using System;
using System.Net;
using System.Collections.Generic;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents connection details for a logical server (could be a pool of servers in reality)
    /// </summary>
    public interface IServerMultiBinding
    {
        IEnumerable<IServerBinding> SubBindings { get; }
        IDBMultiBinding GetDBMultiBinding(Uri uri);
    }
}
