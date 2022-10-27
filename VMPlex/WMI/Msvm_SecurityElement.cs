using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMi;

namespace VMPlex.WMI
{
    [WMIClass(Name = "Msvm_SecurityElement", Namespace = @"root\Virtualization\V2")]
    public class Msvm_SecurityElement : WMIInstance
    {
        [WMIProperty("Shielded")]
        public bool Shielded { get; set; }

        [WMIProperty("EncryptStateAndVmMigrationTrafficEnabled")]
        public bool EncryptStateAndVmMigrationTrafficEnabled { get; set; }
    }
}
