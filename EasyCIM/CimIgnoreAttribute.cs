/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

namespace EasyCIM
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CimIgnoreAttribute : Attribute
    {
        public CimIgnoreAttribute() { }
    }
}
