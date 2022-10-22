using ORMi.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ORMi
{
    /// <summary>
    /// Static class for WMI method helpers.
    /// </summary>
    public static class WMIMethod
    {
        /// <summary>
        /// Executes an WMI instance method with no parameter. Returns dynamic object.
        /// </summary>
        /// <param name="obj">Instance which will be instanciated to call the method.</param>
        /// <returns></returns>
        public static dynamic ExecuteMethod(object obj)
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

#if NET45
            WindowsImpersonationContext impersonatedUser = windowsIdentity.Impersonate();
#endif
#if NETSTANDARD20
            return WindowsIdentity.RunImpersonated(windowsIdentity.AccessToken, () =>
#endif
            {
                var mth = new StackTrace().GetFrame(1).GetMethod();
                string methodName = mth.Name;

                ManagementClass genericClass = new ManagementClass(TypeHelper.GetNamespace(obj), TypeHelper.GetClassName(obj), null);

                ManagementObject instance = TypeHelper.GetManagementObject(genericClass, obj);

                ManagementBaseObject result = instance.InvokeMethod(methodName, null, null);

                return result == null ? null : TypeHelper.LoadDynamicObject(result);
            }
#if NETSTANDARD20
                );
#endif
        }

        /// <summary>
        /// Executes WMI instance method with no parameter. Returns an object of specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Instance which will be instanciated to call the method.</param>
        /// <returns></returns>
        public static T ExecuteMethod<T>(object obj)
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

#if NET45
            WindowsImpersonationContext impersonatedUser = windowsIdentity.Impersonate();
#endif
#if NETSTANDARD20
            return WindowsIdentity.RunImpersonated(windowsIdentity.AccessToken, () =>
#endif
            {
                var mth = new StackTrace().GetFrame(1).GetMethod();
                string methodName = mth.Name;

                ManagementClass genericClass = new ManagementClass(TypeHelper.GetNamespace(obj), TypeHelper.GetClassName(obj), null);

                ManagementObject instance = TypeHelper.GetManagementObject(genericClass, obj);

                ManagementBaseObject result = instance.InvokeMethod(methodName, null, null);

                return (T)TypeHelper.LoadObject(result, typeof(T));
            }
#if NETSTANDARD20
                );
#endif
        }

        /// <summary>
        /// Executes an instance method with parameters. Returns a dynamic object.
        /// </summary>
        /// <param name="obj">Instance which will be instanciated to call the method.</param>
        /// <param name="parameters">Anonymous object with properties matching the parameter names of the method.</param>
        /// <returns></returns>
        public static dynamic ExecuteMethod(object obj, dynamic parameters, string name = null)
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

#if NET45
            WindowsImpersonationContext impersonatedUser = windowsIdentity.Impersonate();
#endif
#if NETSTANDARD20
            return WindowsIdentity.RunImpersonated(windowsIdentity.AccessToken, () =>
#endif
            {
                var frame = new StackTrace().GetFrames().Skip(1).First(x => x.GetMethod().DeclaringType.Namespace != "System.Dynamic");

                string methodName = name == null ? frame.GetMethod().Name : name;

                ManagementClass genericClass = new ManagementClass(TypeHelper.GetNamespace(obj), TypeHelper.GetClassName(obj), null);

                ManagementObject instance = TypeHelper.GetManagementObject(genericClass, obj);

                ManagementBaseObject inParams = genericClass.GetMethodParameters(methodName);

                foreach (PropertyInfo p in parameters.GetType().GetProperties())
                {
                    inParams[p.Name] = p.GetValue(parameters);
                }

                ManagementBaseObject result = instance.InvokeMethod(methodName, inParams, null);

                return result;
                //return result == null ? null : TypeHelper.LoadDynamicObject(result);
            }
#if NETSTANDARD20
                );
#endif
        }

        /// <summary>
        /// Executes an instance method with parameters. Returns an object of specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T ExecuteMethod<T>(object obj, dynamic parameters)
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

#if NET45
            WindowsImpersonationContext impersonatedUser = windowsIdentity.Impersonate();
#endif
#if NETSTANDARD20
            return WindowsIdentity.RunImpersonated(windowsIdentity.AccessToken, () =>
#endif
            {
                var frame = new StackTrace().GetFrames().Skip(1).First(x => x.GetMethod().DeclaringType.Namespace != "System.Dynamic");

                string methodName = frame.GetMethod().Name;

                ManagementClass genericClass = new ManagementClass(TypeHelper.GetNamespace(obj), TypeHelper.GetClassName(obj), null);

                ManagementObject instance = TypeHelper.GetManagementObject(genericClass, obj);

                ManagementBaseObject inParams = genericClass.GetMethodParameters(methodName);

                foreach (PropertyInfo p in parameters.GetType().GetProperties())
                {
                    inParams[p.Name] = p.GetValue(parameters);
                }

                ManagementBaseObject result = instance.InvokeMethod(methodName, inParams, null);

                return (T)TypeHelper.LoadObject(result, typeof(T));
            }
#if NETSTANDARD20
                );
#endif
        }

        /// <summary>
        /// Executes a static method without parameters.
        /// </summary>
        /// <returns></returns>
        public static dynamic ExecuteStaticMethod()
        {
            var mth = new StackTrace().GetFrame(1).GetMethod();
            string methodName = mth.Name;

            Type t = mth.ReflectedType;

            ManagementClass cls = new ManagementClass(TypeHelper.GetNamespace(t), TypeHelper.GetClassName(t), null);

            ManagementBaseObject result = cls.InvokeMethod(methodName, null, null);

            return result == null ? null : TypeHelper.LoadDynamicObject(result);
        }

        /// <summary>
        /// Executes a static method without parameters. Returns an object of specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ExecuteStaticMethod<T>()
        {
            var mth = new StackTrace().GetFrame(1).GetMethod();
            string methodName = mth.Name;

            Type t = mth.ReflectedType;

            ManagementClass cls = new ManagementClass(TypeHelper.GetNamespace(t), TypeHelper.GetClassName(t), null);

            ManagementBaseObject result = cls.InvokeMethod(methodName, null, null);

            return (T)TypeHelper.LoadObject(result, typeof(T));
        }

        /// <summary>
        /// Executes a static method with parameters.
        /// </summary>
        /// <param name="parameters">Anonymous object with properties matching the WMI method parameters</param>
        /// <returns></returns>
        public static dynamic ExecuteStaticMethod(dynamic parameters)
        {
            var frame = new StackTrace().GetFrames().Skip(2).First(x => x.GetMethod().DeclaringType.Namespace != "System.Dynamic");

            string methodName = frame.GetMethod().Name;

            Type t = frame.GetMethod().ReflectedType;

            ManagementClass cls = new ManagementClass(TypeHelper.GetNamespace(t), TypeHelper.GetClassName(t), null);

            ManagementBaseObject inParams = cls.GetMethodParameters(methodName);

            foreach (PropertyInfo p in parameters.GetType().GetProperties())
            {
                inParams[p.Name] = p.GetValue(parameters);
            }

            ManagementBaseObject result = cls.InvokeMethod(methodName, inParams, null);

            return result == null ? null : TypeHelper.LoadDynamicObject(result);
        }

        /// <summary>
        /// Executes a static method with parameters. Returns an object of specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T ExecuteStaticMethod<T>(dynamic parameters)
        {
            var frame = new StackTrace().GetFrames().Skip(2).First(x => x.GetMethod().DeclaringType.Namespace != "System.Dynamic");

            string methodName = frame.GetMethod().Name;

            Type t = frame.GetMethod().ReflectedType;

            ManagementClass cls = new ManagementClass(TypeHelper.GetNamespace(t), TypeHelper.GetClassName(t), null);

            ManagementBaseObject inParams = cls.GetMethodParameters(methodName);

            foreach (PropertyInfo p in parameters.GetType().GetProperties())
            {
                inParams[p.Name] = p.GetValue(parameters);
            }

            ManagementBaseObject result = cls.InvokeMethod(methodName, inParams, null);

            return (T)TypeHelper.LoadObject(result, typeof(T));
        }
    }
}
