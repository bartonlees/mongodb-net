//COPYRIGHT

using System.Collections.Generic;
namespace MongoDB.Driver
{
    /// <summary>
    /// The primary, public implementation of <see cref="IDBObject"/>
    /// </summary>
    /// <remarks>
    /// DBObjects are dynamic blocks of data for use in server transmissions.
    /// <example caption="Simple constructor, explicit adds">
    /// <code>
    /// IDBObject o1 = new DBObject();
    /// o1.Add("key", "value");
    /// o1.Add("key2", 0);
    /// o1.Add("key3", true);
    /// </code>
    /// </example>
    /// <example caption="Convenience constructor">
    /// <code>
    /// IDBObject o2 = new DBObject("key", "value");
    /// </code>
    /// </example>
    /// <example caption="[http://msdn.microsoft.com/en-us/library/bb531208.aspx Collection initialization]">
    /// <code>
    /// IDBObject o3 = new DBObject() 
    /// {
    ///    {"key", "value"},
    ///    {"key2", 0},
    ///    {"key3", true}
    /// }
    /// </code>
    /// </example>
    /// <example caption="Nested object">
    /// <code>
    /// IDBObject o4 = new DBObject 
    /// {
    ///    {"key", new DBObject{
    ///      {"key2", 0},
    ///      {"key3", true}}
    ///    }
    /// }
    /// </code>
    /// </example>
    /// </remarks>
    public class DBObject : Dictionary<string, object>, IDBObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        public DBObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObject"/> class from an existing DBObject or compatible dictionary.
        /// </summary>
        /// <param name="obj">The db object</param>
        public DBObject(IDictionary<string, object> obj)
            : base(obj)
        {
        }

        /// <summary>
        /// Convenience constructor.
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public DBObject(string key, object value)
        {
            this[key] = value;
        }

        /// <summary>
        /// Copies pairs from the specified dbObject to this one
        /// </summary>
        /// <param name="dbObject">The DBObject.</param>
        public void PutAll(IDictionary<string, object> dbObject)
        {
            foreach (string key in dbObject.Keys)
            {
                this[key] = dbObject[key];
            }
        }

        /// <summary>
        /// Appends the specified pair in a manner that allows chaining of commands.</summary>
        /// <example caption="Chaining append operations">
        /// <code>new BasicDBObject().append("test", 0).append("t2", 1);</code>
        /// </example>
        /// <param name="key">The key.</param>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public DBObject Append(string key, object val)
        {
            this[key] = val;

            return this;
        }
    }
}