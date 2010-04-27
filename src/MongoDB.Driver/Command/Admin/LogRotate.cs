using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        public static void logRotate(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_logRotate);
            response.ThrowIfResponseNotOK("buildinfo failed");
        }
        static DBQuery _logRotate = new DBQuery("logRotate", 1);
    }
}
