using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        public static void shutdown(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_shutdown);
            response.ThrowIfResponseNotOK("shutdown failed");
        }
        static DBQuery _shutdown = new DBQuery("shutdown", 1);
    }
}
