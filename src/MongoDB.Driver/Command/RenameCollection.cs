using System;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Renames the collection.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="collectionUri">The collection URI.</param>
        /// <param name="newCollectionUri">The new collection URI.</param>
        public static void renameCollection(this IDatabase database, Uri collectionUri, Uri newCollectionUri)
        {
            Uri relativeChangeUri = newCollectionUri.IsAbsoluteUri ? collectionUri.MakeRelativeUri(newCollectionUri) : newCollectionUri;

            Uri targetName = new Uri(database.Uri, relativeChangeUri);
            IDBObject ret =
                database
                .ExecuteCommand(new DBQuery
                    {
                          {"renameCollection", collectionUri.GetFullCollectionName()},
                          {"to", targetName.ToString()}
                    });
            ret.ThrowIfResponseNotOK("rename failed");
        }
    }
}
