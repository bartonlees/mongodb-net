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

        static DBQuery _IsMaster = (DBQuery)new DBQuery().Append("ismaster", 1);
        /// <summary>
        /// Gets the "is master?" query.
        /// </summary>
        /// <value>The query that checks to see who the master is.</value>
        public static DBQuery IsMaster { get { return _IsMaster; } }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class Where
    {
        /// <summary>
        /// Builds a DBQuery from the supplied lambda expression (three separate parameters)
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static DBQuery Fields(Expression<Func<DBQueryParameter, DBQueryParameter, DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }

        /// <summary>
        /// Builds a DBQuery from the supplied lambda expression (two separate parameters)
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static DBQuery Fields(Expression<Func<DBQueryParameter, DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }

        /// <summary>
        /// Builds a DBQuery from the supplied lambda expression (one parameter)
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static DBQuery Field(Expression<Func<DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }
    }
}
