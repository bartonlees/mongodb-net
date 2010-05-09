using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace MongoDB.Driver
{
    /// <summary>
    /// Lambda based query support helper
    /// </summary>
    public static class Lambda
    {
        public static DBQuery Query(Expression<Func<DBQueryParameter, DBQueryParameter, DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }

        public static DBQuery Query(Expression<Func<DBQueryParameter, DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }

        public static DBQuery Query(Expression<Func<DBQueryParameter, bool>> selector)
        {
            return selector.ToDBQuery();
        }

    }
}
