using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// closesAllDatabases
        /// </summary>
        /// <returns>the list</returns>
        public static void closeAllDatabases(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_closeAllDatabases);
            response.ThrowIfResponseNotOK("closeAllDatabases failed");
        }

        static DBQuery _closeAllDatabases = new DBQuery("closeAllDatabases", 1);
    }
}
