using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    /// <summary>
    /// Drops a collection.
    /// </summary>
    internal static partial class CommandExtensions
    {
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
