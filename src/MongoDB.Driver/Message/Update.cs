using System;
using System.IO;

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
        
        public string FullNameSpace { get; set; }

        public IDBObject Selector { get; set; }

        public IDBObject Document { get; set; }

        public UpdateOption Flags { get; set; }

        public Update(string fullNameSpace, IDBObject selector, IDBObject document, UpdateOption flags) : base(Operation.Update)
        {
            FullNameSpace = fullNameSpace;
            Selector = selector;
            Document = document;
            Flags = flags;
        }

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
    [Flags]
    public enum UpdateOption
    {
        None = 0x00,
        Upsert = 0x01,
        MultiUpdate = 0x02
    }
}
