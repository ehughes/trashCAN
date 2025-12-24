"""
Plugin host for managing plugin lifecycle and state persistence.

This module provides the PluginHost class which manages the creation,
destruction, and state persistence of plugin instances.
"""

from typing import List, Dict, Type, Optional
import logging
import json
from pathlib import Path
from .plugin_base import PluginBase, PluginState
from .broker import MessageBroker


class PluginInstance:
    """
    Container for plugin instance with metadata.

    Attributes:
        plugin: The actual plugin object
        instance_id: Unique identifier for this instance
    """

    def __init__(self, plugin: PluginBase, instance_id: int):
        self.plugin = plugin
        self.instance_id = instance_id


class PluginHost:
    """
    Plugin lifecycle manager - matches C# trashCANHost functionality.

    Manages plugin instances, including:
    - Registration of available plugin types
    - Creation and destruction of plugin instances
    - Assignment of unique instance IDs
    - State persistence (save/restore layouts)
    - Termination request handling

    Unlike the C# version which uses reflection to discover plugins,
    this implementation requires explicit registration of plugin types.

    Example:
        >>> host = PluginHost(broker)
        >>> host.register_plugin_type(PCANAdapterPlugin)
        >>> instance = host.create_plugin_instance("PCAN Adapter>2.0.0")
        >>> host.save_state(Path("layout.json"))
    """

    def __init__(self, broker: MessageBroker):
        """
        Initialize plugin host.

        Args:
            broker: MessageBroker instance for routing messages
        """
        self.broker = broker
        self.available_plugins: Dict[str, Type[PluginBase]] = {}
        self.active_plugins: List[PluginInstance] = []
        self.next_instance_id = 0
        self.logger = logging.getLogger("pytrashcan.host")

    def register_plugin_type(self, plugin_class: Type[PluginBase]):
        """
        Register a plugin class as available.

        Unlike C# reflection-based discovery, we use explicit registration
        which is more Pythonic and easier to debug.

        Args:
            plugin_class: Plugin class (must inherit from PluginBase)
        """
        # Create temporary instance to get metadata
        temp = plugin_class()
        name = temp.plugin_name
        version = temp.plugin_version

        # Create key: "PluginName>Version"
        key = f"{name}>{version}"
        self.available_plugins[key] = plugin_class
        self.logger.info(f"Registered plugin type: {key}")

    def create_plugin_instance(
        self,
        plugin_key: str,
        state: Optional[PluginState] = None
    ) -> Optional[PluginInstance]:
        """
        Create and initialize a new plugin instance.

        Args:
            plugin_key: Plugin name>version key (e.g., "PCAN Adapter>2.0.0")
            state: Optional state to restore (window position, custom data)

        Returns:
            PluginInstance object, or None if creation failed
        """
        if plugin_key not in self.available_plugins:
            self.logger.error(
                f"Plugin {plugin_key} not found in available plugins. "
                f"Available: {list(self.available_plugins.keys())}"
            )
            return None

        try:
            # Instantiate plugin
            plugin_class = self.available_plugins[plugin_key]
            plugin = plugin_class()

            # Assign instance ID
            instance_id = self.next_instance_id
            self.next_instance_id += 1
            plugin.instance_id = instance_id

            # Initialize
            result = plugin.init()
            if result != "OK":
                self.logger.error(
                    f"Plugin {plugin_key} init() failed: {result}"
                )
                return None

            # Restore state if provided
            if state:
                plugin.state = state

            # Register with broker
            self.broker.register_plugin(plugin)

            # Create instance record
            instance = PluginInstance(plugin, instance_id)
            self.active_plugins.append(instance)

            self.logger.info(
                f"Created plugin instance {instance_id}: "
                f"{plugin.plugin_name} v{plugin.plugin_version}"
            )

            return instance

        except Exception as e:
            self.logger.error(
                f"Failed to create plugin instance {plugin_key}: {e}",
                exc_info=True
            )
            return None

    def destroy_plugin_instance(self, instance_id: int) -> bool:
        """
        Terminate and remove a plugin instance.

        Args:
            instance_id: ID of instance to destroy

        Returns:
            True if successful, False if instance not found or error occurred
        """
        # Find instance
        instance = None
        for inst in self.active_plugins:
            if inst.instance_id == instance_id:
                instance = inst
                break

        if not instance:
            self.logger.error(f"Instance {instance_id} not found")
            return False

        try:
            # Terminate plugin
            result = instance.plugin.terminate()
            if result != "OK":
                self.logger.warning(
                    f"Plugin {instance.plugin.plugin_name} terminate() "
                    f"returned: {result}"
                )

            # Unregister from broker
            self.broker.unregister_plugin(instance.plugin)

            # Remove from active list
            self.active_plugins.remove(instance)

            self.logger.info(
                f"Destroyed plugin instance {instance_id}: "
                f"{instance.plugin.plugin_name}"
            )
            return True

        except Exception as e:
            self.logger.error(
                f"Failed to destroy instance {instance_id}: {e}",
                exc_info=True
            )
            return False

    def check_termination_requests(self):
        """
        Check for plugins requesting termination (matches C# pattern).

        Should be called periodically from main loop. Destroys any plugins
        that have set their request_termination flag to True.
        """
        to_remove = []
        for instance in self.active_plugins:
            if instance.plugin.request_termination:
                to_remove.append(instance.instance_id)

        for instance_id in to_remove:
            self.logger.info(
                f"Plugin {instance_id} requested termination"
            )
            self.destroy_plugin_instance(instance_id)

    def save_state(self, filepath: Path):
        """
        Save all plugin states to file (matches C# .bag file concept).

        Uses JSON instead of XML for Python simplicity and readability.

        Args:
            filepath: Path to save state file

        Raises:
            IOError: If file cannot be written
        """
        state_data = {
            'version': '1.0.0',
            'plugins': []
        }

        for instance in self.active_plugins:
            plugin = instance.plugin
            plugin_record = {
                'key': f"{plugin.plugin_name}>{plugin.plugin_version}",
                'instance_id': instance.instance_id,
                'state': plugin.state.to_dict()
            }
            state_data['plugins'].append(plugin_record)

        with open(filepath, 'w') as f:
            json.dump(state_data, f, indent=2)

        self.logger.info(
            f"Saved state to {filepath} ({len(self.active_plugins)} plugins)"
        )

    def restore_state(self, filepath: Path):
        """
        Restore plugin states from file.

        Terminates all existing plugins first, then recreates plugins
        from the saved state.

        Args:
            filepath: Path to state file to restore

        Raises:
            IOError: If file cannot be read
            ValueError: If state file is invalid
        """
        # Terminate all existing plugins
        for instance in list(self.active_plugins):
            self.destroy_plugin_instance(instance.instance_id)

        # Load state file
        with open(filepath, 'r') as f:
            state_data = json.load(f)

        # Validate version (for future compatibility)
        version = state_data.get('version', '1.0.0')
        self.logger.info(f"Restoring state from version {version}")

        # Recreate plugins
        plugins_restored = 0
        for plugin_record in state_data.get('plugins', []):
            plugin_key = plugin_record['key']
            state = PluginState.from_dict(plugin_record['state'])

            if self.create_plugin_instance(plugin_key, state):
                plugins_restored += 1
            else:
                self.logger.warning(
                    f"Failed to restore plugin: {plugin_key}"
                )

        self.logger.info(
            f"Restored {plugins_restored} plugins from {filepath}"
        )

    def shutdown(self):
        """
        Terminate all plugins and cleanup.

        Should be called before application exit.
        """
        self.logger.info("Shutting down plugin host...")
        for instance in list(self.active_plugins):
            self.destroy_plugin_instance(instance.instance_id)
        self.logger.info("Plugin host shutdown complete")
