/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;

namespace EasyWMI
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class WmiKeyAttribute : Attribute
    {
        public WmiKeyAttribute() { }
    }
}
