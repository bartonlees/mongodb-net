
namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Replacepeers the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static string replacepeer(this IAdminOperations db)
        {
            IDBObject res = db.ExecuteCommand(_replacepeer);
            res.ThrowIfResponseNotOK("replacepeer failed");
            return res.GetAsString("info");
        }

        static DBQuery _replacepeer = new DBQuery("replacepeer", 1);
    }
}
