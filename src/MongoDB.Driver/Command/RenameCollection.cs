using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
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
