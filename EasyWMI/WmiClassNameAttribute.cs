/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;

namespace EasyWMI
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class WmiClassNameAttribute : Attribute
    {
        public string ClassName { get; }
        public string Namespace { get; }

        public WmiClassNameAttribute(string className, string nameSpace)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException(nameof(className));
            }
            ClassName = className;
            Namespace = nameSpace;
        }
    }
}
