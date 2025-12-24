"""
Entry point for PyTrashCAN application.

Run with: python -m pytrashcan
"""

import sys
from .gui.app import TrashCANApp


def main():
    """Main entry point."""
    app = TrashCANApp()
    app.setup()
    app.register_plugins()
    app.run()
    return 0


if __name__ == "__main__":
    sys.exit(main())
