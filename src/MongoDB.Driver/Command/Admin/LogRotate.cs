
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Logs the rotate.
        /// </summary>
        /// <param name="db">The db.</param>
        public static void logRotate(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_logRotate);
            response.ThrowIfResponseNotOK("buildinfo failed");
        }
        static DBQuery _logRotate = new DBQuery("logRotate", 1);
    }
}
