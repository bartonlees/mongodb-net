//COPYRIGHT

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security;
using MongoDB.Driver.Command;
using MongoDB.Driver.Command.Admin;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// 
    /// </summary>
    public static class IAdminDatabaseExtensions
    {
        /// <summary>
        /// Closes all databases.
        /// </summary>
        /// <param name="adminDatabase">The admin database.</param>
        public static void CloseAllDatabases(this IAdminOperations adminDatabase)
        {
            adminDatabase.closeAllDatabases();
        }

        /// <summary>
        /// Copies the database.
        /// </summary>
        /// <param name="adminDatabase">The admin database.</param>
        /// <param name="fromDatabase">From database.</param>
        /// <param name="toDatabase">To database.</param>
        public static void CopyDatabase(this IAdminOperations adminDatabase, IDatabase fromDatabase, IDatabase toDatabase)
        {
            if (toDatabase.ReadOnly)
                throw new ReadOnlyException("Cannot copy to a readonly binding");

            adminDatabase.copydb(fromDatabase, toDatabase);
        }

        /// <summary>
        /// Copies the database get nonce.
        /// </summary>
        /// <param name="adminDatabase">The admin database.</param>
        /// <param name="fromDatabase">From database.</param>
        /// <returns></returns>
        public static string CopyDatabaseGetNonce(this IAdminOperations adminDatabase, IDatabase fromDatabase)
        {
            return adminDatabase.copydbgetnonce(fromDatabase);
        }

        /// <summary>
        /// Fs the sync.
        /// </summary>
        /// <param name="adminDatabase">The admin database.</param>
        /// <param name="asynchronous">if set to <c>true</c> [asynchronous].</param>
        /// <param name="shouldLock">if set to <c>true</c> [should lock].</param>
        public static void FSync(this IAdminOperations adminDatabase, bool asynchronous, bool shouldLock)
        {
            adminDatabase.fsync(asynchronous, shouldLock);
        }

        /// <summary>
        /// Replaces the peer.
        /// </summary>
        /// <param name="adminDatabase">The admin database.</param>
        public static void ReplacePeer(this IAdminOperations adminDatabase)
        {
            adminDatabase.replacepeer();
        }

        /// <summary>
        /// Shutdowns the specified admin database.
        /// </summary>
        /// <param name="adminDatabase">The admin database.</param>
        public static void Shutdown(this IAdminOperations adminDatabase)
        {
            adminDatabase.shutdown();
        }

        /// <summary>
        /// Gets the $cmd collection.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static IDBCollection GetCmdCollection(this IAdminOperations db)
        {
            return db.GetCollection("$cmd");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class IDatabaseExtensions
    {

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="collectionUri">The collection URI.</param>
        /// <returns></returns>
        public static IDBCollection GetCollection(this IDatabase db, string collectionUri)
        {
            return db.GetCollection(new Uri(collectionUri, UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The passwd.</param>
        public static void AddUser(this IDatabase db, string username, IEnumerable<char> passwd)
        {
            SecureString ss = new SecureString();
            foreach (char c in passwd)
            {
                ss.AppendChar(c);
            }
            db.AddUser(username, ss);
        }

        /// <summary>
        /// Sets the credentials.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The passwd.</param>
        public static void SetCredentials(this IDBBinding db, string username, IEnumerable<char> passwd)
        {
            SecureString ss = new SecureString();
            foreach (char c in passwd)
            {
                ss.AppendChar(c);
            }
            db.SetCredentials(username, ss);
        }

        /// <summary>
        /// Gets the last error.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static LastError GetLastError(this IDatabase db)
        {
            return db.getlasterror();
        }

        /// <summary>
        /// Gets the previous error.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static PrevError GetPreviousError(this IDatabase db)
        {
            return db.getpreverror();
        }

        /// <summary>
        /// Evaluates the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static object Evaluate(this IDatabase db, string expression, params object[] args)
        {
            return db.eval(expression, args);
        }

        /// <summary>
        /// Resets the error.
        /// </summary>
        /// <param name="db">The db.</param>
        /// Resets the error memory for this database.  Used to clear all errors such that getPreviousError()
        /// will return no error.
        public static void ResetError(this IDatabase db)
        {
            db.reseterror();
        }

        /// <summary>
        /// Forces the error.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        /// For testing purposes only - this method forces an error to help test error handling
        public static DBError ForceError(this IDatabase db)
        {
            return db.forceerror();
        }

        /// <summary>
        /// Drops this database.  Removes all data on disk.  Use with caution.
        /// </summary>
        /// <param name="db">The db.</param>
        public static void Drop(this IDatabase db)
        {
            db.Server.DropDatabase(db);
        }

        /// <summary>
        /// Creates a collection with a given name and options.
        /// If the collection does not exist, a new collection is created.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="name">the name of the collection to create</param>
        /// <param name="capped">true if the collection has a maximum capacity</param>
        /// <param name="size">If non-null, it specifies the maximum size of the collection (in bytes)</param>
        /// <param name="max">If non-null, it specifies the maximum number of documents allowed in the collection</param>
        /// <returns>the collection</returns>
        public static IDBCollection CreateCollection(this IDatabase db, string name, bool? capped = null, int? size = null, int? max = null)
        {
            if (db.ReadOnly)
                throw new ReadOnlyException("Cannot create a collection when using a readonly binding");

            //if we have options
            if (capped.HasValue)
            {
                DBObject options = new DBObject("capped", capped.Value);
                if (size.HasValue)
                {
                    Condition.Requires(size.Value, "size").IsGreaterOrEqual(0);
                    options["size"] = size.Value;
                }

                if (max.HasValue)
                {
                    Condition.Requires(max.Value, "max").IsGreaterOrEqual(0);
                    options["max"] = max.Value;
                }

                //Create with them
                db.create(name, options);
            }
            return db.GetCollection(name);
        }

        /// <summary>
        /// Gets the collection names.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        /// Returns a set of the names of collections in this database.
        /// @return the names of collections in this database
        public static IEnumerable<Uri> GetCollectionNames(this IDatabase db)
        {
            IDBCollection namespaces = db.GetCollection("system.namespaces");
            if (namespaces == null)
                throw new InvalidDataException();

            foreach (IDBObject o in namespaces.Find(DBQuery.SelectAll))
            {
                string name = o.GetAsString("name");
                if (name.Contains("$"))
                    continue;
                string[] parts = name.Split('.');
                if (!parts[0].Equals(db.Uri.GetDatabaseName()))
                    continue;
                yield return new Uri(parts[1], UriKind.Relative);
            }
        }

        /// <summary>
        /// Collections the exists.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="collectionUri">The collection URI.</param>
        /// <returns></returns>
        public static bool CollectionExists(this IDatabase db, Uri collectionUri)
        {
            IDBCollection namespaces = db.GetCollection("system.namespaces");
            if (namespaces == null)
                throw new InvalidDataException();

            IDocument collectionInfo = namespaces.FindOne(Where.Field(name => name == collectionUri.GetFullCollectionName()));
            return collectionInfo != null;
        }

    }
}