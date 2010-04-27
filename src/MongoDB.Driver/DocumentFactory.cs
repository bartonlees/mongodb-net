using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    //http://www.smelser.net/blog/post/2010/03/05/When-Activator-is-just-to-slow.aspx
    public static class DocumentFactory<TDoc> where TDoc : class, IDocument
    {
        static DocumentFactory()
        {
            ConstructorInfo constructorInfo = typeof(TDoc).GetConstructor(new Type[] { typeof(Oid), typeof(bool) });
            Condition.Requires(constructorInfo, "constructionInfo").IsNotNull(string.Format("\"{0}\" type must have an (Oid, bool) constructor to be used in the DocumentFactory<T>", typeof(TDoc).Name));

            ParameterExpression p1 = Expression.Parameter(typeof(Oid), "id");
            ParameterExpression p2 = Expression.Parameter(typeof(bool), "partial");

            _Ctor = Expression.Lambda<Func<Oid, bool, TDoc>>(Expression.New(constructorInfo, p1, p2), p1, p2)
                        .Compile();
        }

        static Func<Oid, bool, TDoc> _Ctor = null;

        public static TDoc CreateDocument(Oid id, bool partial)
        {
            return _Ctor(id, partial);
        }
    }
}
