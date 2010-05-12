
namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Evals the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="code">The code.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static object eval(this IDatabase db, string code, params object[] args)
        {
            DBQuery cmd = new DBQuery() { { "$eval", code }, { "args", args } };
            IDBObject res = db.ExecuteCommand(cmd);
            res.ThrowIfResponseNotOK("eval failed");
            return res["retval"];
        }
    }
}
