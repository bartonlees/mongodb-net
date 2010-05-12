using System;

namespace MongoDB.Driver.Command
{
    /**
         *  Gets the the error (if there is one) from the previous operation.  The result of
         *  this command will look like
         *
         *  <pre>
         * { "err" :  errorMessage  , "ok" : 1.0 , "_ns" : "$cmd"}
         * </pre>
         *
         * The value for errorMessage will be null if no error occurred, or a description otherwise.
         *
         * Care must be taken to ensure that calls to getLastError go to the same connection as that
         * of the previous operation. See com.mongodb.Mongo.requestStart for more information.
         *
         *  @return DBObject with error and status information
         */

    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Getlasterrors the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static LastError getlasterror(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_getlasterror);
            res.ThrowIfResponseNotOK("getlasterror failed");
            return new LastError(res);
        }

        static DBQuery _getlasterror = new DBQuery("getlasterror", 1);
    }
}

namespace MongoDB.Driver
{
    /// <summary>
    /// Convenience wrapper for the result of the GetLastError command
    /// </summary>
    public class LastError : DBObjectWrapper
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LastError"/> class.
        /// </summary>
        /// <param name="res">The res.</param>
        public LastError(IDBObject res)
            : base(res)
        {
        }

        //{err : error, n : numberOfErrors, ok : 1}
        /// <summary>
        /// Gets the number of errors.
        /// </summary>
        /// <value>The number of errors.</value>
        public int NumberOfErrors { get { return Object.GetAsInt("n"); } }
        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage { get { return Object.GetAsString("err"); } }
        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        public DBError.Code Code { get { return DBError.ToCode(ErrorMessage); } }
    }
}
