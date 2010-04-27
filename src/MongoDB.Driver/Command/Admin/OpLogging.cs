using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command.Admin
{
    /// <summary>
    /// Checks opLogging settings
    /// </summary>
    internal static partial class AdminCommandExtensions
    {
        public static void opLogging(this IAdminOperations db, bool useOpLogging)
        {
            DBQuery query = new DBQuery("opLogging", useOpLogging ? 1 : 0);
            IDBObject response = db.ExecuteCommand(query);
            response.ThrowIfResponseNotOK("opLogging failed");
        }
    }
}
