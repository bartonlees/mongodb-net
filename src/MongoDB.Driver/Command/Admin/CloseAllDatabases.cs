
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Closes all databases associated with the specified admin instance
        /// </summary>
        /// <param name="db">The db.</param>
        public static void closeAllDatabases(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_closeAllDatabases);
            response.ThrowIfResponseNotOK("closeAllDatabases failed");
        }

        static DBQuery _closeAllDatabases = new DBQuery("closeAllDatabases", 1);
    }
}
