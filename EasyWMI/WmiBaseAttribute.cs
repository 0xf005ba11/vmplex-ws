/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;

namespace EasyWMI
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public sealed class WmiBaseAttribute : Attribute
    {
        public WmiBaseAttribute() { }
    }
}
