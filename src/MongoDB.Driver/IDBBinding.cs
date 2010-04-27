//COPYRIGHT

using System.Collections.Generic;
using System.Net;
using System;
using System.Net.Sockets;
using System.Diagnostics.Contracts;
using MongoDB.Driver.Platform.Util;
using MongoDB.Driver.Platform.Conditions;
using System.Linq;
using MongoDB.Driver.Command;
using System.Security;
namespace MongoDB.Driver
{
    /// <summary>
    /// An interface that represents the binding of a client to server data source(s)
    /// </summary>
    public interface IDBBinding
    {
        /// <summary>
        /// Gets the sister binding.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IDBBinding GetSisterBinding(Uri name);

        void Say(IDBCollection cmdCollection, IDBRequest msg, bool checkError = false);
        bool TrySay(IDBCollection cmdCollection, IDBRequest msg, bool checkError = false);
        IDBResponse<TDoc> Call<TDoc>(IDBCollection cmdCollection, IDBRequest msg) where TDoc : class, IDocument;

        Exception LastException { get; }
        DBConnectionOptions ConnectionOptions { get; }
        IServer Server { get; }
        IPEndPoint EndPoint { get; }
        bool ReadOnly { get; }
        string HostName { get;}
        int Port { get; }
        string DatabaseName { get;}
        IPAddress Address { get;}
        /// <summary>
        /// Gets the username we are logged in with (if any).
        /// </summary>
        /// <value>The username.</value>
        string Username { get; }
        Uri Uri { get; }

        /// <summary>
        /// sets connection credentials for using with the database.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The password.</param>
        /// <returns>true if authentication succeeded, false otherwise</returns>
        void SetCredentials(string username, SecureString passwd);
    }

    internal interface IInternalDBBinding : IDBBinding
    {
        void Initialize(IServer server);
    }
}