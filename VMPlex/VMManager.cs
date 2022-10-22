/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Management;
using System.Threading;

using ORMi;
using VMPlex.WMI;

namespace VMPlex
{
    class VMManager
    {
        // Static helpers
        private const string Namespace = @"root\Virtualization\V2";
        private ManagementScope Scope;

        private static WMIHelper helper = new WMIHelper(Namespace);

        private static string GuidSelector(string guid) => "SELECT * FROM Msvm_ComputerSystem WHERE Name='" + guid + "'";

        public static Msvm_ComputerSystem GetVM(string name) =>
            helper.QueryFirstOrDefault<Msvm_ComputerSystem>("SELECT * FROM Msvm_ComputerSystem WHERE ElementName='" + name + "'");

        public static Msvm_ComputerSystem GetVMByGuid(string guid) =>
            helper.QueryFirstOrDefault<Msvm_ComputerSystem>(GuidSelector(guid));

        public static WMIWatcher CreateMsvmWatcher(string guid) =>
            new WMIWatcher(Namespace, "SELECT * FROM __InstanceModificationEvent WITHIN 1 WHERE TargetInstance ISA 'Msvm_ComputerSystem' AND TargetInstance.Name = '" + guid + "'", typeof(ModificationEvent));

        // Implement singleton
        private static readonly Lazy<VMManager> lazy = new Lazy<VMManager>(() => new VMManager());
        public static VMManager Instance { get { return lazy.Value; } }

        private VMManager()
        {
            Scope = new ManagementScope(Namespace, null);
            vsms = helper.QueryFirstOrDefault<Msvm_VirtualSystemManagementService>();

            creationWatcher = new WMIWatcher(Namespace, "SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Msvm_computerSystem'");
            modificationWatcher = new WMIWatcher(Namespace, "SELECT * FROM __InstanceModificationEvent WITHIN 1 WHERE TargetInstance ISA 'Msvm_ComputerSystem'");
            deletionWatcher = new WMIWatcher(Namespace, "SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'Msvm_ComputerSystem'");

            // Initialize list of VMs
            VirtualMachines = new ObservableCollection<VirtualMachine>(GetVMs());
            BindingOperations.EnableCollectionSynchronization(VirtualMachines, vmListLock);
            //UpdateSummaryInformation();

            creationWatcher.WMIEventArrived += OnWmiCreateInstance;
            deletionWatcher.WMIEventArrived += OnWmiDeleteInstance;
            modificationWatcher.WMIEventArrived += OnWmiModifyInstance;

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
        private void OnWmiCreateInstance(object sender, WMIEventArgs e)
        {
            var target = (Msvm_ComputerSystem)ORMi.Helpers.TypeHelper.LoadObject(((dynamic)e.Object).TargetInstance, typeof(Msvm_ComputerSystem));
            VirtualMachines.Add(new VirtualMachine(target));
            UpdateSummaryInformation();
            //OnVmCreated(this, target);
        }

        private void OnWmiDeleteInstance(object sender, WMIEventArgs e)
        {
            var target = (Msvm_ComputerSystem)ORMi.Helpers.TypeHelper.LoadObject(((dynamic)e.Object).TargetInstance, typeof(Msvm_ComputerSystem));

            VirtualMachine removed = null;
            {
                lock(vmListLock)
                for (int i = 0; i < VirtualMachines.Count; ++i)
                {
                    if (VirtualMachines[i].Guid == target.Guid)
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

        private void OnWmiModifyInstance(object sender, WMIEventArgs e)
        {
            Msvm_ComputerSystem target = (Msvm_ComputerSystem)ORMi.Helpers.TypeHelper.LoadObject(((dynamic)e.Object).TargetInstance, typeof(Msvm_ComputerSystem));
            Msvm_ComputerSystem previous = (Msvm_ComputerSystem)ORMi.Helpers.TypeHelper.LoadObject(((dynamic)e.Object).PreviousInstance, typeof(Msvm_ComputerSystem));
            //OnVmModified(this, previous, target);

            lock (vmListLock)
            {
                foreach (VirtualMachine vm in VirtualMachines)
                {
                    if (vm.Guid == target.Guid)
                    {
                        vm.UpdateMainInformation(target);
                        break;
                    }
                }
            }
        }

        private IEnumerable<VirtualMachine> GetVMs()
        {
            return from vm in helper.Query<Msvm_ComputerSystem>() where vm.Caption == "Virtual Machine" select new VirtualMachine(vm);
        }

        private ManagementObject[] CreateSettingsArray()
        {
            ManagementObject[] vms = helper.QueryRaw("Msvm_ComputerSystem", Scope);
            List<ManagementObject> ret = new List<ManagementObject>();

            foreach (var vm in vms)
            {
                var settings = vm.GetRelated(
                    "Msvm_VirtualSystemSettingData",
                    "Msvm_SettingsDefineState",
                    null,
                    null,
                    "SettingData",
                    "ManagedElement",
                    false,
                    null);
                foreach (var instance in settings)
                {
                    ret.Add((ManagementObject)instance);
                }
            }

            return ret.ToArray();
        }

        private void UpdateSummaryInformation()
        {
            lock(vmListLock)
            {
                ManagementObject[] settings = CreateSettingsArray();
                uint[] infoRequest = new uint[] {
                    0, // Name (Guid)
                    4, // NumberOfProcessors
                    7, // ThumbnailImage (Large 320x240 RGB565 format)
                    10, // Version
                    101, // ProcessorLoad
                    103, // MemoryUsage
                    104, // Heartbeat
                    105, // Uptime
                    112 // MemoryAvailable
                };
                ManagementBaseObject result;
                try
                {
                    result = vsms.GetSummaryInformation(settings, infoRequest);
                    if (result == null)
                    {
                        return;
                    }
                }
                catch (Exception)
                {
                    return;
                }

                uint returnValue = (uint)result["ReturnValue"];
                if (returnValue != 0)
                {
                    return;
                }

                ManagementBaseObject[] summary = (ManagementBaseObject[])result["SummaryInformation"];
                if (summary is null)
                {
                    return;
                }

                foreach (ManagementBaseObject info in summary)
                {
                    foreach (VirtualMachine vm in VirtualMachines)
                    {
                        if (vm.Guid == (string)info["Name"])
                        {
                            vm.UpdateSummaryInformation(info);
                            break;
                        }
                    }
                }
            }
        }

        // events
        public event VmCreateHandler OnVmCreated;
        public event VmDeleteHandler OnVmDeleted;
        public event VmModifyHandler OnVmModified;

        // data for bindings
        public ObservableCollection<VirtualMachine> VirtualMachines;

        // singleton vars
        public delegate void VmCreateHandler(object sender, Msvm_ComputerSystem target);
        public delegate void VmDeleteHandler(object sender, VirtualMachine target);
        public delegate void VmModifyHandler(object sender, Msvm_ComputerSystem previous, Msvm_ComputerSystem target);
        private Msvm_VirtualSystemManagementService vsms;
        private WMIWatcher creationWatcher;
        private WMIWatcher modificationWatcher;
        private WMIWatcher deletionWatcher;
        private Timer updateTimer;
        private object vmListLock = new object();
    }
}
