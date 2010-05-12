//COPYRIGHT

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using MongoDB.Driver.Command;
using MongoDB.Driver.Platform.Conditions;
using MongoDB.Driver.Platform.IO;
using MongoDB.Driver.Platform.Util;
namespace MongoDB.Driver
{

    /// <summary>
    /// A database port that you can connect to
    /// </summary>
    internal class DBConnection : IDBConnection
    {
        /// <summary>
        /// 
        /// </summary>
        public static TraceSource _ts = new TraceSource("DBConnection", SourceLevels.All);
        bool _Disposed = false;

        private NetworkStream _NetworkStream = null;
        /// <summary>
        /// Gets the network stream.
        /// </summary>
        /// <value>The network stream.</value>
        protected NetworkStream NetworkStream
        {
            get
            {
                if (_Disposed)
                {
                    throw new ObjectDisposedException("DBConnection");
                }
                if (_NetworkStream == null)
                {
                    if (_Client == null || !_Client.Connected)
                        ConnectClient();

                    _NetworkStream = _Client.GetStream();
                }
                return _NetworkStream;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DBConnection"/> class.
        /// </summary>
        /// <param name="addr">The addr.</param>
        /// <param name="options">The options.</param>
        public DBConnection(IPEndPoint addr, DBConnectionOptions options)
        {
            Condition.Requires(addr, "addr").IsNotNull();
            Condition.Requires(options, "options").IsNotNull();
            Options = options;
            EndPoint = addr;
        }

        /// <summary>
        /// Calls the specified MSG.
        /// </summary>
        /// <typeparam name="TDoc">The type of the doc.</typeparam>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        public IDBResponse<TDoc> Call<TDoc>(IDBRequest msg) where TDoc : class, IDocument
        {
            return _SendRequest<TDoc>(msg, true); ;
        }

        /// <summary>
        /// Says the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void Say(IDBRequest msg)
        {
            _SendRequest<Document>(msg, false);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private IDBResponse<TDoc> _SendRequest<TDoc>(IDBRequest msg, bool expectResponse) where TDoc : class, IDocument
        {
            if (_Disposed)
            {
                throw new ObjectDisposedException("DBConnection");
            }

            _ts.TraceEvent(TraceEventType.Verbose, msg.GetHashCode(), "Sending: {0}", msg);
            using (NonClosingStreamWrapper networkStream = new NonClosingStreamWrapper(NetworkStream))
            {
                using (MemoryStream buffer = new MemoryStream(msg.MessageLength))
                using (WireProtocolWriter writer = new WireProtocolWriter(buffer))
                {
                    msg.Write(writer);
                    networkStream.Write(buffer.GetBuffer(), 0, Convert.ToInt32(buffer.Length));
                }
                networkStream.Flush();
                if (!expectResponse)
                {
                    return null;
                }
                using (WireProtocolReader reader = new WireProtocolReader(networkStream))
                {
                    IDBResponse<TDoc> response = new Message.Reply<TDoc>(msg.Partial);
                    response.Read(reader);
                    _ts.TraceEvent(TraceEventType.Verbose, msg.GetHashCode(), "Received: {0}", response);
                    return response;
                }
            }
        }

        void ConnectClient()
        {
            long sleepTime = 100;
            long start = DateTime.Now.Ticks;
            while (true)
            {
                IOException lastError = null;
                try
                {
                    _Client = new TcpClient();
                    _ts.TraceEvent(TraceEventType.Verbose, _Client.GetHashCode(), "Connecting: {0}", EndPoint);
                    _Client.SendTimeout = Options.SendTimeout;
                    _Client.ReceiveTimeout = Options.ReceiveTimeout;
                    _Client.NoDelay = Options.NoDelay;
                    _Client.LingerState = Options.LingerState;
                    _Client.ReceiveBufferSize = Options.ReceiveBufferSize;
                    _Client.SendBufferSize = Options.SendBufferSize;
                    _Client.Connect(EndPoint);
                    return;
                }
                catch (IOException ioe)
                {
                    _ts.TraceInformation("Connecting-Exception: {0}", ioe);
                    lastError = new IOException("couldn't connect to [" + EndPoint + "] bc:" + ioe);
                }

                if (!Options.AutoConnectRetry)
                    throw lastError;

                long sleptSoFar = DateTime.Now.Ticks - start;

                if (sleptSoFar >= Options.RetryTime)
                    throw lastError;

                if (sleepTime + sleptSoFar > Options.RetryTime)
                    sleepTime = Options.RetryTime - sleptSoFar;

                Thread.Sleep(TimeSpan.FromMilliseconds(sleepTime));
                sleepTime *= 2;
                _ts.TraceInformation("Connecting-Retrying");
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            if (_Disposed)
            {
                throw new ObjectDisposedException("DBConnection");
            }
            return EndPoint.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (_Disposed)
            {
                throw new ObjectDisposedException("DBConnection");
            }
            return EndPoint.ToString();
        }

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public IPEndPoint EndPoint { get; private set; }
        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        public DBConnectionOptions Options { get; private set; }
        TcpClient _Client;

        /// <summary>
        /// Gets a value indicating whether this instance can request.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can request; otherwise, <c>false</c>.
        /// </value>
        public bool CanRequest
        {
            get { return NetworkStream.CanWrite; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!_Disposed)
            {
                _ts.TraceEvent(TraceEventType.Verbose, this.GetHashCode(), "Disposing");
                _Disposed = true;
                if (_Client != null)
                {
                    _Client.Close();
                }
                if (_NetworkStream != null)
                {
                    _NetworkStream.Dispose();
                }
            }
        }

        bool _authenticated = false;

        /// <summary>
        /// Tries the authenticate.
        /// </summary>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <param name="username">The username.</param>
        /// <param name="usrPassHash">The usr pass hash.</param>
        /// <returns></returns>
        public bool TryAuthenticate(IDBCollection cmdCollection, string username, SecureString usrPassHash)
        {
            //If this connection has already authenticated
            if (!_authenticated)
            {
                _ts.TraceEvent(TraceEventType.Verbose, this.GetHashCode(), "Authenticating: {0}", username);
                try
                {
                    string nonce = this.nonce(cmdCollection);
                    SecureString key = new SecureString();
                    key.Append(nonce);
                    key.Append(username);
                    key.Append(usrPassHash);
                    _authenticated = this.authenticate(cmdCollection, username, nonce, key);
                    _ts.TraceEvent(TraceEventType.Verbose, nonce.GetHashCode(), "Authenticated: {0}", _authenticated);
                }
                catch (Exception x)
                {
                    _ts.TraceEvent(TraceEventType.Verbose, x.GetHashCode(), "Authenticating-exception: {0}", x);
                    _authenticated = false;
                }
            }
            return _authenticated;
        }
    }
}