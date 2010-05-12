using System;

namespace MongoDB.Driver.Message
{


    internal class Update : Request
    {
        //struct {
        //    MsgHeader header;             // standard message header
        //    int32     ZERO;               // 0 - reserved for future use
        //    cstring   fullCollectionName; // "dbname.collectionname"
        //    int32     upsert;             // value 0 or 1 for an 'upsert' operation
        //    BSON      selector;           // the query to select the document
        //    BSON      document;           // the document data to update with or insert
        //}

        /// <summary>
        /// Gets or sets the full name space.
        /// </summary>
        /// <value>The full name space.</value>
        public string FullNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the selector.
        /// </summary>
        /// <value>The selector.</value>
        public IDBObject Selector { get; set; }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        public IDBObject Document { get; set; }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>The flags.</value>
        public UpdateOption Flags { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Update"/> class.
        /// </summary>
        /// <param name="fullNameSpace">The full name space.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="document">The document.</param>
        /// <param name="flags">The flags.</param>
        public Update(string fullNameSpace, IDBObject selector, IDBObject document, UpdateOption flags)
            : base(Operation.Update)
        {
            FullNameSpace = fullNameSpace;
            Selector = selector;
            Document = document;
            Flags = flags;
        }

        /// <summary>
        /// Writes the body.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected override void WriteBody(WireProtocolWriter writer)
        {
            writer.Write(0);
            writer.WriteNullTerminated(FullNameSpace);
            writer.Write((int)Flags);
            writer.Write(Selector);
            writer.Write(Document);
        }
    }
}

namespace MongoDB.Driver
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum UpdateOption
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0x00,
        /// <summary>
        /// 
        /// </summary>
        Upsert = 0x01,
        /// <summary>
        /// 
        /// </summary>
        MultiUpdate = 0x02
    }
}
