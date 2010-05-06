using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace MongoDB.Newtonsoft.Json
{
    public static class JsonIDBCollectionExtensions
    {
        /// <summary>
        /// Gets a cursor for contract Documents of type T
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
        public static IDBCursor<ContractDocument<T>> GetContractDocumentCursor<T>(
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
            IDBIndex explicitIndexHint = null) where T:new()
        {
            return IDBCollectionExtensions.GetCursor<ContractDocument<T>>(
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
        /// Finds the specified contract document collection.
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
        public static IEnumerable<ContractDocument<T>> FindContractDocuments<T>(
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
            IDBIndex explicitIndexHint = null) where T : new()
        {
            return IDBCollectionExtensions.Find<ContractDocument<T>>(
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
        /// <param name="id">The id.</param>
        /// <param name="returnFields">Which fields to return or <c>null</c> for all.</param>
        /// <returns>the object, if found, otherwise <code>null</code></returns>
        public static ContractDocument<T> FindContractDocumentByID<T>(this IDBCollection collection,
            object id,
            DBFieldSet returnFields = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None) where T : new()
        {
            return IDBCollectionExtensions.FindByID<ContractDocument<T>>(
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
        public static ContractDocument<T> FindOneContractDocument<T>(this IDBCollection collection,
            DBQuery selector = null,
            DBFieldSet returnFields = null,
            int? numToSkip = null,
            bool explain = false,
            CursorFlags options = CursorFlags.None,
            IDBIndex explicitIndexHint = null) where T : new()
        {
            return IDBCollectionExtensions.FindOne<ContractDocument<T>>(
                collection: collection,
                selector: selector,
                returnFields: returnFields,
                numToSkip: numToSkip,
                explain: explain,
                options: options,
                explicitIndexHint: explicitIndexHint);
        }
    }
}
