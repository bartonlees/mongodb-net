//COPYRIGHT

using System.Collections.Generic;
using MongoDB.Driver.Platform.Util;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using MongoDB.Driver.Platform.IO;
using System.IO;
using Writer = MongoDB.Driver.Platform.IO.EndianBinaryWriter;
using System.Diagnostics;
using MongoDB.Driver.Platform.Conversion;
using MongoDB.Driver.Platform.Conditions;
namespace MongoDB.Driver
{

    /// <summary>
    /// Serializes a <code>DBObject</code> into a string that can be sent to the database.
    /// </summary>
    public class WireProtocolWriter : EndianBinaryWriter
    {
        //TODO:Ensure WireProtocolWriter correctly implements IDisposable
        // things that won't get sent in the scope
        static HashSet<string> BAD_GLOBALS = new HashSet<string>() { "db", "local", "core", "args", "obj" };
        static HashSet<string> DBONLY_FIELDS = new HashSet<string>() { "_ns", "_save", "_update", "_transientFields"};

        public WireProtocolWriter(Stream stream) : base(EndianBitConverter.Little, stream)
        {
        }

        /** Encodes a <code>DBObject</code>.
         * This is for the higher level api calls
         * @param o the object to encode
         * @return the number of characters in the encoding
         */
        public void Write(IDBObject o)
        {
            element_object(null, o);
        }

        void element_object(string name, IDBObject obj)
        {
            Condition.Requires(obj, "obj").IsNotNull();

            if (_handleSpecialObjects(name, obj))
                return;

            if (!string.IsNullOrWhiteSpace(name))
            {
                element_type(Bytes.OBJECT);
                element_name(name);
            }

            long sizePos = BaseStream.Position;
            Write(0); //Dummy object size, will overwrite later
            //write the _id first
            if (obj.HasID())
            {
                element("_id", obj.GetID());
            }
            IList<string> transientFields = obj.GetAs<IList<string>>("_transientFields");

            foreach (string key in obj.Keys)
            {
                if (key.Equals("_id"))
                    continue;

                if (transientFields != null && transientFields.Contains(key))
                    continue;

                object val = obj[key];
                element(key, val);
            }
            Write(Bytes.EOO);
            //Go back and overwrite the dummy length
            RewindAndWriteSize(sizePos);
        }

        void element_array(string name, IList list)
        {
            Condition.Requires(list, "list").IsNotNull();

            if (!string.IsNullOrWhiteSpace(name))
            {
                element_type(Bytes.ARRAY);
                element_name(name);
            }

            long sizePos = BaseStream.Position;
            Write(0); //Dummy object size, will overwrite later
            int i = 0;
            foreach (object item in list)
            {
                element(i.ToString(), item);
                i++;
            }
            Write(Bytes.EOO);
            //Go back and overwrite the dummy length
            RewindAndWriteSize(sizePos);
        }

        private void RewindAndWriteSize(long sizePos)
        {
            long currentPosition = BaseStream.Position;
            long size = currentPosition - sizePos;
            Seek(sizePos, SeekOrigin.Begin);
            Write(Convert.ToInt32(size));
            Seek(currentPosition, SeekOrigin.Begin);
        }

        void element(string name, object val)
        {
            if (DBONLY_FIELDS.Contains(name))
                return;

            if (name.Equals("$where") && val is string)
                element_code(name, val.ToString());
            else if (val == null)
                element_null(name);
            else if (val is DateTime)
                element_date(name, (DateTime)val);
            else if (val is int)
                element_int(name, (int)val);
            else if (val is long)
                element_long(name, (long)val);
            else if (val is double)
                element_number(name, (double)val);
            else if (val is float)
                element_number(name, (float)val);
            else if (val is string)
                element_string(name, val.ToString());
            else if (val is Oid)
                element_oid(name, (Oid)val);
            else if (val is IDBObject)
                element_object(name, (IDBObject)val);
            else if (val is bool)
                element_boolean(name, (bool)val);
            else if (val is Regex)
                element_regex(name, (Regex)val);
            else if (val is DBRegex)
                element_regex(name, (DBRegex)val);
            else if (val is IDictionary)
                element_object(name, (IDictionary)val);
            else if (val is byte[])
                element_binary(name, (byte[])val);
            else if (val is IList)
                element_array(name, val as IList);
            else if (val is DBBinary)
                element_binary(name, (DBBinary)val);
            else if (val is DBRef)
                element_object(name, (DBRef)val);
            else if (val is DBSymbol)
                element_symbol(name, (DBSymbol)val);
            else if (val is DBUndefined)
                element_undefined(name);
            else if (val is DBTimestamp)
                element_timestamp(name, (DBTimestamp)val);
            else
                throw new ArgumentException("can't serialize " + val.GetType());

        }

        void element_code(string name, string code)
        {
            element_type(Bytes.CODE);
            WriteNullTerminated(name);
            WriteLengthPrefixedNullTerminated(code);
            return;
        }

        void element_object(string name, IDictionary dictionary)
        {
            element_type(Bytes.OBJECT);
            element_name(name);
            long sizePos = BaseStream.Position;
            Write(0);
            foreach (object key in dictionary.Keys)
            {
                element(Convert.ToString(key), dictionary[key]);
            }
            Write(Bytes.EOO);
            RewindAndWriteSize(sizePos);
        }

        private bool _handleSpecialObjects(string name, IDBObject o)
        {
            if (o == null)
                return false;

            if (o is IDBCollection)
            {
                IDBCollection c = (IDBCollection)o;
                element_ref(name, c.Uri.GetCollectionName(), Oid.CollectionRefID);
                return true;
            }

            if ((o as IList) == null && o.ContainsKey(Bytes.NO_REF_HACK))
            {
                o.Remove(Bytes.NO_REF_HACK);
                return false;
            }

            if (!_dontRefContains(o) &&
             name != null &&
                 !(o is IList) &&
                 Bytes.CameFromDB(o))
            {
                element_ref(name, o["_ns"].ToString(), o.GetOid());
                return true;
            }

            return false;
        }

        void element_null(string name)
        {
            element_type(Bytes.NULL);
            element_name(name);
        }

        void element_undefined(string name)
        {
            element_type(Bytes.UNDEFINED);
            element_name(name);
        }

        void element_timestamp(string name, DBTimestamp ts)
        {
            element_type(Bytes.TIMESTAMP);
            element_name(name);
            Write(ts.Time);
            Write(ts.Inc);
        }

        void element_boolean(string name, bool b)
        {
            element_type(Bytes.BOOLEAN);
            element_name(name);
            Write(b ? (byte)0x1 : (byte)0x0);
        }

        void element_date(string name, DateTime d)
        {
            element_type(Bytes.DATE);
            element_name(name);
            Write(d.Ticks);
        }

        void element_int(string name, int value)
        {
            element_type(Bytes.NUMBER_INT);
            element_name(name);
            Write(value);
        }

        void element_long(string name, long value)
        {
            element_type(Bytes.NUMBER_LONG);
            element_name(name);
            Write(value);
        }

        void element_number(string name, double value)
        {
            element_type(Bytes.NUMBER);
            element_name(name);
            Write(value);
        }

        void element_number(string name, float value)
        {
            element_number(name, Convert.ToDouble(value));
        }

        void element_binary(string name, byte[] data)
        {
            element_type(Bytes.BINARY);
            element_name(name);
            Write(data.Length);
            base.Write((byte)BinaryType.Binary);
            base.Write(data);
        }

        void element_binary(string name, DBBinary val)
        {
            element_type(Bytes.BINARY);
            element_name(name);
            base.Write(val.Buffer.Length);
            base.Write((byte)val.Type);
            base.Write(val.Buffer);
        }

        void element_symbol(string name, DBSymbol s)
        {
            element_type(Bytes.SYMBOL);
            element_name(name);
            WriteLengthPrefixedNullTerminated(s.Symbol);  
        }

        void element_string(string name, string s)
        {
            element_type(Bytes.STRING);
            element_name(name);
            WriteLengthPrefixedNullTerminated(s);  
        }

        void element_oid(string name, Oid oid)
        {
            element_type(Bytes.OID);
            element_name(name);
            base.Write(oid.Buffer);
        }

        void element_ref(string name, string ns, Oid oid)
        {
            element_type(Bytes.REF);
            element_name(name);
            WriteLengthPrefixedNullTerminated(ns);
            base.Write(oid.Buffer);
        }

        void element_object(string name, DBRef reference)
        {
            element_type(Bytes.OBJECT);
            element_name(name);
            long sizePos = BaseStream.Position;
            Write(0);

            element_string("$ref", reference.Collection.Name);
            element("$id", reference.ID);

            Write(Bytes.EOO);
            RewindAndWriteSize(sizePos);
        }

        void element_regex(string name, DBRegex regex)
        {
            element_type(Bytes.REGEX);
            element_name(name);
            WriteNullTerminated(regex.getPattern());

            string options = regex.getOptions();

            Dictionary<char, char> sm = new Dictionary<char, char>();

            for (int i = 0; i < options.Length; i++)
            {
                sm[options[i]] = options[i];
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in sm.Keys)
            {
                sb.Append(c);
            }

            WriteNullTerminated(sb.ToString());
        }

        void element_regex(string name, Regex p)
        {
            //TODO: handle Regex
            //int start = BaseStream.Position;
            //_put( REGEX , name );
            //_put( p.ToString() );
            throw new NotImplementedException();
            //_put( patternFlags( p.Options) );
            //return BaseStream.Position - start;
        }

        /// <summary>
        /// Writes the element_type of the BSON Grammar
        /// </summary>
        /// <param name="type">The type.</param>
        void element_type(byte type)
        {
            Write(type);
        }

        /// <summary>
        ///  Writes the element_type of the BSON Grammar
        /// </summary>
        /// <param name="name">The name.</param>
        void element_name(string name)
        {
            WriteNullTerminated(name);
        }

        bool _dontRefContains(object o)
        {
            if (_dontRef.Count == 0)
                return false;
            return _dontRef.Peek().Contains(o.GetHashCode());
        }

        private Stack<HashSet<int>> _dontRef = new Stack<HashSet<int>>();
    }
}