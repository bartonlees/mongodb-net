using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        public static AssertInfo assertinfo(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_assertinfo);
            res.ThrowIfResponseNotOK("unable to retrieve assert information");
            return new AssertInfo(res);
        }

        static DBQuery _assertinfo = new DBQuery("assertinfo", 1);

        //IDatabase
        //> db.$cmd.findOne({assertinfo:1})
        //{
        //    "dbasserted" : false , // boolean: db asserted
        //    "asserted" : false , // boolean: db asserted or a user assert have happend
        //    "assert" : "" ,  // regular assert
        //    "assertw" : "" , // "warning" assert
        //    "assertmsg" : "" , // assert with a message in the db log
        //    "assertuser" : "" , // user assert - benign, generally a request that was not meaningful
        //    "ok" : 1.0
        //}

        
    }

    public class AssertInfo : DBObjectWrapper
    {
        public AssertInfo(IDBObject obj)
            : base(obj)
        {
        }
    }
}
