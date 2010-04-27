using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        //IDatabase
        //{ clone  : from_host }

        //// clone the current database (implied by 'db') from another host
        //var fromhost = ...;
        //print("about to get a copy of database " + db + " from " + fromhost);
        //db.cloneDatabase(fromhost);
        //// in "command" syntax (runnable from any driver):
        //db.runCommand( { clone : fromhost } );
    }
}
