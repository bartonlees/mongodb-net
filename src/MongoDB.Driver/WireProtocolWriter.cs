//COPYRIGHT
#pragma warning disable 0618
#pragma warning disable 0612
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MongoDB.Driver.Conditions;
using MongoDB.Driver.Conversion;
using MongoDB.Driver.IO;
namespace MongoDB.Driver
{

    /// <summary>
    /// Serializes messages via the MongoDB wire protocol
    /// </summary>
    public class WireProtocolWriter : EndianBinaryWriter
    {
        //TODO:Ensure WireProtocolWriter correctly implements IDisposable
        // things that won't get sent in the scope
        static HashSet<string> BAD_GLOBALS = new HashSet<string>() { "db", "local", "core", "args", "obj" };
        static HashSet<string> DBONLY_FIELDS = new HashSet<string>() { "_ns", "_save", "_update", "_transientFields" };

        /// <summary>
        /// Initializes a new instance of the <see cref="WireProtocolWriter"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public WireProtocolWriter(Stream stream)
            : base(EndianBitConverter.Little, stream)
        {
        }

        /// <summary>
        /// Writes the specified object.
        /// </summary>
        /// <param name="o">the object to encode</param>
        public void Write(IDBObject o)
        {
            element_object(null, o);
        }

        void element_object(string name, IDBObject obj)
        {
            Condition.Requires(obj, "obj").IsNotNull();

            IDBObjectCustom custom = obj as IDBObjectCustom;
            if (custom != null)
            {
                custom.Write(this);
                return;
            }

            if (_handleSpecialObjects(name, obj))
                return;

            if (!string.IsNullOrWhiteSpace(name))
            {
                element_type(TypeByte.OBJECT);
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
            Write((byte)TypeByte.EOO);
            //Go back and overwrite the dummy length
            RewindAndWriteSize(sizePos);
        }

        void element_array(string name, IList list)
        {
            Condition.Requires(list, "list").IsNotNull();

            if (!string.IsNullOrWhiteSpace(name))
            {
                element_type(TypeByte.ARRAY);
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
            Write((byte)TypeByte.EOO);
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
            else if (val is DBCode)
                element_code(name, (DBCode)val);
            else if (val is DBUndefined)
                element_undefined(name);
            else if (val is DBTimestamp)
                element_timestamp(name, (DBTimestamp)val);
            else
                throw new ArgumentException("can't serialize " + val.GetType());

        }

        void element_code(string name, string code)
        {
            element_type(TypeByte.CODE);
            WriteNullTerminated(name);
            WriteLengthPrefixedNullTerminated(code);
        }

        void element_code(string name, DBCode code)
        {
            element_code(name, code.Code);
        }

        void element_object(string name, IDictionary dictionary)
        {
            element_type(TypeByte.OBJECT);
            element_name(name);
            long sizePos = BaseStream.Position;
            Write(0);
            foreach (object key in dictionary.Keys)
            {
                element(Convert.ToString(key), dictionary[key]);
            }
            Write((byte)TypeByte.EOO);
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

            if ((o as IList) == null && o.ContainsKey(Constants.NO_REF_HACK))
            {
                o.Remove(Constants.NO_REF_HACK);
                return false;
            }

            if (!_dontRefContains(o) &&
             name != null &&
                 !(o is IList) &&
                 o.CameFromDB())
            {
                element_ref(name, o["_ns"].ToString(), o.GetOid());
                return true;
            }

            return false;
        }

        void element_null(string name)
        {
            element_type(TypeByte.NULL);
            element_name(name);
        }

        void element_undefined(string name)
        {
            element_type(TypeByte.UNDEFINED);
            element_name(name);
        }

        void element_timestamp(string name, DBTimestamp ts)
        {
            element_type(TypeByte.TIMESTAMP);
            element_name(name);
            Write(ts.Time);
            Write(ts.Inc);
        }

        void element_boolean(string name, bool b)
        {
            element_type(TypeByte.BOOLEAN);
            element_name(name);
            Write(b ? (byte)0x1 : (byte)0x0);
        }

        void element_date(string name, DateTime d)
        {
            element_type(TypeByte.DATE);
            element_name(name);
            Write(d.Ticks);
        }

        void element_int(string name, int value)
        {
            element_type(TypeByte.NUMBER_INT);
            element_name(name);
            Write(value);
        }

        void element_long(string name, long value)
        {
            element_type(TypeByte.NUMBER_LONG);
            element_name(name);
            Write(value);
        }

        void element_number(string name, double value)
        {
            element_type(TypeByte.NUMBER);
            element_name(name);
            Write(value);
        }

        void element_number(string name, float value)
        {
            element_number(name, Convert.ToDouble(value));
        }

        void element_binary(string name, byte[] data)
        {
            element_type(TypeByte.BINARY);
            element_name(name);
            Write(data.Length);
            base.Write((byte)BinaryType.Binary);
            base.Write(data);
        }

        void element_binary(string name, DBBinary val)
        {
            element_type(TypeByte.BINARY);
            element_name(name);
            base.Write(val.Buffer.Length);
            base.Write((byte)val.Type);
            base.Write(val.Buffer);
        }

        void element_symbol(string name, DBSymbol s)
        {
            element_type(TypeByte.SYMBOL);
            element_name(name);
            WriteLengthPrefixedNullTerminated(s.Symbol);
        }

        void element_string(string name, string s)
        {
            element_type(TypeByte.STRING);
            element_name(name);
            WriteLengthPrefixedNullTerminated(s);
        }

        void element_oid(string name, Oid oid)
        {
            element_type(TypeByte.OID);
            element_name(name);
            base.Write(oid.Buffer);
        }

        void element_ref(string name, string ns, Oid oid)
        {
            element_type(TypeByte.REF);
            element_name(name);
            WriteLengthPrefixedNullTerminated(ns);
            base.Write(oid.Buffer);
        }

        void element_object(string name, DBRef reference)
        {
            element_type(TypeByte.OBJECT);
            element_name(name);
            long sizePos = BaseStream.Position;
            Write(0);

            element_string("$ref", reference.Collection.Name);
            element("$id", reference.ID);

            Write((byte)TypeByte.EOO);
            RewindAndWriteSize(sizePos);
        }

        void element_regex(string name, Regex p)
        {
            element_type(TypeByte.REGEX);
            element_name(name);
            WriteNullTerminated(p.ToString());

            //FROM bsonspec.org:
            //Regular expression - The first cstring is the regex pattern, the second is the regex
            //options string. Options are identified by characters, which must be stored in alphabetical 
            //order. Valid options are 'i' for case insensitive matching, 'm' for multiline matching,
            //'x' for verbose mode, 'l' to make \w, \W, etc. locale dependent, 's' for dotall mode 
            //('.' matches everything), and 'u' to make \w, \W, etc. match unicode.

            List<char> optionCodes = new List<char>();
            if ((p.Options & RegexOptions.IgnoreCase) != RegexOptions.None)
                optionCodes.Add('i');
            if ((p.Options & RegexOptions.Multiline) != RegexOptions.None)
                optionCodes.Add('m');
            
            WriteNullTerminated(new string(optionCodes.ToArray()));
        }

        /// <summary>
        /// Writes the element_type of the BSON Grammar
        /// </summary>
        /// <param name="type">The type.</param>
        void element_type(TypeByte type)
        {
            Write((byte)type);
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