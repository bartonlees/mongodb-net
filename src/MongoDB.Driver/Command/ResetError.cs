using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        public static void reseterror(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_reseterror);
            res.ThrowIfResponseNotOK("reseterror failed");
        }
        
        //{reseterror : 1}
        static DBQuery _reseterror = new DBQuery("reseterror", 1);
    }
}
