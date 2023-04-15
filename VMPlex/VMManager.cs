/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management;
using System.Windows.Data;
using System.Threading;

using EasyWMI;
using HyperV;
using System.Text.Json.Serialization;
using VMPlex.UI;

namespace VMPlex
{
    class VMManager
    {
        //private static WMIHelper helper = new WMIHelper(Namespace);
        private static WmiScope scope;

        private static string GuidSelector(string guid) => "SELECT * FROM Msvm_ComputerSystem WHERE Name='" + guid + "'";
        private static string NameSelector(string name) => "SELECT * FROM Msvm_ComputerSystem WHERE ElementName='" + name + "'";

        public static IMsvm_ComputerSystem GetVM(string name) =>
            scope.QueryInstances<IMsvm_ComputerSystem>(NameSelector(name)).FirstOrDefault();

        public static IMsvm_ComputerSystem GetVMByGuid(string guid) =>
            scope.QueryInstances<IMsvm_ComputerSystem>(GuidSelector(guid)).FirstOrDefault();

        public static IMsvm_VirtualSystemSettingData GetVMSettingData(string id) =>
            scope.QueryInstances<IMsvm_VirtualSystemSettingData>("SELECT * FROM Msvm_VirtualSystemSettingData WHERE InstanceID='" + id + "'").FirstOrDefault();

        public static IMsvm_VirtualSystemSnapshotService SnapshotService => scope.GetInstance<IMsvm_VirtualSystemSnapshotService>();

        public static WmiSubscription<IMsvm_ComputerSystem> CreateMsvmWatcher(string guid) =>
            scope.Subscribe<IMsvm_ComputerSystem>("SELECT * FROM __InstanceModificationEvent WITHIN 1 WHERE TargetInstance ISA 'Msvm_ComputerSystem' AND TargetInstance.Name = '" + guid + "'");

        public enum SnapshotType : ushort
        {
            Full = 2,
            Disk = 3
        }

        public static void CreateSnapshot(VirtualMachine vm, SnapshotType snapshotType)
        {
            IMsvm_ComputerSystem system = GetVMByGuid(vm.Guid);

            SnapshotService.CreateSnapshot(
                            system,
                            out IMsvm_VirtualSystemSettingData? snapshot,
                            String.Empty,
                            (ushort)snapshotType,
                            out IMsvm_ConcreteJob? job);
            if (job != null)
            {
                new HyperV.Job(job).WaitForCompletion();
                if (job.ErrorCode != 0)
                {
                    UI.MessageBox.Show(
                        System.Windows.MessageBoxImage.Error,
                        "Checkpoint Creation Failed",
                        job.ErrorDescription,
                        System.Windows.MessageBoxButton.OK);
                }
            }
        }

        public static void RevertSnapshot(VirtualMachine vm)
        {
            IMsvm_ComputerSystem system = GetVMByGuid(vm.Guid);
            IMsvm_VirtualSystemSettingData mostCurrent = system.GetAssociated<IMsvm_VirtualSystemSettingData>("Msvm_MostCurrentSnapshotInBranch").FirstOrDefault();
            if (mostCurrent == null)
            {
                return;
            }

            ApplySnapshot(new Snapshot(mostCurrent, false));
        }

        public static void ApplySnapshot(Snapshot snapshot)
        {
            IMsvm_ComputerSystem system = GetVMByGuid(snapshot.SettingData.VirtualSystemIdentifier);
            if (system == null)
            {
                return;
            }

            VirtualMachine vm = new VirtualMachine(system);
            IMsvm_ComputerSystem.SystemState prevState = vm.State;
            IMsvm_ConcreteJob job;
            uint err;

            // Must be off or saved to apply a snapshot
            if (vm.State != IMsvm_ComputerSystem.SystemState.Off && vm.State != IMsvm_ComputerSystem.SystemState.Saved)
            {
                err = vm.RequestStateChange(VirtualMachine.StateChange.Offline, out job);
                if (job != null)
                {
                    new HyperV.Job(job).WaitForCompletion();
                }
                else if (err != 0)
                {
                    return;
                }
            }

            // N.B. The underlying ManagementBaseObject in SettingData may be missing the __PATH which will break InvokeMethod.
            //      Query for the object again to get a fresh copy.
            IMsvm_VirtualSystemSettingData settings = GetVMSettingData(snapshot.SettingData.InstanceID);
            SnapshotService.ApplySnapshot(settings, out job);
            if (job != null)
            {
                new HyperV.Job(job).WaitForCompletion();
                if (job.ErrorCode != 0)
                {
                    UI.MessageBox.Show(
                        System.Windows.MessageBoxImage.Error,
                        "Checkpoint Apply Failed",
                        job.ErrorDescription,
                        System.Windows.MessageBoxButton.OK);
                }
            }

            vm = new VirtualMachine(GetVMByGuid(vm.Guid));
            if (vm.State == IMsvm_ComputerSystem.SystemState.Saved && prevState == IMsvm_ComputerSystem.SystemState.Running)
            {
                vm.RequestStateChange(prevState);
            }
        }

        public static void DeleteSnapshot(Snapshot snapshot)
        {
            IMsvm_VirtualSystemSettingData settings = GetVMSettingData(snapshot.SettingData.InstanceID);
            SnapshotService.DestroySnapshot(settings, out IMsvm_ConcreteJob? job);
            if (job != null)
            {
                new HyperV.Job(job).WaitForCompletion();
                if (job.ErrorCode != 0)
                {
                    UI.MessageBox.Show(
                        System.Windows.MessageBoxImage.Error,
                        "Checkpoint Delete Failed",
                        job.ErrorDescription,
                        System.Windows.MessageBoxButton.OK);
                }
            }
        }

        public static void DeleteSnapshotTree(Snapshot snapshot)
        {
            IMsvm_VirtualSystemSettingData settings = GetVMSettingData(snapshot.SettingData.InstanceID);
            SnapshotService.DestroySnapshotTree(settings, out IMsvm_ConcreteJob? job);
            if (job != null)
            {
                new HyperV.Job(job).WaitForCompletion();
                if (job.ErrorCode != 0)
                {
                    UI.MessageBox.Show(
                        System.Windows.MessageBoxImage.Error,
                        "Checkpoint Delete Failed",
                        job.ErrorDescription,
                        System.Windows.MessageBoxButton.OK);
                }
            }
        }

        // Implement singleton
        private static readonly Lazy<VMManager> lazy = new Lazy<VMManager>(() => new VMManager());
        public static VMManager Instance { get { return lazy.Value; } }

        private VMManager()
        {
            scope = new WmiScope(@"root\virtualization\v2");

            vsms = scope.GetInstance<IMsvm_VirtualSystemManagementService>();
            if (vsms == null)
            {
                UI.MessageBox.Show(
                   System.Windows.MessageBoxImage.Error,
                    "Vrtual System Management",
                    "VMPlex is unable to interact with the Virtual Machine Management Service. Please run as administrator or add your user to the Hyper-V Administrators group.");
                Environment.Exit(0xdead);
            }

            creationWatcher = scope.Subscribe<IMsvm_ComputerSystem>("__InstanceCreationEvent", 1);
            modificationWatcher = scope.Subscribe<IMsvm_ComputerSystem>("__InstanceModificationEvent", 1);
            deletionWatcher = scope.Subscribe<IMsvm_ComputerSystem>("__InstanceDeletionEvent", 1);

            // Initialize list of VMs
            VirtualMachines = new ObservableCollection<VirtualMachine>(GetVMs());
            BindingOperations.EnableCollectionSynchronization(VirtualMachines, vmListLock);
            UpdateSummaryInformation();

            creationWatcher.EventArrived += OnCreateInstance;
            deletionWatcher.EventArrived += OnDeleteInstance;
            modificationWatcher.EventArrived += OnModifyInstance;

            new Thread(() => UpdateDataThread()) { IsBackground = true }.Start();
        }

        void UpdateDataThread()
        {
            while (true)
            {
                UpdateSummaryInformation();
                Thread.Sleep(1000);
            }
        }

        // singleton funcs
        private void OnCreateInstance(object sender, WmiEvent<IMsvm_ComputerSystem> e)
        {
            IMsvm_ComputerSystem target = e.TargetInstance;
            VirtualMachines.Add(new VirtualMachine(target));
            UpdateSummaryInformation();
            //OnVmCreated(this, target);
        }

        private void OnDeleteInstance(object sender, WmiEvent<IMsvm_ComputerSystem> e)
        {
            IMsvm_ComputerSystem target = e.TargetInstance;

            VirtualMachine removed = null;
            {
                lock(vmListLock)
                for (int i = 0; i < VirtualMachines.Count; ++i)
                {
                    if (VirtualMachines[i].Guid == target.Name)
                    {
                        removed = VirtualMachines[i];
                        VirtualMachines.RemoveAt(i);
                        break;
                    }
                }
            }
            if (removed != null)
            {
                try
                {
                    OnVmDeleted(this, removed);
                }
                catch(Exception)
                {
                }
            }
        }

        private void OnModifyInstance(object sender, WmiEvent<IMsvm_ComputerSystem> e)
        {
            IMsvm_ComputerSystem target = e.TargetInstance;
            IMsvm_ComputerSystem previous = e.PreviousInstance;
            //OnVmModified(this, previous, target);

            lock (vmListLock)
            {
                foreach (VirtualMachine vm in VirtualMachines)
                {
                    if (vm.Guid == target.Name)
                    {
                        vm.UpdateMainInformation(target);
                        break;
                    }
                }
            }
        }

        private IMsvm_VirtualSystemSettingData[] CreateSettingsArray()
        {
            uint err = vsms.GetSummaryInformation(new uint[] { 0 /* Guid */ }, null, out IMsvm_SummaryInformation[]? summary);
            if (err != 0 || summary == null)
            {
                return Array.Empty<IMsvm_VirtualSystemSettingData>();
            }

            IEnumerable<IMsvm_ComputerSystem> systems = from system in scope.GetInstances<IMsvm_ComputerSystem>()
                                                        from sm in summary
                                                            where system.Name == sm.Name
                                                        select system;

            return (from system in systems
                    from data in system.GetAssociated<IMsvm_VirtualSystemSettingData>("Msvm_SettingsDefineState")
                    select data).ToArray();
        }

        private IEnumerable<VirtualMachine> GetVMs()
        {
            uint err = vsms.GetSummaryInformation(new uint[] { 0 /* Guid */ }, null, out IMsvm_SummaryInformation[]? summary);
            if (err != 0 || summary == null)
            {
                return Array.Empty<VirtualMachine>();
            }

            return from system in scope.GetInstances<IMsvm_ComputerSystem>()
                   from sm in summary
                       where system.Name == sm.Name
                   select new VirtualMachine(system);
        }

        private void UpdateSummaryInformation()
        {
            lock (vmListLock)
            {
                uint[] infoRequest = new uint[] {
                    0, // Name (Guid)
                    4, // NumberOfProcessors
                    7, // ThumbnailImage (Large 320x240 RGB565 format)
                    10, // Version
                    101, // ProcessorLoad
                    103, // MemoryUsage
                    104, // Heartbeat
                    105, // Uptime
                    107, // Snapshots
                    112 // MemoryAvailable
                };

                //
                // N.B. In some circumstances this API can return no error and null output.
                //
                uint err = vsms.GetSummaryInformation(infoRequest, CreateSettingsArray(), out IMsvm_SummaryInformation[]? summary);
                if (err != 0 || summary == null)
                {
                    return;
                }

                foreach (IMsvm_SummaryInformation info in summary)
                {
                    foreach (VirtualMachine vm in VirtualMachines)
                    {
                        if (vm.Guid == info.Name)
                        {
                            vm.UpdateSummaryInformation(info);
                            break;
                        }
                    }
                }
            }
        }

        // events
        //public event VmCreateHandler OnVmCreated;
        public event VmDeleteHandler OnVmDeleted;
        //public event VmModifyHandler OnVmModified;

        // data for bindings
        public ObservableCollection<VirtualMachine> VirtualMachines;

        // singleton vars
        public delegate void VmCreateHandler(object sender, IMsvm_ComputerSystem target);
        public delegate void VmDeleteHandler(object sender, VirtualMachine target);
        public delegate void VmModifyHandler(object sender, IMsvm_ComputerSystem previous, IMsvm_ComputerSystem target);
        private IMsvm_VirtualSystemManagementService vsms;
        private WmiSubscription<IMsvm_ComputerSystem> creationWatcher;
        private WmiSubscription<IMsvm_ComputerSystem> modificationWatcher;
        private WmiSubscription<IMsvm_ComputerSystem> deletionWatcher;
        private object vmListLock = new object();
    }
}
