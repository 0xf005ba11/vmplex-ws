/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Diagnostics;

using HyperV;
using EasyWMI;

namespace VMPlex
{

    public class VirtualMachine : INotifyPropertyChanged
    {
        public enum HeartbeatState
        {
            Off = 0,
            Ok = 2,
            Error = 6,
            NoContact = 12,
            LostCommunication = 13
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(params string[] names)
        {
            if (PropertyChanged != null)
            {
                if (names == null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(null));
                    return;
                }

                foreach (string name in names)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
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

        public VirtualMachine(IMsvm_ComputerSystem vm)
        {
            Msvm = vm;
            Name = vm.ElementName;
            Guid = vm.Name;
            State = vm.EnabledState ?? IMsvm_ComputerSystem.SystemState.Unknown;
            ProcessID = vm.ProcessID ?? 0;
            EnhancedSessionModeState = vm.EnhancedSessionModeState ?? IMsvm_ComputerSystem.EnhancedSessionMode.NotAllowed;
            Snapshots = new List<Snapshot>();

            //
            // Generates user settings if they don't exist.
            //
            GetVmUserSettings();
        }

        public static void OpenNewVmWizard()
        {
            TryLaunchHVIntegrateInJob(new string[] { "av" });
        }

        public void DeleteFromServer()
        {
            TryLaunchHVIntegrateInJob(new string[] { "dv", Guid });
        }

        public VmConfig GetVmUserSettings()
        {
            var settings = UserSettings.Instance.Settings;

            var vmSetting = settings.VirtualMachines.FirstOrDefault(v => v.Guid == Guid);
            if (vmSetting != null)
            {
                return vmSetting;
            }

            //
            // Create a new entry for this VM.
            //
            settings = UserSettings.Instance.Mutate(s =>
            {
                s.VirtualMachines.Add(
                    new VmConfig
                    {
                        Guid = Guid,
                        Name = Name,
                        DebuggerArguments = ""
                    });

                return s;
            });

            return settings.VirtualMachines.FirstOrDefault(v => v.Guid == Guid);
        }

        public VmConfig MutateVmUserSettings(Func<VmConfig, VmConfig> Mutator)
        {
            return UserSettings.Instance.Mutate(s =>
            {
                var index = s.VirtualMachines.FindIndex(v => v.Guid == Guid);
                if (index == -1)
                {
                    //
                    // Create a new entry for this VM.
                    //
                    s.VirtualMachines.Add(
                        new VmConfig
                        {
                            Guid = Guid,
                            Name = Name,
                            DebuggerArguments = ""
                        });
                    index = s.VirtualMachines.FindIndex(v => v.Guid == Guid);
                }

                s.VirtualMachines[index] = Mutator(s.VirtualMachines[index]);

                return s;

            }).VirtualMachines.First(v => v.Guid == Guid);
        }

        public void OpenDebugger()
        {
            var settings = UserSettings.Instance.Settings;
            var vm = GetVmUserSettings();

            if (settings.Debugger.Length == 0 ||
                vm.DebuggerArguments.Length == 0)
            {
                UI.MessageBox.Show(
                   MessageBoxImage.Information,
                    "Debugger settings are incomplete.",
                    "Please specify the debugger and arguments for the " +
                    "virtual machine in the user settings. The settings " +
                    "file will be opened when you close this dialog.");
                UserSettings.Instance.OpenInEditor();
                return;
            }

            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                FileName = settings.Debugger,
                Arguments = vm.DebuggerArguments,
                UseShellExecute = true
            };

            try
            {
                process.Start();
            }
            catch (Exception exc)
            {
                UI.MessageBox.Show(
                    MessageBoxImage.Error,
                    "Failed to start debugger.",
                    exc.Message);
            }
        }

        public void OpenSettingsDialog()
        {
            TryLaunchHVIntegrateInJob(new string[] { "vm", Guid });
        }

        public static void OpenSwitchManagerDialog()
        {
            TryLaunchHVIntegrateInJob(new string[] { "vs" });
        }

        public static void OpenEditDiskWizard()
        {
            TryLaunchHVIntegrateInJob(new string[] { "ed" });
        }

        public static void OpenHyperVSettingsDialog()
        {
            TryLaunchHVIntegrateInJob(new string[] { "hv" });
        }

        public uint RequestStateChange(StateChange state)
        {
            return Msvm.RequestStateChange((ushort)state, out IMsvm_ConcreteJob? job);
        }

        public void TypeText(string text)
        {
            Keyboard.TypeText(text);
        }

        public bool IsVideoAvailable()
        {
            switch (State)
            {
            case IMsvm_ComputerSystem.SystemState.Running:
            case IMsvm_ComputerSystem.SystemState.Paused:
            case IMsvm_ComputerSystem.SystemState.Pausing:
            case IMsvm_ComputerSystem.SystemState.Stopping:
            case IMsvm_ComputerSystem.SystemState.Saving:
                return true;
            }
            return false;
        }

        public void UpdateMainInformation(IMsvm_ComputerSystem vm)
        {
            Msvm = VMManager.GetVMByGuid(vm.Name);
            EnhancedSessionModeState = vm.EnhancedSessionModeState ?? IMsvm_ComputerSystem.EnhancedSessionMode.NotAllowed;
            State = vm.EnabledState ?? IMsvm_ComputerSystem.SystemState.Unknown;
            Name = vm.ElementName;
            ProcessID = vm.ProcessID ?? 0;
            NotifyChange(null);
        }

        public void UpdateSummaryInformation(IMsvm_SummaryInformation summary)
        {
            bool loadreceived = false;
            byte[] thumbnail = null;

            if (summary.Version != null && Version != summary.Version)
            {
                Version = summary.Version;
            }

            if (summary.NumberOfProcessors != null && NumberOfProcessors != summary.NumberOfProcessors)
            {
                NumberOfProcessors = summary.NumberOfProcessors.Value;
            }

            if (summary.MemoryAvailable != null && MemoryAvailable != summary.MemoryAvailable)
            {
                MemoryAvailable = summary.MemoryAvailable.Value;
            }

            if (summary.UpTime != null)
            {
                ulong uptime = (ulong)summary.UpTime.Value / 1000;
                UpTime = new TimeSpan((long)uptime * 10000000);
            }

            if (summary.ProcessorLoad != null)
            {
                loadreceived = true;
                if (summary.ProcessorLoad != ProcessorLoad)
                {
                    ProcessorLoad = summary.ProcessorLoad.Value;
                }
            }

            if (summary.MemoryUsage != null && MemoryUsage != summary.MemoryUsage.Value)
            {
                MemoryUsage = summary.MemoryUsage.Value;
            }

            if (summary.Heartbeat != null)
            {
                HeartbeatState hbstate = (HeartbeatState)summary.Heartbeat.Value;
                if (hbstate != Heartbeat)
                {
                    Heartbeat = hbstate;
                }
            }

            if (summary.Snapshots != null && summary.Snapshots.Length != 0)
            {
                IMsvm_VirtualSystemSettingData mostCurrent = Msvm.GetAssociated<IMsvm_VirtualSystemSettingData>("Msvm_MostCurrentSnapshotInBranch").FirstOrDefault();
                List<Snapshot> newSnapshots = SnapshotHierarchy.BuildFrom(
                                                    mostCurrent,
                                                    (from snapshot in summary.Snapshots select
                                                     WmiClassGenerator.CreateInstance<IMsvm_VirtualSystemSettingData>(snapshot)).ToArray());
                if (!SnapshotHierarchy.IsSame(Snapshots, newSnapshots))
                {
                    Snapshots = newSnapshots;
                }
            }
            else if (Snapshots != null && (summary.Snapshots == null || summary.Snapshots.Length == 0))
            {
                Snapshots = new List<Snapshot>();
            }

            if (summary.ThumbnailImageWidth != null && ThumbnailWidth != summary.ThumbnailImageWidth)
            {
                ThumbnailWidth= summary.ThumbnailImageWidth.Value;
            }

            if (summary.ThumbnailImageHeight != null && ThumbnailHeight != summary.ThumbnailImageHeight)
            {
                ThumbnailHeight = summary.ThumbnailImageHeight.Value;
            }

            if (summary.ThumbnailImage != null)
            {
                thumbnail = summary.ThumbnailImage;
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
                }
                catch (System.NullReferenceException)
                {
                }
            }

            NotifyChange(null);
        }

        private static void TryLaunchHVIntegrateInJob(string[] args)
        {
            try
            {
                Utility.LaunchHVIntegrateInJob(args);
            }
            catch (Exception exc)
            {
                UI.MessageBox.Show(
                    System.Windows.MessageBoxImage.Error,
                    "Failed to start Hyper-V Integration",
                    exc.Message);
            }
        }

        private IMsvm_ComputerSystem Msvm { get; set; }
        public VirtualMachine Self { get { return this; } }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Version { get; set; }
        public uint ProcessID { get; set; }
        public List<Snapshot> Snapshots { get; set; }
        public IMsvm_SecurityElement? SecurityElement { get => Msvm.GetAssociated<IMsvm_SecurityElement>(null).FirstOrDefault(); }
        public IMsvm_Keyboard Keyboard { get => Msvm.GetAssociated<IMsvm_Keyboard>("Msvm_SystemDevice").FirstOrDefault(); }
        public IMsvm_ComputerSystem.SystemState State { get; set; }
        public bool IsRunning {
            get
            {
                switch(State)
                {
                    case IMsvm_ComputerSystem.SystemState.Unknown:
                    case IMsvm_ComputerSystem.SystemState.Off:
                    case IMsvm_ComputerSystem.SystemState.Saved:
                    case IMsvm_ComputerSystem.SystemState.Paused:
                    case IMsvm_ComputerSystem.SystemState.FastSaved:
                    case IMsvm_ComputerSystem.SystemState.Hibernated:
                        return false;
                }
                return true;
            }
        }
        public bool IsPaused { get {  return State == IMsvm_ComputerSystem.SystemState.Paused; } }
        public bool IsSaved { get {  return State == IMsvm_ComputerSystem.SystemState.Saved; } }
        public bool IsPoweredOn { get { return IsRunning || IsPaused; } }
        public IMsvm_ComputerSystem.EnhancedSessionMode EnhancedSessionModeState { get; set; }
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
