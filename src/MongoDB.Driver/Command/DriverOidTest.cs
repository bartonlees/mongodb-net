
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Performs an ObjectId test for the driver
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
