/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

namespace EasyCIM
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public sealed class CimBaseAttribute : Attribute
    {
        public CimBaseAttribute() { }
    }
}
