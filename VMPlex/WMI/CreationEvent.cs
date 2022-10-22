/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Management;
using ORMi;

namespace VMPlex.WMI
{
    class CreationEvent : WMIInstance
    {
        public  ManagementBaseObject TargetInstance { get; set; }

        [WMIProperty("TIME_CREATED")]
        public UInt64 TimeCreated { get; set; }
    }
}
