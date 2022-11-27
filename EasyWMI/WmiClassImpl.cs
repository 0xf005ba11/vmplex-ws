/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System.Management;
using System.Reflection;

namespace EasyWMI
{
    public class WmiClassImpl
    {
        public static WmiClassNameAttribute ClassName<T>()
        {
            Attribute? attribute = typeof(T).GetCustomAttribute(typeof(WmiClassNameAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Template interface requires WmiClassName attribute");
            }
            return (WmiClassNameAttribute)attribute;
        }

        public static T? GetProperty<T>(ManagementBaseObject? instance, string propertyName)
        {
            if (instance == null)
            {
                return default;
            }
            try
            {
                object? value = instance.GetPropertyValue(propertyName);
                if (value == null)
                {
                    return default;
                }
                return ConvertFromObject<T>(instance.GetPropertyValue(propertyName));
            }
            catch(Exception)
            {
                return default;
            }
        }

        private static T ConvertFromObject<T>(object value)
        {
            Type t = typeof(T);
            if (t.IsArray)
            {
                Type? et = t.GetElementType();
                if (et == null)
                {
                    throw new ArgumentException();
                }

                var methodName = typeof(IWmiObject).IsAssignableFrom(et)
                    ? nameof(ConvertFromObjectArray)
                    : nameof(ConvertFromTypedArray);
                object? result = typeof(WmiClassImpl).GetMethod(methodName)
                    ?.MakeGenericMethod(et)
                    ?.Invoke(null, new object[] { value });
                if (result == null)
                {
                    throw new NullReferenceException();
                }
                return (T)result;
            }

            if (t == typeof(DateTime))
            {
                value = ManagementDateTimeConverter.ToDateTime((string)value);
            }
            else if (t.IsEnum)
            {
                if (t.GetEnumUnderlyingType() != value.GetType())
                {
                    throw new InvalidCastException();
                }
            }
            else if (typeof(IWmiObject).IsAssignableFrom(t))
            {
                string? path = value as string;
                if (path != null)
                {
                    value = new ManagementObject(path);
                }
                T instance = WmiClassGenerator.CreateInstance<T>((ManagementBaseObject)value);
                value = (T)instance!;
            }
            return (T)value;
        }

        public static object ConvertFromObjectArray<T>(object[] array)
        {
            T[] ret = new T[array.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                ret[i] = ConvertFromObject<T>(array[i]!);
            }
            return ret;
        }

        public static object ConvertFromTypedArray<T>(T[] array)
        {
            T[] ret = new T[array.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                ret[i] = ConvertFromObject<T>(array[i]!);
            }
            return ret;
        }

        public static void SetProperty<T>(ManagementBaseObject instance, string propertyName, object? value)
        {
            try
            {
                if (value == null)
                {
                    instance.Properties.Remove(propertyName);
                }
                else
                {
                    Type t = value.GetType();
                    if (t.IsArray)
                    {
                        Type? et = t.GetElementType();
                        if (et == null)
                        {
                            throw new NullReferenceException();
                        }
                        if (typeof(IWmiObject).IsAssignableFrom(et))
                        {
                            value = ToInstanceArray((IWmiObject[])value);
                        }
                    }
                    else if (t == typeof(DateTime))
                    {
                        value = ManagementDateTimeConverter.ToDmtfDateTime((DateTime)value);
                    }
                    instance.SetPropertyValue(propertyName, (T)value);
                }
            }
            catch(Exception)
            {
            }
        }

        public static ManagementBaseObject MethodParameters(ManagementBaseObject instance, string methodName)
        {
            ManagementClass wmiClass = new ManagementClass(instance.ClassPath);
            return wmiClass.GetMethodParameters(methodName);
        }

        public static T[] FromInstances<T>(ManagementObjectCollection? instances)
        {
            if (instances == null)
            {
                return new T[0];
            }
            T[] ret = new T[instances.Count];
            var enumerator = instances.GetEnumerator();
            for (int i = 0; enumerator.MoveNext(); ++i)
            {
                ret[i] = WmiClassGenerator.CreateInstance<T>(enumerator.Current);
            }
            return ret;
        }

        public static ManagementBaseObject[] ToInstanceArray(IEnumerable<IWmiObject>? instances)
        {
            if (instances == null)
            {
                return new ManagementBaseObject[0];
            }
            ManagementBaseObject[] ret = new ManagementBaseObject[instances.Count()];
            var enumerator = instances.GetEnumerator();
            for (int i = 0; enumerator.MoveNext(); ++i)
            {
                ret[i] = enumerator.Current.__Instance;
            }
            return ret;
        }
    }
}
