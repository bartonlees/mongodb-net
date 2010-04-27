//COPYRIGHT

namespace MongoDB.Driver
{
    public enum BinaryType : byte
    {
        Function = 0x01,
        Binary = 0x02,
        UUID = 0x03,
        MD5 = 0x05,
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