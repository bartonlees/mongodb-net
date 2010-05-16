using System;
using System.Collections.Generic;
using System.Data;
using MongoDB.Driver.Command;
using MongoDB.Driver.Command.Admin;
namespace MongoDB.Driver
{
    internal class Server : IServer
    {
        /// <summary>
        /// Gets or sets the binding.
        /// </summary>
        /// <value>The binding.</value>
        public IServerBinding Binding { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="options">The options.</param>
        public Server(IServerBinding binding, DBConnectionOptions options)
        {
            Binding = binding;
            Options = options ?? new DBConnectionOptions();
            Binding.Bind(this); //Initialize the binding
        }

        /// <summary>
        /// Gets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get { return Binding.ReadOnly; }
        }

        /// <summary>
        /// Gets an interface for the named database.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <returns></returns>
        public IDatabase GetDatabase(IDBBinding binding)
        {
            IDatabase db = null;
            _DatabaseLookup.TryGetValue(binding.DatabaseName.ToString(), out db);
            if (db != null)
                return db;

            lock (_DatabaseLookup)
            {
                _DatabaseLookup.TryGetValue(binding.DatabaseName.ToString(), out db);
                if (db != null)
                    return db;

                db = new Database(this, binding);

                _DatabaseLookup[binding.DatabaseName.ToString()] = db;
                return db;
            }
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IDatabase GetDatabase(Uri name)
        {
            return GetDatabase(Binding.GetDBBinding(name));
        }

        /// <summary>
        /// Gets the <see cref="MongoDB.Driver.IDatabase"/> with the specified database name.
        /// </summary>
        /// <value></value>
        public IDatabase this[Uri databaseUri]
        {
            get
            {
                return GetDatabase(databaseUri);
            }
        }

        /// <summary>
        /// Gets the <see cref="MongoDB.Driver.IDatabase"/> with the specified database name.
        /// </summary>
        /// <value></value>
        public IDatabase this[string databaseUri]
        {
            get
            {
                return this.GetDatabase(databaseUri);
            }
        }

        /// <summary>
        /// Gets the database names for the active host.
        /// </summary>
        /// <value>The database names.</value>
        public IEnumerable<Uri> DatabaseNames
        {
            get
            {
                DatabaseList r = Admin.listDatabases();
                return r.DatabaseNames;
            }
        }

        /// <summary>
        /// Gets the admin option and operation interface.
        /// </summary>
        /// <value>The admin.</value>
        public IAdminOperations Admin
        {
            get
            {
                return this.GetDatabase("admin") as IAdminOperations;
            }
        }

        /// <summary>
        /// Drops the database.
        /// </summary>
        /// <param name="database">The database.</param>
        public void DropDatabase(IDatabase database)
        {
            if (ReadOnly)
                throw new ReadOnlyException("cannot drop a database while using a readonly binding");
            Admin.dropDatabase(database.Name);
            _DatabaseLookup.Remove(database.Name);
        }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        public DBConnectionOptions Options { get; private set; }
        Dictionary<string, IDatabase> _DatabaseLookup = new Dictionary<string, IDatabase>();

        /// <summary>
        /// Gets this server's available databases.
        /// </summary>
        /// <value>The databases.</value>
        public IEnumerable<IDatabase> Databases
        {
            get
            {
                foreach (Uri name in DatabaseNames)
                    yield return GetDatabase(name);
            }
        }


        /// <summary>
        /// Gets the URI associated with the current server.
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri
        {
            get { return Binding.Uri; }
        }


        /// <summary>
        /// Clears the database cache.
        /// </summary>
        public void ClearDatabaseCache()
        {
            _DatabaseLookup.Clear();
        }
    }
}
