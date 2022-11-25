/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

namespace EasyCIM
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CimKeyAttribute : Attribute
    {
        public CimKeyAttribute() { }
    }
}
