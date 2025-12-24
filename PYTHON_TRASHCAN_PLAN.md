# Python TrashCAN Implementation Plan

## Overview
Create an official Python version of the trashCAN application, a plugin-based CAN bus development and testing tool. This will be a modern Python port that maintains the core concepts from the C# original while leveraging Python's strengths and the lessons learned from cruise_cruncher.

## Goals
- Plugin-based architecture with virtual network message routing
- 3 initial plugins: PEAK CAN adapter, Message Injector, Message Viewer
- Cross-platform GUI using DearPyGui
- Clean, maintainable Python codebase
- All work in current repository

## Project Structure

```
C:\ELI\projects\wavenumber\kung-fu\trashcan\
├── trashCAN\                      # Existing C# implementation (unchanged)
└── pytrashcan\                    # NEW: Python implementation
    ├── __init__.py
    ├── __main__.py                # Entry point: python -m pytrashcan
    ├── core\                      # Core framework
    │   ├── __init__.py
    │   ├── can_message.py         # CAN message dataclass
    │   ├── plugin_base.py         # Abstract base class for plugins
    │   ├── broker.py              # Message routing/broker
    │   ├── host.py                # Plugin lifecycle manager
    │   └── state.py               # State persistence
    ├── plugins\                   # Plugin implementations
    │   ├── __init__.py
    │   ├── pcan_adapter.py        # PEAK CAN hardware adapter
    │   ├── injector.py            # Message injection plugin
    │   └── viewer.py              # Message viewer/sniffer plugin
    ├── gui\                       # GUI framework
    │   ├── __init__.py
    │   └── app.py                 # Main DearPyGui application
    ├── requirements.txt           # Dependencies
    ├── pyproject.toml            # Modern Python packaging
    └── README.md                  # Documentation
```

## Core Architecture

### 1. CAN Message Format (`core/can_message.py`)
- Python dataclass matching C# CAN_t semantics
- Fields: `arbitration_id`, `data`, `is_extended_id`, `is_remote_frame`, `timestamp`, `is_error_frame`
- Validation in `__post_init__`
- JSON serialization support
- String formatting matching C# output

### 2. Plugin Base Class (`core/plugin_base.py`)
- ABC-based design (Abstract Base Class)
- Queue-based message passing (thread-safe)
- Plugin interface types: `READ_WRITE`, `READ_ONLY`, `WRITE_ONLY`
- Lifecycle methods: `init()`, `terminate()`, `create_ui()`, `update_ui()`
- Properties: `plugin_name`, `plugin_version`, `interface_type`, `instance_id`
- State persistence support

### 3. Message Broker (`core/broker.py`)
- Single-threaded tick() pattern (called from main loop)
- Routes CAN messages between plugins based on interface type
- Broadcast pattern: messages from writers go to all readers (except sender)
- Non-blocking queue operations
- Statistics tracking

### 4. Plugin Host (`core/host.py`)
- Manages plugin lifecycle (create, destroy)
- Explicit plugin registration (cleaner than C# reflection)
- State save/restore to JSON files
- Assigns unique instance IDs
- Termination request handling

### 5. GUI Application (`gui/app.py`)
- DearPyGui-based main window
- Menu bar: File, Plugins, Tools, Help
- Active plugins table
- Main event loop: broker.tick() → update_ui() → render frame
- Auto-save/restore state on startup/shutdown

## Plugin Implementations

### PCAN Adapter Plugin (`plugins/pcan_adapter.py`)
- **Type**: READ_WRITE
- **Purpose**: Bridge to physical CAN bus via PEAK USB adapter
- **Threading**: Background RX/TX threads for hardware I/O
- **Library**: python-can with PCAN interface
- **UI**: Channel selection, bitrate, connect/disconnect, statistics
- **Features**: Converts between python-can Messages and CANMessage format

### Injector Plugin (`plugins/injector.py`)
- **Type**: WRITE_ONLY
- **Purpose**: Manual CAN message transmission
- **UI**: Text input with validation, Extended ID/RTR checkboxes, send button
- **Features**:
  - Regex-based message parsing (matches C# format)
  - Auto-send with configurable interval
  - Statistics tracking
  - Input validation and auto-formatting

### Viewer Plugin (`plugins/viewer.py`)
- **Type**: READ_ONLY
- **Purpose**: Display received CAN messages
- **UI**: DearPyGui table with columns: Timestamp, ID, DLC, Data, Flags
- **Features**:
  - Circular buffer (128 messages max for performance)
  - Newest-first display
  - Statistics tracking
  - Clear function

## Dependencies

### Python Version
- **Minimum**: Python 3.10
- Requires modern type hints and dataclass features

### Required Libraries (requirements.txt)
```
dearpygui>=1.11.0          # GUI framework
python-can>=4.3.0          # CAN bus abstraction
python-can[pcan]>=4.3.0    # PEAK CAN support
```

### Development Tools
```
pytest>=7.4.0              # Testing
black>=23.0.0              # Code formatting
mypy>=1.5.0                # Type checking
```

## Implementation Phases

### Phase 1: Core Framework
**Goal**: Implement foundation classes
**Files to create**:
1. `core/can_message.py` - CAN message dataclass with validation
2. `core/plugin_base.py` - Abstract plugin base class
3. `core/broker.py` - Message routing logic
4. `core/host.py` - Plugin lifecycle management
5. `core/state.py` - State persistence helpers

**Validation**: Unit tests for each module

### Phase 2: GUI Foundation
**Goal**: Basic application with DearPyGui
**Files to create**:
1. `gui/app.py` - Main application class
2. `__main__.py` - Entry point
3. Setup menu bar and active plugins table
4. Integrate broker.tick() into event loop

**Validation**: Application launches, menu works, broker ticks

### Phase 3: PCAN Adapter Plugin
**Goal**: Physical CAN bus interface
**Files to create**:
1. `plugins/pcan_adapter.py` - Complete implementation

**Implementation details**:
- Channel/bitrate selection UI
- Connect/disconnect logic using python-can
- RX thread: hardware → OutgoingCANMsgQueue → broker → other plugins
- TX thread: broker → IncomingCANMsgQueue → hardware
- Statistics tracking and display

**Validation**: Connect to PCAN adapter, see messages in log

### Phase 4: Injector Plugin
**Goal**: Manual message sending
**Files to create**:
1. `plugins/injector.py` - Complete implementation

**Implementation details**:
- Message composition UI with text input
- Regex validation matching C# pattern: `0xID : 0xByte0 0xByte1 ...`
- Extended ID and RTR checkboxes
- Auto-send with interval control
- Send button and Enter key handling

**Validation**: Send messages, see them in PCAN adapter

### Phase 5: Viewer Plugin
**Goal**: Message display
**Files to create**:
1. `plugins/viewer.py` - Complete implementation

**Implementation details**:
- DearPyGui table with proper columns
- Deque-based circular buffer (128 messages)
- Message formatting with flags (EXT, RTR, ERR)
- Statistics and clear function
- Performance optimization for high message rates

**Validation**: View messages from PCAN adapter at high rates (1000+ msg/s)

### Phase 6: Integration & Polish
**Goal**: Complete end-to-end testing
**Tasks**:
1. Test full workflow: PCAN → Viewer
2. Test full workflow: Injector → PCAN → physical bus
3. Test state save/restore
4. Documentation (README.md, docstrings)
5. Bug fixes and performance tuning

## Key Design Decisions

### Threading Model
- **Decision**: Single-threaded main loop with broker.tick()
- **Rationale**: Python GIL makes thread-based routing inefficient; simpler debugging
- **Exception**: PCAN adapter uses background threads for blocking hardware I/O only

### GUI Framework
- **Decision**: DearPyGui
- **Rationale**: Immediate mode, GPU-accelerated, lightweight, MIT license, perfect for real-time displays

### State Persistence
- **Decision**: JSON (not XML like C#)
- **Rationale**: Native Python support, more readable, smaller files

### Plugin Discovery
- **Decision**: Explicit registration (not reflection like C#)
- **Rationale**: More Pythonic, clearer dependencies, easier debugging

### CAN Library
- **Decision**: python-can
- **Rationale**: Industry standard, supports multiple adapters, well-maintained

## Critical Files Summary

**Must implement in order**:
1. `pytrashcan/core/can_message.py` - Foundation for all CAN communication
2. `pytrashcan/core/plugin_base.py` - Defines plugin contract
3. `pytrashcan/core/broker.py` - Core message routing
4. `pytrashcan/gui/app.py` - Main application entry point
5. `pytrashcan/plugins/pcan_adapter.py` - First real plugin (most complex)

## Testing Strategy

### Unit Tests
- CAN message validation
- Broker routing logic
- State serialization/deserialization

### Integration Tests
- Plugin creation/destruction
- Message flow through broker
- State persistence

### Hardware Tests
- Physical PCAN adapter connection
- High message rates (target: 1000 msg/s)
- Error conditions (disconnects, invalid messages)

## Future Enhancements (Post-MVP)
- ID filtering in viewer
- Message recording/playback
- DBC file support for symbolic decoding
- Additional CAN adapters (SocketCAN, IXXAT, Vector)
- Python scripting console
- Performance plots (bus load visualization)
- Multi-bus support

## Success Criteria
- [ ] Application launches and shows main window
- [ ] PCAN adapter plugin connects to hardware
- [ ] Injector plugin sends messages to bus
- [ ] Viewer plugin displays received messages
- [ ] State persistence works (save/restore layout)
- [ ] All 3 plugins work together in full workflow
- [ ] Performance: Handle 1000+ messages/second smoothly
