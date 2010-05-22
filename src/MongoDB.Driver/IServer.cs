using System;
using System.Collections.Generic;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a remote MongoDB server
    /// </summary>
    public interface IServer : IUriComparable
    {
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IDatabase GetDatabase(Uri name);

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <returns></returns>
        IDatabase GetDatabase(IDBBinding binding);

        /// <summary>
        /// Drops the database.
        /// </summary>
        /// <param name="database">The database.</param>
        void DropDatabase(IDatabase database);

        /// <summary>
        /// Clears the database cache.
        /// </summary>
        void ClearDatabaseCache();

        /// <summary>
        /// Gets the <see cref="MongoDB.Driver.IDatabase"/> with the specified database URI.
        /// </summary>
        /// <value></value>
        IDatabase this[Uri databaseUri] { get; }

        /// <summary>
        /// Gets the <see cref="MongoDB.Driver.IDatabase"/> with the specified database URI.
        /// </summary>
        /// <value></value>
        IDatabase this[string databaseUri] { get; }

        /// <summary>
        /// Gets this server's available database names.
        /// </summary>
        /// <value>The database names.</value>
        IEnumerable<Uri> DatabaseNames { get; }

        /// <summary>
        /// Gets this server's available databases.
        /// </summary>
        /// <value>The databases.</value>
        IEnumerable<IDatabase> Databases { get; }

        /// <summary>
        /// Gets the binding.
        /// </summary>
        /// <value>The binding.</value>
        IServerBinding Binding { get; }

        /// <summary>
        /// Gets the admin option and operation interface.
        /// </summary>
        /// <value>The admin.</value>
        IAdminOperations Admin { get; }

        /// <summary>
        /// Gets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        bool ReadOnly { get; }
    }
}
