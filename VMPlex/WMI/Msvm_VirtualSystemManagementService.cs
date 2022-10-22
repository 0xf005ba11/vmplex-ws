/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Management;
using ORMi;

namespace VMPlex.WMI
{
    [WMIClass(Name = "Msvm_VirtualSystemManagementService", Namespace = @"root\Virtualization\V2")]
    class Msvm_VirtualSystemManagementService : WMIInstance
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public string ElementName { get; set; }
        //public DateTime InstallDate;
        public ushort[] OperationalStatus { get; set; }
        public string[] StatusDescriptions { get; set; }
        public string Status { get; set; }
        public ushort HealthState { get; set; }
        public ushort EnabledState { get; set; }
        public string OtherEnabledState { get; set; }
        public ushort RequestedState { get; set; }
        public ushort EnabledDefault { get; set; }
        public DateTime TimeOfLastStateChange { get; set; }
        public string SystemCreationClassName { get; set; }
        public string SystemName { get; set; }
        public string CreationClassName { get; set; }
        public string Name { get; set; }
        public string PrimaryOwnerName { get; set; }
        public string PrimaryOwnerContact { get; set; }
        public string StartMode { get; set; }
        public bool Started { get; set; }

        public dynamic GetSummaryInformation(ManagementObject[] settings, UInt32[] info)
        {
            return WMIMethod.ExecuteMethod(this, new { SettingData = settings, RequestedInformation = info }, "GetSummaryInformation");
        }
    }
}
