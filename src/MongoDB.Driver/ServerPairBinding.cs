using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver.Platform.Conditions;
using System.Net;

namespace MongoDB.Driver
{
    /// <summary>
    /// A database binding that leverages a pair of databases
    /// </summary>
    public class ServerPairBinding : IServerBinding
    {
        public ServerPairBinding(ServerBinding leftBinding, ServerBinding rightBinding, bool readOnly = false)
        {
            Condition.Requires(leftBinding, "leftBinding").IsNotNull();
            Condition.Requires(rightBinding, "rightBinding").IsNotNull();
            LeftBinding = leftBinding;
            RightBinding = rightBinding;
            ReadOnly = readOnly;
        }

        public ServerBinding LeftBinding { get; private set; }
        public ServerBinding RightBinding { get; private set; }

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

        public string HostName
        {
            get { return LeftBinding.HostName; }
        }

        public int Port
        {
            get { return LeftBinding.Port; }
        }

        public IPAddress Address
        {
            get { return LeftBinding.Address; }
        }

        public Uri ToUri()
        {
            return LeftBinding.ToUri();
        }
    }
}
