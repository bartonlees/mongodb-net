using System;
using System.Linq.Expressions;

namespace MongoDB.Driver
{
    /// <summary>
    /// Lambda based query support helper
    /// </summary>
    public static class Lambda
    {
        /// <summary>
        /// Queries the specified selector.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static DBQuery Query(Expression<Func<DBQueryParameter, DBQueryParameter, DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }

        /// <summary>
        /// Queries the specified selector.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static DBQuery Query(Expression<Func<DBQueryParameter, DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }

        /// <summary>
        /// Queries the specified selector.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static DBQuery Query(Expression<Func<DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }

    }
}
