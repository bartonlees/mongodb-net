using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Get a nonce for a subsequent call to copydb using a secure source database.  http://www.mongodb.org/display/DOCS/Clone+Database
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="fromDatabase">From database.</param>
        /// <returns></returns>
        public static string copydbgetnonce(this IAdminOperations db, IDatabase fromDatabase)
        {
            IDBObject res = db.ExecuteCommand(new DBQuery ()
            {
                {"copydbgetnonce", 1},
                {"fromdb", fromDatabase.Name}
            }
            );
            res.ThrowIfResponseNotOK("unable to get nonce value for copydb");
            return res.GetAsString("nonce");
        }
    }
}
