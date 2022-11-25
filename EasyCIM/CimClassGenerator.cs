/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System.Reflection;
using System.Reflection.Emit;
using System.ComponentModel;
using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Generic;
using Microsoft.Management.Infrastructure.Options;

namespace EasyCIM
{
    public sealed class CimClassGenerator
    {
        private CimAssembly m_assembly;
        private CimSession m_localSession; // used for cim class-type lookups

        public CimAssembly Assembly { get => m_assembly; }

        public CimClassGenerator(CimAssembly cimAssembly)
        {
            m_assembly = cimAssembly;

            var sessionOptions = new DComSessionOptions { Timeout = TimeSpan.FromSeconds(30) };
            m_localSession = CimSession.Create("localhost", sessionOptions);
        }

        public T? CreateInstance<T>()
        {
            return CreateInstance<T>(null, null);
        }

        public T? CreateInstance<T>(CimSession server)
        {
            return CreateInstance<T>(server, null);
        }

        public T[]? CreateInstanceArray<T>(CimSession? server, CimInstance[]? instances)
        {
            if (instances == null)
            {
                return null;
            }
            var result = new List<T>();
            foreach (var inst in instances)
            {
                var obj = CreateInstance<T>(server, inst);
                if (obj != null)
                {
                    result.Add(obj);
                }
            }
            return result.ToArray();
        }

        public T? CreateInstance<T>(CimSession? server, CimInstance? instance)
        {
            if (server == null && instance != null)
            {
                throw new ArgumentException();
            }

            Attribute? attribute = typeof(T).GetCustomAttribute(typeof(CimClassNameAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Template interface requires CimClassName attribute");
            }
            CimClassNameAttribute cimName = (CimClassNameAttribute)attribute;

            Type? type = m_assembly.ModuleBuilder.GetType(cimName.CimClassName);
            if (type == null)
            {
                type = GenerateCimClass(typeof(T));
            }

            if (instance == null)
            {
                if (server == null)
                {
                    instance = new CimInstance(cimName.CimClassName, cimName.CimNamespace);
                }
                else
                {
                    instance = server.CreateInstance(cimName.CimNamespace, new CimInstance(cimName.CimClassName));
                }
            }

            if (server == null)
            {
                server = m_localSession;
            }

            object? result = Activator.CreateInstance(type, new object[] { this, server, instance });
            if (result == null)
            {
                return default;
            }

            return (T)result;
        }

        public Type GenerateCimClass(Type templateInterface)
        {
            Attribute? attribute = templateInterface.GetCustomAttribute(typeof(CimClassNameAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Template interface requires CimClassName attribute");
            }
            CimClassNameAttribute cimName = (CimClassNameAttribute)attribute;

            Type? type = m_assembly.ModuleBuilder.GetType(cimName.CimClassName);
            if (type != null)
            {
                return type;
            }
            return GenerateCimClass(cimName.CimNamespace, cimName.CimClassName, templateInterface);
        }

        private Type GenerateCimClass(string nameSpace, string className, Type templateInterface)
        {
            // Retrieve the class definition from WMI
            CimClass cimClass = m_localSession.GetClass(nameSpace, className);

            // Check if we already generated this class
            Type? type = m_assembly.ModuleBuilder.GetType(className);
            if (type is not null)
            {
                return type;
            }

            // Declare and define the new class type
            TypeBuilder? typeBuilder = m_assembly.ModuleBuilder.DefineType(
                className,
                TypeAttributes.Public |
                TypeAttributes.Class |
                TypeAttributes.UnicodeClass,
                null,
                new Type[] { templateInterface });

            // Add some fields all classes need
            FieldBuilder sessionField = typeBuilder.DefineField("m_session", typeof(CimSession), FieldAttributes.Private);
            FieldBuilder instanceField = typeBuilder.DefineField("m_instance", typeof(CimInstance), FieldAttributes.Private);
            FieldBuilder generatorField = typeBuilder.DefineField("m_generator", typeof(CimClassGenerator), FieldAttributes.Private);
            EventBuilder changeNotifier = typeBuilder.DefineEvent("PropertyChanged", EventAttributes.None, typeof(PropertyChangedEventHandler));

            // Generate implementation of the template interface
            GenerateConstructor(typeBuilder, generatorField, sessionField, instanceField);
            GenerateBaseObjectProperties(typeBuilder, generatorField, sessionField, instanceField);
            GenerateProperties(cimClass, typeBuilder, sessionField, instanceField, generatorField, templateInterface);
            GenerateMethods(nameSpace, className, cimClass, typeBuilder, sessionField, instanceField, generatorField, templateInterface);
            InheritInterfaces(typeBuilder, sessionField, instanceField, generatorField, templateInterface);

            type = typeBuilder.CreateType();
            if (type == null)
            {
                throw new CimException("Failed to generate CIM class");
            }

            return type;
        }

        private void GenerateConstructor(TypeBuilder typeBuilder, FieldBuilder generatorField, FieldBuilder sessionField, FieldBuilder instanceField)
        {
            ConstructorBuilder cb = typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.HasThis,
                new Type[] { typeof(CimClassGenerator), typeof(CimSession), typeof(CimInstance) });
            ILGenerator il = cb.GetILGenerator();

            // ClassName(CimClassGenerator gen, CimSession session, CimInstance instance) { m_generator = gen; m_session = session; m_instance = instance; }
            il.Emit(OpCodes.Ldarg_0); // load "this"
            il.Emit(OpCodes.Call, typeof(object).GetConstructors().Single()); // call the object ctor
            il.Emit(OpCodes.Ldarg_0); // load "this"
            il.Emit(OpCodes.Ldarg_1); // load session obj
            il.Emit(OpCodes.Stfld, generatorField); // m_generator = gen;
            il.Emit(OpCodes.Ldarg_0); // load "this"
            il.Emit(OpCodes.Ldarg_2); // load session obj
            il.Emit(OpCodes.Stfld, sessionField); // m_session = session;
            il.Emit(OpCodes.Ldarg_0); // load "this"
            il.Emit(OpCodes.Ldarg_3); // load instance obj
            il.Emit(OpCodes.Stfld, instanceField); // m_instance = instance;
            il.Emit(OpCodes.Ret);
        }

        private void GenerateBaseObjectProperties(TypeBuilder typeBuilder, FieldBuilder generatorField, FieldBuilder sessionField, FieldBuilder instanceField)
        {
            PropertyBuilder pb = typeBuilder.DefineProperty("__Generator", PropertyAttributes.None, typeof(CimClassGenerator), null);
            MethodBuilder mb = typeBuilder.DefineMethod(
                "get_" + "__Generator",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                typeof(CimClassGenerator),
                Type.EmptyTypes);

            ILGenerator il = mb.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);              // load "this"
            il.Emit(OpCodes.Ldfld, generatorField); // load m_generator
            il.Emit(OpCodes.Ret);
            pb.SetGetMethod(mb);

            pb = typeBuilder.DefineProperty("__Instance", PropertyAttributes.None, typeof(CimInstance), null);
            mb = typeBuilder.DefineMethod(
                "get_" + "__Instance",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                typeof(CimInstance),
                Type.EmptyTypes);

            il = mb.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);              // load "this"
            il.Emit(OpCodes.Ldfld, instanceField); // load m_instance
            il.Emit(OpCodes.Ret);
            pb.SetGetMethod(mb);

            pb = typeBuilder.DefineProperty("__Session", PropertyAttributes.None, typeof(CimSession), null);
            mb = typeBuilder.DefineMethod(
                "get_" + "__Session",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                typeof(CimSession),
                Type.EmptyTypes);

            il = mb.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);             // load "this"
            il.Emit(OpCodes.Ldfld, sessionField); // load m_session
            il.Emit(OpCodes.Ret);
            pb.SetGetMethod(mb);
        }

        private void GenerateProperties(CimClass cimClass, TypeBuilder typeBuilder, FieldBuilder sessionField, FieldBuilder instanceField, FieldBuilder generatorField, Type templateInterface)
        {
            foreach (CimPropertyDeclaration property in cimClass.CimClassProperties)
            {
                GenerateProperty(property, typeBuilder, sessionField, instanceField, generatorField, templateInterface);
            }
        }

        private void GenerateMethods(
            string nameSpace,
            string className,
            CimClass cimClass,
            TypeBuilder typeBuilder,
            FieldBuilder sessionField,
            FieldBuilder instanceField,
            FieldBuilder generatorField,
            Type templateInterface)
        {
            foreach (CimMethodDeclaration method in cimClass.CimClassMethods)
            {
                GenerateMethod(nameSpace, className, method, typeBuilder, sessionField, instanceField, generatorField, templateInterface);
            }
        }

        private void InheritInterfaces(TypeBuilder typeBuilder, FieldBuilder sessionField, FieldBuilder instanceField, FieldBuilder generatorField, Type templateInterface)
        {
            foreach (Type inf in templateInterface.GetInterfaces())
            {
                Attribute? attribute = inf.GetCustomAttribute(typeof(CimBaseAttribute));
                if (attribute is not null)
                {
                    InheritInterface(typeBuilder, sessionField, instanceField, generatorField, inf);
                }
            }
        }

        private void InheritInterface(TypeBuilder typeBuilder, FieldBuilder sessionField, FieldBuilder instanceField, FieldBuilder generatorField, Type templateInterface)
        {
            //typeBuilder.AddInterfaceImplementation(templateInterface);
            foreach (PropertyInfo property in templateInterface.GetProperties())
            {
                Attribute? attribute = property.GetCustomAttribute(typeof(CimIgnoreAttribute));
                if (attribute != null)
                {
                    continue;
                }

                PropertyBuilder pb = typeBuilder.DefineProperty(property.Name, PropertyAttributes.None, property.PropertyType, null);
                GeneratePropertyGetter(typeBuilder, sessionField, instanceField, generatorField, pb, property.Name, property.PropertyType);
            }
            InheritInterfaces(typeBuilder, sessionField, instanceField, generatorField, templateInterface);
        }

        private void GenerateProperty(CimPropertyDeclaration property, TypeBuilder typeBuilder, FieldBuilder sessionField, FieldBuilder instanceField, FieldBuilder generatorField, Type templateInterface)
        {
            PropertyInfo? info = templateInterface.GetProperty(property.Name);
            if (info == null)
            {
                // Unused property
                return;
            }

            Attribute? attribute = info.GetCustomAttribute(typeof(CimIgnoreAttribute));
            if (attribute != null)
            {
                return;
            }

            bool isKey = info.GetCustomAttribute(typeof(CimKeyAttribute)) != null;

            // Nullable value types will actually be wrapped in a System.Nullable, while references will be annotated
            Type? templateType = info.PropertyType;
            if (templateType.IsValueType)
            {
                templateType = Nullable.GetUnderlyingType(templateType);
                if (templateType == null)
                {
                    throw new InvalidCastException("CIM property type must be nullable: " + info.PropertyType.Name);
                }
            }

            // Convert the incoming CIM type to a .net type
            Type propertyType = ConvertCimType(property.CimType);

            // If the template interface type doesn't match, then this is an override of the property's type
            if (templateType != propertyType)
            {
                // Make sure the override type is safe to use
                if (templateType.IsEnum)
                {
                    if (templateType.GetEnumUnderlyingType() != propertyType)
                    {
                        throw new InvalidCastException("CIM property type override underlying type must match: " + templateType.Name + " = " + propertyType.Name);
                    }
                }
                else
                {
                    Type? checkType = templateType.IsArray ? templateType.GetElementType() : templateType;
                    if (checkType == null || !typeof(ICimObject).IsAssignableFrom(checkType))
                    {
                        throw new InvalidCastException("CIM property type override must be an enum or derived from ICimObject");
                    }
                }
            }

            // Determine if the CIM property is readable/writeable
            bool write = false;
            bool read = true;
            foreach (CimQualifier qualifier in property.Qualifiers)
            {
                switch (qualifier.Name.ToLower())
                {
                    case "write":
                        write = true;
                        break;
                    default:
                        continue;
                }
            }

            bool readNullable = IsReadNullable(info);
            bool writeNullable = IsWriteNullable(info);

            if (!read && !write)
            {
                throw new InvalidCastException("CIM property inaccessible: " + info.PropertyType.Name);
            }
            //else if (read != info.CanRead || write != info.CanWrite)
            //{
            //    throw new InvalidCastException("CIM property getter/setter mismatch: " + info.PropertyType.Name);
            //}
            else if (read && !IsReadNullable(info))
            {
                throw new InvalidCastException("CIM property type must be nullable: " + info.PropertyType.Name);
            }

            // Generate the property and getter
            PropertyBuilder pb = typeBuilder.DefineProperty(property.Name, PropertyAttributes.None, info.PropertyType, null);
            if (info.CanRead)
            {
                GeneratePropertyGetter(typeBuilder, sessionField, instanceField, generatorField, pb, property.Name, info.PropertyType);
            }
            if (info.CanWrite)
            {
                CimFlags flags = CimFlags.None;
                if (property.CimType == CimType.Instance)
                {
                    flags |= CimFlags.Reference;
                }
                if (isKey)
                {
                    flags |= CimFlags.Key;
                }
                GeneratePropertySetter(typeBuilder, instanceField, pb, property.Name, info.PropertyType, property.CimType, flags);
            }
        }

        private void GeneratePropertyGetter(TypeBuilder typeBuilder, FieldBuilder sessionField, FieldBuilder instanceField, FieldBuilder generatorField, PropertyBuilder propBuilder, string name, Type type)
        {
            Type? implType = Nullable.GetUnderlyingType(type);
            if (implType == null)
            {
                implType = type;
            }

            Type? elemType = null;
            string impl = "GetProperty";
            if (implType.IsArray)
            {
                elemType = implType.GetElementType();
                string? typeName = typeof(ICimObject).IsAssignableFrom(elemType) ? "CimInstance" : elemType?.Name;
                string? array = typeName + "Array";
                if (array == null)
                {
                    throw new InvalidOperationException("Unexpected null type");
                }
                impl += array;
            }
            else if (implType.IsEnum)
            {
                elemType = implType.GetEnumUnderlyingType();
                impl += elemType.Name;
            }
            else
            {
                elemType = implType;
                impl += typeof(ICimObject).IsAssignableFrom(elemType) ? "CimInstance" : elemType?.Name;
            }

            MethodInfo? mi = typeof(CimClassImpl).GetMethod(impl, new Type[] { typeof(CimInstance), typeof(string) });
            MethodInfo? fromInstance = typeof(CimClassImpl).GetMethod("FromInstance", new Type[] { typeof(CimInstance), typeof(CimClassGenerator), typeof(CimSession) });
            MethodInfo? fromInstanceArray = typeof(CimClassImpl).GetMethod("FromInstanceArray", new Type[] { typeof(CimInstance[]), typeof(CimClassGenerator), typeof(CimSession) });
            if (mi == null || fromInstance == null || fromInstanceArray == null)
            {
                throw new InvalidOperationException("Unexpected null type");
            }

            MethodBuilder mb = typeBuilder.DefineMethod(
                "get_" + name,
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                type,
                Type.EmptyTypes);

            ILGenerator il = mb.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);              // load "this"
            il.Emit(OpCodes.Ldfld, instanceField); // load m_instance
            il.Emit(OpCodes.Ldstr, name);          // load property name
            il.Emit(OpCodes.Call, mi);             // call CimClassImpl.GetProperty[Type](m_instance, propertyName)
            if (typeof(ICimObject).IsAssignableFrom(elemType))
            {
                il.Emit(OpCodes.Ldarg_0);               // load "this"
                il.Emit(OpCodes.Ldfld, generatorField); // load m_generator
                il.Emit(OpCodes.Ldarg_0);               // load "this"
                il.Emit(OpCodes.Ldfld, sessionField);   // load m_instance
                if (implType.IsArray)
                {
                    il.Emit(OpCodes.Call, fromInstanceArray.MakeGenericMethod(elemType));
                }
                else
                {
                    il.Emit(OpCodes.Call, fromInstance.MakeGenericMethod(type));
                }
            }
            il.Emit(OpCodes.Ret);

            propBuilder.SetGetMethod(mb);
        }

        private void GeneratePropertySetter(
            TypeBuilder typeBuilder,
            FieldBuilder instanceField,
            PropertyBuilder propBuilder,
            string name,
            Type type,
            CimType cimType,
            CimFlags flags)
        {
            Type? implType = Nullable.GetUnderlyingType(type);
            if (implType == null)
            {
                implType = type;
            }
            if (type.IsEnum)
            {
                implType = implType.GetEnumUnderlyingType();
            }

            MethodInfo? setValue = typeof(CimClassImpl).GetMethod("SetProperty", new Type[] { typeof(CimInstance), typeof(string), typeof(object), typeof(CimType), typeof(CimFlags) });
            Type? nullableType = MakeNullableType(type);
            MethodInfo? checkNull = typeof(CimClassImpl).GetMethod("CheckNull");
            if (setValue == null || checkNull == null)
            {
                throw new InvalidOperationException("Unexpected null type");
            }

            MethodBuilder mb = typeBuilder.DefineMethod(
                "set_" + name,
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual,
                typeof(void),
                new Type[] { type });

            ILGenerator il = mb.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);                // load "this"
            il.Emit(OpCodes.Ldfld, instanceField);   // load m_instance
            il.Emit(OpCodes.Ldstr, name);            // load property name
            il.Emit(OpCodes.Ldarg_1);                // load 'value'
            if (implType.IsValueType)
            {
                il.Emit(OpCodes.Box, nullableType);
            }
            il.Emit(OpCodes.Call, checkNull);
            il.Emit(OpCodes.Ldc_I4_S, (int)cimType);
            il.Emit(OpCodes.Ldc_I4_S, (int)flags);
            il.Emit(OpCodes.Conv_I8);
            il.Emit(OpCodes.Call, setValue);
            il.Emit(OpCodes.Ret);

            propBuilder.SetSetMethod(mb);
        }

        private void GenerateMethod(
            string nameSpace,
            string className,
            CimMethodDeclaration method,
            TypeBuilder typeBuilder,
            FieldBuilder sessionField,
            FieldBuilder instanceField,
            FieldBuilder generatorField,
            Type templateInterface)
        {
            MethodInfo? info = templateInterface.GetMethod(method.Name);
            if (info == null)
            {
                // Unused method
                return;
            }

            if (info.GetCustomAttribute<CimIgnoreAttribute>() != null)
            {
                return;
            }
            bool isStatic = info.GetCustomAttribute<CimStaticAttribute>() != null;

            // Make sure all the parameters are correct
            Type returnType = ConvertCimType(method.ReturnType);
            if (info.ReturnType != returnType)
            {
                if (!info.ReturnType.IsEnum || info.ReturnType.GetEnumUnderlyingType() != returnType)
                {
                    throw new InvalidCastException("method return type does not match");
                }
                returnType = info.ReturnType;
            }
            else if (info.GetParameters().Length > method.Parameters.Count)
            {
                throw new InvalidCastException("too many parameters for method");
            }

            Type[] parameters = new Type[info.GetParameters().Length];

            int i = -1;
            foreach (ParameterInfo param in info.GetParameters())
            {
                ++i;
                CimMethodParameterDeclaration cimParam = method.Parameters[param.Name];
                if (cimParam == null)
                {
                    throw new InvalidCastException("unknown method parameter");
                }

                bool isOutput = param.IsOut;
                bool isRef = !param.IsOut && param.ParameterType.IsByRef;

                bool cimInput = cimParam.Qualifiers["IN"] != null;
                bool cimOutput = cimParam.Qualifiers["OUT"] != null;
                Type cimType = ConvertCimType(cimParam.CimType);

                if (cimInput && cimOutput)
                {
                    if (!isRef)
                    {
                        throw new InvalidCastException("parameter must pass by ref");
                    }
                }
                else if (cimOutput)
                {
                    if (!isOutput)
                    {
                        throw new InvalidCastException("parameter must pass by out");
                    }
                    if (!IsWriteNullable(param))
                    {
                        throw new InvalidCastException("out parameter must be nullable");
                    }
                    if (GetNullableRefUnderlyingType(param.ParameterType) != cimType && cimType != typeof(CimInstance) && cimType != typeof(CimInstance[]))
                    {
                        throw new InvalidCastException("method parameter type does not match");
                    }
                }
                else if (cimInput)
                {
                    if (isOutput || isRef)
                    {
                        throw new InvalidCastException("parameter must not pass by out or ref");
                    }
                    if (param.ParameterType != cimType)
                    {
                        if (cimType != typeof(CimInstance) && cimType != typeof(CimInstance[]) &&
                            (!param.ParameterType.IsEnum || param.ParameterType.GetEnumUnderlyingType() != cimType))
                        {
                            throw new InvalidCastException("method parameter type does not match");
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("cim parameter not marked as in or out");
                }

                parameters[i] = param.ParameterType;
            }

            // Generate the actual method
            MethodBuilder mb = typeBuilder.DefineMethod(
                info.Name,
                MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.Final | MethodAttributes.NewSlot,
                returnType,
                parameters);

            ConstructorInfo? ctor = typeof(CimMethodParametersCollection).GetConstructor(Type.EmptyTypes);
            MethodInfo? createParam = typeof(CimMethodParameter).GetMethod("Create", new Type[] { typeof(string), typeof(object), typeof(CimType), typeof(CimFlags) });
            MethodInfo? addParam = typeof(CimMethodParametersCollection).GetMethod("Add", new Type[] { typeof(CimMethodParameter) });
            MethodInfo? getInstance = typeof(ICimObject).GetMethod("get___Instance");
            MethodInfo? invokeMethod = typeof(CimSession).GetMethod("InvokeMethod", new Type[] { typeof(string), typeof(CimInstance), typeof(string), typeof(CimMethodParametersCollection) });
            MethodInfo? invokeStaticMethod = typeof(CimSession).GetMethod("InvokeMethod", new Type[] { typeof(string), typeof(string), typeof(string), typeof(CimMethodParametersCollection) });
            MethodInfo? getValue = typeof(CimMethodParameter).GetMethod("get_Value", Type.EmptyTypes);
            MethodInfo? getOutParams = typeof(CimMethodResult).GetMethod("get_OutParameters", Type.EmptyTypes);
            MethodInfo? getItem = typeof(CimReadOnlyKeyedCollection<CimMethodParameter>).GetMethod("get_Item", new Type[] { typeof(string) });
            MethodInfo? getOutParameter = typeof(CimClassImpl).GetMethod("GetOutParameter", new Type[] { typeof(CimMethodResult), typeof(string) });
            MethodInfo? getOutParameterEx = typeof(CimClassImpl).GetMethod("GetOutParameter", new Type[] { typeof(CimClassGenerator), typeof(CimSession), typeof(CimMethodResult), typeof(string) });
            MethodInfo? getReturnValue = typeof(CimClassImpl).GetMethod("GetReturnValue", new Type[] { typeof(CimMethodResult) });
            MethodInfo? toInstanceArray = typeof(CimClassImpl).GetMethod("ToInstanceArray");
            if (ctor == null || createParam == null || addParam == null || getInstance == null || invokeMethod == null || invokeStaticMethod == null || toInstanceArray == null ||
                getValue == null || getOutParams == null || getItem == null || getOutParameter == null || getOutParameterEx == null || getReturnValue == null)
            {
                throw new InvalidOperationException("Unexpected null type");
            }

            // CimMethodParametersCollection parameters = new CimMethodParametersCollection();
            ILGenerator il = mb.GetILGenerator();

            LocalBuilder collection = il.DeclareLocal(typeof(CimMethodParametersCollection));
            LocalBuilder results = il.DeclareLocal(typeof(CimMethodResult));

            il.Emit(OpCodes.Newobj, ctor);
            il.Emit(OpCodes.Stloc_0); // parameters object

            // Build parameters collection
            i = 0;
            foreach (ParameterInfo param in info.GetParameters())
            {
                ++i;
                if (param.IsOut || param.Name == null)
                {
                    continue;
                }

                // parameters.Add(CimMethodParameter.Create("param", val, CimFlags.In));
                il.Emit(OpCodes.Ldloc_0); // parameters
                il.Emit(OpCodes.Ldstr, param.Name);
                il.Emit(OpCodes.Ldarg, i);
                if (typeof(ICimObject).IsAssignableFrom(param.ParameterType))
                {
                    il.Emit(OpCodes.Callvirt, getInstance);
                }
                else if (param.ParameterType.IsValueType)
                {
                    il.Emit(OpCodes.Box, param.ParameterType);
                }
                else if (param.ParameterType.IsArray && typeof(ICimObject).IsAssignableFrom(param.ParameterType.GetElementType()))
                {
                    il.Emit(OpCodes.Call, toInstanceArray.MakeGenericMethod(param.ParameterType.GetElementType()!));
                }
                il.Emit(OpCodes.Ldc_I4_S, (char)method.Parameters[param.Name].CimType);
                il.Emit(OpCodes.Ldc_I4, (int)CimFlags.In);
                il.Emit(OpCodes.Conv_I8);
                il.Emit(OpCodes.Call, createParam);
                il.Emit(OpCodes.Callvirt, addParam);
            }

            // Call the method
            if (isStatic)
            {
                // CimMethodResult results = m_session.InvokeMethod(nameSpace, className, "method", parameters);
                il.Emit(OpCodes.Ldarg_0); // this
                il.Emit(OpCodes.Ldfld, sessionField);
                il.Emit(OpCodes.Ldstr, nameSpace);
                il.Emit(OpCodes.Ldstr, className);
                il.Emit(OpCodes.Ldstr, method.Name);
                il.Emit(OpCodes.Ldloc_0); // parameters
                il.Emit(OpCodes.Callvirt, invokeStaticMethod);
                il.Emit(OpCodes.Stloc_1); // results
            }
            else
            {
                // CimMethodResult results = m_session.InvokeMethod(m_instance, "method", parameters);
                il.Emit(OpCodes.Ldarg_0); // this
                il.Emit(OpCodes.Ldfld, sessionField);
                il.Emit(OpCodes.Ldstr, nameSpace);
                il.Emit(OpCodes.Ldarg_0); // this
                il.Emit(OpCodes.Ldfld, instanceField);
                il.Emit(OpCodes.Ldstr, method.Name);
                il.Emit(OpCodes.Ldloc_0); // parameters
                il.Emit(OpCodes.Callvirt, invokeMethod);
                il.Emit(OpCodes.Stloc_1); // results
            }

            // Get output parameters
            i = 0;
            foreach (ParameterInfo param in info.GetParameters())
            {
                ++i;
                if (!param.IsOut || param.Name == null)
                {
                    continue;
                }

                Type? elemType = param.ParameterType.GetElementType();
                if (elemType == null)
                {
                    throw new InvalidOperationException("Unexpected null type");
                }
                Type? underlyingType = Nullable.GetUnderlyingType(elemType);

                if (typeof(ICimObject).IsAssignableFrom(elemType) || (elemType.IsArray && typeof(ICimObject).IsAssignableFrom(elemType.GetElementType())))
                {
                    // param = CimClassImpl.GetOutParameter<T>(instanceType, m_session, results, "param");
                    il.Emit(OpCodes.Ldarg, i);
                    il.Emit(OpCodes.Ldarg_0); // this
                    il.Emit(OpCodes.Ldfld, generatorField);
                    il.Emit(OpCodes.Ldarg_0); // this
                    il.Emit(OpCodes.Ldfld, sessionField);
                    il.Emit(OpCodes.Ldloc_1); // results
                    il.Emit(OpCodes.Ldstr, param.Name);
                    il.Emit(OpCodes.Call, getOutParameterEx.MakeGenericMethod(elemType));
                    il.Emit(OpCodes.Stind_Ref);
                }
                else if (underlyingType != null)
                {
                    ConstructorInfo? pctor = elemType.GetConstructor(new Type[] { underlyingType });
                    if (pctor == null)
                    {
                        throw new InvalidOperationException("Unexpected null type");
                    }

                    // param = CimClassImpl.GetOutParameter<T>(results, "param");
                    il.Emit(OpCodes.Ldarg, i);
                    il.Emit(OpCodes.Ldloc_1); // results
                    il.Emit(OpCodes.Ldstr, param.Name);
                    il.Emit(OpCodes.Call, getOutParameter.MakeGenericMethod(underlyingType));
                    il.Emit(OpCodes.Newobj, pctor);
                    il.Emit(OpCodes.Stobj, elemType);
                }
                else
                {
                    il.Emit(OpCodes.Ldarg, i);
                    il.Emit(OpCodes.Ldloc_1); // results
                    il.Emit(OpCodes.Ldstr, param.Name);
                    il.Emit(OpCodes.Call, getOutParameter.MakeGenericMethod(elemType));
                    il.Emit(OpCodes.Stind_Ref);
                }
            }

            // return CimClassImpl.GetReturnValue<T>(results);
            il.Emit(OpCodes.Ldloc_1);
            il.Emit(OpCodes.Call, getReturnValue.MakeGenericMethod(returnType));
            il.Emit(OpCodes.Ret);
        }

        private Type ConvertCimType(CimType type)
        {
            if (type == CimType.DateTime)
            {
                return typeof(DateTime);
            }
            return CimConverter.GetDotNetType(type);
        }

        private bool IsReadNullable(PropertyInfo pi)
        {
            NullabilityInfoContext ctx = new();
            NullabilityInfo propInfo = ctx.Create(pi);
            return propInfo.ReadState == NullabilityState.Nullable;
        }

        private bool IsWriteNullable(PropertyInfo pi)
        {
            NullabilityInfoContext ctx = new();
            NullabilityInfo paramInfo = ctx.Create(pi);
            return paramInfo.WriteState == NullabilityState.Nullable;
        }

        private bool IsWriteNullable(ParameterInfo pi)
        {
            NullabilityInfoContext ctx = new();
            NullabilityInfo paramInfo = ctx.Create(pi);
            return paramInfo.WriteState == NullabilityState.Nullable;
        }

        private Type MakeNullableType(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            if (type.IsValueType)
            {
                if (type.IsEnum)
                {
                    type = type.GetEnumUnderlyingType();
                }
                return typeof(Nullable<>).MakeGenericType(type);
            }
            return type;
        }

        private Type? GetNullableRefUnderlyingType(Type type)
        {
            if (!type.IsByRef)
            {
                throw new ArgumentException("type must be pass-by-reference");
            }
            Type? elemType = type.GetElementType();
            if (elemType != null)
            {
                Type? nullableType = Nullable.GetUnderlyingType(elemType);
                if (nullableType != null)
                {
                    return nullableType;
                }
                return elemType;
            }
            return null;
        }
    }
}
