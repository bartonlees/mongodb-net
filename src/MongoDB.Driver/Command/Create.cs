using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        public static void create(this IDatabase db, string collectionName, IDBObject options)
        {
            DBQuery createCmd = new DBQuery("create", collectionName);
            createCmd.PutAll(options);
            IDBObject result = db.ExecuteCommand(createCmd);
            result.ThrowIfResponseNotOK("create failed");
        }
    }
}
