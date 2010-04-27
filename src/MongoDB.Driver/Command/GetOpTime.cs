using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {

        public static OpTime getoptime(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_getoptime);
            res.ThrowIfResponseNotOK("unable to retrieve operation time");
            return new OpTime(res);
        }

        static DBQuery _getoptime = new DBQuery("getoptime", 1);
    }

    public class OpTime : DBObjectWrapper
    {
        public OpTime(IDBObject obj)
            : base(obj)
        {
        }
    }
}
