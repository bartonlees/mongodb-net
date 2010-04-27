//DEVFUEL COPYRIGHT

using System.Collections.Generic;
using System;
using System.Collections;
using MongoDB.Driver.Platform.Conditions;
namespace MongoDB.Driver
{
    /// <summary>
    /// Utility class to allow array <code>DBObject</code>s to be created. (Completely re-written for C#)
    /// <p>
    /// <blockquote><pre>
    /// DBObject obj = new BasicDBList();
    /// obj["0"] = value1;
    /// obj["4"] = value2;
    /// obj[2] = value3;
    /// </pre></blockquote>
    /// This simulates the array [ value1, null, value3, null, value2 ] by creating the 
    /// <code>DBObject</code> <code>{ "0" : value1, "1" : null, "2" : value3, "3" : null, "4" : value2 }</code>.
    /// </p>
    /// <p>
    /// BasicDBList only supports numeric keys.  Passing strings that cannot be converted to ints will cause an
    /// ArgumentException.
    /// <blockquote><pre>
    /// BasicDBList list = new BasicDBList();
    /// list["1"] ="bar"; // ok
    /// list["1E1"] ="bar"; // throws exception
    /// </pre></blockquote>
    /// </p>
    /// </summary>
    public class DBObjectArray : IList, IList<object>, IDBObject
    {
        List<object> _list = null;
        public DBObjectArray()
        {
            _list = new List<object>();
        }

        public DBObjectArray(int capacity)
        {
            _list = new List<object>(capacity);
        }

        public DBObjectArray(IDictionary<string, object> map)
        {
            Condition.Requires(map, "map").IsNotNull();
            _list = new List<object>(map.Count);
            PutAll(map);
        }

        public DBObjectArray(IList list)
        {
            Condition.Requires(list, "list").IsNotNull();
            _list = new List<object>(list.Count);
            foreach (object o in list)
            {
                (_list as IList).Add(o);
            }
        }

        public DBObjectArray(IList<object> list)
        {
            _list = new List<object>(list);
        }

        public void PutAll(IDictionary<string, object> map)
        {
            foreach (string key in map.Keys)
            {
                _list[int.Parse(key)] = map[key];
            }
        }

        public bool PartialObject { get; set; }
        public Oid ID { get; set; }

        public void Add(string key, object value)
        {
            this[key] = value;
        }

        public bool ContainsKey(string key)
        {
            int index = int.Parse(key);
            return index < _list.Count && index >= 0;
        }

        public ICollection<string> Keys
        {
            get 
            { 
                int i = 0;
                return _list.ConvertAll(o => (i++).ToString());
            }
        }

        public bool Remove(string key)
        {
            _list.RemoveAt(int.Parse(key));
            return true;
        }

        public bool TryGetValue(string key, out object value)
        {
            value = null;
            int index = 0;
            if (!int.TryParse(key, out index) || index < 0 || index >= Count)
                return false;
            value = _list[index];
            return true;
        }

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
                    throw new ArgumentException("Cannot parse integer index","key");
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

        public void Add(KeyValuePair<string, object> item)
        {
            this[item.Key] = item.Value;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return ContainsKey(item.Key);
        }

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

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return Remove(item.Key);
        }

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

        public int IndexOf(object item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, object item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public void Add(object item)
        {
            _list.Add(item);
        }

        public bool Contains(object item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

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
                return _ilist[index];
            }
            set
            {
                _ilist[index] = value;
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

        public DocumentState State
        {
            get;
            private set;
        }
    }
}