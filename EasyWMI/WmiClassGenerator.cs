/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Management;

namespace EasyWMI
{
    public class WmiClassGenerator
    {
        public static T CreateInstance<T>(ManagementBaseObject instance)
        {
            object? result = Activator.CreateInstance(typeof(T), new object[] { instance });
            if (result == null)
            {
                throw new NullReferenceException();
            }
            return (T)result;
        }
    }
}
