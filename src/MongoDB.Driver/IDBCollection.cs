//COPYRIGHT

using System.Collections.Generic;
using System;
using System.Collections;
using MongoDB.Driver.Platform.Conditions;
using MongoDB.Driver.Command;
using System.Data;
namespace MongoDB.Driver
{
    /// <summary>
    /// This interface represents the core operations and data of a MongoDB collection
    /// </summary>
    public interface IDBCollection : IEnumerable<IDocument>
    {
        /// <summary>
        /// Gets the DB.
        /// </summary>
        /// <value>The DB.</value>
        IDatabase Database { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Gets the full name. (database.collection)
        /// </summary>
        /// <value>The full name.</value>
        string FullName { get; }

        /// <summary>
        /// Gets the absolute URI for this collection.
        /// </summary>
        /// <value>The URI.</value>
        Uri Uri { get; }

        /// <summary>
        /// Gets or sets the index hint field sets.
        /// </summary>
        /// <value>The index hint field sets.</value>
        IEnumerable<DBFieldSet> IndexHintFieldSets { get; set; }

        /// <summary>
        /// Saves a series of documents to the database.
        /// </summary>
        /// <param name="documents">The series</param>
        void Insert(IEnumerable<IDocument> documents, bool checkError = false);

        /// <summary>
        /// Tries to saves a series of documents to the database.
        /// </summary>
        /// <param name="documents">The series</param>
        bool TryInsert(IEnumerable<IDocument> documents, bool checkError = false);

        /// <summary>
        /// Performs an update operation.
        /// </summary>
        /// <param name="selector">search query for old object to update.</param>
        /// <param name="document">The document.</param>
        /// <param name="modifier">The modifier.</param>
        /// <param name="upsert">if set to <c>true</c> then the matching documents will either be updated or inserted (depending on existence)</param>
        /// <param name="multi">if set to <c>true</c> then allow the update of multiple matching documents.</param>
        void Update(DBQuery selector = null, IDocument document = null, DBModifier modifier = null, bool upsert = false, bool multi = false, bool checkError = false);

        /// <summary>
        /// Tries to perform an update operation.
        /// </summary>
        /// <param name="selector">search query for old object to update.</param>
        /// <param name="document">The document.</param>
        /// <param name="modifier">The modifier.</param>
        /// <param name="upsert">if set to <c>true</c> then the matching documents will either be updated or inserted (depending on existence)</param>
        /// <param name="multi">if set to <c>true</c> then allow the update of multiple matching documents.</param>
        bool TryUpdate(DBQuery selector = null, IDocument document = null, DBModifier modifier = null, bool upsert = false, bool multi = false, bool checkError = false);

        /// <summary>
        /// Removes the specified object from the collection.
        /// </summary>
        /// <param name="document">The object to remove.</param>
        void Remove(IDocument document, bool checkError = false);

        /// <summary>
        /// Removes the specified object from the collection.
        /// </summary>
        /// <param name="document">The object to remove.</param>
        bool TryRemove(IDocument document, bool checkError = false);

        /// <summary>
        /// Uses OP_QUERY message to retrieve the first batch of documents in a query
        /// </summary>
        /// <typeparam name="TDoc">The type of the document proxy</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <returns>The documents of this batch</returns>
        IEnumerable<TDoc> Query<TDoc>(IDBCursor<TDoc> cursor) where TDoc : class, IDocument;

        /// <summary>
        /// Uses OP_GETMORE to retrieve more documents for the specified cursor
        /// </summary>
        /// <typeparam name="TDoc">The type of the document proxy.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <returns>The documents of this batch</returns>
        IEnumerable<TDoc> GetMore<TDoc>(IDBCursor<TDoc> cursor) where TDoc : class, IDocument;

        /// <summary>
        /// Ensures an optionally unique index on this collection..
        /// </summary>
        /// <param name="indexKeysFieldSet">The keys.</param>
        /// <param name="name">The name.</param>
        /// <param name="force">if set to <c>true</c> index creation should be forced, even if it is unnecessary.</param>
        /// <param name="unique">if set to <c>true</c> the index will be unique.</param>
        IDBIndex EnsureIndex(DBFieldSet indexKeyFieldSet, Uri name, bool unique);

        /// <summary>
        /// Enumerates all indexes known to the server.
        /// </summary>
        /// <value>The indexes.</value>
        IEnumerable<IDBIndex> Indexes { get; }

        /// <summary>
        /// Gets the index specified by the URI.
        /// </summary>
        /// <param name="indexUri">The index URI.</param>
        /// <returns></returns>
        IDBIndex GetIndex(Uri indexUri);

        /// <summary>
        /// Ensures that there is an index for the ID Field.
        /// </summary>
        IDBIndex EnsureIDIndex();

        /// <summary>
        /// Drops the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        void DropIndex(IDBIndex index);

        /// <summary>
        /// Resets the index cache.
        /// </summary>
        void ClearIndexCache();

        /// <summary>
        /// Gets a value indicating whether the collection is read only.
        /// </summary>
        /// <value><c>true</c> if the collection is read only; otherwise, <c>false</c>.</value>
        bool ReadOnly { get; }
    }
}