"""
CAN Message Viewer/Sniffer Plugin.

Displays received CAN messages in a table with filtering and statistics.
"""

import dearpygui.dearpygui as dpg
from collections import deque
from typing import Optional

from ..core.plugin_base import PluginBase, PluginInterfaceType
from ..core.can_message import CANMessage


class ViewerPlugin(PluginBase):
    """
    CAN message viewer/sniffer - displays received messages.

    Matches C# CANMessageSniffer plugin functionality.
    Uses DearPyGui table for high-performance display of real-time
    CAN bus traffic.

    Features:
    - Real-time message display
    - Circular buffer (configurable max messages)
    - Newest-first display order
    - Statistics tracking
    - Clear function

    Type: READ_ONLY (only receives messages, doesn't send)
    """

    def __init__(self):
        super().__init__()

        # Message buffer (limited size for performance)
        self.max_messages = 128
        self.message_buffer = deque(maxlen=self.max_messages)

        # Statistics
        self.messages_received = 0

        # UI tags
        self.window_tag = f"viewer_window_{id(self)}"
        self.table_tag = f"{self.window_tag}_table"

        # UI update optimization (only rebuild table when needed)
        self._needs_table_refresh = False

    @property
    def plugin_name(self) -> str:
        return "Message Viewer"

    @property
    def plugin_version(self) -> str:
        return "2.0.0"

    @property
    def interface_type(self) -> PluginInterfaceType:
        return PluginInterfaceType.READ_ONLY

    def init(self) -> str:
        """Initialize plugin."""
        self.send_plugin_message("Message Viewer initialized")
        return "OK"

    def terminate(self) -> str:
        """Terminate plugin."""
        self.send_plugin_message("Message Viewer terminating")
        return "OK"

    def create_ui(self, parent) -> str:
        """Create viewer UI window."""
        with dpg.window(
            label=f"{self.plugin_name} v{self.plugin_version} (Instance {self.instance_id})",
            tag=self.window_tag,
            width=800,
            height=500,
            pos=(420, 320),
            on_close=lambda: self._on_window_close()
        ):
            # Statistics and controls
            with dpg.group(horizontal=True):
                dpg.add_text("Messages:", tag=f"{self.window_tag}_msg_count")
                dpg.add_button(
                    label="Clear",
                    callback=self._clear_buffer,
                    width=80
                )

            dpg.add_separator()

            # Message table
            with dpg.table(
                tag=self.table_tag,
                header_row=True,
                borders_outerH=True,
                borders_innerV=True,
                borders_innerH=True,
                borders_outerV=True,
                scrollY=True,
                height=-1,
                policy=dpg.mvTable_SizingFixedFit
            ):
                dpg.add_table_column(label="Timestamp", width_fixed=True, init_width_or_weight=140)
                dpg.add_table_column(label="ID", width_fixed=True, init_width_or_weight=120)
                dpg.add_table_column(label="DLC", width_fixed=True, init_width_or_weight=50)
                dpg.add_table_column(label="Data", width_stretch=True)
                dpg.add_table_column(label="Flags", width_fixed=True, init_width_or_weight=80)

        return self.window_tag

    def update_ui(self):
        """Update UI - process incoming messages and refresh display."""
        if not dpg.does_item_exist(self.window_tag):
            return

        # Process incoming messages
        new_messages = 0
        while True:
            msg = self.get_can_message(block=False)
            if not msg:
                break

            self.message_buffer.append(msg)
            self.messages_received += 1
            new_messages += 1
            self._needs_table_refresh = True

        # Update statistics
        dpg.set_value(
            f"{self.window_tag}_msg_count",
            f"Messages: {self.messages_received:,} (Buffer: {len(self.message_buffer)})"
        )

        # Refresh table only if there are new messages
        if self._needs_table_refresh and new_messages > 0:
            self._refresh_table()
            self._needs_table_refresh = False

    def _refresh_table(self):
        """Rebuild message table from buffer."""
        if not dpg.does_item_exist(self.table_tag):
            return

        # Clear existing rows
        dpg.delete_item(self.table_tag, children_only=True, slot=1)

        # Add rows in reverse order (newest first)
        for msg in reversed(self.message_buffer):
            with dpg.table_row(parent=self.table_tag):
                # Timestamp
                dpg.add_text(f"{msg.timestamp:.6f}")

                # ID
                if msg.is_extended_id:
                    id_text = f"0x{msg.arbitration_id:08X}"
                else:
                    id_text = f"0x{msg.arbitration_id:03X}"
                dpg.add_text(id_text)

                # DLC
                dpg.add_text(str(msg.dlc))

                # Data
                if msg.data:
                    data_text = " ".join(f"{b:02X}" for b in msg.data)
                else:
                    data_text = ""
                dpg.add_text(data_text)

                # Flags
                flags = []
                if msg.is_extended_id:
                    flags.append("EXT")
                if msg.is_remote_frame:
                    flags.append("RTR")
                if msg.is_error_frame:
                    flags.append("ERR")
                dpg.add_text(" ".join(flags))

    def _clear_buffer(self):
        """Clear message buffer and statistics."""
        self.message_buffer.clear()
        self.messages_received = 0
        self._refresh_table()
        self.send_plugin_message("Buffer cleared")

    def _on_window_close(self):
        """Window close button clicked."""
        self._request_termination = True
