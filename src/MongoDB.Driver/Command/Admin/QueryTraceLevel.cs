using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        public static void queryTraceLevel(this IAdminOperations db, int traceLevel)
        {
            DBQuery query = new DBQuery("queryTraceLevel", traceLevel);
            IDBObject response = db.ExecuteCommand(query);
            response.ThrowIfResponseNotOK("queryTraceLevel failed");
        }
    }
}
