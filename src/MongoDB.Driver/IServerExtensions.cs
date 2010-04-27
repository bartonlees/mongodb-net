using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    public static class IServerExtensions
    {
        public static IDatabase GetDatabase(this IServer server, string databaseUri)
        {
            return server.GetDatabase(new Uri(databaseUri, UriKind.RelativeOrAbsolute));
        }
    }
}
