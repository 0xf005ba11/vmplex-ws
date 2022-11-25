/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using Microsoft.Management.Infrastructure;
using System.Reflection;

namespace EasyCIM
{
    [CimBase]
    public interface ICimObject
    {
        [CimIgnore]
        CimClassGenerator __Generator { get; }

        [CimIgnore]
        CimSession __Session { get; }

        [CimIgnore]
        CimInstance __Instance { get; }

        [CimIgnore]
        public T CastTo<T>()
        {
            Attribute? attribute = typeof(T).GetCustomAttribute(typeof(CimClassNameAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Template interface requires CimClassName attribute");
            }
            CimClassNameAttribute resultName = (CimClassNameAttribute)attribute;

            T? ret = __Generator.CreateInstance<T>(__Session, __Instance);
            if (ret == null)
            {
                throw new InvalidCastException();
            }
            return ret;
        }

        [CimIgnore]
        public T[] GetAssociated<T>(string association)
        {
            Attribute? attribute = typeof(T).GetCustomAttribute(typeof(CimClassNameAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Template interface requires CimClassName attribute");
            }
            CimClassNameAttribute resultName = (CimClassNameAttribute)attribute;

            var list = __Session.EnumerateAssociatedInstances(
                resultName.CimNamespace,
                __Instance,
                association,
                resultName.CimClassName,
                null,
                null);
            return CimClassImpl.FromInstanceEnumerable<T>(list, __Generator, __Session)!;
        }
    }
}
