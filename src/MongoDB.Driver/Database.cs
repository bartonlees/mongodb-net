//COPYRIGHT

using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using MongoDB.Driver.Command;
using MongoDB.Driver.Command.Admin;
using MongoDB.Driver.Platform.Conditions;
using MongoDB.Driver.Platform.Util;
namespace MongoDB.Driver
{

    /// <summary>
    /// The default implementation of the database interface
    /// </summary>
    internal class Database : IAdminOperations
    {
        /** The maximum number of cursors allowed */
        public static int NUM_CURSORS_BEFORE_KILL = 100;
        /// <summary>
        /// Gets the server hosting this database
        /// </summary>
        /// <value>The server.</value>
        public IServer Server { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="binding">The binding.</param>
        public Database(IServer server, IDBBinding binding)
        {
            Server = server;
            Uri relative = binding.Uri.IsAbsoluteUri ? server.Uri.MakeRelativeUri(binding.Uri) : binding.Uri;
            Uri = new Uri(server.Uri, relative);
            Binding = binding;
        }

        internal IDBCollection _GetCollection(Uri collectionUri)
        {
            DBCollection c = null;
            if (_CollectionLookup.TryGetValue(collectionUri.GetCollectionName(), out c))
                return c;

            lock (_CollectionLookup)
            {
                //Re-get for thread safety?
                if (_CollectionLookup.TryGetValue(collectionUri.GetCollectionName(), out c))
                    return c;

                if (ReadOnly && !IsStandardCollection(collectionUri) && !this.CollectionExists(collectionUri))
                {
                    throw new ReadOnlyException("cannot create a new collection when using a readonly binding");
                }

                c = new DBCollection(this, collectionUri);
                _CollectionLookup[collectionUri.GetCollectionName()] = c;
            }
            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        public static HashSet<string> StandardCollectionNames = new HashSet<string>(new string[] { "admin", "system.namespaces" });

        private bool IsStandardCollection(System.Uri collectionUri)
        {
            return StandardCollectionNames.Contains(collectionUri.GetCollectionName().ToLower());
        }

        /// <summary>
        /// Gets the a database on the same host as the current one
        /// </summary>
        /// <param name="databaseUri">Name of the database.</param>
        /// <returns></returns>
        public IDatabase GetSisterDatabase(Uri databaseUri)
        {
            return new Database(Server, Binding.GetSisterBinding(databaseUri));
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <param name="collectionUri">The name.</param>
        /// <returns></returns>
        public IDBCollection GetCollection(Uri collectionUri)
        {
            IDBCollection c = null;
            if (!collectionUri.IsAbsoluteUri) //Must be a collection on this db
            {
                c = _GetCollection(collectionUri);
            }
            else
            {
                if (Uri.Equals(collectionUri.GetDatabaseName()))//if Absolute path references this db
                {
                    c = _GetCollection(collectionUri);
                }
                else //Try a sister db
                {
                    c = GetSisterDatabase(collectionUri).GetCollection(collectionUri);
                }
            }
            return c;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Uri.ToString();
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The passwd.</param>
        public void AddUser(string username, SecureString passwd)
        {
            if (ReadOnly)
                throw new ReadOnlyException("cannot add a user while using a readonly binding");
            IDBCollection c = this.GetCollection("system.users");
            IDocument o = c.FindOne(new DBQuery("user", username));
            if (o == null)
                o = new Document("user", username);
            o["pwd"] = Util._hash(username, passwd);
            c.Save(o);
        }

        /// <summary>
        /// Execute a database command directly. <a href="http://mongodb.onconfluence.com/display/DOCS/Mongo+Commands">Mongo Commands</a>
        /// </summary>
        /// <param name="cmd">The command object to execute.</param>
        /// <returns>The response object</returns>
        public IDBObject ExecuteCommand(DBQuery cmd)
        {
            return CmdCollection.FindOne(cmd);
        }

        /// <summary>
        /// Gets the special $cmd collection.
        /// </summary>
        /// <value>The $cmd collection.</value>
        public IDBCollection CmdCollection
        {
            get
            {
                return this.GetCollection("$cmd");
            }
        }

        /// <summary>
        /// Gets the database binding.
        /// </summary>
        /// <value>The binding.</value>
        public IDBBinding Binding { get; private set; }
        Dictionary<string, DBCollection> _CollectionLookup = new Dictionary<string, DBCollection>();
        static List<IDBObject> EMPTY = new List<IDBObject>();



        /// <summary>
        /// The fully-qualified URI of this database.
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether we are in a ReadOnly mode.
        /// </summary>
        /// <value><c>true</c> if read only; otherwise, <c>false</c>.</value>
        public bool ReadOnly { get { return Binding.ReadOnly; } }

        /// <summary>
        /// Enumerates the collection available on this database.
        /// </summary>
        /// <value>The collections.</value>
        public IEnumerable<IDBCollection> Collections
        {
            get
            {
                foreach (Uri collectionUri in this.GetCollectionNames())
                {
                    yield return GetCollection(collectionUri);
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="MongoDB.Driver.IDBCollection"/> with the specified collection URI.
        /// </summary>
        /// <value></value>
        public IDBCollection this[Uri collectionUri]
        {
            get { return GetCollection(collectionUri); }
        }

        /// <summary>
        /// Gets the <see cref="MongoDB.Driver.IDBCollection"/> with the specified collection URI.
        /// </summary>
        /// <value></value>
        public IDBCollection this[string collectionUri]
        {
            get { return this.GetCollection(collectionUri); }
        }


        /// <summary>
        /// Clears the collection cache.
        /// </summary>
        public void ClearCollectionCache()
        {
            _CollectionLookup.Clear();
        }


        /// <summary>
        /// Gets the name of this database.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return Uri.GetDatabaseName(); }
        }

        /// <summary>
        /// Gets the admin.
        /// </summary>
        /// <value>The admin.</value>
        protected IAdminOperations Admin { get { return this as IAdminOperations; } }

        /// <summary>
        /// Gets the build info.
        /// </summary>
        /// <value>The build info.</value>
        public BuildInfo BuildInfo
        {
            get { return Admin.buildinfo(); }
        }

        DiagnosticLoggingLevel _DiagnosticLoggingLevel = DiagnosticLoggingLevel.Unknown;
        /// <summary>
        /// Gets or sets the diagnostic logging level.
        /// </summary>
        /// <value>The diagnostic logging level.</value>
        public DiagnosticLoggingLevel DiagnosticLoggingLevel
        {
            get
            {
                if (_DiagnosticLoggingLevel == Driver.DiagnosticLoggingLevel.Unknown)
                    Admin.diagLogging(ref _DiagnosticLoggingLevel);
                return _DiagnosticLoggingLevel;
            }
            set
            {
                Admin.diagLogging(ref _DiagnosticLoggingLevel);
            }
        }

        bool IAdminOperations.OpLogging
        {
            get
            {
                return false;
            }
            set
            {
                Admin.opLogging(value);
            }
        }

        int IAdminOperations.QueryTraceLevel
        {
            get
            {
                return 0;
            }
            set
            {
                Admin.queryTraceLevel(value);
            }
        }


        /// <summary>
        /// Drops the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void DropCollection(IDBCollection collection)
        {
            if (ReadOnly)
                throw new ReadOnlyException("Cannot drop a collection when using a readonly binding");
            Condition.Requires(collection, "collection").IsNotNull();
            this.drop(collection.Name);
            collection.ClearIndexCache();
        }
    }
}