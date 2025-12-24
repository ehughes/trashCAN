"""
Main GUI application for PyTrashCAN using DearPyGui.

This module provides the main application window and event loop that
integrates the broker, plugin host, and all GUI components.
"""

import dearpygui.dearpygui as dpg
from pathlib import Path
import logging
import sys
from typing import Dict, Any

from ..core.host import PluginHost
from ..core.broker import MessageBroker


class TrashCANApp:
    """
    Main application - matches C# trashCANHost form.

    Manages DearPyGui context, main event loop, and coordinates
    between the plugin host, message broker, and GUI.

    The main loop performs these steps each frame:
    1. broker.tick() - Route messages between plugins
    2. host.check_termination_requests() - Handle plugin shutdowns
    3. Update all plugin UIs
    4. dpg.render_dearpygui_frame() - Render the frame

    Example:
        >>> app = TrashCANApp()
        >>> app.setup()
        >>> app.register_plugins()
        >>> app.run()
    """

    def __init__(self):
        """Initialize application components."""
        # Core components
        self.broker = MessageBroker()
        self.host = PluginHost(self.broker)

        # Setup logging
        logging.basicConfig(
            level=logging.INFO,
            format='%(asctime)s - %(name)s - %(levelname)s - %(message)s'
        )
        self.logger = logging.getLogger("pytrashcan.app")

        # UI state
        self.plugin_windows: Dict[int, Any] = {}  # instance_id -> window_tag mapping
        self._running = False

        # State file
        self.state_file = Path("last_state.json")

    def setup(self):
        """Initialize DearPyGui and create main window."""
        self.logger.info("Setting up PyTrashCAN application...")

        dpg.create_context()

        # Setup theme
        self._setup_theme()

        # Create main window
        with dpg.window(
            label="PyTrashCAN - CAN Development Tool",
            tag="main_window",
            width=400,
            height=700,
            pos=(10, 10),
            no_close=True
        ):

            # Menu bar
            with dpg.menu_bar():
                with dpg.menu(label="File"):
                    dpg.add_menu_item(
                        label="Save Layout",
                        callback=self._save_layout
                    )
                    dpg.add_menu_item(
                        label="Restore Layout",
                        callback=self._restore_layout
                    )
                    dpg.add_separator()
                    dpg.add_menu_item(
                        label="Exit",
                        callback=self._exit_app
                    )

                # Plugins menu (will be populated dynamically)
                with dpg.menu(label="Plugins", tag="plugins_menu"):
                    dpg.add_text("No plugins registered", tag="plugins_menu_placeholder")

                with dpg.menu(label="Tools"):
                    dpg.add_menu_item(
                        label="Broker Statistics",
                        callback=self._show_broker_stats
                    )
                    dpg.add_menu_item(
                        label="Reset Statistics",
                        callback=self._reset_statistics
                    )

                with dpg.menu(label="Help"):
                    dpg.add_menu_item(
                        label="About",
                        callback=self._show_about
                    )

            # Active plugins section
            dpg.add_text("Active Plugin Instances:")
            dpg.add_separator()

            # Active plugins table
            with dpg.table(
                tag="active_plugins_table",
                header_row=True,
                borders_outerH=True,
                borders_innerV=True,
                borders_innerH=True,
                borders_outerV=True,
                scrollY=True,
                height=200
            ):
                dpg.add_table_column(label="ID", width_fixed=True, init_width_or_weight=40)
                dpg.add_table_column(label="Name")
                dpg.add_table_column(label="Version", width_fixed=True, init_width_or_weight=70)
                dpg.add_table_column(label="Type", width_fixed=True, init_width_or_weight=80)
                dpg.add_table_column(label="Actions", width_fixed=True, init_width_or_weight=80)

            dpg.add_separator()

            # Statistics
            dpg.add_text("Broker Statistics:", color=(200, 200, 255))
            dpg.add_text("Messages Routed: 0", tag="stats_messages")
            dpg.add_text("Plugin Messages: 0", tag="stats_plugin_msgs")
            dpg.add_text("Active Plugins: 0", tag="stats_active_plugins")

        # Setup viewport
        dpg.create_viewport(
            title="PyTrashCAN - CAN Development Tool",
            width=1400,
            height=900
        )
        dpg.setup_dearpygui()
        dpg.show_viewport()

        self.logger.info("DearPyGui setup complete")

    def _setup_theme(self):
        """Configure DearPyGui theme for CAN tool aesthetic."""
        with dpg.theme() as global_theme:
            with dpg.theme_component(dpg.mvAll):
                # Dark theme colors
                dpg.add_theme_color(dpg.mvThemeCol_WindowBg, (15, 15, 15))
                dpg.add_theme_color(dpg.mvThemeCol_ChildBg, (20, 20, 20))
                dpg.add_theme_color(dpg.mvThemeCol_FrameBg, (30, 30, 30))
                dpg.add_theme_color(dpg.mvThemeCol_FrameBgHovered, (45, 45, 45))
                dpg.add_theme_color(dpg.mvThemeCol_FrameBgActive, (50, 50, 50))
                dpg.add_theme_color(dpg.mvThemeCol_Button, (50, 50, 180))
                dpg.add_theme_color(dpg.mvThemeCol_ButtonHovered, (70, 70, 200))
                dpg.add_theme_color(dpg.mvThemeCol_ButtonActive, (90, 90, 220))
                dpg.add_theme_color(dpg.mvThemeCol_Header, (50, 50, 180))
                dpg.add_theme_color(dpg.mvThemeCol_HeaderHovered, (70, 70, 200))
                dpg.add_theme_color(dpg.mvThemeCol_HeaderActive, (90, 90, 220))
                dpg.add_theme_color(dpg.mvThemeCol_TableHeaderBg, (40, 40, 100))

                # Styling
                dpg.add_theme_style(dpg.mvStyleVar_FrameRounding, 3)
                dpg.add_theme_style(dpg.mvStyleVar_WindowRounding, 5)
                dpg.add_theme_style(dpg.mvStyleVar_ChildRounding, 3)
                dpg.add_theme_style(dpg.mvStyleVar_GrabRounding, 3)

        dpg.bind_theme(global_theme)

    def register_plugins(self):
        """
        Register all available plugin types.

        Import and register plugin classes here. This makes them
        available for instantiation through the Plugins menu.
        """
        self.logger.info("Registering plugin types...")

        # Import plugin classes
        from ..plugins.pcan_adapter import PCANAdapterPlugin
        from ..plugins.injector import InjectorPlugin
        from ..plugins.viewer import ViewerPlugin

        # Register with host
        self.host.register_plugin_type(PCANAdapterPlugin)
        self.host.register_plugin_type(InjectorPlugin)
        self.host.register_plugin_type(ViewerPlugin)

        # Update plugins menu
        self._update_plugins_menu()

        self.logger.info(f"Registered {len(self.host.available_plugins)} plugin types")

    def _update_plugins_menu(self):
        """Rebuild plugins menu with available plugin types."""
        # Remove placeholder
        if dpg.does_item_exist("plugins_menu_placeholder"):
            dpg.delete_item("plugins_menu_placeholder")

        # Add menu item for each plugin type
        for key in sorted(self.host.available_plugins.keys()):
            # Check if menu item already exists
            menu_item_tag = f"plugin_menu_{key}"
            if not dpg.does_item_exist(menu_item_tag):
                dpg.add_menu_item(
                    label=f"New {key.split('>')[0]}",
                    callback=lambda s, a, u: self._create_plugin(u),
                    user_data=key,
                    parent="plugins_menu",
                    tag=menu_item_tag
                )

    def _create_plugin(self, plugin_key: str):
        """
        Create new plugin instance and its UI.

        Args:
            plugin_key: Plugin name>version key
        """
        self.logger.info(f"Creating plugin: {plugin_key}")

        instance = self.host.create_plugin_instance(plugin_key)
        if instance:
            # Create plugin UI
            try:
                window_tag = instance.plugin.create_ui(parent=None)
                self.plugin_windows[instance.instance_id] = window_tag

                # Update active plugins table
                self._update_active_plugins_table()

                self.logger.info(
                    f"Created plugin instance {instance.instance_id}: "
                    f"{instance.plugin.plugin_name}"
                )
            except Exception as e:
                self.logger.error(
                    f"Failed to create UI for {plugin_key}: {e}",
                    exc_info=True
                )
                # Cleanup failed plugin
                self.host.destroy_plugin_instance(instance.instance_id)
        else:
            self.logger.error(f"Failed to create plugin instance: {plugin_key}")

    def _update_active_plugins_table(self):
        """Refresh the active plugins table."""
        # Clear existing rows
        dpg.delete_item("active_plugins_table", children_only=True, slot=1)

        # Repopulate with current plugins
        for instance in self.host.active_plugins:
            with dpg.table_row(parent="active_plugins_table"):
                dpg.add_text(str(instance.instance_id))
                dpg.add_text(instance.plugin.plugin_name)
                dpg.add_text(instance.plugin.plugin_version)
                dpg.add_text(instance.plugin.interface_type.name)
                dpg.add_button(
                    label="Destroy",
                    callback=lambda s, a, u: self._destroy_plugin(u),
                    user_data=instance.instance_id,
                    width=-1
                )

    def _destroy_plugin(self, instance_id: int):
        """
        Destroy plugin instance and its UI.

        Args:
            instance_id: ID of instance to destroy
        """
        self.logger.info(f"Destroying plugin instance {instance_id}")

        # Delete UI window if it exists
        if instance_id in self.plugin_windows:
            window_tag = self.plugin_windows[instance_id]
            if dpg.does_item_exist(window_tag):
                dpg.delete_item(window_tag)
            del self.plugin_windows[instance_id]

        # Destroy plugin
        self.host.destroy_plugin_instance(instance_id)

        # Update table
        self._update_active_plugins_table()

    def run(self):
        """
        Main event loop.

        This is the heart of the application. Each iteration:
        1. Routes messages between plugins (broker.tick())
        2. Checks for plugin termination requests
        3. Updates all plugin UIs
        4. Updates statistics display
        5. Renders the frame
        """
        self.logger.info("Starting PyTrashCAN main loop...")
        self._running = True

        # Restore last state if exists
        if self.state_file.exists():
            try:
                self.logger.info(f"Restoring state from {self.state_file}")
                self.host.restore_state(self.state_file)
                # Recreate UI for restored plugins
                for instance in self.host.active_plugins:
                    window_tag = instance.plugin.create_ui(parent=None)
                    self.plugin_windows[instance.instance_id] = window_tag
                self._update_active_plugins_table()
            except Exception as e:
                self.logger.warning(f"Failed to restore state: {e}")

        # Main loop
        frame_count = 0
        while dpg.is_dearpygui_running() and self._running:
            try:
                # 1. Broker tick - route messages
                self.broker.tick()

                # 2. Check for plugin termination requests
                self.host.check_termination_requests()

                # 3. Update all plugin UIs
                for instance in self.host.active_plugins:
                    try:
                        instance.plugin.update_ui()
                    except Exception as e:
                        self.logger.error(
                            f"Error updating UI for {instance.plugin.plugin_name}: {e}",
                            exc_info=True
                        )

                # 4. Update statistics display (every 60 frames ~ 1 second at 60Hz)
                frame_count += 1
                if frame_count % 60 == 0:
                    self._update_statistics_display()

                # 5. Render frame
                dpg.render_dearpygui_frame()

            except Exception as e:
                self.logger.error(f"Error in main loop: {e}", exc_info=True)

        # Cleanup
        self._shutdown()

    def _update_statistics_display(self):
        """Update the statistics text in main window."""
        stats = self.broker.get_statistics()
        dpg.set_value("stats_messages", f"Messages Routed: {stats['messages_routed']:,}")
        dpg.set_value(
            "stats_plugin_msgs",
            f"Plugin Messages: {stats['plugin_messages_routed']:,}"
        )
        dpg.set_value("stats_active_plugins", f"Active Plugins: {stats['active_plugins']}")

    def _shutdown(self):
        """Clean shutdown."""
        self.logger.info("Shutting down PyTrashCAN...")

        # Save state
        try:
            self.logger.info(f"Saving state to {self.state_file}")
            self.host.save_state(self.state_file)
        except Exception as e:
            self.logger.error(f"Failed to save state: {e}")

        # Terminate all plugins
        self.host.shutdown()

        # Cleanup DearPyGui
        dpg.destroy_context()

        self.logger.info("Shutdown complete")

    # Menu callbacks
    def _save_layout(self):
        """Save current layout."""
        try:
            self.host.save_state(self.state_file)
            self.logger.info("Layout saved")
        except Exception as e:
            self.logger.error(f"Failed to save layout: {e}")

    def _restore_layout(self):
        """Restore saved layout."""
        if not self.state_file.exists():
            self.logger.warning("No saved layout found")
            return

        try:
            # Destroy existing plugin windows
            for instance_id in list(self.plugin_windows.keys()):
                self._destroy_plugin(instance_id)

            # Restore state
            self.host.restore_state(self.state_file)

            # Recreate UI for restored plugins
            for instance in self.host.active_plugins:
                window_tag = instance.plugin.create_ui(parent=None)
                self.plugin_windows[instance.instance_id] = window_tag

            self._update_active_plugins_table()
            self.logger.info("Layout restored")

        except Exception as e:
            self.logger.error(f"Failed to restore layout: {e}")

    def _exit_app(self):
        """Exit application."""
        self.logger.info("Exit requested")
        self._running = False
        dpg.stop_dearpygui()

    def _show_broker_stats(self):
        """Show broker statistics window."""
        stats = self.broker.get_statistics()

        # Create or show stats window
        if dpg.does_item_exist("stats_window"):
            dpg.show_item("stats_window")
        else:
            with dpg.window(
                label="Broker Statistics",
                tag="stats_window",
                width=400,
                height=200,
                pos=(420, 10),
                modal=False
            ):
                dpg.add_text(f"Active Plugins: {stats['active_plugins']}")
                dpg.add_text(f"CAN Messages Routed: {stats['messages_routed']:,}")
                dpg.add_text(
                    f"Plugin Messages Routed: {stats['plugin_messages_routed']:,}"
                )
                dpg.add_separator()
                dpg.add_button(label="Close", callback=lambda: dpg.hide_item("stats_window"))

    def _reset_statistics(self):
        """Reset broker statistics."""
        self.broker.reset_statistics()
        self.logger.info("Statistics reset")

    def _show_about(self):
        """Show about dialog."""
        if dpg.does_item_exist("about_window"):
            dpg.show_item("about_window")
        else:
            with dpg.window(
                label="About PyTrashCAN",
                tag="about_window",
                width=400,
                height=250,
                pos=(500, 300),
                modal=True
            ):
                dpg.add_text("PyTrashCAN", color=(100, 200, 255))
                dpg.add_text("Version 1.0.0")
                dpg.add_separator()
                dpg.add_text("Python CAN Bus Development and Testing Tool")
                dpg.add_text("")
                dpg.add_text("A modern Python port of the trashCAN C# application.")
                dpg.add_text("Plugin-based architecture for CAN bus development,")
                dpg.add_text("testing, and analysis.")
                dpg.add_separator()
                dpg.add_button(
                    label="Close",
                    callback=lambda: dpg.hide_item("about_window"),
                    width=-1
                )
