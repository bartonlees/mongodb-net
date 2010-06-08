using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MongoDB.Driver.Conditions;

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
        /// Expresses an equality test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the operands are equal.</returns>
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
        /// Expresses an inequality test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the operands are not equal.</returns>
        public static bool operator !=(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation(DBQuery.ConditionalOperation.Ne, rhs);
            return true;
        }

        /// <summary>
        /// Expresses an equality test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the operands are equal.</returns>
        public static bool operator ==(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation(null, lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Expresses an inequality test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the operands are not equal.</returns>
        public static bool operator !=(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation(DBQuery.ConditionalOperation.Ne, lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Expresses an value comparison (greater than) test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the lhs is greater than the rhs</returns>
        public static bool operator >(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation(DBQuery.ConditionalOperation.Gt, rhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Expresses an value comparison (less than) test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the lhs is less than the rhs.</returns>
        public static bool operator <(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation(DBQuery.ConditionalOperation.Lt, rhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Expresses an value comparison (greater than) test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the lhs is greater than the rhs</returns>
        public static bool operator >(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation(DBQuery.ConditionalOperation.Lte, lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Expresses an value comparison (less than) test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the lhs is less than the rhs</returns>
        public static bool operator <(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation(DBQuery.ConditionalOperation.Gte, lhs);
            return true; //to enforce full expression visitation
        }


        /// <summary>
        /// Expresses an value comparison (greater than or equal) test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the lhs is greater than or equal to the rhs</returns>
        public static bool operator >=(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation(DBQuery.ConditionalOperation.Gte, rhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Expresses an value comparison (less than or equal) test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the lhs is less than or equal to the rhs</returns>
        public static bool operator <=(DBQueryParameter lhs, object rhs)
        {
            lhs.AppendOperation(DBQuery.ConditionalOperation.Lte, rhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Expresses an value comparison (greater than or equal) test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the lhs is greater than or equal to the rhs</returns>
        public static bool operator >=(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation(DBQuery.ConditionalOperation.Lt, lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Expresses an value comparison (less than or equal) test between a Query parameter and some other value
        /// </summary>
        /// <param name="lhs">The left hand side operand.</param>
        /// <param name="rhs">The right hand side operand.</param>
        /// <returns><c>true</c> if the lhs is less than or equal to the rhs</returns>
        public static bool operator <=(object lhs, DBQueryParameter rhs)
        {
            rhs.AppendOperation(DBQuery.ConditionalOperation.Gt, lhs);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests if this parameter is a member of the specified list
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if this is a member; <c>false</c> otherwise.</returns>
        public bool In(IList list)
        {
            AppendOperation(DBQuery.ConditionalOperation.In, list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests if this parameter is a member of the specified list
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if this is a member; <c>false</c> otherwise.</returns>
        public bool In(params object[] list)
        {
            AppendOperation(DBQuery.ConditionalOperation.In, list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests if this parameter is not a member of the specified list
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if this is not a member; <c>false</c> otherwise.</returns>
        public bool Nin(params object[] list)
        {
            AppendOperation(DBQuery.ConditionalOperation.Nin, list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests if this parameter is not a member of the specified list
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if this is not a member; <c>false</c> otherwise.</returns>
        public bool Nin(IList list)
        {
            AppendOperation(DBQuery.ConditionalOperation.Nin, list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests if this parameter contains all the members of the specified list
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if this contains all members; <c>false</c> otherwise.</returns>
        public bool All(IList list)
        {
            AppendOperation(DBQuery.ConditionalOperation.All, list);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests whether or not this field has the specified size
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public bool Size(int size)
        {
            AppendOperation(DBQuery.ConditionalOperation.Size, size);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests whether or not this field has the specified size
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public bool Size(long size)
        {
            AppendOperation(DBQuery.ConditionalOperation.Size, size);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that test whether or not this field, when divided by the divisor, has the specified remainder
        /// </summary>
        /// <param name="divisor">The divisor.</param>
        /// <param name="remainder">The remainder.</param>
        /// <returns></returns>
        public bool Mod(int divisor, int remainder)
        {
            Condition.Requires(divisor, DBQuery.ConditionalOperation.Divisor).IsGreaterThan(0);
            Condition.Requires(remainder, DBQuery.ConditionalOperation.Remainder).IsGreaterOrEqual(0);
            AppendOperation(DBQuery.ConditionalOperation.Mod, new int[] { divisor, remainder });
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that test whether or not this field, when divided by the divisor, has the specified remainder
        /// </summary>
        /// <param name="divisor">The divisor.</param>
        /// <param name="remainder">The remainder.</param>
        /// <returns></returns>
        public bool Mod(long divisor, long remainder)
        {
            Condition.Requires(divisor, DBQuery.ConditionalOperation.Divisor).IsGreaterThan(0L);
            Condition.Requires(remainder, DBQuery.ConditionalOperation.Remainder).IsGreaterOrEqual(0L);
            AppendOperation(DBQuery.ConditionalOperation.Mod, new long[] { divisor, remainder });
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests if this parameter exists in the document
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            AppendOperation(DBQuery.ConditionalOperation.Exists, true);
            return true; //to enforce full expression visitation
        }

        /// <summary>
        /// Builds an expression that tests if this parameter does not exist in the document
        /// </summary>
        /// <returns></returns>
        public bool Nexists()
        {
            AppendOperation(DBQuery.ConditionalOperation.Exists, false);
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

        /// <summary>
        /// Toes the DB query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static DBQuery ToDBQuery<T>(this Expression<T> selector) where T : class
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
