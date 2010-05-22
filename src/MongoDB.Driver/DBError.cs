using System;
using System.Linq;

namespace MongoDB.Driver
{
    /// <summary>
    /// Convenience wrapper for error responses from the database
    /// </summary>
    public class DBError
    {
        /// <summary>
        /// Well-known error codes
        /// </summary>
        public enum Code
        {
            /// <summary>
            /// No Error
            /// </summary>
            NoError = 0,
            /// <summary>
            /// Failing update of capped Namespace
            /// </summary>
            FailingUpdateOfCappedNS = 10003,
            /// <summary>
            /// Duplicate key error
            /// </summary>
            DuplicateKeyError = 11000,
            /// <summary>
            /// Duplicate key on update
            /// </summary>
            DuplicateKeyOnUpdate = 11001,
            /// <summary>
            /// Index number fails
            /// </summary>
            IdxNoFails = 12000,
            /// <summary>
            /// Cannot sort MS snapshot
            /// </summary>
            CannotSortMSSnapshot = 12001,
            /// <summary>
            /// Cannot increment an indexed field
            /// </summary>
            CannotIncAnIndexedField = 12010,
            /// <summary>
            /// Cannot set and indexed field
            /// </summary>
            CannotSetAnIndexedField = 12011
        }

        /// <summary>
        /// Parses an error code from the start of the specified string
        /// </summary>
        /// <param name="error">The error string.</param>
        /// <returns>
        /// the code, or Code.NoError if a code cannot be parsed
        /// </returns>
        public static Code ToCode(string error)
        {
            if (string.IsNullOrWhiteSpace(error) || !error.StartsWith("E"))
                return Code.NoError;
            //Retrieve numeric characters after "E"
            int maxLen = error.Length - 1;
            if (maxLen > 11)
                maxLen = 11;
            string code = new string(error.Substring(1,maxLen).TakeWhile(c => char.IsNumber(c)).ToArray());
            int i;
            if (!int.TryParse(code, out i) || !Enum.IsDefined(typeof(Code), i))
                return Code.NoError;
            return (Code)i;
        }

        /// <summary>
        /// Gets or sets the actual response document.
        /// </summary>
        /// <value>The response.</value>
        public IDBObject Response { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBError"/> class.
        /// </summary>
        /// <param name="response">The underlying response object from the database.</param>
        public DBError(IDBObject response)
        {
            Response = response;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get { return Response.GetAsString("errmsg"); } }
        /// <summary>
        /// Gets the assertion.
        /// </summary>
        /// <value>The assertion.</value>
        public string Assertion { get { return Response.GetAsString("assertion"); } }

        static string[] _nsMissingErrors = { "ns not found", "ns does not exist", "ns missing" };

        /// <summary>
        /// Gets a value indicating whether [namespace was not found].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [namespace was not found]; otherwise, <c>false</c>.
        /// </value>
        public bool NamespaceWasNotFound { get { return _nsMissingErrors.Contains(Response.GetAsString("errmsg")); } }

        /// <summary>
        /// Throws the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Throw(string context)
        {
            throw new MongoException(string.Format("{0} : {1}", context, Message));
        }
    }
}
