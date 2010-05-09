
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Shutdowns the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        public static void shutdown(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_shutdown);
            response.ThrowIfResponseNotOK("shutdown failed");
        }
        static DBQuery _shutdown = new DBQuery("shutdown", 1);
    }
}
