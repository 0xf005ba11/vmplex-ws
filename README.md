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
  - Checkpoints support

## Quick Start
1. Make sure the Hyper-V windows feature is enabled.
2. Download VMPlex and place where you like.
3. Add your user to the `Hyper-V Administrators` group or `run VMPlex as administrator`.

## User Settings 

User settings are stored in `vmplex-settings.json`. It is generated and managed by the application.
You may edit the settings at runtime. The settings are documented [here](VMPlex/UserSettings.cs).

### Debugger Launch Support

Debugger launch support is configured via the settings file. When attempting to launch the debugger
for a VM, if configuration is missing, you will be prompted to fill out the required information.
Here is an example configuration:

```json
{
  "Debugger": "windbgx",
  "VirtualMachines": [
    {
      "Guid": "ECD89D3D-77C7-4AFC-B0B5-ACAAF1F83EE0",
      "Name": "Win10",
      "DebuggerArguments": "-k net:port=50001,key=1.2.3.4 -T win10",
      "RdpSettings": {
        "DefaultEnhancedSession": false,
        "AudioRedirectionMode": "None",
        "DesktopWidth": 1600,
        "DesktopHeight": 1200
      }
    },
    {
      "Guid": "17B91C63-0F95-4B07-996C-24F5DCF7E46A",
      "Name": "Win11",
      "DebuggerArguments": "",
      "RdpSettings": {
        "DefaultEnhancedSession": true,
        "RedirectClipboard": true,
        "AudioRedirectionMode": "Redirect",
        "AudioCaptureRedirectionMode": false,
        "RedirectDrives": false,
        "RedirectDevices": false,
        "RedirectSmartCards": false,
        "DesktopWidth": 1024,
        "DesktopHeight": 768
      }
    }
  ]
}
```

## Screenshots
![](https://github.com/0xf005ba11/vmplex-ws/blob/assets/Manager.png?raw=true "Manager Tab")

![](https://github.com/0xf005ba11/vmplex-ws/blob/assets/Enhanced.png?raw=true "Virtual Machine Enhanced Session")
