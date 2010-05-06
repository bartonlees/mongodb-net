//COPYRIGHT

using MongoDB.Driver.Platform.Util;
using System.Text;
using System;
using MongoDB.Driver.Platform.IO;
using System.IO;
using MongoDB.Driver.Platform.Conversion;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace MongoDB.Driver
{
    /// <summary>
    /// Reads messages and data from the wire protocol
    /// </summary>
    public class WireProtocolReader : EndianBinaryReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WireProtocolReader"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public WireProtocolReader(Stream stream) : base(EndianBitConverter.Little, stream)
        {
        }

        


        TDoc CreateDocument<TDoc>(bool partial) where TDoc : class, IDocument
        {
            TDoc document = Activator.CreateInstance<TDoc>();
            DocumentFactory<TDoc>.CreateDocument(Oid.Empty, partial);
            return document;
        }

        public TDoc ReadDocument<TDoc>(bool partial = false) where TDoc : class, IDocument
        {
            if (!BaseStream.CanRead)
                return default(TDoc);

            TDoc created = CreateDocument<TDoc>(partial);
            IDBObjectCustom custom = created as IDBObjectCustom;
            if (custom != null)
            {
                custom.Read(this);
            }
            else
            {
                int len = ReadInt32();
                while (ReadNextElement<TDoc>(created, partial))
                {
                    // intentionally empty
                }
            }

            return created;
        }

        bool ReadNextElement<TDoc>(IDBObject o, bool partial) where TDoc : class, IDocument
        {
            byte type = ReadByte();

            if (type == Bytes.EOO || !BaseStream.CanRead)
                return false;

            string name = cstring();            

            object created = null;
            IDBObject createdObject = null;

            switch (type)
            {
                case Bytes.NULL:
                    break;
                case Bytes.UNDEFINED:
                    break;
                case Bytes.BOOLEAN:
                    created = ReadByte() != 0;
                    break;
                case Bytes.NUMBER:
                    created = ReadDouble();
                    break;
                case Bytes.NUMBER_INT:
                    created = ReadInt32();
                    break;
                case Bytes.NUMBER_LONG:
                    created = ReadInt64();
                    break;
                case Bytes.SYMBOL:
                    goto case Bytes.STRING;
                case Bytes.STRING:
                    created = data_string();
                    break;
                case Bytes.OID:
                    created = new Oid(ReadBytes(12));
                    break;
                case Bytes.REF:
                    string ns = data_string();
                    Oid oid = new Oid(ReadBytes(12));
                    //if (oid.Equals(Oid.CollectionRefID))
                    //    created = _Database.GetCollection(ns);
                    //else
                    //    created = new DBPointer(o, name, _Database, ns, oid);
                    break;
                case Bytes.DATE:
                    created = new DateTime(ReadInt64());
                    break;
                case Bytes.REGEX:
                    created = new Regex(cstring()); //TODO:Parse options, Bytes.patternFlags(readCStr()));
                    break;
                case Bytes.BINARY:
                    created = data_binary();
                    break;
                case Bytes.CODE:
                    created = new DBCode(data_string());
                    break;
                case Bytes.ARRAY:
                    int size = ReadInt32(); //Size of the array document (in bytes)
                    created = createdObject = new DBObjectArray();

                    while (ReadNextElement<TDoc>(createdObject, partial))
                    {
                        // intentionally empty
                    }
                    break;

                case Bytes.OBJECT:
                    ReadInt32();  // total size - we don't care....

                    createdObject = o.ContainsKey(name) ? o[name] as IDBObject : null; //Check for an existing object

                    created = created ??  createdObject  ?? CreateDocument<TDoc>(partial);

                    while (ReadNextElement<TDoc>((IDBObject)created, partial))
                    {
                        // intentionally empty
                    }

                    //TODO: re-integrate this
                    //IDBObject theObject = (IDBObject)created;
                    //if (theObject.ContainsKey("$ref") &&
                    //     theObject.ContainsKey("$id"))
                    //{
                    //    created = new DBRef(_Database, theObject["$ref"].ToString(), theObject["$id"]);
                    //}

                    break;

                case Bytes.TIMESTAMP:
                    int i = ReadInt32();
                    int time = ReadInt32();

                    created = new DBTimestamp(time, i);
                    break;

                case Bytes.MINKEY:
                    created = "MinKey";
                    break;

                case Bytes.MAXKEY:
                    created = "MaxKey";
                    break;

                default:
                    throw new NotSupportedException("ByteDecoder can't handle type : " + type);
            }

            o[name] = created;
            return true;
        }

        object data_binary()
        {
            int totalLen = ReadInt32();
            byte bType = ReadByte();

            switch ((BinaryType)bType)
            {
                case BinaryType.Binary:
                   return ReadBytes(totalLen);
            }
            return new DBBinary((BinaryType)bType, ReadBytes(totalLen));
        }
        
        public string cstring()
        {
            List<byte> bytes = new List<byte>(50);
            while (true)
            {
                byte b = ReadByte();
                if (b == 0)
                    break;
                bytes.Add(b);
            }
            return this.Encoding.GetString(bytes.ToArray());
        }
        
        public string data_string()
        {
            int size = ReadInt32() - 1;
            byte[] buffer = ReadBytes(size);
            ReadByte(); //Eat null termination
            return this.Encoding.GetString(buffer);
        }
    }

}