using System;
using System.Management;
using ORMi;

namespace VMPlex.WMI
{
    class DeletionEvent : WMIInstance
    {
        public  ManagementBaseObject TargetInstance { get; set; }

        [WMIProperty("TIME_CREATED")]
        public UInt64 TimeCreated { get; set; }
    }
}
