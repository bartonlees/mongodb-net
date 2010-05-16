using System;
using System.Net;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents connection details for a logical server (could be a pool of servers in reality)
    /// </summary>
    public interface IServerBinding : IUriComparable
    {
        /// <summary>
        /// Gets the DB binding.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IDBBinding GetDBBinding(Uri name);
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        IPAddress Address { get; }
        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        string HostName { get; }
        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>The port.</value>
        int Port { get; }
        /// <summary>
        /// Gets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        bool ReadOnly { get; }
        
        /// <summary>
        /// Binds the specified server proxy to this connection information.
        /// </summary>
        /// <param name="server">The server.</param>
        void Bind(IServer server);

        /// <summary>
        /// Gets the bound server.
        /// </summary>
        /// <value>The bound server.</value>
        IServer BoundServer { get; }
    }
}
