//COPYRIGHT

using System;
using System.Collections.Generic;
namespace MongoDB.Driver
{
    /// <summary>
    /// A proxy representation of a remote MongoDB collection
    /// </summary>
    /// <remarks>
    /// An <c>IDBCollection</c> is a member of an <see cref="T:MongoDB.Driver.IDatabase"/> and contains
    /// <see cref="T:MongoDB.Driver.IDBIndex"/> instances and houses a collection of<see cref="T:MongoDB.Driver.IDocument"/>
    /// instances that can be saved and loaded.
    /// <example caption="Attaching to a remote collection">
    /// <code>
    /// IDatabase database = ...
    /// 
    /// //GetCollection creates the named collection if it does not already exist
    /// IDBCollection col1 = database.GetCollection("collectionName");
    /// 
    /// //Shorthand for GetCollection using array index syntax
    /// IDBCollection col2 = database["collectionName"];
    /// 
    /// //Explicitly create a collection
    /// IDBCollection col3 = database.CreateCollection("collectionName");
    /// </code>
    /// </example>
    /// <example caption="[http://www.mongodb.org/display/DOCS/Capped+Collections capped collections]">
    /// //Create a capped collection that will not exceed 100 bytes
    /// IDBCollection col4 = database.CreateCollection("collectionName", capped:true, size:100);
    /// 
    /// //Create a capped collection that will not exceed 100 bytes, and will contain no more than 5 documents
    /// IDBCollection col5 = database.CreateCollection("collectionName", capped:true, size:100, max:5);
    /// </example>
    /// </remarks>
    public interface IDBCollection : IEnumerable<IDocument>, IUriComparable
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
        /// Gets or sets the index hint field sets.
        /// </summary>
        /// <value>The index hint field sets.</value>
        IEnumerable<DBFieldSet> IndexHintFieldSets { get; set; }

        /// <summary>
        /// Saves a series of documents to the database.
        /// </summary>
        /// <param name="documents">The series</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        void Insert(IEnumerable<IDocument> documents, bool checkError = false);

        /// <summary>
        /// Tries to saves a series of documents to the database.
        /// </summary>
        /// <param name="documents">The series</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        /// <returns></returns>
        bool TryInsert(IEnumerable<IDocument> documents, bool checkError = false);

        /// <summary>
        /// Performs an update operation.
        /// </summary>
        /// <param name="selector">search query for old object to update.</param>
        /// <param name="document">The document.</param>
        /// <param name="modifier">The modifier.</param>
        /// <param name="upsert">if set to <c>true</c> then the matching documents will either be updated or inserted (depending on existence)</param>
        /// <param name="multi">if set to <c>true</c> then allow the update of multiple matching documents.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        void Update(DBQuery selector = null, IDocument document = null, DBModifier modifier = null, bool upsert = false, bool multi = false, bool checkError = false);

        /// <summary>
        /// Tries to perform an update operation.
        /// </summary>
        /// <param name="selector">search query for old object to update.</param>
        /// <param name="document">The document.</param>
        /// <param name="modifier">The modifier.</param>
        /// <param name="upsert">if set to <c>true</c> then the matching documents will either be updated or inserted (depending on existence)</param>
        /// <param name="multi">if set to <c>true</c> then allow the update of multiple matching documents.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        /// <returns></returns>
        bool TryUpdate(DBQuery selector = null, IDocument document = null, DBModifier modifier = null, bool upsert = false, bool multi = false, bool checkError = false);

        /// <summary>
        /// Removes the specified object from the collection.
        /// </summary>
        /// <param name="document">The object to remove.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        void Remove(IDocument document, bool checkError = false);

        /// <summary>
        /// Removes the specified object from the collection.
        /// </summary>
        /// <param name="document">The object to remove.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        /// <returns></returns>
        bool TryRemove(IDocument document, bool checkError = false);

        /// <summary>
        /// Uses OP_QUERY message to retrieve the first batch of documents in a query
        /// </summary>
        /// <typeparam name="TDoc">A type that implements <see cref="T:MongoDB.Driver.IDocument"/>.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <returns>The documents of this batch</returns>
        IEnumerable<TDoc> Query<TDoc>(IDBCursor<TDoc> cursor) where TDoc : class, IDocument;

        /// <summary>
        /// Uses OP_GETMORE to retrieve more documents for the specified cursor
        /// </summary>
        /// <typeparam name="TDoc">A type that implements <see cref="T:MongoDB.Driver.IDocument"/>.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <returns>The documents of this batch</returns>
        IEnumerable<TDoc> GetMore<TDoc>(IDBCursor<TDoc> cursor) where TDoc : class, IDocument;

        /// <summary>
        /// Ensures an optionally unique index on this collection..
        /// </summary>
        /// <param name="indexKeyFieldSet">The index key field set.</param>
        /// <param name="name">The name.</param>
        /// <param name="unique">if set to <c>true</c> the index will be unique.</param>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <value>
        /// 	<c>true</c> if the collection is read only; otherwise, <c>false</c>.
        /// </value>
        bool ReadOnly { get; }
    }
}