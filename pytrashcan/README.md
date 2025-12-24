# PyTrashCAN - Python CAN Bus Development and Testing Tool

A modern Python port of the trashCAN C# application, providing a plugin-based architecture for CAN bus development, testing, and analysis.

## Features

- **Plugin-Based Architecture**: Extensible system where each plugin is a node on a virtual CAN network
- **Message Broker**: Central router that broadcasts CAN messages between plugins
- **Cross-Platform GUI**: Built with DearPyGui for modern, GPU-accelerated rendering
- **Multiple Plugin Instances**: Run multiple instances of the same plugin simultaneously
- **State Persistence**: Save and restore your workspace layout

## Included Plugins

### 1. PCAN Adapter (READ_WRITE)
Physical CAN bus interface via PEAK USB adapter.

**Features:**
- Channel selection (PCAN_USBBUS1-4)
- Configurable bitrate (125k, 250k, 500k, 1000k)
- Real-time statistics (messages in/out/errors)
- Background RX/TX threads for non-blocking operation

### 2. Message Injector (WRITE_ONLY)
Manual CAN message composition and transmission.

**Features:**
- Text-based message input with validation
- Extended ID (29-bit) and RTR frame support
- Auto-send with configurable interval
- Statistics tracking

### 3. Message Viewer (READ_ONLY)
Real-time CAN message display and monitoring.

**Features:**
- Table-based display with newest-first ordering
- Circular buffer (128 messages) for performance
- Timestamp, ID, DLC, Data, and Flags columns
- Clear and statistics functions

## Installation

### Prerequisites

- Python 3.10 or higher
- [uv](https://github.com/astral-sh/uv) - Fast Python package installer
- PEAK CAN driver (for PCAN Adapter plugin)
  - Download from: https://www.peak-system.com/PCAN-USB.199.0.html
  - Windows: Install PCAN-Basic driver
  - Linux: Install peak-linux-driver

### Install uv (if not already installed)

```bash
# Windows
powershell -c "irm https://astral.sh/uv/install.ps1 | iex"

# macOS/Linux
curl -LsSf https://astral.sh/uv/install.sh | sh
```

### Install Dependencies

```bash
cd pytrashcan
uv sync
```

This will create a virtual environment and install all dependencies.

## Running PyTrashCAN

### With uv (recommended)

```bash
cd pytrashcan
uv run python run.py
```

This will:
1. Set up the Python path correctly
2. Use the uv-managed virtual environment
3. Launch the PyTrashCAN GUI application

## Usage

### Creating Plugin Instances

1. Launch PyTrashCAN
2. Click **Plugins** menu
3. Select **New [Plugin Name]** to create an instance
4. Multiple instances of the same plugin can be created

### Basic Workflow

**Example: View CAN traffic from physical bus**

1. Create a **PCAN Adapter** instance
2. Select channel and bitrate
3. Click **Connect**
4. Create a **Message Viewer** instance
5. CAN messages from the bus will appear in the viewer

**Example: Inject messages to physical bus**

1. Create a **PCAN Adapter** instance and connect
2. Create a **Message Injector** instance
3. Compose message (e.g., `0x123 : 0x01 0x02 0x03`)
4. Click **Send Message**
5. Message is sent to the bus via PCAN adapter

**Example: Test with virtual loopback**

1. Create a **Message Injector** instance
2. Create **two Message Viewer** instances
3. Send messages from injector
4. Both viewers will display the messages (virtual network)

### Message Format

Messages use the format: `0xID : 0xByte0 0xByte1 ...`

Examples:
- `0x123 : 0x01 0x02 0x03` - Standard ID with 3 data bytes
- `0x18FF1234 : 0xAA 0xBB 0xCC 0xDD` - Extended ID with 4 bytes
- `0x456 :` - Standard ID with no data (use with RTR checkbox)

### Saving/Restoring Layouts

- **File → Save Layout**: Save current plugin configuration
- **File → Restore Layout**: Restore previously saved configuration
- Layouts are auto-saved on exit to `last_state.json`
- Auto-restored on startup if file exists

## Architecture

### Core Components

- **CANMessage**: Dataclass representing CAN bus messages
- **PluginBase**: Abstract base class for all plugins
- **MessageBroker**: Routes messages between plugins
- **PluginHost**: Manages plugin lifecycle and state persistence
- **TrashCANApp**: Main GUI application and event loop

### Plugin Interface Types

- **READ_WRITE**: Plugin both sends and receives messages (e.g., PCAN Adapter)
- **READ_ONLY**: Plugin only receives messages (e.g., Message Viewer)
- **WRITE_ONLY**: Plugin only sends messages (e.g., Message Injector)

### Message Flow

```
Physical CAN Bus
     ↓ (PCAN RX thread)
PCAN Plugin → outgoing_can_queue
     ↓
Message Broker (tick)
     ↓ (broadcast to all readers)
Viewer Plugins ← incoming_can_queue
     ↓ (process in update_ui)
Display in GUI
```

## Creating Custom Plugins

1. Create a new file in `pytrashcan/plugins/`
2. Inherit from `PluginBase`
3. Implement required methods and properties
4. Register in `gui/app.py`

Example skeleton:

```python
from ..core.plugin_base import PluginBase, PluginInterfaceType
from ..core.can_message import CANMessage
import dearpygui.dearpygui as dpg

class MyPlugin(PluginBase):
    @property
    def plugin_name(self) -> str:
        return "My Plugin"

    @property
    def plugin_version(self) -> str:
        return "1.0.0"

    @property
    def interface_type(self) -> PluginInterfaceType:
        return PluginInterfaceType.READ_WRITE

    def init(self) -> str:
        # Initialize resources
        return "OK"

    def terminate(self) -> str:
        # Cleanup resources
        return "OK"

    def create_ui(self, parent):
        # Create DearPyGui window
        with dpg.window(label=self.plugin_name, tag=f"my_plugin_{id(self)}"):
            dpg.add_text("Hello from my plugin!")
        return f"my_plugin_{id(self)}"

    def update_ui(self):
        # Process incoming messages and update GUI
        while True:
            msg = self.get_can_message()
            if not msg:
                break
            # Process message
```

## Troubleshooting

### PCAN Connection Issues

- **Error: "No PCAN device found"**
  - Ensure PCAN USB adapter is connected
  - Verify PCAN driver is installed
  - Try different channel (PCAN_USBBUS1-4)

- **Error: "Channel already in use"**
  - Close other applications using PCAN
  - Disconnect and reconnect the adapter

### Performance Issues

- **Viewer not updating smoothly**
  - Reduce message buffer size
  - Close unnecessary plugin instances
  - Lower message transmission rate

### Installation Issues

- **ImportError: No module named 'dearpygui'**
  - Run: `uv sync` to install all dependencies

- **ImportError: No module named 'can'**
  - Run: `uv sync` to install all dependencies

- **uv command not found**
  - Install uv: See installation instructions above

## Differences from C# TrashCAN

### Advantages
- **Cross-platform**: Works on Windows, Linux, macOS
- **Lighter weight**: Smaller footprint, faster startup
- **Modern GUI**: DearPyGui provides GPU-accelerated rendering
- **Simpler threading**: Python Queue handles synchronization automatically

### Differences
- **State files**: JSON instead of XML (`.json` vs `.bag`)
- **Plugin discovery**: Explicit registration instead of reflection
- **GUI framework**: DearPyGui instead of WinForms

### Compatibility
- State files are NOT compatible between Python and C# versions
- Both versions can access same PCAN hardware (not simultaneously)
- Both versions use same CAN message format concept

## Development

### Install Development Dependencies

```bash
uv sync --all-extras
```

### Running Tests

```bash
uv run pytest
```

### Code Formatting

```bash
uv run black pytrashcan
```

### Type Checking

```bash
uv run mypy pytrashcan
```

### Adding Dependencies

```bash
# Add a runtime dependency
uv add package-name

# Add a development dependency
uv add --dev package-name
```

## License

MIT License

## Author

Eli Hughes

## Version

1.0.0
