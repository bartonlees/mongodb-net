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
using System.Data;

namespace MongoDB.Driver
{
    public static class IAdminDatabaseExtensions
    {
        public static void CloseAllDatabases(this IAdminOperations adminDatabase)
        {
            adminDatabase.closeAllDatabases();
        }

        public static void CopyDatabase(this IAdminOperations adminDatabase, IDatabase fromDatabase, IDatabase toDatabase)
        {
            if (toDatabase.ReadOnly)
                throw new ReadOnlyException("Cannot copy to a readonly binding");

            adminDatabase.copydb(fromDatabase, toDatabase);
        }

        public static string CopyDatabaseGetNonce(this IAdminOperations adminDatabase, IDatabase fromDatabase)
        {
            return adminDatabase.copydbgetnonce(fromDatabase);
        }

        public static void FSync(this IAdminOperations adminDatabase, bool asynchronous, bool shouldLock)
        {
            adminDatabase.fsync(asynchronous, shouldLock);
        }

        public static void ReplacePeer(this IAdminOperations adminDatabase)
        {
            adminDatabase.replacepeer();
        }

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

    public static class IDatabaseExtensions
    {

        public static IDBCollection GetCollection(this IDatabase db, string collectionUri)
        {
            return db.GetCollection(new Uri(collectionUri, UriKind.RelativeOrAbsolute));
        }

        public static void AddUser(this IDatabase db, string username, IEnumerable<char> passwd)
        {
            SecureString ss = new SecureString();
            foreach (char c in passwd)
            {
                ss.AppendChar(c);
            }
            db.AddUser(username, ss);
        }

        public static void SetCredentials(this IDBBinding db, string username, IEnumerable<char> passwd)
        {
            SecureString ss = new SecureString();
            foreach (char c in passwd)
            {
                ss.AppendChar(c);
            }
            db.SetCredentials(username, ss);
        }

        public static LastError GetLastError(this IDatabase db)
        {
            return db.getlasterror();
        }

        public static PrevError GetPreviousError(this IDatabase db)
        {
            return db.getpreverror();
        }

        public static object Evaluate(this IDatabase db, string expression, params object[] args)
        {
            return db.eval(expression, args);
        }

        /**
        *  Resets the error memory for this database.  Used to clear all errors such that getPreviousError()
        *  will return no error.
        */
        public static void ResetError(this IDatabase db)
        {
            db.reseterror();
        }

        /**
         *  For testing purposes only - this method forces an error to help test error handling
         */ 
        public static DBError ForceError(this IDatabase db)
        {
            return db.forceerror();
        }

        /// <summary>
        /// Drops this database.  Removes all data on disk.  Use with caution.
        /// </summary>
        public static void Drop(this IDatabase db)
        {
            db.Server.DropDatabase(db);
        }

        /// <summary>
        /// Creates a collection with a given name and options.
        /// If the collection does not exist, a new collection is created.
        /// </summary>
        /// <param name="name">the name of the collection to create</param>
        /// <param name="capped">true if the collection has a maximum capacity</param>
        /// <param name="size">If non-null, it specifies the maximum size of the collection (in bytes)</param>
        /// <param name="max">If non-null, it specifies the maximum number of documents allowed in the collection</param>
        /// <returns>the collection</returns>
        public static IDBCollection CreateCollection(this IDatabase db, string name, bool? capped = null, int? size = null, int? max = null )
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

        /** Returns a set of the names of collections in this database.
         * @return the names of collections in this database
         */
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