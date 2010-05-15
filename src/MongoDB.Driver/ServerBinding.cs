//COPYRIGHT

using System;
using System.Net;
using MongoDB.Driver.Platform.Conditions;
namespace MongoDB.Driver
{
    /// <summary>
    /// A Simple binding that represents a single mongodb server.
    /// </summary>
    /// <example>
    /// Initializing via <see cref="System.Uri">Uri</see>
    /// <code>
    /// ServerBinding basic = new ServerBinding("mongo://localhost");
    /// </code>
    /// </example>
    /// <example>
    /// <code>
    /// ServerBinding withport = new ServerBinding("localhost", 1910);
    /// //Equivalent to "mongo://localhost:1910"
    /// </code>
    /// </example>
    public class ServerBinding : IServerBinding
    {
        /// <summary>
        /// Gets the end point represented by this binding.
        /// </summary>
        /// <value>The end point.</value>
        public IPEndPoint EndPoint
        {
            get { return new IPEndPoint(Address, Port); }
        }

        /// <summary>
        /// Gets the name of the host this binding is bound to.
        /// </summary>
        /// <value>The name of the host.</value>
        public string HostName
        {
            get { return Uri.DnsSafeHost; }
        }

        /// <summary>
        /// Gets the bound server.
        /// </summary>
        /// <value>The bound server.</value>
        public IServer BoundServer { get; private set; }

        /// <summary>
        /// Gets the port this binding is bound to
        /// </summary>
        /// <value>The port.</value>
        public int Port
        {
            get { return Uri.IsDefaultPort ? DefaultPort : Uri.Port; }
        }

        /// <summary>
        /// Gets the underlying IP address of this binding.
        /// </summary>
        /// <value>The address.</value>
        public IPAddress Address
        {
            get { return _Addresses[0]; }
        }

        IPAddress[] _Addresses;

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether modifications to the server data is allowed.
        /// </summary>
        /// <value><c>true</c> if binding is read only; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get;
            private set;
        }

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
        /// Initializes a new instance of the <see cref="ServerBinding"/> class from a valid, absolute mongo URI string:
        /// </summary>
        /// <param name="address">The URL format.</param>
        /// <param name="readOnly">if set to <c>true</c> this binding will be readonly.</param>
        /// <example>
        /// <code>
        /// ServerBinding loopback = new ServerBinding("mongo://localhost");
        /// ServerBinding ipv4loopback = new ServerBinding("mongo://127.0.0.1");
        /// ServerBinding ipv6loopback = new ServerBinding("mongo://[::1]");
        /// ServerBinding loopbackport = new ServerBinding("mongo://localhost:1910");
        /// ServerBinding ipv4loopbackport = new ServerBinding("mongo://127.0.0.1:1910");
        /// ServerBinding ipv6loopbackport = new ServerBinding("mongo://[::1]:1910");
        /// </code>
        /// </example>
        public ServerBinding(string address, bool readOnly = false)
            : this(new Uri(address, UriKind.Absolute), readOnly)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerBinding"/> class.
        /// </summary>
        /// <param name="uri">The URI with a format of <code>"mongo://host:port"</code>.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        public ServerBinding(Uri uri, bool readOnly = false)
        {
            Condition.Requires(uri, "uri")
                .IsNotNull()
                .Evaluate(uri.Scheme == UriExtensions.UriSchemeMongo, "The mongo:// scheme is required.");
            Uri = uri;
            ReadOnly = readOnly;
            //homoginize v6/v4 loopbacks
            if (Uri.HostNameType == UriHostNameType.IPv6)
            {
                IPAddress address = IPAddress.Parse(Uri.Host);
                if (IPAddress.IsLoopback(address))
                {
                    _Addresses = new IPAddress[] { IPAddress.Loopback };
                }
            }
            else if (Uri.Host.Equals("localhost", StringComparison.CurrentCultureIgnoreCase))
            {
                _Addresses = new IPAddress[] { IPAddress.Loopback };
            }

            //If not explicitly set, fallback to DNS interpretation
            if (_Addresses == null)
            {
                _Addresses = Dns.GetHostAddresses(Uri.DnsSafeHost);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerBinding"/> class with the specified host and port
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="readOnly">if set to <c>true</c> the binding is read only.</param>
        /// <example caption="">
        /// <code>
        /// ServerBinding b = new ServerBinding("localhost", 1910);
        /// //Result would be: "mongo://localhost:1910/db"
        /// </code>
        /// </example>
        public ServerBinding(string host, int port, bool readOnly = false)
            : this(port == ServerBinding.DefaultPort ? string.Format("mongo://{0}", host.Trim())
                : string.Format("mongo://{0}:{1}", host.Trim(), port), readOnly)
        {
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return EndPoint.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object other)
        {
            ServerBinding a = other as ServerBinding;
            if (a != null)
            {
                return a.EndPoint.Equals(EndPoint);
            }
            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Uri.ToString();
        }

        
        /// <summary>
        /// Gets the DB binding.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IDBBinding GetDBBinding(Uri name)
        {
            return new DBBinding(this, name, ReadOnly);
        }

        public void Bind(IServer server)
        {
            Server = server;
        }
    }
}