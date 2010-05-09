//COPYRIGHT

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Platform.Conditions;
using MongoDB.Driver.Platform.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Serialization;
namespace MongoDB.Newtonsoft.Json
{
    /// <summary>
    /// A strongly typed IDBObject based off of a JsonContract
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ContractDBObject<T> : IDBObjectCustom where T : new()
    {
        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public T Instance { get; private set; }
        MongoDBSerializer _Serializer;
        JsonObjectContract _Contract;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDBObject&lt;T&gt;"/> class.
        /// </summary>
        public ContractDBObject()
            : this(new T(), new MongoDBSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDBObject&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        public ContractDBObject(T instance)
            : this(instance, new MongoDBSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDBObject&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        /// <param name="serializer">The serializer to use.</param>
        public ContractDBObject(T instance, MongoDBSerializer serializer)
        {
            Condition.Requires(serializer, "serializer")
                .IsNotNull();

            object boxedInstance = instance;
            Condition.Requires(boxedInstance, "instance").IsNotNull();
            JsonContract contract = serializer.ContractResolver.ResolveContract(typeof(T));
            _Contract = contract as JsonObjectContract;

            if (_Contract == null)
                throw new NotSupportedException("Only a serializer that resolves a JsonContract of type JsonObjectContract is supported");

            Instance = instance;
            _Serializer = serializer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDBObject&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        /// <param name="serializer">The serializer to use.</param>
        /// <param name="contract">The contract.</param>
        public ContractDBObject(T instance, MongoDBSerializer serializer, JsonObjectContract contract)
        {
            Condition.Requires(serializer, "serializer").IsNotNull();
            object boxedInstance = instance;
            Condition.Requires(boxedInstance, "instance").IsNotNull();
            Condition.Requires(contract, "contract").IsNotNull();
            _Contract = contract;
            Instance = instance;
            _Serializer = serializer;
        }

        /// <summary>
        /// Puts all.
        /// </summary>
        /// <param name="m">The m.</param>
        public void PutAll(IDictionary<string, object> m)
        {
            foreach (string key in m.Keys)
            {
                this[key] = m[key];
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            using (StringWriter streamWriter = new StringWriter())
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
            {
                jsonTextWriter.Formatting = Formatting.Indented;
                _Serializer.Serialize(jsonTextWriter, Instance);
                return streamWriter.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, object value)
        {
            this[key] = value;
        }

        /// <summary>
        /// Determines whether the specified key contains key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified key contains key; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey(string key)
        {
            return _Contract.Properties.GetClosestMatchProperty(key) != null;
        }



        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>The keys.</value>
        public ICollection<string> Keys
        {
            get { return _Contract.Properties.Select(prop => prop.PropertyName).ToList(); }
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Tries the get value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool TryGetValue(string key, out object value)
        {
            value = null;
            JsonProperty prop = _Contract.Properties.GetClosestMatchProperty(key);
            if (prop == null)
                return false;
            value = prop.ValueProvider.GetValue(Instance);
            return true;
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <value>The values.</value>
        public ICollection<object> Values
        {
            get
            {
                return _Contract.Properties.Select(prop => prop.ValueProvider.GetValue(Instance)).ToList();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <value></value>
        public object this[string key]
        {
            get
            {
                JsonProperty prop = _Contract.Properties.GetClosestMatchProperty(key);
                if (prop == null)
                    throw new KeyNotFoundException(string.Format("Cannot find a suitable match for: {0}", key));
                return prop.ValueProvider.GetValue(Instance);
            }
            set
            {
                JsonProperty prop = _Contract.Properties.GetClosestMatchProperty(key);
                if (prop == null)
                    throw new KeyNotFoundException(string.Format("Cannot find a suitable match for: {0}", key));
                prop.ValueProvider.SetValue(Instance, value);
            }
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(KeyValuePair<string, object> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(KeyValuePair<string, object> item)
        {
            return ContainsKey(item.Key);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            foreach (string key in Keys)
            {
                array[arrayIndex++] = new KeyValuePair<string, object>(key, this[key]);
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return _Contract.Properties.Count;
            }
        }

        bool ICollection<System.Collections.Generic.KeyValuePair<string, object>>.IsReadOnly
        {
            get { return true; }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[Count];
            CopyTo(array, 0);
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(array);
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Writes the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void Write(WireProtocolWriter writer)
        {
            using (NonClosingStreamWrapper rawStream = new NonClosingStreamWrapper(writer.BaseStream))
            using (BsonWriter bsonWriter = new BsonWriter(rawStream))
            {
                _Serializer.Serialize(bsonWriter, Instance);
            }
        }

        /// <summary>
        /// Reads the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public void Read(WireProtocolReader reader)
        {
            using (NonClosingStreamWrapper rawStream = new NonClosingStreamWrapper(reader.BaseStream))
            using (BsonReader bsonReader = new BsonReader(rawStream))
            {
                _Serializer.Populate(bsonReader, Instance);
            }
        }
    }
}