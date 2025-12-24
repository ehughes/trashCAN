"""
CAN message data structure for PyTrashCAN.

This module provides the CANMessage dataclass, which represents a CAN bus message
compatible with the C# CAN_t class semantics from the original trashCAN.
"""

from dataclasses import dataclass, field
from typing import Dict, Any
import time


@dataclass
class CANMessage:
    """
    CAN message representation matching C# CAN_t class semantics.

    This class represents a single CAN bus message with support for both
    standard (11-bit) and extended (29-bit) identifiers, remote frames,
    and error frames.

    Attributes:
        arbitration_id: 11-bit (0-0x7FF) or 29-bit (0-0x1FFFFFFF) CAN identifier
        data: Message data bytes (0-8 bytes for CAN 2.0)
        is_extended_id: True for 29-bit extended ID, False for 11-bit standard
        is_remote_frame: True for Remote Transmission Request frames
        timestamp: Local timestamp in seconds (float for microsecond precision)
        is_error_frame: True if this represents a bus error

    Example:
        >>> msg = CANMessage(
        ...     arbitration_id=0x123,
        ...     data=bytes([0x01, 0x02, 0x03]),
        ...     is_extended_id=False
        ... )
        >>> print(msg)
        0x123      : 0x01 0x02 0x03
    """

    arbitration_id: int
    data: bytes = field(default_factory=bytes)
    is_extended_id: bool = False
    is_remote_frame: bool = False
    timestamp: float = field(default_factory=time.time)
    is_error_frame: bool = False

    def __post_init__(self):
        """Validate message parameters after initialization."""
        # Validate ID range
        max_id = 0x1FFFFFFF if self.is_extended_id else 0x7FF
        if self.arbitration_id > max_id:
            raise ValueError(
                f"ID 0x{self.arbitration_id:X} exceeds maximum for "
                f"{'extended' if self.is_extended_id else 'standard'} frame (0x{max_id:X})"
            )

        if self.arbitration_id < 0:
            raise ValueError(f"ID cannot be negative: {self.arbitration_id}")

        # Validate data length (CAN 2.0 allows 0-8 bytes)
        if len(self.data) > 8:
            raise ValueError(
                f"Data length {len(self.data)} exceeds CAN 2.0 maximum of 8 bytes"
            )

        # RTR frames should have no data
        if self.is_remote_frame and len(self.data) > 0:
            # Auto-correct RTR frames to have no data
            object.__setattr__(self, 'data', bytes())

    @property
    def dlc(self) -> int:
        """Data Length Code - the number of data bytes in the message."""
        return len(self.data)

    def to_dict(self) -> Dict[str, Any]:
        """
        Serialize to dictionary for JSON persistence.

        Returns:
            Dictionary representation suitable for JSON serialization
        """
        return {
            'id': self.arbitration_id,
            'data': list(self.data),
            'extended': self.is_extended_id,
            'rtr': self.is_remote_frame,
            'timestamp': self.timestamp,
            'error': self.is_error_frame
        }

    @classmethod
    def from_dict(cls, d: Dict[str, Any]) -> 'CANMessage':
        """
        Deserialize from dictionary (for JSON loading).

        Args:
            d: Dictionary containing message data

        Returns:
            New CANMessage instance
        """
        return cls(
            arbitration_id=d['id'],
            data=bytes(d.get('data', [])),
            is_extended_id=d.get('extended', False),
            is_remote_frame=d.get('rtr', False),
            timestamp=d.get('timestamp', time.time()),
            is_error_frame=d.get('error', False)
        )

    def __str__(self) -> str:
        """
        Format message for display (matches C# ToString() method).

        Returns:
            Formatted string like "0x123      : 0x01 0x02 0x03"
        """
        # Format ID with appropriate padding
        if self.is_extended_id:
            # Extended ID: 8 hex digits
            id_str = f"0x{self.arbitration_id:08X}"
        else:
            # Standard ID: 3 hex digits with padding to match extended width
            id_str = f"0x{self.arbitration_id:03X}     "

        # Add separator
        result = id_str + " : "

        # Add data bytes
        if self.data:
            result += " ".join(f"0x{b:02X}" for b in self.data)

        # Add flags
        if self.is_remote_frame:
            result += " [RTR]"
        if self.is_error_frame:
            result += " [ERR]"

        return result

    def __repr__(self) -> str:
        """
        Detailed representation for debugging.

        Returns:
            String representation showing all fields
        """
        return (
            f"CANMessage("
            f"id=0x{self.arbitration_id:X}, "
            f"data={self.data.hex()}, "
            f"dlc={self.dlc}, "
            f"ext={self.is_extended_id}, "
            f"rtr={self.is_remote_frame}, "
            f"err={self.is_error_frame}, "
            f"ts={self.timestamp:.6f})"
        )
