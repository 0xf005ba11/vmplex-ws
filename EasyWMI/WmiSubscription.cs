/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System.Management;

namespace EasyWMI
{
    public class WmiSubscription<T>
    {
        private ManagementEventWatcher m_watcher;

        public WmiScope Scope { get; }
        public string? Query { get; }

        public event EventHandler<WmiEvent<T>>? EventArrived;

        public WmiSubscription(WmiScope scope, string query)
        {
            Scope = scope;
            Query = query;
            var eq = new EventQuery();
            eq.QueryLanguage = "WQL";
            eq.QueryString = query;
            m_watcher = new ManagementEventWatcher(Scope.Scope, eq);
            m_watcher.EventArrived += EventProxy;
            m_watcher.Start();
        }

        private void EventProxy(object sender, EventArrivedEventArgs e)
        {
            EventArrived?.Invoke(this, new WmiEvent<T>(e));
        }

        public void Stop()
        {
            m_watcher.Stop();
        }
    }

    public class WmiEvent<T>
    {
        public ManagementBaseObject Event { get; }

        public T PreviousInstance
        {
            get
            {
                T? value = WmiClassImpl.GetProperty<T>(Event, "PreviousInstance");
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                return value;
            }
        }

        public T TargetInstance
        {
            get
            {
                T? value = WmiClassImpl.GetProperty<T>(Event, "TargetInstance");
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                return value;
            }
        }

        public WmiEvent(EventArrivedEventArgs args)
        {
            Event = args.NewEvent;
        }
    }
}
