using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace MongoDB.Driver
{
    /// <summary>
    /// The static root for <see cref="DBQuery"/> generation
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
