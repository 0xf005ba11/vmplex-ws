/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using Microsoft.Management.Infrastructure;

namespace EasyCIM
{
    public class CimClassImpl
    {
        public static T? GetProperty<T>(CimInstance instance, string property)
        {
            if (instance == null)
            {
                throw new FieldAccessException("Cannot access property of static class");
            }
            var value = instance.CimInstanceProperties[property];
            if (value is null || value.Value is null)
            {
                return default;
            }
            return (T)value.Value;
        }

        public static T[]? GetPropertyArray<T>(CimInstance instance, string property)
        {
            if (instance == null)
            {
                throw new FieldAccessException("Cannot access property of static class");
            }
            var value = instance.CimInstanceProperties[property];
            if (value is null || value.Value is null)
            {
                return default;
            }
            return (T[])value.Value;
        }

        public static void SetProperty(CimInstance instance, string property, object value, CimType type, CimFlags flags)
        {
            if (instance == null)
            {
                throw new FieldAccessException("Cannot access property of static class");
            }
            var prop = instance.CimInstanceProperties[property];
            if (prop == null)
            {
                instance.CimInstanceProperties.Add(CimProperty.Create(property, value, type, flags));
            }
            else
            {
                prop.Value = value;
            }
        }

        public static object CheckNull(object? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            return value;
        }

        public static T? GetOutParameter<T>(CimMethodResult results, string name)
        {
            CimMethodParameter param = results.OutParameters[name];
            if (param == null)
            {
                return default;
            }
            return (T?)param.Value;
        }

        public static T? GetOutParameter<T>(CimClassGenerator gen, CimSession server, CimMethodResult results, string name)
        {
            CimMethodParameter param = results.OutParameters[name];
            if (param == null || param.Value == null)
            {
                return default!;
            }

            if (param.CimType == CimType.InstanceArray || param.CimType == CimType.ReferenceArray)
            {
                Type? elemType = typeof(T).GetElementType();
                if (elemType == null)
                {
                    return default;
                }
                var method = typeof(CimClassGenerator).GetMethod("CreateInstanceArray")?.MakeGenericMethod(elemType);
                if (method == null)
                {
                    return default;
                }
                return (T?)method.Invoke(gen, new object[] { server, (CimInstance[])param.Value });
            }

            if (param.CimType == CimType.Instance || param.CimType == CimType.Reference)
            {
                if (server == null)
                {
                    return default;
                }
                return gen.CreateInstance<T>(server, (CimInstance)param.Value);
            }
            return (T?)param.Value;
        }

        public static T GetReturnValue<T>(CimMethodResult results)
        {
            return (T)results.ReturnValue.Value;
        }

        public static T? FromInstance<T>(CimInstance? instance, CimClassGenerator generator, CimSession session)
        {
            return instance == null ? default : generator.CreateInstance<T>(session, instance);
        }

        public static T[]? FromInstanceArray<T>(CimInstance[]? array, CimClassGenerator generator, CimSession session)
        {
            if (array == null)
            {
                return null;
            }
            return (from item in array select generator.CreateInstance<T>(session, item)).ToArray();
        }

        public static T[]? FromInstanceEnumerable<T>(IEnumerable<CimInstance>? instances, CimClassGenerator generator, CimSession session)
        {
            return (from item in instances select generator.CreateInstance<T>(session, item)).ToArray();
        }

        public static CimInstance[]? ToInstanceArray<T>(T[]? instances)
        {
            if (instances == null)
            {
                return null;
            }
            var ret = new List<CimInstance>();
            foreach (var instance in instances)
            {
                if (instance != null)
                {
                    ret.Add(((ICimObject)instance).__Instance);
                }
            }
            return ret.ToArray();
        }

        public static bool? GetPropertyBoolean(CimInstance instance, string property) => GetProperty<bool>(instance, property);
        public static string? GetPropertyString(CimInstance instance, string property) => GetProperty<string>(instance, property);
        public static byte? GetPropertyByte(CimInstance instance, string property) => GetProperty<byte>(instance, property);
        public static sbyte? GetPropertySByte(CimInstance instance, string property) => GetProperty<sbyte>(instance, property);
        public static ushort? GetPropertyUInt16(CimInstance instance, string property) => GetProperty<ushort>(instance, property);
        public static short? GetPropertyInt16(CimInstance instance, string property) => GetProperty<short>(instance, property);
        public static uint? GetPropertyUInt32(CimInstance instance, string property) => GetProperty<uint>(instance, property);
        public static int? GetPropertyInt32(CimInstance instance, string property) => GetProperty<int>(instance, property);
        public static UInt64? GetPropertyUInt64(CimInstance instance, string property) => GetProperty<UInt64>(instance, property);
        public static Int64? GetPropertyInt64(CimInstance instance, string property) => GetProperty<Int64>(instance, property);
        public static float? GetPropertySingle(CimInstance instance, string property) => GetProperty<float>(instance, property);
        public static double? GetPropertyDouble(CimInstance instance, string property) => GetProperty<double>(instance, property);
        public static DateTime? GetPropertyDateTime(CimInstance instance, string property) => GetProperty<DateTime>(instance, property);
        public static CimInstance? GetPropertyCimInstance(CimInstance instance, string property) => GetProperty<CimInstance>(instance, property);
        public static bool[]? GetPropertyBooleanArray(CimInstance instance, string property) => GetPropertyArray<bool>(instance, property);
        public static string[]? GetPropertyStringArray(CimInstance instance, string property) => GetPropertyArray<string>(instance, property);
        public static byte[]? GetPropertyByteArray(CimInstance instance, string property) => GetPropertyArray<byte>(instance, property);
        public static sbyte[]? GetPropertySByteArray(CimInstance instance, string property) => GetPropertyArray<sbyte>(instance, property);
        public static ushort[]? GetPropertyUInt16Array(CimInstance instance, string property) => GetPropertyArray<ushort>(instance, property);
        public static short[]? GetPropertyInt16Array(CimInstance instance, string property) => GetPropertyArray<short>(instance, property);
        public static uint[]? GetPropertyUInt32Array(CimInstance instance, string property) => GetPropertyArray<uint>(instance, property);
        public static int[]? GetPropertyInt32Array(CimInstance instance, string property) => GetPropertyArray<int>(instance, property);
        public static UInt64[]? GetPropertyUInt64Array(CimInstance instance, string property) => GetPropertyArray<UInt64>(instance, property);
        public static Int64[]? GetPropertyInt64Array(CimInstance instance, string property) => GetPropertyArray<Int64>(instance, property);
        public static float[]? GetPropertySingleArray(CimInstance instance, string property) => GetPropertyArray<float>(instance, property);
        public static double[]? GetPropertyDoubleArray(CimInstance instance, string property) => GetPropertyArray<double>(instance, property);
        public static DateTime[]? GetPropertyDateTimeArray(CimInstance instance, string property) => GetPropertyArray<DateTime>(instance, property);
        public static CimInstance[]? GetPropertyCimInstanceArray(CimInstance instance, string property) => GetPropertyArray<CimInstance>(instance, property);
    }
}
