//COPYRIGHT


using System;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

namespace MongoDB.Driver
{

    /// <summary>
    /// A globally unique identifier for objects. 
    /// Consists of 12 bytes
    /// </summary>
    [Serializable]
    public class Oid : IFormattable, IComparable, IComparable<Oid>, IEquatable<Oid>, ISerializable
    {
        public byte[] Buffer { get; private set;}
        public Oid(Oid from)
        {
            Buffer = null;
            FromByteArray(from.Buffer);
        }

        public Oid()
        {
            Buffer = null;
            FromByteArray(Empty.Buffer);
        }

        public Oid(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : this(serializationInfo.GetString("value"))
        {

        }

        public Oid(string value)
        {
            Buffer = null;
            FromHexadecimalString(value);
        }

        public Oid(string value, string format)
        {
            Buffer = null;
            switch (format)
            {
                case "m":
                    if (value.EndsWith("\")") && value.StartsWith("ObjectId(\""))
                    {
                        FromHexadecimalString(value.Substring(10, value.Length - 12));
                    }
                    else
                        throw new ArgumentException("Expected form of Oid(\"ABCDABCDABCDABCD\")", "value");
                    break;
                case "h":
                    FromHexadecimalString(value);
                    break;
                case "b":
                    byte[] buffer = Convert.FromBase64String(value);
                    try
                    {
                        FromByteArray(buffer);
                    }
                    catch (Exception x)
                    {
                        throw new ArgumentException("Base 64 string is not valid", "value", x);
                    }
                    break;
                default:
                    throw new ArgumentException("format", "unsupported format");
            }
        }

        public Oid(byte[] buffer)
        {
            this.Buffer = null;
            FromByteArray(buffer);
        }

        public override bool Equals(object obj)
        {
            return CompareTo(obj) == 0;
        }

        public override string ToString()
        {
            return ToHexadecimalString();
        }
        
        public string ToHexadecimalString()
        {
            if (Buffer == null)
                return string.Empty;
            return BitConverter.ToString(Buffer).Replace("-", "").ToLower();
        }

        public string ToBase64String()
        {
            if (Buffer == null)
                return string.Empty;
            return Convert.ToBase64String(Buffer);
        }

        public string ToMongoDBString()
        {
            return string.Format("ObjectId(\"{0}\")", ToHexadecimalString());
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "m":
                    return ToMongoDBString();
                case "h":
                    return ToHexadecimalString();
                case "b":
                    return ToBase64String();
                default:
                    return ToHexadecimalString();
            }   
        }

        //http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
        public override int GetHashCode()
        {
            if (Buffer != null)
            {
                int hash = 17;
                hash = hash * 23 + Buffer[0].GetHashCode();
                hash = hash * 23 + Buffer[1].GetHashCode();
                hash = hash * 23 + Buffer[2].GetHashCode();
                hash = hash * 23 + Buffer[3].GetHashCode();
                hash = hash * 23 + Buffer[4].GetHashCode();
                hash = hash * 23 + Buffer[5].GetHashCode();
                hash = hash * 23 + Buffer[6].GetHashCode();
                hash = hash * 23 + Buffer[7].GetHashCode();
                hash = hash * 23 + Buffer[8].GetHashCode();
                hash = hash * 23 + Buffer[9].GetHashCode();
                hash = hash * 23 + Buffer[10].GetHashCode();
                hash = hash * 23 + Buffer[11].GetHashCode();
                return hash;
            }
            return 0;
        }

        void FromByteArray(byte[] buffer)
        {
            if (buffer == null)
            {
                Buffer = null;
            }
            else
            {
                if (buffer.Length != 12)
                {
                    throw new ArgumentException("buffer", "buffer should either be null or have 12 bytes");
                }

                if (Buffer == null)
                {
                    Buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                   
                }
                buffer.CopyTo(Buffer, 0);
            }
        }


        void FromHexadecimalString(string val)
        {
            if (string.IsNullOrWhiteSpace(val)) //Empty Oid
            {
                Buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                return;
            }
            if (val.Length != 24) 
                throw new ArgumentException(string.Format("Oid strings should be 24 characters, got {0} : \"{1}\"", val.Length, val));

            Regex notHexChars = new Regex(@"[^A-Fa-f0-9]", RegexOptions.None);
            if (notHexChars.IsMatch(val))
            {
                throw new ArgumentOutOfRangeException("val", "Value contains invalid characters");
            }

            int numberChars = val.Length;

            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                try
                {
                    bytes[i / 2] = Convert.ToByte(val.Substring(i, 2), 16);
                }
                catch
                {
                    //failed to convert these 2 chars, they may contain illegal charracters
                    bytes[i / 2] = 0;
                }
            }

            if (Buffer == null)
                Buffer = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bytes.CopyTo(Buffer, 0);
        }

        public static readonly Oid Empty = new Oid(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        public static readonly Oid CollectionRefID = new Oid(new byte[]{255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 });

        static Generator _Generator = new Generator();

        public static implicit operator string(Oid oid)
        {
            return oid.ToString();
        }
        public static implicit operator Oid(string s)
        {
            return new Oid(s);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Oid))
            {
                string rhsString = obj as string;
                if (rhsString != null)
                    return ToHexadecimalString().CompareTo(rhsString);
                throw new ArgumentException("object is not of type Oid");
            }
            return CompareTo((Oid)obj);
        }

        public static Oid NewOid()
        {
            return _Generator.Generate();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("value", ToString(null, null));
        }

        public int CompareTo(Oid rhs)
        {
            bool lhsNull = Buffer == null;
            bool rhsNull = rhs.Buffer == null;
            if (lhsNull && rhsNull)
                return 0;
            if (lhsNull)
                return 1;
            if (rhsNull)
                return -1;
            int ret = Buffer.Length.CompareTo(rhs.Buffer.Length);
            if (ret != 0)
                return ret;
            for (int i = 0; i < Buffer.Length; i++)
            {
                ret = Buffer[i].CompareTo(rhs.Buffer[i]);
                if (ret != 0)
                    return ret;
            }
            return 0;
        }

        public bool Equals(Oid other)
        {
            return CompareTo(other) == 0;
        }

        public int Machine
        {
            get
            {
                if (Buffer == null)
                    return 0;
                return BitConverter.ToInt32(Buffer, 0);
            }
        }

        public long Time
        {
            get
            {
                //long z = _flip(_time);
                //return z * 1000;
                if (Buffer == null)
                    return 0;
                return BitConverter.ToInt64(Buffer, 4);
            }
        }

        public int Inc
        {
            get
            {
                if (Buffer == null)
                    return 0;
                return BitConverter.ToInt32(Buffer, 8);
            }
        }

        public class Generator
        {
            private int inc;
            private object inclock = new object();

            private DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            private byte[] machineHash;
            private byte[] procID;

            public Generator()
            {
                GenerateConstants();
            }

            public Oid Generate()
            {
                byte[] oid = new byte[12];
                int copyidx = 0;

                Array.Copy(BitConverter.GetBytes(GenerateTime()), 0, oid, copyidx, 4);
                copyidx += 4;

                Array.Copy(machineHash, 0, oid, copyidx, 3);
                copyidx += 3;

                Array.Copy(this.procID, 0, oid, copyidx, 2);
                copyidx += 2;

                Array.Copy(BitConverter.GetBytes(GenerateInc()), 0, oid, copyidx, 3);

                return new Oid(oid);
            }

            private int GenerateTime()
            {
                DateTime now = DateTime.Now.ToUniversalTime(); ;
                DateTime nowtime = new DateTime(epoch.Year, epoch.Month, epoch.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
                TimeSpan diff = nowtime - epoch;
                return Convert.ToInt32(Math.Floor(diff.TotalMilliseconds));
            }

            private int GenerateInc()
            {
                lock (this.inclock)
                {
                    return inc++;
                }
            }

            private void GenerateConstants()
            {
                this.machineHash = GenerateHostHash();
                this.procID = BitConverter.GetBytes(GenerateProcId());
            }

            private byte[] GenerateHostHash()
            {
                MD5 md5 = MD5.Create();
                string host = System.Net.Dns.GetHostName();
                return md5.ComputeHash(Encoding.Default.GetBytes(host));
            }

            private int GenerateProcId()
            {
                Process proc = Process.GetCurrentProcess();
                return proc.Id;
            }
        }
    }
}
