"""
Simple runner script for PyTrashCAN.

This adds the parent directory to sys.path so the pytrashcan package
can be imported, then runs the main application.
"""

import sys
from pathlib import Path

# Add parent directory to path so pytrashcan can be imported
parent_dir = Path(__file__).parent.parent
sys.path.insert(0, str(parent_dir))

# Now we can import and run
from pytrashcan.__main__ import main

if __name__ == "__main__":
    sys.exit(main())
