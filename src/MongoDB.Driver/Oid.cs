//COPYRIGHT


using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MongoDB.Driver
{

    /// <summary>
    /// A globally unique identifier for objects.
    /// Consists of 12 bytes
    /// </summary>
    [Serializable]
    public class Oid : IFormattable, IComparable, IComparable<Oid>, IEquatable<Oid>, ISerializable
    {
        /// <summary>
        /// Gets or sets the buffer.
        /// </summary>
        /// <value>The buffer.</value>
        public byte[] Buffer { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Oid"/> class.
        /// </summary>
        /// <param name="from">From.</param>
        public Oid(Oid from)
        {
            Buffer = null;
            FromByteArray(from.Buffer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Oid"/> class.
        /// </summary>
        public Oid()
        {
            Buffer = null;
            FromByteArray(Empty.Buffer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Oid"/> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization info.</param>
        /// <param name="streamingContext">The streaming context.</param>
        public Oid(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : this(serializationInfo.GetString("value"))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Oid"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Oid(string value)
        {
            Buffer = null;
            FromHexadecimalString(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Oid"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Oid"/> class.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        public Oid(byte[] buffer)
        {
            this.Buffer = null;
            FromByteArray(buffer);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return CompareTo(obj) == 0;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ToHexadecimalString();
        }

        /// <summary>
        /// Toes the hexadecimal string.
        /// </summary>
        /// <returns></returns>
        public string ToHexadecimalString()
        {
            if (Buffer == null)
                return string.Empty;
            return BitConverter.ToString(Buffer).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Toes the base64 string.
        /// </summary>
        /// <returns></returns>
        public string ToBase64String()
        {
            if (Buffer == null)
                return string.Empty;
            return Convert.ToBase64String(Buffer);
        }

        /// <summary>
        /// Toes the mongo DB string.
        /// </summary>
        /// <returns></returns>
        public string ToMongoDBString()
        {
            return string.Format("ObjectId(\"{0}\")", ToHexadecimalString());
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
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
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
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

        /// <summary>
        /// 
        /// </summary>
        public static readonly Oid Empty = new Oid(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        /// <summary>
        /// 
        /// </summary>
        public static readonly Oid CollectionRefID = new Oid(new byte[] { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 });

        static Generator _Generator = new Generator();

        /// <summary>
        /// Performs an implicit conversion from <see cref="MongoDB.Driver.Oid"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="oid">The oid.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(Oid oid)
        {
            return oid.ToString();
        }
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="MongoDB.Driver.Oid"/>.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Oid(string s)
        {
            return new Oid(s);
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj"/>. Zero This instance is equal to <paramref name="obj"/>. Greater than zero This instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="obj"/> is not the same type as this instance. </exception>
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

        /// <summary>
        /// News the oid.
        /// </summary>
        /// <returns></returns>
        public static Oid NewOid()
        {
            return _Generator.Generate();
        }

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("value", ToString(null, null));
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(Oid other)
        {
            return CompareTo(other) == 0;
        }

        /// <summary>
        /// Gets the machine.
        /// </summary>
        /// <value>The machine.</value>
        public int Machine
        {
            get
            {
                if (Buffer == null)
                    return 0;
                return BitConverter.ToInt32(Buffer, 0);
            }
        }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>The time.</value>
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

        /// <summary>
        /// Gets the inc.
        /// </summary>
        /// <value>The inc.</value>
        public int Inc
        {
            get
            {
                if (Buffer == null)
                    return 0;
                return BitConverter.ToInt32(Buffer, 8);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Generator
        {
            private int inc;
            private object inclock = new object();

            private DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            private byte[] machineHash;
            private byte[] procID;

            /// <summary>
            /// Initializes a new instance of the <see cref="Generator"/> class.
            /// </summary>
            public Generator()
            {
                GenerateConstants();
            }

            /// <summary>
            /// Generates this instance.
            /// </summary>
            /// <returns></returns>
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
