//COPYRIGHT

using System.Collections.Generic;
using System;
using MongoDB.Driver.Platform.Util;
using System.Text;
using System.IO;
using MongoDB.Driver.Platform.Conditions;
using MongoDB.Driver.Command;
using System.Security;
using MongoDB.Driver.Command.Admin;

namespace MongoDB.Driver
{
    /// <summary>
    /// This interface represents the core operations and data of a MongoDB database
    /// </summary>
    public interface IDatabase
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
        /// The fully-qualified URI of this database.
        /// </summary>
        /// <value>The URI.</value>
        Uri Uri { get; }

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
        bool ReadOnly { get;}
    }

    /// <summary>
    /// Extended interface for administrative operations
    /// </summary>
    public interface IAdminOperations : IDatabase
    {
        BuildInfo BuildInfo { get; }
        DiagnosticLoggingLevel DiagnosticLoggingLevel { get; set; }
        bool OpLogging { get; set; }
        int QueryTraceLevel { get; set; }
    }
}