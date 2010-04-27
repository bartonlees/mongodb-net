using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver.Platform.Conditions;
using System.IO;
using System.Transactions;
using MongoDB.Driver.Command;

namespace MongoDB.Driver
{
    /// <summary>
    /// A database binding that leverages a pair of databases
    /// </summary>
    public class DBPairBinding : IInternalDBBinding
    {
        public DBPairBinding(IDBBinding leftBinding, IDBBinding rightBinding, bool readOnly = false)
        {
            Condition.Requires(leftBinding, "leftBinding").IsNotNull();
            Condition.Requires(rightBinding, "rightBinding").IsNotNull().Evaluate(rightBinding.DatabaseName.Equals(leftBinding.DatabaseName), "In order to be paired, both DBBindings must include the same DatabaseName.");
            LeftBinding = leftBinding;
            RightBinding = rightBinding;
            ReadOnly = readOnly;
        }

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
            IDBCollection collection = Server.GetDatabase("admin").GetCollection("$cmd");
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
        public IDBBinding ActiveBinding
        {
            get
            {
                if (_ActiveBinding == null)
                    PickInitialSubBinding();
                return _ActiveBinding;
            }
        }
        public System.Net.IPEndPoint EndPoint
        {
            get { return ActiveBinding.EndPoint; }
        }

        public string HostName
        {
            get { return ActiveBinding.HostName; }
        }

        public int Port
        {
            get { return ActiveBinding.Port; }
        }

        public string DatabaseName
        {
            get { return ActiveBinding.DatabaseName; }
        }

        public System.Net.IPAddress Address
        {
            get { return ActiveBinding.Address; }
        }

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

        public Uri Uri
        {
            get { return ActiveBinding.Uri; }
        }

        public IDBBinding LeftBinding { get; private set; }
        public IDBBinding RightBinding { get; private set; }


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


        public bool TrySay(IDBCollection cmdCollection, IDBRequest msg, bool checkError = false)
        {
            throw new NotImplementedException();
        }

        public Exception LastException
        {
            get { throw new NotImplementedException(); }
        }


        public DBConnectionOptions ConnectionOptions
        {
            get { throw new NotImplementedException(); }
        }


        public string Username
        {
            get { throw new NotImplementedException(); }
        }

        public void SetCredentials(string username, System.Security.SecureString passwd)
        {
            throw new NotImplementedException();
        }
    }
}
