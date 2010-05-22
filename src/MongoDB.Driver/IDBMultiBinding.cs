//COPYRIGHT

using System;
using System.Net;
using System.Security;
using System.Collections.Generic;
namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a logical database connection that may connect to multiple physical databases
    /// </summary>
    public interface IDBMultiBinding : IDBBinding
    {
        /// <summary>
        /// Gets the sub bindings.
        /// </summary>
        /// <value>The sub bindings.</value>
        IEnumerable<IDBBinding> SubBindings { get; }

        /// <summary>
        /// Gets the active binding.
        /// </summary>
        /// <value>The active binding.</value>
        IDBBinding ActiveSubBinding { get; }

        /// <summary>
        /// Gets the server multi binding.
        /// </summary>
        /// <value>The server multi binding.</value>
        IServerMultiBinding ServerMultiBinding { get; }
    }
}