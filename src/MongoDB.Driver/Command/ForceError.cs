using System;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Forceerrors the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static DBError forceerror(this IDatabase db)
        {
            IDBObject res = db.ExecuteCommand(_forceerror);
            DBError error = null;
            //{assertion : "forced error", errmsg : "db assertion failure", ok : 0}
            if (res.WasError(out error))
                return error;
            throw new Exception("forceerror did not cause error");
        }

        //TODO:Readonly db object wrappers to avoid tampering with these "constants"
        static DBQuery _forceerror = new DBQuery("forceerror", 1);
    }
}
