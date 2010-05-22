
namespace MongoDB.Driver.Command
{
    /// <summary>
    /// Deletes one or all (if index_name is "*") indexes.
    /// </summary>
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Deletes the specified indexes.
        /// </summary>
        /// <remarks>Specifying "*" will delete all indexes on the specified collection.</remarks>
        /// <param name="db">The db.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="indexName">Name of the index.</param>
        public static void deleteIndexes(this IDatabase db, IDBCollection collection, string indexName)
        {
            DBQuery cmd = new DBQuery
            {   
                {"deleteIndexes", collection.Name},
                {"index", string.IsNullOrWhiteSpace(indexName)? "*" : indexName}
            };

            IDBObject res = db.ExecuteCommand(cmd);
            DBError error;
            if (res.WasError(out error))
            {
                if (error.NamespaceWasNotFound)
                    return;
                error.Throw("deleteIndexes failed");
            }
        }

        //{deleteIndexes : collection_name, index : index_name}

        //{nIndexesWas : N, ok : 1}
    }
}
