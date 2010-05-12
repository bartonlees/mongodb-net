//COPYRIGHT

using System.Collections.Generic;
namespace MongoDB.Driver
{

    /// <summary>
    /// A simple implementation of <code>IDBObject</code>.
    /// An <code>IDBObject</code> can be created as follows, using this class:
    /// <blockquote><pre>
    /// IDBObject obj = new BasicDBObject();
    /// obj["foo"] = "bar";
    /// </pre></blockquote>
    /// </summary>
    public class DBObject : Dictionary<string, object>, IDBObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        public DBObject()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObject"/> class from an existing DBObject.
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
        /// Convenience constructor.
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        /// <param name="key1">The key1.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="key2">The key2.</param>
        /// <param name="value2">The value2.</param>
        public DBObject(string key1, object value1, string key2, object value2)
        {
            Add(key1, value1);
            Add(key2, value2);
        }

        /// <summary>
        /// Convenience constructor.
        /// Initializes a new instance of the <see cref="DBObject"/> class.
        /// </summary>
        /// <param name="key1">The key1.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="key2">The key2.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="key3">The key3.</param>
        /// <param name="value3">The value3.</param>
        public DBObject(string key1, object value1, string key2, object value2, string key3, object value3)
        {
            Add(key1, value1);
            Add(key2, value2);
            Add(key3, value3);
        }

        /// <summary>
        /// Copies JSON pairs from the specified dbObject to this one
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
        /// Appends the specified key/value pair in a manner that allows chaining of commands.
        /// <code>new BasicDBObject().append("test", 0).append("t2", 1);</code>
        /// </summary>
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