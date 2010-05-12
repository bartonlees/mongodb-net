using System.IO;

namespace MongoDB.Driver.Message
{
    /// <summary>
    /// In general, each message consists of a standard message header followed by request-specific data.
    /// </summary>
    internal abstract class Header : IDBMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public const int HEADER_LENGTH = 16;

        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// </summary>
        /// <param name="opCode">The op code.</param>
        public Header(Operation opCode)
        {
            this.OpCode = opCode;
            this.MessageLength = HEADER_LENGTH; //The starting size of any message.
        }

        /// <summary>
        /// Gets or sets the length of the message.
        /// </summary>
        /// <value>total size of the message, including the 4 bytes of length .</value>
        public int MessageLength { get; protected set; }

        /// <summary>
        /// Gets or sets the request id.
        /// </summary>
        /// <value>client or database-generated identifier for this message.</value>
        public int RequestID { get; set; }

        /// <summary>
        /// Gets or sets the response to.
        /// </summary>
        /// <value>requestID from the original request (used in reponses from db).</value>
        public int ResponseTo { get; set; }

        /// <summary>
        /// Gets or sets the op code.
        /// </summary>
        /// <value>request type</value>
        public Operation OpCode { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("length:{0} requestId:{1} responseTo:{2} opCode:{3}",
                this.MessageLength, this.RequestID, this.ResponseTo, this.OpCode);
        }

        //public void Write(BufferedStream stream)
        //{
        //    using (EndianBinaryWriter writer = new EndianBinaryWriter(EndianBitConverter.Little, stream))
        //    {
        //        writer.Write(GetLength());
        //        writer.Write(_id);
        //        writer.Write(_responseTo);
        //        writer.Write((int)_operation);
        //    }
        //    if (_Body != null)
        //    {
        //        StreamUtil.Copy(_Body, stream);
        //    }
        //}

        //public void Read(BufferedStream stream)
        //{
        //    int bodyLen = 0;
        //    using (EndianBinaryReader reader = new EndianBinaryReader(EndianBitConverter.Little, stream))
        //    {
        //        bodyLen = reader.ReadInt32() - HEADER_LENGTH;
        //        if (bodyLen < 0)
        //            throw new InvalidDataException("Message should be at least 16 bytes");
        //        _id = reader.ReadInt32();
        //        _responseTo = reader.ReadInt32();
        //        _operation =  (Operation)reader.ReadInt32();
        //    }

        //    if (bodyLen > 0)
        //    {
        //        stream.SetLength(bodyLen+stream.Length); //Reallocate for the remainder of the body
        //        _Body = new MemoryStream(StreamUtil.ReadExactly(stream, bodyLen));
        //    }
        //    else
        //    {
        //        _Body = null;
        //    }
        //}
    }

    /// <summary>
    /// A request message sent to MongoDB.
    /// </summary>
    internal abstract class Request : Header, IDBRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public static int ID = 1;
        /// <summary>
        /// Gets a value indicating whether this <see cref="IDBRequest"/> is partial.
        /// </summary>
        /// <value><c>true</c> if partial; otherwise, <c>false</c>.</value>
        public bool Partial { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="opCode">The op code.</param>
        /// <param name="partial">if set to <c>true</c> [partial].</param>
        public Request(Operation opCode, bool partial = false)
            : base(opCode)
        {
            Partial = partial;
            this.RequestID = ID++;
            this.ResponseTo = 0;
        }

        /// <summary>
        /// Writes the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void Write(WireProtocolWriter writer)
        {
            //Write the header
            int start = writer.Position;
            writer.Write(MessageLength); //placeholder for size
            writer.Write(RequestID);
            writer.Write(ResponseTo);
            writer.Write((int)OpCode);
            //Write the payload
            WriteBody(writer);
            int finish = writer.Position;
            writer.Seek(start, SeekOrigin.Begin);
            MessageLength = finish - start;
            writer.Write(MessageLength);
            writer.Seek(finish, SeekOrigin.Begin);
        }

        /// <summary>
        /// Writes the body.
        /// </summary>
        /// <param name="writer">The writer.</param>
        protected abstract void WriteBody(WireProtocolWriter writer);

        /// <summary>
        /// Writes the DB object.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="dbo">The dbo.</param>
        protected virtual void WriteDBObject(WireProtocolWriter writer, IDBObject dbo)
        {
            writer.Write(dbo);
        }
    }
}
