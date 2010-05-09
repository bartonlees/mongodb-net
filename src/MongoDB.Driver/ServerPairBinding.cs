using System;
using System.Net;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// A database binding that leverages a pair of databases
    /// </summary>
    public class ServerPairBinding : IServerBinding
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerPairBinding"/> class.
        /// </summary>
        /// <param name="leftBinding">The left binding.</param>
        /// <param name="rightBinding">The right binding.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        public ServerPairBinding(ServerBinding leftBinding, ServerBinding rightBinding, bool readOnly = false)
        {
            Condition.Requires(leftBinding, "leftBinding").IsNotNull();
            Condition.Requires(rightBinding, "rightBinding").IsNotNull();
            LeftBinding = leftBinding;
            RightBinding = rightBinding;
            ReadOnly = readOnly;
        }

        /// <summary>
        /// Gets or sets the left binding.
        /// </summary>
        /// <value>The left binding.</value>
        public ServerBinding LeftBinding { get; private set; }
        /// <summary>
        /// Gets or sets the right binding.
        /// </summary>
        /// <value>The right binding.</value>
        public ServerBinding RightBinding { get; private set; }

        /// <summary>
        /// Gets the DB binding.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IDBBinding GetDBBinding(Uri name)
        {
            return new DBPairBinding(LeftBinding.GetDBBinding(name), RightBinding.GetDBBinding(name), ReadOnly);
        }

        /// <summary>
        /// Gets or sets a value indicating whether modifications to the server data is allowed.
        /// </summary>
        /// <value><c>true</c> if binding is read only; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        public string HostName
        {
            get { return LeftBinding.HostName; }
        }

        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>The port.</value>
        public int Port
        {
            get { return LeftBinding.Port; }
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public IPAddress Address
        {
            get { return LeftBinding.Address; }
        }

        /// <summary>
        /// Toes the URI.
        /// </summary>
        /// <returns></returns>
        public Uri ToUri()
        {
            return LeftBinding.ToUri();
        }
    }
}
