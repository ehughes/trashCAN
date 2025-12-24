"""
Message broker for routing CAN messages between plugins.

This module implements the central message router that connects all plugins
in a virtual network, broadcasting CAN messages between them based on their
interface types.
"""

from typing import List
from queue import Empty
import logging
from .can_message import CANMessage
from .plugin_base import PluginBase, PluginInterfaceType


class MessageBroker:
    """
    Central message router for CAN messages between plugins.

    The broker implements a broadcast routing pattern where messages from
    writer plugins are routed to all reader plugins (except the sender).
    This matches the C# PluginProcessLoop functionality but uses a
    single-threaded polling pattern instead of a dedicated thread with locks.

    The broker's tick() method should be called from the main event loop
    to process and route pending messages.

    Example:
        >>> broker = MessageBroker()
        >>> broker.register_plugin(pcan_plugin)
        >>> broker.register_plugin(viewer_plugin)
        >>> while running:
        ...     broker.tick()  # Route messages each iteration
    """

    def __init__(self):
        """Initialize the message broker."""
        self.plugins: List[PluginBase] = []
        self.logger = logging.getLogger("pytrashcan.broker")
        self.paused = False

        # Statistics
        self.messages_routed = 0
        self.plugin_messages_routed = 0

    def register_plugin(self, plugin: PluginBase):
        """
        Add a plugin to the routing pool.

        Args:
            plugin: Plugin instance to register
        """
        self.plugins.append(plugin)
        self.logger.info(
            f"Registered plugin: {plugin.plugin_name} "
            f"(ID: {plugin.instance_id}, Type: {plugin.interface_type.name})"
        )

    def unregister_plugin(self, plugin: PluginBase):
        """
        Remove a plugin from the routing pool.

        Args:
            plugin: Plugin instance to unregister
        """
        if plugin in self.plugins:
            self.plugins.remove(plugin)
            self.logger.info(
                f"Unregistered plugin: {plugin.plugin_name} "
                f"(ID: {plugin.instance_id})"
            )

    def tick(self):
        """
        Single broker iteration - route messages between plugins.

        This method should be called from the main event loop. It routes
        both CAN messages and plugin messages between registered plugins.

        The routing logic:
        - CAN messages from writers → all readers (except sender)
        - Plugin messages with "@" prefix → broadcast to all
        - All plugin messages → logged
        """
        if self.paused:
            return

        # Route CAN messages
        self._route_can_messages()

        # Route plugin messages
        self._route_plugin_messages()

    def _route_can_messages(self):
        """
        Route CAN messages from writers to readers.

        Matches C# routing logic:
        - For each plugin that can write (READ_WRITE or WRITE_ONLY)
        - Dequeue all pending messages from its outgoing queue
        - Route each message to all other plugins that can read
        """
        # For each plugin that can write
        for src_plugin in self.plugins:
            if src_plugin.interface_type in (
                PluginInterfaceType.READ_WRITE,
                PluginInterfaceType.WRITE_ONLY
            ):
                # Process all messages in its outgoing queue
                while True:
                    try:
                        msg = src_plugin.outgoing_can_queue.get_nowait()

                        # Route to all other plugins that can read
                        for dst_plugin in self.plugins:
                            # Don't route back to sender
                            if dst_plugin.instance_id == src_plugin.instance_id:
                                continue

                            # Only route to readers
                            if dst_plugin.interface_type in (
                                PluginInterfaceType.READ_WRITE,
                                PluginInterfaceType.READ_ONLY
                            ):
                                try:
                                    # Non-blocking put
                                    dst_plugin.incoming_can_queue.put_nowait(msg)
                                except:
                                    # Queue full - log and continue
                                    self.logger.warning(
                                        f"Incoming queue full for {dst_plugin.plugin_name}, "
                                        f"message dropped: {msg}"
                                    )

                        self.messages_routed += 1

                    except Empty:
                        break  # No more messages in this queue

    def _route_plugin_messages(self):
        """
        Route plugin messages for inter-plugin communication and logging.

        Plugin messages are text strings used for:
        - Logging/debugging
        - Inter-plugin communication (with "@" prefix for broadcast)

        All plugin messages are logged. Messages starting with "@" are
        broadcast to all other plugins.
        """
        for src_plugin in self.plugins:
            while True:
                try:
                    msg = src_plugin.outgoing_plugin_messages.get_nowait()

                    # Messages starting with @ are broadcast to all plugins
                    if msg.startswith("@"):
                        for dst_plugin in self.plugins:
                            if dst_plugin.instance_id != src_plugin.instance_id:
                                try:
                                    dst_plugin.incoming_plugin_messages.put_nowait(msg)
                                except:
                                    pass  # Silently drop if queue full

                    # Log all plugin messages
                    self.logger.info(
                        f"[{src_plugin.plugin_name}:{src_plugin.instance_id}] {msg}"
                    )

                    self.plugin_messages_routed += 1

                except Empty:
                    break

    def get_statistics(self) -> dict:
        """
        Get broker statistics.

        Returns:
            Dictionary with statistics:
                - active_plugins: Number of registered plugins
                - messages_routed: Total CAN messages routed
                - plugin_messages_routed: Total plugin messages routed
        """
        return {
            'active_plugins': len(self.plugins),
            'messages_routed': self.messages_routed,
            'plugin_messages_routed': self.plugin_messages_routed
        }

    def reset_statistics(self):
        """Reset statistics counters to zero."""
        self.messages_routed = 0
        self.plugin_messages_routed = 0
