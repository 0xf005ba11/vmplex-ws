using ORMi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ORMi
{
    public class WMIHelper
    {
        public ManagementScope Scope { get;set; }

        /// <summary>
        /// Creates a WMIHelper object targeting the desired scope. Default credentials are used.
        /// </summary>
        /// <param name="scope">WMI namespace</param>
        public WMIHelper(string scope)
        {
            Scope = new ManagementScope(scope);
            Scope.Options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate
            };
        }

        /// <summary>
        /// Creates a WMIHelper object targeting the desired scope on the specified hostname. Beware that in order to make WMI calls work, the user running the application must have the corresponding privileges on the client machine. Otherwise it will throw an 'Access Denied' exception.
        /// </summary>
        /// <param name="scope">WMI namespace</param>
        /// <param name="hostname">Client machine</param>
        public WMIHelper(string scope, string hostname)
        {
            Scope = new ManagementScope(String.Format("\\\\{0}\\{1}", hostname, scope));
            Scope.Options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate
            };
        }

        /// <summary>
        /// Creates a WMIHelper object targeting the desired scope on the specified hostname with specified credentials.
        /// </summary>
        /// <param name="scope">WMI namespace</param>
        /// <param name="hostname">Client machine</param>
        /// <param name="username">Username that will make the WMI connection</param>
        /// <param name="password">The username´s password</param>
        public WMIHelper(string scope, string hostname, string username, string password)
        {
            Scope = new ManagementScope(String.Format("\\\\{0}\\{1}", hostname, scope));
            Scope.Options = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                Authentication = AuthenticationLevel.Default,
                Username = username,
                Password = password
            };
        }

        #region CRUD Operations

        /// <summary>
        /// Adds a new WMI Instance
        /// </summary>
        /// <param name="obj">Object to add. The classname and properties or corresponding attributes will be maped to the corresponding WMI structure</param>
        public void AddInstance(object obj)
        {
            try
            {
                Scope.Path.ClassName = TypeHelper.GetClassName(obj);

                ManagementClass genericClass = new ManagementClass(Scope.Path);

                ManagementObject genericInstance = TypeHelper.GetManagementObject(genericClass, obj);

                genericInstance.Put();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds a new WMI Instance asynchronously
        /// </summary>
        /// <param name="obj">Object to add. The classname and properties or corresponding attributes will be maped to the corresponding WMI structure</param>
        /// <returns></returns>
        public async Task AddInstanceAsync(object obj)
        {
            await Task.Run(() => AddInstance(obj));
        }

        /// <summary>
        /// Modifies an existing instance.
        /// </summary>
        /// <param name="obj">Object to be updated. ORMi will search the property with the SearchKey attribute. That value is going to be used to make the update.</param>
        public void UpdateInstance(object obj)
        {
            try
            {
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

#if NET45
                WindowsImpersonationContext impersonatedUser = windowsIdentity.Impersonate();
#endif
#if NETSTANDARD20
                WindowsIdentity.RunImpersonated(windowsIdentity.AccessToken, () =>
#endif
                {
                    string className = TypeHelper.GetClassName(obj);

                    string query = String.Format("SELECT * FROM {0}", TypeHelper.GetClassName(obj));

                    List<WMISearchKey> keys = TypeHelper.GetSearchKeys(obj);

                    if (keys.Count > 0)
                    {
                        for (int i = 0; i < keys.Count; i++)
                        {
                            if (i == 0)
                            {
                                query = String.Format("{0} WHERE {1} = '{2}'", query, keys[i].Name, keys[i].Value);
                            }
                            else
                            {
                                query = String.Format("{0} AND {1} = '{2}'", query, keys[i].Name, keys[i].Value);
                            }
                        }

                        ManagementObjectSearcher searcher;
                        searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query));

                        ManagementObjectCollection col = searcher.Get();

                        foreach (ManagementObject m in searcher.Get())
                        {
                            foreach (PropertyInfo p in obj.GetType().GetProperties())
                            {
                                if (p.GetValue(obj) != null)
                                {
                                    WMIIgnore ignoreProp = p.GetCustomAttribute<WMIIgnore>();
                                    WMIIgnoreOnUpdate ignoreOnUpdateProp = p.GetCustomAttribute<WMIIgnoreOnUpdate>();

                                    if (ignoreProp == null && ignoreOnUpdateProp == null)
                                    {
                                        WMIProperty propAtt = p.GetCustomAttribute<WMIProperty>();

                                        if (propAtt != null)
                                        {
                                            m[propAtt.Name] = p.GetValue(obj).GetType() == typeof(DateTime) ? ManagementDateTimeConverter.ToDmtfDateTime(Convert.ToDateTime(p.GetValue(obj))) : p.GetValue(obj);
                                        }
                                        else
                                        {
                                            m[p.Name] = p.GetValue(obj).GetType() == typeof(DateTime) ? ManagementDateTimeConverter.ToDmtfDateTime(Convert.ToDateTime(p.GetValue(obj))) : p.GetValue(obj);
                                        }
                                    }
                                }
                            }

                            m.Put();
                        }
                    }
                    else
                    {
                        throw new WMISearchKeyException("There is no SearchKey specified for the object");
                    }
                }
#if NETSTANDARD20
                );
#endif
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifies an existing instance asynchonously.
        /// </summary>
        /// <param name="obj">Object to be updated. ORMi will search the property with the SearchKey attribute. That value is going to be used to make the update.</param>
        /// <returns></returns>
        public async Task UpdateInstanceAsync(object obj)
        {
            await Task.Run(() => UpdateInstance(obj));
        }

        /// <summary>
        /// Modifies an existing instance based on a custom query.
        /// </summary>
        /// <param name="obj">Object to be updated</param>
        /// <param name="query">Query to be run against WMI. The resulting instances will be updated</param>
        public void UpdateInstance(object obj, string query)
        {
            try
            {
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

#if NET45
                WindowsImpersonationContext impersonatedUser = windowsIdentity.Impersonate();
#endif
#if NETSTANDARD20
                WindowsIdentity.RunImpersonated(windowsIdentity.AccessToken, () =>
#endif
                {
                    string className = TypeHelper.GetClassName(obj);

                    ManagementObjectSearcher searcher;
                    searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query));

                    ManagementObjectCollection col = searcher.Get();

                    foreach (ManagementObject m in searcher.Get())
                    {
                        foreach (PropertyInfo p in obj.GetType().GetProperties())
                        {
                            WMIIgnore ignoreProp = p.GetCustomAttribute<WMIIgnore>();
                            WMIIgnoreOnUpdate ignoreOnUpdateProp = p.GetCustomAttribute<WMIIgnoreOnUpdate>();

                            if (ignoreProp == null && ignoreOnUpdateProp == null)
                            {
                                if (p.GetValue(obj) != null)
                                {
                                    WMIProperty propAtt = p.GetCustomAttribute<WMIProperty>();

                                    if (propAtt != null)
                                    {
                                        m[propAtt.Name] = p.GetValue(obj).GetType() == typeof(DateTime) ? ManagementDateTimeConverter.ToDmtfDateTime(Convert.ToDateTime(p.GetValue(obj))) : p.GetValue(obj);
                                    }
                                    else
                                    {
                                        m[p.Name] = p.GetValue(obj).GetType() == typeof(DateTime) ? ManagementDateTimeConverter.ToDmtfDateTime(Convert.ToDateTime(p.GetValue(obj))) : p.GetValue(obj);
                                    }
                                }
                            }
                        }

                        m.Put();
                    }
                }
#if NETSTANDARD20
                );
#endif
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifies an existing instance based on a custom query asynchonously.
        /// </summary>
        /// <param name="obj">Object to be updated</param>
        /// <param name="query">Query to be run. The resulting instances will be updated</param>
        /// <returns></returns>
        public async Task UpdateInstanceAsync(object obj, string query)
        {
            await Task.Run(() => UpdateInstance(obj, query));
        }

        /// <summary>
        /// Remove a WMI instance.
        /// </summary>
        /// <param name="obj">Object to be removed.</param>
        public void RemoveInstance(object obj)
        {
            try
            {
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

#if NET45
                WindowsImpersonationContext impersonatedUser = windowsIdentity.Impersonate();
#endif
#if NETSTANDARD20
                WindowsIdentity.RunImpersonated(windowsIdentity.AccessToken, () =>
#endif
                {
                    string className = TypeHelper.GetClassName(obj);

                    string query = String.Format("SELECT * FROM {0}", className);

                    List<WMISearchKey> keys = TypeHelper.GetSearchKeys(obj);

                    if (keys.Count > 0)
                    {
                        for (int i = 0; i < keys.Count; i++)
                        {
                            if (i == 0)
                            {
                                query = String.Format("{0} WHERE {1} = '{2}'", query, keys[i].Name, keys[i].Value);
                            }
                            else
                            {
                                query = String.Format("{0} AND {1} = '{2}'", query, keys[i].Name, keys[i].Value);
                            }
                        }

                        ManagementObjectSearcher searcher;
                        searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query));

                        foreach (ManagementObject m in searcher.Get())
                        {
                            m.Delete();
                        }
                    }
                    else
                    {
                        throw new WMISearchKeyException("There is no SearchKey specified for the object");
                    }
                }
#if NETSTANDARD20
                );
#endif
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remove a WMI instance asynchronously.
        /// </summary>
        /// <param name="obj">Object to be removed.</param>
        /// <returns></returns>
        public async Task RemoveInstanceAsync(object obj)
        {
            await Task.Run(() => RemoveInstance(obj));
        }

        /// <summary>
        /// Remove WMI instances based on a custom query.
        /// </summary>
        /// <param name="query">Query that returns the objects to be removed</param>
        public void RemoveInstance(string query)
        {
            try
            {
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

#if NET45
                WindowsImpersonationContext impersonatedUser = windowsIdentity.Impersonate();
#endif
#if NETSTANDARD20
                WindowsIdentity.RunImpersonated(windowsIdentity.AccessToken, () =>
#endif
                {
                    ManagementObjectSearcher searcher;
                    searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query));

                    foreach (ManagementObject m in searcher.Get())
                    {
                        m.Delete();
                    }
                }
#if NETSTANDARD20
                );
#endif
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remove WMI instances based on a custom query asynchronously.
        /// </summary>
        /// <param name="query">Query that returns the objects to be removed</param>
        /// <returns></returns>
        public async Task RemoveInstanceAsync(string query)
        {
            await Task.Run(() => RemoveInstance(query));
        }

        /// <summary>
        /// Runs a query against WMI. It will return a IEnumerable of dynamic type. No type mapping is done.
        /// </summary>
        /// <param name="query">Query to be run against WMI</param>
        /// <returns></returns>
        public IEnumerable<dynamic> Query(string query)
        {
            List<dynamic> res = new List<dynamic>();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query)))
            {
                using (ManagementObjectCollection wmiRes = searcher.Get())
                {
                    foreach (ManagementObject mo in wmiRes)
                    {
                        dynamic a = TypeHelper.LoadDynamicObject(mo);
                        res.Add(a);
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Runs a async query against WMI. It will return a IEnumerable of dynamic type. No type mapping is done.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<dynamic>> QueryAsync(string query)
        {
            return await Task.Run(() => Query(query));
        }

        /// <summary>
        /// Runs a query against WMI. It will return all instances of the class corresponding to the WMI class set on the Type on IEnumerable.
        /// </summary>
        /// <typeparam name="T">The Type of IEnumerable that will be returned</typeparam>
        /// <returns></returns>
        public IEnumerable<T> Query<T>()
        {
            List<T> res = new List<T>();

            string nombre = TypeHelper.GetClassName(typeof(T));

            string query = String.Format("SELECT {0} FROM {1}", TypeHelper.GetPropertiesToSearch(typeof(T)), nombre);

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query)))
            {
                using (ManagementObjectCollection wmiRes = searcher.Get())
                {
                    foreach (ManagementObject mo in wmiRes)
                    {
                        var a = (T)TypeHelper.LoadObject(mo, typeof(T));
                        res.Add(a);
                    }
                }
            }

            return res;
        }

        public ManagementObject[] QueryRaw(string className, ManagementScope scope)
        {
            string query = string.Format("select * from {0}", className);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query));
            ManagementObjectCollection objs = searcher.Get();
            return objs.Cast<ManagementObject>().ToArray();
        }

        /// <summary>
        /// Runs an async query against WMI. It will return all instances of the class corresponding to the WMI class set on the Type on IEnumerable.
        /// </summary>
        /// <typeparam name="T">The Type of IEnumerable that will be returned</typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAsync<T>()
        {
            return await Task.Run(() => Query<T>());
        }

        /// <summary>
        /// Runs a custom query against WMI.
        /// </summary>
        /// <typeparam name="T">The Type of IEnumerable that will be returned</typeparam>
        /// <param name="query">Query to be run against WMI</param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string query)
        {
            List<T> res = new List<T>();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query)))
            {
                using (ManagementObjectCollection wmiRes = searcher.Get())
                {
                    foreach (ManagementObject mo in wmiRes)
                    {
                        var a = (T)TypeHelper.LoadObject(mo, typeof(T));
                        res.Add(a);
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Runs an async query against WMI.
        /// </summary>
        /// <typeparam name="T">The Type of IEnumerable that will be returned</typeparam>
        /// <param name="query">Query to be run against WMI</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            return await Task.Run(() => Query<T>(query));
        }

        /// <summary>
        /// Runs a custom query against WMI returning a single value.
        /// </summary>
        /// <param name="query">Query to be run</param>
        /// <returns></returns>
        public dynamic QueryFirstOrDefault(string query)
        {
            dynamic res = null;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query)))
            {
                using (ManagementObjectCollection wmiRes = searcher.Get())
                {
                    foreach (ManagementObject mo in wmiRes)
                    {
                        res = TypeHelper.LoadDynamicObject(mo);
                        break;
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Runs an async query against WMI returning a single value.
        /// </summary>
        /// <param name="query">Query to be run</param>
        /// <returns></returns>
        public async Task<dynamic> QueryFirstOrDefaultAsync(string query)
        {
            return await Task.Run(() => QueryFirstOrDefault(query));
        }

        /// <summary>
        /// Runs a query against WMI. It will return the first instance of the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of object that will be returned</typeparam>
        /// <returns></returns>
        public T QueryFirstOrDefault<T>()
        {
            object res = null;

            string nombre = TypeHelper.GetClassName(typeof(T));

            string query = String.Format("SELECT {0} FROM {1}", TypeHelper.GetPropertiesToSearch(typeof(T)), nombre);

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query)))
            {
                using (ManagementObjectCollection wmiRes = searcher.Get())
                {
                    foreach (ManagementObject mo in wmiRes)
                    {
                        res = (T)TypeHelper.LoadObject(mo, typeof(T));
                        break;
                    }
                }
            }

            return (T)res;
        }

        /// <summary>
        /// Runs an async query against WMI. It will return the first instance of the specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of object that will be returned</typeparam>
        /// <returns></returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>()
        {
            return await Task.Run(() => QueryFirstOrDefault<T>());
        }

        /// <summary>
        /// Runs an custom query against WMI returning a single value of specified Type.
        /// </summary>
        /// <typeparam name="T">The Type of object that will be returned</typeparam>
        /// <param name="query">Query to be run</param>
        /// <returns></returns>
        public T QueryFirstOrDefault<T>(string query)
        {
            object res = null;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, new ObjectQuery(query)))
            {
                using (ManagementObjectCollection wmiRes = searcher.Get())
                {
                    foreach (ManagementObject mo in wmiRes)
                    {
                        res = (T)TypeHelper.LoadObject(mo, typeof(T));
                        break;
                    }
                }
            }

            return (T)res;
        }

        /// <summary>
        /// Runs an custom async query against WMI returning a single value of specified Type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>(string query)
        {
            return await Task.Run(() => QueryFirstOrDefault<T>(query));
        }


#endregion

    }
}
