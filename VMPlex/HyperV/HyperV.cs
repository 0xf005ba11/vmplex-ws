using System;
using System.Management;
using EasyWMI;

namespace HyperV
{
    [WmiClassName("Msvm_VirtualSystemManagementService", @"root\virtualization\v2")]
    public class IMsvm_VirtualSystemManagementService : IWmiObject
    {
        public IMsvm_VirtualSystemManagementService(ManagementBaseObject instance) { __Instance = instance; }

        public string? Caption{ get => WmiClassImpl.GetProperty<string>(__Instance, "Caption"); set => WmiClassImpl.SetProperty<string>(__Instance, "Caption", value); }
        public string? Description{ get => WmiClassImpl.GetProperty<string>(__Instance, "Description"); set => WmiClassImpl.SetProperty<string>(__Instance, "Description", value); }
        public string? ElementName{ get => WmiClassImpl.GetProperty<string>(__Instance, "ElementName"); set => WmiClassImpl.SetProperty<string>(__Instance, "ElementName", value); }
        public string? InstanceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "InstanceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "InstanceID", value); }
        public ushort? CommunicationStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "CommunicationStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "CommunicationStatus", value); }
        public ushort? DetailedStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "DetailedStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "DetailedStatus", value); }
        public ushort? HealthState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "HealthState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "HealthState", value); }
        public DateTime? InstallDate{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "InstallDate"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "InstallDate", value); }
        [WmiKey] public string? Name{ get => WmiClassImpl.GetProperty<string>(__Instance, "Name"); set => WmiClassImpl.SetProperty<string>(__Instance, "Name", value); }
        public ushort? OperatingStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "OperatingStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "OperatingStatus", value); }
        public ushort[]? OperationalStatus{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "OperationalStatus"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "OperationalStatus", value); }
        public ushort? PrimaryStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "PrimaryStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "PrimaryStatus", value); }
        public string? Status{ get => WmiClassImpl.GetProperty<string>(__Instance, "Status"); set => WmiClassImpl.SetProperty<string>(__Instance, "Status", value); }
        public string[]? StatusDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "StatusDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "StatusDescriptions", value); }
        public ushort[]? AvailableRequestedStates{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "AvailableRequestedStates"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "AvailableRequestedStates", value); }
        public ushort? EnabledDefault{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledDefault"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledDefault", value); }
        public ushort? EnabledState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledState", value); }
        public string? OtherEnabledState{ get => WmiClassImpl.GetProperty<string>(__Instance, "OtherEnabledState"); set => WmiClassImpl.SetProperty<string>(__Instance, "OtherEnabledState", value); }
        public ushort? RequestedState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "RequestedState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "RequestedState", value); }
        public DateTime? TimeOfLastStateChange{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeOfLastStateChange"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeOfLastStateChange", value); }
        public ushort? TransitioningToState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "TransitioningToState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "TransitioningToState", value); }
        [WmiKey] public string? CreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "CreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "CreationClassName", value); }
        public string? PrimaryOwnerContact{ get => WmiClassImpl.GetProperty<string>(__Instance, "PrimaryOwnerContact"); set => WmiClassImpl.SetProperty<string>(__Instance, "PrimaryOwnerContact", value); }
        public string? PrimaryOwnerName{ get => WmiClassImpl.GetProperty<string>(__Instance, "PrimaryOwnerName"); set => WmiClassImpl.SetProperty<string>(__Instance, "PrimaryOwnerName", value); }
        public bool? Started{ get => WmiClassImpl.GetProperty<bool>(__Instance, "Started"); set => WmiClassImpl.SetProperty<bool>(__Instance, "Started", value); }
        public string? StartMode{ get => WmiClassImpl.GetProperty<string>(__Instance, "StartMode"); set => WmiClassImpl.SetProperty<string>(__Instance, "StartMode", value); }
        [WmiKey] public string? SystemCreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "SystemCreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "SystemCreationClassName", value); }
        [WmiKey] public string? SystemName{ get => WmiClassImpl.GetProperty<string>(__Instance, "SystemName"); set => WmiClassImpl.SetProperty<string>(__Instance, "SystemName", value); }

        public uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RequestStateChange");
            WmiClassImpl.SetProperty<ushort>(inParams, "RequestedState", RequestedState);
            WmiClassImpl.SetProperty<DateTime>(inParams, "TimeoutPeriod", TimeoutPeriod);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RequestStateChange", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint StartService()
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "StartService");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("StartService", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint StopService()
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "StopService");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("StopService", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint AddResourceSettings(ManagementBaseObject AffectedConfiguration, string[] ResourceSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingResourceSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "AddResourceSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedConfiguration", AffectedConfiguration);
            WmiClassImpl.SetProperty<string[]>(inParams, "ResourceSettings", ResourceSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("AddResourceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingResourceSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingResourceSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint DefineSystem(ManagementBaseObject ReferenceConfiguration, string[] ResourceSettings, string SystemSettings, out ManagementBaseObject? Job, out ManagementBaseObject? ResultingSystem)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "DefineSystem");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "ReferenceConfiguration", ReferenceConfiguration);
            WmiClassImpl.SetProperty<string[]>(inParams, "ResourceSettings", ResourceSettings);
            WmiClassImpl.SetProperty<string>(inParams, "SystemSettings", SystemSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("DefineSystem", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingSystem = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "ResultingSystem");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint DestroySystem(ManagementBaseObject AffectedSystem, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "DestroySystem");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedSystem", AffectedSystem);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("DestroySystem", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ModifyResourceSettings(string[] ResourceSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingResourceSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ModifyResourceSettings");
            WmiClassImpl.SetProperty<string[]>(inParams, "ResourceSettings", ResourceSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ModifyResourceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingResourceSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingResourceSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ModifySystemSettings(string SystemSettings, out IMsvm_ConcreteJob? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ModifySystemSettings");
            WmiClassImpl.SetProperty<string>(inParams, "SystemSettings", SystemSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ModifySystemSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<IMsvm_ConcreteJob>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RemoveResourceSettings(ManagementBaseObject[] ResourceSettings, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RemoveResourceSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject[]>(inParams, "ResourceSettings", ResourceSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RemoveResourceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint DefinePlannedSystem(ManagementBaseObject ReferenceConfiguration, string[] ResourceSettings, string SystemSettings, out ManagementBaseObject? Job, out ManagementBaseObject? ResultingSystem)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "DefinePlannedSystem");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "ReferenceConfiguration", ReferenceConfiguration);
            WmiClassImpl.SetProperty<string[]>(inParams, "ResourceSettings", ResourceSettings);
            WmiClassImpl.SetProperty<string>(inParams, "SystemSettings", SystemSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("DefinePlannedSystem", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingSystem = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "ResultingSystem");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ValidatePlannedSystem(ManagementBaseObject PlannedSystem, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ValidatePlannedSystem");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "PlannedSystem", PlannedSystem);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ValidatePlannedSystem", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint UpgradeSystemVersion(ManagementBaseObject ComputerSystem, string UpgradeSettingData, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "UpgradeSystemVersion");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "ComputerSystem", ComputerSystem);
            WmiClassImpl.SetProperty<string>(inParams, "UpgradeSettingData", UpgradeSettingData);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("UpgradeSystemVersion", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ImportSystemDefinition(bool GenerateNewSystemIdentifier, string SnapshotFolder, string SystemDefinitionFile, out ManagementBaseObject? ImportedSystem, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ImportSystemDefinition");
            WmiClassImpl.SetProperty<bool>(inParams, "GenerateNewSystemIdentifier", GenerateNewSystemIdentifier);
            WmiClassImpl.SetProperty<string>(inParams, "SnapshotFolder", SnapshotFolder);
            WmiClassImpl.SetProperty<string>(inParams, "SystemDefinitionFile", SystemDefinitionFile);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ImportSystemDefinition", inParams, null!);
            ImportedSystem = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "ImportedSystem");
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ImportSnapshotDefinitions(ManagementBaseObject PlannedSystem, string SnapshotFolder, out ManagementBaseObject[]? ImportedSnapshots, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ImportSnapshotDefinitions");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "PlannedSystem", PlannedSystem);
            WmiClassImpl.SetProperty<string>(inParams, "SnapshotFolder", SnapshotFolder);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ImportSnapshotDefinitions", inParams, null!);
            ImportedSnapshots = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ImportedSnapshots");
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RealizePlannedSystem(ManagementBaseObject PlannedSystem, out ManagementBaseObject? Job, out ManagementBaseObject? ResultingSystem)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RealizePlannedSystem");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "PlannedSystem", PlannedSystem);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RealizePlannedSystem", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingSystem = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "ResultingSystem");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ExportSystemDefinition(ManagementBaseObject ComputerSystem, string ExportDirectory, string ExportSettingData, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ExportSystemDefinition");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "ComputerSystem", ComputerSystem);
            WmiClassImpl.SetProperty<string>(inParams, "ExportDirectory", ExportDirectory);
            WmiClassImpl.SetProperty<string>(inParams, "ExportSettingData", ExportSettingData);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ExportSystemDefinition", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint AddFeatureSettings(ManagementBaseObject AffectedConfiguration, string[] FeatureSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingFeatureSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "AddFeatureSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedConfiguration", AffectedConfiguration);
            WmiClassImpl.SetProperty<string[]>(inParams, "FeatureSettings", FeatureSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("AddFeatureSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingFeatureSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingFeatureSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ModifyFeatureSettings(string[] FeatureSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingFeatureSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ModifyFeatureSettings");
            WmiClassImpl.SetProperty<string[]>(inParams, "FeatureSettings", FeatureSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ModifyFeatureSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingFeatureSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingFeatureSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RemoveFeatureSettings(ManagementBaseObject[] FeatureSettings, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RemoveFeatureSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject[]>(inParams, "FeatureSettings", FeatureSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RemoveFeatureSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint AddBootSourceSettings(ManagementBaseObject AffectedConfiguration, string[] BootSourceSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingBootSourceSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "AddBootSourceSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedConfiguration", AffectedConfiguration);
            WmiClassImpl.SetProperty<string[]>(inParams, "BootSourceSettings", BootSourceSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("AddBootSourceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingBootSourceSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingBootSourceSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint AddGuestServiceSettings(ManagementBaseObject AffectedConfiguration, string[] GuestServiceSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingGuestServiceSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "AddGuestServiceSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedConfiguration", AffectedConfiguration);
            WmiClassImpl.SetProperty<string[]>(inParams, "GuestServiceSettings", GuestServiceSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("AddGuestServiceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingGuestServiceSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingGuestServiceSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ModifyGuestServiceSettings(string[] GuestServiceSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingGuestServiceSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ModifyGuestServiceSettings");
            WmiClassImpl.SetProperty<string[]>(inParams, "GuestServiceSettings", GuestServiceSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ModifyGuestServiceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingGuestServiceSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingGuestServiceSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RemoveBootSourceSettings(ManagementBaseObject[] BootSourceSettings, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RemoveBootSourceSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject[]>(inParams, "BootSourceSettings", BootSourceSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RemoveBootSourceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RemoveGuestServiceSettings(ManagementBaseObject[] GuestServiceSettings, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RemoveGuestServiceSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject[]>(inParams, "GuestServiceSettings", GuestServiceSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RemoveGuestServiceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint GetVirtualSystemThumbnailImage(ushort HeightPixels, ManagementBaseObject TargetSystem, ushort WidthPixels, out byte[]? ImageData)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "GetVirtualSystemThumbnailImage");
            WmiClassImpl.SetProperty<ushort>(inParams, "HeightPixels", HeightPixels);
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "TargetSystem", TargetSystem);
            WmiClassImpl.SetProperty<ushort>(inParams, "WidthPixels", WidthPixels);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("GetVirtualSystemThumbnailImage", inParams, null!);
            ImageData = WmiClassImpl.GetProperty<byte[]>(outParams, "ImageData");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ModifyServiceSettings(string SettingData, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ModifyServiceSettings");
            WmiClassImpl.SetProperty<string>(inParams, "SettingData", SettingData);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ModifyServiceSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint GetSummaryInformation(uint[] RequestedInformation, IMsvm_VirtualSystemSettingData[] SettingData, out IMsvm_SummaryInformation[]? SummaryInformation)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "GetSummaryInformation");
            WmiClassImpl.SetProperty<uint[]>(inParams, "RequestedInformation", RequestedInformation);
            WmiClassImpl.SetProperty<ManagementBaseObject[]>(inParams, "SettingData", SettingData);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("GetSummaryInformation", inParams, null!);
            SummaryInformation = WmiClassImpl.GetProperty<IMsvm_SummaryInformation[]>(outParams, "SummaryInformation");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint GetDefinitionFileSummaryInformation(string[] DefinitionFiles, out ManagementBaseObject[]? SummaryInformation)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "GetDefinitionFileSummaryInformation");
            WmiClassImpl.SetProperty<string[]>(inParams, "DefinitionFiles", DefinitionFiles);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("GetDefinitionFileSummaryInformation", inParams, null!);
            SummaryInformation = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "SummaryInformation");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint AddKvpItems(string[] DataItems, ManagementBaseObject TargetSystem, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "AddKvpItems");
            WmiClassImpl.SetProperty<string[]>(inParams, "DataItems", DataItems);
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "TargetSystem", TargetSystem);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("AddKvpItems", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ModifyKvpItems(string[] DataItems, ManagementBaseObject TargetSystem, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ModifyKvpItems");
            WmiClassImpl.SetProperty<string[]>(inParams, "DataItems", DataItems);
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "TargetSystem", TargetSystem);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ModifyKvpItems", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RemoveKvpItems(string[] DataItems, ManagementBaseObject TargetSystem, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RemoveKvpItems");
            WmiClassImpl.SetProperty<string[]>(inParams, "DataItems", DataItems);
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "TargetSystem", TargetSystem);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RemoveKvpItems", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint FormatError(string[] Errors, out string? ErrorMessage)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "FormatError");
            WmiClassImpl.SetProperty<string[]>(inParams, "Errors", Errors);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("FormatError", inParams, null!);
            ErrorMessage = WmiClassImpl.GetProperty<string>(outParams, "ErrorMessage");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ModifyDiskMergeSettings(string SettingData, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ModifyDiskMergeSettings");
            WmiClassImpl.SetProperty<string>(inParams, "SettingData", SettingData);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ModifyDiskMergeSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint GenerateWwpn(uint NumberOfWwpns, out string[]? GeneratedWwpn)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "GenerateWwpn");
            WmiClassImpl.SetProperty<uint>(inParams, "NumberOfWwpns", NumberOfWwpns);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("GenerateWwpn", inParams, null!);
            GeneratedWwpn = WmiClassImpl.GetProperty<string[]>(outParams, "GeneratedWwpn");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint AddFibreChannelChap(string[] FcPortSettings, byte SecretEncoding, byte[] SharedSecret)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "AddFibreChannelChap");
            WmiClassImpl.SetProperty<string[]>(inParams, "FcPortSettings", FcPortSettings);
            WmiClassImpl.SetProperty<byte>(inParams, "SecretEncoding", SecretEncoding);
            WmiClassImpl.SetProperty<byte[]>(inParams, "SharedSecret", SharedSecret);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("AddFibreChannelChap", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RemoveFibreChannelChap(string[] FcPortSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RemoveFibreChannelChap");
            WmiClassImpl.SetProperty<string[]>(inParams, "FcPortSettings", FcPortSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RemoveFibreChannelChap", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint SetGuestNetworkAdapterConfiguration(ManagementBaseObject ComputerSystem, string[] NetworkConfiguration, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "SetGuestNetworkAdapterConfiguration");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "ComputerSystem", ComputerSystem);
            WmiClassImpl.SetProperty<string[]>(inParams, "NetworkConfiguration", NetworkConfiguration);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("SetGuestNetworkAdapterConfiguration", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint GetSizeOfSystemFiles(ManagementBaseObject Vssd, out UInt64? Size)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "GetSizeOfSystemFiles");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "Vssd", Vssd);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("GetSizeOfSystemFiles", inParams, null!);
            Size = WmiClassImpl.GetProperty<UInt64>(outParams, "Size");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint GetCurrentWwpnFromGenerator(out string? CurrentWwpn)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "GetCurrentWwpnFromGenerator");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("GetCurrentWwpnFromGenerator", inParams, null!);
            CurrentWwpn = WmiClassImpl.GetProperty<string>(outParams, "CurrentWwpn");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint TestNetworkConnection(uint IsolationId, bool IsSender, string ReceiverIP, string ReceiverMac, string SenderIP, uint SequenceNumber, ManagementBaseObject TargetNetworkAdapter, out ManagementBaseObject? Job, out uint? RoundTripTime)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "TestNetworkConnection");
            WmiClassImpl.SetProperty<uint>(inParams, "IsolationId", IsolationId);
            WmiClassImpl.SetProperty<bool>(inParams, "IsSender", IsSender);
            WmiClassImpl.SetProperty<string>(inParams, "ReceiverIP", ReceiverIP);
            WmiClassImpl.SetProperty<string>(inParams, "ReceiverMac", ReceiverMac);
            WmiClassImpl.SetProperty<string>(inParams, "SenderIP", SenderIP);
            WmiClassImpl.SetProperty<uint>(inParams, "SequenceNumber", SequenceNumber);
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "TargetNetworkAdapter", TargetNetworkAdapter);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("TestNetworkConnection", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            RoundTripTime = WmiClassImpl.GetProperty<uint>(outParams, "RoundTripTime");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint DiagnoseNetworkConnection(string DiagnosticSettings, ManagementBaseObject TargetNetworkAdapter, out string? DiagnosticInformation, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "DiagnoseNetworkConnection");
            WmiClassImpl.SetProperty<string>(inParams, "DiagnosticSettings", DiagnosticSettings);
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "TargetNetworkAdapter", TargetNetworkAdapter);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("DiagnoseNetworkConnection", inParams, null!);
            DiagnosticInformation = WmiClassImpl.GetProperty<string>(outParams, "DiagnosticInformation");
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint SetInitialMachineConfigurationData(byte[] ImcData, ManagementBaseObject TargetSystem, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "SetInitialMachineConfigurationData");
            WmiClassImpl.SetProperty<byte[]>(inParams, "ImcData", ImcData);
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "TargetSystem", TargetSystem);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("SetInitialMachineConfigurationData", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint AddSystemComponentSettings(ManagementBaseObject AffectedConfiguration, string[] ComponentSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingComponentSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "AddSystemComponentSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedConfiguration", AffectedConfiguration);
            WmiClassImpl.SetProperty<string[]>(inParams, "ComponentSettings", ComponentSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("AddSystemComponentSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingComponentSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingComponentSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ModifySystemComponentSettings(string[] ComponentSettings, out ManagementBaseObject? Job, out ManagementBaseObject[]? ResultingComponentSettings)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ModifySystemComponentSettings");
            WmiClassImpl.SetProperty<string[]>(inParams, "ComponentSettings", ComponentSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ModifySystemComponentSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            ResultingComponentSettings = WmiClassImpl.GetProperty<ManagementBaseObject[]>(outParams, "ResultingComponentSettings");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RemoveSystemComponentSettings(ManagementBaseObject[] ComponentSettings, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RemoveSystemComponentSettings");
            WmiClassImpl.SetProperty<ManagementBaseObject[]>(inParams, "ComponentSettings", ComponentSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RemoveSystemComponentSettings", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
    }

    [WmiClassName("Msvm_VirtualSystemSnapshotService", @"root\virtualization\v2")]
    public class IMsvm_VirtualSystemSnapshotService : IWmiObject
    {
        public IMsvm_VirtualSystemSnapshotService(ManagementBaseObject instance) { __Instance = instance; }

        public string? Caption{ get => WmiClassImpl.GetProperty<string>(__Instance, "Caption"); set => WmiClassImpl.SetProperty<string>(__Instance, "Caption", value); }
        public string? Description{ get => WmiClassImpl.GetProperty<string>(__Instance, "Description"); set => WmiClassImpl.SetProperty<string>(__Instance, "Description", value); }
        public string? ElementName{ get => WmiClassImpl.GetProperty<string>(__Instance, "ElementName"); set => WmiClassImpl.SetProperty<string>(__Instance, "ElementName", value); }
        public string? InstanceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "InstanceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "InstanceID", value); }
        public ushort? CommunicationStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "CommunicationStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "CommunicationStatus", value); }
        public ushort? DetailedStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "DetailedStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "DetailedStatus", value); }
        public ushort? HealthState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "HealthState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "HealthState", value); }
        public DateTime? InstallDate{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "InstallDate"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "InstallDate", value); }
        [WmiKey] public string? Name{ get => WmiClassImpl.GetProperty<string>(__Instance, "Name"); set => WmiClassImpl.SetProperty<string>(__Instance, "Name", value); }
        public ushort? OperatingStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "OperatingStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "OperatingStatus", value); }
        public ushort[]? OperationalStatus{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "OperationalStatus"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "OperationalStatus", value); }
        public ushort? PrimaryStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "PrimaryStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "PrimaryStatus", value); }
        public string? Status{ get => WmiClassImpl.GetProperty<string>(__Instance, "Status"); set => WmiClassImpl.SetProperty<string>(__Instance, "Status", value); }
        public string[]? StatusDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "StatusDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "StatusDescriptions", value); }
        public ushort[]? AvailableRequestedStates{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "AvailableRequestedStates"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "AvailableRequestedStates", value); }
        public ushort? EnabledDefault{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledDefault"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledDefault", value); }
        public ushort? EnabledState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledState", value); }
        public string? OtherEnabledState{ get => WmiClassImpl.GetProperty<string>(__Instance, "OtherEnabledState"); set => WmiClassImpl.SetProperty<string>(__Instance, "OtherEnabledState", value); }
        public ushort? RequestedState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "RequestedState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "RequestedState", value); }
        public DateTime? TimeOfLastStateChange{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeOfLastStateChange"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeOfLastStateChange", value); }
        public ushort? TransitioningToState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "TransitioningToState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "TransitioningToState", value); }
        [WmiKey] public string? CreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "CreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "CreationClassName", value); }
        public string? PrimaryOwnerContact{ get => WmiClassImpl.GetProperty<string>(__Instance, "PrimaryOwnerContact"); set => WmiClassImpl.SetProperty<string>(__Instance, "PrimaryOwnerContact", value); }
        public string? PrimaryOwnerName{ get => WmiClassImpl.GetProperty<string>(__Instance, "PrimaryOwnerName"); set => WmiClassImpl.SetProperty<string>(__Instance, "PrimaryOwnerName", value); }
        public bool? Started{ get => WmiClassImpl.GetProperty<bool>(__Instance, "Started"); set => WmiClassImpl.SetProperty<bool>(__Instance, "Started", value); }
        public string? StartMode{ get => WmiClassImpl.GetProperty<string>(__Instance, "StartMode"); set => WmiClassImpl.SetProperty<string>(__Instance, "StartMode", value); }
        [WmiKey] public string? SystemCreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "SystemCreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "SystemCreationClassName", value); }
        [WmiKey] public string? SystemName{ get => WmiClassImpl.GetProperty<string>(__Instance, "SystemName"); set => WmiClassImpl.SetProperty<string>(__Instance, "SystemName", value); }

        public uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RequestStateChange");
            WmiClassImpl.SetProperty<ushort>(inParams, "RequestedState", RequestedState);
            WmiClassImpl.SetProperty<DateTime>(inParams, "TimeoutPeriod", TimeoutPeriod);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RequestStateChange", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint StartService()
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "StartService");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("StartService", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint StopService()
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "StopService");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("StopService", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint CreateSnapshot(IMsvm_ComputerSystem AffectedSystem, out IMsvm_VirtualSystemSettingData? ResultingSnapshot, string SnapshotSettings, ushort SnapshotType, out IMsvm_ConcreteJob? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "CreateSnapshot");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedSystem", AffectedSystem.__Instance);
            WmiClassImpl.SetProperty<string>(inParams, "SnapshotSettings", SnapshotSettings);
            WmiClassImpl.SetProperty<ushort>(inParams, "SnapshotType", SnapshotType);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("CreateSnapshot", inParams, null!);
            ResultingSnapshot = WmiClassImpl.GetProperty<IMsvm_VirtualSystemSettingData>(outParams, "ResultingSnapshot");
            Job = WmiClassImpl.GetProperty<IMsvm_ConcreteJob>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint DestroySnapshot(IMsvm_VirtualSystemSettingData AffectedSnapshot, out IMsvm_ConcreteJob? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "DestroySnapshot");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedSnapshot", AffectedSnapshot.__Instance);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("DestroySnapshot", inParams, null!);
            Job = WmiClassImpl.GetProperty<IMsvm_ConcreteJob>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ApplySnapshot(IMsvm_VirtualSystemSettingData Snapshot, out IMsvm_ConcreteJob? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ApplySnapshot");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "Snapshot", Snapshot.__Instance);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ApplySnapshot", inParams, null!);
            Job = WmiClassImpl.GetProperty<IMsvm_ConcreteJob>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint DestroySnapshotTree(IMsvm_VirtualSystemSettingData SnapshotSettingData, out IMsvm_ConcreteJob? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "DestroySnapshotTree");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "SnapshotSettingData", SnapshotSettingData.__Instance);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("DestroySnapshotTree", inParams, null!);
            Job = WmiClassImpl.GetProperty<IMsvm_ConcreteJob>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ClearSnapshotState(ManagementBaseObject SnapshotSettingData, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ClearSnapshotState");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "SnapshotSettingData", SnapshotSettingData);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ClearSnapshotState", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ConvertToReferencePoint(ManagementBaseObject AffectedSnapshot, string ReferencePointSettings, out ManagementBaseObject? ResultingReferencePoint, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ConvertToReferencePoint");
            WmiClassImpl.SetProperty<ManagementBaseObject>(inParams, "AffectedSnapshot", AffectedSnapshot);
            WmiClassImpl.SetProperty<string>(inParams, "ReferencePointSettings", ReferencePointSettings);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ConvertToReferencePoint", inParams, null!);
            ResultingReferencePoint = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "ResultingReferencePoint");
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
    }

    [WmiClassName("Msvm_ComputerSystem", @"root\virtualization\v2")]
    public class IMsvm_ComputerSystem : IWmiObject
    {
        public IMsvm_ComputerSystem(ManagementBaseObject instance) { __Instance = instance; }

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

        public enum EnhancedSessionMode : ushort
        {
            AllowedAndAvailable = 2,
            NotAllowed = 3,
            AllowedButUnavailable = 6
        }

        public string? Caption{ get => WmiClassImpl.GetProperty<string>(__Instance, "Caption"); set => WmiClassImpl.SetProperty<string>(__Instance, "Caption", value); }
        public string? Description{ get => WmiClassImpl.GetProperty<string>(__Instance, "Description"); set => WmiClassImpl.SetProperty<string>(__Instance, "Description", value); }
        public string? ElementName{ get => WmiClassImpl.GetProperty<string>(__Instance, "ElementName"); set => WmiClassImpl.SetProperty<string>(__Instance, "ElementName", value); }
        public string? InstanceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "InstanceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "InstanceID", value); }
        public ushort? CommunicationStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "CommunicationStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "CommunicationStatus", value); }
        public ushort? DetailedStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "DetailedStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "DetailedStatus", value); }
        public ushort? HealthState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "HealthState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "HealthState", value); }
        public DateTime? InstallDate{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "InstallDate"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "InstallDate", value); }
        [WmiKey] public string? Name{ get => WmiClassImpl.GetProperty<string>(__Instance, "Name"); set => WmiClassImpl.SetProperty<string>(__Instance, "Name", value); }
        public ushort? OperatingStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "OperatingStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "OperatingStatus", value); }
        public ushort[]? OperationalStatus{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "OperationalStatus"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "OperationalStatus", value); }
        public ushort? PrimaryStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "PrimaryStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "PrimaryStatus", value); }
        public string? Status{ get => WmiClassImpl.GetProperty<string>(__Instance, "Status"); set => WmiClassImpl.SetProperty<string>(__Instance, "Status", value); }
        public string[]? StatusDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "StatusDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "StatusDescriptions", value); }
        public ushort[]? AvailableRequestedStates{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "AvailableRequestedStates"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "AvailableRequestedStates", value); }
        public ushort? EnabledDefault{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledDefault"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledDefault", value); }
        public SystemState? EnabledState{ get => WmiClassImpl.GetProperty<SystemState>(__Instance, "EnabledState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledState", value); }
        public string? OtherEnabledState{ get => WmiClassImpl.GetProperty<string>(__Instance, "OtherEnabledState"); set => WmiClassImpl.SetProperty<string>(__Instance, "OtherEnabledState", value); }
        public ushort? RequestedState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "RequestedState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "RequestedState", value); }
        public DateTime? TimeOfLastStateChange{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeOfLastStateChange"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeOfLastStateChange", value); }
        public ushort? TransitioningToState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "TransitioningToState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "TransitioningToState", value); }
        [WmiKey] public string? CreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "CreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "CreationClassName", value); }
        public string[]? IdentifyingDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "IdentifyingDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "IdentifyingDescriptions", value); }
        public string? NameFormat{ get => WmiClassImpl.GetProperty<string>(__Instance, "NameFormat"); set => WmiClassImpl.SetProperty<string>(__Instance, "NameFormat", value); }
        public string[]? OtherIdentifyingInfo{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "OtherIdentifyingInfo"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "OtherIdentifyingInfo", value); }
        public string? PrimaryOwnerContact{ get => WmiClassImpl.GetProperty<string>(__Instance, "PrimaryOwnerContact"); set => WmiClassImpl.SetProperty<string>(__Instance, "PrimaryOwnerContact", value); }
        public string? PrimaryOwnerName{ get => WmiClassImpl.GetProperty<string>(__Instance, "PrimaryOwnerName"); set => WmiClassImpl.SetProperty<string>(__Instance, "PrimaryOwnerName", value); }
        public string[]? Roles{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "Roles"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "Roles", value); }
        public ushort[]? Dedicated{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "Dedicated"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "Dedicated", value); }
        public string[]? OtherDedicatedDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "OtherDedicatedDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "OtherDedicatedDescriptions", value); }
        public ushort[]? PowerManagementCapabilities{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "PowerManagementCapabilities"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "PowerManagementCapabilities", value); }
        public ushort? ResetCapability{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ResetCapability"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ResetCapability", value); }
        public EnhancedSessionMode? EnhancedSessionModeState{ get => WmiClassImpl.GetProperty<EnhancedSessionMode>(__Instance, "EnhancedSessionModeState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnhancedSessionModeState", value); }
        public ushort? FailedOverReplicationType{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "FailedOverReplicationType"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "FailedOverReplicationType", value); }
        public uint? HwThreadsPerCoreRealized{ get => WmiClassImpl.GetProperty<uint>(__Instance, "HwThreadsPerCoreRealized"); set => WmiClassImpl.SetProperty<uint>(__Instance, "HwThreadsPerCoreRealized", value); }
        public DateTime? LastApplicationConsistentReplicationTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "LastApplicationConsistentReplicationTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "LastApplicationConsistentReplicationTime", value); }
        public DateTime? LastReplicationTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "LastReplicationTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "LastReplicationTime", value); }
        public ushort? LastReplicationType{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "LastReplicationType"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "LastReplicationType", value); }
        public DateTime? LastSuccessfulBackupTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "LastSuccessfulBackupTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "LastSuccessfulBackupTime", value); }
        public ushort? NumberOfNumaNodes{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "NumberOfNumaNodes"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "NumberOfNumaNodes", value); }
        public UInt64? OnTimeInMilliseconds{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "OnTimeInMilliseconds"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "OnTimeInMilliseconds", value); }
        public uint? ProcessID{ get => WmiClassImpl.GetProperty<uint>(__Instance, "ProcessID"); set => WmiClassImpl.SetProperty<uint>(__Instance, "ProcessID", value); }
        public ushort? ReplicationHealth{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ReplicationHealth"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ReplicationHealth", value); }
        public ushort? ReplicationMode{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ReplicationMode"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ReplicationMode", value); }
        public ushort? ReplicationState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ReplicationState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ReplicationState", value); }
        public DateTime? TimeOfLastConfigurationChange{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeOfLastConfigurationChange"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeOfLastConfigurationChange", value); }

        public uint RequestStateChange(ushort RequestedState, out IMsvm_ConcreteJob? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RequestStateChange");
            WmiClassImpl.SetProperty<ushort>(inParams, "RequestedState", RequestedState);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RequestStateChange", inParams, null!);
            Job = WmiClassImpl.GetProperty<IMsvm_ConcreteJob>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint SetPowerState(uint PowerState, DateTime Time)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "SetPowerState");
            WmiClassImpl.SetProperty<uint>(inParams, "PowerState", PowerState);
            WmiClassImpl.SetProperty<DateTime>(inParams, "Time", Time);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("SetPowerState", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RequestReplicationStateChange(ushort RequestedState, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RequestReplicationStateChange");
            WmiClassImpl.SetProperty<ushort>(inParams, "RequestedState", RequestedState);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RequestReplicationStateChange", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint InjectNonMaskableInterrupt(out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "InjectNonMaskableInterrupt");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("InjectNonMaskableInterrupt", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RequestReplicationStateChangeEx(string ReplicationRelationship, ushort RequestedState, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RequestReplicationStateChangeEx");
            WmiClassImpl.SetProperty<string>(inParams, "ReplicationRelationship", ReplicationRelationship);
            WmiClassImpl.SetProperty<ushort>(inParams, "RequestedState", RequestedState);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RequestReplicationStateChangeEx", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
    }

    [WmiClassName("Msvm_Keyboard", @"root\virtualization\v2")]
    public class IMsvm_Keyboard : IWmiObject
    {
        public IMsvm_Keyboard(ManagementBaseObject instance) { __Instance = instance; }

        public string? Caption{ get => WmiClassImpl.GetProperty<string>(__Instance, "Caption"); set => WmiClassImpl.SetProperty<string>(__Instance, "Caption", value); }
        public string? Description{ get => WmiClassImpl.GetProperty<string>(__Instance, "Description"); set => WmiClassImpl.SetProperty<string>(__Instance, "Description", value); }
        public string? ElementName{ get => WmiClassImpl.GetProperty<string>(__Instance, "ElementName"); set => WmiClassImpl.SetProperty<string>(__Instance, "ElementName", value); }
        public string? InstanceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "InstanceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "InstanceID", value); }
        public ushort? CommunicationStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "CommunicationStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "CommunicationStatus", value); }
        public ushort? DetailedStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "DetailedStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "DetailedStatus", value); }
        public ushort? HealthState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "HealthState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "HealthState", value); }
        public DateTime? InstallDate{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "InstallDate"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "InstallDate", value); }
        public string? Name{ get => WmiClassImpl.GetProperty<string>(__Instance, "Name"); set => WmiClassImpl.SetProperty<string>(__Instance, "Name", value); }
        public ushort? OperatingStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "OperatingStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "OperatingStatus", value); }
        public ushort[]? OperationalStatus{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "OperationalStatus"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "OperationalStatus", value); }
        public ushort? PrimaryStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "PrimaryStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "PrimaryStatus", value); }
        public string? Status{ get => WmiClassImpl.GetProperty<string>(__Instance, "Status"); set => WmiClassImpl.SetProperty<string>(__Instance, "Status", value); }
        public string[]? StatusDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "StatusDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "StatusDescriptions", value); }
        public ushort[]? AvailableRequestedStates{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "AvailableRequestedStates"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "AvailableRequestedStates", value); }
        public ushort? EnabledDefault{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledDefault"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledDefault", value); }
        public ushort? EnabledState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledState", value); }
        public string? OtherEnabledState{ get => WmiClassImpl.GetProperty<string>(__Instance, "OtherEnabledState"); set => WmiClassImpl.SetProperty<string>(__Instance, "OtherEnabledState", value); }
        public ushort? RequestedState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "RequestedState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "RequestedState", value); }
        public DateTime? TimeOfLastStateChange{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeOfLastStateChange"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeOfLastStateChange", value); }
        public ushort? TransitioningToState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "TransitioningToState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "TransitioningToState", value); }
        public ushort[]? AdditionalAvailability{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "AdditionalAvailability"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "AdditionalAvailability", value); }
        public ushort? Availability{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "Availability"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "Availability", value); }
        [WmiKey] public string? CreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "CreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "CreationClassName", value); }
        [WmiKey] public string? DeviceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "DeviceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "DeviceID", value); }
        public bool? ErrorCleared{ get => WmiClassImpl.GetProperty<bool>(__Instance, "ErrorCleared"); set => WmiClassImpl.SetProperty<bool>(__Instance, "ErrorCleared", value); }
        public string? ErrorDescription{ get => WmiClassImpl.GetProperty<string>(__Instance, "ErrorDescription"); set => WmiClassImpl.SetProperty<string>(__Instance, "ErrorDescription", value); }
        public string[]? IdentifyingDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "IdentifyingDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "IdentifyingDescriptions", value); }
        public uint? LastErrorCode{ get => WmiClassImpl.GetProperty<uint>(__Instance, "LastErrorCode"); set => WmiClassImpl.SetProperty<uint>(__Instance, "LastErrorCode", value); }
        public UInt64? MaxQuiesceTime{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "MaxQuiesceTime"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "MaxQuiesceTime", value); }
        public string[]? OtherIdentifyingInfo{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "OtherIdentifyingInfo"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "OtherIdentifyingInfo", value); }
        public ushort[]? PowerManagementCapabilities{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "PowerManagementCapabilities"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "PowerManagementCapabilities", value); }
        public bool? PowerManagementSupported{ get => WmiClassImpl.GetProperty<bool>(__Instance, "PowerManagementSupported"); set => WmiClassImpl.SetProperty<bool>(__Instance, "PowerManagementSupported", value); }
        public UInt64? PowerOnHours{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "PowerOnHours"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "PowerOnHours", value); }
        public ushort? StatusInfo{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "StatusInfo"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "StatusInfo", value); }
        [WmiKey] public string? SystemCreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "SystemCreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "SystemCreationClassName", value); }
        [WmiKey] public string? SystemName{ get => WmiClassImpl.GetProperty<string>(__Instance, "SystemName"); set => WmiClassImpl.SetProperty<string>(__Instance, "SystemName", value); }
        public UInt64? TotalPowerOnHours{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "TotalPowerOnHours"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "TotalPowerOnHours", value); }
        public bool? IsLocked{ get => WmiClassImpl.GetProperty<bool>(__Instance, "IsLocked"); set => WmiClassImpl.SetProperty<bool>(__Instance, "IsLocked", value); }
        public string? Layout{ get => WmiClassImpl.GetProperty<string>(__Instance, "Layout"); set => WmiClassImpl.SetProperty<string>(__Instance, "Layout", value); }
        public ushort? NumberOfFunctionKeys{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "NumberOfFunctionKeys"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "NumberOfFunctionKeys", value); }
        public ushort? Password{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "Password"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "Password", value); }
        public bool? UnicodeSupported{ get => WmiClassImpl.GetProperty<bool>(__Instance, "UnicodeSupported"); set => WmiClassImpl.SetProperty<bool>(__Instance, "UnicodeSupported", value); }

        public uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RequestStateChange");
            WmiClassImpl.SetProperty<ushort>(inParams, "RequestedState", RequestedState);
            WmiClassImpl.SetProperty<DateTime>(inParams, "TimeoutPeriod", TimeoutPeriod);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RequestStateChange", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint SetPowerState(ushort PowerState, DateTime Time)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "SetPowerState");
            WmiClassImpl.SetProperty<ushort>(inParams, "PowerState", PowerState);
            WmiClassImpl.SetProperty<DateTime>(inParams, "Time", Time);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("SetPowerState", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint Reset()
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "Reset");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("Reset", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint EnableDevice(bool Enabled)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "EnableDevice");
            WmiClassImpl.SetProperty<bool>(inParams, "Enabled", Enabled);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("EnableDevice", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint OnlineDevice(bool Online)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "OnlineDevice");
            WmiClassImpl.SetProperty<bool>(inParams, "Online", Online);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("OnlineDevice", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint QuiesceDevice(bool Quiesce)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "QuiesceDevice");
            WmiClassImpl.SetProperty<bool>(inParams, "Quiesce", Quiesce);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("QuiesceDevice", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint SaveProperties()
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "SaveProperties");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("SaveProperties", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RestoreProperties()
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RestoreProperties");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RestoreProperties", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint PressKey(uint KeyCode)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "PressKey");
            WmiClassImpl.SetProperty<uint>(inParams, "KeyCode", KeyCode);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("PressKey", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint ReleaseKey(uint KeyCode)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "ReleaseKey");
            WmiClassImpl.SetProperty<uint>(inParams, "KeyCode", KeyCode);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("ReleaseKey", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint TypeKey(uint KeyCode)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "TypeKey");
            WmiClassImpl.SetProperty<uint>(inParams, "KeyCode", KeyCode);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("TypeKey", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint IsKeyPressed(uint KeyCode, out bool? KeyState)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "IsKeyPressed");
            WmiClassImpl.SetProperty<uint>(inParams, "KeyCode", KeyCode);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("IsKeyPressed", inParams, null!);
            KeyState = WmiClassImpl.GetProperty<bool>(outParams, "KeyState");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint TypeText(string AsciiText)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "TypeText");
            WmiClassImpl.SetProperty<string>(inParams, "AsciiText", AsciiText);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("TypeText", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint TypeCtrlAltDel()
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "TypeCtrlAltDel");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("TypeCtrlAltDel", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint TypeScancodes(byte[] Scancodes)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "TypeScancodes");
            WmiClassImpl.SetProperty<byte[]>(inParams, "Scancodes", Scancodes);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("TypeScancodes", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
    }

    [WmiClassName("Msvm_VirtualSystemSettingData", @"root\virtualization\v2")]
    public class IMsvm_VirtualSystemSettingData : IWmiObject
    {
        public IMsvm_VirtualSystemSettingData(ManagementBaseObject instance) { __Instance = instance; }

        public string? Caption{ get => WmiClassImpl.GetProperty<string>(__Instance, "Caption"); set => WmiClassImpl.SetProperty<string>(__Instance, "Caption", value); }
        public string? Description{ get => WmiClassImpl.GetProperty<string>(__Instance, "Description"); set => WmiClassImpl.SetProperty<string>(__Instance, "Description", value); }
        public string? ElementName{ get => WmiClassImpl.GetProperty<string>(__Instance, "ElementName"); set => WmiClassImpl.SetProperty<string>(__Instance, "ElementName", value); }
        [WmiKey] public string? InstanceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "InstanceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "InstanceID", value); }
        public ushort? AutomaticRecoveryAction{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "AutomaticRecoveryAction"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "AutomaticRecoveryAction", value); }
        public ushort? AutomaticShutdownAction{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "AutomaticShutdownAction"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "AutomaticShutdownAction", value); }
        public ushort? AutomaticStartupAction{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "AutomaticStartupAction"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "AutomaticStartupAction", value); }
        public DateTime? AutomaticStartupActionDelay{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "AutomaticStartupActionDelay"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "AutomaticStartupActionDelay", value); }
        public ushort? AutomaticStartupActionSequenceNumber{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "AutomaticStartupActionSequenceNumber"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "AutomaticStartupActionSequenceNumber", value); }
        public string? ConfigurationDataRoot{ get => WmiClassImpl.GetProperty<string>(__Instance, "ConfigurationDataRoot"); set => WmiClassImpl.SetProperty<string>(__Instance, "ConfigurationDataRoot", value); }
        public string? ConfigurationFile{ get => WmiClassImpl.GetProperty<string>(__Instance, "ConfigurationFile"); set => WmiClassImpl.SetProperty<string>(__Instance, "ConfigurationFile", value); }
        public string? ConfigurationID{ get => WmiClassImpl.GetProperty<string>(__Instance, "ConfigurationID"); set => WmiClassImpl.SetProperty<string>(__Instance, "ConfigurationID", value); }
        public DateTime? CreationTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "CreationTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "CreationTime", value); }
        public string? LogDataRoot{ get => WmiClassImpl.GetProperty<string>(__Instance, "LogDataRoot"); set => WmiClassImpl.SetProperty<string>(__Instance, "LogDataRoot", value); }
        public string[]? Notes{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "Notes"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "Notes", value); }
        public string? RecoveryFile{ get => WmiClassImpl.GetProperty<string>(__Instance, "RecoveryFile"); set => WmiClassImpl.SetProperty<string>(__Instance, "RecoveryFile", value); }
        public string? SnapshotDataRoot{ get => WmiClassImpl.GetProperty<string>(__Instance, "SnapshotDataRoot"); set => WmiClassImpl.SetProperty<string>(__Instance, "SnapshotDataRoot", value); }
        public string? SuspendDataRoot{ get => WmiClassImpl.GetProperty<string>(__Instance, "SuspendDataRoot"); set => WmiClassImpl.SetProperty<string>(__Instance, "SuspendDataRoot", value); }
        public string? SwapFileDataRoot{ get => WmiClassImpl.GetProperty<string>(__Instance, "SwapFileDataRoot"); set => WmiClassImpl.SetProperty<string>(__Instance, "SwapFileDataRoot", value); }
        public string? VirtualSystemIdentifier{ get => WmiClassImpl.GetProperty<string>(__Instance, "VirtualSystemIdentifier"); set => WmiClassImpl.SetProperty<string>(__Instance, "VirtualSystemIdentifier", value); }
        public string? VirtualSystemType{ get => WmiClassImpl.GetProperty<string>(__Instance, "VirtualSystemType"); set => WmiClassImpl.SetProperty<string>(__Instance, "VirtualSystemType", value); }
        public string? AdditionalRecoveryInformation{ get => WmiClassImpl.GetProperty<string>(__Instance, "AdditionalRecoveryInformation"); set => WmiClassImpl.SetProperty<string>(__Instance, "AdditionalRecoveryInformation", value); }
        public bool? AllowFullSCSICommandSet{ get => WmiClassImpl.GetProperty<bool>(__Instance, "AllowFullSCSICommandSet"); set => WmiClassImpl.SetProperty<bool>(__Instance, "AllowFullSCSICommandSet", value); }
        public bool? AllowReducedFcRedundancy{ get => WmiClassImpl.GetProperty<bool>(__Instance, "AllowReducedFcRedundancy"); set => WmiClassImpl.SetProperty<bool>(__Instance, "AllowReducedFcRedundancy", value); }
        public string? Architecture{ get => WmiClassImpl.GetProperty<string>(__Instance, "Architecture"); set => WmiClassImpl.SetProperty<string>(__Instance, "Architecture", value); }
        public ushort? AutomaticCriticalErrorAction{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "AutomaticCriticalErrorAction"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "AutomaticCriticalErrorAction", value); }
        public DateTime? AutomaticCriticalErrorActionTimeout{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "AutomaticCriticalErrorActionTimeout"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "AutomaticCriticalErrorActionTimeout", value); }
        public bool? AutomaticSnapshotsEnabled{ get => WmiClassImpl.GetProperty<bool>(__Instance, "AutomaticSnapshotsEnabled"); set => WmiClassImpl.SetProperty<bool>(__Instance, "AutomaticSnapshotsEnabled", value); }
        public string? BaseBoardSerialNumber{ get => WmiClassImpl.GetProperty<string>(__Instance, "BaseBoardSerialNumber"); set => WmiClassImpl.SetProperty<string>(__Instance, "BaseBoardSerialNumber", value); }
        public string? BIOSGUID{ get => WmiClassImpl.GetProperty<string>(__Instance, "BIOSGUID"); set => WmiClassImpl.SetProperty<string>(__Instance, "BIOSGUID", value); }
        public bool? BIOSNumLock{ get => WmiClassImpl.GetProperty<bool>(__Instance, "BIOSNumLock"); set => WmiClassImpl.SetProperty<bool>(__Instance, "BIOSNumLock", value); }
        public string? BIOSSerialNumber{ get => WmiClassImpl.GetProperty<string>(__Instance, "BIOSSerialNumber"); set => WmiClassImpl.SetProperty<string>(__Instance, "BIOSSerialNumber", value); }
        public ushort[]? BootOrder{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "BootOrder"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "BootOrder", value); }
        public bool? BootPciExpress{ get => WmiClassImpl.GetProperty<bool>(__Instance, "BootPciExpress"); set => WmiClassImpl.SetProperty<bool>(__Instance, "BootPciExpress", value); }
        public string? BootPciExpressInstanceFilter{ get => WmiClassImpl.GetProperty<string>(__Instance, "BootPciExpressInstanceFilter"); set => WmiClassImpl.SetProperty<string>(__Instance, "BootPciExpressInstanceFilter", value); }
        public string[]? BootSourceOrder{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "BootSourceOrder"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "BootSourceOrder", value); }
        public string? ChassisAssetTag{ get => WmiClassImpl.GetProperty<string>(__Instance, "ChassisAssetTag"); set => WmiClassImpl.SetProperty<string>(__Instance, "ChassisAssetTag", value); }
        public string? ChassisSerialNumber{ get => WmiClassImpl.GetProperty<string>(__Instance, "ChassisSerialNumber"); set => WmiClassImpl.SetProperty<string>(__Instance, "ChassisSerialNumber", value); }
        public ushort? ClusterWideNodeCapabilitiesValidationMode{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ClusterWideNodeCapabilitiesValidationMode"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ClusterWideNodeCapabilitiesValidationMode", value); }
        public ushort? ConsoleMode{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ConsoleMode"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ConsoleMode", value); }
        public uint? DebugChannelId{ get => WmiClassImpl.GetProperty<uint>(__Instance, "DebugChannelId"); set => WmiClassImpl.SetProperty<uint>(__Instance, "DebugChannelId", value); }
        public uint? DebugPort{ get => WmiClassImpl.GetProperty<uint>(__Instance, "DebugPort"); set => WmiClassImpl.SetProperty<uint>(__Instance, "DebugPort", value); }
        public ushort? DebugPortEnabled{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "DebugPortEnabled"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "DebugPortEnabled", value); }
        public bool? EnableHibernation{ get => WmiClassImpl.GetProperty<bool>(__Instance, "EnableHibernation"); set => WmiClassImpl.SetProperty<bool>(__Instance, "EnableHibernation", value); }
        public ushort? EnhancedSessionTransportType{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnhancedSessionTransportType"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnhancedSessionTransportType", value); }
        public bool? GuestControlledCacheTypes{ get => WmiClassImpl.GetProperty<bool>(__Instance, "GuestControlledCacheTypes"); set => WmiClassImpl.SetProperty<bool>(__Instance, "GuestControlledCacheTypes", value); }
        public string? GuestStateDataRoot{ get => WmiClassImpl.GetProperty<string>(__Instance, "GuestStateDataRoot"); set => WmiClassImpl.SetProperty<string>(__Instance, "GuestStateDataRoot", value); }
        public string? GuestStateFile{ get => WmiClassImpl.GetProperty<string>(__Instance, "GuestStateFile"); set => WmiClassImpl.SetProperty<string>(__Instance, "GuestStateFile", value); }
        public bool? GuestStateIsolationEnabled{ get => WmiClassImpl.GetProperty<bool>(__Instance, "GuestStateIsolationEnabled"); set => WmiClassImpl.SetProperty<bool>(__Instance, "GuestStateIsolationEnabled", value); }
        public ushort? GuestStateIsolationType{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "GuestStateIsolationType"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "GuestStateIsolationType", value); }
        public UInt64? HighMmioGapBase{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "HighMmioGapBase"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "HighMmioGapBase", value); }
        public UInt64? HighMmioGapSize{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "HighMmioGapSize"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "HighMmioGapSize", value); }
        public bool? IncrementalBackupEnabled{ get => WmiClassImpl.GetProperty<bool>(__Instance, "IncrementalBackupEnabled"); set => WmiClassImpl.SetProperty<bool>(__Instance, "IncrementalBackupEnabled", value); }
        public bool? IsAutomaticSnapshot{ get => WmiClassImpl.GetProperty<bool>(__Instance, "IsAutomaticSnapshot"); set => WmiClassImpl.SetProperty<bool>(__Instance, "IsAutomaticSnapshot", value); }
        public bool? IsSaved{ get => WmiClassImpl.GetProperty<bool>(__Instance, "IsSaved"); set => WmiClassImpl.SetProperty<bool>(__Instance, "IsSaved", value); }
        public bool? LockOnDisconnect{ get => WmiClassImpl.GetProperty<bool>(__Instance, "LockOnDisconnect"); set => WmiClassImpl.SetProperty<bool>(__Instance, "LockOnDisconnect", value); }
        public UInt64? LowMmioGapSize{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "LowMmioGapSize"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "LowMmioGapSize", value); }
        public ushort? NetworkBootPreferredProtocol{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "NetworkBootPreferredProtocol"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "NetworkBootPreferredProtocol", value); }
        public string[]? NumaNodeTopologyArray{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "NumaNodeTopologyArray"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "NumaNodeTopologyArray", value); }
        public string? Parent{ get => WmiClassImpl.GetProperty<string>(__Instance, "Parent"); set => WmiClassImpl.SetProperty<string>(__Instance, "Parent", value); }
        public bool? PauseAfterBootFailure{ get => WmiClassImpl.GetProperty<bool>(__Instance, "PauseAfterBootFailure"); set => WmiClassImpl.SetProperty<bool>(__Instance, "PauseAfterBootFailure", value); }
        public bool? SecureBootEnabled{ get => WmiClassImpl.GetProperty<bool>(__Instance, "SecureBootEnabled"); set => WmiClassImpl.SetProperty<bool>(__Instance, "SecureBootEnabled", value); }
        public string? SecureBootTemplateId{ get => WmiClassImpl.GetProperty<string>(__Instance, "SecureBootTemplateId"); set => WmiClassImpl.SetProperty<string>(__Instance, "SecureBootTemplateId", value); }
        public bool? TurnOffOnGuestRestart{ get => WmiClassImpl.GetProperty<bool>(__Instance, "TurnOffOnGuestRestart"); set => WmiClassImpl.SetProperty<bool>(__Instance, "TurnOffOnGuestRestart", value); }
        public ushort? UserSnapshotType{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "UserSnapshotType"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "UserSnapshotType", value); }
        public string? Version{ get => WmiClassImpl.GetProperty<string>(__Instance, "Version"); set => WmiClassImpl.SetProperty<string>(__Instance, "Version", value); }
        public bool? VirtualNumaEnabled{ get => WmiClassImpl.GetProperty<bool>(__Instance, "VirtualNumaEnabled"); set => WmiClassImpl.SetProperty<bool>(__Instance, "VirtualNumaEnabled", value); }
        public ushort? VirtualSlitType{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "VirtualSlitType"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "VirtualSlitType", value); }
        public string? VirtualSystemSubType{ get => WmiClassImpl.GetProperty<string>(__Instance, "VirtualSystemSubType"); set => WmiClassImpl.SetProperty<string>(__Instance, "VirtualSystemSubType", value); }
    }

    [WmiClassName("Msvm_ConcreteJob", @"root\virtualization\v2")]
    public class IMsvm_ConcreteJob : IWmiObject
    {
        public IMsvm_ConcreteJob(ManagementBaseObject instance) { __Instance = instance; }

        public string? Caption{ get => WmiClassImpl.GetProperty<string>(__Instance, "Caption"); set => WmiClassImpl.SetProperty<string>(__Instance, "Caption", value); }
        public string? Description{ get => WmiClassImpl.GetProperty<string>(__Instance, "Description"); set => WmiClassImpl.SetProperty<string>(__Instance, "Description", value); }
        public string? ElementName{ get => WmiClassImpl.GetProperty<string>(__Instance, "ElementName"); set => WmiClassImpl.SetProperty<string>(__Instance, "ElementName", value); }
        [WmiKey] public string? InstanceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "InstanceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "InstanceID", value); }
        public ushort? CommunicationStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "CommunicationStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "CommunicationStatus", value); }
        public ushort? DetailedStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "DetailedStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "DetailedStatus", value); }
        public ushort? HealthState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "HealthState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "HealthState", value); }
        public DateTime? InstallDate{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "InstallDate"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "InstallDate", value); }
        public string? Name{ get => WmiClassImpl.GetProperty<string>(__Instance, "Name"); set => WmiClassImpl.SetProperty<string>(__Instance, "Name", value); }
        public ushort? OperatingStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "OperatingStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "OperatingStatus", value); }
        public ushort[]? OperationalStatus{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "OperationalStatus"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "OperationalStatus", value); }
        public ushort? PrimaryStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "PrimaryStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "PrimaryStatus", value); }
        public string? Status{ get => WmiClassImpl.GetProperty<string>(__Instance, "Status"); set => WmiClassImpl.SetProperty<string>(__Instance, "Status", value); }
        public string[]? StatusDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "StatusDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "StatusDescriptions", value); }
        public bool? DeleteOnCompletion{ get => WmiClassImpl.GetProperty<bool>(__Instance, "DeleteOnCompletion"); set => WmiClassImpl.SetProperty<bool>(__Instance, "DeleteOnCompletion", value); }
        public DateTime? ElapsedTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "ElapsedTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "ElapsedTime", value); }
        public ushort? ErrorCode{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ErrorCode"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ErrorCode", value); }
        public string? ErrorDescription{ get => WmiClassImpl.GetProperty<string>(__Instance, "ErrorDescription"); set => WmiClassImpl.SetProperty<string>(__Instance, "ErrorDescription", value); }
        public uint? JobRunTimes{ get => WmiClassImpl.GetProperty<uint>(__Instance, "JobRunTimes"); set => WmiClassImpl.SetProperty<uint>(__Instance, "JobRunTimes", value); }
        public string? JobStatus{ get => WmiClassImpl.GetProperty<string>(__Instance, "JobStatus"); set => WmiClassImpl.SetProperty<string>(__Instance, "JobStatus", value); }
        public ushort? LocalOrUtcTime{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "LocalOrUtcTime"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "LocalOrUtcTime", value); }
        public string? Notify{ get => WmiClassImpl.GetProperty<string>(__Instance, "Notify"); set => WmiClassImpl.SetProperty<string>(__Instance, "Notify", value); }
        public string? OtherRecoveryAction{ get => WmiClassImpl.GetProperty<string>(__Instance, "OtherRecoveryAction"); set => WmiClassImpl.SetProperty<string>(__Instance, "OtherRecoveryAction", value); }
        public string? Owner{ get => WmiClassImpl.GetProperty<string>(__Instance, "Owner"); set => WmiClassImpl.SetProperty<string>(__Instance, "Owner", value); }
        public ushort? PercentComplete{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "PercentComplete"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "PercentComplete", value); }
        public uint? Priority{ get => WmiClassImpl.GetProperty<uint>(__Instance, "Priority"); set => WmiClassImpl.SetProperty<uint>(__Instance, "Priority", value); }
        public ushort? RecoveryAction{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "RecoveryAction"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "RecoveryAction", value); }
        public sbyte? RunDay{ get => WmiClassImpl.GetProperty<sbyte>(__Instance, "RunDay"); set => WmiClassImpl.SetProperty<sbyte>(__Instance, "RunDay", value); }
        public sbyte? RunDayOfWeek{ get => WmiClassImpl.GetProperty<sbyte>(__Instance, "RunDayOfWeek"); set => WmiClassImpl.SetProperty<sbyte>(__Instance, "RunDayOfWeek", value); }
        public byte? RunMonth{ get => WmiClassImpl.GetProperty<byte>(__Instance, "RunMonth"); set => WmiClassImpl.SetProperty<byte>(__Instance, "RunMonth", value); }
        public DateTime? RunStartInterval{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "RunStartInterval"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "RunStartInterval", value); }
        public DateTime? ScheduledStartTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "ScheduledStartTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "ScheduledStartTime", value); }
        public DateTime? StartTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "StartTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "StartTime", value); }
        public DateTime? TimeSubmitted{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeSubmitted"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeSubmitted", value); }
        public DateTime? UntilTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "UntilTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "UntilTime", value); }
        public ushort? JobState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "JobState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "JobState", value); }
        public DateTime? TimeBeforeRemoval{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeBeforeRemoval"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeBeforeRemoval", value); }
        public DateTime? TimeOfLastStateChange{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeOfLastStateChange"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeOfLastStateChange", value); }
        public bool? Cancellable{ get => WmiClassImpl.GetProperty<bool>(__Instance, "Cancellable"); set => WmiClassImpl.SetProperty<bool>(__Instance, "Cancellable", value); }
        public string? ErrorSummaryDescription{ get => WmiClassImpl.GetProperty<string>(__Instance, "ErrorSummaryDescription"); set => WmiClassImpl.SetProperty<string>(__Instance, "ErrorSummaryDescription", value); }
        public ushort? JobType{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "JobType"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "JobType", value); }

        public uint KillJob(bool DeleteOnKill)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "KillJob");
            WmiClassImpl.SetProperty<bool>(inParams, "DeleteOnKill", DeleteOnKill);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("KillJob", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RequestStateChange");
            WmiClassImpl.SetProperty<ushort>(inParams, "RequestedState", RequestedState);
            WmiClassImpl.SetProperty<DateTime>(inParams, "TimeoutPeriod", TimeoutPeriod);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RequestStateChange", inParams, null!);
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint GetError(out string? Error)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "GetError");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("GetError", inParams, null!);
            Error = WmiClassImpl.GetProperty<string>(outParams, "Error");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
        public uint GetErrorEx(out string[]? Errors)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "GetErrorEx");
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("GetErrorEx", inParams, null!);
            Errors = WmiClassImpl.GetProperty<string[]>(outParams, "Errors");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
    }

    [WmiClassName("Msvm_SummaryInformation", @"root\virtualization\v2")]
    public class IMsvm_SummaryInformation : IWmiObject
    {
        public IMsvm_SummaryInformation(ManagementBaseObject instance) { __Instance = instance; }

        public string? Caption{ get => WmiClassImpl.GetProperty<string>(__Instance, "Caption"); set => WmiClassImpl.SetProperty<string>(__Instance, "Caption", value); }
        public string? Description{ get => WmiClassImpl.GetProperty<string>(__Instance, "Description"); set => WmiClassImpl.SetProperty<string>(__Instance, "Description", value); }
        public string? ElementName{ get => WmiClassImpl.GetProperty<string>(__Instance, "ElementName"); set => WmiClassImpl.SetProperty<string>(__Instance, "ElementName", value); }
        [WmiKey] public string? InstanceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "InstanceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "InstanceID", value); }
        public DateTime? CreationTime{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "CreationTime"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "CreationTime", value); }
        public ushort? EnabledState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledState", value); }
        public ushort? EnhancedSessionModeState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnhancedSessionModeState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnhancedSessionModeState", value); }
        public ushort? HealthState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "HealthState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "HealthState", value); }
        public string? HostComputerSystemName{ get => WmiClassImpl.GetProperty<string>(__Instance, "HostComputerSystemName"); set => WmiClassImpl.SetProperty<string>(__Instance, "HostComputerSystemName", value); }
        public string? Name{ get => WmiClassImpl.GetProperty<string>(__Instance, "Name"); set => WmiClassImpl.SetProperty<string>(__Instance, "Name", value); }
        public string? Notes{ get => WmiClassImpl.GetProperty<string>(__Instance, "Notes"); set => WmiClassImpl.SetProperty<string>(__Instance, "Notes", value); }
        public ushort? NumberOfProcessors{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "NumberOfProcessors"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "NumberOfProcessors", value); }
        public ushort[]? OperationalStatus{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "OperationalStatus"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "OperationalStatus", value); }
        public string? OtherEnabledState{ get => WmiClassImpl.GetProperty<string>(__Instance, "OtherEnabledState"); set => WmiClassImpl.SetProperty<string>(__Instance, "OtherEnabledState", value); }
        public string[]? StatusDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "StatusDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "StatusDescriptions", value); }
        public UInt64? UpTime{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "UpTime"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "UpTime", value); }
        public string? Version{ get => WmiClassImpl.GetProperty<string>(__Instance, "Version"); set => WmiClassImpl.SetProperty<string>(__Instance, "Version", value); }
        public string[]? VirtualSwitchNames{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "VirtualSwitchNames"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "VirtualSwitchNames", value); }
        public string? VirtualSystemSubType{ get => WmiClassImpl.GetProperty<string>(__Instance, "VirtualSystemSubType"); set => WmiClassImpl.SetProperty<string>(__Instance, "VirtualSystemSubType", value); }
        public string? AllocatedGPU{ get => WmiClassImpl.GetProperty<string>(__Instance, "AllocatedGPU"); set => WmiClassImpl.SetProperty<string>(__Instance, "AllocatedGPU", value); }
        public ushort? ApplicationHealth{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ApplicationHealth"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ApplicationHealth", value); }
        public ManagementBaseObject[]? AsynchronousTasks{ get => WmiClassImpl.GetProperty<ManagementBaseObject[]>(__Instance, "AsynchronousTasks"); set => WmiClassImpl.SetProperty<ManagementBaseObject[]>(__Instance, "AsynchronousTasks", value); }
        public int? AvailableMemoryBuffer{ get => WmiClassImpl.GetProperty<int>(__Instance, "AvailableMemoryBuffer"); set => WmiClassImpl.SetProperty<int>(__Instance, "AvailableMemoryBuffer", value); }
        public string? GuestOperatingSystem{ get => WmiClassImpl.GetProperty<string>(__Instance, "GuestOperatingSystem"); set => WmiClassImpl.SetProperty<string>(__Instance, "GuestOperatingSystem", value); }
        public ushort? Heartbeat{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "Heartbeat"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "Heartbeat", value); }
        public UInt64? HypervisorPartitionId{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "HypervisorPartitionId"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "HypervisorPartitionId", value); }
        public ushort? IntegrationServicesVersionState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "IntegrationServicesVersionState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "IntegrationServicesVersionState", value); }
        public int? MemoryAvailable{ get => WmiClassImpl.GetProperty<int>(__Instance, "MemoryAvailable"); set => WmiClassImpl.SetProperty<int>(__Instance, "MemoryAvailable", value); }
        public bool? MemorySpansPhysicalNumaNodes{ get => WmiClassImpl.GetProperty<bool>(__Instance, "MemorySpansPhysicalNumaNodes"); set => WmiClassImpl.SetProperty<bool>(__Instance, "MemorySpansPhysicalNumaNodes", value); }
        public UInt64? MemoryUsage{ get => WmiClassImpl.GetProperty<UInt64>(__Instance, "MemoryUsage"); set => WmiClassImpl.SetProperty<UInt64>(__Instance, "MemoryUsage", value); }
        public ushort? ProcessorLoad{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ProcessorLoad"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ProcessorLoad", value); }
        public ushort[]? ProcessorLoadHistory{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "ProcessorLoadHistory"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "ProcessorLoadHistory", value); }
        public ushort? ReplicationHealth{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ReplicationHealth"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ReplicationHealth", value); }
        public ushort[]? ReplicationHealthEx{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "ReplicationHealthEx"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "ReplicationHealthEx", value); }
        public ushort? ReplicationMode{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ReplicationMode"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ReplicationMode", value); }
        public string[]? ReplicationProviderId{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "ReplicationProviderId"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "ReplicationProviderId", value); }
        public ushort? ReplicationState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ReplicationState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ReplicationState", value); }
        public ushort[]? ReplicationStateEx{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "ReplicationStateEx"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "ReplicationStateEx", value); }
        public bool? Shielded{ get => WmiClassImpl.GetProperty<bool>(__Instance, "Shielded"); set => WmiClassImpl.SetProperty<bool>(__Instance, "Shielded", value); }
        public ManagementBaseObject[]? Snapshots{ get => WmiClassImpl.GetProperty<ManagementBaseObject[]>(__Instance, "Snapshots"); set => WmiClassImpl.SetProperty<ManagementBaseObject[]>(__Instance, "Snapshots", value); }
        public bool? SwapFilesInUse{ get => WmiClassImpl.GetProperty<bool>(__Instance, "SwapFilesInUse"); set => WmiClassImpl.SetProperty<bool>(__Instance, "SwapFilesInUse", value); }
        public ManagementBaseObject? TestReplicaSystem{ get => WmiClassImpl.GetProperty<ManagementBaseObject>(__Instance, "TestReplicaSystem"); set => WmiClassImpl.SetProperty<ManagementBaseObject>(__Instance, "TestReplicaSystem", value); }
        public byte[]? ThumbnailImage{ get => WmiClassImpl.GetProperty<byte[]>(__Instance, "ThumbnailImage"); set => WmiClassImpl.SetProperty<byte[]>(__Instance, "ThumbnailImage", value); }
        public ushort? ThumbnailImageHeight{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ThumbnailImageHeight"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ThumbnailImageHeight", value); }
        public ushort? ThumbnailImageWidth{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "ThumbnailImageWidth"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "ThumbnailImageWidth", value); }
    }

    [WmiClassName("Msvm_SecurityElement", @"root\virtualization\v2")]
    public class IMsvm_SecurityElement : IWmiObject
    {
        public IMsvm_SecurityElement(ManagementBaseObject instance) { __Instance = instance; }

        public string? Caption{ get => WmiClassImpl.GetProperty<string>(__Instance, "Caption"); set => WmiClassImpl.SetProperty<string>(__Instance, "Caption", value); }
        public string? Description{ get => WmiClassImpl.GetProperty<string>(__Instance, "Description"); set => WmiClassImpl.SetProperty<string>(__Instance, "Description", value); }
        public string? ElementName{ get => WmiClassImpl.GetProperty<string>(__Instance, "ElementName"); set => WmiClassImpl.SetProperty<string>(__Instance, "ElementName", value); }
        public string? InstanceID{ get => WmiClassImpl.GetProperty<string>(__Instance, "InstanceID"); set => WmiClassImpl.SetProperty<string>(__Instance, "InstanceID", value); }
        public ushort? CommunicationStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "CommunicationStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "CommunicationStatus", value); }
        public ushort? DetailedStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "DetailedStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "DetailedStatus", value); }
        public ushort? HealthState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "HealthState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "HealthState", value); }
        public DateTime? InstallDate{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "InstallDate"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "InstallDate", value); }
        public string? Name{ get => WmiClassImpl.GetProperty<string>(__Instance, "Name"); set => WmiClassImpl.SetProperty<string>(__Instance, "Name", value); }
        public ushort? OperatingStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "OperatingStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "OperatingStatus", value); }
        public ushort[]? OperationalStatus{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "OperationalStatus"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "OperationalStatus", value); }
        public ushort? PrimaryStatus{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "PrimaryStatus"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "PrimaryStatus", value); }
        public string? Status{ get => WmiClassImpl.GetProperty<string>(__Instance, "Status"); set => WmiClassImpl.SetProperty<string>(__Instance, "Status", value); }
        public string[]? StatusDescriptions{ get => WmiClassImpl.GetProperty<string[]>(__Instance, "StatusDescriptions"); set => WmiClassImpl.SetProperty<string[]>(__Instance, "StatusDescriptions", value); }
        public ushort[]? AvailableRequestedStates{ get => WmiClassImpl.GetProperty<ushort[]>(__Instance, "AvailableRequestedStates"); set => WmiClassImpl.SetProperty<ushort[]>(__Instance, "AvailableRequestedStates", value); }
        public ushort? EnabledDefault{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledDefault"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledDefault", value); }
        public ushort? EnabledState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "EnabledState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "EnabledState", value); }
        public string? OtherEnabledState{ get => WmiClassImpl.GetProperty<string>(__Instance, "OtherEnabledState"); set => WmiClassImpl.SetProperty<string>(__Instance, "OtherEnabledState", value); }
        public ushort? RequestedState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "RequestedState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "RequestedState", value); }
        public DateTime? TimeOfLastStateChange{ get => WmiClassImpl.GetProperty<DateTime>(__Instance, "TimeOfLastStateChange"); set => WmiClassImpl.SetProperty<DateTime>(__Instance, "TimeOfLastStateChange", value); }
        public ushort? TransitioningToState{ get => WmiClassImpl.GetProperty<ushort>(__Instance, "TransitioningToState"); set => WmiClassImpl.SetProperty<ushort>(__Instance, "TransitioningToState", value); }
        [WmiKey] public string? CreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "CreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "CreationClassName", value); }
        public bool? EncryptStateAndVmMigrationTrafficEnabled{ get => WmiClassImpl.GetProperty<bool>(__Instance, "EncryptStateAndVmMigrationTrafficEnabled"); set => WmiClassImpl.SetProperty<bool>(__Instance, "EncryptStateAndVmMigrationTrafficEnabled", value); }
        public bool? Shielded{ get => WmiClassImpl.GetProperty<bool>(__Instance, "Shielded"); set => WmiClassImpl.SetProperty<bool>(__Instance, "Shielded", value); }
        [WmiKey] public string? SystemCreationClassName{ get => WmiClassImpl.GetProperty<string>(__Instance, "SystemCreationClassName"); set => WmiClassImpl.SetProperty<string>(__Instance, "SystemCreationClassName", value); }
        [WmiKey] public string? SystemName{ get => WmiClassImpl.GetProperty<string>(__Instance, "SystemName"); set => WmiClassImpl.SetProperty<string>(__Instance, "SystemName", value); }

        public uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ManagementBaseObject? Job)
        {
            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "RequestStateChange");
            WmiClassImpl.SetProperty<ushort>(inParams, "RequestedState", RequestedState);
            WmiClassImpl.SetProperty<DateTime>(inParams, "TimeoutPeriod", TimeoutPeriod);
            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("RequestStateChange", inParams, null!);
            Job = WmiClassImpl.GetProperty<ManagementBaseObject>(outParams, "Job");
            return WmiClassImpl.GetProperty<uint>(outParams, "ReturnValue");
        }
    }
}
