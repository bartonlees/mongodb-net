using System;
using System.Collections.Generic;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Returns a list of database names and sizes.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns>the list</returns>
        public static DatabaseList listDatabases(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_listDatabases);
            response.ThrowIfResponseNotOK("listDatabases failed");
            return new DatabaseList(response);
        }

        static DBQuery _listDatabases = new DBQuery("listDatabases", 1);
    }


    /// <summary>
    /// 
    /// </summary>
    public class DatabaseList : DBObjectWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseList"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        public DatabaseList(IDBObject response)
            : base(response)
        {
        }
        /// <summary>
        /// Gets the databases.
        /// </summary>
        /// <value>The databases.</value>
        public DBObjectArray Databases { get { return (DBObjectArray)Object["databases"]; } }
        /// <summary>
        /// Gets the database names.
        /// </summary>
        /// <value>The database names.</value>
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
        /// <summary>
        /// Gets the sys info.
        /// </summary>
        /// <value>The sys info.</value>
        public object SysInfo { get { return Object["sysInfo"]; } }
    }
}
