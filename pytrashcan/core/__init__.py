"""
Core framework components for PyTrashCAN.

This module contains the fundamental building blocks:
- CAN message format
- Plugin base class and interface
- Message broker for routing
- Plugin host for lifecycle management
- State persistence
"""

from .can_message import CANMessage
from .plugin_base import PluginBase, PluginInterfaceType, PluginState
from .broker import MessageBroker
from .host import PluginHost

__all__ = [
    'CANMessage',
    'PluginBase',
    'PluginInterfaceType',
    'PluginState',
    'MessageBroker',
    'PluginHost',
]
