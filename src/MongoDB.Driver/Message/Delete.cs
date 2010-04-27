using System;
using System.IO;

namespace MongoDB.Driver.Message
{
    /// <summary>
    /// The OP_DELETE message is used to remove one or more messages from a collection
    /// </summary>
    internal class Delete : Request
    {
        //struct {
        //    MsgHeader header;                 // standard message header
        //    int32     ZERO;                   // 0 - reserved for future use
        //    cstring   fullCollectionName;     // "dbname.collectionname"
        //    int32     ZERO;                   // 0 - reserved for future use
        //    BSON      selector;               // query object.  See below for details.
        //}

        /// <summary>
        /// Gets or sets the full name of the collection.
        /// </summary>
        /// <value>The full name of the collection.</value>
        public string FullNameSpace { get; set; }


        /// <summary>
        /// Gets or sets the selector document.
        /// </summary>
        /// <value>The selector document.</value>
        public IDBObject DeleteQuery { get; set; }
        
        public Delete(IDBObject objectToDelete, string fullNameSpace) : base(Operation.Delete)
        {
            FullNameSpace = fullNameSpace;
            DeleteQuery = objectToDelete;
        }
        
        protected override void WriteBody(WireProtocolWriter writer)
        {
            writer.Write(0);
            writer.WriteNullTerminated(FullNameSpace);
            writer.Write(DeleteQuery.HasOid() ? 1 : 0);
            WriteDBObject(writer, DeleteQuery);
        }
    }
}
