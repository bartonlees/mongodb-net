using System;
using System.Net;
using MongoDB.Driver.Platform.Conditions;
using System.Linq;
using System.Collections.Generic;

namespace MongoDB.Driver
{
    /// <summary>
    /// A database binding that leverages a pair of databases
    /// </summary>
    internal class ServerMultiBinding : IServerMultiBinding
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerMultiBinding"/> class.
        /// </summary>
        /// <param name="subBindings">The sub bindings.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        public ServerMultiBinding(IEnumerable<IServerBinding> subBindings, bool readOnly = false)
        {
            Condition.Requires(subBindings, "subBindings").IsNotNull();
            _SubBindings = subBindings.Distinct(new UriEqualityComparer<IServerBinding>()).ToList();
            Condition.Requires(_SubBindings, "SubBindings").IsLongerThan(1,"Must have more than one unique server binding.");
            ReadOnly = readOnly;
        }

        

        public IServer BoundServer { get; private set; }

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
            return GetDBMultiBinding(name);
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
        /// Retrieves a representational Uri
        /// </summary>
        /// <returns></returns>
        public Uri Uri
        {
            get
            {
                return LeftBinding.Uri;
            }
        }

        public List<IServerBinding> _SubBindings;
        public IEnumerable<IServerBinding> SubBindings
        {
            get { return _SubBindings; }
        }

        public IDBMultiBinding GetDBMultiBinding(Uri name)
        {
            return new DBMultiBinding(this, SubBindings.Select(b => b.GetDBBinding(name)), ReadOnly);
        }

        public void Bind(IServer server)
        {
            BoundServer = server;
        }
    }
}
