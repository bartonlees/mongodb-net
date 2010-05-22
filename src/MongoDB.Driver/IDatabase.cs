//COPYRIGHT

using System;
using System.Collections.Generic;
using System.Security;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents the core operations and data of a MongoDB database
    /// </summary>
    public interface IDatabase : IUriComparable
    {
        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <param name="collectionUri">The collection URI</param>
        /// <returns></returns>
        IDBCollection GetCollection(Uri collectionUri);

        /// <summary>
        /// Drops the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        void DropCollection(IDBCollection collection);

        /// <summary>
        /// Clears the collection cache.
        /// </summary>
        void ClearCollectionCache();

        /// <summary>
        /// Gets the sister to the current database.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IDatabase GetSisterDatabase(Uri name);

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The passwd.</param>
        void AddUser(string username, SecureString passwd);

        /// <summary>
        /// Execute a database command directly. <a href="http://mongodb.onconfluence.com/display/DOCS/Mongo+Commands">Mongo Commands</a>
        /// </summary>
        /// <param name="cmd">The command object to execute.</param>
        /// <returns>The response object</returns>
        IDBObject ExecuteCommand(DBQuery cmd);

        /// <summary>
        /// Gets the special $cmd collection.
        /// </summary>
        /// <value>The $cmd collection.</value>
        IDBCollection CmdCollection { get; }

        /// <summary>
        /// Gets the special system.users collection.
        /// </summary>
        /// <value>The system.users collection.</value>
        IDBCollection SystemUsersCollection { get; }

        /// <summary>
        /// Enumerates the collection available on this database.
        /// </summary>
        /// <value>The collections.</value>
        IEnumerable<IDBCollection> Collections { get; }

        /// <summary>
        /// Gets the <see cref="MongoDB.Driver.IDBCollection"/> with the specified collection URI.
        /// </summary>
        /// <value></value>
        IDBCollection this[Uri collectionUri] { get; }

        /// <summary>
        /// Gets the <see cref="MongoDB.Driver.IDBCollection"/> with the specified collection URI.
        /// </summary>
        /// <value></value>
        IDBCollection this[string collectionUri] { get; }

        /// <summary>
        /// Gets the name of this database.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Gets the database binding.
        /// </summary>
        /// <value>The binding.</value>
        IDBBinding Binding { get; }

        /// <summary>
        /// Gets the server hosting this database
        /// </summary>
        /// <value>The server.</value>
        IServer Server { get; }

        /// <summary>
        /// Gets or sets a value indicating whether we are in a ReadOnly mode.
        /// </summary>
        /// <value><c>true</c> if read only; otherwise, <c>false</c>.</value>
        bool ReadOnly { get; }
    }

    /// <summary>
    /// Represents an <see cref="IDatabase"/> that supports administrative operations
    /// </summary>
    public interface IAdminOperations : IDatabase
    {
        /// <summary>
        /// Gets the build info.
        /// </summary>
        /// <value>The build info.</value>
        BuildInfo BuildInfo { get; }
        /// <summary>
        /// Gets or sets the diagnostic logging level.
        /// </summary>
        /// <value>The diagnostic logging level.</value>
        DiagnosticLoggingLevel DiagnosticLoggingLevel { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [op logging].
        /// </summary>
        /// <value><c>true</c> if [op logging]; otherwise, <c>false</c>.</value>
        bool OpLogging { get; set; }
        /// <summary>
        /// Gets or sets the query trace level.
        /// </summary>
        /// <value>The query trace level.</value>
        int QueryTraceLevel { get; set; }
    }
}