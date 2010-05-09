using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    /// <summary>
    /// Extension methods for the IServer interface
    /// </summary>
    public static class IServerExtensions
    {
        public static IDatabase GetDatabase(this IServer server, string databaseUri)
        {
            return server.GetDatabase(new Uri(databaseUri, UriKind.RelativeOrAbsolute));
        }
    }
}
