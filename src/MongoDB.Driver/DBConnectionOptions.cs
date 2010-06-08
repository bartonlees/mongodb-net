//COPYRIGHT

using System;
using System.Net;
using System.Net.Sockets;
namespace MongoDB.Driver
{

    /// <summary>
    /// Options for setting up and maintaining logical database connections
    /// </summary>
    public class DBConnectionOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBConnectionOptions"/> class.
        /// </summary>
        public DBConnectionOptions()
        {
            Reset();
        }

        /// <summary>
        /// Resets all options to their default values
        /// </summary>
        public void Reset()
        {
            SendTimeout = 0;
            ReceiveTimeout = 0;
            AutoConnectRetry = false;
            ConnectionPoolSize = 5;
            RetryTime = 15000;
            ReceiveBufferSize = 8192;
            SendBufferSize = 8192;
            LingerState = new LingerOption(false, 0);
            ConnectionFactory = (ep, co) => new DBConnection(ep, co);
            NoDelay = true;
            FireAndForgetUpdate = false;
            LingerState = null;
        }

        /// <summary>
        /// Gets or sets the amount of time a<see cref="System.Net.Sockets.TcpClient"/>will wait for a send operation to complete successfully.
        /// </summary>
        /// <remarks>Value is in milliseconds. 0 is default and infinite.</remarks>
        /// <value>The send timeout.</value>
        public int SendTimeout { get; set; }

        /// <summary>
        /// Gets or sets the amount of time a<see cref="System.Net.Sockets.TcpClient"/>will wait to receive data once a read operation is initiated.
        /// </summary>
        /// <remarks>The send time-out value, in milliseconds. The default is 0.</remarks>
        /// <value>The receive timeout.</value>
        public int ReceiveTimeout { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically retry on a failed connection attempt.
        /// </summary>
        /// <value><c>true</c> automatically retry otherwise, <c>false</c>.</value>
        public bool AutoConnectRetry { get; set; }

        /// <summary>
        /// Gets or sets the size of the connection pool.
        /// </summary>
        /// <value>The size of the connection pool.</value>
        public int ConnectionPoolSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the receive buffer.
        /// </summary>
        /// <value>The size of the receive buffer, in bytes. The default value is 8192 bytes.</value>
        public int ReceiveBufferSize { get; set; }
        /// <summary>
        /// Gets or sets the size of the receive buffer.
        /// </summary>
        /// <value>The size of the send buffer, in bytes. The default value is 8192 bytes.</value>
        public int SendBufferSize { get; set; }

        /// <summary>
        /// Gets or sets a value that disables a delay when send or receive buffers are not full.
        /// </summary>
        /// <value><c>true</c> if the delay is disabled, otherwise, <c>false</c>. The default value is <c>false</c>.</value>
        public bool NoDelay { get; set; }

        /// <summary>
        /// Gets or sets the retry time.
        /// </summary>
        /// <value>The retry time.</value>
        public long RetryTime { get; set; }

        /// <summary>
        /// Gets or sets information about the linger state of the associated socket.
        /// </summary>
        /// <value>The state of the linger.</value>
        public LingerOption LingerState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not to check for an error after every modifying call to the database.
        /// </summary>
        /// <value>Set this to <c>true</c> if you want to intentionally "fire and forget"; otherwise, <c>false</c>.</value>
        public bool FireAndForgetUpdate { get; set; }

        /// <summary>
        /// Gets or sets the connection factory.
        /// </summary>
        /// <value>The connection factory.</value>
        public Func<IPEndPoint, DBConnectionOptions, IDBConnection> ConnectionFactory
        {
            get;
            set;
        }
    }
}