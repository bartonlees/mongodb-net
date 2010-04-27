//COPYRIGHT

using System.Net.Sockets;
using System;
using System.Net;
namespace MongoDB.Driver
{

    /**
     * Various settings for the driver
     */
    public class DBConnectionOptions
    {

        public DBConnectionOptions()
        {
            Reset();
        }

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

        public int ConnectionPoolSize { get; set; }

        public int ReceiveBufferSize { get; set; }
        public int SendBufferSize { get; set; }

        public bool NoDelay { get; set; }


        public long RetryTime { get; set;}

        public LingerOption LingerState { get; set; }

        public Func<IPEndPoint, DBConnectionOptions, IDBConnection> ConnectionFactory
        {
            get;
            set;
        }
    }
}