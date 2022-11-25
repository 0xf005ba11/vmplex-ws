/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Generic;

namespace EasyCIM
{
    public class CimEvent<T>
    {
        public CimSubscriptionResult Result { get; private set; }
        public CimServer Server { get; private set; }
        public CimKeyedCollection<CimProperty> Properties { get => Result.Instance.CimInstanceProperties; }

        public T PreviousInstance { 
            get
            {
                CimProperty prev = Properties["PreviousInstance"];
                if (prev == null)
                {
                    throw new NullReferenceException();
                }
                T? ret = Server.Generator.CreateInstance<T>(Server.CimSession, (CimInstance)prev.Value);
                if (ret == null)
                {
                    throw new NullReferenceException();
                }
                return ret;
            }
        }

        public T TargetInstance { 
            get
            {
                CimProperty prev = Properties["TargetInstance"];
                if (prev == null)
                {
                    throw new NullReferenceException();
                }
                T? ret = Server.Generator.CreateInstance<T>(Server.CimSession, (CimInstance)prev.Value);
                if (ret == null)
                {
                    throw new NullReferenceException();
                }
                return ret;
            }
        }

        public CimEvent(CimSubscriptionResult result, CimServer server)
        {
            Result = result;
            Server = server;
        }
    }
}
