
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Queries the trace level.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="traceLevel">The trace level.</param>
        public static void queryTraceLevel(this IAdminOperations db, int traceLevel)
        {
            DBQuery query = new DBQuery("queryTraceLevel", traceLevel);
            IDBObject response = db.ExecuteCommand(query);
            response.ThrowIfResponseNotOK("queryTraceLevel failed");
        }
    }
}
