//DEVFUEL COPYRIGHT

using System.Collections;
using System.Collections.Generic;

namespace MongoDB.Driver
{
    /// <summary>
    /// A DBObject that is optimized for modification clauses on DB updates
    /// </summary>
    public class DBModifier : DBObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBModifier"/> class.
        /// </summary>
        public DBModifier()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBModifier"/> class from an existing DBObject.
        /// </summary>
        /// <param name="obj">The db object</param>
        public DBModifier(IDictionary<string, object> obj)
            : base(obj)
        {
        }

        /// <summary>
        /// Convenience constructor.
        /// Initializes a new instance of the <see cref="DBModifier"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public DBModifier(string key, object value)
        {
            this[key] = value;
        }


        /// <summary>
        /// Incs the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier Inc(string fieldName, object value)
        {
            if (!ContainsKey("$inc"))
            {
                this["$inc"] = new DBObject();
            }
            this.GetAsIDBObject("$inc")[fieldName] = value;
            return this;
        }

        /// <summary>
        /// Sets the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier Set(string fieldName, object value)
        {
            if (!ContainsKey("$set"))
            {
                this["$set"] = new DBObject();
            }
            this.GetAsIDBObject("$set")[fieldName] = value;
            return this;
        }

        /// <summary>
        /// Unsets the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier Unset(string fieldName, object value)
        {
            if (!ContainsKey("$unset"))
            {
                this["$unset"] = new DBObject();
            }
            this.GetAsIDBObject("$unset")[fieldName] = value;
            return this;
        }

        /// <summary>
        /// Pushes the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier Push(string fieldName, object value)
        {
            if (!ContainsKey("$push"))
            {
                this["$push"] = new DBObject();
            }
            this.GetAsIDBObject("$push")[fieldName] = value;
            return this;
        }

        /// <summary>
        /// Pushes all.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier PushAll(string fieldName, IList value)
        {
            if (!ContainsKey("$pushAll"))
            {
                this["$pushAll"] = new DBObject();
            }
            this.GetAsIDBObject("$pushAll")[fieldName] = value;
            return this;
        }

        /// <summary>
        /// Adds to set.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier AddToSet(string fieldName, object value)
        {
            if (!ContainsKey("$addToSet"))
            {
                this["$addToSet"] = new DBObject();
            }
            this.GetAsIDBObject("$addToSet")[fieldName] = value;
            return this;
        }

        /// <summary>
        /// Adds the each to set.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier AddEachToSet(string fieldName, IList value)
        {
            return AddToSet(fieldName, new DBObject("$each", value));
        }

        /// <summary>
        /// Pops the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fromTop">if set to <c>true</c> [from top].</param>
        /// <returns></returns>
        public DBModifier Pop(string fieldName, bool fromTop = true)
        {
            if (!ContainsKey("$pop"))
            {
                this["$pop"] = new DBObject();
            }
            this.GetAsIDBObject("$pop")[fieldName] = fromTop ? 1 : -1;
            return this;
        }

        /// <summary>
        /// Pulls the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier Pull(string fieldName, object value)
        {
            if (!ContainsKey("$pull"))
            {
                this["$pull"] = new DBObject();
            }
            this.GetAsIDBObject("$pull")[fieldName] = value;
            return this;
        }

        /// <summary>
        /// Pulls all.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public DBModifier PullAll(string fieldName, IList value)
        {
            if (!ContainsKey("$pullAll"))
            {
                this["$pullAll"] = new DBObject();
            }
            this.GetAsIDBObject("$pullAll")[fieldName] = value;
            return this;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class Do
    {
        /// <summary>
        /// Incs the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Inc(string fieldName, object value)
        {
            return new DBModifier().Inc(fieldName, value);
        }

        /// <summary>
        /// Sets the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Set(string fieldName, object value)
        {
            return new DBModifier().Set(fieldName, value);
        }

        /// <summary>
        /// Unsets the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Unset(string fieldName, object value)
        {
            return new DBModifier().Unset(fieldName, value);
        }

        /// <summary>
        /// Pushes the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Push(string fieldName, object value)
        {
            return new DBModifier().Push(fieldName, value);
        }

        /// <summary>
        /// Pushes all.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier PushAll(string fieldName, IList value)
        {
            return new DBModifier().PushAll(fieldName, value);
        }

        /// <summary>
        /// Adds to set.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier AddToSet(string fieldName, object value)
        {
            return new DBModifier().AddToSet(fieldName, value);
        }

        /// <summary>
        /// Adds the each to set.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier AddEachToSet(string fieldName, IList value)
        {
            return new DBModifier().AddEachToSet(fieldName, value);
        }

        /// <summary>
        /// Pops the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fromTop">if set to <c>true</c> [from top].</param>
        /// <returns></returns>
        public static DBModifier Pop(string fieldName, bool fromTop = true)
        {
            return new DBModifier().Pop(fieldName, fromTop);
        }

        /// <summary>
        /// Pulls the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Pull(string fieldName, object value)
        {
            return new DBModifier().Pull(fieldName, value);
        }

        /// <summary>
        /// Pulls all.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier PullAll(string fieldName, IList value)
        {
            return new DBModifier().PullAll(fieldName, value);
        }
    }
}
