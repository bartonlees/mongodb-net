using System;
using MongoDB.Driver.Platform.Conditions;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MongoDB.Driver
{
    /// <summary>
    /// A database binding that leverages a pair of databases
    /// </summary>
    internal class DBMultiBinding : IDBMultiBinding
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBMultiBinding"/> class.
        /// </summary>
        /// <param name="serverMultiBinding">The server multi binding.</param>
        /// <param name="subBindings">The sub bindings.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        public DBMultiBinding(IServerMultiBinding serverMultiBinding, IEnumerable<IDBBinding> subBindings, bool readOnly)
        {
            Condition.Requires(serverMultiBinding).IsNotNull();
            Condition.Requires(subBindings, "subBindings").IsNotNull();
            _SubBindings = subBindings.Distinct(new UriEqualityComparer<IDBBinding>()).ToList();
            Condition.Requires(_SubBindings, "SubBindings").IsLongerThan(1,"You must specify more than one unique database binding");
            ServerMultiBinding = serverMultiBinding;
            ReadOnly = readOnly;
        }

        /// <summary>
        /// Gets the bound Database
        /// </summary>
        /// <value>The server.</value>
        public IDatabase BoundDatabase { get; private set; }

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
            IDBCollection collection = BoundDatabase.Server.Admin.CmdCollection;
            IDBObject res = collection.FindOne(DBQuery.IsMaster);
            if (1 == res.GetAsInt("ismaster"))
                return; //Current binding is master
            string hostAndPort = res.GetAsString("remote"); //of the form : "192.168.58.1:30001"
            string[] parts = hostAndPort.Split(':');
            IPAddress masterAddress = IPAddress.Parse(parts[0]);

            _ActiveBinding = SubBindings.FirstOrDefault(b => b.Address == masterAddress);
            if (_ActiveBinding == null)
                _ActiveBinding = SubBindings.First();

        }

        /// <summary>
        /// Cycles the sub binding.
        /// If there is not currently an active binding, one is chosen randomly.
        /// If there is an active binding, the alternative binding is activated.
        /// </summary>
        public void CycleSubBinding()
        {
            List<IDBBinding> availableBindings = null;
            if (_ActiveBinding == null)
            {
                availableBindings = _SubBindings;
                
            }
            else //Toggle
            {
                availableBindings = _SubBindings.Where(b => b.Uri != _ActiveBinding.Uri).ToList();
            }
            _ActiveBinding = availableBindings[new Random().Next(availableBindings.Count)];
        }

        IDBBinding _ActiveBinding = null;
        /// <summary>
        /// Gets the active binding.
        /// </summary>
        /// <value>The active binding.</value>
        public IDBBinding ActiveSubBinding
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
            get { return ActiveSubBinding.EndPoint; }
        }

        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        public string HostName
        {
            get { return ActiveSubBinding.HostName; }
        }

        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>The port.</value>
        public int Port
        {
            get { return ActiveSubBinding.Port; }
        }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        /// <value>The name of the database.</value>
        public string DatabaseName
        {
            get { return ActiveSubBinding.DatabaseName; }
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public System.Net.IPAddress Address
        {
            get { return ActiveSubBinding.Address; }
        }

        /// <summary>
        /// Gets the sister binding.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IDBBinding GetSisterBinding(Uri name)
        {
            IDBMultiBinding sisterBinding = ServerMultiBinding.GetDBMultiBinding(name);
            sisterBinding.Bind(ServerMultiBinding.BoundServer.GetDatabase(sisterBinding));
            return sisterBinding;
        }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri
        {
            get { return ActiveSubBinding.Uri; }
        }

        
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


        public List<IDBBinding> _SubBindings;
        public IEnumerable<IDBBinding> SubBindings
        {
            get { return _SubBindings; }
        }

        public void Bind(IDatabase database)
        {
            BoundDatabase = database;
            foreach (IDBBinding subBinding in SubBindings)
            {
                subBinding.Bind(database);
            }
        }

        public IServerMultiBinding ServerMultiBinding
        {
            get;
            private set;
        }
    }
}
