"""
Plugin base class and supporting types for PyTrashCAN.

This module provides the abstract base class that all plugins must inherit from,
along with supporting enumerations and state classes.
"""

from abc import ABC, abstractmethod
from enum import Enum
from queue import Queue
from typing import Optional, Dict, Any
import logging


class PluginInterfaceType(Enum):
    """
    Plugin CAN interface type - matches C# CAN_INTERFACE_TYPE enum.

    Defines how a plugin interacts with the CAN message broker:
    - READ_WRITE: Plugin both sends and receives CAN messages
    - READ_ONLY: Plugin only receives CAN messages (viewer/logger/sniffer)
    - WRITE_ONLY: Plugin only sends CAN messages (injector/generator)
    """
    READ_WRITE = 0
    READ_ONLY = 1
    WRITE_ONLY = 2


class PluginState:
    """
    Plugin state for persistence - matches C# PluginState class.

    Stores window position, size, and plugin-specific data for
    saving and restoring application layouts.

    Attributes:
        window_position: (x, y) tuple for window position
        window_size: (width, height) tuple for window dimensions
        window_maximized: Whether window is maximized
        plugin_data: Dictionary for plugin-specific state data
    """

    def __init__(self):
        self.window_position: tuple[int, int] = (100, 100)
        self.window_size: tuple[int, int] = (800, 600)
        self.window_maximized: bool = False
        self.plugin_data: Dict[str, Any] = {}

    def to_dict(self) -> Dict[str, Any]:
        """Serialize to dictionary for JSON persistence."""
        return {
            'window_position': list(self.window_position),
            'window_size': list(self.window_size),
            'window_maximized': self.window_maximized,
            'plugin_data': self.plugin_data
        }

    @classmethod
    def from_dict(cls, d: Dict[str, Any]) -> 'PluginState':
        """Deserialize from dictionary."""
        state = cls()
        state.window_position = tuple(d.get('window_position', [100, 100]))
        state.window_size = tuple(d.get('window_size', [800, 600]))
        state.window_maximized = d.get('window_maximized', False)
        state.plugin_data = d.get('plugin_data', {})
        return state


class PluginBase(ABC):
    """
    Abstract base class for all trashCAN plugins.

    Matches C# ItrashCANPlugin and IPlugin interfaces. All plugins must
    inherit from this class and implement the required abstract methods
    and properties.

    The plugin system uses queue-based message passing for thread-safe
    communication. Each plugin has incoming and outgoing queues for both
    CAN messages and plugin messages (text logging/debugging).

    Lifecycle:
        1. Instantiate plugin class
        2. Assign instance_id
        3. Call init() - must return "OK" on success
        4. Call create_ui() to build GUI
        5. Periodically call update_ui() from main loop
        6. When terminating, call terminate()

    Example:
        >>> class MyPlugin(PluginBase):
        ...     @property
        ...     def plugin_name(self) -> str:
        ...         return "My Plugin"
        ...
        ...     def init(self) -> str:
        ...         # Initialize resources
        ...         return "OK"
        ...
        ...     def create_ui(self, parent):
        ...         # Create DearPyGui window
        ...         pass
    """

    def __init__(self):
        """Initialize plugin with message queues and default state."""
        # CAN message queues (thread-safe with maxsize to prevent memory issues)
        self._incoming_can_queue: Queue = Queue(maxsize=1024)
        self._outgoing_can_queue: Queue = Queue(maxsize=1024)

        # Plugin message queues (for logging/debugging)
        self._incoming_plugin_messages: Queue[str] = Queue(maxsize=1024)
        self._outgoing_plugin_messages: Queue[str] = Queue(maxsize=1024)

        # Plugin state
        self._instance_id: int = -1
        self._request_termination: bool = False
        self._state: PluginState = PluginState()

        # Logging
        self.logger = logging.getLogger(f"pytrashcan.{self.plugin_name}")

    # Abstract properties that must be implemented by subclasses
    @property
    @abstractmethod
    def plugin_name(self) -> str:
        """
        Plugin display name.

        Returns:
            User-friendly name for display in menus and windows
        """
        pass

    @property
    @abstractmethod
    def plugin_version(self) -> str:
        """
        Plugin version string.

        Returns:
            Version string (e.g., "1.0.0", "2.5.1")
        """
        pass

    @property
    @abstractmethod
    def interface_type(self) -> PluginInterfaceType:
        """
        Plugin CAN interface type.

        Determines how the message broker routes messages to/from this plugin.

        Returns:
            PluginInterfaceType enum value
        """
        pass

    # Abstract methods for lifecycle management
    @abstractmethod
    def init(self) -> str:
        """
        Initialize plugin resources.

        Called after instantiation but before GUI creation. Use this to
        initialize any resources, load configurations, etc.

        Returns:
            "OK" on success, error message string on failure
        """
        pass

    @abstractmethod
    def terminate(self) -> str:
        """
        Clean shutdown of plugin resources.

        Called when plugin is being destroyed. Clean up any resources,
        close connections, save state, etc.

        Returns:
            "OK" on success, error message string on failure
        """
        pass

    @abstractmethod
    def create_ui(self, parent) -> Any:
        """
        Create and return the plugin's UI panel.

        Called after init() to create the plugin's GUI window/panel.

        Args:
            parent: DearPyGui parent window/container (currently unused,
                   plugins create top-level windows)

        Returns:
            The DearPyGui window ID/tag for the created window
        """
        pass

    @abstractmethod
    def update_ui(self):
        """
        Update UI elements.

        Called periodically by the main event loop (typically 60Hz).
        Process incoming message queues and update display elements.

        This is where plugins should:
        - Dequeue and process incoming CAN messages
        - Update UI elements with new data
        - Process user input if needed
        """
        pass

    # Concrete properties (implementations provided)
    @property
    def instance_id(self) -> int:
        """
        Unique instance ID assigned by host.

        Returns:
            Integer instance ID, -1 if not yet assigned
        """
        return self._instance_id

    @instance_id.setter
    def instance_id(self, value: int):
        """Set instance ID (called by PluginHost)."""
        self._instance_id = value

    @property
    def request_termination(self) -> bool:
        """
        Flag indicating plugin requests to be terminated.

        Plugins can set this to True to request graceful shutdown.

        Returns:
            True if termination requested
        """
        return self._request_termination

    @property
    def incoming_can_queue(self) -> Queue:
        """
        Queue for receiving CAN messages from broker.

        The message broker puts messages into this queue. Plugins should
        dequeue and process messages in update_ui().

        Returns:
            Queue containing CANMessage objects
        """
        return self._incoming_can_queue

    @property
    def outgoing_can_queue(self) -> Queue:
        """
        Queue for sending CAN messages to broker.

        Plugins put messages into this queue to send to other plugins.
        The broker dequeues and routes these messages.

        Returns:
            Queue for placing CANMessage objects
        """
        return self._outgoing_can_queue

    @property
    def incoming_plugin_messages(self) -> Queue:
        """
        Queue for receiving plugin messages.

        Currently used for logging and debugging purposes.

        Returns:
            Queue containing string messages
        """
        return self._incoming_plugin_messages

    @property
    def outgoing_plugin_messages(self) -> Queue:
        """
        Queue for sending plugin messages.

        Messages starting with "@" are broadcast to all plugins.
        All messages are logged.

        Returns:
            Queue for placing string messages
        """
        return self._outgoing_plugin_messages

    @property
    def state(self) -> PluginState:
        """
        Plugin state for persistence.

        Returns:
            PluginState object containing window position/size and custom data
        """
        return self._state

    @state.setter
    def state(self, value: PluginState):
        """Set plugin state (used when restoring from saved layout)."""
        self._state = value

    # Helper methods for subclasses
    def send_can_message(self, msg):
        """
        Send a CAN message to the broker.

        Convenience method to enqueue a CAN message for transmission.
        If queue is full, message is dropped with a warning.

        Args:
            msg: CANMessage object to send
        """
        if not self._outgoing_can_queue.full():
            self._outgoing_can_queue.put(msg)
        else:
            self.logger.warning("Outgoing CAN queue full, message dropped")

    def send_plugin_message(self, msg: str):
        """
        Send a plugin message for logging.

        Args:
            msg: String message to send
        """
        if not self._outgoing_plugin_messages.full():
            self._outgoing_plugin_messages.put(msg)

    def get_can_message(self, block: bool = False, timeout: Optional[float] = None):
        """
        Get a CAN message from incoming queue.

        Convenience method to dequeue CAN messages.

        Args:
            block: Whether to block waiting for a message
            timeout: Maximum time to wait (only used if block=True)

        Returns:
            CANMessage object or None if queue is empty
        """
        try:
            return self._incoming_can_queue.get(block=block, timeout=timeout)
        except:
            return None
