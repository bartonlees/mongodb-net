//COPYRIGHT

using MongoDB.Driver.Platform.Util;
using System.Diagnostics;
using System;
using System.Linq;
using MongoDB.Driver.Platform.IO;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Serialization;
using MongoDB.Driver.Platform.Conditions;
namespace MongoDB.Newtonsoft.Json
{
    /// <summary>
    /// A strongly typed IDBObject based off of a JsonContract
    /// </summary>
    public class ContractDBObject<T> : IDBObjectCustom where T:new()
    {
        T _Instance;
        JsonSerializer _Serializer;
        JsonObjectContract _Contract;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDBObject&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        public ContractDBObject()
            : this(new T(), new JsonSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDBObject&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        public ContractDBObject(T instance) : this(instance, new JsonSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDBObject&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        /// <param name="serializer">The serializer to use.</param>
        public ContractDBObject(T instance, JsonSerializer serializer)
        {
            Condition.Requires(serializer, "serializer")
                .IsNotNull();
            Condition.Requires(instance, "instance")
                .Evaluate(!instance.Equals(default(T)),"The instance requires a value");

            _Contract = serializer.ContractResolver.ResolveContract(typeof(T)) as JsonObjectContract;

            if (_Contract == null)
                throw new NotSupportedException("Only a serializer that resolves a JsonContract of type JsonObjectContract is supported");
            
            _Instance = instance;
            _Serializer = serializer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDBObject&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">An instance of the Contracted Type.</param>
        /// <param name="serializer">The serializer to use.</param>
        public ContractDBObject(T instance, JsonSerializer serializer, JsonObjectContract contract)
        {
            Condition.Requires(serializer, "serializer").IsNotNull();
            Condition.Requires(instance, "instance").Evaluate(!instance.Equals(default(T)), "The instance requires a value");
            Condition.Requires(contract, "contract").IsNotNull();
            _Contract = contract;            
            _Instance = instance;
            _Serializer = serializer;
            
        }

        public void PutAll(IDictionary<string, object> m)
        {
            foreach (string key in m.Keys)
            {
                this[key] = m[key];
            }
        }

        public override string ToString()
        {   
            using (StringWriter streamWriter = new StringWriter())
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
            {
                jsonTextWriter.Formatting = Formatting.Indented;
                _Serializer.Serialize(jsonTextWriter, _Instance);
                return streamWriter.GetStringBuilder().ToString();
            }
        }

        public void Add(string key, object value)
        {
            this[key] = value;
        }

        public bool ContainsKey(string key)
        {
            return _Contract.Properties.GetClosestMatchProperty(key) != null;
        }

        

        public ICollection<string> Keys
        {
            get { return _Contract.Properties.Select(prop => prop.PropertyName).ToList(); }
        }

        public bool Remove(string key)
        {
            throw new NotSupportedException();
        }

        public bool TryGetValue(string key, out object value)
        {
            value = null;
            JsonProperty prop = _Contract.Properties.GetClosestMatchProperty(key);
            if (prop == null)
                return false;
            value = prop.ValueProvider.GetValue(_Instance);
            return true;
        }

        public ICollection<object> Values
        {
            get
            {
                return _Contract.Properties.Select(prop => prop.ValueProvider.GetValue(_Instance)).ToList();
            }
        }

        public object this[string key]
        {
            get 
            {
                JsonProperty prop = _Contract.Properties.GetClosestMatchProperty(key);
                if (prop == null)
                    throw new KeyNotFoundException(string.Format("Cannot find a suitable match for: {0}", key));
                return prop.ValueProvider.GetValue(_Instance);
            }
            set
            {
                JsonProperty prop = _Contract.Properties.GetClosestMatchProperty(key);
                if (prop == null)
                    throw new KeyNotFoundException(string.Format("Cannot find a suitable match for: {0}", key));
                prop.ValueProvider.SetValue(_Instance, value);
            }
        }

        public void Add(KeyValuePair<string, object> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            foreach (string key in Keys)
            {
                array[arrayIndex++] = new KeyValuePair<string, object>(key, this[key]);
            }
        }

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

        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        public System.Collections.Generic.IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            KeyValuePair<string, object>[] array = new KeyValuePair<string,object>[Count];
            CopyTo(array, 0);
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string,object>>(array);
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Write(WireProtocolWriter writer)
        {
            using (NonClosingStreamWrapper rawStream = new NonClosingStreamWrapper(writer.BaseStream))
            using (BsonWriter bsonWriter = new BsonWriter(rawStream))
            {
                _Serializer.Serialize(bsonWriter, _Instance);
            }
        }

        public void Read(WireProtocolReader reader)
        {
            using (NonClosingStreamWrapper rawStream = new NonClosingStreamWrapper(reader.BaseStream))
            using (BsonReader bsonReader = new BsonReader(rawStream))
            {
                _Serializer.Populate(bsonReader, _Instance);
            }
        }
    }
}