using System.Linq;
using MongoDB.Driver.Message;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Gets a nonce for subsequent communication
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static string nonce(this IAdminOperations db)
        {
            IDBObject res = db.ExecuteCommand(_getnonce);
            res.ThrowIfResponseNotOK("unable to get nonce value for authentication");
            return res.GetAsString("nonce");
        }

        /// <summary>
        /// Gets a nonce for subsequent communication
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <returns></returns>
        public static string nonce(this IDBConnection connection, IDBCollection cmdCollection)
        {
            IDocument result = connection.Call<Document>(new Query(new DBCursorOptions(cmdCollection, selector: _getnonce, limit: 1))).Documents.FirstOrDefault();
            result.ThrowIfResponseNotOK("unable to get nonce value for authentication");
            return result.GetAsString("nonce");
        }

        static DBQuery _getnonce = new DBQuery("getnonce", 1);
    }
}
