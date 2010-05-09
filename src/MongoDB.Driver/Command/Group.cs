
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Groups the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="key">The key.</param>
        /// <param name="cond">The cond.</param>
        /// <param name="initial">The initial.</param>
        /// <param name="reduce">The reduce.</param>
        /// <returns></returns>
        public static IDBObject group(this IDatabase db, IDBCollection collection, DBFieldSet key, DBQuery cond, IDocument initial, string reduce)
        {
            DBObject group = new DBObject() 
            {
                  {"ns", collection.Name},
                  {"$reduce", reduce},
            };

            if (key != null)
                group["key"] = key;

            if (cond != null)
                group["cond"] = cond;

            if (initial != null)
                group["initial"] = initial;

            IDBObject ret = db.ExecuteCommand(new DBQuery("group", group));
            ret.ThrowIfResponseNotOK("group failed");
            return ret.GetAsIDBObject("retval");
        }
    }
}
