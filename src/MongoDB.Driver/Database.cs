//COPYRIGHT

using System;
using MongoDB.Driver.Platform.Util;
using System.Collections.Generic;
using MongoDB.Driver.Platform.IO;
using System.IO;
using MongoDB.Driver.Platform.Conversion;
using MongoDB.Driver.Platform.Conditions;
using MongoDB.Driver.Command;
using System.Security;
using System.Text;
using MongoDB.Driver.Command.Admin;
using System.Data;
using System.Transactions;
namespace MongoDB.Driver
{

    /// <summary>
    /// The default implementation of the database interface
    /// </summary>
    internal class Database : IAdminOperations
    {
        /** The maximum number of cursors allowed */
        public static int NUM_CURSORS_BEFORE_KILL = 100;
        public IServer Server { get; private set; }
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

        public static HashSet<string> StandardCollectionNames = new HashSet<string>(new string[] {"admin", "system.namespaces" });

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

        public IDBObject ExecuteCommand(DBQuery cmd)
        {
            return CmdCollection.FindOne(cmd);
        }

        public IDBCollection CmdCollection
        {
            get
            {
                return this.GetCollection("$cmd");
            }
        }

        public IDBBinding Binding { get; private set; }
        Dictionary<string, DBCollection> _CollectionLookup = new Dictionary<string, DBCollection>();
        static List<IDBObject> EMPTY = new List<IDBObject>();



        public Uri Uri
        {
            get;
            private set;
        }

        public bool ReadOnly { get { return Binding.ReadOnly; } }

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

        public IDBCollection this[Uri collectionUri]
        {
            get { return GetCollection(collectionUri); }
        }

        public IDBCollection this[string collectionUri]
        {
            get { return this.GetCollection(collectionUri); }
        }


        public void ClearCollectionCache()
        {
            _CollectionLookup.Clear();
        }


        public string Name
        {
            get { return Uri.GetDatabaseName(); }
        }

        protected IAdminOperations Admin { get { return this as IAdminOperations; } }

        public BuildInfo BuildInfo
        {
            get { return Admin.buildinfo(); }
        }

        DiagnosticLoggingLevel _DiagnosticLoggingLevel = DiagnosticLoggingLevel.Unknown;
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