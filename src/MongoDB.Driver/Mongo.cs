//COPYRIGHT
using System;
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
        /// Returns the default database host.
        /// </summary>
        /// <value>the db_ip setting from the .config, or "127.0.0.1" as a default</value>
        public static string DefaultHost
        {
            get
            {
                return Properties.Settings.Default.DefaultHost;
            }
        }

        /// <summary>
        /// Gets the default port that the database runs on.
        /// </summary>
        /// <value>the db_port setting from the .config, or 27017 as a default.</value>
        public static int DefaultPort
        {
            get
            {
                return Properties.Settings.Default.DefaultPort;
            }
        }


        /// <summary>
        /// A proxy for a "default" database with the host, port, and database defined in the app.config (usually mongo://localhost/test)
        /// </summary>
        /// <value>The default database.</value>
        /// <returns></returns>
        public static IDatabase DefaultDatabase
        {
            get
            {
                return GetDatabase(
                    Properties.Settings.Default.DefaultHost, 
                    Properties.Settings.Default.DefaultDatabaseName,
                    Properties.Settings.Default.DefaultPort);
            }
        }

        /// <summary>
        /// A proxy for an "alternate default" database with the host, port, and database defined in the app.config (usually mongo://localhost:27018/test)
        /// </summary>
        /// <value>The default database.</value>
        /// <returns></returns>
        public static IDatabase DefaultDatabase_Alt
        {
            get
            {
                return GetDatabase(
                    Properties.Settings.Default.DefaultAltHost,
                    Properties.Settings.Default.DefaultDatabaseName,
                    Properties.Settings.Default.DefaultAltPort);
            }
        }

        /// <summary>
        /// A read only proxy to the database indicated by <see cref="DefaultDatabase"/>
        /// </summary>
        /// <value>The read only default database.</value>
        /// <returns></returns>
        public static IDatabase DefaultDatabase_ReadOnly
        {
            get
            {
                return GetDatabase(
                    Properties.Settings.Default.DefaultHost,
                    Properties.Settings.Default.DefaultDatabaseName,
                    Properties.Settings.Default.DefaultPort, readOnly:true);
            }
        }

        /// <summary>
        /// A read only proxy to the database indicated by <see cref="DefaultDatabase_Alt"/>
        /// </summary>
        /// <value>The read only default database.</value>
        /// <returns></returns>
        public static IDatabase DefaultDatabase_Alt_ReadOnly
        {
            get
            {
                return GetDatabase(
                    Properties.Settings.Default.DefaultAltHost,
                    Properties.Settings.Default.DefaultDatabaseName,
                    Properties.Settings.Default.DefaultAltPort, readOnly:true);
            }
        }

        /// <summary>
        /// A proxy for a "default" server with the host, and port defined in the app.config (usually mongo://localhost)
        /// </summary>
        /// <value>The default server.</value>
        public static IServer DefaultServer
        {
            get
            {
                return GetServer(Properties.Settings.Default.DefaultHost,
                    Properties.Settings.Default.DefaultPort);
            }
        }

        /// <summary>
        /// A proxy for a "default pair mode" server with the hosts, and ports of the pair defined in the app.config
        /// </summary>
        /// <value>The default server.</value>
        public static IServer DefaultServer_PairMode
        {
            get
            {
                return GetServer(Properties.Settings.Default.DefaultHost,
                    Properties.Settings.Default.DefaultPort);
            }
        }

        /// <summary>
        /// A proxy for a "default cluster mode" server with the hosts, and ports of the pair defined in the app.config
        /// </summary>
        /// <value>The default server.</value>
        public static IServer DefaultServer_ClusterMode
        {
            get
            {
                return GetServer(Properties.Settings.Default.DefaultHost,
                    Properties.Settings.Default.DefaultPort);
            }
        }

        /// <summary>
        /// A proxy for an "alternate default" server with the host, and port defined in the app.config (usually mongo://localhost:27018)
        /// </summary>
        /// <value>The default server.</value>
        public static IServer DefaultServer_Alt
        {
            get
            {
                return GetServer(Properties.Settings.Default.DefaultAltHost,
                    Properties.Settings.Default.DefaultAltPort);
            }
        }

        /// <summary>
        /// A read only proxy to the server indicated by <see cref="DefaultServer"/>
        /// </summary>
        /// <value>The read only default server.</value>
        public static IServer DefaultServer_ReadOnly
        {
            get
            {
                return GetServer(Properties.Settings.Default.DefaultHost,
                    Properties.Settings.Default.DefaultPort, readOnly:true);
            }
        }

        /// <summary>
        /// A read only proxy to the server indicated by <see cref="DefaultServer_Alt"/>
        /// </summary>
        /// <value>The read only default server.</value>
        public static IServer DefaultServer_Alt_ReadOnly
        {
            get
            {
                return GetServer(Properties.Settings.Default.DefaultAltHost,
                    Properties.Settings.Default.DefaultAltPort, readOnly:true);
            }
        }

        /// <summary>
        /// Retrieves an <see cref="IDatabase"/> proxy object bound to the <see cref="System.Uri"/> parsed from the supplied string
        /// </summary>
        /// <remarks>
        /// This function will construct a new proxy object on every call.
        /// An <see cref="IServer"/> proxy will be implicitly created by this call. You can access that via <c>IDatabase.Server</c>.
        /// The <c>databaseUri</c> should be of the form: <c>mongo://host:port</c>
        /// </remarks>
        /// <param name="databaseUri">The database URI in string format</param>
        /// <param name="options">The connection options.</param>
        /// <param name="readOnly">if set to <c>true</c> this database (and server) will be readonly and throw <see cref="System.Data.ReadOnlyException"/> on any write/modify attempts.</param>
        /// <returns>The database proxy instance</returns>
        public static IDatabase GetDatabase(string databaseUri, DBConnectionOptions options = null, bool readOnly = false)
        {
            return GetDatabase(new Uri(databaseUri, UriKind.RelativeOrAbsolute), options, readOnly);
        }

        /// <summary>
        /// Retrieves an <see cref="IDatabase"/> proxy object bound to the supplied <see cref="System.Uri"/>
        /// </summary>
        /// <remarks>
        /// This function will construct a new proxy object on every call.
        /// An <see cref="IServer"/> proxy will be implicitly created by this call. You can access that via <c>IDatabase.Server</c>.
        /// The <c>databaseUri</c> should be of the form: <c>mongo://host:port</c>
        /// </remarks>
        /// <param name="databaseUri">The database URI</param>
        /// <param name="options">The connection options.</param>
        /// <param name="readOnly">if set to <c>true</c> this database (and server) will be readonly and throw <see cref="System.Data.ReadOnlyException"/> on any write/modify attempts.</param>
        /// <returns>The database proxy instance</returns>
        public static IDatabase GetDatabase(Uri databaseUri, DBConnectionOptions options = null, bool readOnly = false)
        {
            Condition.Requires(databaseUri, "databaseUri").IsNotNull().Evaluate(databaseUri.IsAbsoluteUri, "the database URI must be absolute and include server details");
            IServer server = GetServer(databaseUri, options, readOnly);
            IDBBinding dbBinding = server.Binding.GetDBBinding(databaseUri);
            return server.GetDatabase(dbBinding);
        }

        /// <summary>
        /// Retrieves an <see cref="IDatabase"/> proxy object bound to the specified host, port, and database name
        /// </summary>
        /// <param name="hostName">The host name.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="port">(optional) The port. If unspecified/null, will use the MongoDB default port</param>
        /// <param name="options">The options.</param>
        /// <param name="readOnly">if set to <c>true</c> the binding is read only.</param>
        /// <returns></returns>
        /// <example caption="">
        /// 	<code>
        /// IDatabase db = Mongo.GetDatabase("localhost", 1910, "test");
        /// //Result would be equivalent to: "mongo://localhost:1910/test"
        /// </code>
        /// </example>
        public static IDatabase GetDatabase(string hostName, string databaseName, int? port = null, DBConnectionOptions options = null, bool readOnly = false)
        {
            if (!port.HasValue)
                port = Mongo.DefaultPort;

            Condition.Requires(databaseName, "databaseName").IsNotNullOrWhitespace();
            Condition.Requires(hostName, "hostName").IsNotNullOrWhitespace();
            Condition.Requires(port.Value, "port").IsGreaterOrEqual(0);
            string databaseUriString = (port.Value == Mongo.DefaultPort ? string.Format("mongo://{0}/{1}", hostName.Trim(), databaseName) : string.Format("mongo://{0}:{1}/{2}", hostName.Trim(), port.Value, databaseName));
            return GetDatabase(databaseUriString, options, readOnly);
        }



        /// <summary>
        /// Retrieves an <see cref="IServer"/> proxy object bound to the supplied <see cref="System.Uri"/>
        /// </summary>
        /// <remarks>
        /// This function will construct a new proxy object on every call.
        /// The <c>serverUri</c> should be of the form: <c>mongo://host:port</c>
        /// </remarks>
        /// <param name="serverUri">The server URI</param>
        /// <param name="options">The connection options.</param>
        /// <param name="readOnly">if set to <c>true</c> this server will be readonly and throw <see cref="System.Data.ReadOnlyException"/> on any write/modify attempts.</param>
        /// <returns>The server proxy instance</returns>
        public static IServer GetServer(Uri serverUri, DBConnectionOptions options = null, bool readOnly = false)
        {
            return GetServer(new ServerBinding(serverUri, readOnly), options);
        }

        /// <summary>
        /// Retrieves an <see cref="IServer"/> proxy object bound to the <see cref="System.Uri"/> parsed from the supplied string
        /// </summary>
        /// This function will construct a new proxy object on every call.
        /// The <c>serverUri</c> should be of the form: <c>"mongo://host:port"</c>
        /// <returns>The server proxy instance</returns>
        /// <example>
        /// serverUriString examples:
        /// <code>
        /// IServer loopback = Mongo.GetServer("mongo://localhost");
        /// IServer ipv4loopback = Mongo.GetServer("mongo://127.0.0.1");
        /// IServer ipv6loopback = Mongo.GetServer("mongo://[::1]");
        /// IServer loopbackport = Mongo.GetServer("mongo://localhost:1910");
        /// IServer ipv4loopbackport = Mongo.GetServer("mongo://127.0.0.1:1910");
        /// IServer ipv6loopbackport = Mongo.GetServer("mongo://[::1]:1910");
        /// </code>
        /// </example>
        /// <param name="serverUriString">The server Uri as a string.</param>
        /// <param name="options">The options.</param>
        /// <param name="readOnly">if set to <c>true</c> this server will be readonly and throw <see cref="System.Data.ReadOnlyException" /> on any write/modify attempts.</param>
        public static IServer GetServer(string serverUriString, DBConnectionOptions options = null, bool readOnly = false)
        {
            return GetServer(new Uri(serverUriString, UriKind.Absolute), options, readOnly);
        }

        /// <summary>
        /// Retrieves an <see cref="IServer"/> proxy object bound to the specified host and port
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">(optional) The port. If unspecified/null, will use the MongoDB default port</param>
        /// <param name="options">The options.</param>
        /// <param name="readOnly">if set to <c>true</c> the binding is read only.</param>
        /// <returns></returns>
        /// <example caption="">
        /// <code>
        /// IServer server = Mongo.GetServer("localhost", 1910);
        /// //Result would be: "mongo://localhost:1910"
        /// </code>
        /// </example>
        public static IServer GetServer(string host, int port, DBConnectionOptions options = null, bool readOnly = false)
        {
            string uri = (port == Mongo.DefaultPort ? string.Format("mongo://{0}", host.Trim()) : string.Format("mongo://{0}:{1}", host.Trim(), port));
            return GetServer(uri, options, readOnly);
        }

        internal static IServer GetServer(IServerBinding serverBinding, DBConnectionOptions options = null)
        {
            Server s = new Server(serverBinding,options);
            return s;
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public static Version Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
    }
}