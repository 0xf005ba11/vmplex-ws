<img align="left" src="VMPlex/Resources/VMPlex.ico" width="128" height="128"/>

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

## User Settings 

User settings are stored in `vmplex-settings.json`. It is generated and managed by the application.
You may edit the settings at runtime.

### Debugger Launch Support

Debugger launch support configured via the settings file. When attempting to launch the debugger
for a VM, if configuration is missing, you will be prompted to fill out the required information.
Here is an example configuration:

```json
{
  "Debugger": "windbgx",
  "VirtualMachines": [
    {
      "Guid": "00000000-0000-0000-0000-000000000000",
      "Name": "WIN11X64",
      "DebuggerArguments": "-k net:port=50000,key=1.2.3.4 -T WIN11X64"
    }
  ]
}
```

## Screenshots
![](https://github.com/0xf005ba11/vmplex-ws/blob/assets/Manager.jpg?raw=true "Manager Tab")

![](https://github.com/0xf005ba11/vmplex-ws/blob/assets/Enhanced.jpg?raw=true "Virtual Machine Enhanced Session")

