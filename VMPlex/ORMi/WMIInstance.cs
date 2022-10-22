using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ORMi
{
    public class WMIInstance
    {
        [WMIIgnore]
        public ManagementScope Scope { get; set; }
    }
}
