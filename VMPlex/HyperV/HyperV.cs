using System;
using Microsoft.Management.Infrastructure;
using EasyCIM;

namespace HyperV
{
    [CimClassName("Msvm_StorageAlert", @"root\virtualization\v2")]
    public interface IMsvm_StorageAlert : ICimObject
    {
        byte[]? SECURITY_DESCRIPTOR{ get; set; }
        UInt64? TIME_CREATED{ get; set; }
        string[]? CorrelatedIndications{ get; set; }
        string? IndicationFilterName{ get; set; }
        string? IndicationIdentifier{ get; set; }
        DateTime? IndicationTime{ get; set; }
        string? OtherSeverity{ get; set; }
        ushort? PerceivedSeverity{ get; set; }
        string? SequenceContext{ get; set; }
        Int64? SequenceNumber{ get; set; }
        ushort? AlertingElementFormat{ get; set; }
        string? AlertingManagedElement{ get; set; }
        ushort? AlertType{ get; set; }
        string? Description{ get; set; }
        string? EventID{ get; set; }
        DateTime? EventTime{ get; set; }
        string? Message{ get; set; }
        string[]? MessageArguments{ get; set; }
        string? MessageID{ get; set; }
        string? OtherAlertingElementFormat{ get; set; }
        string? OtherAlertType{ get; set; }
        string? OwningEntity{ get; set; }
        ushort? ProbableCause{ get; set; }
        string? ProbableCauseDescription{ get; set; }
        string? ProviderName{ get; set; }
        string[]? RecommendedActions{ get; set; }
        string? SystemCreationClassName{ get; set; }
        string? SystemName{ get; set; }
        ushort? Trending{ get; set; }
    }

    [CimClassName("Msvm_FeatureSettingData", @"root\virtualization\v2")]
    public interface IMsvm_FeatureSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchFeatureSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchFeatureSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
    }

    [CimClassName("Msvm_VirtualEthernetSwitchNicTeamingSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualEthernetSwitchNicTeamingSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? LoadBalancingAlgorithm{ get; set; }
        uint? TeamingMode{ get; set; }
    }

    [CimClassName("Msvm_VirtualEthernetSwitchBandwidthSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualEthernetSwitchBandwidthSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        UInt64? DefaultFlowReservation{ get; set; }
        UInt64? DefaultFlowWeight{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchHardwareOffloadSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchHardwareOffloadSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? DefaultQueueVmmqEnabled{ get; set; }
        uint? DefaultQueueVmmqQueuePairs{ get; set; }
        bool? DefaultQueueVrssEnabled{ get; set; }
        bool? DefaultQueueVrssExcludePrimaryProcessor{ get; set; }
        bool? DefaultQueueVrssIndependentHostSpreading{ get; set; }
        uint? DefaultQueueVrssMinQueuePairs{ get; set; }
        uint? DefaultQueueVrssQueueSchedulingMode{ get; set; }
        bool? RscOffloadEnabled{ get; set; }
        bool? SoftwareRscEnabled{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortFeatureSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortFeatureSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortTeamMappingSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortTeamMappingSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? DisableOnFailover{ get; set; }
        string? NetAdapterDeviceId{ get; set; }
        string? NetAdapterName{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortIsolationSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortIsolationSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? AllowUntaggedTraffic{ get; set; }
        uint? DefaultIsolationId{ get; set; }
        bool? EnableMultiTenantStack{ get; set; }
        uint? IsolationMode{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortVlanSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortVlanSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? AccessVlanId{ get; set; }
        ushort? NativeVlanId{ get; set; }
        uint? OperationMode{ get; set; }
        ushort? PrimaryVlanId{ get; set; }
        ushort[]? PruneVlanIdArray{ get; set; }
        uint? PvlanMode{ get; set; }
        ushort? SecondaryVlanId{ get; set; }
        ushort[]? SecondaryVlanIdArray{ get; set; }
        ushort[]? TrunkVlanIdArray{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortAclSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortAclSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        byte? AclType{ get; set; }
        byte? Action{ get; set; }
        byte? Applicability{ get; set; }
        byte? Direction{ get; set; }
        string? LocalAddress{ get; set; }
        byte? LocalAddressPrefixLength{ get; set; }
        string? Name{ get; set; }
        string? RemoteAddress{ get; set; }
        byte? RemoteAddressPrefixLength{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortRdmaSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortRdmaSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? RdmaOffloadWeight{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortBandwidthSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortBandwidthSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        UInt64? BurstLimit{ get; set; }
        UInt64? BurstSize{ get; set; }
        UInt64? Limit{ get; set; }
        UInt64? Reservation{ get; set; }
        UInt64? Weight{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortExtendedAclSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortExtendedAclSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        byte? Action{ get; set; }
        byte? Direction{ get; set; }
        ushort? IdleSessionTimeout{ get; set; }
        uint? IsolationID{ get; set; }
        string? LocalIPAddress{ get; set; }
        string? LocalPort{ get; set; }
        string? Name{ get; set; }
        string? Protocol{ get; set; }
        string? RemoteIPAddress{ get; set; }
        string? RemotePort{ get; set; }
        bool? Stateful{ get; set; }
        ushort? Weight{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortRoutingDomainSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortRoutingDomainSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint[]? IsolationIdList{ get; set; }
        string[]? IsolationIdNameList{ get; set; }
        string? RoutingDomainGuid{ get; set; }
        string? RoutingDomainName{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortProfileSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortProfileSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? CdnLabelId{ get; set; }
        string? CdnLabelString{ get; set; }
        string? NetCfgInstanceId{ get; set; }
        uint? PciBusNumber{ get; set; }
        uint? PciDeviceNumber{ get; set; }
        uint? PciFunctionNumber{ get; set; }
        uint? PciSegmentNumber{ get; set; }
        uint? ProfileData{ get; set; }
        string? ProfileId{ get; set; }
        string? ProfileName{ get; set; }
        string? VendorId{ get; set; }
        string? VendorName{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortOffloadSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortOffloadSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? IOVInterruptModeration{ get; set; }
        uint? IOVOffloadWeight{ get; set; }
        uint? IOVQueuePairsRequested{ get; set; }
        uint? IPSecOffloadLimit{ get; set; }
        uint? PacketDirectModerationCount{ get; set; }
        uint? PacketDirectModerationInterval{ get; set; }
        uint? PacketDirectNumProcs{ get; set; }
        bool? RscEnabled{ get; set; }
        bool? VmmqEnabled{ get; set; }
        uint? VmmqQueuePairs{ get; set; }
        uint? VMQOffloadWeight{ get; set; }
        bool? VrssEnabled{ get; set; }
        bool? VrssExcludePrimaryProcessor{ get; set; }
        bool? VrssIndependentHostSpreading{ get; set; }
        uint? VrssMinQueuePairs{ get; set; }
        uint? VrssQueueSchedulingMode{ get; set; }
        uint? VrssVmbusChannelAffinityPolicy{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortSecuritySettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortSecuritySettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? AllowIeeePriorityTag{ get; set; }
        bool? AllowMacSpoofing{ get; set; }
        bool? AllowTeaming{ get; set; }
        uint? DynamicIPAddressLimit{ get; set; }
        bool? EnableDhcpGuard{ get; set; }
        bool? EnableFixSpeed10G{ get; set; }
        bool? EnableRouterGuard{ get; set; }
        byte? MonitorMode{ get; set; }
        byte? MonitorSession{ get; set; }
        bool? Reserved{ get; set; }
        uint? StormLimit{ get; set; }
        string? TeamName{ get; set; }
        uint? TeamNumber{ get; set; }
        uint? VirtualSubnetId{ get; set; }
    }

    [CimClassName("Msvm_ReplicationSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ReplicationSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? AutomaticRecoveryAction{ get; set; }
        ushort? AutomaticShutdownAction{ get; set; }
        ushort? AutomaticStartupAction{ get; set; }
        DateTime? AutomaticStartupActionDelay{ get; set; }
        ushort? AutomaticStartupActionSequenceNumber{ get; set; }
        string? ConfigurationDataRoot{ get; set; }
        string? ConfigurationFile{ get; set; }
        string? ConfigurationID{ get; set; }
        DateTime? CreationTime{ get; set; }
        string? LogDataRoot{ get; set; }
        string[]? Notes{ get; set; }
        string? RecoveryFile{ get; set; }
        string? SnapshotDataRoot{ get; set; }
        string? SuspendDataRoot{ get; set; }
        string? SwapFileDataRoot{ get; set; }
        string? VirtualSystemIdentifier{ get; set; }
        string? VirtualSystemType{ get; set; }
        string? AdditionalSettings{ get; set; }
        ushort? ApplicationConsistentSnapshotInterval{ get; set; }
        ushort? AuthenticationType{ get; set; }
        bool? AutoResynchronizeEnabled{ get; set; }
        DateTime? AutoResynchronizeIntervalEnd{ get; set; }
        DateTime? AutoResynchronizeIntervalStart{ get; set; }
        bool? BypassProxyServer{ get; set; }
        string? CertificateThumbPrint{ get; set; }
        bool? CompressionEnabled{ get; set; }
        bool? EnableWriteOrderPreservationAcrossDisks{ get; set; }
        string[]? IncludedDisks{ get; set; }
        string? PrimaryConnectionPoint{ get; set; }
        string? PrimaryHostSystem{ get; set; }
        string? RecoveryConnectionPoint{ get; set; }
        ushort? RecoveryHistory{ get; set; }
        string? RecoveryHostSystem{ get; set; }
        ushort? RecoveryServerPortNumber{ get; set; }
        bool? ReplicateHostKvpItems{ get; set; }
        ushort? ReplicationInterval{ get; set; }
        string? ReplicationProvider{ get; set; }
        string? RootCertificateThumbPrint{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? AutomaticRecoveryAction{ get; set; }
        ushort? AutomaticShutdownAction{ get; set; }
        ushort? AutomaticStartupAction{ get; set; }
        DateTime? AutomaticStartupActionDelay{ get; set; }
        ushort? AutomaticStartupActionSequenceNumber{ get; set; }
        string? ConfigurationDataRoot{ get; set; }
        string? ConfigurationFile{ get; set; }
        string? ConfigurationID{ get; set; }
        DateTime? CreationTime{ get; set; }
        string? LogDataRoot{ get; set; }
        string[]? Notes{ get; set; }
        string? RecoveryFile{ get; set; }
        string? SnapshotDataRoot{ get; set; }
        string? SuspendDataRoot{ get; set; }
        string? SwapFileDataRoot{ get; set; }
        string? VirtualSystemIdentifier{ get; set; }
        string? VirtualSystemType{ get; set; }
        string? AdditionalRecoveryInformation{ get; set; }
        bool? AllowFullSCSICommandSet{ get; set; }
        bool? AllowReducedFcRedundancy{ get; set; }
        string? Architecture{ get; set; }
        ushort? AutomaticCriticalErrorAction{ get; set; }
        DateTime? AutomaticCriticalErrorActionTimeout{ get; set; }
        bool? AutomaticSnapshotsEnabled{ get; set; }
        string? BaseBoardSerialNumber{ get; set; }
        string? BIOSGUID{ get; set; }
        bool? BIOSNumLock{ get; set; }
        string? BIOSSerialNumber{ get; set; }
        ushort[]? BootOrder{ get; set; }
        bool? BootPciExpress{ get; set; }
        string? BootPciExpressInstanceFilter{ get; set; }
        string[]? BootSourceOrder{ get; set; }
        string? ChassisAssetTag{ get; set; }
        string? ChassisSerialNumber{ get; set; }
        ushort? ClusterWideNodeCapabilitiesValidationMode{ get; set; }
        ushort? ConsoleMode{ get; set; }
        uint? DebugChannelId{ get; set; }
        uint? DebugPort{ get; set; }
        ushort? DebugPortEnabled{ get; set; }
        bool? EnableHibernation{ get; set; }
        ushort? EnhancedSessionTransportType{ get; set; }
        bool? GuestControlledCacheTypes{ get; set; }
        string? GuestStateDataRoot{ get; set; }
        string? GuestStateFile{ get; set; }
        bool? GuestStateIsolationEnabled{ get; set; }
        ushort? GuestStateIsolationType{ get; set; }
        UInt64? HighMmioGapBase{ get; set; }
        UInt64? HighMmioGapSize{ get; set; }
        bool? IncrementalBackupEnabled{ get; set; }
        bool? IsAutomaticSnapshot{ get; set; }
        bool? IsSaved{ get; set; }
        bool? LockOnDisconnect{ get; set; }
        UInt64? LowMmioGapSize{ get; set; }
        ushort? NetworkBootPreferredProtocol{ get; set; }
        string[]? NumaNodeTopologyArray{ get; set; }
        string? Parent{ get; set; }
        bool? PauseAfterBootFailure{ get; set; }
        bool? SecureBootEnabled{ get; set; }
        string? SecureBootTemplateId{ get; set; }
        bool? TurnOffOnGuestRestart{ get; set; }
        ushort? UserSnapshotType{ get; set; }
        string? Version{ get; set; }
        bool? VirtualNumaEnabled{ get; set; }
        ushort? VirtualSlitType{ get; set; }
        string? VirtualSystemSubType{ get; set; }
    }

    [CimClassName("Msvm_VirtualEthernetSwitchSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualEthernetSwitchSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? AutomaticRecoveryAction{ get; set; }
        ushort? AutomaticShutdownAction{ get; set; }
        ushort? AutomaticStartupAction{ get; set; }
        DateTime? AutomaticStartupActionDelay{ get; set; }
        ushort? AutomaticStartupActionSequenceNumber{ get; set; }
        string? ConfigurationDataRoot{ get; set; }
        string? ConfigurationFile{ get; set; }
        string? ConfigurationID{ get; set; }
        DateTime? CreationTime{ get; set; }
        string? LogDataRoot{ get; set; }
        string[]? Notes{ get; set; }
        string? RecoveryFile{ get; set; }
        string? SnapshotDataRoot{ get; set; }
        string? SuspendDataRoot{ get; set; }
        string? SwapFileDataRoot{ get; set; }
        string? VirtualSystemIdentifier{ get; set; }
        string? VirtualSystemType{ get; set; }
        string[]? AssociatedResourcePool{ get; set; }
        uint? MaxNumMACAddress{ get; set; }
        string[]? VLANConnection{ get; set; }
        bool? AllowNetLbfoTeams{ get; set; }
        uint? BandwidthReservationMode{ get; set; }
        bool? BypassExtensionStack{ get; set; }
        string[]? ExtensionOrder{ get; set; }
        bool? IOVPreferred{ get; set; }
        bool? PacketDirectEnabled{ get; set; }
        string[]? RequiredExtensionIds{ get; set; }
        bool? TeamingEnabled{ get; set; }
    }

    [CimClassName("Msvm_VirtualFcSwitchSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualFcSwitchSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? AutomaticRecoveryAction{ get; set; }
        ushort? AutomaticShutdownAction{ get; set; }
        ushort? AutomaticStartupAction{ get; set; }
        DateTime? AutomaticStartupActionDelay{ get; set; }
        ushort? AutomaticStartupActionSequenceNumber{ get; set; }
        string? ConfigurationDataRoot{ get; set; }
        string? ConfigurationFile{ get; set; }
        string? ConfigurationID{ get; set; }
        DateTime? CreationTime{ get; set; }
        string? LogDataRoot{ get; set; }
        string[]? Notes{ get; set; }
        string? RecoveryFile{ get; set; }
        string? SnapshotDataRoot{ get; set; }
        string? SuspendDataRoot{ get; set; }
        string? SwapFileDataRoot{ get; set; }
        string? VirtualSystemIdentifier{ get; set; }
        string? VirtualSystemType{ get; set; }
    }

    [CimClassName("Msvm_DiskMergeSettingData", @"root\virtualization\v2")]
    public interface IMsvm_DiskMergeSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? EnabledState{ get; set; }
    }

    [CimClassName("Msvm_ResourceAllocationSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ResourceAllocationSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        string[]? VirtualSystemIdentifiers{ get; set; }
    }

    [CimClassName("Msvm_SerialPortSettingData", @"root\virtualization\v2")]
    public interface IMsvm_SerialPortSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        bool? DebuggerMode{ get; set; }
    }

    [CimClassName("Msvm_SyntheticDisplayControllerSettingData", @"root\virtualization\v2")]
    public interface IMsvm_SyntheticDisplayControllerSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? HorizontalResolution{ get; set; }
        byte? ResolutionType{ get; set; }
        ushort? VerticalResolution{ get; set; }
    }

    [CimClassName("Msvm_GuestServiceInterfaceComponentSettingData", @"root\virtualization\v2")]
    public interface IMsvm_GuestServiceInterfaceComponentSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? DefaultEnabledStatePolicy{ get; set; }
        ushort? EnabledState{ get; set; }
    }

    [CimClassName("Msvm_HeartbeatComponentSettingData", @"root\virtualization\v2")]
    public interface IMsvm_HeartbeatComponentSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? EnabledState{ get; set; }
        uint? ErrorThreshold{ get; set; }
        uint? Interval{ get; set; }
        uint? Latency{ get; set; }
    }

    [CimClassName("Msvm_KvpExchangeComponentSettingData", @"root\virtualization\v2")]
    public interface IMsvm_KvpExchangeComponentSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        bool? DisableHostKVPItems{ get; set; }
        ushort? EnabledState{ get; set; }
        string[]? HostExchangeItems{ get; set; }
        string[]? HostOnlyItems{ get; set; }
    }

    [CimClassName("Msvm_ShutdownComponentSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ShutdownComponentSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? EnabledState{ get; set; }
    }

    [CimClassName("Msvm_TimeSyncComponentSettingData", @"root\virtualization\v2")]
    public interface IMsvm_TimeSyncComponentSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? EnabledState{ get; set; }
    }

    [CimClassName("Msvm_VssComponentSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VssComponentSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? EnabledState{ get; set; }
    }

    [CimClassName("Msvm_RdvComponentSettingData", @"root\virtualization\v2")]
    public interface IMsvm_RdvComponentSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? EnabledState{ get; set; }
    }

    [CimClassName("Msvm_BatterySettingData", @"root\virtualization\v2")]
    public interface IMsvm_BatterySettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
    }

    [CimClassName("Msvm_EthernetPortAllocationSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetPortAllocationSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? DesiredVLANEndpointMode{ get; set; }
        string? OtherEndpointMode{ get; set; }
        string? CompartmentGuid{ get; set; }
        ushort? EnabledState{ get; set; }
        string? LastKnownSwitchName{ get; set; }
        string? PortName{ get; set; }
        string[]? RequiredFeatureHints{ get; set; }
        string[]? RequiredFeatures{ get; set; }
        string? TestReplicaPoolID{ get; set; }
        string? TestReplicaSwitchName{ get; set; }
    }

    [CimClassName("Msvm_SyntheticEthernetPortSettingData", @"root\virtualization\v2")]
    public interface IMsvm_SyntheticEthernetPortSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? DesiredVLANEndpointMode{ get; set; }
        string? OtherEndpointMode{ get; set; }
        bool? AllowDirectTranslatedP2P{ get; set; }
        bool? AllowPacketDirect{ get; set; }
        bool? ClusterMonitored{ get; set; }
        bool? DeviceNamingEnabled{ get; set; }
        bool? InterruptModeration{ get; set; }
        uint? MediaType{ get; set; }
        bool? NumaAwarePlacement{ get; set; }
        bool? StaticMacAddress{ get; set; }
        string[]? VirtualSystemIdentifiers{ get; set; }
    }

    [CimClassName("Msvm_EmulatedEthernetPortSettingData", @"root\virtualization\v2")]
    public interface IMsvm_EmulatedEthernetPortSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? DesiredVLANEndpointMode{ get; set; }
        string? OtherEndpointMode{ get; set; }
        bool? ClusterMonitored{ get; set; }
        bool? StaticMacAddress{ get; set; }
    }

    [CimClassName("Msvm_StorageAllocationSettingData", @"root\virtualization\v2")]
    public interface IMsvm_StorageAllocationSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        ushort? Access{ get; set; }
        string? HostExtentName{ get; set; }
        ushort? HostExtentNameFormat{ get; set; }
        ushort? HostExtentNameNamespace{ get; set; }
        UInt64? HostExtentStartingAddress{ get; set; }
        UInt64? HostResourceBlockSize{ get; set; }
        string? OtherHostExtentNameFormat{ get; set; }
        string? OtherHostExtentNameNamespace{ get; set; }
        UInt64? VirtualResourceBlockSize{ get; set; }
        ushort? CachingMode{ get; set; }
        bool? IgnoreFlushes{ get; set; }
        string? IOPSAllocationUnits{ get; set; }
        UInt64? IOPSLimit{ get; set; }
        UInt64? IOPSReservation{ get; set; }
        bool? PersistentReservationsSupported{ get; set; }
        string? SnapshotId{ get; set; }
        string? StorageQoSPolicyID{ get; set; }
        ushort? WriteHardeningMethod{ get; set; }
    }

    [CimClassName("Msvm_MemorySettingData", @"root\virtualization\v2")]
    public interface IMsvm_MemorySettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        bool? DynamicMemoryEnabled{ get; set; }
        bool? HugePagesEnabled{ get; set; }
        bool? IsVirtualized{ get; set; }
        UInt64? MaxMemoryBlocksPerNumaNode{ get; set; }
        byte? MemoryEncryptionPolicy{ get; set; }
        bool? SgxEnabled{ get; set; }
        string? SgxLaunchControlDefault{ get; set; }
        uint? SgxLaunchControlMode{ get; set; }
        UInt64? SgxSize{ get; set; }
        bool? SwapFilesInUse{ get; set; }
        uint? TargetMemoryBuffer{ get; set; }
    }

    [CimClassName("Msvm_ProcessorSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ProcessorSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        bool? AllowACountMCount{ get; set; }
        byte? ApicMode{ get; set; }
        string? CpuBrandString{ get; set; }
        string? CpuGroupId{ get; set; }
        bool? DisableSpeculationControls{ get; set; }
        bool? EnableHostResourceProtection{ get; set; }
        bool? EnableLegacyApicMode{ get; set; }
        byte? EnablePageShattering{ get; set; }
        bool? EnablePerfmonArchPmu{ get; set; }
        bool? EnablePerfmonIpt{ get; set; }
        bool? EnablePerfmonLbr{ get; set; }
        bool? EnablePerfmonPebs{ get; set; }
        bool? EnablePerfmonPmu{ get; set; }
        bool? EnableSocketTopology{ get; set; }
        string? EnlightenmentSet{ get; set; }
        bool? ExposeVirtualizationExtensions{ get; set; }
        uint? ExtendedVirtualizationExtensions{ get; set; }
        bool? HideHypervisorPresent{ get; set; }
        UInt64? HwThreadsPerCore{ get; set; }
        uint? L3CacheWays{ get; set; }
        byte? L3ProcessorDistributionPolicy{ get; set; }
        bool? LimitCPUID{ get; set; }
        bool? LimitProcessorFeatures{ get; set; }
        byte? LimitProcessorFeaturesMode{ get; set; }
        uint? MaxClusterCountPerSocket{ get; set; }
        uint? MaxHwIsolatedGuests{ get; set; }
        UInt64? MaxNumaNodesPerSocket{ get; set; }
        uint? MaxProcessorCountPerL3{ get; set; }
        UInt64? MaxProcessorsPerNumaNode{ get; set; }
        uint? PerfCpuFreqCapMhz{ get; set; }
        string? ProcessorFeatureSet{ get; set; }
    }

    [CimClassName("Msvm_PciExpressSettingData", @"root\virtualization\v2")]
    public interface IMsvm_PciExpressSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        bool[]? AllowDirectTranslatedP2P{ get; set; }
        bool? NumaAwarePlacement{ get; set; }
        byte? TargetVtl{ get; set; }
        ushort[]? VirtualFunctions{ get; set; }
        string[]? VirtualSystemIdentifiers{ get; set; }
    }

    [CimClassName("Msvm_GpuPartitionSettingData", @"root\virtualization\v2")]
    public interface IMsvm_GpuPartitionSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        UInt64? MaxPartitionCompute{ get; set; }
        UInt64? MaxPartitionDecode{ get; set; }
        UInt64? MaxPartitionEncode{ get; set; }
        UInt64? MaxPartitionVRAM{ get; set; }
        UInt64? MinPartitionCompute{ get; set; }
        UInt64? MinPartitionDecode{ get; set; }
        UInt64? MinPartitionEncode{ get; set; }
        UInt64? MinPartitionVRAM{ get; set; }
        bool? NumaAwarePlacement{ get; set; }
        UInt64? OptimalPartitionCompute{ get; set; }
        UInt64? OptimalPartitionDecode{ get; set; }
        UInt64? OptimalPartitionEncode{ get; set; }
        UInt64? OptimalPartitionVRAM{ get; set; }
        string[]? VirtualSystemIdentifiers{ get; set; }
    }

    [CimClassName("Msvm_VirtualLogicalUnitSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualLogicalUnitSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        string? StorageSubsystemType{ get; set; }
    }

    [CimClassName("Msvm_Synthetic3DDisplayControllerSettingData", @"root\virtualization\v2")]
    public interface IMsvm_Synthetic3DDisplayControllerSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        byte? MaximumMonitors{ get; set; }
        byte? MaximumScreenResolution{ get; set; }
        UInt64? VRAMSizeBytes{ get; set; }
    }

    [CimClassName("Msvm_FcPortAllocationSettingData", @"root\virtualization\v2")]
    public interface IMsvm_FcPortAllocationSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
    }

    [CimClassName("Msvm_FlexIoDeviceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_FlexIoDeviceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        string[]? EmulatorConfiguration{ get; set; }
        string? EmulatorId{ get; set; }
        ushort? PhysicalNumaNode{ get; set; }
        string[]? VirtualSystemIdentifiers{ get; set; }
    }

    [CimClassName("Msvm_SyntheticFcPortSettingData", @"root\virtualization\v2")]
    public interface IMsvm_SyntheticFcPortSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? Address{ get; set; }
        string? AddressOnParent{ get; set; }
        string? AllocationUnits{ get; set; }
        bool? AutomaticAllocation{ get; set; }
        bool? AutomaticDeallocation{ get; set; }
        string[]? Connection{ get; set; }
        ushort? ConsumerVisibility{ get; set; }
        string[]? HostResource{ get; set; }
        UInt64? Limit{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string? OtherResourceType{ get; set; }
        string? Parent{ get; set; }
        string? PoolID{ get; set; }
        UInt64? Reservation{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        UInt64? VirtualQuantity{ get; set; }
        string? VirtualQuantityUnits{ get; set; }
        uint? Weight{ get; set; }
        bool? ChapEnabled{ get; set; }
        string? SecondaryWWNN{ get; set; }
        string? SecondaryWWPN{ get; set; }
        string? VirtualPortWWNN{ get; set; }
        string? VirtualPortWWPN{ get; set; }
        string[]? VirtualSystemIdentifiers{ get; set; }
    }

    [CimClassName("Msvm_BootSourceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_BootSourceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? BootSourceDescription{ get; set; }
        uint? BootSourceType{ get; set; }
        string? FirmwareDevicePath{ get; set; }
        byte[]? OptionalData{ get; set; }
        string? OtherLocation{ get; set; }
    }

    [CimClassName("Msvm_TerminalServiceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_TerminalServiceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string[]? AllowedHashAlgorithms{ get; set; }
        byte[]? AuthCertificateHash{ get; set; }
        bool? DisableSelfSignedCertificateGeneration{ get; set; }
        uint? ListenerPort{ get; set; }
        string[]? TrustedIssuerCertificateHashes{ get; set; }
    }

    [CimClassName("Msvm_CopyFileToGuestSettingData", @"root\virtualization\v2")]
    public interface IMsvm_CopyFileToGuestSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? CreateFullPath{ get; set; }
        string? DestinationPath{ get; set; }
        bool? OverwriteExisting{ get; set; }
        string? SourcePath{ get; set; }
    }

    [CimClassName("Msvm_SecuritySettingData", @"root\virtualization\v2")]
    public interface IMsvm_SecuritySettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? AppContainerLaunchOptOut{ get; set; }
        bool? BindToHostTpm{ get; set; }
        bool? DataProtectionRequested{ get; set; }
        bool? EncryptStateAndVmMigrationTraffic{ get; set; }
        bool? KsdEnabled{ get; set; }
        bool? ShieldingRequested{ get; set; }
        bool? TpmEnabled{ get; set; }
        bool? VirtualizationBasedSecurityOptOut{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemUpgradeSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemUpgradeSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? TargetVersion{ get; set; }
    }

    [CimClassName("Msvm_SystemComponentSettingData", @"root\virtualization\v2")]
    public interface IMsvm_SystemComponentSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
    }

    [CimClassName("Msvm_StorageSettingData", @"root\virtualization\v2")]
    public interface IMsvm_StorageSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? DisableInterruptBatching{ get; set; }
        ushort? ThreadCountPerChannel{ get; set; }
        ushort? VirtualProcessorsPerChannel{ get; set; }
    }

    [CimClassName("Msvm_MetricServiceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_MetricServiceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        DateTime? MetricsFlushInterval{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemExportSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemExportSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        byte? BackupIntent{ get; set; }
        byte? CaptureLiveState{ get; set; }
        byte? CopySnapshotConfiguration{ get; set; }
        bool? CopyVmRuntimeInformation{ get; set; }
        bool? CopyVmStorage{ get; set; }
        bool? CreateVmExportSubdirectory{ get; set; }
        string? DifferentialBackupBase{ get; set; }
        bool? DisableDifferentialOfIgnoredStorage{ get; set; }
        string[]? ExcludedVirtualHardDisks{ get; set; }
        bool? ExportForLiveMigration{ get; set; }
        string? GuestDebugStateFilePath{ get; set; }
        string? SnapshotVirtualSystem{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemMigrationServiceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemMigrationServiceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? AuthenticationType{ get; set; }
        bool? EnableCompression{ get; set; }
        bool? EnableSmbTransport{ get; set; }
        bool? EnableVirtualSystemMigration{ get; set; }
        uint? MaximumActiveStorageMigration{ get; set; }
        uint? MaximumActiveVirtualSystemMigration{ get; set; }
    }

    [CimClassName("Msvm_FailoverNetworkAdapterSettingData", @"root\virtualization\v2")]
    public interface IMsvm_FailoverNetworkAdapterSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string[]? DefaultGateways{ get; set; }
        bool? DHCPEnabled{ get; set; }
        string[]? DNSServers{ get; set; }
        string[]? IPAddresses{ get; set; }
        ushort? ProtocolIFType{ get; set; }
        string[]? Subnets{ get; set; }
    }

    [CimClassName("Msvm_CollectionReferencePointSettingData", @"root\virtualization\v2")]
    public interface IMsvm_CollectionReferencePointSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        byte? ConsistencyLevel{ get; set; }
    }

    [CimClassName("Msvm_CollectionSettingData", @"root\virtualization\v2")]
    public interface IMsvm_CollectionSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
    }

    [CimClassName("Msvm_CollectionSnapshotExportSettingData", @"root\virtualization\v2")]
    public interface IMsvm_CollectionSnapshotExportSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? BackupIntent{ get; set; }
        bool? CopyVmStorage{ get; set; }
        string? DifferentialBackupBase{ get; set; }
    }

    [CimClassName("Msvm_AssignableDeviceDismountSettingData", @"root\virtualization\v2")]
    public interface IMsvm_AssignableDeviceDismountSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? DeviceInstancePath{ get; set; }
        string? DeviceLocationPath{ get; set; }
        bool? RequireAcsSupport{ get; set; }
        bool? RequireDeviceMitigations{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemMigrationSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemMigrationSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? Bandwidth{ get; set; }
        string? BandwidthUnit{ get; set; }
        ushort? MigrationType{ get; set; }
        string? OtherTransportType{ get; set; }
        ushort? Priority{ get; set; }
        ushort? TransportType{ get; set; }
        bool? AllowOverwriteExistingFile{ get; set; }
        bool? AvoidRemovingVHDs{ get; set; }
        bool? CancelIfBlackoutThresholdExceeded{ get; set; }
        ushort? CPUCappingMagnitude{ get; set; }
        string[]? DestinationIPAddressList{ get; set; }
        string? DestinationPlannedVirtualSystemId{ get; set; }
        bool? EnableCompression{ get; set; }
        bool? EnableVhdCompression{ get; set; }
        bool? RemoveSourceUnmanagedVhds{ get; set; }
        bool? RetainVhdCopiesOnSource{ get; set; }
        string[]? UnmanagedVhds{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemManagementServiceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemManagementServiceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? BiosLockString{ get; set; }
        string? CurrentWWNNAddress{ get; set; }
        string? DefaultExternalDataRoot{ get; set; }
        ushort? DefaultVirtualHardDiskCachingMode{ get; set; }
        string? DefaultVirtualHardDiskPath{ get; set; }
        bool? EnhancedSessionModeEnabled{ get; set; }
        uint? HbaLunTimeout{ get; set; }
        bool? HypervisorRootSchedulerEnabled{ get; set; }
        string? MaximumMacAddress{ get; set; }
        string? MaximumWWPNAddress{ get; set; }
        string? MinimumMacAddress{ get; set; }
        string? MinimumWWPNAddress{ get; set; }
        bool? NumaSpanningEnabled{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
    }

    [CimClassName("Msvm_AbstractResourcePoolSettingData", @"root\virtualization\v2")]
    public interface IMsvm_AbstractResourcePoolSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? LoadBalancingBehavior{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string[]? MappingOrder{ get; set; }
        string? Notes{ get; set; }
        string? OtherResourceType{ get; set; }
        string? PoolID{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
    }

    [CimClassName("Msvm_ResourcePoolSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ResourcePoolSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? LoadBalancingBehavior{ get; set; }
        ushort? MappingBehavior{ get; set; }
        string[]? MappingOrder{ get; set; }
        string? Notes{ get; set; }
        string? OtherResourceType{ get; set; }
        string? PoolID{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemReferencePointExportSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemReferencePointExportSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? BaseReferencePoint{ get; set; }
        string[]? DisksToExport{ get; set; }
    }

    [CimClassName("Msvm_VirtualHardDiskSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualHardDiskSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? BlockSize{ get; set; }
        UInt64? DataAlignment{ get; set; }
        ushort? Format{ get; set; }
        bool? IsPmemCompatible{ get; set; }
        uint? LogicalSectorSize{ get; set; }
        UInt64? MaxInternalSize{ get; set; }
        string? ParentIdentifier{ get; set; }
        string? ParentPath{ get; set; }
        DateTime? ParentTimestamp{ get; set; }
        string? Path{ get; set; }
        uint? PhysicalSectorSize{ get; set; }
        ushort? PmemAddressAbstractionType{ get; set; }
        ushort? Type{ get; set; }
        string? VirtualDiskId{ get; set; }
    }

    [CimClassName("Msvm_ReplicationAuthorizationSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ReplicationAuthorizationSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? AllowedPrimaryHostSystem{ get; set; }
        string? ReplicaStorageLocation{ get; set; }
        string? TrustGroup{ get; set; }
    }

    [CimClassName("Msvm_Synthetic3DServiceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_Synthetic3DServiceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? GPUOvercommitEnabled{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemMigrationNetworkSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemMigrationNetworkSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? Metric{ get; set; }
        byte? PrefixLength{ get; set; }
        string? SubnetNumber{ get; set; }
        string[]? Tags{ get; set; }
    }

    [CimClassName("Msvm_GuestCommunicationServiceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_GuestCommunicationServiceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? EnabledStatePolicy{ get; set; }
        string? Name{ get; set; }
    }

    [CimClassName("Msvm_NetworkConnectionDiagnosticSettingData", @"root\virtualization\v2")]
    public interface IMsvm_NetworkConnectionDiagnosticSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint? IsolationId{ get; set; }
        bool? IsSender{ get; set; }
        uint? PayloadSize{ get; set; }
        string? ReceiverIP{ get; set; }
        string? ReceiverMac{ get; set; }
        string? SenderIP{ get; set; }
        uint? SequenceNumber{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemReferencePointSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemReferencePointSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        byte? ConsistencyLevel{ get; set; }
    }

    [CimClassName("Msvm_CollectionReferencePointExportSettingData", @"root\virtualization\v2")]
    public interface IMsvm_CollectionReferencePointExportSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? BaseReferencePointCollection{ get; set; }
        string[]? VirtualMachinesToDisksToExport{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemSnapshotSettingData", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemSnapshotSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        byte? ConsistencyLevel{ get; set; }
        byte? GuestBackupType{ get; set; }
        bool? IgnoreNonSnapshottableDisks{ get; set; }
    }

    [CimClassName("Msvm_ReplicationServiceSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ReplicationServiceSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? AllowedAuthenticationType{ get; set; }
        string? CertificateThumbPrint{ get; set; }
        ushort? HttpPort{ get; set; }
        ushort? HttpsPort{ get; set; }
        uint? MonitoringInterval{ get; set; }
        DateTime? MonitoringStartTime{ get; set; }
        bool? RecoveryServerEnabled{ get; set; }
    }

    [CimClassName("Msvm_EthernetPortData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetPortData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceCreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        [CimKey] string? Name{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortOffloadData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortOffloadData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceCreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        [CimKey] string? Name{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        uint? IovOffloadUsage{ get; set; }
        uint? IovQueuePairUsage{ get; set; }
        bool? IovVfDataPathActive{ get; set; }
        ushort? IovVfId{ get; set; }
        uint? IpsecCurrentOffloadSaCount{ get; set; }
        bool? RscEnabled{ get; set; }
        bool? VmmqEnabled{ get; set; }
        uint? VmmqQueuePairs{ get; set; }
        uint? VMQId{ get; set; }
        uint? VMQOffloadUsage{ get; set; }
        bool? VrssEnabled{ get; set; }
        bool? VrssExcludePrimaryProcessor{ get; set; }
        bool? VrssIndependentHostSpreading{ get; set; }
        uint? VrssMinQueuePairs{ get; set; }
        uint? VrssQueueSchedulingMode{ get; set; }
        uint? VrssVmbusChannelAffinityPolicy{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchPortBandwidthData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPortBandwidthData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceCreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        [CimKey] string? Name{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        uint? CurrentBandwidthReservationPercentage{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? Name{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchOperationalData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchOperationalData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? Name{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        uint? CurrentSwitchingMode{ get; set; }
        uint[]? SupportedSwitchingModes{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchHardwareOffloadData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchHardwareOffloadData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? Name{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        bool? DefaultQueueVmmqEnabled{ get; set; }
        uint? DefaultQueueVmmqQueuePairs{ get; set; }
        bool? DefaultQueueVrssEnabled{ get; set; }
        bool? DefaultQueueVrssExcludePrimaryProcessor{ get; set; }
        bool? DefaultQueueVrssIndependentHostSpreading{ get; set; }
        uint? DefaultQueueVrssMinQueuePairs{ get; set; }
        uint? DefaultQueueVrssQueueSchedulingMode{ get; set; }
        uint? IovQueuePairCapacity{ get; set; }
        uint? IovQueuePairUsage{ get; set; }
        uint? IovVfCapacity{ get; set; }
        uint? IovVfUsage{ get; set; }
        uint? IPsecSACapacity{ get; set; }
        uint? IPsecSAUsage{ get; set; }
        bool? PacketDirectInUse{ get; set; }
        uint? VmqCapacity{ get; set; }
        uint? VmqUsage{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchBandwidthData", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchBandwidthData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? Name{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? Capacity{ get; set; }
        UInt64? DefaultFlowReservation{ get; set; }
        uint? DefaultFlowReservationPercentage{ get; set; }
        UInt64? DefaultFlowWeight{ get; set; }
        UInt64? Reservation{ get; set; }
    }

    [CimClassName("Msvm_ComputerSystem", @"root\virtualization\v2")]
    public interface IMsvm_ComputerSystem : ICimObject
    {
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

        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        SystemState? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        string? NameFormat{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        string[]? Roles{ get; set; }
        ushort[]? Dedicated{ get; set; }
        string[]? OtherDedicatedDescriptions{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        ushort? ResetCapability{ get; set; }
        EnhancedSessionMode? EnhancedSessionModeState{ get; set; }
        ushort? FailedOverReplicationType{ get; set; }
        uint? HwThreadsPerCoreRealized{ get; set; }
        DateTime? LastApplicationConsistentReplicationTime{ get; set; }
        DateTime? LastReplicationTime{ get; set; }
        ushort? LastReplicationType{ get; set; }
        DateTime? LastSuccessfulBackupTime{ get; set; }
        ushort? NumberOfNumaNodes{ get; set; }
        UInt64? OnTimeInMilliseconds{ get; set; }
        uint? ProcessID{ get; set; }
        ushort? ReplicationHealth{ get; set; }
        ushort? ReplicationMode{ get; set; }
        ushort? ReplicationState{ get; set; }
        DateTime? TimeOfLastConfigurationChange{ get; set; }

        uint RequestStateChange(ushort RequestedState, out ICIM_ConcreteJob? Job);
        uint RequestReplicationStateChange(ushort RequestedState, out ICIM_ConcreteJob? Job);
        uint InjectNonMaskableInterrupt(out ICIM_ConcreteJob? Job);
        uint RequestReplicationStateChangeEx(string ReplicationRelationship, ushort RequestedState, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_PlannedComputerSystem", @"root\virtualization\v2")]
    public interface IMsvm_PlannedComputerSystem : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        string? NameFormat{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        string[]? Roles{ get; set; }
        ushort[]? Dedicated{ get; set; }
        string[]? OtherDedicatedDescriptions{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        ushort? ResetCapability{ get; set; }
        ushort[]? AssignedNumaNodeList{ get; set; }
        UInt64? OnTimeInMilliseconds{ get; set; }
        uint? ProcessID{ get; set; }
        DateTime? TimeOfLastConfigurationChange{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(uint PowerState, DateTime Time);
    }

    [CimClassName("Msvm_VirtualEthernetSwitch", @"root\virtualization\v2")]
    public interface IMsvm_VirtualEthernetSwitch : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        string? NameFormat{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        string[]? Roles{ get; set; }
        ushort[]? Dedicated{ get; set; }
        string[]? OtherDedicatedDescriptions{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        ushort? ResetCapability{ get; set; }
        uint? MaxIOVOffloads{ get; set; }
        uint? MaxVMQOffloads{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(uint PowerState, DateTime Time);
    }

    [CimClassName("Msvm_VirtualFcSwitch", @"root\virtualization\v2")]
    public interface IMsvm_VirtualFcSwitch : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        string? NameFormat{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        string[]? Roles{ get; set; }
        ushort[]? Dedicated{ get; set; }
        string[]? OtherDedicatedDescriptions{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        ushort? ResetCapability{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(uint PowerState, DateTime Time);
    }

    [CimClassName("Msvm_PartitionableGpu", @"root\virtualization\v2")]
    public interface IMsvm_PartitionableGpu : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        string? NameFormat{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        string[]? Roles{ get; set; }
        ushort[]? Dedicated{ get; set; }
        string[]? OtherDedicatedDescriptions{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        ushort? ResetCapability{ get; set; }
        UInt64? AvailableCompute{ get; set; }
        UInt64? AvailableDecode{ get; set; }
        UInt64? AvailableEncode{ get; set; }
        UInt64? AvailableVRAM{ get; set; }
        UInt64? MaxPartitionCompute{ get; set; }
        UInt64? MaxPartitionDecode{ get; set; }
        UInt64? MaxPartitionEncode{ get; set; }
        UInt64? MaxPartitionVRAM{ get; set; }
        UInt64? MinPartitionCompute{ get; set; }
        UInt64? MinPartitionDecode{ get; set; }
        UInt64? MinPartitionEncode{ get; set; }
        UInt64? MinPartitionVRAM{ get; set; }
        UInt64? OptimalPartitionCompute{ get; set; }
        UInt64? OptimalPartitionDecode{ get; set; }
        UInt64? OptimalPartitionEncode{ get; set; }
        UInt64? OptimalPartitionVRAM{ get; set; }
        ushort? PartitionCount{ get; set; }
        UInt64? TotalCompute{ get; set; }
        UInt64? TotalDecode{ get; set; }
        UInt64? TotalEncode{ get; set; }
        UInt64? TotalVRAM{ get; set; }
        ushort[]? ValidPartitionCounts{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(uint PowerState, DateTime Time);
    }

    [CimClassName("Msvm_AssignableDeviceService", @"root\virtualization\v2")]
    public interface IMsvm_AssignableDeviceService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint DismountAssignableDevice(string DismountSettingData, out string? DismountedDeviceInstancePath, out ICIM_ConcreteJob? Job);
        uint MountAssignableDevice(string DeviceInstancePath, string DeviceLocationPath, out ICIM_ConcreteJob? Job, out string? MountedDeviceInstancePath);
    }

    [CimClassName("Msvm_VirtualSystemManagementService", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemManagementService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint AddResourceSettings(ICIM_VirtualSystemSettingData AffectedConfiguration, string[] ResourceSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingResourceSettings);
        uint DefineSystem(ICIM_VirtualSystemSettingData ReferenceConfiguration, string[] ResourceSettings, string SystemSettings, out ICIM_ConcreteJob? Job, out ICIM_ComputerSystem? ResultingSystem);
        uint DestroySystem(ICIM_ComputerSystem AffectedSystem, out ICIM_ConcreteJob? Job);
        uint ModifyResourceSettings(string[] ResourceSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingResourceSettings);
        uint ModifySystemSettings(string SystemSettings, out ICIM_ConcreteJob? Job);
        uint RemoveResourceSettings(CimInstance[] ResourceSettings, out ICIM_ConcreteJob? Job);
        uint DefinePlannedSystem(ICIM_VirtualSystemSettingData ReferenceConfiguration, string[] ResourceSettings, string SystemSettings, out ICIM_ConcreteJob? Job, out ICIM_ComputerSystem? ResultingSystem);
        uint ValidatePlannedSystem(IMsvm_PlannedComputerSystem PlannedSystem, out ICIM_ConcreteJob? Job);
        uint UpgradeSystemVersion(ICIM_ComputerSystem ComputerSystem, string UpgradeSettingData, out ICIM_ConcreteJob? Job);
        uint ImportSystemDefinition(bool GenerateNewSystemIdentifier, string SnapshotFolder, string SystemDefinitionFile, out IMsvm_PlannedComputerSystem? ImportedSystem, out ICIM_ConcreteJob? Job);
        uint ImportSnapshotDefinitions(IMsvm_PlannedComputerSystem PlannedSystem, string SnapshotFolder, out CimInstance[]? ImportedSnapshots, out ICIM_ConcreteJob? Job);
        uint RealizePlannedSystem(IMsvm_PlannedComputerSystem PlannedSystem, out ICIM_ConcreteJob? Job, out ICIM_ComputerSystem? ResultingSystem);
        uint ExportSystemDefinition(ICIM_ComputerSystem ComputerSystem, string ExportDirectory, string ExportSettingData, out ICIM_ConcreteJob? Job);
        uint AddFeatureSettings(IMsvm_EthernetPortAllocationSettingData AffectedConfiguration, string[] FeatureSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingFeatureSettings);
        uint ModifyFeatureSettings(string[] FeatureSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingFeatureSettings);
        uint RemoveFeatureSettings(CimInstance[] FeatureSettings, out ICIM_ConcreteJob? Job);
        uint AddBootSourceSettings(ICIM_VirtualSystemSettingData AffectedConfiguration, string[] BootSourceSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingBootSourceSettings);
        uint AddGuestServiceSettings(ICIM_VirtualSystemSettingData AffectedConfiguration, string[] GuestServiceSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingGuestServiceSettings);
        uint ModifyGuestServiceSettings(string[] GuestServiceSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingGuestServiceSettings);
        uint RemoveBootSourceSettings(CimInstance[] BootSourceSettings, out ICIM_ConcreteJob? Job);
        uint RemoveGuestServiceSettings(CimInstance[] GuestServiceSettings, out ICIM_ConcreteJob? Job);
        uint GetVirtualSystemThumbnailImage(ushort HeightPixels, ICIM_VirtualSystemSettingData TargetSystem, ushort WidthPixels, out byte[]? ImageData);
        uint ModifyServiceSettings(string SettingData, out ICIM_ConcreteJob? Job);
        uint GetSummaryInformation(uint[] RequestedInformation, IMsvm_VirtualSystemSettingData[] SettingData, out IMsvm_SummaryInformation[]? SummaryInformation);
        uint GetDefinitionFileSummaryInformation(string[] DefinitionFiles, out CimInstance[]? SummaryInformation);
        uint AddKvpItems(string[] DataItems, ICIM_ComputerSystem TargetSystem, out ICIM_ConcreteJob? Job);
        uint ModifyKvpItems(string[] DataItems, ICIM_ComputerSystem TargetSystem, out ICIM_ConcreteJob? Job);
        uint RemoveKvpItems(string[] DataItems, ICIM_ComputerSystem TargetSystem, out ICIM_ConcreteJob? Job);
        uint FormatError(string[] Errors, out string? ErrorMessage);
        uint ModifyDiskMergeSettings(string SettingData, out ICIM_ConcreteJob? Job);
        uint GenerateWwpn(uint NumberOfWwpns, out string[]? GeneratedWwpn);
        uint AddFibreChannelChap(string[] FcPortSettings, byte SecretEncoding, byte[] SharedSecret);
        uint RemoveFibreChannelChap(string[] FcPortSettings);
        uint SetGuestNetworkAdapterConfiguration(ICIM_ComputerSystem ComputerSystem, string[] NetworkConfiguration, out ICIM_ConcreteJob? Job);
        uint GetSizeOfSystemFiles(ICIM_VirtualSystemSettingData Vssd, out UInt64? Size);
        uint GetCurrentWwpnFromGenerator(out string? CurrentWwpn);
        uint TestNetworkConnection(uint IsolationId, bool IsSender, string ReceiverIP, string ReceiverMac, string SenderIP, uint SequenceNumber, IMsvm_EthernetPortAllocationSettingData TargetNetworkAdapter, out ICIM_ConcreteJob? Job, out uint? RoundTripTime);
        uint DiagnoseNetworkConnection(string DiagnosticSettings, IMsvm_EthernetPortAllocationSettingData TargetNetworkAdapter, out string? DiagnosticInformation, out ICIM_ConcreteJob? Job);
        uint SetInitialMachineConfigurationData(byte[] ImcData, ICIM_ComputerSystem TargetSystem, out ICIM_ConcreteJob? Job);
        uint AddSystemComponentSettings(IMsvm_VirtualSystemSettingData AffectedConfiguration, string[] ComponentSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingComponentSettings);
        uint ModifySystemComponentSettings(string[] ComponentSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingComponentSettings);
        uint RemoveSystemComponentSettings(CimInstance[] ComponentSettings, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_VirtualEthernetSwitchManagementService", @"root\virtualization\v2")]
    public interface IMsvm_VirtualEthernetSwitchManagementService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint AddResourceSettings(ICIM_VirtualSystemSettingData AffectedConfiguration, string[] ResourceSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingResourceSettings);
        uint DefineSystem(ICIM_VirtualSystemSettingData ReferenceConfiguration, string[] ResourceSettings, string SystemSettings, out ICIM_ConcreteJob? Job, out ICIM_ComputerSystem? ResultingSystem);
        uint DestroySystem(ICIM_ComputerSystem AffectedSystem, out ICIM_ConcreteJob? Job);
        uint ModifyResourceSettings(string[] ResourceSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingResourceSettings);
        uint ModifySystemSettings(string SystemSettings, out ICIM_ConcreteJob? Job);
        uint RemoveResourceSettings(CimInstance[] ResourceSettings, out ICIM_ConcreteJob? Job);
        uint AddFeatureSettings(ICIM_SettingData AffectedConfiguration, string[] FeatureSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingFeatureSettings);
        uint ModifyFeatureSettings(string[] FeatureSettings, out ICIM_ConcreteJob? Job, out CimInstance[]? ResultingFeatureSettings);
        uint RemoveFeatureSettings(CimInstance[] FeatureSettings, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_CollectionReferencePointService", @"root\virtualization\v2")]
    public interface IMsvm_CollectionReferencePointService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint CreateReferencePoint(IMsvm_VirtualSystemCollection Collection, string ReferencePointSettings, ushort ReferencePointType, out ICIM_Collection? ResultingReferencePointCollection, out ICIM_ConcreteJob? Job);
        uint DestroyReferencePoint(ICIM_Collection AffectedReferencePointCollection, out ICIM_ConcreteJob? Job);
        uint RemoveAssociatedData(ICIM_Collection AffectedReferencePointCollection, out ICIM_ConcreteJob? Job);
        uint ExportReferencePoint(string ExportDirectory, string ExportSettingData, ICIM_Collection ReferencePointCollection, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_VirtualSystemReferencePointService", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemReferencePointService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint CreateReferencePoint(IMsvm_ComputerSystem AffectedSystem, string ReferencePointSettings, ushort ReferencePointType, out IMsvm_VirtualSystemReferencePoint? ResultingReferencePoint, out ICIM_ConcreteJob? Job);
        uint ExportReferencePoint(string ExportDirectory, string ExportSettingData, IMsvm_VirtualSystemReferencePoint ReferencePoint, out ICIM_ConcreteJob? Job);
        uint DestroyReferencePoint(IMsvm_VirtualSystemReferencePoint AffectedReferencePoint, out ICIM_ConcreteJob? Job);
        uint RemoveAssociatedData(IMsvm_VirtualSystemReferencePoint AffectedReferencePoint, out ICIM_ConcreteJob? Job);
        uint ImportReferencePointMetadata(IMsvm_ComputerSystem AffectedSystem, string ConfigFilePath, string RuntimeStateFilePath, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_TransparentBridgingService", @"root\virtualization\v2")]
    public interface IMsvm_TransparentBridgingService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        string[]? Keywords{ get; set; }
        string? ServiceURL{ get; set; }
        string[]? StartupConditions{ get; set; }
        string[]? StartupParameters{ get; set; }
        string? OtherProtocolType{ get; set; }
        ushort? ProtocolType{ get; set; }
        uint? AgingTime{ get; set; }
        uint? FID{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
    }

    [CimClassName("Msvm_GuestService", @"root\virtualization\v2")]
    public interface IMsvm_GuestService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
    }

    [CimClassName("Msvm_VssService", @"root\virtualization\v2")]
    public interface IMsvm_VssService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint QueryGuestClusterInformation(out ICimObject? GuestClusterInformation);
    }

    [CimClassName("Msvm_GuestFileService", @"root\virtualization\v2")]
    public interface IMsvm_GuestFileService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint CopyFilesToGuest(string[] CopyFileToGuestSettings, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_GuestCommunicationService", @"root\virtualization\v2")]
    public interface IMsvm_GuestCommunicationService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
    }

    [CimClassName("Msvm_VirtualSystemMigrationService", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemMigrationService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        uint? ActiveStorageMigrationCount{ get; set; }
        uint? ActiveVirtualSystemMigrationCount{ get; set; }
        string[]? MigrationServiceListenerIPAddressList{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint MigrateVirtualSystemToHost(ICIM_ComputerSystem ComputerSystem, string DestinationHost, string MigrationSettingData, string[] NewResourceSettingData, string NewSystemSettingData, out ICIM_ConcreteJob? Job);
        uint MigrateVirtualSystemToSystem(ICIM_ComputerSystem ComputerSystem, ICIM_System DestinationSystem, string MigrationSettingData, string[] NewResourceSettingData, string NewSystemSettingData, out ICIM_ConcreteJob? Job, out ICIM_ComputerSystem? NewComputerSystem);
        uint CheckVirtualSystemIsMigratableToHost(ICIM_ComputerSystem ComputerSystem, string DestinationHost, string MigrationSettingData, string[] NewResourceSettingData, string NewSystemSettingData, out bool? IsMigratable);
        uint CheckVirtualSystemIsMigratableToSystem(ICIM_ComputerSystem ComputerSystem, ICIM_System DestinationSystem, string MigrationSettingData, string[] NewResourceSettingData, string NewSystemSettingData, out bool? IsMigratable);
        uint CheckVirtualSystemIsMigratable(ICIM_ComputerSystem ComputerSystem, string DestinationHost, string MigrationSettingData, string[] NewResourceSettingData, string NewSystemSettingData, out ICIM_ConcreteJob? Job);
        uint ModifyServiceSettings(string ServiceSettingData, out ICIM_ConcreteJob? Job);
        uint AddNetworkSettings(string[] NetworkSettings, out ICIM_ConcreteJob? Job);
        uint RemoveNetworkSettings(CimInstance[] NetworkSettings, out ICIM_ConcreteJob? Job);
        uint ModifyNetworkSettings(string[] NetworkSettings, out ICIM_ConcreteJob? Job);
        uint GetSystemCompatibilityInfo(ICIM_ComputerSystem ComputerSystem, out byte[]? CompatibilityInfo);
        uint CheckSystemCompatibilityInfo(byte[] CompatibilityInfo, out string[]? Reasons);
        uint GetSystemCompatibilityVectors(ICIM_ComputerSystem ComputerSystem, out CimInstance[]? CompatibilityVectors);
        uint GetProcessorFeatureLimits(string Options, out CimInstance[]? CompatibilityVectors);
    }

    [CimClassName("Msvm_CollectionSnapshotService", @"root\virtualization\v2")]
    public interface IMsvm_CollectionSnapshotService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint CreateSnapshot(ICIM_CollectionOfMSEs Collection, out ICIM_Collection? ResultingSnapshotCollection, string SnapshotSettings, ushort SnapshotType, out ICIM_ConcreteJob? Job);
        uint DestroySnapshot(ICIM_Collection AffectedSnapshotCollection, out ICIM_ConcreteJob? Job);
        uint ExportSnapshot(string ExportDirectory, string ExportSettingData, ICIM_Collection SnapshotCollection, out ICIM_ConcreteJob? Job);
        uint ApplySnapshot(ICIM_Collection SnapshotCollection, out ICIM_ConcreteJob? Job);
        uint ConvertToReferencePoint(IMsvm_SnapshotCollection AffectedSnapshotCollection, out IMsvm_ReferencePointCollection? ResultingReferencePointCollection, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_ResourcePoolConfigurationService", @"root\virtualization\v2")]
    public interface IMsvm_ResourcePoolConfigurationService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint CreatePool(string[] AllocationSettings, CimInstance[] ParentPools, string PoolSettings, out ICIM_ConcreteJob? Job, out ICIM_ResourcePool? Pool);
        uint ModifyPoolResources(string[] AllocationSettings, ICIM_ResourcePool ChildPool, CimInstance[] ParentPools, out ICIM_ConcreteJob? Job);
        uint ModifyPoolSettings(ICIM_ResourcePool ChildPool, string PoolSettings, out ICIM_ConcreteJob? Job);
        uint DeletePool(ICIM_ResourcePool Pool, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_Synthetic3DService", @"root\virtualization\v2")]
    public interface IMsvm_Synthetic3DService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint EnableGPUForVirtualization(IMsvm_Physical3dGraphicsProcessor PhysicalGPU, out ICIM_ConcreteJob? Job);
        uint DisableGPUForVirtualization(IMsvm_Physical3dGraphicsProcessor PhysicalGPU, out ICIM_ConcreteJob? Job);
        uint ModifyServiceSettings(string SettingData, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_ReplicationService", @"root\virtualization\v2")]
    public interface IMsvm_ReplicationService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint ModifyServiceSettings(string SettingData, out ICIM_ConcreteJob? Job);
        uint AddAuthorizationEntry(string AuthorizationEntry, out ICIM_ConcreteJob? Job);
        uint ModifyAuthorizationEntry(string AuthorizationEntry, out ICIM_ConcreteJob? Job);
        uint RemoveAuthorizationEntry(string AllowedPrimaryHostSystem, out ICIM_ConcreteJob? Job);
        uint TestReplicationConnection(ushort AuthenticationType, bool BypassProxyServer, string CertificateThumbPrint, string RecoveryConnectionPoint, ushort RecoveryServerPortNumber, out ICIM_ConcreteJob? Job);
        uint CreateReplicationRelationship(ICIM_ComputerSystem ComputerSystem, string ReplicationSettingData, out ICIM_ConcreteJob? Job);
        uint ModifyReplicationSettings(ICIM_ComputerSystem ComputerSystem, string ReplicationSettingData, out ICIM_ConcreteJob? Job);
        uint RemoveReplicationRelationship(ICIM_ComputerSystem ComputerSystem, out ICIM_ConcreteJob? Job);
        uint RemoveReplicationRelationshipEx(ICIM_ComputerSystem ComputerSystem, string ReplicationRelationship, out ICIM_ConcreteJob? Job);
        uint StartReplication(ICIM_ComputerSystem ComputerSystem, string InitialReplicationExportLocation, ushort InitialReplicationType, DateTime StartTime, out ICIM_ConcreteJob? Job);
        uint ImportInitialReplica(ICIM_ComputerSystem ComputerSystem, string InitialReplicationImportLocation, out ICIM_ConcreteJob? Job);
        uint ReverseReplicationRelationship(ICIM_ComputerSystem ComputerSystem, string ReplicationSettingData, out ICIM_ConcreteJob? Job);
        uint InitiateFailover(ICIM_ComputerSystem ComputerSystem, ICIM_VirtualSystemSettingData SnapshotSettingData, out ICIM_ConcreteJob? Job);
        uint RevertFailover(ICIM_ComputerSystem ComputerSystem, out ICIM_ConcreteJob? Job);
        uint CommitFailover(ICIM_ComputerSystem ComputerSystem, out ICIM_ConcreteJob? Job);
        uint TestReplicaSystem(ICIM_ComputerSystem ComputerSystem, ICIM_VirtualSystemSettingData SnapshotSettingData, out ICIM_ConcreteJob? Job, out ICIM_ComputerSystem? ResultingSystem);
        uint Resynchronize(ICIM_ComputerSystem ComputerSystem, DateTime StartTime, out ICIM_ConcreteJob? Job);
        uint SetFailoverNetworkAdapterSettings(ICIM_ComputerSystem ComputerSystem, string[] NetworkSettings, out ICIM_ConcreteJob? Job);
        uint GetReplicationStatistics(ICIM_ComputerSystem ComputerSystem, out ICIM_ConcreteJob? Job, out string[]? ReplicationHealthIssues, out string[]? ReplicationStatistics);
        uint GetReplicationStatisticsEx(ICIM_ComputerSystem ComputerSystem, string ReplicationRelationship, out ICIM_ConcreteJob? Job, out string[]? ReplicationHealthIssues, out string[]? ReplicationStatistics);
        uint ResetReplicationStatistics(ICIM_ComputerSystem ComputerSystem, out ICIM_ConcreteJob? Job);
        uint ResetReplicationStatisticsEx(ICIM_ComputerSystem ComputerSystem, string ReplicationRelationship, out ICIM_ConcreteJob? Job);
        uint SetAuthorizationEntry(string AuthorizationEntry, ICIM_ComputerSystem ComputerSystem, out ICIM_ConcreteJob? Job);
        uint GetSystemCertificates(out string[]? EncodedCertificates);
        uint ChangeReplicationModeToPrimary(ICIM_ComputerSystem ComputerSystem, string ReplicationRelationship, out ICIM_ConcreteJob? Job);
        uint InitiateFailback(ICIM_ComputerSystem ComputerSystem, string RecoveryPointIdentifier, string ReplicationSettingData, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_MetricService", @"root\virtualization\v2")]
    public interface IMsvm_MetricService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint ShowMetrics(ICIM_BaseMetricDefinition Definition, ICIM_ManagedElement Subject, out CimInstance[]? DefinitionList, out CimInstance[]? ManagedElements, out ushort[]? MetricCollectionEnabled, out string[]? MetricNames);
        uint ShowMetricsByClass(ICIM_BaseMetricDefinition Definition, ICIM_ManagedElement Subject, out CimInstance[]? DefinitionList, out ushort[]? MetricCollectionEnabled, out string[]? MetricNames);
        uint ControlMetrics(ICIM_BaseMetricDefinition Definition, ushort MetricCollectionEnabled, ICIM_ManagedElement Subject);
        uint ControlMetricsByClass(ICIM_BaseMetricDefinition Definition, ushort MetricCollectionEnabled, ICIM_ManagedElement Subject);
        uint GetMetricValues(ushort Count, ICIM_BaseMetricDefinition Definition, ushort Range, out CimInstance[]? Values);
        uint ControlSampleTimes(DateTime PreferredSampleInterval, bool RestartGathering, DateTime StartSampleTime);
        uint ModifyServiceSettings(string SettingData, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_ImageManagementService", @"root\virtualization\v2")]
    public interface IMsvm_ImageManagementService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint SetVirtualHardDiskSettingData(string VirtualDiskSettingData, out ICIM_ConcreteJob? Job);
        uint CreateVirtualHardDisk(string VirtualDiskSettingData, out ICIM_ConcreteJob? Job);
        uint SetParentVirtualHardDisk(string ChildPath, bool IgnoreIDMismatch, string LeafPath, string ParentPath, out ICIM_ConcreteJob? Job);
        uint CreateVirtualFloppyDisk(string Path, out ICIM_ConcreteJob? Job);
        uint MergeVirtualHardDisk(string DestinationPath, string SourcePath, out ICIM_ConcreteJob? Job);
        uint CompactVirtualHardDisk(ushort Mode, string Path, out ICIM_ConcreteJob? Job);
        uint ResizeVirtualHardDisk(UInt64 MaxInternalSize, string Path, out ICIM_ConcreteJob? Job);
        uint ConvertVirtualHardDisk(string SourcePath, string VirtualDiskSettingData, out ICIM_ConcreteJob? Job);
        uint GetVirtualHardDiskSettingData(string Path, out ICIM_ConcreteJob? Job, out string? SettingData);
        uint GetVirtualHardDiskState(string Path, out ICIM_ConcreteJob? Job, out string? State);
        uint AttachVirtualHardDisk(bool AssignDriveLetter, string Path, bool ReadOnly, out ICIM_ConcreteJob? Job);
        uint ValidateVirtualHardDisk(string Path, out ICIM_ConcreteJob? Job);
        uint ValidatePersistentReservationSupport(string Path, out ICIM_ConcreteJob? Job);
        uint GetVHDSetInformation(uint[] AdditionalInformation, string VHDSetPath, out string? Information, out ICIM_ConcreteJob? Job);
        uint GetVHDSnapshotInformation(uint[] AdditionalInformation, string[] SnapshotIds, string VHDSetPath, out ICIM_ConcreteJob? Job, out string[]? SnapshotInformation);
        uint SetVHDSnapshotInformation(string Information, out ICIM_ConcreteJob? Job);
        uint DeleteVHDSnapshot(bool PersistReferenceSnapshot, string SnapshotId, string VHDSetPath, out ICIM_ConcreteJob? Job);
        uint ConvertVirtualHardDiskToVHDSet(string VirtualHardDiskPath, out ICIM_ConcreteJob? Job);
        uint OptimizeVHDSet(string VHDSetPath, out ICIM_ConcreteJob? Job);
        uint GetVirtualDiskChanges(UInt64 ByteLength, UInt64 ByteOffset, string LimitId, string Path, string TargetSnapshotId, out UInt64[]? ChangedByteLengths, out UInt64[]? ChangedByteOffsets, out ICIM_ConcreteJob? Job, out UInt64? ProcessedByteLength);
        uint FindMountedStorageImageInstance(ushort CriterionType, string SelectionCriterion, out IMsvm_MountedStorageImage? Image);
    }

    [CimClassName("Msvm_CollectionManagementService", @"root\virtualization\v2")]
    public interface IMsvm_CollectionManagementService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint DefineCollection(string Id, string Name, ushort Type, out ICIM_CollectionOfMSEs? DefinedCollection, out ICIM_ConcreteJob? Job);
        uint DestroyCollection(ICIM_CollectionOfMSEs Collection, out ICIM_ConcreteJob? Job);
        uint RenameCollection(ICIM_CollectionOfMSEs Collection, string NewName, out ICIM_ConcreteJob? Job);
        uint AddMember(ICIM_CollectionOfMSEs Collection, ICIM_ManagedElement Member, out ICIM_ConcreteJob? Job);
        uint RemoveMember(ICIM_CollectionOfMSEs Collection, ICIM_ManagedElement Member, out ICIM_ConcreteJob? Job);
        uint RemoveMemberById(string CollectionId, ICIM_ManagedElement Member, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_SecurityService", @"root\virtualization\v2")]
    public interface IMsvm_SecurityService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint ModifySecuritySettings(string SecuritySettingData, out ICIM_ConcreteJob? Job);
        uint SetSecurityPolicy(byte[] SecurityPolicy, string SecuritySettingData, out ICIM_ConcreteJob? Job);
        uint SetKeyProtector(byte[] KeyProtector, string SecuritySettingData, out ICIM_ConcreteJob? Job);
        uint GetKeyProtector(string SecuritySettingData, out byte[]? KeyProtector);
        uint RestoreLastKnownGoodKeyProtector(string SecuritySettingData, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_TerminalService", @"root\virtualization\v2")]
    public interface IMsvm_TerminalService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint ModifyServiceSettings(string ServiceSettingData, out ICIM_ConcreteJob? Job);
        uint GrantInteractiveSessionAccess(ICIM_ComputerSystem ComputerSystem, string[] Trustees, out ICIM_ConcreteJob? Job);
        uint RevokeInteractiveSessionAccess(ICIM_ComputerSystem ComputerSystem, string[] Trustees, out ICIM_ConcreteJob? Job);
        uint GetInteractiveSessionACL(ICIM_ComputerSystem ComputerSystem, out string[]? AccessControlList);
    }

    [CimClassName("Msvm_VirtualSystemSnapshotService", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemSnapshotService : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        bool? Started{ get; set; }
        string? StartMode{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint StartService();
        uint StopService();
        uint CreateSnapshot(ICIM_ComputerSystem AffectedSystem, out ICIM_VirtualSystemSettingData? ResultingSnapshot, string SnapshotSettings, ushort SnapshotType, out ICIM_ConcreteJob? Job);
        uint DestroySnapshot(ICIM_VirtualSystemSettingData AffectedSnapshot, out ICIM_ConcreteJob? Job);
        uint ApplySnapshot(ICIM_VirtualSystemSettingData Snapshot, out ICIM_ConcreteJob? Job);
        uint DestroySnapshotTree(ICIM_VirtualSystemSettingData SnapshotSettingData, out ICIM_ConcreteJob? Job);
        uint ClearSnapshotState(ICIM_VirtualSystemSettingData SnapshotSettingData, out ICIM_ConcreteJob? Job);
        uint ConvertToReferencePoint(ICIM_VirtualSystemSettingData AffectedSnapshot, string ReferencePointSettings, out IMsvm_VirtualSystemReferencePoint? ResultingReferencePoint, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_SecurityElement", @"root\virtualization\v2")]
    public interface IMsvm_SecurityElement : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        bool? EncryptStateAndVmMigrationTrafficEnabled{ get; set; }
        bool? Shielded{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_SyntheticEthernetPort", @"root\virtualization\v2")]
    public interface IMsvm_SyntheticEthernetPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        ushort[]? EnabledCapabilities{ get; set; }
        uint? MaxDataSize{ get; set; }
        string[]? OtherEnabledCapabilities{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_EthernetSwitchPort", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        ushort[]? EnabledCapabilities{ get; set; }
        uint? MaxDataSize{ get; set; }
        string[]? OtherEnabledCapabilities{ get; set; }
        uint? IOVOffloadUsage{ get; set; }
        uint? VMQOffloadUsage{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_InternalEthernetPort", @"root\virtualization\v2")]
    public interface IMsvm_InternalEthernetPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        ushort[]? EnabledCapabilities{ get; set; }
        uint? MaxDataSize{ get; set; }
        string[]? OtherEnabledCapabilities{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_ExternalEthernetPort", @"root\virtualization\v2")]
    public interface IMsvm_ExternalEthernetPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        ushort[]? EnabledCapabilities{ get; set; }
        uint? MaxDataSize{ get; set; }
        string[]? OtherEnabledCapabilities{ get; set; }
        bool? IsBound{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_EmulatedEthernetPort", @"root\virtualization\v2")]
    public interface IMsvm_EmulatedEthernetPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        ushort[]? EnabledCapabilities{ get; set; }
        uint? MaxDataSize{ get; set; }
        string[]? OtherEnabledCapabilities{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_SyntheticFcPort", @"root\virtualization\v2")]
    public interface IMsvm_SyntheticFcPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        ushort[]? ActiveCOS{ get; set; }
        ushort[]? ActiveFC4Types{ get; set; }
        ushort[]? SupportedCOS{ get; set; }
        ushort[]? SupportedFC4Types{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_FcSwitchPort", @"root\virtualization\v2")]
    public interface IMsvm_FcSwitchPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        ushort[]? ActiveCOS{ get; set; }
        ushort[]? ActiveFC4Types{ get; set; }
        ushort[]? SupportedCOS{ get; set; }
        ushort[]? SupportedFC4Types{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_ExternalFcPort", @"root\virtualization\v2")]
    public interface IMsvm_ExternalFcPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        ushort[]? ActiveCOS{ get; set; }
        ushort[]? ActiveFC4Types{ get; set; }
        ushort[]? SupportedCOS{ get; set; }
        ushort[]? SupportedFC4Types{ get; set; }
        bool? IsHyperVCapable{ get; set; }
        string? WWNN{ get; set; }
        string? WWPN{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_WiFiPort", @"root\virtualization\v2")]
    public interface IMsvm_WiFiPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }
        UInt64? ActiveMaximumTransmissionUnit{ get; set; }
        bool? AutoSense{ get; set; }
        bool? FullDuplex{ get; set; }
        ushort? LinkTechnology{ get; set; }
        string[]? NetworkAddresses{ get; set; }
        string? OtherLinkTechnology{ get; set; }
        string? OtherNetworkPortType{ get; set; }
        string? PermanentAddress{ get; set; }
        ushort? PortNumber{ get; set; }
        UInt64? SupportedMaximumTransmissionUnit{ get; set; }
        bool? IsBound{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_SerialPort", @"root\virtualization\v2")]
    public interface IMsvm_SerialPort : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? MaxSpeed{ get; set; }
        string? OtherPortType{ get; set; }
        ushort? PortType{ get; set; }
        UInt64? RequestedSpeed{ get; set; }
        UInt64? Speed{ get; set; }
        ushort? UsageRestriction{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_TimeSyncComponent", @"root\virtualization\v2")]
    public interface IMsvm_TimeSyncComponent : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_GpuPartition", @"root\virtualization\v2")]
    public interface IMsvm_GpuPartition : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? CurrentCompute{ get; set; }
        UInt64? CurrentDecode{ get; set; }
        UInt64? CurrentEncode{ get; set; }
        UInt64? CurrentVRAM{ get; set; }
        string? DeviceInstancePath{ get; set; }
        ushort? PartitionId{ get; set; }
        string? PartitionVfLuid{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_HeartbeatComponent", @"root\virtualization\v2")]
    public interface IMsvm_HeartbeatComponent : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_Keyboard", @"root\virtualization\v2")]
    public interface IMsvm_Keyboard : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        bool? IsLocked{ get; set; }
        string? Layout{ get; set; }
        ushort? NumberOfFunctionKeys{ get; set; }
        ushort? Password{ get; set; }
        bool? UnicodeSupported{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint PressKey(uint KeyCode);
        uint ReleaseKey(uint KeyCode);
        uint TypeKey(uint KeyCode);
        uint IsKeyPressed(uint KeyCode, out bool? KeyState);
        uint TypeText(string AsciiText);
        uint TypeCtrlAltDel();
        uint TypeScancodes(byte[] Scancodes);
    }

    [CimClassName("Msvm_Ps2Mouse", @"root\virtualization\v2")]
    public interface IMsvm_Ps2Mouse : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        bool? IsLocked{ get; set; }
        ushort? Handedness{ get; set; }
        byte? NumberOfButtons{ get; set; }
        ushort? PointingType{ get; set; }
        uint? Resolution{ get; set; }
        bool? AbsoluteCoordinates{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint GetButtonState(uint ButtonIndex, out bool? ButtonState);
        uint SetButtonState(uint ButtonIndex, bool ButtonState);
        uint ClickButton(uint ButtonIndex);
        uint SetRelativePosition(sbyte HorizontalDelta, sbyte VerticalDelta);
        uint SetScrollPosition(sbyte ScrollPositionDelta);
    }

    [CimClassName("Msvm_SyntheticMouse", @"root\virtualization\v2")]
    public interface IMsvm_SyntheticMouse : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        bool? IsLocked{ get; set; }
        ushort? Handedness{ get; set; }
        byte? NumberOfButtons{ get; set; }
        ushort? PointingType{ get; set; }
        uint? Resolution{ get; set; }
        bool? AbsoluteCoordinates{ get; set; }
        int? HorizontalPosition{ get; set; }
        int? ScrollPosition{ get; set; }
        int? VerticalPosition{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint GetButtonState(uint ButtonIndex, out bool? IsDown);
        uint SetButtonState(uint ButtonIndex, bool IsDown);
        uint ClickButton(uint ButtonIndex);
        uint SetAbsolutePosition(int HorizontalPosition, int VerticalPosition);
        uint SetScrollPosition(int ScrollPositionDelta);
    }

    [CimClassName("Msvm_SyntheticKeyboard", @"root\virtualization\v2")]
    public interface IMsvm_SyntheticKeyboard : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        bool? IsLocked{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_TPM", @"root\virtualization\v2")]
    public interface IMsvm_TPM : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        ushort[]? AvailableRequestedTPMStates{ get; set; }
        uint? TPMManafucturerMajorRevision{ get; set; }
        uint? TPMManufacturerId{ get; set; }
        string? TPMManufacturerInfo{ get; set; }
        uint? TPMManufacturerMinorRevision{ get; set; }
        uint? TPMSpecMajorVersion{ get; set; }
        uint? TPMSpecMinorVersion{ get; set; }
        ushort? TPMState{ get; set; }
        ushort? TransitioningToTPMState{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint RequestTPMStateChange(string AuthorizationToken, ushort RequestedTPMState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint ChangeOwnerAuth(string NewOwnerAuth, string OldOwnerAuth);
    }

    [CimClassName("Msvm_FlexIoDevice", @"root\virtualization\v2")]
    public interface IMsvm_FlexIoDevice : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        string[]? EmulatorConfiguration{ get; set; }
        string? EmulatorId{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_PciExpress", @"root\virtualization\v2")]
    public interface IMsvm_PciExpress : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        string? DeviceInstancePath{ get; set; }
        ushort? FunctionNumber{ get; set; }
        string? LocationPath{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_SCSIProtocolController", @"root\virtualization\v2")]
    public interface IMsvm_SCSIProtocolController : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? MaxUnitsControlled{ get; set; }
        ushort? NameFormat{ get; set; }
        string? OtherNameFormat{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_KvpExchangeComponent", @"root\virtualization\v2")]
    public interface IMsvm_KvpExchangeComponent : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        string[]? GuestExchangeItems{ get; set; }
        string[]? GuestIntrinsicExchangeItems{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_Physical3dGraphicsProcessor", @"root\virtualization\v2")]
    public interface IMsvm_Physical3dGraphicsProcessor : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        UInt64? AdapterIndexID{ get; set; }
        UInt64? AvailableVideoMemory{ get; set; }
        bool? CompatibleForVirtualization{ get; set; }
        UInt64? DedicatedSystemMemory{ get; set; }
        UInt64? DedicatedVideoMemory{ get; set; }
        string? DirectXVersion{ get; set; }
        DateTime? DriverDate{ get; set; }
        DateTime? DriverInstalled{ get; set; }
        string? DriverModelVersion{ get; set; }
        string? DriverProvider{ get; set; }
        string? DriverVersion{ get; set; }
        bool? EnabledForVirtualization{ get; set; }
        string? GPUID{ get; set; }
        string? PixelShaderVersion{ get; set; }
        UInt64? Rating{ get; set; }
        UInt64? SharedSystemMemory{ get; set; }
        UInt64? TotalVideoMemory{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_VssComponent", @"root\virtualization\v2")]
    public interface IMsvm_VssComponent : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_ShutdownComponent", @"root\virtualization\v2")]
    public interface IMsvm_ShutdownComponent : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint InitiateShutdown(bool Force, string Reason);
        uint InitiateReboot(bool Force, string Reason);
        uint InitiateHibernate();
    }

    [CimClassName("Msvm_DiskDrive", @"root\virtualization\v2")]
    public interface IMsvm_DiskDrive : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        string? CompressionMethod{ get; set; }
        UInt64? DefaultBlockSize{ get; set; }
        string? ErrorMethodology{ get; set; }
        DateTime? LastCleaned{ get; set; }
        UInt64? LoadTime{ get; set; }
        UInt64? MaxAccessTime{ get; set; }
        UInt64? MaxBlockSize{ get; set; }
        UInt64? MaxMediaSize{ get; set; }
        UInt64? MaxUnitsBeforeCleaning{ get; set; }
        bool? MediaIsLocked{ get; set; }
        UInt64? MinBlockSize{ get; set; }
        UInt64? MountCount{ get; set; }
        bool? NeedsCleaning{ get; set; }
        uint? NumberOfMediaSupported{ get; set; }
        ushort? Security{ get; set; }
        DateTime? TimeOfLastMount{ get; set; }
        UInt64? TotalMountTime{ get; set; }
        uint? UncompressedDataRate{ get; set; }
        string? UnitsDescription{ get; set; }
        UInt64? UnitsUsed{ get; set; }
        UInt64? UnloadTime{ get; set; }
        uint? DriveNumber{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint LockMedia(bool Lock);
    }

    [CimClassName("Msvm_DisketteDrive", @"root\virtualization\v2")]
    public interface IMsvm_DisketteDrive : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        string? CompressionMethod{ get; set; }
        UInt64? DefaultBlockSize{ get; set; }
        string? ErrorMethodology{ get; set; }
        DateTime? LastCleaned{ get; set; }
        UInt64? LoadTime{ get; set; }
        UInt64? MaxAccessTime{ get; set; }
        UInt64? MaxBlockSize{ get; set; }
        UInt64? MaxMediaSize{ get; set; }
        UInt64? MaxUnitsBeforeCleaning{ get; set; }
        bool? MediaIsLocked{ get; set; }
        UInt64? MinBlockSize{ get; set; }
        UInt64? MountCount{ get; set; }
        bool? NeedsCleaning{ get; set; }
        uint? NumberOfMediaSupported{ get; set; }
        ushort? Security{ get; set; }
        DateTime? TimeOfLastMount{ get; set; }
        UInt64? TotalMountTime{ get; set; }
        uint? UncompressedDataRate{ get; set; }
        string? UnitsDescription{ get; set; }
        UInt64? UnitsUsed{ get; set; }
        UInt64? UnloadTime{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint LockMedia(bool Lock);
    }

    [CimClassName("Msvm_DVDDrive", @"root\virtualization\v2")]
    public interface IMsvm_DVDDrive : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        string? CompressionMethod{ get; set; }
        UInt64? DefaultBlockSize{ get; set; }
        string? ErrorMethodology{ get; set; }
        DateTime? LastCleaned{ get; set; }
        UInt64? LoadTime{ get; set; }
        UInt64? MaxAccessTime{ get; set; }
        UInt64? MaxBlockSize{ get; set; }
        UInt64? MaxMediaSize{ get; set; }
        UInt64? MaxUnitsBeforeCleaning{ get; set; }
        bool? MediaIsLocked{ get; set; }
        UInt64? MinBlockSize{ get; set; }
        UInt64? MountCount{ get; set; }
        bool? NeedsCleaning{ get; set; }
        uint? NumberOfMediaSupported{ get; set; }
        ushort? Security{ get; set; }
        DateTime? TimeOfLastMount{ get; set; }
        UInt64? TotalMountTime{ get; set; }
        uint? UncompressedDataRate{ get; set; }
        string? UnitsDescription{ get; set; }
        UInt64? UnitsUsed{ get; set; }
        UInt64? UnloadTime{ get; set; }
        ushort[]? FormatsSupported{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint LockMedia(bool Lock);
    }

    [CimClassName("Msvm_Battery", @"root\virtualization\v2")]
    public interface IMsvm_Battery : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_VideoHead", @"root\virtualization\v2")]
    public interface IMsvm_VideoHead : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? CurrentBitsPerPixel{ get; set; }
        uint? CurrentHorizontalResolution{ get; set; }
        UInt64? CurrentNumberOfColors{ get; set; }
        uint? CurrentNumberOfColumns{ get; set; }
        uint? CurrentNumberOfRows{ get; set; }
        uint? CurrentRefreshRate{ get; set; }
        ushort? CurrentScanMode{ get; set; }
        uint? CurrentVerticalResolution{ get; set; }
        uint? MaxRefreshRate{ get; set; }
        uint? MinRefreshRate{ get; set; }
        string? OtherCurrentScanMode{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_IDEController", @"root\virtualization\v2")]
    public interface IMsvm_IDEController : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? MaxNumberControlled{ get; set; }
        string? ProtocolDescription{ get; set; }
        ushort? ProtocolSupported{ get; set; }
        DateTime? TimeOfLastReset{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_S3DisplayController", @"root\virtualization\v2")]
    public interface IMsvm_S3DisplayController : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? MaxNumberControlled{ get; set; }
        string? ProtocolDescription{ get; set; }
        ushort? ProtocolSupported{ get; set; }
        DateTime? TimeOfLastReset{ get; set; }
        ushort[]? AcceleratorCapabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        uint? MaxMemorySupported{ get; set; }
        uint? NumberOfVideoPages{ get; set; }
        string? OtherVideoArchitecture{ get; set; }
        string? OtherVideoMemoryType{ get; set; }
        ushort? VideoArchitecture{ get; set; }
        ushort? VideoMemoryType{ get; set; }
        string? VideoProcessor{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_Synthetic3DDisplayController", @"root\virtualization\v2")]
    public interface IMsvm_Synthetic3DDisplayController : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? MaxNumberControlled{ get; set; }
        string? ProtocolDescription{ get; set; }
        ushort? ProtocolSupported{ get; set; }
        DateTime? TimeOfLastReset{ get; set; }
        ushort[]? AcceleratorCapabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        uint? MaxMemorySupported{ get; set; }
        uint? NumberOfVideoPages{ get; set; }
        string? OtherVideoArchitecture{ get; set; }
        string? OtherVideoMemoryType{ get; set; }
        ushort? VideoArchitecture{ get; set; }
        ushort? VideoMemoryType{ get; set; }
        string? VideoProcessor{ get; set; }
        string? AllocatedGPU{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_SyntheticDisplayController", @"root\virtualization\v2")]
    public interface IMsvm_SyntheticDisplayController : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? MaxNumberControlled{ get; set; }
        string? ProtocolDescription{ get; set; }
        ushort? ProtocolSupported{ get; set; }
        DateTime? TimeOfLastReset{ get; set; }
        ushort[]? AcceleratorCapabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        uint? MaxMemorySupported{ get; set; }
        uint? NumberOfVideoPages{ get; set; }
        string? OtherVideoArchitecture{ get; set; }
        string? OtherVideoMemoryType{ get; set; }
        ushort? VideoArchitecture{ get; set; }
        ushort? VideoMemoryType{ get; set; }
        string? VideoProcessor{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_PersistentMemoryController", @"root\virtualization\v2")]
    public interface IMsvm_PersistentMemoryController : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? MaxNumberControlled{ get; set; }
        string? ProtocolDescription{ get; set; }
        ushort? ProtocolSupported{ get; set; }
        DateTime? TimeOfLastReset{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_SerialController", @"root\virtualization\v2")]
    public interface IMsvm_SerialController : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? MaxNumberControlled{ get; set; }
        string? ProtocolDescription{ get; set; }
        ushort? ProtocolSupported{ get; set; }
        DateTime? TimeOfLastReset{ get; set; }
        ushort[]? Capabilities{ get; set; }
        string[]? CapabilityDescriptions{ get; set; }
        uint? MaxBaudRate{ get; set; }
        ushort? Security{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_DisketteController", @"root\virtualization\v2")]
    public interface IMsvm_DisketteController : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        uint? MaxNumberControlled{ get; set; }
        string? ProtocolDescription{ get; set; }
        ushort? ProtocolSupported{ get; set; }
        DateTime? TimeOfLastReset{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_RdvComponent", @"root\virtualization\v2")]
    public interface IMsvm_RdvComponent : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
        uint EnableEndPoints();
    }

    [CimClassName("Msvm_GuestServiceInterfaceComponent", @"root\virtualization\v2")]
    public interface IMsvm_GuestServiceInterfaceComponent : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_Memory", @"root\virtualization\v2")]
    public interface IMsvm_Memory : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        ushort? Access{ get; set; }
        UInt64? BlockSize{ get; set; }
        UInt64? ConsumableBlocks{ get; set; }
        ushort? DataOrganization{ get; set; }
        ushort? DataRedundancy{ get; set; }
        byte? DeltaReservation{ get; set; }
        string? ErrorMethodology{ get; set; }
        ushort[]? ExtentStatus{ get; set; }
        bool? IsBasedOnUnderlyingRedundancy{ get; set; }
        ushort? NameFormat{ get; set; }
        ushort? NameNamespace{ get; set; }
        bool? NoSinglePointOfFailure{ get; set; }
        UInt64? NumberOfBlocks{ get; set; }
        string? OtherNameFormat{ get; set; }
        string? OtherNameNamespace{ get; set; }
        ushort? PackageRedundancy{ get; set; }
        bool? Primordial{ get; set; }
        string? Purpose{ get; set; }
        bool? SequentialAccess{ get; set; }
        byte[]? AdditionalErrorData{ get; set; }
        bool? CorrectableError{ get; set; }
        UInt64? EndingAddress{ get; set; }
        ushort? ErrorAccess{ get; set; }
        UInt64? ErrorAddress{ get; set; }
        byte[]? ErrorData{ get; set; }
        ushort? ErrorDataOrder{ get; set; }
        ushort? ErrorInfo{ get; set; }
        UInt64? ErrorResolution{ get; set; }
        DateTime? ErrorTime{ get; set; }
        uint? ErrorTransferSize{ get; set; }
        string? OtherErrorDescription{ get; set; }
        UInt64? StartingAddress{ get; set; }
        bool? SystemLevelAddress{ get; set; }
        bool? Volatile{ get; set; }
        bool? MemoryEncryption{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_LogicalDisk", @"root\virtualization\v2")]
    public interface IMsvm_LogicalDisk : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        ushort? Access{ get; set; }
        UInt64? BlockSize{ get; set; }
        UInt64? ConsumableBlocks{ get; set; }
        ushort? DataOrganization{ get; set; }
        ushort? DataRedundancy{ get; set; }
        byte? DeltaReservation{ get; set; }
        string? ErrorMethodology{ get; set; }
        ushort[]? ExtentStatus{ get; set; }
        bool? IsBasedOnUnderlyingRedundancy{ get; set; }
        ushort? NameFormat{ get; set; }
        ushort? NameNamespace{ get; set; }
        bool? NoSinglePointOfFailure{ get; set; }
        UInt64? NumberOfBlocks{ get; set; }
        string? OtherNameFormat{ get; set; }
        string? OtherNameNamespace{ get; set; }
        ushort? PackageRedundancy{ get; set; }
        bool? Primordial{ get; set; }
        string? Purpose{ get; set; }
        bool? SequentialAccess{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_Processor", @"root\virtualization\v2")]
    public interface IMsvm_Processor : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        ushort[]? AdditionalAvailability{ get; set; }
        ushort? Availability{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? DeviceID{ get; set; }
        bool? ErrorCleared{ get; set; }
        string? ErrorDescription{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        uint? LastErrorCode{ get; set; }
        UInt64? MaxQuiesceTime{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        bool? PowerManagementSupported{ get; set; }
        UInt64? PowerOnHours{ get; set; }
        ushort? StatusInfo{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        UInt64? TotalPowerOnHours{ get; set; }
        ushort? AddressWidth{ get; set; }
        ushort? CPUStatus{ get; set; }
        uint? CurrentClockSpeed{ get; set; }
        ushort? DataWidth{ get; set; }
        uint? ExternalBusClockSpeed{ get; set; }
        ushort? Family{ get; set; }
        ushort? LoadPercentage{ get; set; }
        uint? MaxClockSpeed{ get; set; }
        string? OtherFamilyDescription{ get; set; }
        string? Role{ get; set; }
        string? Stepping{ get; set; }
        string? UniqueID{ get; set; }
        ushort? UpgradeMethod{ get; set; }
        ushort[]? LoadPercentageHistory{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(ushort PowerState, DateTime Time);
        uint Reset();
        uint EnableDevice(bool Enabled);
        uint OnlineDevice(bool Online);
        uint QuiesceDevice(bool Quiesce);
        uint SaveProperties();
        uint RestoreProperties();
    }

    [CimClassName("Msvm_LANEndpoint", @"root\virtualization\v2")]
    public interface IMsvm_LANEndpoint : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        string? NameFormat{ get; set; }
        string? OtherTypeDescription{ get; set; }
        ushort? ProtocolIFType{ get; set; }
        ushort? ProtocolType{ get; set; }
        string[]? AliasAddresses{ get; set; }
        string[]? GroupAddresses{ get; set; }
        string? LANID{ get; set; }
        ushort? LANType{ get; set; }
        string? MACAddress{ get; set; }
        uint? MaxDataSize{ get; set; }
        string? OtherLANType{ get; set; }
        bool? Connected{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_WiFiEndpoint", @"root\virtualization\v2")]
    public interface IMsvm_WiFiEndpoint : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        string? NameFormat{ get; set; }
        string? OtherTypeDescription{ get; set; }
        ushort? ProtocolIFType{ get; set; }
        ushort? ProtocolType{ get; set; }
        string[]? AliasAddresses{ get; set; }
        string[]? GroupAddresses{ get; set; }
        string? LANID{ get; set; }
        ushort? LANType{ get; set; }
        string? MACAddress{ get; set; }
        uint? MaxDataSize{ get; set; }
        string? OtherLANType{ get; set; }
        string? AccessPointAddress{ get; set; }
        bool? Associated{ get; set; }
        ushort? AuthenticationMethod{ get; set; }
        ushort? BSSType{ get; set; }
        ushort? EncryptionMethod{ get; set; }
        ushort? IEEE8021xAuthenticationProtocol{ get; set; }
        string? OtherAuthenticationMethod{ get; set; }
        string? OtherEncryptionMethod{ get; set; }
        bool? Connected{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_FcEndpoint", @"root\virtualization\v2")]
    public interface IMsvm_FcEndpoint : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        string? NameFormat{ get; set; }
        string? OtherTypeDescription{ get; set; }
        ushort? ProtocolIFType{ get; set; }
        ushort? ProtocolType{ get; set; }
        bool? Connected{ get; set; }
        string? WWNN{ get; set; }
        string? WWPN{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_VLANEndpoint", @"root\virtualization\v2")]
    public interface IMsvm_VLANEndpoint : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        string? NameFormat{ get; set; }
        string? OtherTypeDescription{ get; set; }
        ushort? ProtocolIFType{ get; set; }
        ushort? ProtocolType{ get; set; }
        ushort? DesiredEndpointMode{ get; set; }
        ushort? DesiredVLANTrunkEncapsulation{ get; set; }
        ushort? GVRPStatus{ get; set; }
        ushort? OperationalEndpointMode{ get; set; }
        ushort? OperationalVLANTrunkEncapsulation{ get; set; }
        string? OtherEndpointMode{ get; set; }
        string? OtherTrunkEncapsulation{ get; set; }
        ushort[]? SupportedEndpointModes{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_TerminalConnection", @"root\virtualization\v2")]
    public interface IMsvm_TerminalConnection : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? ConnectionID{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_EthernetSwitchExtension", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchExtension : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        byte? ExtensionType{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        string? Vendor{ get; set; }
        string? Version{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_NumaNode", @"root\virtualization\v2")]
    public interface IMsvm_NumaNode : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        uint? CurrentlyAssignedVirtualProcessors{ get; set; }
        UInt64? CurrentlyConsumableMemoryBlocks{ get; set; }
        [CimKey] string? NodeID{ get; set; }
        uint? NumberOfLogicalProcessors{ get; set; }
        uint? NumberOfProcessorCores{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("Msvm_ConcreteJob", @"root\virtualization\v2")]
    public interface IMsvm_ConcreteJob : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        bool? DeleteOnCompletion{ get; set; }
        DateTime? ElapsedTime{ get; set; }
        ushort? ErrorCode{ get; set; }
        string? ErrorDescription{ get; set; }
        uint? JobRunTimes{ get; set; }
        string? JobStatus{ get; set; }
        ushort? LocalOrUtcTime{ get; set; }
        string? Notify{ get; set; }
        string? OtherRecoveryAction{ get; set; }
        string? Owner{ get; set; }
        ushort? PercentComplete{ get; set; }
        uint? Priority{ get; set; }
        ushort? RecoveryAction{ get; set; }
        sbyte? RunDay{ get; set; }
        sbyte? RunDayOfWeek{ get; set; }
        byte? RunMonth{ get; set; }
        DateTime? RunStartInterval{ get; set; }
        DateTime? ScheduledStartTime{ get; set; }
        DateTime? StartTime{ get; set; }
        DateTime? TimeSubmitted{ get; set; }
        DateTime? UntilTime{ get; set; }
        ushort? JobState{ get; set; }
        DateTime? TimeBeforeRemoval{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        bool? Cancellable{ get; set; }
        string? ErrorSummaryDescription{ get; set; }
        ushort? JobType{ get; set; }

        uint KillJob(bool DeleteOnKill);
        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod);
        uint GetError(out string? Error);
        uint GetErrorEx(out string[]? Errors);
    }

    [CimClassName("Msvm_MigrationJob", @"root\virtualization\v2")]
    public interface IMsvm_MigrationJob : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        bool? DeleteOnCompletion{ get; set; }
        DateTime? ElapsedTime{ get; set; }
        ushort? ErrorCode{ get; set; }
        string? ErrorDescription{ get; set; }
        uint? JobRunTimes{ get; set; }
        string? JobStatus{ get; set; }
        ushort? LocalOrUtcTime{ get; set; }
        string? Notify{ get; set; }
        string? OtherRecoveryAction{ get; set; }
        string? Owner{ get; set; }
        ushort? PercentComplete{ get; set; }
        uint? Priority{ get; set; }
        ushort? RecoveryAction{ get; set; }
        sbyte? RunDay{ get; set; }
        sbyte? RunDayOfWeek{ get; set; }
        byte? RunMonth{ get; set; }
        DateTime? RunStartInterval{ get; set; }
        DateTime? ScheduledStartTime{ get; set; }
        DateTime? StartTime{ get; set; }
        DateTime? TimeSubmitted{ get; set; }
        DateTime? UntilTime{ get; set; }
        ushort? JobState{ get; set; }
        DateTime? TimeBeforeRemoval{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        bool? Cancellable{ get; set; }
        string? DestinationHost{ get; set; }
        string? ErrorSummaryDescription{ get; set; }
        ushort? JobType{ get; set; }
        ushort? MigrationType{ get; set; }
        string[]? NewResourceSettingData{ get; set; }
        string? NewSystemSettingData{ get; set; }
        string? VirtualSystemName{ get; set; }

        uint KillJob(bool DeleteOnKill);
        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod);
        uint GetError(out string? Error);
        uint GetErrorEx(out string[]? Errors);
    }

    [CimClassName("Msvm_CopyFileToGuestJob", @"root\virtualization\v2")]
    public interface IMsvm_CopyFileToGuestJob : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        bool? DeleteOnCompletion{ get; set; }
        DateTime? ElapsedTime{ get; set; }
        ushort? ErrorCode{ get; set; }
        string? ErrorDescription{ get; set; }
        uint? JobRunTimes{ get; set; }
        string? JobStatus{ get; set; }
        ushort? LocalOrUtcTime{ get; set; }
        string? Notify{ get; set; }
        string? OtherRecoveryAction{ get; set; }
        string? Owner{ get; set; }
        ushort? PercentComplete{ get; set; }
        uint? Priority{ get; set; }
        ushort? RecoveryAction{ get; set; }
        sbyte? RunDay{ get; set; }
        sbyte? RunDayOfWeek{ get; set; }
        byte? RunMonth{ get; set; }
        DateTime? RunStartInterval{ get; set; }
        DateTime? ScheduledStartTime{ get; set; }
        DateTime? StartTime{ get; set; }
        DateTime? TimeSubmitted{ get; set; }
        DateTime? UntilTime{ get; set; }
        ushort? JobState{ get; set; }
        DateTime? TimeBeforeRemoval{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        bool? Cancellable{ get; set; }
        string[]? CopyFileToGuestSettingData{ get; set; }
        string? ErrorSummaryDescription{ get; set; }
        string? VirtualSystemName{ get; set; }

        uint KillJob(bool DeleteOnKill);
        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod);
        uint GetError(out string? Error);
        uint GetErrorEx(out string[]? Errors);
    }

    [CimClassName("Msvm_StorageJob", @"root\virtualization\v2")]
    public interface IMsvm_StorageJob : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        bool? DeleteOnCompletion{ get; set; }
        DateTime? ElapsedTime{ get; set; }
        ushort? ErrorCode{ get; set; }
        string? ErrorDescription{ get; set; }
        uint? JobRunTimes{ get; set; }
        string? JobStatus{ get; set; }
        ushort? LocalOrUtcTime{ get; set; }
        string? Notify{ get; set; }
        string? OtherRecoveryAction{ get; set; }
        string? Owner{ get; set; }
        ushort? PercentComplete{ get; set; }
        uint? Priority{ get; set; }
        ushort? RecoveryAction{ get; set; }
        sbyte? RunDay{ get; set; }
        sbyte? RunDayOfWeek{ get; set; }
        byte? RunMonth{ get; set; }
        DateTime? RunStartInterval{ get; set; }
        DateTime? ScheduledStartTime{ get; set; }
        DateTime? StartTime{ get; set; }
        DateTime? TimeSubmitted{ get; set; }
        DateTime? UntilTime{ get; set; }
        ushort? JobState{ get; set; }
        DateTime? TimeBeforeRemoval{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        bool? Cancellable{ get; set; }
        string? Child{ get; set; }
        string? ErrorSummaryDescription{ get; set; }
        uint? JobCompletionStatusCode{ get; set; }
        ushort? JobType{ get; set; }
        string? Parent{ get; set; }

        uint KillJob(bool DeleteOnKill);
        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod);
        uint GetError(out string? Error);
        uint GetErrorEx(out string[]? Errors);
    }

    [CimClassName("Msvm_CollectionReferencePointExportJob", @"root\virtualization\v2")]
    public interface IMsvm_CollectionReferencePointExportJob : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        bool? DeleteOnCompletion{ get; set; }
        DateTime? ElapsedTime{ get; set; }
        ushort? ErrorCode{ get; set; }
        string? ErrorDescription{ get; set; }
        uint? JobRunTimes{ get; set; }
        string? JobStatus{ get; set; }
        ushort? LocalOrUtcTime{ get; set; }
        string? Notify{ get; set; }
        string? OtherRecoveryAction{ get; set; }
        string? Owner{ get; set; }
        ushort? PercentComplete{ get; set; }
        uint? Priority{ get; set; }
        ushort? RecoveryAction{ get; set; }
        sbyte? RunDay{ get; set; }
        sbyte? RunDayOfWeek{ get; set; }
        byte? RunMonth{ get; set; }
        DateTime? RunStartInterval{ get; set; }
        DateTime? ScheduledStartTime{ get; set; }
        DateTime? StartTime{ get; set; }
        DateTime? TimeSubmitted{ get; set; }
        DateTime? UntilTime{ get; set; }
        ushort? JobState{ get; set; }
        DateTime? TimeBeforeRemoval{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        string? BaseReferencePointGroupId{ get; set; }
        bool? Cancellable{ get; set; }
        string? CollectionId{ get; set; }
        string? ErrorSummaryDescription{ get; set; }
        string? ExportDirectory{ get; set; }
        string[]? ExportedConfigFilePaths{ get; set; }
        string[]? ExportedDisks{ get; set; }
        string[]? ExportedGuestStateFilePaths{ get; set; }
        string[]? ExportedLogFilePaths{ get; set; }
        string[]? ExportedRuntimeFilePaths{ get; set; }
        string? ReferencePointGroupId{ get; set; }
        string[]? VirtualMachineId{ get; set; }

        uint KillJob(bool DeleteOnKill);
        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod);
        uint GetError(out string? Error);
        uint GetErrorEx(out string[]? Errors);
    }

    [CimClassName("Msvm_VirtualSystemReferencePointExportJob", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemReferencePointExportJob : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        bool? DeleteOnCompletion{ get; set; }
        DateTime? ElapsedTime{ get; set; }
        ushort? ErrorCode{ get; set; }
        string? ErrorDescription{ get; set; }
        uint? JobRunTimes{ get; set; }
        string? JobStatus{ get; set; }
        ushort? LocalOrUtcTime{ get; set; }
        string? Notify{ get; set; }
        string? OtherRecoveryAction{ get; set; }
        string? Owner{ get; set; }
        ushort? PercentComplete{ get; set; }
        uint? Priority{ get; set; }
        ushort? RecoveryAction{ get; set; }
        sbyte? RunDay{ get; set; }
        sbyte? RunDayOfWeek{ get; set; }
        byte? RunMonth{ get; set; }
        DateTime? RunStartInterval{ get; set; }
        DateTime? ScheduledStartTime{ get; set; }
        DateTime? StartTime{ get; set; }
        DateTime? TimeSubmitted{ get; set; }
        DateTime? UntilTime{ get; set; }
        ushort? JobState{ get; set; }
        DateTime? TimeBeforeRemoval{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        string? BaseReferencePointId{ get; set; }
        bool? Cancellable{ get; set; }
        string? ErrorSummaryDescription{ get; set; }
        string? ExportDirectory{ get; set; }
        string? ExportedConfigFilePath{ get; set; }
        string[]? ExportedDisks{ get; set; }
        string? ExportedGuestStateFilePath{ get; set; }
        string[]? ExportedLogFilePaths{ get; set; }
        string? ExportedRuntimeFilePath{ get; set; }
        string? ReferencePointId{ get; set; }
        string? VirtualMachineId{ get; set; }

        uint KillJob(bool DeleteOnKill);
        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod);
        uint GetError(out string? Error);
        uint GetErrorEx(out string[]? Errors);
    }

    [CimClassName("Msvm_Synth3dVideoPool", @"root\virtualization\v2")]
    public interface IMsvm_Synth3dVideoPool : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        string? AllocationUnits{ get; set; }
        UInt64? Capacity{ get; set; }
        string? ConsumedResourceUnits{ get; set; }
        UInt64? CurrentlyConsumedResource{ get; set; }
        UInt64? MaxConsumableResource{ get; set; }
        string? OtherResourceType{ get; set; }
        string? PoolID{ get; set; }
        bool? Primordial{ get; set; }
        UInt64? Reserved{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        string? DirectXVersion{ get; set; }
        bool? Is3dVideoSupported{ get; set; }
        bool? IsGPUCapable{ get; set; }
        bool? IsSLATCapable{ get; set; }
        string? RequiredMinimumDirectXVersion{ get; set; }

        uint CalculateVideoMemoryRequirements(uint monitorResolution, uint numberOfMonitors, out UInt64? requiredVideoMemory);
    }

    [CimClassName("Msvm_ProcessorPool", @"root\virtualization\v2")]
    public interface IMsvm_ProcessorPool : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        string? AllocationUnits{ get; set; }
        UInt64? Capacity{ get; set; }
        string? ConsumedResourceUnits{ get; set; }
        UInt64? CurrentlyConsumedResource{ get; set; }
        UInt64? MaxConsumableResource{ get; set; }
        string? OtherResourceType{ get; set; }
        string? PoolID{ get; set; }
        bool? Primordial{ get; set; }
        UInt64? Reserved{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }

        uint CalculatePossibleReserve(ushort ProcessorCount);
    }

    [CimClassName("Msvm_ResourcePool", @"root\virtualization\v2")]
    public interface IMsvm_ResourcePool : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        string? AllocationUnits{ get; set; }
        UInt64? Capacity{ get; set; }
        string? ConsumedResourceUnits{ get; set; }
        UInt64? CurrentlyConsumedResource{ get; set; }
        UInt64? MaxConsumableResource{ get; set; }
        string? OtherResourceType{ get; set; }
        string? PoolID{ get; set; }
        bool? Primordial{ get; set; }
        UInt64? Reserved{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
    }

    [CimClassName("Msvm_DynamicForwardingEntry", @"root\virtualization\v2")]
    public interface IMsvm_DynamicForwardingEntry : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        ushort? DynamicStatus{ get; set; }
        [CimKey] string? MACAddress{ get; set; }
        [CimKey] string? ServiceCreationClassName{ get; set; }
        [CimKey] string? ServiceName{ get; set; }
        [CimKey] string? SystemCreationClassName{ get; set; }
        [CimKey] string? SystemName{ get; set; }
        ushort? VlanId{ get; set; }
    }

    [CimClassName("Msvm_MountedStorageImage", @"root\virtualization\v2")]
    public interface IMsvm_MountedStorageImage : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort? Access{ get; set; }
        [CimKey] byte? Lun{ get; set; }
        [CimKey] byte? PathId{ get; set; }
        string? PnpDevicePath{ get; set; }
        [CimKey] byte? PortNumber{ get; set; }
        [CimKey] byte? TargetId{ get; set; }
        ushort? Type{ get; set; }

        uint DetachVirtualHardDisk();
    }

    [CimClassName("Msvm_BIOSElement", @"root\virtualization\v2")]
    public interface IMsvm_BIOSElement : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        string? BuildNumber{ get; set; }
        string? CodeSet{ get; set; }
        string? IdentificationCode{ get; set; }
        string? LanguageEdition{ get; set; }
        string? Manufacturer{ get; set; }
        string? OtherTargetOS{ get; set; }
        string? SerialNumber{ get; set; }
        [CimKey] string? SoftwareElementID{ get; set; }
        [CimKey] ushort? SoftwareElementState{ get; set; }
        [CimKey] ushort? TargetOperatingSystem{ get; set; }
        [CimKey] string? Version{ get; set; }
        string? CurrentLanguage{ get; set; }
        string[]? ListOfLanguages{ get; set; }
        UInt64? LoadedEndingAddress{ get; set; }
        UInt64? LoadedStartingAddress{ get; set; }
        string? LoadUtilityInformation{ get; set; }
        bool? PrimaryBIOS{ get; set; }
        string[]? RegistryURIs{ get; set; }
        DateTime? ReleaseDate{ get; set; }
        string? BaseBoardSerialNumber{ get; set; }
        string? BIOSGUID{ get; set; }
        bool? BIOSNumLock{ get; set; }
        string? BIOSSerialNumber{ get; set; }
        ushort[]? BootOrder{ get; set; }
        bool? BootPciExpress{ get; set; }
        string? BootPciExpressInstanceFilter{ get; set; }
        string? ChassisAssetTag{ get; set; }
        string? ChassisSerialNumber{ get; set; }
        bool? EnableHibernation{ get; set; }
    }

    [CimClassName("Msvm_ReplicationRelationship", @"root\virtualization\v2")]
    public interface IMsvm_ReplicationRelationship : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort? FailedOverReplicationType{ get; set; }
        DateTime? LastApplicationConsistentReplicationTime{ get; set; }
        DateTime? LastApplyTime{ get; set; }
        DateTime? LastReplicationTime{ get; set; }
        ushort? LastReplicationType{ get; set; }
        ushort? ReplicationHealth{ get; set; }
        ushort? ReplicationState{ get; set; }
    }

    [CimClassName("Msvm_ReplicationProvider", @"root\virtualization\v2")]
    public interface IMsvm_ReplicationProvider : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
    }

    [CimClassName("Msvm_InstalledEthernetSwitchExtension", @"root\virtualization\v2")]
    public interface IMsvm_InstalledEthernetSwitchExtension : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        byte? ExtensionType{ get; set; }
        string? Vendor{ get; set; }
        string? Version{ get; set; }
    }

    [CimClassName("Msvm_SummaryInformationBase", @"root\virtualization\v2")]
    public interface IMsvm_SummaryInformationBase : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        DateTime? CreationTime{ get; set; }
        ushort? EnabledState{ get; set; }
        ushort? EnhancedSessionModeState{ get; set; }
        ushort? HealthState{ get; set; }
        string? HostComputerSystemName{ get; set; }
        string? Name{ get; set; }
        string? Notes{ get; set; }
        ushort? NumberOfProcessors{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        string? OtherEnabledState{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        UInt64? UpTime{ get; set; }
        string? Version{ get; set; }
        string[]? VirtualSwitchNames{ get; set; }
        string? VirtualSystemSubType{ get; set; }
    }

    [CimClassName("Msvm_SummaryInformation", @"root\virtualization\v2")]
    public interface IMsvm_SummaryInformation : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        DateTime? CreationTime{ get; set; }
        ushort? EnabledState{ get; set; }
        ushort? EnhancedSessionModeState{ get; set; }
        ushort? HealthState{ get; set; }
        string? HostComputerSystemName{ get; set; }
        string? Name{ get; set; }
        string? Notes{ get; set; }
        ushort? NumberOfProcessors{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        string? OtherEnabledState{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        UInt64? UpTime{ get; set; }
        string? Version{ get; set; }
        string[]? VirtualSwitchNames{ get; set; }
        string? VirtualSystemSubType{ get; set; }
        string? AllocatedGPU{ get; set; }
        ushort? ApplicationHealth{ get; set; }
        ICIM_ConcreteJob[]? AsynchronousTasks{ get; set; }
        int? AvailableMemoryBuffer{ get; set; }
        string? GuestOperatingSystem{ get; set; }
        ushort? Heartbeat{ get; set; }
        UInt64? HypervisorPartitionId{ get; set; }
        ushort? IntegrationServicesVersionState{ get; set; }
        int? MemoryAvailable{ get; set; }
        bool? MemorySpansPhysicalNumaNodes{ get; set; }
        UInt64? MemoryUsage{ get; set; }
        ushort? ProcessorLoad{ get; set; }
        ushort[]? ProcessorLoadHistory{ get; set; }
        ushort? ReplicationHealth{ get; set; }
        ushort[]? ReplicationHealthEx{ get; set; }
        ushort? ReplicationMode{ get; set; }
        string[]? ReplicationProviderId{ get; set; }
        ushort? ReplicationState{ get; set; }
        ushort[]? ReplicationStateEx{ get; set; }
        bool? Shielded{ get; set; }
        IMsvm_VirtualSystemSettingData[]? Snapshots{ get; set; }
        bool? SwapFilesInUse{ get; set; }
        CimInstance? TestReplicaSystem{ get; set; }
        byte[]? ThumbnailImage{ get; set; }
        ushort? ThumbnailImageHeight{ get; set; }
        ushort? ThumbnailImageWidth{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemManagementCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemManagementCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? ElementNameEditSupported{ get; set; }
        string? ElementNameMask{ get; set; }
        ushort? MaxElementNameLen{ get; set; }
        ushort[]? RequestedStatesSupported{ get; set; }
        ushort[]? AsynchronousMethodsSupported{ get; set; }
        ushort[]? IndicationsSupported{ get; set; }
        ushort[]? SynchronousMethodsSupported{ get; set; }
        string[]? VirtualSystemTypesSupported{ get; set; }
    }

    [CimClassName("Msvm_VirtualEthernetSwitchManagementCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_VirtualEthernetSwitchManagementCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? ElementNameEditSupported{ get; set; }
        string? ElementNameMask{ get; set; }
        ushort? MaxElementNameLen{ get; set; }
        ushort[]? RequestedStatesSupported{ get; set; }
        ushort[]? AsynchronousMethodsSupported{ get; set; }
        ushort[]? IndicationsSupported{ get; set; }
        ushort[]? SynchronousMethodsSupported{ get; set; }
        string[]? VirtualSystemTypesSupported{ get; set; }
        bool? IOVSupport{ get; set; }
        string[]? IOVSupportReasons{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? ElementNameEditSupported{ get; set; }
        string? ElementNameMask{ get; set; }
        ushort? MaxElementNameLen{ get; set; }
        ushort[]? RequestedStatesSupported{ get; set; }
    }

    [CimClassName("Msvm_MetricServiceCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_MetricServiceCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? ElementNameEditSupported{ get; set; }
        string? ElementNameMask{ get; set; }
        ushort? MaxElementNameLen{ get; set; }
        ushort[]? RequestedStatesSupported{ get; set; }
        string[]? ControllableManagedElements{ get; set; }
        string[]? ControllableMetrics{ get; set; }
        ushort[]? ManagedElementControlTypes{ get; set; }
        ushort[]? MetricsControlTypes{ get; set; }
        ushort[]? SupportedMethods{ get; set; }
    }

    [CimClassName("Msvm_ExternalEthernetPortCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_ExternalEthernetPortCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        bool? IOVSupport{ get; set; }
        string[]? IOVSupportReasons{ get; set; }
    }

    [CimClassName("Msvm_ResourcePoolConfigurationCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_ResourcePoolConfigurationCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        uint[]? AsynchronousMethodsSupported{ get; set; }
        uint[]? SynchronousMethodsSupported{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemMigrationCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemMigrationCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort[]? AsynchronousMethodsSupported{ get; set; }
        ushort[]? DestinationHostFormatsSupported{ get; set; }
        ushort[]? SynchronousMethodsSupported{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchFeatureCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchFeatureCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? Applicability{ get; set; }
        string? FeatureId{ get; set; }
        string? Version{ get; set; }
    }

    [CimClassName("Msvm_AllocationCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_AllocationCapabilities : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? OtherResourceType{ get; set; }
        ushort? RequestTypesSupported{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
        ushort? SharingMode{ get; set; }
        ushort[]? SupportedAddStates{ get; set; }
        ushort[]? SupportedRemoveStates{ get; set; }
    }

    [CimClassName("Msvm_KvpExchangeDataItem", @"root\virtualization\v2")]
    public interface IMsvm_KvpExchangeDataItem : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        string? Data{ get; set; }
        string? Name{ get; set; }
        ushort? Source{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemReferencePoint", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemReferencePoint : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? ConsistencyLevel{ get; set; }
        bool? HasAssociatedData{ get; set; }
        ushort? ReferencePointType{ get; set; }
        string[]? ResilientChangeTrackingIdentifiers{ get; set; }
        string[]? VirtualDiskIdentifiers{ get; set; }
        [CimKey] string? VirtualSystemIdentifier{ get; set; }
    }

    [CimClassName("Msvm_ReplicationStatistics", @"root\virtualization\v2")]
    public interface IMsvm_ReplicationStatistics : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        uint? ApplicationConsistentSnapshotFailureCount{ get; set; }
        DateTime? EndStatisticTime{ get; set; }
        DateTime? LastTestFailoverTime{ get; set; }
        uint? MaxReplicationLatency{ get; set; }
        UInt64? MaxReplicationSize{ get; set; }
        uint? NetworkFailureCount{ get; set; }
        UInt64? PendingReplicationSize{ get; set; }
        uint? ReplicationFailureCount{ get; set; }
        uint? ReplicationHealth{ get; set; }
        uint? ReplicationLatency{ get; set; }
        uint? ReplicationMissCount{ get; set; }
        UInt64? ReplicationSize{ get; set; }
        uint? ReplicationSuccessCount{ get; set; }
        DateTime? StartStatisticTime{ get; set; }
    }

    [CimClassName("Msvm_PhysicalGPUInfo", @"root\virtualization\v2")]
    public interface IMsvm_PhysicalGPUInfo : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        UInt64? AvailableVideoMemory{ get; set; }
        string? ID{ get; set; }
        string? Name{ get; set; }
        UInt64? TotalVideoMemory{ get; set; }
    }

    [CimClassName("Msvm_AggregationMetricDefinition", @"root\virtualization\v2")]
    public interface IMsvm_AggregationMetricDefinition : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        string[]? BreakdownDimensions{ get; set; }
        ushort? Calculable{ get; set; }
        ushort? ChangeType{ get; set; }
        ushort? DataType{ get; set; }
        ushort? GatheringType{ get; set; }
        [CimKey] string? Id{ get; set; }
        bool? IsContinuous{ get; set; }
        string? Name{ get; set; }
        string? ProgrammaticUnits{ get; set; }
        ushort? TimeScope{ get; set; }
        string? Units{ get; set; }
        ushort? SimpleFunction{ get; set; }
    }

    [CimClassName("Msvm_BaseMetricDefinition", @"root\virtualization\v2")]
    public interface IMsvm_BaseMetricDefinition : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        string[]? BreakdownDimensions{ get; set; }
        ushort? Calculable{ get; set; }
        ushort? ChangeType{ get; set; }
        ushort? DataType{ get; set; }
        ushort? GatheringType{ get; set; }
        [CimKey] string? Id{ get; set; }
        bool? IsContinuous{ get; set; }
        string? Name{ get; set; }
        string? ProgrammaticUnits{ get; set; }
        ushort? TimeScope{ get; set; }
        string? Units{ get; set; }
    }

    [CimClassName("Msvm_NumaNodeTopology", @"root\virtualization\v2")]
    public interface IMsvm_NumaNodeTopology : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        UInt64? CountOfMemoryBlocks{ get; set; }
        uint? CountOfProcessors{ get; set; }
        uint? PhysicalNodeNumber{ get; set; }
        uint? VirtualNodeNumber{ get; set; }
        uint? VirtualSocketNumber{ get; set; }
    }

    [CimClassName("Msvm_SnapshotCollection", @"root\virtualization\v2")]
    public interface IMsvm_SnapshotCollection : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CollectionID{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemCollection", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemCollection : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CollectionID{ get; set; }
        ushort? FailedOverReplicationType{ get; set; }
        ushort? LastApplyConsistencyLevel{ get; set; }
        DateTime? LastApplyTime{ get; set; }
        string[]? LastApplyVirtualMachineIds{ get; set; }
        ushort? ReplicationMode{ get; set; }
        ushort? ReplicationState{ get; set; }
    }

    [CimClassName("Msvm_ManagementCollection", @"root\virtualization\v2")]
    public interface IMsvm_ManagementCollection : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CollectionID{ get; set; }
    }

    [CimClassName("Msvm_ReferencePointCollection", @"root\virtualization\v2")]
    public interface IMsvm_ReferencePointCollection : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        [CimKey] string? CollectionID{ get; set; }
        ushort? ConsistencyLevel{ get; set; }
        bool? HasAssociatedLog{ get; set; }
        ushort? ReferencePointType{ get; set; }
        [CimKey] string? VirtualSystemCollectionId{ get; set; }
    }

    [CimClassName("Msvm_AggregationMetricValue", @"root\virtualization\v2")]
    public interface IMsvm_AggregationMetricValue : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? BreakdownDimension{ get; set; }
        string? BreakdownValue{ get; set; }
        DateTime? Duration{ get; set; }
        string? MeasuredElementName{ get; set; }
        string? MetricDefinitionId{ get; set; }
        string? MetricValue{ get; set; }
        DateTime? TimeStamp{ get; set; }
        bool? Volatile{ get; set; }
        DateTime? AggregationDuration{ get; set; }
        DateTime? AggregationTimeStamp{ get; set; }
    }

    [CimClassName("Msvm_BaseMetricValue", @"root\virtualization\v2")]
    public interface IMsvm_BaseMetricValue : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string? BreakdownDimension{ get; set; }
        string? BreakdownValue{ get; set; }
        DateTime? Duration{ get; set; }
        string? MeasuredElementName{ get; set; }
        string? MetricDefinitionId{ get; set; }
        string? MetricValue{ get; set; }
        DateTime? TimeStamp{ get; set; }
        bool? Volatile{ get; set; }
    }

    [CimClassName("Msvm_MoveUnmanagedVhd", @"root\virtualization\v2")]
    public interface IMsvm_MoveUnmanagedVhd : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        string? VhdDestinationPath{ get; set; }
        string? VhdSourcePath{ get; set; }
    }

    [CimClassName("Msvm_CollectedVirtualSystems", @"root\virtualization\v2")]
    public interface IMsvm_CollectedVirtualSystems : ICimObject
    {
        [CimKey] CimInstance? Collection{ get; set; }
        [CimKey] CimInstance? Member{ get; set; }
    }

    [CimClassName("Msvm_CollectedSnapshots", @"root\virtualization\v2")]
    public interface IMsvm_CollectedSnapshots : ICimObject
    {
        [CimKey] CimInstance? Collection{ get; set; }
        [CimKey] CimInstance? Member{ get; set; }
    }

    [CimClassName("Msvm_CollectedCollections", @"root\virtualization\v2")]
    public interface IMsvm_CollectedCollections : ICimObject
    {
        [CimKey] CimInstance? Collection{ get; set; }
        [CimKey] CimInstance? Member{ get; set; }
    }

    [CimClassName("Msvm_CollectedReferencePoints", @"root\virtualization\v2")]
    public interface IMsvm_CollectedReferencePoints : ICimObject
    {
        [CimKey] CimInstance? Collection{ get; set; }
        [CimKey] CimInstance? Member{ get; set; }
    }

    [CimClassName("Msvm_HostedResourcePool", @"root\virtualization\v2")]
    public interface IMsvm_HostedResourcePool : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_SystemBIOS", @"root\virtualization\v2")]
    public interface IMsvm_SystemBIOS : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_SystemComponent", @"root\virtualization\v2")]
    public interface IMsvm_SystemComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_SystemDevice", @"root\virtualization\v2")]
    public interface IMsvm_SystemDevice : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_BootSourceComponent", @"root\virtualization\v2")]
    public interface IMsvm_BootSourceComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_ConcreteComponent", @"root\virtualization\v2")]
    public interface IMsvm_ConcreteComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_SettingsDefineCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_SettingsDefineCapabilities : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
        ushort? PropertyPolicy{ get; set; }
        ushort? ValueRange{ get; set; }
        ushort? ValueRole{ get; set; }
        ushort? SupportStatement{ get; set; }
    }

    [CimClassName("Msvm_FeatureSettingsDefineCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_FeatureSettingsDefineCapabilities : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
        ushort? PropertyPolicy{ get; set; }
        ushort? ValueRange{ get; set; }
        ushort? ValueRole{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemSettingDataComponent", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemSettingDataComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_GuestServiceInterfaceSettingDataComponent", @"root\virtualization\v2")]
    public interface IMsvm_GuestServiceInterfaceSettingDataComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_SettingDataComponent", @"root\virtualization\v2")]
    public interface IMsvm_SettingDataComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_EthernetPortFailoverSettingDataComponent", @"root\virtualization\v2")]
    public interface IMsvm_EthernetPortFailoverSettingDataComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_EthernetPortSettingDataComponent", @"root\virtualization\v2")]
    public interface IMsvm_EthernetPortSettingDataComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_VirtualEthernetSwitchSettingDataComponent", @"root\virtualization\v2")]
    public interface IMsvm_VirtualEthernetSwitchSettingDataComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_VirtualSystemMigrationServiceSettingDataComponent", @"root\virtualization\v2")]
    public interface IMsvm_VirtualSystemMigrationServiceSettingDataComponent : ICimObject
    {
        [CimKey] CimInstance? GroupComponent{ get; set; }
        [CimKey] CimInstance? PartComponent{ get; set; }
    }

    [CimClassName("Msvm_SystemTerminalConnection", @"root\virtualization\v2")]
    public interface IMsvm_SystemTerminalConnection : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_HostedService", @"root\virtualization\v2")]
    public interface IMsvm_HostedService : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_HostedSwitchService", @"root\virtualization\v2")]
    public interface IMsvm_HostedSwitchService : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_HostedDependency", @"root\virtualization\v2")]
    public interface IMsvm_HostedDependency : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_SerialPortOnSerialController", @"root\virtualization\v2")]
    public interface IMsvm_SerialPortOnSerialController : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_VideoHeadOnController", @"root\virtualization\v2")]
    public interface IMsvm_VideoHeadOnController : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_HostedEthernetSwitchExtension", @"root\virtualization\v2")]
    public interface IMsvm_HostedEthernetSwitchExtension : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ReferencePointOfVirtualSystem", @"root\virtualization\v2")]
    public interface IMsvm_ReferencePointOfVirtualSystem : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_SystemReplicationRelationship", @"root\virtualization\v2")]
    public interface IMsvm_SystemReplicationRelationship : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_SnapshotOfVirtualSystem", @"root\virtualization\v2")]
    public interface IMsvm_SnapshotOfVirtualSystem : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ComputerSystemSummaryInformation", @"root\virtualization\v2")]
    public interface IMsvm_ComputerSystemSummaryInformation : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_LastAppliedSnapshot", @"root\virtualization\v2")]
    public interface IMsvm_LastAppliedSnapshot : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_MostCurrentSnapshotInBranch", @"root\virtualization\v2")]
    public interface IMsvm_MostCurrentSnapshotInBranch : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ReplicaSystemDependency", @"root\virtualization\v2")]
    public interface IMsvm_ReplicaSystemDependency : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ElementAllocatedFromNumaNode", @"root\virtualization\v2")]
    public interface IMsvm_ElementAllocatedFromNumaNode : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ElementAllocatedFromPool", @"root\virtualization\v2")]
    public interface IMsvm_ElementAllocatedFromPool : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_MetricDefForME", @"root\virtualization\v2")]
    public interface IMsvm_MetricDefForME : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
        ushort? MetricCollectionEnabled{ get; set; }
    }

    [CimClassName("Msvm_MetricCollectionDependency", @"root\virtualization\v2")]
    public interface IMsvm_MetricCollectionDependency : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_MetricForME", @"root\virtualization\v2")]
    public interface IMsvm_MetricForME : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ConcreteDependency", @"root\virtualization\v2")]
    public interface IMsvm_ConcreteDependency : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ParentChildSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ParentChildSettingData : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ResourceAllocationFromPool", @"root\virtualization\v2")]
    public interface IMsvm_ResourceAllocationFromPool : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ResourceDependentOnResource", @"root\virtualization\v2")]
    public interface IMsvm_ResourceDependentOnResource : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_EthernetDeviceSAPImplementation", @"root\virtualization\v2")]
    public interface IMsvm_EthernetDeviceSAPImplementation : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_DeviceSAPImplementation", @"root\virtualization\v2")]
    public interface IMsvm_DeviceSAPImplementation : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_WiFiDeviceSAPImplementation", @"root\virtualization\v2")]
    public interface IMsvm_WiFiDeviceSAPImplementation : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_FcDeviceSAPImplementation", @"root\virtualization\v2")]
    public interface IMsvm_FcDeviceSAPImplementation : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ProtocolControllerForUnit", @"root\virtualization\v2")]
    public interface IMsvm_ProtocolControllerForUnit : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
        ushort? AccessPriority{ get; set; }
        ushort? AccessState{ get; set; }
        string? DeviceNumber{ get; set; }
        ushort? DeviceAccess{ get; set; }
    }

    [CimClassName("Msvm_ControlledBy", @"root\virtualization\v2")]
    public interface IMsvm_ControlledBy : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
        uint? NegotiatedDataWidth{ get; set; }
        UInt64? NegotiatedSpeed{ get; set; }
        ushort? AccessMode{ get; set; }
        ushort? AccessPriority{ get; set; }
        ushort? AccessState{ get; set; }
        string? DeviceNumber{ get; set; }
        uint? NumberOfHardResets{ get; set; }
        uint? NumberOfSoftResets{ get; set; }
        DateTime? TimeOfDeviceReset{ get; set; }
    }

    [CimClassName("Msvm_BindsToLANEndpoint", @"root\virtualization\v2")]
    public interface IMsvm_BindsToLANEndpoint : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
        ushort? FrameType{ get; set; }
    }

    [CimClassName("Msvm_ActiveConnection", @"root\virtualization\v2")]
    public interface IMsvm_ActiveConnection : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
        bool? IsUnidirectional{ get; set; }
        string? OtherTrafficDescription{ get; set; }
        ushort? TrafficType{ get; set; }
    }

    [CimClassName("Msvm_FcActiveConnection", @"root\virtualization\v2")]
    public interface IMsvm_FcActiveConnection : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
        bool? IsUnidirectional{ get; set; }
        string? OtherTrafficDescription{ get; set; }
        ushort? TrafficType{ get; set; }
    }

    [CimClassName("Msvm_SwitchPortDynamicForwarding", @"root\virtualization\v2")]
    public interface IMsvm_SwitchPortDynamicForwarding : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_EthernetPortInfo", @"root\virtualization\v2")]
    public interface IMsvm_EthernetPortInfo : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ServiceOfVssComponent", @"root\virtualization\v2")]
    public interface IMsvm_ServiceOfVssComponent : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ReferencePointOfVirtualSystemCollection", @"root\virtualization\v2")]
    public interface IMsvm_ReferencePointOfVirtualSystemCollection : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_VirtualEthernetSwitchNicTeamingMember", @"root\virtualization\v2")]
    public interface IMsvm_VirtualEthernetSwitchNicTeamingMember : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_MetricInstance", @"root\virtualization\v2")]
    public interface IMsvm_MetricInstance : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ParentEthernetSwitchExtension", @"root\virtualization\v2")]
    public interface IMsvm_ParentEthernetSwitchExtension : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchInfo", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchInfo : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_BasedOn", @"root\virtualization\v2")]
    public interface IMsvm_BasedOn : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
        UInt64? EndingAddress{ get; set; }
        ushort? OrderIndex{ get; set; }
        UInt64? StartingAddress{ get; set; }
    }

    [CimClassName("Msvm_RegisteredGuestService", @"root\virtualization\v2")]
    public interface IMsvm_RegisteredGuestService : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_SnapshotOfVirtualSystemCollection", @"root\virtualization\v2")]
    public interface IMsvm_SnapshotOfVirtualSystemCollection : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_MediaPresent", @"root\virtualization\v2")]
    public interface IMsvm_MediaPresent : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
        bool? FixedMedia{ get; set; }
    }

    [CimClassName("Msvm_TransparentBridgingDynamicForwarding", @"root\virtualization\v2")]
    public interface IMsvm_TransparentBridgingDynamicForwarding : ICimObject
    {
        [CimKey] CimInstance? Antecedent{ get; set; }
        [CimKey] CimInstance? Dependent{ get; set; }
    }

    [CimClassName("Msvm_ElementConformsToProfile", @"root\virtualization\v2")]
    public interface IMsvm_ElementConformsToProfile : ICimObject
    {
        [CimKey] CimInstance? ConformantStandard{ get; set; }
        [CimKey] CimInstance? ManagedElement{ get; set; }
    }

    [CimClassName("Msvm_SystemExportSettingData", @"root\virtualization\v2")]
    public interface IMsvm_SystemExportSettingData : ICimObject
    {
        ushort? IsCurrent{ get; set; }
        ushort? IsDefault{ get; set; }
        ushort? IsNext{ get; set; }
        [CimKey] CimInstance? ManagedElement{ get; set; }
        [CimKey] CimInstance? SettingData{ get; set; }
    }

    [CimClassName("Msvm_ElementSettingData", @"root\virtualization\v2")]
    public interface IMsvm_ElementSettingData : ICimObject
    {
        ushort? IsCurrent{ get; set; }
        ushort? IsDefault{ get; set; }
        ushort? IsNext{ get; set; }
        [CimKey] CimInstance? ManagedElement{ get; set; }
        [CimKey] CimInstance? SettingData{ get; set; }
    }

    [CimClassName("Msvm_AffectedStorageJobElement", @"root\virtualization\v2")]
    public interface IMsvm_AffectedStorageJobElement : ICimObject
    {
        [CimKey] CimInstance? AffectedElement{ get; set; }
        [CimKey] CimInstance? AffectingElement{ get; set; }
        ushort[]? ElementEffects{ get; set; }
        string[]? OtherElementEffectsDescriptions{ get; set; }
    }

    [CimClassName("Msvm_AffectedJobElement", @"root\virtualization\v2")]
    public interface IMsvm_AffectedJobElement : ICimObject
    {
        [CimKey] CimInstance? AffectedElement{ get; set; }
        [CimKey] CimInstance? AffectingElement{ get; set; }
        ushort[]? ElementEffects{ get; set; }
        string[]? OtherElementEffectsDescriptions{ get; set; }
    }

    [CimClassName("Msvm_LogicalIdentity", @"root\virtualization\v2")]
    public interface IMsvm_LogicalIdentity : ICimObject
    {
        [CimKey] CimInstance? SameElement{ get; set; }
        [CimKey] CimInstance? SystemElement{ get; set; }
    }

    [CimClassName("Msvm_SettingsDefineState", @"root\virtualization\v2")]
    public interface IMsvm_SettingsDefineState : ICimObject
    {
        [CimKey] CimInstance? ManagedElement{ get; set; }
        [CimKey] CimInstance? SettingData{ get; set; }
    }

    [CimClassName("Msvm_ServiceAffectsElement", @"root\virtualization\v2")]
    public interface IMsvm_ServiceAffectsElement : ICimObject
    {
        [CimKey] CimInstance? AffectedElement{ get; set; }
        [CimKey] CimInstance? AffectingElement{ get; set; }
        ushort[]? ElementEffects{ get; set; }
        string[]? OtherElementEffectsDescriptions{ get; set; }
    }

    [CimClassName("Msvm_ElementCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_ElementCapabilities : ICimObject
    {
        [CimKey] CimInstance? Capabilities{ get; set; }
        ushort[]? Characteristics{ get; set; }
        [CimKey] CimInstance? ManagedElement{ get; set; }
    }

    [CimClassName("Msvm_EthernetSwitchExtensionCapabilities", @"root\virtualization\v2")]
    public interface IMsvm_EthernetSwitchExtensionCapabilities : ICimObject
    {
        [CimKey] CimInstance? Capabilities{ get; set; }
        ushort[]? Characteristics{ get; set; }
        [CimKey] CimInstance? ManagedElement{ get; set; }
    }

    [CimClassName("Msvm_OwningJobElement", @"root\virtualization\v2")]
    public interface IMsvm_OwningJobElement : ICimObject
    {
        [CimKey] CimInstance? OwnedElement{ get; set; }
        [CimKey] CimInstance? OwningElement{ get; set; }
    }

    [CimClassName("Msvm_GuestNetworkAdapterConfiguration", @"root\virtualization\v2")]
    public interface IMsvm_GuestNetworkAdapterConfiguration : ICimObject
    {
        string[]? DefaultGateways{ get; set; }
        bool? DHCPEnabled{ get; set; }
        string[]? DNSServers{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        string[]? IPAddresses{ get; set; }
        ushort[]? IPAddressOrigins{ get; set; }
        ushort? ProtocolIFType{ get; set; }
        string[]? Subnets{ get; set; }
    }

    [CimClassName("Msvm_Error", @"root\virtualization\v2")]
    public interface IMsvm_Error : ICimObject
    {
        uint? CIMStatusCode{ get; set; }
        string? CIMStatusCodeDescription{ get; set; }
        string? ErrorSource{ get; set; }
        ushort? ErrorSourceFormat{ get; set; }
        ushort? ErrorType{ get; set; }
        string? Message{ get; set; }
        string[]? MessageArguments{ get; set; }
        string? MessageID{ get; set; }
        string? OtherErrorSourceFormat{ get; set; }
        string? OtherErrorType{ get; set; }
        string? OwningEntity{ get; set; }
        ushort? PerceivedSeverity{ get; set; }
        ushort? ProbableCause{ get; set; }
        string? ProbableCauseDescription{ get; set; }
        string[]? RecommendedActions{ get; set; }
    }

    [CimClassName("Msvm_GuestClusterInformation", @"root\virtualization\v2")]
    public interface IMsvm_GuestClusterInformation : ICimObject
    {
        string? ClusterId{ get; set; }
        ushort? ClusterSize{ get; set; }
        bool[]? IsActiveActive{ get; set; }
        bool[]? IsClustered{ get; set; }
        bool[]? IsOnline{ get; set; }
        bool[]? IsOwned{ get; set; }
        UInt64? LastResourceMoveTime{ get; set; }
        string[]? SharedVirtualHardDiskPaths{ get; set; }
        string[]? SharedVirtualHardDisks{ get; set; }
    }

    [CimClassName("Msvm_CompatibilityVector", @"root\virtualization\v2")]
    public interface IMsvm_CompatibilityVector : ICimObject
    {
        uint? CompareOperation{ get; set; }
        UInt64? CompatibilityInfo{ get; set; }
        uint? VectorId{ get; set; }
    }

    [CimClassName("Msvm_VirtualHardDiskState", @"root\virtualization\v2")]
    public interface IMsvm_VirtualHardDiskState : ICimObject
    {
        uint? Alignment{ get; set; }
        UInt64? FileSize{ get; set; }
        uint? FragmentationPercentage{ get; set; }
        bool? InUse{ get; set; }
        UInt64? MinInternalSize{ get; set; }
        uint? PhysicalSectorSize{ get; set; }
        DateTime? Timestamp{ get; set; }
    }

    [CimClassName("Msvm_VHDSetInformation", @"root\virtualization\v2")]
    public interface IMsvm_VHDSetInformation : ICimObject
    {
        string[]? AllPaths{ get; set; }
        string? Path{ get; set; }
        string[]? SnapshotIdList{ get; set; }
    }

    [CimClassName("Msvm_VHDSnapshotInformation", @"root\virtualization\v2")]
    public interface IMsvm_VHDSnapshotInformation : ICimObject
    {
        DateTime? CreationTime{ get; set; }
        string? FilePath{ get; set; }
        string[]? ParentPathsList{ get; set; }
        string? ResilientChangeTrackingId{ get; set; }
        string? SnapshotId{ get; set; }
        string? SnapshotPath{ get; set; }
    }

    [CimClassName("Msvm_InteractiveSessionACE", @"root\virtualization\v2")]
    public interface IMsvm_InteractiveSessionACE : ICimObject
    {
        ushort? AccessType{ get; set; }
        string? Trustee{ get; set; }
    }

    [CimClassName("Msvm_VirtualMachineToDisks", @"root\virtualization\v2")]
    public interface IMsvm_VirtualMachineToDisks : ICimObject
    {
        string[]? DisksToExport{ get; set; }
        string? VirtualMachineId{ get; set; }
    }

    [CimClassName("Msvm_NetworkConnectionDiagnosticInformation", @"root\virtualization\v2")]
    public interface IMsvm_NetworkConnectionDiagnosticInformation : ICimObject
    {
        uint? RoundTripTime{ get; set; }
    }

    [CimClassName("Msvm_ServicingSettings", @"root\virtualization\v2")]
    public interface IMsvm_ServicingSettings : ICimObject
    {
        string? Version{ get; set; }
    }

    [CimClassName("CIM_ConcreteJob", @"root\virtualization\v2")]
    public interface ICIM_ConcreteJob : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        bool? DeleteOnCompletion{ get; set; }
        DateTime? ElapsedTime{ get; set; }
        ushort? ErrorCode{ get; set; }
        string? ErrorDescription{ get; set; }
        uint? JobRunTimes{ get; set; }
        string? JobStatus{ get; set; }
        ushort? LocalOrUtcTime{ get; set; }
        string? Notify{ get; set; }
        string? OtherRecoveryAction{ get; set; }
        string? Owner{ get; set; }
        ushort? PercentComplete{ get; set; }
        uint? Priority{ get; set; }
        ushort? RecoveryAction{ get; set; }
        sbyte? RunDay{ get; set; }
        sbyte? RunDayOfWeek{ get; set; }
        byte? RunMonth{ get; set; }
        DateTime? RunStartInterval{ get; set; }
        DateTime? ScheduledStartTime{ get; set; }
        DateTime? StartTime{ get; set; }
        DateTime? TimeSubmitted{ get; set; }
        DateTime? UntilTime{ get; set; }
        ushort? JobState{ get; set; }
        DateTime? TimeBeforeRemoval{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }

        uint KillJob(bool DeleteOnKill);
        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod);
        uint GetError(out string? Error);
    }

    [CimClassName("CIM_VirtualSystemSettingData", @"root\virtualization\v2")]
    public interface ICIM_VirtualSystemSettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? AutomaticRecoveryAction{ get; set; }
        ushort? AutomaticShutdownAction{ get; set; }
        ushort? AutomaticStartupAction{ get; set; }
        DateTime? AutomaticStartupActionDelay{ get; set; }
        ushort? AutomaticStartupActionSequenceNumber{ get; set; }
        string? ConfigurationDataRoot{ get; set; }
        string? ConfigurationFile{ get; set; }
        string? ConfigurationID{ get; set; }
        DateTime? CreationTime{ get; set; }
        string? LogDataRoot{ get; set; }
        string[]? Notes{ get; set; }
        string? RecoveryFile{ get; set; }
        string? SnapshotDataRoot{ get; set; }
        string? SuspendDataRoot{ get; set; }
        string? SwapFileDataRoot{ get; set; }
        string? VirtualSystemIdentifier{ get; set; }
        string? VirtualSystemType{ get; set; }
    }

    [CimClassName("CIM_ComputerSystem", @"root\virtualization\v2")]
    public interface ICIM_ComputerSystem : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        string? NameFormat{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        string[]? Roles{ get; set; }
        ushort[]? Dedicated{ get; set; }
        string[]? OtherDedicatedDescriptions{ get; set; }
        ushort[]? PowerManagementCapabilities{ get; set; }
        ushort? ResetCapability{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
        uint SetPowerState(uint PowerState, DateTime Time);
    }

    [CimClassName("CIM_SettingData", @"root\virtualization\v2")]
    public interface ICIM_SettingData : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
    }

    [CimClassName("CIM_Collection", @"root\virtualization\v2")]
    public interface ICIM_Collection : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
    }

    [CimClassName("CIM_System", @"root\virtualization\v2")]
    public interface ICIM_System : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        [CimKey] string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        ushort[]? AvailableRequestedStates{ get; set; }
        ushort? EnabledDefault{ get; set; }
        ushort? EnabledState{ get; set; }
        string? OtherEnabledState{ get; set; }
        ushort? RequestedState{ get; set; }
        DateTime? TimeOfLastStateChange{ get; set; }
        ushort? TransitioningToState{ get; set; }
        [CimKey] string? CreationClassName{ get; set; }
        string[]? IdentifyingDescriptions{ get; set; }
        string? NameFormat{ get; set; }
        string[]? OtherIdentifyingInfo{ get; set; }
        string? PrimaryOwnerContact{ get; set; }
        string? PrimaryOwnerName{ get; set; }
        string[]? Roles{ get; set; }

        uint RequestStateChange(ushort RequestedState, DateTime TimeoutPeriod, out ICIM_ConcreteJob? Job);
    }

    [CimClassName("CIM_CollectionOfMSEs", @"root\virtualization\v2")]
    public interface ICIM_CollectionOfMSEs : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        string? CollectionID{ get; set; }
    }

    [CimClassName("CIM_ResourcePool", @"root\virtualization\v2")]
    public interface ICIM_ResourcePool : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        [CimKey] string? InstanceID{ get; set; }
        ushort? CommunicationStatus{ get; set; }
        ushort? DetailedStatus{ get; set; }
        ushort? HealthState{ get; set; }
        DateTime? InstallDate{ get; set; }
        string? Name{ get; set; }
        ushort? OperatingStatus{ get; set; }
        ushort[]? OperationalStatus{ get; set; }
        ushort? PrimaryStatus{ get; set; }
        string? Status{ get; set; }
        string[]? StatusDescriptions{ get; set; }
        string? AllocationUnits{ get; set; }
        UInt64? Capacity{ get; set; }
        string? ConsumedResourceUnits{ get; set; }
        UInt64? CurrentlyConsumedResource{ get; set; }
        UInt64? MaxConsumableResource{ get; set; }
        string? OtherResourceType{ get; set; }
        string? PoolID{ get; set; }
        bool? Primordial{ get; set; }
        UInt64? Reserved{ get; set; }
        string? ResourceSubType{ get; set; }
        ushort? ResourceType{ get; set; }
    }

    [CimClassName("CIM_BaseMetricDefinition", @"root\virtualization\v2")]
    public interface ICIM_BaseMetricDefinition : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
        string[]? BreakdownDimensions{ get; set; }
        ushort? Calculable{ get; set; }
        ushort? ChangeType{ get; set; }
        ushort? DataType{ get; set; }
        ushort? GatheringType{ get; set; }
        [CimKey] string? Id{ get; set; }
        bool? IsContinuous{ get; set; }
        string? Name{ get; set; }
        string? ProgrammaticUnits{ get; set; }
        ushort? TimeScope{ get; set; }
        string? Units{ get; set; }
    }

    [CimClassName("CIM_ManagedElement", @"root\virtualization\v2")]
    public interface ICIM_ManagedElement : ICimObject
    {
        string? Caption{ get; set; }
        string? Description{ get; set; }
        string? ElementName{ get; set; }
        string? InstanceID{ get; set; }
    }
}

