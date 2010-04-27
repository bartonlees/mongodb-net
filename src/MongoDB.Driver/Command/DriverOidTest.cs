using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        public static string driverOIDTest(this IDatabase db, Oid id)
        {
            IDBObject res = db.ExecuteCommand(new DBQuery("driverOIDTest", id));
            res.ThrowIfResponseNotOK("unable to retrieve string representation of OID");
            return res.GetAsString("str");
        }
    }
}
