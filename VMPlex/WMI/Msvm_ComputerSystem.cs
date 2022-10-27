/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System.ComponentModel;
using System.Management;
using ORMi;

namespace VMPlex.WMI
{
    [WMIClass(Name = "Msvm_ComputerSystem", Namespace = @"root\Virtualization\V2")]
    public class Msvm_ComputerSystem : WMIInstance, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public enum SystemState : ushort
        {
            Unknown = 0,
            Other = 1,
            Running = 2,
            Off = 3,
            Stopping = 4,
            Saved = 6,
            Paused = 9,
            Starting = 10,
            Reset = 11,
            Saving = 0x8005,
            Pausing = 0x8008,
            Resuming = 0x8009,
            FastSaved = 0x800b,
            FastSaving = 0x800c,
            ForceShutdown = 0x800d,
            ForceReboot = 0x800e,
            Hibernated = 0x800f,
            ComponentServicing = 0x8010
        }

        public enum EnhancedSessionMode
        {
            AllowedAndAvailable = 2,
            NotAllowed = 3,
            AllowedButUnavailable = 6
        }

        public string InstanceID { get; set; }

        public string Caption { get; set; }

        [WMIProperty("EnabledState")]
        public SystemState State { get; set; }

        [WMIProperty("Name")]
        public string Guid { get; set; }

        [WMIProperty(Name = "ElementName", SearchKey = true)]
        public string Name { get; set; }

        public uint ProcessID { get; set; }

        public EnhancedSessionMode EnhancedSessionModeState { get; set; }

        [WMIIgnore]
        public Msvm_SecurityElement SecurityElement
        {
            get {
                ManagementObjectCollection securityElements = GetVm(Guid).GetRelated(
                    "Msvm_SecurityElement",
                    "Msvm_SystemComponent",
                    null,
                    null,
                    null,
                    null,
                    false,
                    null);

                foreach (ManagementObject instance in securityElements)
                {
                    return (Msvm_SecurityElement)ORMi.Helpers.TypeHelper.LoadObject(instance, typeof(Msvm_SecurityElement));
                }
                return null;
            }
        }

        public uint RequestStateChange(ushort state)
        {
            ManagementObject mo = GetVm(Guid);
            ManagementBaseObject inParams = mo.GetMethodParameters("RequestStateChange");
            inParams["RequestedState"] = (int)state;
            ManagementBaseObject outParams = mo.InvokeMethod("RequestStateChange", inParams, null);
            return (uint)outParams["ReturnValue"];
        }

        public void TypeText(string text)
        {
            ManagementObject kbd = GetKeyboard();
            if (kbd is null)
            { 
                return;
            }

            ManagementBaseObject inParams = kbd.GetMethodParameters("TypeText");
            inParams["asciiText"] = text;
            kbd.InvokeMethod("TypeText", inParams, null);
        }

        private ManagementObject GetKeyboard()
        {
            ManagementObjectCollection kbdCollection = GetVm(Guid).GetRelated(
                "Msvm_Keyboard",
                "Msvm_SystemDevice",
                null,
                null,
                "PartComponent",
                "GroupComponent",
                false,
                null);

            foreach (ManagementObject instance in kbdCollection)
            {
                return instance;
            }
            return null;
        }

        private ManagementObject GetVm(string guid)
        {
            ManagementScope scope = new ManagementScope(@"\\.\root\virtualization\V2", null);
            string query = string.Format("select * from Msvm_ComputerSystem Where Name = '{0}'", guid);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query));

            ManagementObjectCollection computers = searcher.Get();

            ManagementObject computer = null;

            foreach (ManagementObject instance in computers)
            {
                computer = instance;
                break;
            }
            return computer;
        }
    }
}
