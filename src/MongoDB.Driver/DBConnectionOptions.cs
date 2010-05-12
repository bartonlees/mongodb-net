//COPYRIGHT

using System;
using System.Net;
using System.Net.Sockets;
namespace MongoDB.Driver
{

    /// <summary>
    /// 
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
        /// Resets this instance.
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
        }

        /**
          connect timeout in milliseconds. 0 is default and infinite
        */
        public int SendTimeout;

        /**
           receive timeout in milliseconds. 0 is default and infinite
         */
        public int ReceiveTimeout;

        /**
           socket timeout.  0 is default and infinite
         */
        public int socketTimeout;

        /**
           this controls whether or not on a connect, the system retries automatically 
        */
        public bool AutoConnectRetry;

        /// <summary>
        /// Gets or sets the size of the connection pool.
        /// </summary>
        /// <value>The size of the connection pool.</value>
        public int ConnectionPoolSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the receive buffer.
        /// </summary>
        /// <value>The size of the receive buffer.</value>
        public int ReceiveBufferSize { get; set; }
        /// <summary>
        /// Gets or sets the size of the send buffer.
        /// </summary>
        /// <value>The size of the send buffer.</value>
        public int SendBufferSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [no delay].
        /// </summary>
        /// <value><c>true</c> if [no delay]; otherwise, <c>false</c>.</value>
        public bool NoDelay { get; set; }


        /// <summary>
        /// Gets or sets the retry time.
        /// </summary>
        /// <value>The retry time.</value>
        public long RetryTime { get; set; }

        /// <summary>
        /// Gets or sets the state of the linger.
        /// </summary>
        /// <value>The state of the linger.</value>
        public LingerOption LingerState { get; set; }

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