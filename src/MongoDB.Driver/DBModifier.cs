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
        /// Well-Known Modifying commands
        /// </summary>
        public static class ModifierOperation
        {
            /// <summary>
            /// 
            /// </summary>
            public const string Add = "$add";
            /// <summary>
            /// increments <c>field</c> by the number <c>value</c> if <c>field</c> is present in the object, otherwise sets <c>field</c> to the number <c>value</c>.
            /// </summary>
            public const string Inc = "$inc";
            /// <summary>
            /// sets <c>field</c> to <c>value</c>. All datatypes are supported with $set.
            /// </summary>
            public const string Set = "$set";
            /// <summary>
            /// Deletes a given <c>field</c>. v1.3+
            /// </summary>
            public const string UnSet = "$unset";
            /// <summary>
            /// Appends value to <c>field</c>, if <c>field</c> is an existing array, otherwise sets <c>field</c> to the array [<c>value</c>] if <c>field</c> is not present. If <c>field</c> is present but is not an array, an error condition is raised.
            /// </summary>
            public const string Push = "$push";
            /// <summary>
            /// appends each value in value_array to field, if field is an existing array, otherwise sets field to the array value_array if field is not present. If field is present but is not an array, an error condition is raised.
            /// </summary>
            public const string PushAll = "$pushAll";
            /// <summary>
            /// Adds value to the array only if its not in the array already.
            /// </summary>
            public const string AddToSet = "$addToSet";
            /// <summary>
            /// Helper field for array operations
            /// </summary>
            public const string Each = "$each";
            /// <summary>
            /// removes the last/first element in an array. v1.1+
            /// </summary>
            public const string Pop = "$pop";
            /// <summary>
            /// removes all occurrences of value from field, if field is an array. If field is present but is not an array, an error condition is raised.
            /// </summary>
            public const string Pull = "$pull";
            /// <summary>
            /// removes all occurrences of each value in value_array from field, if field is an array. If field is present but is not an array, an error condition is raised.
            /// </summary>
            public const string PullAll = "$pullAll";
        }

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
            if (!ContainsKey(ModifierOperation.Inc))
            {
                this[ModifierOperation.Inc] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.Inc)[fieldName] = value;
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
            if (!ContainsKey(ModifierOperation.Set))
            {
                this[ModifierOperation.Set] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.Set)[fieldName] = value;
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
            if (!ContainsKey(ModifierOperation.UnSet))
            {
                this[ModifierOperation.UnSet] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.UnSet)[fieldName] = value;
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
            if (!ContainsKey(ModifierOperation.Push))
            {
                this[ModifierOperation.Push] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.Push)[fieldName] = value;
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
            if (!ContainsKey(ModifierOperation.PushAll))
            {
                this[ModifierOperation.PushAll] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.PushAll)[fieldName] = value;
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
            if (!ContainsKey(ModifierOperation.AddToSet))
            {
                this[ModifierOperation.AddToSet] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.AddToSet)[fieldName] = value;
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
            return AddToSet(fieldName, new DBObject(ModifierOperation.Each, value));
        }

        /// <summary>
        /// Pops the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fromTop">if set to <c>true</c> [from top].</param>
        /// <returns></returns>
        public DBModifier Pop(string fieldName, bool fromTop = true)
        {
            if (!ContainsKey(ModifierOperation.Pop))
            {
                this[ModifierOperation.Pop] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.Pop)[fieldName] = fromTop ? 1 : -1;
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
            if (!ContainsKey(ModifierOperation.Pull))
            {
                this[ModifierOperation.Pull] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.Pull)[fieldName] = value;
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
            if (!ContainsKey(ModifierOperation.PullAll))
            {
                this[ModifierOperation.PullAll] = new DBObject();
            }
            this.GetAsIDBObject(ModifierOperation.PullAll)[fieldName] = value;
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
