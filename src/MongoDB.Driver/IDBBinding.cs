//COPYRIGHT

using System;
using System.Net;
using System.Security;
namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a logical connection to a database
    /// </summary>
    /// Some construction options:
    /// <example caption="Basic">
    /// <code>
    /// DBBinding basic = new DBBinding("mongo://localhost/db");
    /// </code>
    /// </example>
    /// <example caption="From Template Binding">
    /// <code>
    /// DBBinding template = new DBBinding("mongo://localhost/db");
    /// DBBinding templated = new DBBinding(template, "db2");
    /// //Equivalent to "mongo://localhost/db2"
    /// </code>
    /// </example>
    /// <example caption="Hostname and DB Name">
    /// <code>
    /// DBBinding withnames = new DBBinding("localhost", "db");
    /// //Equivalent to "mongo://localhost/db"
    /// </code>
    /// </example>
    /// <example caption="With Port">
    /// <code>
    /// DBBinding withport = new DBBinding("localhost", 1910, "db");
    /// //Equivalent to "mongo://localhost:1910/db"
    /// </code>
    /// </example>
    public interface IDBBinding : IUriComparable
    {
        /// <summary>
        /// Gets the sister binding.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IDBBinding GetSisterBinding(Uri name);

        /// <summary>
        /// Says the specified CMD collection.
        /// </summary>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        void Say(IDBCollection cmdCollection, IDBRequest msg, bool checkError = false);
        /// <summary>
        /// Tries the say.
        /// </summary>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        /// <returns></returns>
        bool TrySay(IDBCollection cmdCollection, IDBRequest msg, bool checkError = false);
        /// <summary>
        /// Calls the specified CMD collection.
        /// </summary>
        /// <typeparam name="TDoc">A type that implements <see cref="T:MongoDB.Driver.IDocument"/>.</typeparam>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        IDBResponse<TDoc> Call<TDoc>(IDBCollection cmdCollection, IDBRequest msg) where TDoc : class, IDocument;

        /// <summary>
        /// Gets the last exception.
        /// </summary>
        /// <value>The last exception.</value>
        Exception LastException { get; }
        /// <summary>
        /// Gets the connection options.
        /// </summary>
        /// <value>The connection options.</value>
        DBConnectionOptions ConnectionOptions { get; }
        /// <summary>
        /// Gets the bound Database.
        /// </summary>
        /// <value>The server.</value>
        IDatabase BoundDatabase { get; }
        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>The end point.</value>
        IPEndPoint EndPoint { get; }
        /// <summary>
        /// Gets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        bool ReadOnly { get; }
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
        /// Gets the name of the database.
        /// </summary>
        /// <value>The name of the database.</value>
        string DatabaseName { get; }
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        IPAddress Address { get; }
        /// <summary>
        /// Gets the username we are logged in with (if any).
        /// </summary>
        /// <value>The username.</value>
        string Username { get; }

        /// <summary>
        /// sets connection credentials for using with the database.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The password.</param>
        void SetCredentials(string username, SecureString passwd);

        /// <summary>
        /// Binds the specified database proxy object to this binding's details.
        /// </summary>
        /// <param name="database">The database.</param>
        void Bind(IDatabase database);
    }
    
}