/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.ComponentModel;
using System.Management;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

using VMPlex.WMI;

namespace VMPlex
{

    public class VirtualMachine : INotifyPropertyChanged
    {
        private static System.Reflection.Assembly client = null;
        private static System.Reflection.Assembly clientCommon = null;
        private static System.Reflection.Assembly clientSettings = null;
        private static System.Reflection.Assembly clientManagement = null;
        private static System.Reflection.Assembly clientWizards = null;
        private static System.Type IVMComputerSystem = null;
        private static System.Type IVMComputerSystemSetting = null;
        private static System.Type WindowsCredential = null;
        private static System.Type ConnectionHelper = null;
        private static System.Type VMSettingsDialog = null;
        private static System.Type NetworkManagerDialog = null;
        private static System.Type VirtualizationSettingsDialog = null;
        private static System.Type VMComputerSystemState = null;
        private static System.Type VMComputerSystemOperationalStatus = null;
        private static System.Type Server = null;
        private static System.Type InformationDisplayer = null;
        private static System.Type IUserPassCredential = null;
        private static System.Type VMWizardForm = null;
        private static System.Type NewVirtualMachineWizard = null;
        private static System.Type EditVirtualHardDiskWizard = null;
        private static object ServerConnection = null;
        private static object Displayer = null;
        private static bool hvClientAvailable = false;

        public enum HeartbeatState
        {
            Ok = 2,
            Error = 6,
            NoContact = 12,
            LostCommunication = 13
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public enum StateChange : ushort
        {
            Enabled = 2, // Power on
            Disabled = 3, // Power off
            Shutdown = 4, // Attempt orderly shutdown via integration services (this fails more often than it should)
            Offline = 6, // Enabled but offline (Saved state, resume with Enabled)
            Quiesce = 9, // Pause VM (resume with Enabled)
            Reboot = 10, // Request reboot
            Reset = 11, // Power reset
        }

        static VirtualMachine()
        {
            try
            {
                client = Utility.LoadGACAssembly("Microsoft.Virtualization.Client");
                clientCommon = Utility.LoadGACAssembly("Microsoft.Virtualization.Client.Common");
                clientSettings = Utility.LoadGACAssembly("Microsoft.Virtualization.Client.Settings");
                clientManagement = Utility.LoadGACAssembly("Microsoft.Virtualization.Client.Management");
                clientWizards = Utility.LoadGACAssembly("Microsoft.Virtualization.Client.Wizards");
                WindowsCredential = clientCommon.GetType("Microsoft.Virtualization.Client.Common.WindowsCredential", true);
                IUserPassCredential = WindowsCredential.GetInterface("IUserPassCredential");
                IVMComputerSystem = clientManagement.GetType("Microsoft.Virtualization.Client.Management.IVMComputerSystem", true);
                IVMComputerSystemSetting = clientManagement.GetType("Microsoft.Virtualization.Client.Management.IVMComputerSystemSetting", true);
                VMComputerSystemState = clientManagement.GetType("Microsoft.Virtualization.Client.Management.VMComputerSystemState", true);
                VMComputerSystemOperationalStatus = clientManagement.GetType("Microsoft.Virtualization.Client.Management.VMComputerSystemOperationalStatus", true);
                Server = clientManagement.GetType("Microsoft.Virtualization.Client.Management.Server", true);
                ConnectionHelper = client.GetType("Microsoft.Virtualization.Client.ConnectionHelper", true);
                InformationDisplayer = client.GetType("Microsoft.Virtualization.Client.InformationDisplayer", true);
                VMSettingsDialog = clientSettings.GetType("Microsoft.Virtualization.Client.Settings.VMSettingsDialog", true);
                NetworkManagerDialog = clientSettings.GetType("Microsoft.Virtualization.Client.Settings.NetworkManagerDialog", true);
                VirtualizationSettingsDialog = clientSettings.GetType("Microsoft.Virtualization.Client.Settings.VirtualizationSettingsDialog", true);
                VMWizardForm = clientWizards.GetType("Microsoft.Virtualization.Client.Wizards.VMWizardForm", true);
                NewVirtualMachineWizard = clientWizards.GetType("Microsoft.Virtualization.Client.Wizards.NewVM.NewVirtualMachineWizard", true);
                EditVirtualHardDiskWizard = clientWizards.GetType("Microsoft.Virtualization.Client.Wizards.EditVhd.EditVirtualHardDiskWizard", true);

                Displayer = Activator.CreateInstance(InformationDisplayer);
                Type[] types = new Type[] { InformationDisplayer, typeof(string), typeof(bool), IUserPassCredential };
                ServerConnection = Utility.InvokeStaticMethod(ConnectionHelper, "ConnectServer", types, new object[] { Displayer, System.Environment.MachineName, false, null });
                hvClientAvailable = true;
            }
            catch(Exception)
            {
                Utility.ErrorPopup("Advanced Hyper-V integration disabled. An update is likely required.");
            }
        }

        public VirtualMachine(Msvm_ComputerSystem vm)
        {
            Msvm = vm;
            Name = vm.Name;
            Guid = vm.Guid;
            State = vm.State;
            ProcessID = vm.ProcessID;
            EnhancedSessionModeState = vm.EnhancedSessionModeState;

            if (!hvClientAvailable)
            {
                return;
            }

            try
            {
                Type[] types = new Type[] { typeof(string), WindowsCredential, typeof(Guid), typeof(string), IVMComputerSystem.MakeByRefType(), typeof(Exception).MakeByRefType() };
                object[] parameters = new object[] { System.Environment.MachineName, null, new Guid(vm.Guid), "Unable to locate virtual machine", null, null };
                object ret = Utility.InvokeStaticMethod(ConnectionHelper, "TryGetVirtualMachine", types, parameters);
                if ((bool)ret)
                {
                    VMComputerSystem = parameters[4];
                }
            }
            catch(Exception)
            {
            }
        }

        public static void OpenNewVmWizard()
        {
            if (!hvClientAvailable)
            {
                return;
            }
            object wizard = Activator.CreateInstance(NewVirtualMachineWizard, new object[] { ServerConnection });
            Utility.InvokeMethod(wizard, "Activate", new object[] { });
            Utility.SetProperty(wizard, "WindowState", FormWindowState.Normal);
            Utility.SetProperty(wizard, "ShowInTaskbar", true);
            Utility.InvokeMethod(wizard, "StartModeless", new Type[] { typeof(IWin32Window) }, new object[] { null });
        }

        public void DeleteFromServer()
        {
            if (VMComputerSystem is null)
            {
                return;
            }
            Utility.InvokeMethod(VMComputerSystem, "BeginDelete", new object[] { });
        }

        public void OpenDebugger()
        {
            string lnk = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\LaunchDebugger\\" + Name + ".lnk";
            if (!File.Exists(lnk))
            {
                Utility.ErrorPopup("In the LaunchDebugger subfolder of your installation, create a shortcut named \"" + Name + "\" to your debugger command.");
                return;
            }
            Process.Start(lnk);
        }

        public void OpenSettingsDialog()
        {
            if (VMComputerSystem is null)
            {
                return;
            }

            Utility.InvokeMethod(VMComputerSystem, "UpdateAssociationCache", new object[] { });

            object server = Utility.GetProperty(VMComputerSystem, "Server");
            object vmSetting = Utility.GetProperty(VMComputerSystem, "Setting");
            string instanceId = (string)Utility.GetProperty(vmSetting, "InstanceId");
            object state = Utility.GetProperty(VMComputerSystem, "State");
            var operationStatus = Utility.InvokeMethod(VMComputerSystem, "GetOperationalStatus", new object[] { });

            object[] parameters = new object[] { server, instanceId, false, true, state, operationStatus, false  };
            object settingsDialog = Activator.CreateInstance(VMSettingsDialog, parameters);
            Utility.InvokeMethod(settingsDialog, "Show", new Type[] { typeof(IWin32Window) }, new object[] { null });
            Utility.InvokeMethod(settingsDialog, "ActivateSelf", new object[] {});
        }

        public static void OpenSwitchManagerDialog()
        {
            if (!hvClientAvailable)
            {
                return;
            }
            object dialog = Activator.CreateInstance(NetworkManagerDialog, new object[] { ServerConnection });
            Utility.InvokeMethod(dialog, "Show", new Type[] { typeof(IWin32Window) }, new object[] { null });
            Utility.InvokeMethod(dialog, "ActivateSelf", new object[] {});
        }

        public static void OpenEditDiskWizard()
        {
            if (!hvClientAvailable)
            {
                return;
            }
            object wizard = Activator.CreateInstance(EditVirtualHardDiskWizard, new object[] { ServerConnection });
            Utility.InvokeMethod(wizard, "Activate", new object[] { });
            Utility.SetProperty(wizard, "WindowState", FormWindowState.Normal);
            Utility.SetProperty(wizard, "ShowInTaskbar", true);
            Utility.InvokeMethod(wizard, "StartModeless", new Type[] { typeof(IWin32Window) }, new object[] { null });
        }

        public static void OpenHyperVSettingsDialog()
        {
            if (!hvClientAvailable)
            {
                return;
            }
            object dialog = Activator.CreateInstance(VirtualizationSettingsDialog, new object[] { ServerConnection });
            Utility.InvokeMethod(dialog, "Show", new Type[] { typeof(IWin32Window) }, new object[] { null });
            Utility.InvokeMethod(dialog, "ActivateSelf", new object[] {});
        }

        public uint RequestStateChange(StateChange state)
        {
            return Msvm.RequestStateChange((ushort)state);
        }

        public void TypeText(string text)
        {
            Msvm.TypeText(text);
        }

        public bool IsVideoAvailable()
        {
            switch (State)
            {
            case Msvm_ComputerSystem.SystemState.Running:
            case Msvm_ComputerSystem.SystemState.Paused:
            case Msvm_ComputerSystem.SystemState.Pausing:
            case Msvm_ComputerSystem.SystemState.Stopping:
            case Msvm_ComputerSystem.SystemState.Saving:
                return true;
            }
            return false;
        }

        public void UpdateMainInformation(Msvm_ComputerSystem vm)
        {
            Msvm = vm;
            EnhancedSessionModeState = vm.EnhancedSessionModeState;
            State = vm.State;
            Name = vm.Name;
            ProcessID = vm.ProcessID;
            NotifyChange(null);
        }

        public void UpdateSummaryInformation(ManagementBaseObject summary)
        {
            bool notify = false;

            bool loadreceived = false;
            byte[] thumbnail = null;
            foreach (PropertyData pdata in summary.Properties)
            {
                if (pdata.Value == null)
                {
                    continue;
                }

                switch (pdata.Name)
                {
                case "Version":
                    {
                        string version = (string)pdata.Value;
                        if (version != Version)
                        {
                            Version = version;
                            notify = true;
                        }
                    }
                    break;

                case "NumberOfProcessors":
                    {
                        ushort numprocs = (ushort)pdata.Value;
                        if (numprocs != NumberOfProcessors)
                        {
                            NumberOfProcessors = numprocs;
                            notify = true;
                        }
                    }
                    break;

                case "MemoryAvailable":
                    {
                        int memavail = (int)pdata.Value;
                        if (memavail != MemoryAvailable)
                        {
                            MemoryAvailable = memavail;
                            notify = true;
                        }
                    }
                    break;

                case "UpTime":
                    {
                        ulong uptime = (ulong)pdata.Value / 1000;
                        UpTime = new TimeSpan((long)uptime * 10000000);
                    }
                    break;

                case "ProcessorLoad":
                    {
                        loadreceived = true;
                        ushort procload = (ushort)pdata.Value;
                        if (procload != ProcessorLoad)
                        {
                            ProcessorLoad = procload;
                            notify = true;
                        }
                    }
                    break;

                case "MemoryUsage":
                    {
                        ulong memusage = (ulong)pdata.Value;
                        if (memusage != MemoryUsage)
                        {
                            MemoryUsage = memusage;
                            notify = true;
                        }
                    }
                    break;

                case "Heartbeat":
                    {
                        HeartbeatState hbstate = (HeartbeatState)(ushort)pdata.Value;
                        if (hbstate != Heartbeat)
                        {
                            Heartbeat = hbstate;
                            notify = true;
                        }
                    }
                    break;

                case "ThumbnailImageWidth":
                    {
                        ushort width = (ushort)pdata.Value;
                        if (width != ThumbnailWidth)
                        {
                            ThumbnailWidth = width;
                            notify = true;
                        }
                    }
                    break;

                case "ThumbnailImageHeight":
                    {
                        ushort height = (ushort)pdata.Value;
                        if (height != ThumbnailHeight)
                        {
                            ThumbnailHeight = height;
                            notify = true;
                        }
                    }
                    break;

                case "ThumbnailImage":
                    {
                        thumbnail = (byte[])pdata.Value;
                    }
                    break;
                }
            }

            if (!loadreceived)
            {
                ProcessorLoad = 0;
                MemoryUsage = 0;
                Heartbeat = 0;
            }

            if (thumbnail != null)
            {
                try
                {
                    BitmapSource thumbnailBitmap = BitmapSource.Create(
                        ThumbnailWidth,
                        ThumbnailHeight,
                        96d,
                        96d,
                        System.Windows.Media.PixelFormats.Bgr565,
                        null,
                        thumbnail,
                        ThumbnailWidth * 2);
                    thumbnailBitmap.Freeze();
                    Thumbnail = thumbnailBitmap;
                    if (Thumbnail == null)
                    {
                        notify = true;
                    }
                }
                catch (System.NullReferenceException)
                {
                    if (Thumbnail != null)
                    {
                        Thumbnail = null;
                        notify = true;
                    }
                }
            }
            else
            {
                if (Thumbnail != null)
                {
                    Thumbnail = null;
                    notify = true;
                }
            }

            if (notify)
            {
                NotifyChange(null);
            }
            else
            {
                NotifyChange("UpTime");
                NotifyChange("Thumbnail");
            }
        }

        private object systemLock = new object();
        private Msvm_ComputerSystem Msvm { get; set; }
        private object VMComputerSystem { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Version { get; set; }
        public uint ProcessID { get; set; }
        public Msvm_ComputerSystem.SystemState State { get; set; }
        public Msvm_ComputerSystem.EnhancedSessionMode EnhancedSessionModeState { get; set; }
        public ushort NumberOfProcessors { get; set; }
        public BitmapSource Thumbnail { get; set; }
        public ushort ThumbnailWidth { get; set; }
        public ushort ThumbnailHeight { get; set; }
        public ushort ProcessorLoad { get; set; }
        public ulong MemoryUsage { get; set; }
        public int MemoryAvailable { get; set; }
        public HeartbeatState Heartbeat { get; set; }
        public TimeSpan UpTime { get; set; }
    }
}
