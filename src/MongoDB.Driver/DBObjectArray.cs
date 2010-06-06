//DEVFUEL COPYRIGHT

using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Driver.Conditions;
namespace MongoDB.Driver
{
    /// <summary>
    /// Utility class to support an array of <see cref="IDBObject"/> instances
    /// </summary>
    /// <example>
    /// <code><![CDATA[ 
    /// DBObjectArray obj = new DBObjectArray();
    /// obj["0"] = value1;
    /// obj["4"] = value2;
    /// obj[2] = value3;
    /// ]]></code>
    /// </example>
    /// <example>
    /// <code><![CDATA[ 
    /// BasicDBList list = new BasicDBList();
    /// list["1"] ="bar"; // ok
    /// list["1E1"] ="bar"; // throws exception
    /// ]]></code>
    /// </example>    
    public class DBObjectArray : IList, IList<object>, IDBObject
    {
        List<object> _list = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="DBObjectArray"/> class.
        /// </summary>
        public DBObjectArray()
        {
            _list = new List<object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObjectArray"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public DBObjectArray(int capacity)
        {
            _list = new List<object>(capacity);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObjectArray"/> class.
        /// </summary>
        /// <param name="map">The map.</param>
        public DBObjectArray(IDictionary<string, object> map)
        {
            Condition.Requires(map, "map").IsNotNull();
            _list = new List<object>(map.Count);
            PutAll(map);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObjectArray"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public DBObjectArray(params DBObject[] list)
        {
            Condition.Requires(list, "list").IsNotNull();
            _list = new List<object>(list.Length);
            foreach (object o in list)
            {
                (_list as IList).Add(o);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObjectArray"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public DBObjectArray(IList list)
        {
            Condition.Requires(list, "list").IsNotNull();
            _list = new List<object>(list.Count);
            foreach (object o in list)
            {
                (_list as IList).Add(o);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObjectArray"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public DBObjectArray(IList<object> list)
        {
            _list = new List<object>(list);
        }

        /// <summary>
        /// Puts all.
        /// </summary>
        /// <param name="map">The map.</param>
        public void PutAll(IDictionary<string, object> map)
        {
            foreach (KeyValuePair<string,object> pair in map)
            {
                this[pair.Key] = pair.Value;
            }
        }

        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        public int Capacity { get { return _list.Capacity; } set { _list.Capacity = value; } }

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
            int index = int.Parse(key);
            return index < _list.Count && index >= 0;
        }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>The keys.</value>
        public ICollection<string> Keys
        {
            get
            {
                int i = 0;
                return _list.ConvertAll(o => (i++).ToString());
            }
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            _list.RemoveAt(int.Parse(key));
            return true;
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
            int index = 0;
            if (!int.TryParse(key, out index) || index < 0 || index >= Count)
                return false;
            value = _list[index];
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
                return _list;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified key. Setting with an index greater than the capacity will cause an error. Otherwise the list will resize (filling with null entries) to accommodate.
        /// </summary>
        /// <value></value>
        public object this[string key]
        {
            get
            {
                int index = -1;
                if (!int.TryParse(key, out index))
                    throw new ArgumentException("Cannot parse integer index", "key");
                return this[index];
            }
            set
            {
                int index = -1;
                if (!int.TryParse(key, out index))
                    throw new ArgumentException("Cannot parse integer index", "key");
                this[index] = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <value></value>
        public object this[int key]
        {
            get
            {
                if (key < 0 || key >= _list.Count)
                    throw new ArgumentOutOfRangeException("key");
                return _list[key];
            }
            set
            {
                if (key < 0)
                    throw new ArgumentOutOfRangeException("key");
                while (key >= _list.Count)//allow a set that extends the list length (inside the capacity)
                {
                    _list.Add(null);
                }
                _list[key] = value;
            }
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(KeyValuePair<string, object> item)
        {
            this[item.Key] = item.Value;
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only. </exception>
        public void Clear()
        {
            _list.Clear();
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
            return ContainsKey(item.Key) && this[item.Key].Equals(item.Value);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex >= array.Length)
                throw new ArgumentException("index must be within the array", "arrayIndex");
            int source = 0;
            for (int dest = arrayIndex; dest < array.Length; dest++)
            {
                array[dest] = new KeyValuePair<string, object>(source.ToString(), _list[source++]);
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection"/>.</returns>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> is read-only; otherwise, false.</returns>
        bool ICollection<System.Collections.Generic.KeyValuePair<string, object>>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> is read-only; otherwise, false.</returns>
        bool ICollection<object>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<string, object> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            if (Count == 0)
                return new List<KeyValuePair<string, object>>().GetEnumerator();
            KeyValuePair<string, object>[] entryArray = new KeyValuePair<string, object>[Count];
            CopyTo(entryArray, 0);
            List<KeyValuePair<string, object>> entries = new List<KeyValuePair<string, object>>(entryArray);
            return entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public int IndexOf(object item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public void Insert(int index, object item)
        {
            _list.Insert(index, item);
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.IList"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(object item)
        {
            _list.Add(item);
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(object item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(object[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Remove(object item)
        {
            return _list.Remove(item);
        }

        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        private IList _ilist { get { return _list as IList; } }

        int IList.Add(object value)
        {
            return _ilist.Add(value);
        }

        void IList.Clear()
        {
            _ilist.Clear();
        }

        bool IList.Contains(object value)
        {
            return _ilist.Contains(value);
        }

        int IList.IndexOf(object value)
        {
            return _ilist.IndexOf(value);
        }

        void IList.Insert(int index, object value)
        {
            _ilist.Insert(index, value);
        }

        bool IList.IsFixedSize
        {
            get { return _ilist.IsFixedSize; }
        }

        bool IList.IsReadOnly
        {
            get { return _ilist.IsReadOnly; }
        }

        void IList.Remove(object value)
        {
            _ilist.Remove(value);
        }

        void IList.RemoveAt(int index)
        {
            _ilist.RemoveAt(index);
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = value;
            }
        }
        ICollection _icollection { get { return _list as ICollection; } }
        void ICollection.CopyTo(Array array, int index)
        {
            _icollection.CopyTo(array, index);
        }

        int ICollection.Count
        {
            get { return _icollection.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return _icollection.IsSynchronized; }
        }

        object ICollection.SyncRoot
        {
            get { return _icollection.SyncRoot; }
        }
    }
}