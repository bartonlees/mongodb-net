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
    /// <remarks>
    /// <example caption="Expanding to indexes">
    /// <code><![CDATA[ 
    /// DBObjectArray obj = new DBObjectArray();
    /// obj["0"] = value1;
    /// obj["4"] = value2;
    /// obj[2] = value3;
    /// ]]></code>
    /// </example>
    /// <example caption="Invalid indexes">
    /// <code><![CDATA[ 
    /// BasicDBList list = new BasicDBList();
    /// list["1"] ="bar"; // ok
    /// list["1E1"] ="bar"; // throws exception
    /// ]]></code>
    /// </remarks>
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
        /// Puts all the pairs in the dictionary into this array
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
        /// Adds the specified pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, object value)
        {
            this[key] = value;
        }

        /// <summary>
        /// Determines whether this array contains the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if this array contains the specified key; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey(string key)
        {
            int index = int.Parse(key);
            return index < _list.Count && index >= 0;
        }

        /// <summary>
        /// Gets the keys for this collection (which should be integers as strings).
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
        /// Removes the pair identified by the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            _list.RemoveAt(int.Parse(key));
            return true;
        }

        /// <summary>
        /// Tries to get the value associated with the specified key
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the value was found; <c>false</c> otherwise.</returns>
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
        /// Gets all the values in the collection
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
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <remarks>
        ///  Setting with an index greater than the capacity will cause an error. Otherwise the list will resize (filling with null entries) to accommodate.</remarks>
        /// <value>The associated value</value>
        /// <exception cref="System.ArgumentException"/>
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
        /// Gets or sets the value associated with the specified index.
        /// </summary>
        /// <remarks>
        ///  Setting with an index greater than the capacity will cause an error. Otherwise the list will resize (filling with null entries) to accommodate.</remarks>
        /// <value>The associated value</value>
        /// <exception cref="System.ArgumentException"/>
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
        /// Adds the specified pair.
        /// </summary>
        /// <param name="pair">The item.</param>
        public void Add(KeyValuePair<string, object> pair)
        {
            this[pair.Key] = pair.Value;
        }

        /// <summary>
        /// Removes all items from this collection.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only. </exception>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Determines whether this collection contains the specified pair
        /// </summary>
        /// <param name="pair">The pair.</param>
        /// <returns>
        /// 	<c>true</c> if this collection contains the pair; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(KeyValuePair<string, object> pair)
        {
            return ContainsKey(pair.Key) && this[pair.Key].Equals(pair.Value);
        }

        /// <summary>
        /// Copies this collection's pairs to the specified array at the specified index
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
        /// Removes the specified pair.
        /// </summary>
        /// <param name="pair">The pair to remove.</param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<string, object> pair)
        {
            return Remove(pair.Key);
        }

        /// <summary>
        /// Gets a pair enumerator.
        /// </summary>
        /// <returns>the enumerator</returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            if (Count == 0)
                return new List<KeyValuePair<string, object>>().GetEnumerator();
            KeyValuePair<string, object>[] entryArray = new KeyValuePair<string, object>[Count];
            CopyTo(entryArray, 0);
            List<KeyValuePair<string, object>> entries = new List<KeyValuePair<string, object>>(entryArray);
            return entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Finds the index of the specified value
        /// </summary>
        /// <param name="value">The value in the collection.</param>
        /// <returns></returns>
        public int IndexOf(object value)
        {
            return _list.IndexOf(value);
        }

        /// <summary>
        /// Inserts the specified item at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        public void Insert(int index, object value)
        {
            _list.Insert(index, value);
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
        /// Adds the specified value to the end of the collection.
        /// </summary>
        /// <param name="value">The item.</param>
        public void Add(object value)
        {
            _list.Add(value);
        }

        /// <summary>
        /// Determines whether this collection contains the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if this collection contains the specified value; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(object value)
        {
            return _list.Contains(value);
        }

        /// <summary>
        /// Copies this collection's values to the array at the specified index
        /// </summary>
        /// <param name="array">the array.</param>
        /// <param name="arrayIndex">the index.</param>
        public void CopyTo(object[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the value was found and removed; <c>false</c> otherwise.</returns>
        public bool Remove(object value)
        {
            return _list.Remove(value);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>the enumerator</returns>
        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        private IList _ilist { get { return _list as IList; } }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The object to add to the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection,
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        int IList.Add(object value)
        {
            return _ilist.Add(value);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only. </exception>
        void IList.Clear()
        {
            _ilist.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// true if the <see cref="T:System.Object"/> is found in the <see cref="T:System.Collections.IList"/>; otherwise, false.
        /// </returns>
        bool IList.Contains(object value)
        {
            return _ilist.Contains(value);
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The index of <paramref name="value"/> if found in the list; otherwise, -1.
        /// </returns>
        int IList.IndexOf(object value)
        {
            return _ilist.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.IList"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">The object to insert into the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        /// <exception cref="T:System.NullReferenceException">
        /// 	<paramref name="value"/> is null reference in the <see cref="T:System.Collections.IList"/>.</exception>
        void IList.Insert(int index, object value)
        {
            _ilist.Insert(index, value);
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, false.</returns>
        bool IList.IsFixedSize
        {
            get { return _ilist.IsFixedSize; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> is read-only; otherwise, false.</returns>
        bool IList.IsReadOnly
        {
            get { return _ilist.IsReadOnly; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The object to remove from the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        void IList.Remove(object value)
        {
            _ilist.Remove(value);
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.IList"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        void IList.RemoveAt(int index)
        {
            _ilist.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> at the specified index.
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="array"/> is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is less than zero. </exception>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="array"/> is multidimensional.-or- The number of elements in the source <see cref="T:System.Collections.ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>. </exception>
        /// <exception cref="T:System.ArgumentException">The type of the source <see cref="T:System.Collections.ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/>. </exception>
        void ICollection.CopyTo(Array array, int index)
        {
            _icollection.CopyTo(array, index);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection"/>.</returns>
        int ICollection.Count
        {
            get { return _icollection.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.</returns>
        bool ICollection.IsSynchronized
        {
            get { return _icollection.IsSynchronized; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.</returns>
        object ICollection.SyncRoot
        {
            get { return _icollection.SyncRoot; }
        }
    }
}