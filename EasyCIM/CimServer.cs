/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;
using System.Reflection;

namespace EasyCIM
{
    public class CimServer
    {
        public CimAssembly Assembly { get; }
        public CimClassGenerator Generator { get; }
        public CimSession CimSession { get; }

        public CimServer(CimAssembly assembly)
        {
            Assembly = assembly;
            Generator = new CimClassGenerator(assembly);

            var sessionOptions = new DComSessionOptions { Timeout = TimeSpan.FromSeconds(30) };
            CimSession = CimSession.Create("localhost", sessionOptions);
        }

        public T SpawnInstance<T>()
        {
            T? ret = Generator.CreateInstance<T>();
            if (ret == null)
            {
                throw new InvalidOperationException("SpawnInstance failed");
            }
            return ret;
        }

        public T GetStatic<T>() => SpawnInstance<T>();

        public T SpawnInstance<T>(T key)
        {
            T? ret = Generator.CreateInstance<T>();
            if (ret == null)
            {
                throw new InvalidOperationException("SpawnInstance failed");
            }
            return ret;
        }

        public T GetInstance<T>()
        {
            return GetInstances<T>().First();
        }

        public IEnumerable<T> GetInstances<T>()
        {
            Attribute? attribute = typeof(T).GetCustomAttribute(typeof(CimClassNameAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Template interface requires CimClassName attribute");
            }
            CimClassNameAttribute cimName = (CimClassNameAttribute)attribute;

            var internalList = CimSession.EnumerateInstances(cimName.CimNamespace, cimName.CimClassName);
            return GenList<T>(Generator, CimSession, internalList);
        }

        public IEnumerable<T> QueryInstances<T>(string query)
        {
            Attribute? attribute = typeof(T).GetCustomAttribute(typeof(CimClassNameAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Template interface requires CimClassName attribute");
            }
            CimClassNameAttribute cimName = (CimClassNameAttribute)attribute;

            var internalList = CimSession.QueryInstances(cimName.CimNamespace, "WQL", query);
            return GenList<T>(Generator, CimSession, internalList);
        }

        public CimSubscription<T> Subscribe<T>(string eventClass, float within)
        {
            Attribute? attribute = typeof(T).GetCustomAttribute(typeof(CimClassNameAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Template interface requires CimClassName attribute");
            }
            CimClassNameAttribute cimName = (CimClassNameAttribute)attribute;

            string query = String.Format("SELECT * FROM {0} WITHIN {1} WHERE TargetInstance ISA '{2}'", eventClass, within, cimName.CimClassName);
            return Subscribe<T>(cimName.CimNamespace, query);
        }

        public CimSubscription<T> Subscribe<T>(string nameSpace, string query)
        {
            CimOperationOptions options = new CimOperationOptions();
            options.Timeout = Timeout.InfiniteTimeSpan;
            return new CimSubscription<T>(this, CimSession.SubscribeAsync(nameSpace, "WQL", query, options), query);
        }

        private static IEnumerable<T> GenList<T>(CimClassGenerator generator, CimSession session, IEnumerable<CimInstance> instances)
        {
            List<T> ret = new List<T>();
            foreach (CimInstance instance in instances)
            {
                T? obj = generator.CreateInstance<T>(session, instance);
                if (obj != null)
                {
                    ret.Add(obj);
                }
            }
            return ret;
        }
    }
}
