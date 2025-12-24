"""
PCAN Adapter Plugin.

Provides physical CAN bus interface via PEAK USB adapter using python-can library.
"""

import dearpygui.dearpygui as dpg
import threading
from typing import Optional
import can
from can import Bus, Message

from ..core.plugin_base import PluginBase, PluginInterfaceType
from ..core.can_message import CANMessage


class PCANAdapterPlugin(PluginBase):
    """
    PEAK CAN adapter plugin - hardware interface to physical CAN bus.

    Matches C# PCAN-USB plugin functionality using python-can library.
    Uses background threads for RX/TX operations to avoid blocking the
    main GUI thread.

    Features:
    - Channel selection (PCAN_USBBUS1-4)
    - Bitrate configuration
    - Connect/disconnect controls
    - Statistics tracking (messages in/out/errors)
    - Background RX/TX threads

    Type: READ_WRITE (both sends and receives messages)

    Threading Model:
    - RX Thread: Polls hardware, converts to CANMessage, enqueues to outgoing_can_queue
    - TX Thread: Dequeues from incoming_can_queue, converts to python-can Message, writes to hardware
    """

    def __init__(self):
        super().__init__()

        # Hardware state
        self.bus: Optional[Bus] = None
        self.connected = False
        self.channel = "PCAN_USBBUS1"
        self.bitrate = 500000

        # Threading
        self.rx_thread: Optional[threading.Thread] = None
        self.tx_thread: Optional[threading.Thread] = None
        self.stop_threads = threading.Event()

        # Statistics
        self.messages_in = 0
        self.messages_out = 0
        self.errors = 0

        # UI tags
        self.window_tag = f"pcan_window_{id(self)}"

    @property
    def plugin_name(self) -> str:
        return "PCAN Adapter"

    @property
    def plugin_version(self) -> str:
        return "2.0.0"

    @property
    def interface_type(self) -> PluginInterfaceType:
        return PluginInterfaceType.READ_WRITE

    def init(self) -> str:
        """Initialize plugin."""
        self.send_plugin_message("PCAN Adapter initialized")
        return "OK"

    def terminate(self) -> str:
        """Terminate plugin and disconnect."""
        if self.connected:
            self._disconnect()
        return "OK"

    def create_ui(self, parent) -> str:
        """Create plugin UI window."""
        with dpg.window(
            label=f"{self.plugin_name} v{self.plugin_version} (Instance {self.instance_id})",
            tag=self.window_tag,
            width=450,
            height=350,
            pos=(420, 10),
            on_close=lambda: self._on_window_close()
        ):
            dpg.add_text("PEAK CAN Hardware Adapter")
            dpg.add_separator()

            # Channel selection
            dpg.add_text("CAN Channel:")
            dpg.add_combo(
                items=["PCAN_USBBUS1", "PCAN_USBBUS2", "PCAN_USBBUS3", "PCAN_USBBUS4"],
                default_value=self.channel,
                tag=f"{self.window_tag}_channel",
                callback=self._on_channel_changed,
                width=200
            )

            # Bitrate selection
            dpg.add_text("Bitrate (bps):")
            dpg.add_combo(
                items=["125000", "250000", "500000", "1000000"],
                default_value=str(self.bitrate),
                tag=f"{self.window_tag}_bitrate",
                callback=self._on_bitrate_changed,
                width=200
            )

            dpg.add_separator()

            # Connect button
            dpg.add_button(
                label="Connect",
                tag=f"{self.window_tag}_connect_btn",
                callback=self._on_connect_clicked,
                width=150,
                height=30
            )

            # Connection status
            dpg.add_text("Status: Disconnected", tag=f"{self.window_tag}_status")

            dpg.add_separator()

            # Statistics
            dpg.add_text("Statistics:", color=(200, 200, 255))
            dpg.add_text("Messages In: 0", tag=f"{self.window_tag}_msg_in")
            dpg.add_text("Messages Out: 0", tag=f"{self.window_tag}_msg_out")
            dpg.add_text("Errors: 0", tag=f"{self.window_tag}_errors")

            dpg.add_separator()

            dpg.add_button(
                label="Clear Statistics",
                callback=self._clear_statistics,
                width=150
            )

        return self.window_tag

    def update_ui(self):
        """Update UI elements."""
        if not dpg.does_item_exist(self.window_tag):
            return

        # Update statistics
        dpg.set_value(f"{self.window_tag}_msg_in", f"Messages In: {self.messages_in:,}")
        dpg.set_value(f"{self.window_tag}_msg_out", f"Messages Out: {self.messages_out:,}")
        dpg.set_value(f"{self.window_tag}_errors", f"Errors: {self.errors:,}")

        # Update connection status and button
        if self.connected:
            dpg.set_item_label(f"{self.window_tag}_connect_btn", "Disconnect")
            dpg.set_value(
                f"{self.window_tag}_status",
                f"Status: Connected to {self.channel} at {self.bitrate} bps"
            )
        else:
            dpg.set_item_label(f"{self.window_tag}_connect_btn", "Connect")
            dpg.set_value(f"{self.window_tag}_status", "Status: Disconnected")

    def _on_channel_changed(self, sender, app_data):
        """Channel selection changed."""
        if not self.connected:
            self.channel = app_data

    def _on_bitrate_changed(self, sender, app_data):
        """Bitrate selection changed."""
        if not self.connected:
            self.bitrate = int(app_data)

    def _on_connect_clicked(self):
        """Connect/disconnect button clicked."""
        if self.connected:
            self._disconnect()
        else:
            self._connect()

    def _connect(self):
        """Connect to PCAN hardware."""
        try:
            self.logger.info(f"Connecting to {self.channel} at {self.bitrate} bps...")

            # Create python-can Bus instance
            self.bus = Bus(
                interface='pcan',
                channel=self.channel,
                bitrate=self.bitrate
            )

            self.connected = True
            self.stop_threads.clear()

            # Start RX/TX threads
            self.rx_thread = threading.Thread(
                target=self._rx_thread_func,
                daemon=True,
                name=f"PCAN-RX-{self.instance_id}"
            )
            self.tx_thread = threading.Thread(
                target=self._tx_thread_func,
                daemon=True,
                name=f"PCAN-TX-{self.instance_id}"
            )

            self.rx_thread.start()
            self.tx_thread.start()

            msg = f"Connected to {self.channel} at {self.bitrate} bps"
            self.send_plugin_message(msg)
            self.logger.info(msg)

        except Exception as e:
            error_msg = f"Connection failed: {e}"
            self.logger.error(error_msg)
            self.send_plugin_message(error_msg)
            self.connected = False
            self.errors += 1

    def _disconnect(self):
        """Disconnect from PCAN hardware."""
        self.logger.info("Disconnecting...")

        # Signal threads to stop
        self.stop_threads.set()

        # Wait for threads with timeout
        if self.rx_thread and self.rx_thread.is_alive():
            self.rx_thread.join(timeout=1.0)
        if self.tx_thread and self.tx_thread.is_alive():
            self.tx_thread.join(timeout=1.0)

        # Shutdown bus
        if self.bus:
            try:
                self.bus.shutdown()
            except Exception as e:
                self.logger.error(f"Error shutting down bus: {e}")
            self.bus = None

        self.connected = False
        msg = "Disconnected"
        self.send_plugin_message(msg)
        self.logger.info(msg)

    def _rx_thread_func(self):
        """
        Background RX thread: receive from hardware, send to broker.

        Continuously polls the PCAN adapter for incoming messages,
        converts them to CANMessage format, and enqueues to the
        outgoing_can_queue for the broker to route to other plugins.
        """
        self.logger.info("RX thread started")

        while not self.stop_threads.is_set():
            try:
                # Receive with timeout
                msg = self.bus.recv(timeout=0.01)
                if msg and not msg.is_error_frame:
                    # Convert python-can Message to CANMessage
                    can_msg = CANMessage(
                        arbitration_id=msg.arbitration_id,
                        data=bytes(msg.data),
                        is_extended_id=msg.is_extended_id,
                        is_remote_frame=msg.is_remote_frame,
                        timestamp=msg.timestamp
                    )

                    # Send to broker (will route to other plugins)
                    self.send_can_message(can_msg)
                    self.messages_in += 1

                elif msg and msg.is_error_frame:
                    self.errors += 1

            except Exception as e:
                if not self.stop_threads.is_set():
                    self.logger.error(f"RX error: {e}")
                    self.errors += 1

        self.logger.info("RX thread stopped")

    def _tx_thread_func(self):
        """
        Background TX thread: receive from broker, send to hardware.

        Continuously dequeues messages from incoming_can_queue (which
        the broker fills with messages from other plugins), converts
        them to python-can Message format, and writes to the PCAN adapter.
        """
        self.logger.info("TX thread started")

        while not self.stop_threads.is_set():
            try:
                # Get message from broker (blocking with timeout)
                can_msg = self.get_can_message(block=True, timeout=0.01)
                if can_msg:
                    # Convert CANMessage to python-can Message
                    msg = Message(
                        arbitration_id=can_msg.arbitration_id,
                        data=can_msg.data,
                        is_extended_id=can_msg.is_extended_id,
                        is_remote_frame=can_msg.is_remote_frame
                    )

                    # Send to hardware
                    self.bus.send(msg)
                    self.messages_out += 1

            except Exception as e:
                if not self.stop_threads.is_set():
                    self.logger.error(f"TX error: {e}")
                    self.errors += 1

        self.logger.info("TX thread stopped")

    def _clear_statistics(self):
        """Clear statistics counters."""
        self.messages_in = 0
        self.messages_out = 0
        self.errors = 0
        self.send_plugin_message("Statistics cleared")

    def _on_window_close(self):
        """Window close button clicked."""
        self._request_termination = True
