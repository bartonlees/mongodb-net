using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        //IDatabase
        //> db.$cmd.findOne({serverStatus:1})
        //{ 
        //  "uptime" : 6 , 
        //  "globalLock" : {
        //                    "totalTime" : 6765166 , 
        //                    "lockTime" : 2131 ,
        //                    "ratio" : 0.00031499596610046226
        //                 } , 
        //   "mem" : {
        //                    "resident" : 3 , 
        //                    "virtual" : 111 , 
        //                    "mapped" : 32
        //   } , 
        //  "ok" : 1
        //}
    }
}
