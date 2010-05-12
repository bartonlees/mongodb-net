//COPYRIGHT

using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Message;
namespace MongoDB.Driver
{
    /// <summary>
    /// Creates a message to send to the database.
    /// </summary>
    public interface IDBMessage
    {
        //        struct {
        //    int32   messageLength;  // total size of the message, including the 4 bytes of length
        //    int32   requestID;      // client or database-generated identifier for this message
        //    int32   responseTo;     // requestID from the original request (used in reponses from db)
        //    int32   opCode;         // request type - see table below
        //}

        /// <summary>
        /// Gets the length of the message.
        /// </summary>
        /// <value>The length of the message.</value>
        int MessageLength { get; }
        /// <summary>
        /// Gets or sets the request ID.
        /// </summary>
        /// <value>The request ID.</value>
        int RequestID { get; set; }
        /// <summary>
        /// Gets the response to.
        /// </summary>
        /// <value>The response to.</value>
        int ResponseTo { get; }
        /// <summary>
        /// Gets the op code.
        /// </summary>
        /// <value>The op code.</value>
        Operation OpCode { get; }
    }

    /// <summary>
    /// An <see cref="IDBMessage"/> sent from client to server
    /// </summary>
    public interface IDBRequest : IDBMessage
    {
        /// <summary>
        /// Writes the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        void Write(WireProtocolWriter writer);
        /// <summary>
        /// Gets a value indicating whether this <see cref="IDBRequest"/> is partial.
        /// </summary>
        /// <value><c>true</c> if partial; otherwise, <c>false</c>.</value>
        bool Partial { get; }
    }

    /// <summary>
    /// An <see cref="IDBMessage"/> sent from server to client
    /// </summary>
    public interface IDBResponse : IDBMessage
    {
        /// <summary>
        /// Reads the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        void Read(WireProtocolReader reader);
        /// <summary>
        /// Gets the documents.
        /// </summary>
        /// <value>The documents.</value>
        IEnumerable<IDocument> Documents { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDoc">The type of the doc.</typeparam>
    public interface IDBResponse<TDoc> : IDBResponse where TDoc : class, IDocument
    {
        /// <summary>
        /// Gets the documents T.
        /// </summary>
        /// <value>The documents T.</value>
        IEnumerable<TDoc> DocumentsT { get; }
    }

    /// <summary>
    /// Type of message
    /// </summary>
    public enum Operation
    {
        /// <summary>
        /// Reply to a client request. will always be received and never sent
        /// </summary>
        Reply = 1,
        /// <summary>
        /// generic msg command followed by a string
        /// </summary>
        Msg = 1000,
        /// <summary>
        /// update document
        /// </summary>
        Update = 2001,
        /// <summary>
        /// insert new document
        /// </summary>
        Insert = 2002,
        /// <summary>
        /// is this used?
        /// </summary>
        GetByOID = 2003,
        /// <summary>
        /// query a collection
        /// </summary>
        Query = 2004,
        /// <summary>
        /// Get more data from a query. See Cursors
        /// </summary>
        GetMore = 2005,
        /// <summary>
        /// Delete documents
        /// </summary>
        Delete = 2006,
        /// <summary>
        /// Tell database client is done with a cursor  
        /// </summary>
        KillCursors = 2007
    }

    internal static class IDBMessageExtensions
    {
        /// <summary>
        /// Gets the length of the message's body.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static int GetBodyLength(this IDBMessage message)
        {
            if (message == null)
                throw new ArgumentException("message object was null", "this");
            return message.MessageLength - Header.HEADER_LENGTH;
        }

        /// <summary>
        /// Gets the error message from the response (if there is one).
        /// </summary>
        /// <param name="response">The error message as a string or null if there is no error.</param>
        /// <returns></returns>
        public static string GetError(this IDBResponse response)
        {
            if (response == null)
                throw new ArgumentException("response object was null", "this");

            if (!response.Documents.Any())
                return null;

            //TODO:Make a constant for another magic string case: $err
            return response.Documents.First().GetAsString("$err");
        }
    }
}