
# Lookup AdminShares

This repository contains scripts designed to find administrative shares on devices within a network. The scripts are provided in Python and C#, targeting network administrators and security professionals who need to monitor network access points.

## Scripts

### `Win_AdminShareFinder.py`
- **Language:** Python
- **Description:** Searches for administrative shares on devices in a network. It outputs the results to a text file listing all detected admin shares per device.

### `Win_AdminShareFinder.cs`
- **Language:** C#
- **Description:** Similar functionality to the Python script but implemented in C#. Note that this script requires compilation before use.

## Setup and Execution

### Python Script
- **Requirements:** Python 3.x, `win32net`, and `ipaddress` modules.
- **Execution:** Run `python Win_AdminShareFinder.py` from your command line.

### C# Script
- **Compilation:** Compile the script using a C# compiler like `csc.exe`.
- **Execution:** Run the resulting executable via command line.

## Credits
- [Volkan Sah](https://github.com/volkansah)
- [BadThin](https://github.com/BadTin/)





