
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Copy an entire database from one name on one server to another name on another server.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="fromDatabase">From database.</param>
        /// <param name="toDatabase">To database.</param>
        public static void copydb(this IAdminOperations db, IDatabase fromDatabase, IDatabase toDatabase)
        {
            DBQuery query = new DBQuery() 
            {
                {"copydb", 1},
                {"fromdb", fromDatabase.Name},
                {"todb", toDatabase.Name },
            };

            if (!fromDatabase.Server.Equals(db.Server))
                query.Add("fromhost", fromDatabase.Server.Uri.Authority);

            IDBObject response = db.ExecuteCommand(query);
            response.ThrowIfResponseNotOK("copydb failed");
        }
    }
}
