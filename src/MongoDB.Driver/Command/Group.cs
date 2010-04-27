using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        public static IDBObject group(this IDatabase db, IDBCollection collection, DBFieldSet key, DBQuery cond, IDocument initial, string reduce)
        {
            DBObject group = new DBObject() 
            {
                  {"ns", collection.Name},
                  {"$reduce", reduce},
            };

            if (key != null)
                group["key"] = key;

            if (cond != null)
                group["cond"] = cond;

            if (initial != null)
                group["initial"] = initial;
            
            IDBObject ret = db.ExecuteCommand(new DBQuery("group", group));
            ret.ThrowIfResponseNotOK("group failed");
            return ret.GetAsIDBObject("retval");
        }
    }
}
