
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// The fsync command allows us to flush all pending writes to datafiles.  More importantly, it also provides a lock option that makes backups easier.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="asynchronous">if set to <c>true</c> return immediately, regardless of completion status.</param>
        /// <param name="shouldLock">if set to <c>true</c> will lock the database until it is subsequently unlocked.</param>
        /// <returns></returns>
        public static int fsync(this IAdminOperations db, bool asynchronous, bool shouldLock)
        {
            DBQuery query = new DBQuery()
            {
                {"fsync", 1},
            };
            if (asynchronous)
                query.Add("async", true);
            if (shouldLock)
                query.Add("lock", true);
            IDBObject res = db.ExecuteCommand(query);

            res.ThrowIfResponseNotOK("fsync failed");
            return res.GetAsInt("numFiles");
        }


        //{numFiles : N, ok : 1}
    }
}
