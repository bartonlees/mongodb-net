
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Reseterrors the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        public static void reseterror(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_reseterror);
            res.ThrowIfResponseNotOK("reseterror failed");
        }

        //{reseterror : 1}
        static DBQuery _reseterror = new DBQuery("reseterror", 1);
    }
}
