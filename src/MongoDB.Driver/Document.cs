using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    public class Document : DBObject, IDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class.
        /// </summary>
        public Document(Oid id, bool partial)
        {
            ID = id;
            State = DocumentState.Added | DocumentState.Unchanged;
            Partial = partial;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Document"/> class. For testing only...by specifying the Oid, you are simulating the arrival of the document from a server
        /// </summary>
        /// <param name="id">The id.</param>
        public Document(Oid id) : this(id, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
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

        IDBCollection _Collection = null;
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

        public bool Partial
        {
            get;
            private set;
        }
    }
}
