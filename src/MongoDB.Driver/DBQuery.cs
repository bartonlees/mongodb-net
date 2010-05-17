//DEVFUEL COPYRIGHT

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MongoDB.Driver
{
    /// <summary>
    /// A DBObject that is optimized for query (selector) clauses on DB operations
    /// </summary>
    public class DBQuery : DBObject
    {
        /// <summary>
        /// Well-Known Query Operations
        /// </summary>
        public static class ConditionalOperation
        {
            /// <summary>
            /// Not equals
            /// </summary>
            public const string Ne = "$ne";
            /// <summary>
            /// Greater than
            /// </summary>
            public const string Gt = "$gt";
            /// <summary>
            /// Less than
            /// </summary>
            public const string Lt = "$lt";
            /// <summary>
            /// Less than or equal to
            /// </summary>
            public const string Lte = "$lte";
            /// <summary>
            /// Greater than or equal to
            /// </summary>
            public const string Gte = "$gte";
            /// <summary>
            /// The $in operator is analogous to the SQL IN modifier, allowing you to specify an array of possible matches.
            /// </summary>
            public const string In = "$in";
            /// <summary>
            /// The $nin operator is similar to $in except that it selects objects for which the specified field does not have any value in the specified array.
            /// </summary>
            public const string Nin = "$nin";
            /// <summary>
            /// The $all operator is similar to $in, but instead of matching any value in the specified array all values in the array must be matched
            /// </summary>
            public const string All = "$all";
            /// <summary>
            /// The $size operator matches any array with the specified number of elements
            /// </summary>
            public const string Size = "$size";
            /// <summary>
            /// The $mod operator allows you to do fast modulo queries to replace a common case for where clauses.
            /// </summary>
            public const string Mod = "$mod";
            /// <summary>
            /// $mod divisor
            /// </summary>
            public const string Divisor = "divisor";
            /// <summary>
            /// The $mod operator allows you to do fast modulo queries to replace a common case for where clauses.
            /// </summary>
            public const string Remainder = "remainder";
            /// <summary>
            /// Check for existence (or lack thereof) of a field.
            /// </summary>
            public const string Exists = "$exists";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBQuery"/> class.
        /// </summary>
        public DBQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBQuery"/> class using the $where notation
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        public DBQuery(string whereClause)
        {
            this["$where"] = whereClause;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBQuery"/> class from an existing DBObject.
        /// </summary>
        /// <param name="obj">The db object</param>
        public DBQuery(IDictionary<string, object> obj)
            : base(obj)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="MongoDB.Driver.DBQuery"/>.
        /// </summary>
        /// <param name="whereClause">The where clause, or "*" for a query that selects all.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DBQuery(string whereClause)
        {
            if (whereClause == "*")
                return _SelectAll;
            return new DBQuery(whereClause);
        }


        /// <summary>
        /// Convenience constructor.
        /// Initializes a new instance of the <see cref="DBQuery"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public DBQuery(string key, object value)
        {
            this[key] = value;
        }

        static DBQuery _SelectAll = new DBQuery();
        /// <summary>
        /// Gets the "select all" query.
        /// </summary>
        /// <value>The query that matches all records in the collection.</value>
        public static DBQuery SelectAll { get { return _SelectAll; } }

        static DBQuery _IsMaster = new DBQuery("ismaster", 1);
        /// <summary>
        /// Gets the "is master?" query.
        /// </summary>
        /// <value>The query that checks to see who the master is.</value>
        public static DBQuery IsMaster { get { return _IsMaster; } }
    }
}
