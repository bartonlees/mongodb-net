
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Drivers the OID test.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static string driverOIDTest(this IDatabase db, Oid id)
        {
            IDBObject res = db.ExecuteCommand(new DBQuery("driverOIDTest", id));
            res.ThrowIfResponseNotOK("unable to retrieve string representation of OID");
            return res.GetAsString("str");
        }
    }
}
