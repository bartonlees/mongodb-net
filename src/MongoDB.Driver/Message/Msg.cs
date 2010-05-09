
namespace MongoDB.Driver.Message
{
    internal class Msg : Request
    {
        //      struct {
        //          MsgHeader header;    // standard message header
        //          cstring   message;   // message for the database
        //      }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Msg"/> class.
        /// </summary>
        public Msg()
            : base(Operation.Msg)
        {
        }

        /// <summary>
        /// Writes the body.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected override void WriteBody(WireProtocolWriter writer)
        {
            writer.WriteNullTerminated(this.Message);
        }
    }
}
