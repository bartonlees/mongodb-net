//COPYRIGHT

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MongoDB.Driver.Command;
using MongoDB.Driver.Platform.Conditions;
namespace MongoDB.Driver
{
    /// <summary>
    /// Extension method implementations for convenience overrides and common collection operations
    /// </summary>
    public static class IDBCollectionExtensions
    {
        /// <summary>
        /// Ensures an optionally unique index on this collection..
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="indexKeyFieldSet">The index key field set.</param>
        /// <param name="indexUri">The index URI.</param>
        /// <param name="unique">if set to <c>true</c> the index will be unique.</param>
        /// <returns></returns>
        public static IDBIndex EnsureIndex(this IDBCollection collection, DBFieldSet indexKeyFieldSet, string indexUri, bool unique)
        {
            return collection.EnsureIndex(indexKeyFieldSet, new Uri(indexUri, UriKind.RelativeOrAbsolute), unique);
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="indexUri">The index URI.</param>
        /// <returns></returns>
        public static IDBIndex GetIndex(this IDBCollection collection, string indexUri)
        {
            return collection.GetIndex(new Uri(indexUri, UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Saves a document to the database.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="document">The document to save.</param>
        public static void Insert(this IDBCollection collection, IDocument document)
        {
            Condition.Requires(collection, "this").IsNotNull();
            collection.Insert(new IDocument[] { document });
        }

        /// <summary>
        /// Saves a document to the database.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="documents">The documents.</param>
        public static void Insert(this IDBCollection collection, params IDocument[] documents)
        {
            Condition.Requires(collection, "this").IsNotNull();
            collection.Insert(documents as IEnumerable<IDocument>);
        }


        /// <summary>
        /// Saves a document to the database.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="document">The document to save.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        /// <returns></returns>
        public static bool TryInsert(this IDBCollection collection, IDocument document, bool checkError = false)
        {
            Condition.Requires(collection, "this").IsNotNull();
            return collection.TryInsert(new IDocument[] { document }, checkError: false);
        }

        /// <summary>
        /// Saves a document to the database.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="documents">The documents.</param>
        /// <returns></returns>
        public static bool TryInsert(this IDBCollection collection, params IDocument[] documents)
        {
            Condition.Requires(collection, "this").IsNotNull();
            return collection.TryInsert(documents as IEnumerable<IDocument>);
        }

        /// <summary>
        /// Retrieve a sub collection using shorthand notation. The following are equivalent:
        /// <code>
        /// DBCollection users = mongo.getCollection( "wiki" ).GetCollection( "users" );
        /// //and
        /// DBCollection users2 = mongo.getCollection( "wiki.users" );
        /// </code>
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="collectionName">the name of the sub-collection to find</param>
        /// <returns>the sub collection</returns>
        public static IDBCollection GetCollection(this IDBCollection collection, string collectionName)
        {
            Condition.Requires(collection, "this").IsNotNull();
            return collection.Database.GetCollection(collection.Uri + "." + collectionName);
        }

        /// <summary>
        /// Creates an index on a set of fields, if one does not already exist.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="keyFieldSet">key set of the fields desired for the index.</param>
        public static void EnsureIndex(this IDBCollection collection, DBFieldSet keyFieldSet)
        {
            Condition.Requires(collection, "this").IsNotNull();
            collection.EnsureIndex(keyFieldSet, false);
        }

        /// <summary>
        /// Forces the creation of an index on a set of fields, if one does not already exist.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="keyFieldSet">a key set of the fields desired for the index.</param>
        public static void CreateIndex(this IDBCollection collection, DBFieldSet keyFieldSet)
        {
            collection.EnsureIndex(keyFieldSet, true);
        }

        /// <summary>
        /// Creates an index on a set of fields, if one does not already exist.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="keyFieldSet">a key set of the fields desired for the index.</param>
        /// <param name="force">if set to <c>true</c> index creation should be forced, even if it is unnecessary.</param>
        /// <returns></returns>
        public static IDBIndex EnsureIndex(this IDBCollection collection, DBFieldSet keyFieldSet, bool force)
        {
            Condition.Requires(collection, "this").IsNotNull();
            return collection.EnsureIndex(keyFieldSet, null, false);
        }

        //TODO: $natural keyword? http://blog.mongodb.org/post/116405435/capped-collections

        /// <summary>
        /// Gets a cursor for any available IDocument Implementation (Document, RawDocument, etc.)
        /// </summary>
        /// <typeparam name="TDoc">The type of the document.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector query document used to search.</param>
        /// <param name="returnFields">A document that specifies what subset of fields of matching objects to return. (sending null will retrieve all fields)</param>
        /// <param name="orderBy">The "order by" field set.</param>
        /// <param name="numberToSkip">Skip the first <tt>numToSkip</tt> matches before returning.</param>
        /// <param name="numberToReturn">The number to return.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="snapshot">if set to <c>true</c> [snapshot].</param>
        /// <param name="options">The options.</param>
        /// <param name="explicitIndexHint">The explicit index hint.</param>
        /// <returns>the matching objects</returns>
        public static IDBCursor<TDoc> GetCursor<TDoc>(
            this IDBCollection collection,
            DBQuery selector = null,
            DBFieldSet returnFields = null,
            DBFieldSet orderBy = null,
            int? numberToSkip = null,
            int? numberToReturn = null,
            int? limit = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None,
            IDBIndex explicitIndexHint = null)
            where TDoc : class, IDocument
        {
            DBCursorOptions cursorOptions = new DBCursorOptions(
                collection: collection,
                returnFields: returnFields,
                explain: explain,
                explicitIndexHint: explicitIndexHint,
                flags: options,
                orderBy: orderBy,
                snapshot: snapshot,
                numberToReturn: numberToReturn,
                numberToSkip: numberToSkip,
                limit: limit,
                selector: selector
            );
            return new DBCursor<TDoc>(cursorOptions);
        }

        /// <summary>
        /// Gets a cursor for standard Documents
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector query document used to search.</param>
        /// <param name="returnFields">A document that specifies what subset of fields of matching objects to return. (sending null will retrieve all fields)</param>
        /// <param name="orderBy">The order by field set.</param>
        /// <param name="numberToSkip">Skip the first <tt>numToSkip</tt> matches before returning.</param>
        /// <param name="numberToReturn">The number to return.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="snapshot">if set to <c>true</c> [snapshot].</param>
        /// <param name="options">The options.</param>
        /// <param name="explicitIndexHint">The explicit index hint.</param>
        /// <returns>the matching objects</returns>
        public static IDBCursor<Document> GetCursor(
            this IDBCollection collection,
            DBQuery selector = null,
            DBFieldSet returnFields = null,
            DBFieldSet orderBy = null,
            int? numberToSkip = null,
            int? numberToReturn = null,
            int? limit = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None,
            IDBIndex explicitIndexHint = null)
        {
            return GetCursor<Document>(
                collection: collection,
                returnFields: returnFields,
                explain: explain,
                explicitIndexHint: explicitIndexHint,
                options: options,
                orderBy: orderBy,
                snapshot: snapshot,
                numberToReturn: numberToReturn,
                numberToSkip: numberToSkip,
                limit: limit,
                selector: selector
            );
        }


        /// <summary>
        /// Finds one or more objects.
        /// </summary>
        /// <typeparam name="TDoc">The type of the doc.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector query document used to search.</param>
        /// <param name="returnFields">A document that specifies what subset of fields of matching objects to return. (sending null will retrieve all fields)</param>
        /// <param name="orderBy">The order by field set.</param>
        /// <param name="numberToSkip">Skip the first <tt>numToSkip</tt> matches before returning.</param>
        /// <param name="numberToReturn">The number to return.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="snapshot">if set to <c>true</c> [snapshot].</param>
        /// <param name="options">The options.</param>
        /// <param name="explicitIndexHint">The explicit index hint.</param>
        /// <returns>the matching objects</returns>
        public static IEnumerable<TDoc> Find<TDoc>(
            this IDBCollection collection,
            DBQuery selector = null,
            DBFieldSet returnFields = null,
            DBFieldSet orderBy = null,
            int? numberToSkip = null,
            int? numberToReturn = null,
            int? limit = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None,
            IDBIndex explicitIndexHint = null)
            where TDoc : class, IDocument
        {
            using (IDBCursor<TDoc> cursor = GetCursor<TDoc>(
                collection: collection,
                returnFields: returnFields,
                explain: explain,
                explicitIndexHint: explicitIndexHint,
                options: options,
                orderBy: orderBy,
                snapshot: snapshot,
                numberToReturn: numberToReturn,
                numberToSkip: numberToSkip,
                limit: limit,
                selector: selector
            ))
            {
                foreach (TDoc document in cursor.DocumentsT)
                {
                    yield return document;
                }
            }
        }

        /// <summary>
        /// Finds the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="returnFields">The desired field set.</param>
        /// <param name="orderBy">The order by field set.</param>
        /// <param name="numberToSkip">The number to skip.</param>
        /// <param name="numberToReturn">The number to return.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="snapshot">if set to <c>true</c> [snapshot].</param>
        /// <param name="options">The options.</param>
        /// <param name="explicitIndexHint">The explicit index hint.</param>
        /// <returns></returns>
        public static IEnumerable<IDocument> Find(
            this IDBCollection collection,
            DBQuery selector = null,
            DBFieldSet returnFields = null,
            DBFieldSet orderBy = null,
            int? numberToSkip = null,
            int? numberToReturn = null,
            int? limit = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None,
            IDBIndex explicitIndexHint = null)
        {
            return Find<Document>(
                collection: collection,
                selector: selector,
                returnFields: returnFields,
                orderBy: orderBy,
                numberToSkip: numberToSkip,
                numberToReturn: numberToReturn,
                limit: limit,
                explain: explain,
                snapshot: snapshot,
                options: options,
                explicitIndexHint: explicitIndexHint
            );
        }

        /// <summary>
        /// Finds an object by its id.
        /// This compares the passed in value to the _id field of the document
        /// </summary>
        /// <typeparam name="TDoc">The type of the doc type.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The id.</param>
        /// <param name="returnFields">Which fields to return or <c>null</c> for all.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="snapshot">if set to <c>true</c> [snapshot].</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// the object, if found, otherwise <code>null</code>
        /// </returns>
        public static TDoc FindByID<TDoc>(this IDBCollection collection,
            object id,
            DBFieldSet returnFields = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None)
            where TDoc : class, IDocument
        {
            IDBIndex idIndex = collection.EnsureIDIndex();

            return FindOne<TDoc>(
                collection,
                selector: new DBQuery("_id", id),
                returnFields: returnFields,
                explain: explain,
                snapshot: snapshot,
                options: options,
                explicitIndexHint: idIndex);
        }

        /// <summary>
        /// Finds an object by its id.
        /// This compares the passed in value to the _id field of the document
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The id.</param>
        /// <param name="returnFields">Which fields to return or <c>null</c> for all.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="snapshot">if set to <c>true</c> [snapshot].</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// the object, if found, otherwise <code>null</code>
        /// </returns>
        public static IDocument FindByID(this IDBCollection collection,
            object id,
            DBFieldSet returnFields = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None)
        {

            return FindByID<Document>(
                collection,
                id: id,
                returnFields: returnFields,
                explain: explain,
                snapshot: snapshot,
                options: options);
        }

        /// <summary>
        /// Returns a single object from this collection matching the query.
        /// </summary>
        /// <typeparam name="TDoc">The type of the doc.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector query.</param>
        /// <param name="returnFields">The desired field set or <c>null</c> for all fields.</param>
        /// <param name="numToSkip">The num to skip.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="snapshot">if set to <c>true</c> [snapshot].</param>
        /// <param name="options">The options.</param>
        /// <param name="explicitIndexHint">The explicit index hint.</param>
        /// <returns>
        /// the object found, or <code>null</code> if no such object exists
        /// </returns>
        public static TDoc FindOne<TDoc>(this IDBCollection collection,
            DBQuery selector = null,
            DBFieldSet returnFields = null,
            int? numToSkip = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None,
            IDBIndex explicitIndexHint = null)
            where TDoc : class, IDocument
        {
            foreach (TDoc result in
                collection.Find<TDoc>(
                    selector: selector,
                    returnFields: returnFields,
                    numberToSkip: numToSkip,
                    limit: 1,
                    explain: explain,
                    snapshot: snapshot,
                    options: options,
                    explicitIndexHint: explicitIndexHint))
                return result;
            return default(TDoc);
        }

        /// <summary>
        /// Returns a single object from this collection matching the query.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector query.</param>
        /// <param name="returnFields">The desired field set or <c>null</c> for all fields.</param>
        /// <param name="numToSkip">The num to skip.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="options">The options.</param>
        /// <param name="explicitIndexHint">The explicit index hint.</param>
        /// <returns>
        /// the object found, or <code>null</code> if no such object exists
        /// </returns>
        public static IDocument FindOne(this IDBCollection collection,
            DBQuery selector = null,
            DBFieldSet returnFields = null,
            int? numToSkip = null,
            bool explain = false,
            CursorFlags options = CursorFlags.None,
            IDBIndex explicitIndexHint = null)
        {
            return FindOne<Document>(
                collection: collection,
                selector: selector,
                returnFields: returnFields,
                numToSkip: numToSkip,
                explain: explain,
                options: options,
                explicitIndexHint: explicitIndexHint);
        }

        /// <summary>
        /// Saves an object to this collection.
        /// will add <code>_id</code> field if needed
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="document">The target document.</param>
        public static void Save(this IDBCollection collection, IDocument document)
        {
            Condition.Requires(document, "document").IsNotNull()
                .Evaluate(!document.Partial, "cannot save a partial document");
            if (collection.ReadOnly)
                throw new ReadOnlyException("Cannot save to a readonly binding");

            document.Validate();

            if ((document.State & DocumentState.Detached) != DocumentState.None)
            {
                collection.Insert(document);
            }
            else
            {
                collection.Update(new DBQuery("_id", document.ID), document: document, upsert: true);
            }
        }

        /// <summary>
        /// Trys to aaves an object to this collection.
        /// will add <code>_id</code> field if needed
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="document">The target document.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        /// <returns></returns>
        public static bool TrySave(this IDBCollection collection, IDocument document, bool checkError = false)
        {
            if (document == null ||
                collection == null ||
                collection.ReadOnly ||
                document.Partial
                )
                return false;

            document.Validate();

            if ((document.State & DocumentState.Detached) != DocumentState.None)
            {
                return collection.TryInsert(document, checkError: checkError);
            }
            else
            {
                return collection.TryUpdate(new DBQuery("_id", document.ID), document: document, upsert: true);
            }
        }

        /// <summary>
        /// Drops all indexes from this collection
        /// </summary>
        /// <param name="collection">The collection.</param>
        public static void DropAllIndexes(this IDBCollection collection)
        {
            collection.DropIndex((IDBIndex)null);
        }

        /// <summary>
        /// Drops (deletes) this collection
        /// </summary>
        /// <param name="collection">The collection.</param>
        public static void Drop(this IDBCollection collection)
        {
            collection.Database.DropCollection(collection);
        }

        /// <summary>
        /// Returns the number of documents in the collection that match the specified query
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector query.</param>
        /// <param name="returnFields">The desired field set.</param>
        /// <returns>
        /// number of documents that match query and fields
        /// </returns>
        public static long GetCount(this IDBCollection collection, DBQuery selector = null, DBFieldSet returnFields = null)
        {
            DBQuery cmd = new DBQuery
            {
                {"count", collection.Name},
                {"query", selector ?? DBQuery.SelectAll}
            };
            if (returnFields != null)
            {
                cmd["fields"] = returnFields;
            }

            IDBObject res = collection.Database.ExecuteCommand(cmd);
            DBError error;
            if (res.WasError(out error))
            {

                if (error.NamespaceWasNotFound)
                {
                    // for now, return 0 - lets pretend it does exist
                    return 0;
                }
                error.Throw("getCount failed");
            }
            return res.GetAsLong("n");
        }

        /// <summary>
        /// Renames this collection
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="newName">new collection name (not a full namespace)</param>
        public static void Rename(this IDBCollection collection, Uri newName)
        {
            if (collection.ReadOnly)
                throw new ReadOnlyException("Cannot rename a collection when using a readonly binding");
            collection.Database.renameCollection(collection.Uri, newName);
        }

        /// <summary>
        /// Renames this collection
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="newName">new collection name (not a full namespace)</param>
        public static void Rename(this IDBCollection collection, string newName)
        {
            Rename(collection, new Uri(newName, UriKind.Relative));
        }

        /// <summary>
        /// Performs a group query, similar to the ‘SQL GROUP BY’ operation.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="key">either 1) an array of fields to group by, 2) a javascript function to generate the key object, or 3) nil.</param>
        /// <param name="cond">an optional document specifying a query to limit the documents over which group is run.</param>
        /// <param name="initial">initial value of the aggregation counter object</param>
        /// <param name="reduce">aggregation function as a JavaScript string</param>
        /// <returns>the grouped items</returns>
        public static IDBObject Group(this IDBCollection collection, DBFieldSet key, DBQuery cond, IDocument initial, string reduce)
        {
            return collection.Database.group(collection, key, cond ?? DBQuery.SelectAll, initial, reduce);
        }

        /// <summary>
        /// find distinct values for a key field and an optional query
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="keyField">The key field.</param>
        /// <param name="selector">an optional selector query to limit the documents over which the unique function is run.</param>
        /// <returns></returns>
        public static IList Distinct(this IDBCollection collection, string keyField, DBQuery selector = null)
        {
            DBQuery c = new DBQuery
            {
                {"distinct", collection.Name},
                {"key", keyField},
                {"query", selector ?? DBQuery.SelectAll}
            };

            IDBObject res = collection.Database.ExecuteCommand(c);
            res.ThrowIfResponseNotOK("distinct failed");
            return (IList)(res["values"]);
        }

        /// <summary>
        /// Performs a map/reduce operation on the current collection. Returns a new collection containing the results of the operation.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="map">a map function, written in javascript.</param>
        /// <param name="reduce">a reduce function, written in javascript.</param>
        /// <param name="outputCollection">the name of the output collection. if specified, the collection will not be treated as temporary</param>
        /// <param name="query">a query selector document (like what is passed to find) to limit the operation to a subset of the collection.</param>
        /// <returns>the map/reduced result</returns>
        public static MapReduceInfo MapReduce(this IDBCollection collection, string map, string reduce, string outputCollection, DBQuery query)
        {
            DBQuery b = new DBQuery 
            {
                {"mapreduce", collection.Name},
                {"map", map},
                {"reduce", reduce}
            };

            if (outputCollection != null)
                b.Add("out", outputCollection);

            if (query != null)
                b.Add("query", query);

            return collection.MapReduce(b);
        }

        /// <summary>
        /// Performs a map/reduce operation on the current collection. Returns a new collection containing the results of the operation.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="command">The command.</param>
        /// <returns>the map/reduced result</returns>
        public static MapReduceInfo MapReduce(this IDBCollection collection, DBQuery command)
        {
            if (command["mapreduce"] == null)
                throw new ArgumentException("need mapreduce arg");
            if (collection.ReadOnly)
                throw new ReadOnlyException("Cannot mapreduce when using a readonly binding...a new collection is created as result");
            DBObject res = (DBObject)(collection.Database.ExecuteCommand(command));
            res.ThrowIfResponseNotOK("mapreduce failed");
            return new MapReduceInfo(collection, res);
        }

        /// <summary>
        /// Return a list of the indexes for this collection.  Each object in the list is the "info document" from MongoDB
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>list of index info documents</returns>
        public static IEnumerable<IDBObject> GetIndexInfo(this IDBCollection collection)
        {
            DBQuery cmd = new DBQuery();
            cmd["ns"] = collection.FullName;
            return collection.Database.GetCollection("system.indexes").Find(cmd);
        }

        /// <summary>
        /// Drops the index associated with the specified key set
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="keyFieldSet">The key field set.</param>
        public static void DropIndex(this IDBCollection collection, DBFieldSet keyFieldSet)
        {
            collection.DropIndex(keyFieldSet.GenerateIndexUri().GetIndexName());
        }

        /// <summary>
        /// Drops the named index.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name of the index to drop.</param>
        public static void DropIndex(this IDBCollection collection, string name)
        {
            collection.DropIndex(collection.GetIndex(new Uri(name, UriKind.RelativeOrAbsolute)));
        }

        /// <summary>
        /// Ensures an index on this collection (that is, the index will be created if it does not exist).
        /// ensureIndex is optimized and is inexpensive if the index already exists.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="indexKeysFieldSet">Fields to use for index.</param>
        /// <param name="name">An identifier for the index.</param>
        /// <returns></returns>
        public static IDBIndex EnsureIndex(this IDBCollection collection, DBFieldSet indexKeysFieldSet, Uri name)
        {
            return collection.EnsureIndex(indexKeysFieldSet, name, false);
        }

        /// <summary>
        /// Updates the specified collection using an explicit selector and modifier expression.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="modifier">The modifier.</param>
        /// <param name="multi">if set to <c>true</c> then allow the update of multiple matching documents.</param>
        public static void Update(this IDBCollection collection, DBQuery selector, DBModifier modifier, bool multi = true)
        {
            collection.Update(selector: selector, document: null, modifier: modifier, multi: multi);
        }

        /// <summary>
        /// Updates the specified collection using an explicit selector and document.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="document">The document.</param>
        /// <param name="upsert">if set to <c>true</c> then the matching documents will either be updated or inserted (depending on existence)</param>
        /// <param name="multi">if set to <c>true</c> then allow the update of multiple matching documents.</param>
        public static void Update(this IDBCollection collection, DBQuery selector, IDocument document, bool upsert = true, bool multi = true)
        {
            collection.Update(selector: selector, modifier: null, document: document, upsert: upsert, multi: multi);
        }

        /// <summary>
        /// Updates the specified collection using the select all query and a modifier expression.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="modifier">The modifier.</param>
        /// <param name="multi">if set to <c>true</c> then allow the update of multiple matching documents.</param>
        public static void Update(this IDBCollection collection, DBModifier modifier, bool multi = true)
        {
            collection.Update(selector: null, document: null, modifier: modifier, multi: multi);
        }

        /// <summary>
        /// Updates the specified collection select all query and a document.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="document">The document.</param>
        /// <param name="upsert">if set to <c>true</c> then the matching documents will either be updated or inserted (depending on existence)</param>
        /// <param name="multi">if set to <c>true</c> then allow the update of multiple matching documents.</param>
        public static void Update(this IDBCollection collection, IDocument document, bool upsert = true, bool multi = true)
        {
            collection.Update(selector: null, modifier: null, document: document, upsert: upsert, multi: multi);
        }
    }
}