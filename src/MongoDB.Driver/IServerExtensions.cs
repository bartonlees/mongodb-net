using System;

namespace MongoDB.Driver
{
    /// <summary>
    /// Extension methods for the IServer interface
    /// </summary>
    public static class IServerExtensions
    {
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="databaseUri">The database URI.</param>
        /// <returns></returns>
        public static IDatabase GetDatabase(this IServer server, string databaseUri)
        {
            return server.GetDatabase(new Uri(databaseUri, UriKind.RelativeOrAbsolute));
        }
    }
}
