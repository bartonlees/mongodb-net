using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using Newtonsoft.Json;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Newtonsoft.Json
{
    public class ContractDocument<T> : ContractDBObject<T>, IDocument where T:new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        public ContractDocument()
            : this(new T(), DocumentState.Unchanged, new MongoDBSerializer())
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        public ContractDocument(T instance, DocumentState state)
            : this(instance, state, new MongoDBSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        /// <param name="serializer">The serializer to use.</param>
        public ContractDocument(T instance, DocumentState state, MongoDBSerializer serializer)
            : base(instance, serializer)
        {
            object id = this["_id"];
            State = state;
        }

        public Oid ID
        {
            get { return this.GetAs<Oid>("_id", null); }
            set { this["_id"] = value; }
        }

        public DocumentState State
        {
            get;
            private set;
        }

        IDBCollection _Collection;
        public IDBCollection Collection
        {
            get { return _Collection; }
            set
            {
                _Collection = value;
                if (ContainsKey("_ns"))
                    this["_ns"] = value.FullName;
            }
        }

        public bool Partial
        {
            get;
            private set;
        }
    }
}
