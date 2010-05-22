
namespace MongoDB.Driver.Command
{
    /// <summary>
    /// Drops a collection.
    /// </summary>
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Drops the specified collection from the database.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="collectionFullName">Full name of the collection.</param>
        public static void drop(this IDatabase db, string collectionFullName)
        {
            //{drop : collection_name}
            IDBObject res = db.ExecuteCommand(new DBQuery("drop", collectionFullName));
            DBError error;
            if (res.WasError(out error))
            {
                if (error.NamespaceWasNotFound) //We can drop a collection that doesn't exist...its easy!
                    return;
                error.Throw("drop (collection) failed");
            }
        }

        //TODO:relay these response details?
        // {nIndexesWas : N,
        //msg : "all indexes deleted for collection",
        //ns : namespace,
        //"ok" : 1}
    }
}
