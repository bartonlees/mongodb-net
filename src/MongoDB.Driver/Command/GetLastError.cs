using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    /// Convenience wrapper for the result of the <see cref="GetLastError"/> command
    /// </summary>
    public class LastError : DBObjectWrapper
    {

        public LastError(IDBObject res)
            : base(res)
        {
        }

        //{err : error, n : numberOfErrors, ok : 1}
        public int NumberOfErrors { get { return Object.GetAsInt("n"); } }
        public string ErrorMessage { get { return Object.GetAsString("err"); } }
        public DBError.Code Code { get { return DBError.ToCode(ErrorMessage); } }
    }
}
