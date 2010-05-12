using MongoDB.Driver;

namespace MongoDB.Newtonsoft.Json
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ContractDocument<T> : ContractDBObject<T>, IDocument where T : new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        public ContractDocument()
            : this(new T(), DocumentState.Unchanged, new MongoDBSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="oid">The oid.</param>
        /// <param name="partial">if set to <c>true</c> [partial].</param>
        public ContractDocument(Oid oid, bool partial)
            : this(new T(), DocumentState.Unchanged, new MongoDBSerializer())
        {
            Partial = partial;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        public ContractDocument(T instance)
            : this(instance, DocumentState.Detached, new MongoDBSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        /// <param name="state">The state.</param>
        public ContractDocument(T instance, DocumentState state)
            : this(instance, state, new MongoDBSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDocument&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        /// <param name="state">The state.</param>
        /// <param name="serializer">The serializer to use.</param>
        public ContractDocument(T instance, DocumentState state, MongoDBSerializer serializer)
            : base(instance, serializer)
        {
            object id = this["_id"];
            State = state;
            Partial = false;
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public Oid ID
        {
            get { return this.GetAs<Oid>("_id", null); }
            set { this["_id"] = value; }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public DocumentState State
        {
            get;
            private set;
        }

        IDBCollection _Collection;
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        /// <value>The collection.</value>
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

        /// <summary>
        /// Gets a value indicating whether this <see cref="IDocument"/> is partial.
        /// </summary>
        /// <value><c>true</c> if partial; otherwise, <c>false</c>.</value>
        public bool Partial
        {
            get;
            private set;
        }
    }
}
