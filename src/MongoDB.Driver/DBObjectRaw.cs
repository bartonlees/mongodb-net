//COPYRIGHT

using MongoDB.Driver.Platform.Util;
using System.Diagnostics;
using System;
using MongoDB.Driver.Platform.IO;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text;
namespace MongoDB.Driver
{

    /// <summary>
    /// This object wraps the binary object format ("BSON") used for the transport of serialized objects 
    /// to / from the Mongo database.
    /// http://www.mongodb.org/display/DOCS/BSON
    /// </summary>
    public class DBObjectRaw : IDBObject, IEnumerable<MongoDB.Driver.DBObjectRaw.Element>, IDisposable
    {

        WireProtocolReader _buf;
        public DBObjectRaw(Stream buf)
            : this(buf, 0)
        {
            
            Debug.Assert(_end == _buf.BaseStream.Length);
        }

        public DBObjectRaw(Stream buf, int offset)
        {
            _buf = new WireProtocolReader(buf);
            _offset = offset;
            _buf.Seek(offset, SeekOrigin.Begin);
            _end = _buf.ReadInt32();
        }

        private IEnumerable<MongoDB.Driver.DBObjectRaw.Element> _ElementEnumerable { get { return this as IEnumerable<MongoDB.Driver.DBObjectRaw.Element>; }}

        public void PutAll(IDictionary<string, object> m)
        {
            throw new NotSupportedException("read only");
        }

        public override string ToString()
        {
            return new DBObject(this).ToString();
        }

        internal class Element
        {
            WireProtocolReader _buf;
            public Element(WireProtocolReader buf, int start)
            {
                _buf = buf;
                _start = start;
                _buf.Seek(start, SeekOrigin.Begin);
                _type = _buf.ReadByte();
                int end = start+1;
                _name = eoo() ? "" : _buf.cstring();
                	    
                int size = 1 + ( end - _start); // 1 for the end of the string
                _dataStart = _start + size;
                _buf.Seek(_dataStart, SeekOrigin.Begin);
                switch ( _type )
                {
                    case Bytes.MAXKEY:
                    case Bytes.MINKEY:
                    case Bytes.EOO:
                    case Bytes.UNDEFINED:
                    case Bytes.NULL:
                        break;
                    case Bytes.BOOLEAN:
                        size += 1;
                        break;
                    case Bytes.DATE:
                    case Bytes.NUMBER:
                    case Bytes.NUMBER_LONG:
                        size += 8;
                        break;
    	            case Bytes.NUMBER_INT:
    		            size += 4;
    		            break;
                    case Bytes.OID:
                        size += 12;
                        break;
                    case Bytes.REF:
                        size += 12;
                        goto case Bytes.STRING;
                    case Bytes.SYMBOL:
                    case Bytes.CODE:
                    case Bytes.STRING:
                        size += 4 + _buf.ReadInt32();
                        break;
                    case Bytes.CODE_W_SCOPE:
                    case Bytes.ARRAY:
                    case Bytes.OBJECT:
                		size += _buf.ReadInt32();
                		break;
                    case Bytes.BINARY:
                        size += 4 + _buf.ReadInt32() + 1;
                        break;
                    case Bytes.REGEX:
                        throw new Exception("RawDBObject can't deal with regex yet ");
                        //int first = _buf.ReadInt32();
                        //_buf.Seek(first, SeekOrigin.Current);
                        //int second = first;
                        //string s = _buf.cstring( out second );
                        //size += first + second;
                        //break;
                    case Bytes.TIMESTAMP:
                        size += 8;
                        break;
                    default:
                        throw new Exception( "RawDBObject can't size type " + _type );
                }
                _size = size;
            }


            public bool eoo()
            {
                return _type == Bytes.EOO || _type == Bytes.MAXKEY;
            }

            internal object getObject()
            {

                if (_cached != null)
                    return _cached;
                _buf.Seek(_dataStart, SeekOrigin.Begin);
                switch (_type)
                {
                    case Bytes.NUMBER:
                        return _buf.ReadDouble();
                    case Bytes.NUMBER_INT:
                        return _buf.ReadInt32();
                    case Bytes.OID:
                        return new Oid(_buf.ReadBytes(12));
                    case Bytes.CODE:
                    case Bytes.CODE_W_SCOPE:
                        throw new Exception("can't handle code");
                    case Bytes.SYMBOL:
                    case Bytes.STRING:
                        return _buf.data_string();
                    case Bytes.DATE:
                        return new DateTime(_buf.ReadInt64());
                    case Bytes.REGEX:
                        //int[] endPos = new int[1];
                        //string first = _readCStr( _dataStart , endPos );
                        //return new JSRegex( first , _readCStr( 1 + endPos[0] ) );
                        throw new Exception("can't handle regex");
                    case Bytes.BINARY:
                        throw new Exception("can't inspect binary in db");
                    case Bytes.BOOLEAN:
                        return _buf.ReadByte() > 0;
                    case Bytes.ARRAY:
                    case Bytes.OBJECT:
                        throw new Exception("can't handle embedded objects");
                    case Bytes.NULL:
                    case Bytes.EOO:
                    case Bytes.MAXKEY:
                    case Bytes.MINKEY:
                    case Bytes.UNDEFINED:
                        return null;
                }
                throw new Exception("can't decode type " + _type);
            }

            public int _start { get; private set; }
            public byte _type { get; private set; }
            public string _name { get; private set; }
            public int _dataStart { get; private set; }
            public int _size { get; private set; }

            public object _cached { get; private set; }
        }

        class ElementEnumerator : IEnumerator<Element>, IEnumerator
        {
            int _offset = 0;
            WireProtocolReader _buf = null;
            public ElementEnumerator(DBObjectRaw dbo)
            {
                _offset = dbo._offset;
                _buf = dbo._buf;
                Reset();
            }

            int _pos;

            public Element Current
            {
                get;
                private set;
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                Current = new Element(_buf, _pos);
                _pos += Current._size;
                return !Current.eoo() && _pos < _buf.BaseStream.Length;
            }

            public void Reset()
            {
                _pos = _offset + 4;
                Current = null;
            }

            bool IEnumerator.MoveNext()
            {
                return MoveNext();
            }

            void IEnumerator.Reset()
            {
                Reset();
            }
        }

        int _offset;
        int _end;


        public Oid ID
        {
            get
            {
                return (Oid)this["_id"];
            }
            set
            {
                this["_id"] = value;
            }
        }

        public void Add(string key, object value)
        {
            throw new NotSupportedException();
        }

        public bool ContainsKey(string key)
        {
            return Keys.Contains(key);
        }

        public ICollection<string> Keys
        {
            get
            {
                HashSet<string> keys = new HashSet<string>();
                foreach (Element element in _ElementEnumerable)
                {
                    keys.Add(element._name);
                }    
                return keys;
            }
        }

        public bool Remove(string key)
        {
            throw new NotSupportedException();
        }

        public bool TryGetValue(string key, out object value)
        {
            foreach (Element element in _ElementEnumerable)
            {
                if (element._name == key)
                {
                    value = element.getObject();
                    return true;
                }
            }
            value = null;
            return false;
        }

        public ICollection<object> Values
        {
            get
            {
                List<object> values = new List<object>();
                foreach (Element element in _ElementEnumerable)
                {
                    values.Add(element.getObject());
                }
                return values;
            }
        }

        public object this[string key]
        {
            get
            {
                foreach (Element element in _ElementEnumerable)
                {
                    if (element._name == key)
                        return element.getObject();                    
                }
                throw new KeyNotFoundException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public void Add(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
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
            foreach (Element element in _ElementEnumerable)
            {
                array[arrayIndex++] = new KeyValuePair<string, object>(element._name, element.getObject());
            }
        }

        public int Count
        {
            get 
            {  
                int count = 0;
                foreach (Element element in _ElementEnumerable) 
                {
                    count++;
                }
                return count;
            }
        }

        public bool IsReadOnly
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
    
        IEnumerator<DBObjectRaw.Element>  IEnumerable<DBObjectRaw.Element>.GetEnumerator()
        {
         	return new ElementEnumerator(this);
        }


        public bool PartialObject
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public void Dispose()
        {
            _buf.Dispose();
        }


        public DocumentState State
        {
            get { return DocumentState.Added | DocumentState.Unchanged; }
        }
    }
}