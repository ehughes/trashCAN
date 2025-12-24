"""
CAN Message Injector Plugin.

Allows manual composition and transmission of CAN messages.
"""

import dearpygui.dearpygui as dpg
import re
import time

from ..core.plugin_base import PluginBase, PluginInterfaceType
from ..core.can_message import CANMessage


class InjectorPlugin(PluginBase):
    """
    CAN message injector - manual message transmission.

    Matches C# CANMessageInjector plugin functionality.

    Features:
    - Text-based message input with validation
    - Extended ID and RTR frame support
    - Auto-send with configurable interval
    - Statistics tracking
    - Input validation and auto-formatting

    Type: WRITE_ONLY (only sends messages, doesn't receive)
    """

    def __init__(self):
        super().__init__()

        # Message composition state
        self.message_text = "0x123 : 0x00 0x01 0x02"
        self.extended_id = False
        self.rtr_frame = False

        # Auto-send state
        self.auto_send_enabled = False
        self.auto_send_interval_ms = 100
        self.last_auto_send_time = 0.0

        # Statistics
        self.messages_sent = 0

        # UI tags
        self.window_tag = f"injector_window_{id(self)}"

    @property
    def plugin_name(self) -> str:
        return "Message Injector"

    @property
    def plugin_version(self) -> str:
        return "2.0.0"

    @property
    def interface_type(self) -> PluginInterfaceType:
        return PluginInterfaceType.WRITE_ONLY

    def init(self) -> str:
        """Initialize plugin."""
        self.send_plugin_message("Message Injector initialized")
        return "OK"

    def terminate(self) -> str:
        """Terminate plugin."""
        self.send_plugin_message("Message Injector terminating")
        return "OK"

    def create_ui(self, parent) -> str:
        """Create injector UI."""
        with dpg.window(
            label=f"{self.plugin_name} v{self.plugin_version} (Instance {self.instance_id})",
            tag=self.window_tag,
            width=550,
            height=400,
            pos=(840, 10),
            on_close=lambda: self._on_window_close()
        ):
            dpg.add_text("CAN Message Composition:")
            dpg.add_separator()

            # Message input
            dpg.add_text("Message Format: 0xID : 0xByte0 0xByte1 ...")
            dpg.add_input_text(
                tag=f"{self.window_tag}_msg_input",
                default_value=self.message_text,
                width=-1,
                hint="0xID : 0xByte0 0xByte1 ...",
                on_enter=True,
                callback=self._on_enter_pressed
            )

            dpg.add_text("(Press ENTER to send, or click Send button)")
            dpg.add_separator()

            # Checkboxes
            dpg.add_checkbox(
                label="Extended ID (29-bit)",
                tag=f"{self.window_tag}_extended",
                default_value=self.extended_id,
                callback=self._on_extended_changed
            )

            dpg.add_checkbox(
                label="RTR (Remote Transmission Request)",
                tag=f"{self.window_tag}_rtr",
                default_value=self.rtr_frame,
                callback=self._on_rtr_changed
            )

            dpg.add_separator()

            # Send button
            dpg.add_button(
                label="Send Message",
                callback=self._send_message,
                width=150,
                height=30
            )

            dpg.add_separator()

            # Auto-send controls
            dpg.add_text("Auto-Send:")
            dpg.add_checkbox(
                label="Enable Auto-Send",
                tag=f"{self.window_tag}_auto_send",
                callback=self._on_auto_send_changed
            )

            with dpg.group(horizontal=True):
                dpg.add_text("Interval (ms):")
                dpg.add_input_int(
                    tag=f"{self.window_tag}_interval",
                    default_value=self.auto_send_interval_ms,
                    min_value=10,
                    max_value=10000,
                    width=100,
                    callback=self._on_interval_changed
                )

            dpg.add_separator()

            # Statistics
            dpg.add_text("Statistics:")
            dpg.add_text("Messages Sent: 0", tag=f"{self.window_tag}_sent_count")
            dpg.add_button(
                label="Clear Statistics",
                callback=self._clear_statistics,
                width=150
            )

        return self.window_tag

    def update_ui(self):
        """Update UI elements and handle auto-send."""
        if not dpg.does_item_exist(self.window_tag):
            return

        # Update statistics
        dpg.set_value(
            f"{self.window_tag}_sent_count",
            f"Messages Sent: {self.messages_sent:,}"
        )

        # Auto-send logic
        if self.auto_send_enabled:
            current_time = time.time()
            interval_seconds = self.auto_send_interval_ms / 1000.0

            if current_time - self.last_auto_send_time >= interval_seconds:
                self._send_message()
                self.last_auto_send_time = current_time

    def _validate_and_parse_message(self, text: str) -> tuple[bool, CANMessage]:
        """
        Parse and validate message text.

        Format: 0xID : 0xByte0 0xByte1 ...

        Args:
            text: Input text to parse

        Returns:
            Tuple of (valid, CANMessage or None)
        """
        try:
            # Extract hex values using regex (matches C# pattern)
            pattern = r'\s*0x([0-9a-fA-F]+)\s*'
            matches = re.findall(pattern, text)

            if len(matches) == 0:
                self.logger.warning("No hex values found in message text")
                return False, None

            # First match is ID
            arb_id = int(matches[0], 16)

            # Validate ID range
            if self.extended_id:
                if arb_id > 0x1FFFFFFF:
                    arb_id = 0x1FFFFFFF  # Clamp to max
            else:
                if arb_id > 0x7FF:
                    arb_id = 0x7FF  # Clamp to max

            # Remaining matches are data bytes (max 8)
            data_bytes = []
            for hex_str in matches[1:9]:  # Max 8 bytes
                data_bytes.append(int(hex_str, 16) & 0xFF)

            # Create message
            msg = CANMessage(
                arbitration_id=arb_id,
                data=bytes(data_bytes) if not self.rtr_frame else bytes(),
                is_extended_id=self.extended_id,
                is_remote_frame=self.rtr_frame
            )

            # Update text with cleaned version
            self.message_text = str(msg)
            if dpg.does_item_exist(f"{self.window_tag}_msg_input"):
                dpg.set_value(f"{self.window_tag}_msg_input", self.message_text)

            return True, msg

        except Exception as e:
            self.logger.error(f"Message parse error: {e}")
            return False, None

    def _send_message(self):
        """Send the composed message."""
        if not dpg.does_item_exist(f"{self.window_tag}_msg_input"):
            return

        text = dpg.get_value(f"{self.window_tag}_msg_input")
        valid, msg = self._validate_and_parse_message(text)

        if valid and msg:
            self.send_can_message(msg)
            self.messages_sent += 1
            self.send_plugin_message(f"Sent: {msg}")

    def _on_enter_pressed(self):
        """Enter key pressed - send message."""
        self._send_message()

    def _on_extended_changed(self, sender, app_data):
        """Extended ID checkbox changed."""
        self.extended_id = app_data

    def _on_rtr_changed(self, sender, app_data):
        """RTR checkbox changed."""
        self.rtr_frame = app_data

    def _on_auto_send_changed(self, sender, app_data):
        """Auto-send checkbox changed."""
        self.auto_send_enabled = app_data
        if self.auto_send_enabled:
            self.last_auto_send_time = time.time()
            self.send_plugin_message("Auto-send enabled")
        else:
            self.send_plugin_message("Auto-send disabled")

    def _on_interval_changed(self, sender, app_data):
        """Auto-send interval changed."""
        self.auto_send_interval_ms = app_data

    def _clear_statistics(self):
        """Clear statistics."""
        self.messages_sent = 0
        self.send_plugin_message("Statistics cleared")

    def _on_window_close(self):
        """Window closed."""
        self._request_termination = True
