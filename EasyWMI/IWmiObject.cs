/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */


using System.Management;

namespace EasyWMI
{
    public abstract class IWmiObject
    {
        public ManagementBaseObject __Instance { get; protected set; }

        public T[] GetAssociated<T>(string association)
        {
            try
            {
                var name = WmiClassImpl.ClassName<T>();
                ManagementObjectCollection collection = ((ManagementObject)__Instance).GetRelated(
                    name.ClassName,
                    association,
                    null!,
                    null!,
                    null!,
                    null!,
                    false,
                    null!);
                return WmiClassImpl.FromInstances<T>(collection);
            }
            catch (Exception)
            {
                return new T[0];
            }
        }
    }
}
