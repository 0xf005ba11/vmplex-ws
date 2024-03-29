﻿/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace hvintegrate
{
    class Utility
    {
        static ConcurrentDictionary<string, bool> listOfAssemblies = new ConcurrentDictionary<string, bool>();
        static public Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            if (listOfAssemblies.ContainsKey(args.Name))
            {
                return null;
            }
            try
            {
                listOfAssemblies.GetOrAdd(args.Name, true);

                string[] parts = args.Name.Split(',');
                try
                {
                    return LoadGACAssembly(parts[0]);
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to resolve assembly: " + args.Name);
                }
                return null;
            }
            finally
            {
                bool val;
                listOfAssemblies.TryRemove(args.Name, out val);
            }
        }

        static public string LocateGACAssemblyDll(string assemblyName, string gacFolder = "GAC_64")
        {
            string gac = Environment.GetFolderPath(Environment.SpecialFolder.Windows) +
                "\\Microsoft.NET\\assembly\\" + gacFolder + "\\" + assemblyName;
            if (!Directory.Exists(gac))
            {
                if (gacFolder == "GAC_64")
                {
                    return LocateGACAssemblyDll(assemblyName, "GAC_MSIL");
                }
                return null;
            }

            IEnumerable<string> versions = Directory.EnumerateDirectories(gac);
            foreach( string version in versions)
            {
                string path = version + "\\" + assemblyName + ".dll";
                if (File.Exists(path))
                {
                    return gac;
                }
                if (gacFolder == "GAC_64")
                {
                    return LocateGACAssemblyDll(assemblyName, "GAC_MSIL");
                }
            }
            return null;
        }

        static public string GetGACAssemblyFullName(string assemblyName)
        {
            string gac = LocateGACAssemblyDll(assemblyName);
            IEnumerable<string> versions = Directory.EnumerateDirectories(gac);

            foreach( string version in versions)
            {
                string[] parts = new FileInfo(version).Name.Split('_');
                if (parts.Length == 4)
                {
                    string culture = parts[2].Length > 0 ? parts[2] : "neutral";
                    return assemblyName + ", Version=" + parts[1] + ", Culture=" + culture + ", PublicKeyToken=" + parts[3];
                }
            }
            return null;
        }

        static public Assembly LoadGACAssembly(string assemblyName)
        {
            return Assembly.Load(GetGACAssemblyFullName(assemblyName));
        }

        static public object InvokeStaticMethod(Type t, string methodName, Type[] types, object[] arguments)
        {
            MethodInfo method = t.GetMethod(methodName, types);

            return method.Invoke(null, arguments);
        }

        static public object InvokeMethod(object o, string methodName, Type[] types,object[] arguments)
        {
            MethodInfo method = o.GetType().GetMethod(methodName, types);

            return method.Invoke(o, arguments);
        }

        static public object InvokeMethod(object o, string methodName, object[] arguments)
        {
            Type[] types = arguments.Select(x => x.GetType()).ToArray();

            MethodInfo method = o.GetType().GetMethod(methodName, types);

            return method.Invoke(o, arguments);
        }

        static public object GetProperty(object o, string propertyName)
        {
            PropertyInfo pi = o.GetType().GetProperty(propertyName);
            if (pi is null)
            {
                return null;
            }

            return pi.GetValue(o);
        }

        static public void SetProperty(object o, string propertyName, object value)
        {
            PropertyInfo pi = o.GetType().GetProperty(propertyName);
            if (pi is null)
            {
                return;
            }
            pi.SetValue(o, value);
        }
    }
}
