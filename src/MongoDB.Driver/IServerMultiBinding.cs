using System;
using System.Net;
using System.Collections.Generic;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a logical server connection that may, in fact, consist of multiple physical servers
    /// </summary>
    public interface IServerMultiBinding : IServerBinding
    {
        /// <summary>
        /// Gets the sub bindings that support this binding.
        /// </summary>
        /// <value>The sub bindings.</value>
        IEnumerable<IServerBinding> SubBindings { get; }
        /// <summary>
        /// Gets a DB multi binding for the given name base on this server multi binding.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        IDBMultiBinding GetDBMultiBinding(Uri uri);
    }
}
