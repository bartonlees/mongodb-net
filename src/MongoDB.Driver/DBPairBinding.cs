using System;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// A database binding that leverages a pair of databases
    /// </summary>
    public class DBPairBinding : IInternalDBBinding
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBPairBinding"/> class.
        /// </summary>
        /// <param name="leftBinding">The left binding.</param>
        /// <param name="rightBinding">The right binding.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        public DBPairBinding(IDBBinding leftBinding, IDBBinding rightBinding, bool readOnly = false)
        {
            Condition.Requires(leftBinding, "leftBinding").IsNotNull();
            Condition.Requires(rightBinding, "rightBinding").IsNotNull().Evaluate(rightBinding.DatabaseName.Equals(leftBinding.DatabaseName), "In order to be paired, both DBBindings must include the same DatabaseName.");
            LeftBinding = leftBinding;
            RightBinding = rightBinding;
            ReadOnly = readOnly;
        }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        public IServer Server { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether modifications to the server data is allowed.
        /// </summary>
        /// <value><c>true</c> if binding is read only; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get;
            private set;
        }

        void PickInitialSubBinding()
        {
            if (_ActiveBinding != null)
                return;

            CycleSubBinding();// randomly choose a server to for ismaster query
            IDBCollection collection = Server.Admin.CmdCollection;
            IDBObject res = collection.FindOne(DBQuery.IsMaster);
            if (1 == res.GetAsInt("ismaster"))
                return; //Current binding is master

            IDBBinding other = LeftBinding.Address.Equals(_ActiveBinding.Address) ? RightBinding : LeftBinding;
            string remote = res.GetAsString("remote");
            if (!other.HostName.Equals(remote, StringComparison.CurrentCultureIgnoreCase))
                throw new MongoException("Neither Binding in DBPairBinding is the Master.");
        }

        /// <summary>
        /// Cycles the sub binding.
        /// If there is not currently an active binding, one is chosen randomly.
        /// If there is an active binding, the alternative binding is activated.
        /// </summary>
        public void CycleSubBinding()
        {
            if (_ActiveBinding == null)
            {
                _ActiveBinding = new Random().Next(100) > 50 ? RightBinding : LeftBinding;
            }
            else //Toggle
            {
                _ActiveBinding = LeftBinding.Address.Equals(_ActiveBinding.Address) ? RightBinding : LeftBinding;
            }
        }

        IDBBinding _ActiveBinding = null;
        /// <summary>
        /// Gets the active binding.
        /// </summary>
        /// <value>The active binding.</value>
        public IDBBinding ActiveBinding
        {
            get
            {
                if (_ActiveBinding == null)
                    PickInitialSubBinding();
                return _ActiveBinding;
            }
        }
        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public System.Net.IPEndPoint EndPoint
        {
            get { return ActiveBinding.EndPoint; }
        }

        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        public string HostName
        {
            get { return ActiveBinding.HostName; }
        }

        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>The port.</value>
        public int Port
        {
            get { return ActiveBinding.Port; }
        }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        /// <value>The name of the database.</value>
        public string DatabaseName
        {
            get { return ActiveBinding.DatabaseName; }
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public System.Net.IPAddress Address
        {
            get { return ActiveBinding.Address; }
        }

        /// <summary>
        /// Gets the sister binding.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IDBBinding GetSisterBinding(Uri name)
        {
            DBPairBinding sisterBinding = new DBPairBinding(new DBBinding(LeftBinding.Server.Binding, name), new DBBinding(RightBinding.Server.Binding, name));
            (sisterBinding as IInternalDBBinding).Initialize(Server);
            return sisterBinding;
        }

        void IInternalDBBinding.Initialize(IServer server)
        {
            Server = server;
        }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri
        {
            get { return ActiveBinding.Uri; }
        }

        /// <summary>
        /// Gets or sets the left binding.
        /// </summary>
        /// <value>The left binding.</value>
        public IDBBinding LeftBinding { get; private set; }
        /// <summary>
        /// Gets or sets the right binding.
        /// </summary>
        /// <value>The right binding.</value>
        public IDBBinding RightBinding { get; private set; }


        /// <summary>
        /// Says the specified CMD collection.
        /// </summary>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <param name="request">The request.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        public void Say(IDBCollection cmdCollection, IDBRequest request, bool checkError = false)
        {
            //using (TransactionScope transactionScope = new TransactionScope())
            //{
            //    using (IDBConnectionSession connection = RequireConnectionSession(Transaction.Current.TransactionInformation.LocalIdentifier))
            //    {
            //        try
            //        {
            //            connection.Say(request);
            //            if (checkError)
            //            {
            //                LastError r = Server.GetDatabase("admin").GetLastError();
            //                switch (r.Code)
            //                {
            //                    case DBError.Code.NoError:
            //                        break;
            //                    case DBError.Code.DuplicateKeyError:
            //                    case DBError.Code.DuplicateKeyOnUpdate:
            //                        throw new MongoException.DuplicateKey(r.ErrorMessage);
            //                    default:
            //                        throw new MongoException(r.ErrorMessage);
            //                }
            //            }
            //        }
            //        catch (IOException ioe)
            //        {
            //            //TODO:move sub binding to pair binding, etc.
            //            //Binding.CycleSubBinding();
            //            if (concern == WriteConcern.None)
            //                return;
            //            throw new MongoException.Network("can't say something", ioe);
            //        }
            //    }
            //    transactionScope.Complete();
            //}
        }

        /// <summary>
        /// Calls the specified CMD collection.
        /// </summary>
        /// <typeparam name="TDoc">The type of the doc.</typeparam>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public IDBResponse<TDoc> Call<TDoc>(IDBCollection cmdCollection, IDBRequest request) where TDoc : class, IDocument
        {
            return _Call<TDoc>(cmdCollection, request, 2);
        }

        IDBResponse<TDoc> _Call<TDoc>(IDBCollection cmdCollection, IDBRequest request, int retries) where TDoc : class, IDocument
        {
            IDBResponse<TDoc> response = null;
            //using (TransactionScope transactionScope = new TransactionScope())
            //{
            //    try
            //    {
            //        using (IDBConnectionSession connection = RequireConnectionSession(Transaction.Current.TransactionInformation.LocalIdentifier))
            //        {
            //            response = connection.Call<TDoc>(request);
            //        }

            //        string err = response.GetError();

            //        if (err != null)
            //        {
            //            //if (err.Equals("not master"))
            //            //{
            //            //    if (retries > 0)
            //            //    {
            //            //        //Binding.CycleSubBinding();
            //            //        return _Call<TDoc>(request, retries - 1);
            //            //    }
            //            //    throw new MongoException("not talking to master and retries used up");
            //            //}
            //        }
            return response;
            //}
            //catch (IOException ioe)
            //{

            //    if (retries > 0)
            //    {
            //        //Binding.CycleSubBinding();
            //        return _Call<TDoc>(request, retries - 1);
            //    }
            //    throw new MongoException.Network("can't call something", ioe);
            //}
            // }
        }


        /// <summary>
        /// Tries the say.
        /// </summary>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="checkError">if set to <c>true</c> [check error].</param>
        /// <returns></returns>
        public bool TrySay(IDBCollection cmdCollection, IDBRequest msg, bool checkError = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the last exception.
        /// </summary>
        /// <value>The last exception.</value>
        public Exception LastException
        {
            get { throw new NotImplementedException(); }
        }


        /// <summary>
        /// Gets the connection options.
        /// </summary>
        /// <value>The connection options.</value>
        public DBConnectionOptions ConnectionOptions
        {
            get { throw new NotImplementedException(); }
        }


        /// <summary>
        /// Gets the username we are logged in with (if any).
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// sets connection credentials for using with the database.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The password.</param>
        public void SetCredentials(string username, System.Security.SecureString passwd)
        {
            throw new NotImplementedException();
        }
    }
}
