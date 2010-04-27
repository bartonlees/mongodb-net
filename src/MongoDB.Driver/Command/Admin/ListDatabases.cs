using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Returns a list of database names and sizes.
        /// </summary>
        /// <returns>the list</returns>
        public static DatabaseList listDatabases(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_listDatabases);
            response.ThrowIfResponseNotOK("listDatabases failed");
            return new DatabaseList(response);
        }

        static DBQuery _listDatabases = new DBQuery("listDatabases", 1);
    }


    public class DatabaseList : DBObjectWrapper
    {
        public DatabaseList(IDBObject response)
            : base(response)
        {
        }
        public DBObjectArray Databases { get { return (DBObjectArray)Object["databases"]; } }
        public IEnumerable<Uri> DatabaseNames
        {
            get
            {
                foreach (DBObject o in (Databases as IEnumerable<object>))
                {
                    yield return new Uri(o.GetAsString("name"), UriKind.RelativeOrAbsolute);
                }
            }
        }
        public object SysInfo { get { return Object["sysInfo"]; } }
    }
}
