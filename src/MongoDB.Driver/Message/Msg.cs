using System;
using System.IO;
using System.Text;

namespace MongoDB.Driver.Message
{
    internal class Msg : Request
    {
        //      struct {
        //          MsgHeader header;    // standard message header
        //          cstring   message;   // message for the database
        //      }
        public string Message { get; set; }

        public Msg()
            : base(Operation.Msg)
        {
        }

        protected override void WriteBody(WireProtocolWriter writer)
        {
            writer.WriteNullTerminated(this.Message);
        }
    }
}
