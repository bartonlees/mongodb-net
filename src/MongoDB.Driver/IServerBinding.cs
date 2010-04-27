using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace MongoDB.Driver
{
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
