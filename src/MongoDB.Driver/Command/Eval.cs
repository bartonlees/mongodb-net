using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        public static object eval(this IDatabase db, string code, params object[] args)
        {
            DBQuery cmd = new DBQuery() {{"$eval", code},{"args", args}};
            IDBObject res = db.ExecuteCommand(cmd);
            res.ThrowIfResponseNotOK("eval failed");
            return res["retval"];
        }
    }
}
