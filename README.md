# VMPlex Workstation

A modern, tabbed UI for Hyper-V.

## Features
- Tabbed view for connected virtual machines including support for enhanced mode.
- Manager tab for viewing and controlling available virtual machines.
- Debugger launching in the spirit of VirtualKD.
- Some management features of Hyper-V:
  - Hyper-V settings
  - Creating, deleting and configuring virtual machnes.
  - Virtual switch configuration
  - Disk editing
  - Thumbnail views

## Quick Start
1. Make sure the Hyper-V windows feature is enabled.
2. Download VMPlex and place where you like.
3. Add your user to the `Hyper-V Administrators` group or `run VMPlex as administrator`.

## Debugger launching support
1. Configure your virtual machines for debugging.
2. Create a subfolder in the location of VMPlex.exe called `LaunchDebugger`.
3. Within the `LaunchDebugger` folder, create shortcut files (lnk) with the same name as their respective virtual machine.

   ```
   Directory of D:\VMPlex\LaunchDebugger

   10/23/2022  11:39 AM    <DIR>          .
   10/22/2022  10:29 PM    <DIR>          ..
   10/21/2022  05:13 PM             1,287 win10x64.lnk
   10/21/2022  05:13 PM             1,283 win11x64.lnk
   ```

4. An example shortcut target that launches WinDbg Preview to kernel-debug a win11 virtual machine:

   ```
   "C:\Users\User\AppData\Local\Microsoft\WindowsApps\WinDbgX.exe" -k net:port=50000,key=1.2.3.4 -T win11x64
   ```

## Screenshots
![](readme/Manager.jpg "Manager Tab")

![](readme/Enhanced.jpg "Virtual Machine Enhanced Session")

