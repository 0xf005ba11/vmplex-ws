/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using Microsoft.Management.Infrastructure;

namespace EasyCIM
{
    public class CimSubscription<T> : IObserver<CimSubscriptionResult>, IDisposable
    {
        private IObservable<CimSubscriptionResult> m_queryInstances;
        private IDisposable? m_watcher;

        public string? Query { get; private set; }
        public CimServer Server { get; }

        public event EventHandler<CimEvent<T>>? EventArrived;
        public event EventHandler<Exception>? Errored;
        public event EventHandler? Completed;

        public CimSubscription(CimServer server, IObservable<CimSubscriptionResult> queryInstances, string query)
        {
            Query = query;
            Server = server;
            m_queryInstances = queryInstances;
            m_watcher = m_queryInstances.Subscribe(this);
        }

        public void OnCompleted()
        {
            try
            {
                Completed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public void OnNext(CimSubscriptionResult result)
        {
            try
            {
                EventArrived?.Invoke(this, new CimEvent<T>(result, Server));
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public void OnError(Exception error)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("CimSubscription \"{0}\" exception: {1}", Query, error);
                Errored?.Invoke(this, error);
            }
            catch (Exception)
            {
            }
        }

        public void Dispose() => m_watcher?.Dispose();
    }
}
