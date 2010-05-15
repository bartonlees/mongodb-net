//COPYRIGHT

using System;
using System.Net;
using System.Security;
using System.Collections.Generic;
namespace MongoDB.Driver
{
    /// <summary>
    /// An interface that represents the binding of a client to server data source(s)
    /// </summary>
    public interface IDBMultiBinding : IDBBinding
    {
        IEnumerable<IDBBinding> SubBindings { get; }
        IDBBinding ActiveBinding { get; }
        IServerMultiBinding ServerMultiBinding { get; }
    }
}