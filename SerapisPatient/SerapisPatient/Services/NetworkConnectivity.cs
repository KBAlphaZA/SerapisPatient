using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Connectivity.Abstractions;

namespace SerapisPatient.Services
{
    public class NetworkConnectivity : IConnectivity
    {
        public bool IsConnected {get;}

        public IEnumerable<ConnectionType> ConnectionTypes { get; set; }

        public IEnumerable<ulong> Bandwidths { get; set; }

        public event ConnectivityChangedEventHandler ConnectivityChanged;
        public event ConnectivityTypeChangedEventHandler ConnectivityTypeChanged;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsReachable(string host, int msTimeout = 5000)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000)
        {
            throw new NotImplementedException();
        }

        public void OnConnectiviTypeChanged()
        {
            ConnectivityTypeChanged(this, new ConnectivityTypeChangedEventArgs());
        }

        public void OnConnectivityChanged(bool connection)
        {
            if (connection)
            {
                ConnectivityChanged(this, new ConnectivityChangedEventArgs());
            }
        }
    }
}
