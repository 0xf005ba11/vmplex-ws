using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMi
{
    public class WMIProperty : Attribute
    {
        public WMIProperty()
        {

        }
        public WMIProperty(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Boolean SearchKey { get; set; }
    }

    public class WMIClass : Attribute
    {
        public WMIClass()
        {

        }
        public WMIClass(string name)
        {
            Name = name;
        }

        [Obsolete("Since 2.0.0 version the namespace should not longer be specified this way. Inherit from WMIInstance instead.")]
        public WMIClass(string name, string wmiNamespace)
        {
            Name = name;
            Namespace = wmiNamespace;
        }

        public string Name { get; set; }
        public string Namespace { get; set; }
    }

    public class WMIIgnore : Attribute
    {

    }

    public class WMIIgnoreOnInsert : Attribute
    {

    }

    public class WMIIgnoreOnUpdate : Attribute
    {

    }

    public class WMISearchKeyException : Exception
    {
        public WMISearchKeyException()
        {

        }

        public WMISearchKeyException(string message) : base(message)
        {

        }
    }
}
