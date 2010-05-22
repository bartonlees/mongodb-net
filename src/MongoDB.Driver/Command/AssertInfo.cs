
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Retrieves assert information from the server
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static AssertInfo assertinfo(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_assertinfo);
            res.ThrowIfResponseNotOK("unable to retrieve assert information");
            return new AssertInfo(res);
        }

        static DBQuery _assertinfo = new DBQuery("assertinfo", 1);

        //IDatabase
        //> db.$cmd.findOne({assertinfo:1})
        //{
        //    "dbasserted" : false , // boolean: db asserted
        //    "asserted" : false , // boolean: db asserted or a user assert have happend
        //    "assert" : "" ,  // regular assert
        //    "assertw" : "" , // "warning" assert
        //    "assertmsg" : "" , // assert with a message in the db log
        //    "assertuser" : "" , // user assert - benign, generally a request that was not meaningful
        //    "ok" : 1.0
        //}


    }

    /// <summary>
    /// The results of an assertinfo query
    /// </summary>
    public class AssertInfo : DBObjectWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssertInfo"/> class.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public AssertInfo(IDBObject obj)
            : base(obj)
        {
        }
    }
}
