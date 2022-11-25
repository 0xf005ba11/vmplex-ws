/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

namespace EasyCIM
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CimStaticAttribute : Attribute
    {
        public CimStaticAttribute() { }
    }
}
