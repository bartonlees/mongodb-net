//COPYRIGHT

using System.Net;
using System.Runtime.CompilerServices;
using MongoDB.Driver.Platform.Util;
using System.Threading;
using System;
using System.Collections.Generic;
using MongoDB.Driver.Platform.IO;
using System.IO;
using System.Net.Sockets;
using MongoDB.Driver.Platform.Conversion;
using System.Linq;
using MongoDB.Driver.Platform.Conditions;
using System.Security;
using MongoDB.Driver.Command;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace MongoDB.Driver
{

    /// <summary>
    /// A database port that you can connect to
    /// </summary>
    internal class DBConnection : IDBConnection
    {
        public static TraceSource _ts = new TraceSource("DBConnection", SourceLevels.All);
        bool _Disposed = false;

        private NetworkStream _NetworkStream = null;
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


        public DBConnection(IPEndPoint addr, DBConnectionOptions options)
        {
            Condition.Requires(addr, "addr").IsNotNull();
            Condition.Requires(options, "options").IsNotNull();
            Options = options;
            EndPoint = addr;
        }

        public IDBResponse<TDoc> Call<TDoc>(IDBRequest msg) where TDoc : class, IDocument
        {
            return _SendRequest<TDoc>(msg, true); ;
        }

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

        public override int GetHashCode()
        {
            if (_Disposed)
            {
                throw new ObjectDisposedException("DBConnection");
            }
            return EndPoint.GetHashCode();
        }

        public override string ToString()
        {
            if (_Disposed)
            {
                throw new ObjectDisposedException("DBConnection");
            }
            return EndPoint.ToString();
        }

        public IPEndPoint EndPoint { get; private set; }
        public DBConnectionOptions Options { get; private set; }
        TcpClient _Client;

        public bool CanRequest
        {
            get { return NetworkStream.CanWrite; }
        }

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