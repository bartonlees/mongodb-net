using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    /// <summary>
    /// Convenience wrapper for error responses from the database
    /// </summary>
    public class DBError
    {
        public enum Code
        {
            NoError = 0,
            FailingUpdateOfCappedNS = 10003,
            DuplicateKeyError = 11000,
            DuplicateKeyOnUpdate = 11001,
            IdxNoFails = 12000,
            CannotSortMSSnapshot = 12001,
            CannotIncAnIndexedField = 12010,
            CannotSetAnIndexedField = 12011
        }

        /// <summary>
        /// Parses an error code from the start of the specified string
        /// </summary>
        /// <param name="error">The error string.</param>
        /// <returns>the code, or Code.NoError if a code cannot be parsed</returns>
        public static Code ToCode(string error)
        {
            if (string.IsNullOrWhiteSpace(error) || !error.StartsWith("E"))
                return Code.NoError;
            //Retrieve numeric characters after "E"
            string code = new string(error.Substring(1,11).TakeWhile( c => char.IsNumber(c)).ToArray());
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

        public string Message { get { return Response.GetAsString("errmsg"); } }
        public string Assertion { get { return Response.GetAsString("assertion"); } }

        static string[] _nsMissingErrors = {"ns not found", "ns does not exist", "ns missing"};

        public bool NamespaceWasNotFound { get { return _nsMissingErrors.Contains(Response.GetAsString("errmsg"));}}

        public void Throw(string context)
        {
            throw new MongoException(string.Format("{0} : {1}", context,Message));
        }
    }
}
