//COPYRIGHT

namespace MongoDB.Driver
{
    /// <summary>
    /// BSON type indicator byte
    /// </summary>
    public enum BinaryType : byte
    {
        /// <summary>
        /// 
        /// </summary>
        Function = 0x01,
        /// <summary>
        /// 
        /// </summary>
        Binary = 0x02,
        /// <summary>
        /// 
        /// </summary>
        UUID = 0x03,
        /// <summary>
        /// 
        /// </summary>
        MD5 = 0x05,
        /// <summary>
        /// 
        /// </summary>
        UserDefined = 0x80
    }


    /// <summary>
    /// A generic container for binary data
    /// </summary>
    public class DBBinary
    {
        public DBBinary(BinaryType type, byte[] data)
        {
            Type = type;
            Buffer = data;
        }

        public BinaryType Type { get; private set; }
        public byte[] Buffer { get; private set;}
    }
}