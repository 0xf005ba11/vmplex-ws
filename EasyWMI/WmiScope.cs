/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System.Management;

namespace EasyWMI
{
    public class WmiScope
    {
        public ManagementScope Scope { get; }

        public WmiScope(string nameSpace)
        {
            var options = new ConnectionOptions();
            Scope = new ManagementScope(nameSpace, options);
            Scope.Connect();
        }

        public T GetInstance<T>()
        {
            return GetInstances<T>().First<T>();
        }

        public IEnumerable<T> GetInstances<T>()
        {
            var name = WmiClassImpl.ClassName<T>();
            var wmiClass = new ManagementClass(Scope, new ManagementPath(name.ClassName), new ObjectGetOptions());
            return GenList<T>(wmiClass.GetInstances());
        }

        public IEnumerable<T> QueryInstances<T>(string query)
        {
            var searcher = new ManagementObjectSearcher(Scope, new WqlObjectQuery(query));
            return GenList<T>(searcher.Get());
        }

        public WmiSubscription<T> Subscribe<T>(string query)
        {
            return new WmiSubscription<T>(this, query);
        }

        public WmiSubscription<T> Subscribe<T>(string eventClass, float within)
        {
            var name = WmiClassImpl.ClassName<T>();
            return Subscribe<T>(String.Format("SELECT * FROM {0} WITHIN {1} WHERE TargetInstance ISA '{2}'", eventClass, within, name.ClassName));
        }

        private IEnumerable<T> GenList<T>(ManagementObjectCollection collection)
        {
            var enumerator = collection.GetEnumerator();
            var list = new List<T>();
            while (enumerator.MoveNext())
            {
                list.Add(WmiClassGenerator.CreateInstance<T>((ManagementObject)enumerator.Current));
            }
            return list;
        }
    }
}
