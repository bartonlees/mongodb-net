
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Diags the logging.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="logLevel">The log level.</param>
        public static void diagLogging(this IAdminOperations db, ref DiagnosticLoggingLevel logLevel)
        {
            DBQuery query = new DBQuery("diagLogging", (int)logLevel);
            IDBObject response = db.ExecuteCommand(query);
            response.ThrowIfResponseNotOK("diagLogging failed");
            logLevel = (DiagnosticLoggingLevel)response.GetAsInt("yada");
        }
    }
}

namespace MongoDB.Driver
{
    /// <summary>
    /// 
    /// </summary>
    public enum DiagnosticLoggingLevel
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Also flushes any pending data to the file.
        /// </summary>
        Off = 0,

        /// <summary>
        /// 
        /// </summary>
        LogWriteOperations = 1,

        /// <summary>
        /// if you log reads, it will record the findOnes above and if you replay them, that will have an effect!
        /// </summary>
        LogReadOperations = 2,

        /// <summary>
        /// 
        /// </summary>
        LogAllOperations = 3
    }
}
