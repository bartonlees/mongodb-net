
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Rotates the log
        /// </summary>
        /// <param name="db">The db.</param>
        public static void logRotate(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_logRotate);
            response.ThrowIfResponseNotOK("logRotate failed");
        }
        static DBQuery _logRotate = new DBQuery("logRotate", 1);
    }
}
