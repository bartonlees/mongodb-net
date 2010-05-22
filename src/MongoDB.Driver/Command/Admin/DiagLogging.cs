
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Gets/Sets the diagnostic logging level
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
    /// The diagnostic logging level of the server
    /// </summary>
    public enum DiagnosticLoggingLevel
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Also flushes any pending data to the file.
        /// </summary>
        Off = 0,

        /// <summary>
        /// Write operations should be/are logged
        /// </summary>
        LogWriteOperations = 1,

        /// <summary>
        /// Read operations should be/are logged
        /// </summary>
        /// <remarks>
        /// if you log reads, it will record the findOnes above and if you replay them, that will have an effect!
        /// </remarks>
        LogReadOperations = 2,

        /// <summary>
        /// All operations should be/are logged
        /// </summary>
        LogAllOperations = 3
    }
}
