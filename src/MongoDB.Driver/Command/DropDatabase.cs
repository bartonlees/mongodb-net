using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        public static void dropDatabase(this IDatabase db, string dbName)
        {
            IDBObject res = db.ExecuteCommand(_dropDatabase);
            //{ok : 1}
            res.ThrowIfResponseNotOK("dropDatabse failed");
        }

        //{dropDatabase : 1}
        static DBQuery _dropDatabase = new DBQuery("dropDatabase", 1);
    }
}
