using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents connection details for a logical server (could be a pool of servers in reality)
    /// </summary>
    public interface IServerBinding
    {
        IDBBinding GetDBBinding(Uri name);
        IPAddress Address { get; }
        string HostName { get; }
        int Port { get; }
        bool ReadOnly { get; }
        Uri ToUri();
    }
}
