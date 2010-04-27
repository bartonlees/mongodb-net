using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver.Platform.Util;
using System.Security;
using MongoDB.Driver.Message;

namespace MongoDB.Driver.Command
{
    internal static partial class CommandExtensions
    {
        public static void authenticate(this IDatabase db, string username, string nonce, SecureString key)
        {
            DBQuery cmd = BuildQuery_authenticate(username, nonce, key);
            IDBObject res = db.ExecuteCommand(cmd);
            res.ThrowIfResponseNotOK("authenticate failed");
        }

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
