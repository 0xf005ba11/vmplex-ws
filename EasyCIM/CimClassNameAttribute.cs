/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;

namespace EasyCIM
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public sealed class CimClassNameAttribute : Attribute
    {
        public string CimClassName { get; private set; }
        public string CimNamespace { get; private set; }

        public CimClassNameAttribute(string ClassName, string Namespace)
        {
            if (string.IsNullOrWhiteSpace(ClassName))
            {
                throw new ArgumentNullException(nameof(ClassName));
            }
            CimClassName = ClassName;
            CimNamespace = Namespace;
        }
    }
}
