
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Creates the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="collectionName">Name of the collection.</param>
        /// <param name="options">The options.</param>
        public static void create(this IDatabase db, string collectionName, IDBObject options)
        {
            DBQuery createCmd = new DBQuery("create", collectionName);
            createCmd.PutAll(options);
            IDBObject result = db.ExecuteCommand(createCmd);
            result.ThrowIfResponseNotOK("create failed");
        }
    }
}
