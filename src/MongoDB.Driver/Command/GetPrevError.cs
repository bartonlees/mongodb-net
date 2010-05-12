using System;

namespace MongoDB.Driver.Command
{
    /// <summary>
    /// Returns the last error that occurred since start of database or a call to ResetError
    /// Care must be taken to ensure that calls to getPreviousError go to the same connection as that
    /// of the previous operation. See com.mongodb.Mongo.requestStart for more information.
    /// </summary>
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Getpreverrors the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static PrevError getpreverror(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_getpreverror);
            res.ThrowIfResponseNotOK("getpreverror failed");
            return new PrevError(res);
        }
        static DBQuery _getpreverror = new DBQuery("getpreverror", 1);
    }

    /// <summary>
    /// 
    /// </summary>
    public class PrevError : DBObjectWrapper
    {
        //{ err : errorMessage, nPrev : countOpsBack, ok : 1 }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrevError"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        public PrevError(IDBObject response)
            : base(response)
        {
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>will be null of no error has ocurred, or the message</value>
        public string ErrorMessage { get { return Object.GetAsString("err"); } }

        /// <summary>
        /// Gets the number of elapsed operations
        /// </summary>
        /// <value>the number of operations since the error occurred</value>
        public int ElapsedOperations { get { return Object.GetAsInt("nPrev"); } }
    }
}
