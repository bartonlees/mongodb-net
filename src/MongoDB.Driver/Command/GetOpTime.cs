
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {

        /// <summary>
        /// Retrieves the elapsed time of the last operation on the server
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static OpTime getoptime(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_getoptime);
            res.ThrowIfResponseNotOK("unable to retrieve operation time");
            return new OpTime(res);
        }

        static DBQuery _getoptime = new DBQuery("getoptime", 1);
    }

    /// <summary>
    /// A strongly typed wrapper of the result of the getoptime message
    /// </summary>
    public class OpTime : DBObjectWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpTime"/> class.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public OpTime(IDBObject obj)
            : base(obj)
        {
        }
    }
}
