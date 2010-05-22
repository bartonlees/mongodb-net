
namespace MongoDB.Driver.Command.Admin
{
    /// <summary>
    /// Checks opLogging settings
    /// </summary>
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Toggles operation logging on or off
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="useOpLogging">if set to <c>true</c> [use op logging].</param>
        public static void opLogging(this IAdminOperations db, bool useOpLogging)
        {
            DBQuery query = new DBQuery("opLogging", useOpLogging ? 1 : 0);
            IDBObject response = db.ExecuteCommand(query);
            response.ThrowIfResponseNotOK("opLogging failed");
        }
    }
}
