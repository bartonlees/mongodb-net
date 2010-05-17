
namespace MongoDB.Driver.Message
{
    /// <summary>
    /// The OP_QUERY message is used to query the database for documents in a collection
    /// </summary>
    internal class Query : Request
    {
        //    MsgHeader header;                 // standard message header
        //    int32     ZERO;                   // 0 - reserved for future use
        //    cstring   fullCollectionName;     // "dbname.collectionname"
        //    int32     numberToSkip;           // number of documents to skip when returning results
        //    int32     numberToReturn;         // number of documents to return in the first OP_REPLY
        //    BSON      query ;                 // query object.  See below for details.
        //  [ BSON      returnFieldSelector; ]  // OPTIONAL : selector indicating the fields to return.  See below for details.

        /// <summary>
        /// Gets or sets the cursor options.
        /// </summary>
        /// <value>The query options.</value>
        public DBCursorOptions Options { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public Query(DBCursorOptions options)
            : base(Operation.Query, options.ReturnFields != null)
        {
            Options = options;

        }

        /// <summary>
        /// Writes the body.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected override void WriteBody(WireProtocolWriter writer)
        {
            writer.Write((int)Options.Flags);
            writer.WriteNullTerminated(Options.Collection.FullName);
            writer.Write(Options.NumberToSkip.HasValue ? Options.NumberToSkip.Value : 0);
            writer.Write(Options.NumberToReturn);
            writer.Write(Options.Selector);

            if (Options.ReturnFields != null)
                writer.Write(Options.ReturnFields);
        }
    }
}
