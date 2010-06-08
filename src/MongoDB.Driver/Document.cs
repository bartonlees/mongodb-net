using System.Collections.Generic;

namespace MongoDB.Driver
{
    /// <summary>
    /// The public, default implementation of <see cref="T:MongoDB.Driver.IDocument"/>be stored to and retrieved from a server
    /// </summary>
    public class Document : DBObject, IDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        /// <remarks>
        /// For testing/internal use only...by specifying the Oid and partial flag, you are simulating the arrival of the document from a server
        /// </remarks>
        /// <param name="id">an explicitly set ID.</param>
        /// <param name="partial">if set to <c>true</c> the document represents a subset of all available fields.</param>
        public Document(Oid id, bool partial)
        {
            ID = id;
            State = DocumentState.Added | DocumentState.Unchanged;
            Partial = partial;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class. 
        /// </summary>
        /// <remarks>
        /// For testing/internal use only...by specifying the Oid, you are simulating the arrival of the document from a server
        /// </remarks>
        /// <param name="id">The id.</param>
        public Document(Oid id)
            : this(id, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        /// <remarks>
        /// This is the recommended constructor for new documents. The <see cref="State"/> will be set to <c>DocumentState.Detached</c>.
        /// </remarks>
        public Document()
        {
            ID = Oid.NewOid();
            State = DocumentState.Detached;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObject"/> class from an existing DBObject.
        /// </summary>
        /// <param name="obj">The db object</param>
        public Document(IDictionary<string, object> obj)
            : base(obj)
        {
            ID = Oid.NewOid();
            State = DocumentState.Detached;
        }

        /// <summary>
        /// Convenience constructor.
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public Document(string key, object value)
        {
            this[key] = value;
            ID = Oid.NewOid();
            State = DocumentState.Detached;
        }

        /// <summary>
        /// Convenience constructor.
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        /// <param name="key1">The key1.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="key2">The key2.</param>
        /// <param name="value2">The value2.</param>
        public Document(string key1, object value1, string key2, object value2)
        {
            Add(key1, value1);
            Add(key2, value2);
            ID = Oid.NewOid();
            State = DocumentState.Detached;
        }

        /// <summary>
        /// Convenience constructor.
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        /// <param name="key1">The key1.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="key2">The key2.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="key3">The key3.</param>
        /// <param name="value3">The value3.</param>
        public Document(string key1, object value1, string key2, object value2, string key3, object value3)
        {
            Add(key1, value1);
            Add(key2, value2);
            Add(key3, value3);
            ID = Oid.NewOid();
            State = DocumentState.Detached;
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
        /// Gets the document's state.
        /// </summary>
        /// <value>The state.</value>
        public DocumentState State
        {
            get;
            private set;
        }

        IDBCollection _Collection = null;
        /// <summary>
        /// Gets or sets the collection this document is associated with
        /// </summary>
        /// <value>The collection.</value>
        public IDBCollection Collection
        {
            get
            {
                return _Collection;
            }
            set
            {
                _Collection = value;
                this["_ns"] = value.FullName;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Document"/> is partial.
        /// </summary>
        /// <value><c>true</c> if partial; otherwise, <c>false</c>.</value>
        public bool Partial
        {
            get;
            private set;
        }
    }
}
