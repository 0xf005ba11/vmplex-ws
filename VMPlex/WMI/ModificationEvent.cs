using System;
using System.Management;
using ORMi;

namespace VMPlex.WMI
{
    [WMIClass("__InstanceModificationEvent")]
    class ModificationEvent : WMIInstance
    {
        public ManagementBaseObject PreviousInstance { get; set; }

        public ManagementBaseObject TargetInstance { get; set; }

        [WMIProperty("TIME_CREATED")]
        public UInt64 TimeCreated { get; set; }
    }
}
