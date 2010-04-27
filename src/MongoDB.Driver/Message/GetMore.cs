using System;
using System.IO;
using System.Text;

namespace MongoDB.Driver.Message
{
    /// <summary>
    /// The OP_GETMORE message is used to query the database for documents in a collection.
    /// </summary>
    internal class GetMore : Request
    {
        //      struct {
        //          MsgHeader header;                 // standard message header
        //          int32     ZERO;                   // 0 - reserved for future use
        //          cstring   fullCollectionName;     // "dbname.collectionname"
        //          int32     numberToReturn;         // number of documents to return
        //          int64     cursorID;               // cursorID from the OP_REPLY
        //      }

        public IDBCursor Cursor { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMore"/> class and OP_GETMORE message.
        /// </summary>
        /// <param name="fullCollectionName">Full name of the collection.</param>
        /// <param name="cursorID">The cursor ID.</param>
        public GetMore(IDBCursor cursor)
            : base(Operation.GetMore)
        {
            Cursor = cursor;
        }

        protected override void WriteBody(WireProtocolWriter writer)
        {
            writer.Write(0);
            writer.WriteNullTerminated(Cursor.Options.Collection.FullName);
            writer.Write(Cursor.Options.NumberToReturn);
            writer.Write(Cursor.CursorID.Value);
        }
    }
}
