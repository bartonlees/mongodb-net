using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Collections;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// A parameter for use in Lambda-based queries
    /// </summary>
    public class DBQueryParameter
    {
        internal object Value { get; private set; }
        internal string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBQueryParameter"/> class.
        /// </summary>
        public DBQueryParameter()
        {
            Value = null;
        }

        /// <summary>
        /// Explicitly sets the name of the field rather than relying on the lambda expression parsing.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public DBQueryParameter SetFieldName(string name)
        {
            Name = name; 
            return this;
        }

        /// <summary>
        /// Shorthand for SetFieldName function.
        /// </summary>
        /// <value></value>
        public DBQueryParameter this[string name] { get { return SetFieldName(name); } }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation(null, rhs);
            return true; //to enforce full expression visitation
        }

        internal void AppendOperation(string key, object value)
        {
            if (Value == null)
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    Value = new DBObject(key, value);
                }
                else
                {
                    Value = value;
                }
            }
            else if (Value is DBObject)
            {
                DBObject v = Value as DBObject;
                Condition.Requires(key, "key")
                    .IsNotNullOrWhitespace()
                    .Evaluate(!v.ContainsKey(key), "this key has already been set");
                v[key] = value;
            }
            else
                throw new InvalidOperationException("Attempted to append operation when it was not possible");
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation("$ne", rhs);
            return true;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation(null, lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation("$ne", lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation("$gt", rhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation("$lt", rhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation("$lte", lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation("$gte", lhs);
            return true; //to enforce full expression visitation
        }


        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation("$gte", rhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation("$lte", rhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation("$lt", lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation("$gt", lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Ins the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public bool In(IList list)
        {
            AppendOperation("$in", list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Ins the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public bool In(params object[] list)
        {
            AppendOperation("$in", list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Nins the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public bool Nin(params object[] list)
        {
            AppendOperation("$nin", list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Nins the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public bool Nin(IList list)
        {
            AppendOperation("$nin", list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Alls the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public bool All(IList list)
        {
            AppendOperation("$all", list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Sizes the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public bool Size(int size)
        {
            AppendOperation("$size", size);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Sizes the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public bool Size(long size)
        {
            AppendOperation("$size", size);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Mods the specified divisor.
        /// </summary>
        /// <param name="divisor">The divisor.</param>
        /// <param name="remainder">The remainder.</param>
        /// <returns></returns>
        public bool Mod(int divisor, int remainder)
        {
            Condition.Requires(divisor, "divisor").IsGreaterThan(0);
            Condition.Requires(remainder, "remainder").IsGreaterOrEqual(0);
            AppendOperation("$mod", new int[] { divisor, remainder });
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Mods the specified divisor.
        /// </summary>
        /// <param name="divisor">The divisor.</param>
        /// <param name="remainder">The remainder.</param>
        /// <returns></returns>
        public bool Mod(long divisor, long remainder)
        {
            Condition.Requires(divisor, "divisor").IsGreaterThan(0L);
            Condition.Requires(remainder, "remainder").IsGreaterOrEqual(0L);
            AppendOperation("$mod", new long[] { divisor, remainder });
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Existses this instance.
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            AppendOperation("$exists", true);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Nexistses this instance.
        /// </summary>
        /// <returns></returns>
        public bool Nexists()
        {
            AppendOperation("$exists", false);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Name.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// Matcheses the specified regex.
        /// </summary>
        /// <param name="regex">The regex.</param>
        /// <returns></returns>
        public bool Matches(Regex regex)
        {
            AppendOperation(null, regex);
            return true; //to enforce full expression visitation
        }
    }

    internal static class LambdaExpressionExtensions
    {
        //Func<DBQueryField, DBQueryField, DBQueryField, bool>
        public static DBQuery ToDBQuery<T>(this Expression<T> selector) where T:class
        {
            
            object[] fields = new object[selector.Parameters.Count];
            int i = 0;
            foreach (ParameterExpression px in selector.Parameters)
            {
                DBQueryParameter fld = new DBQueryParameter();
                fld.Name = px.Name;
                fields[i++] = fld;
            }
            Delegate del = selector.Compile() as Delegate;
            del.DynamicInvoke(fields);
            DBQuery q = new DBQuery();
            HashSet<string> nameSet = new HashSet<string>();
            foreach (DBQueryParameter fld in fields)
            {
                if (fld.Value != null)
                    q[fld.Name] = fld.Value;
                if (!nameSet.Add(fld.Name))
                    throw new InvalidOperationException(string.Format("Cannot have two parameters with the name \"{0}\"", fld.Name));
            }
            return q;
        }
    }
}
