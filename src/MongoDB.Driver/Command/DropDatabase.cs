
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Drops the database.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="dbName">Name of the db.</param>
        public static void dropDatabase(this IDatabase db, string dbName)
        {
            IDBObject res = db.ExecuteCommand(_dropDatabase);
            //{ok : 1}
            res.ThrowIfResponseNotOK("dropDatabse failed");
        }

        //{dropDatabase : 1}
        static DBQuery _dropDatabase = new DBQuery("dropDatabase", 1);
    }
}
