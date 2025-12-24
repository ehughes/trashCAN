"""
PyTrashCAN plugin implementations.

Available plugins:
- PCANAdapterPlugin: Physical CAN bus interface via PEAK USB adapter
- InjectorPlugin: Manual CAN message injection tool
- ViewerPlugin: CAN message viewer/sniffer
"""

from .pcan_adapter import PCANAdapterPlugin
from .injector import InjectorPlugin
from .viewer import ViewerPlugin

__all__ = [
    'PCANAdapterPlugin',
    'InjectorPlugin',
    'ViewerPlugin',
]
