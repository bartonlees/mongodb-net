//COPYRIGHT
using System;
using System.Collections.Generic;
using System.Reflection;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// A database connection with internal pooling.
    /// The following are equivalent, and all connect to the
    /// local database running on the default port:
    /// </summary>
    public static class Mongo
    {
        /// <summary>
        /// Connects to the default host, port, and database as defined in the app.config
        /// </summary>
        /// <returns></returns>
        public static IDatabase DefaultDatabase
        {
            get
            {
                IServerBinding serverBinding = DefaultServerBinding;
                DBBinding binding = new DBBinding(serverBinding,
                    new Uri(Properties.Settings.Default.DefaultDatabaseName, UriKind.Relative));
                return GetServer(serverBinding).GetDatabase(binding);
            }
        }

        /// <summary>
        /// Retrieves a readonly connection to the default host, port, and database as defined in the app.config
        /// </summary>
        /// <returns></returns>
        public static IDatabase ReadOnlyDefaultDatabase
        {
            get
            {
                IServerBinding serverBinding = ReadOnlyDefaultServerBinding;
                DBBinding binding = new DBBinding(serverBinding,
                    new Uri(Properties.Settings.Default.DefaultDatabaseName, UriKind.Relative), true);
                return GetServer(serverBinding).GetDatabase(binding);
            }
        }

        public static IServer DefaultServer
        {
            get
            {
                return GetServer(DefaultServerBinding);
            }
        }

        public static IServer ReadOnlyDefaultServer
        {
            get
            {
                return GetServer(ReadOnlyDefaultServerBinding);
            }
        }

        public static IServerBinding DefaultServerBinding
        {
            get
            {
                ServerBinding binding = new ServerBinding(
                Properties.Settings.Default.DefaultHost,
                Properties.Settings.Default.DefaultPort);
                return binding;
            }
        }

        public static IServerBinding ReadOnlyDefaultServerBinding
        {
            get
            {
                ServerBinding binding = new ServerBinding(
                Properties.Settings.Default.DefaultHost,
                Properties.Settings.Default.DefaultPort, true);
                return binding;
            }
        }

        public static IDatabase GetDatabase(string databaseBinding)
        {
            return GetDatabase(new Uri(databaseBinding, UriKind.RelativeOrAbsolute));
        }

        public static IDatabase GetDatabase(Uri databaseUri)
        {
            Condition.Requires(databaseUri, "databaseUri").IsNotNull().Evaluate(databaseUri.IsAbsoluteUri, "the database URI must be absolute and include server details");
            ServerBinding serverBinding = new ServerBinding(databaseUri);
            IServer server = GetServer(serverBinding);
            DBBinding dbBinding = new DBBinding(serverBinding, databaseUri);
            return server.GetDatabase(dbBinding);
        }

        public static IServer GetServer(Uri location)
        {
            return GetServer(new ServerBinding(location));
        }

        public static IServer GetServer(string location)
        {
            return GetServer(new ServerBinding(location));
        }

        //public static IServer this[Uri location]
        //{
        //    get
        //    {
        //        return GetServer(location);
        //    }
        //}

        //public static IServer this[string location]
        //{
        //    get
        //    {
        //        return GetServer(location);
        //    }
        //}

        public static IServer GetServer(IServerBinding serverBinding)
        {
            Server s = new Server(serverBinding);
            return s;
        }

        public static Version Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
    }
}