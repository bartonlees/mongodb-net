using System;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// Extension functions for <see cref="Uri"/>
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public const string UriPrefixMongo = "mongo://";
        /// <summary>
        /// 
        /// </summary>
        public const string UriSchemeMongo = "mongo";

        internal static string GetFullCollectionName(this Uri collectionUri)
        {
            Condition.Requires(collectionUri, "collectionUri").IsNotNull().Evaluate(collectionUri.IsAbsoluteUri, "an absolute collection URI is required to retrieve the full collection name");
            string[] parts = collectionUri.PathAndQuery.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            Condition.Requires(collectionUri, "collectionUri").Evaluate(parts.Length == 2 && !string.IsNullOrWhiteSpace(parts[0]) && !string.IsNullOrWhiteSpace(parts[1]), "absolute collection URI must have a database and then collection name component");
            return string.Join(".", parts);
        }

        internal static string GetCollectionName(this Uri collectionUri)
        {
            Condition.Requires(collectionUri, "collectionUri").IsNotNull();
            if (collectionUri.IsAbsoluteUri)
            {
                string[] parts = collectionUri.PathAndQuery.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                Condition.Requires(collectionUri, "collectionUri").Evaluate(parts.Length >= 2 && !string.IsNullOrWhiteSpace(parts[1]), "absolute collection URI must have a database and then collection name component");
                return parts[1];
            }
            else
            {
                string[] parts = collectionUri.OriginalString.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                Condition.Requires(collectionUri, "collectionUri").Evaluate(parts.Length >= 1 && !string.IsNullOrWhiteSpace(parts[0]), "relative collection URI must have a collection name component");
                return parts[0];
            }
        }

        internal static string GetDatabaseName(this Uri databaseUri)
        {
            Condition.Requires(databaseUri, "databaseUri").IsNotNull();
            string path = databaseUri.IsAbsoluteUri ? databaseUri.PathAndQuery : databaseUri.OriginalString;
            string[] parts = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            Condition.Requires(databaseUri, "databaseUri").Evaluate(parts.Length >= 1 && !string.IsNullOrWhiteSpace(parts[0]), "database URI must have a database name component");
            return parts[0];
        }

        internal static string GetIndexName(this Uri indexUri)
        {
            Condition.Requires(indexUri, "indexUri").IsNotNull();
            if (indexUri.IsAbsoluteUri)
            {
                string[] parts = indexUri.PathAndQuery.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                Condition.Requires(indexUri, "indexUri").Evaluate(parts.Length >= 3 && !string.IsNullOrWhiteSpace(parts[2]), "absolute index URI must have a database, collection, and then index name component");
                return parts[2];
            }
            else
            {
                string[] parts = indexUri.OriginalString.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                Condition.Requires(indexUri, "indexUri").Evaluate(parts.Length >= 1 && !string.IsNullOrWhiteSpace(parts[0]), "relative index URI must have an index name component");
                return parts[0];
            }
        }
    }
}
