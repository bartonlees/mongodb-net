using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MongoDB.Newtonsoft.Json
{
    public class ContractDocument<T> : ContractDBObject<T>, IDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        public ContractDocument(T instance, DocumentState state) : this(instance, state, new JsonSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        /// <param name="serializer">The serializer to use.</param>
        public ContractDocument(T instance, DocumentState state, JsonSerializer serializer)
            : base(instance, serializer)
        {
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
