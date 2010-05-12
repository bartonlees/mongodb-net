using System.Linq;
using System.Security;
using MongoDB.Driver.Message;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        /// <summary>
        /// Authenticates the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="username">The username.</param>
        /// <param name="nonce">The nonce.</param>
        /// <param name="key">The key.</param>
        public static void authenticate(this IDatabase db, string username, string nonce, SecureString key)
        {
            DBQuery cmd = BuildQuery_authenticate(username, nonce, key);
            IDBObject res = db.ExecuteCommand(cmd);
            res.ThrowIfResponseNotOK("authenticate failed");
        }

        /// <summary>
        /// Authenticates the specified connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="username">The username.</param>
        /// <param name="nonce">The nonce.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool authenticate(this IDBConnection connection, IDBCollection collection, string username, string nonce, SecureString key)
        {
            DBQuery cmd = BuildQuery_authenticate(username, nonce, key);
            IDocument result = connection.Call<Document>(new Query(new DBCursorOptions(collection, selector: cmd, limit: 1))).Documents.FirstOrDefault();
            DBError err;
            return !result.WasError(out err);
        }

        static DBQuery BuildQuery_authenticate(string username, string nonce, SecureString key)
        {
            return new DBQuery 
            {
                {"authenticate", 1},
                {"user", username},
                {"nonce", nonce},
                {"key", key} //should evenutally be Util.hexMD5(Encoding.UTF8.GetBytes(key))
            };
        }
    }
}
