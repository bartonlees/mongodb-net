//DEVFUEL COPYRIGHT

using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// A convenience DBObject to hold sets of field names for queries in the correct format
    /// </summary>
    public class DBFieldSet : DBObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBFieldSet"/> class.
        /// </summary>
        /// <param name="fieldNames">The field names.</param>
        public DBFieldSet(params string[] fieldNames)
            : this(fieldNames as IEnumerable<string>)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBFieldSet"/> class.
        /// </summary>
        /// <param name="fieldNames">The field names.</param>
        public DBFieldSet(IEnumerable<string> fieldNames)
        {
            foreach (string fieldName in fieldNames)
            {
                this[fieldName] = 1;
            }
        }

        /// <summary>
        /// Generate an index name from this set of fields
        /// </summary>
        /// <returns>
        /// a string representation of this index's fields
        /// </returns>
        public Uri GenerateIndexUri()
        {
            string name = "";
            foreach (string key in Keys)
            {
                if (name.Length > 0)
                    name += "_";
                name += key + "_";
                object val = this[key];
                if (val is int || val is long || val is double || val is float)
                    name += val.ToString().Replace(' ', '_');
            }
            return new Uri(name, UriKind.Relative);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="MongoDB.Driver.DBFieldSet"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="fieldSet">The field set.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(DBFieldSet fieldSet)
        {
            return fieldSet.Keys.First();
        }
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="MongoDB.Driver.DBFieldSet"/>.
        /// </summary>
        /// <param name="s">The string, either a field name, or a comma delimeted set of field names.</param>
        /// <returns>The resulting Field Set.</returns>
        public static implicit operator DBFieldSet(string s)
        {
            Condition.Requires(s, "s").IsNotNullOrWhitespace();
            if (!s.Contains(','))
                return new DBFieldSet(s);
            return new DBFieldSet(s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        }
        /// <summary>
        /// Performs an implicit conversion from <see cref="MongoDB.Driver.DBFieldSet"/> to System.String[].
        /// </summary>
        /// <param name="fieldSet">The field set.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string[](DBFieldSet fieldSet)
        {
            return fieldSet.Keys.ToArray();
        }
        /// <summary>
        /// Performs an implicit conversion from System.String[] to <see cref="MongoDB.Driver.DBFieldSet"/>.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DBFieldSet(string[] s)
        {
            return new DBFieldSet(s);
        }

        static DBFieldSet _idKeyFieldSet = new DBFieldSet("_id");
        /// <summary>
        /// Gets the ID key field set.
        /// </summary>
        /// <value>The ID key field set.</value>
        public static DBFieldSet IDKeyFieldSet { get { return _idKeyFieldSet; } }
    }
}
