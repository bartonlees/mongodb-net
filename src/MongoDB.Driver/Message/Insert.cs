using System.Collections.Generic;

namespace MongoDB.Driver.Message
{
    /// <summary>
    /// The OP_INSERT message is used to insert one or more documents into a collection
    /// </summary>
    internal class Insert : Request
    {
        //      MsgHeader header;             // standard message header
        //      int32     ZERO;               // 0 - reserved for future use
        //      cstring   fullCollectionName; // "dbname.collectionname"
        //      BSON[]    documents;          // one or more documents to insert into the collection

        /// <summary>
        /// Gets or sets the full name of the collection.
        /// </summary>
        /// <value>
        /// The full name of the collection in the form "dbname.collectionname"
        /// </value>
        public string FullCollectionName { get; private set; }

        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>one or more documents to insert into the collection</value>
        public IEnumerable<IDocument> Documents { get { return _documents; } }
        List<IDocument> _documents = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Insert"/> class and OP_INSERT message
        /// </summary>
        /// <param name="fullCollectionName">Full name of the collection.</param>
        /// <param name="documentsToInsert">The documents to insert.</param>
        public Insert(string fullCollectionName, IEnumerable<IDocument> documentsToInsert)
            : base(Operation.Insert)
        {
            FullCollectionName = fullCollectionName;
            _documents = new List<IDocument>(documentsToInsert);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Insert"/> class and OP_INSERT message
        /// </summary>
        /// <param name="fullCollectionName">Full name of the collection.</param>
        /// <param name="documentsToInsert">The documents to insert.</param>
        public Insert(string fullCollectionName, params IDocument[] documentsToInsert)
            : this(fullCollectionName, documentsToInsert as IEnumerable<IDocument>)
        {
        }

        /// <summary>
        /// Writes the body.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected override void WriteBody(WireProtocolWriter writer)
        {
            writer.Write(0);
            writer.WriteNullTerminated(FullCollectionName);
            foreach (IDBObject document in _documents)
            {
                WriteDBObject(writer, document);
            }
        }
    }

    //TODO:RAW INSERT
    ///// <summary>
    ///// An <see cref="Insert"/> object (OP_INSERT message) that sends <see cref="DBObjectRaw"/> documents
    ///// </summary>
    //internal class InsertRaw : Insert
    //{
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="Insert"/> class.
    //    /// </summary>
    //    /// <param name="fullCollectionName">Full name of the collection.</param>
    //    /// <param name="documentsToInsert">The documents to insert.</param>
    //    public InsertRaw(string fullCollectionName, IEnumerable<DBObjectRaw> documentsToInsert)
    //        : base(fullCollectionName, documentsToInsert)
    //    {
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="Insert"/> class.
    //    /// </summary>
    //    /// <param name="fullCollectionName">Full name of the collection.</param>
    //    /// <param name="documentsToInsert">The documents to insert.</param>
    //    public InsertRaw(string fullCollectionName, params DBObjectRaw[] documentsToInsert)
    //        : base(fullCollectionName, documentsToInsert)
    //    {
    //    }

    //    protected override void WriteDBObject(WireProtocolWriter writer, IDBObject document)
    //    {
    //        DBObjectRaw raw = document as DBObjectRaw;
    //        if (raw != null)
    //        {
    //            //TODO:Raw copy to stream
    //        }
    //        else
    //        {
    //            base.WriteDBObject(writer, document);
    //        }
    //    }
    //}
}
