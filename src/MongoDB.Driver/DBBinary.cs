//COPYRIGHT

namespace MongoDB.Driver
{
    /// <summary>
    /// BSON type indicator byte
    /// </summary>
    public enum BinaryType : byte
    {
        /// <summary>
        /// Indicates that a Function is encoded in the binary data
        /// </summary>
        Function = 0x01,
        /// <summary>
        /// Indicates that standard binary data is encoded
        /// </summary>
        /// <remarks>This is the most commonly used binary subtype. The structure of the binary data (the byte* array in the binary non-terminal) must be an int32 followed by a (byte*). The int32 is the number of bytes in the repetition.</remarks>
        Binary = 0x02,
        /// <summary>
        /// Indicates that a Universal Unique IDentifier is encoded in the binary data
        /// </summary>
        UUID = 0x03,
        /// <summary>
        /// Indicates that an MD5 Hashs is encoded in the binary data
        /// </summary>
        MD5 = 0x05,
        /// <summary>
        /// Indicates that a User-Define format is used to encode the binary data
        /// </summary>
        UserDefined = 0x80
    }


    /// <summary>
    /// A generic container for binary data
    /// </summary>
    public class DBBinary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBBinary"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="data">A buffer of byte data.</param>
        public DBBinary(BinaryType type, byte[] data)
        {
            Type = type;
            Buffer = data;
        }

        /// <summary>
        /// Gets the type of this data.
        /// </summary>
        /// <value>The type.</value>
        public BinaryType Type { get; private set; }
        /// <summary>
        /// Gets the buffer holding this data.
        /// </summary>
        /// <value>The buffer.</value>
        public byte[] Buffer { get; private set; }
    }
}