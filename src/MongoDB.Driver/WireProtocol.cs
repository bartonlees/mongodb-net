//COPYRIGHT

using System;
using System.Collections;
using System.Text.RegularExpressions;
namespace MongoDB.Driver
{

    /// <summary>
    /// BSON Element Type designator
    /// </summary>
    public enum TypeByte : byte
    {
        /// <summary>
        /// End Of Object
        /// </summary>
        EOO = 0,
        /// <summary>
        /// Number
        /// </summary>
        NUMBER = 1,
        /// <summary>
        /// String
        /// </summary>
        STRING = 2,
        /// <summary>
        /// Object
        /// </summary>
        OBJECT = 3,
        /// <summary>
        /// Array/List
        /// </summary>
        ARRAY = 4,
        /// <summary>
        /// Binary data
        /// </summary>
        BINARY = 5,
        /// <summary>
        /// Undefined block of data
        /// </summary>
        UNDEFINED = 6,
        /// <summary>
        /// ObjectID
        /// </summary>
        OID = 7,
        /// <summary>
        /// Boolean
        /// </summary>
        BOOLEAN = 8,
        /// <summary>
        /// Date
        /// </summary>
        DATE = 9,
        /// <summary>
        /// Null representation
        /// </summary>
        NULL = 10,
        /// <summary>
        /// Regular Expression
        /// </summary>
        REGEX = 11,
        /// <summary>
        /// Reference/DBPointer (Obsolete)
        /// </summary>
        [Obsolete("See http://bsonspec.org/#/specification")]
        REF = 12,
        /// <summary>
        /// JavaScript Code
        /// </summary>
        CODE = 13,
        /// <summary>
        /// Similar to string but for languages with a distinct symbol type
        /// </summary>
        SYMBOL = 14,
        /// <summary>
        /// Javascript code with scope
        /// </summary>
        CODE_W_SCOPE = 15,
        /// <summary>
        /// 32-bit Integer
        /// </summary>
        NUMBER_INT = 16,
        /// <summary>
        /// Special internal type used by MongoDB replication and sharding
        /// </summary>
        TIMESTAMP = 17,
        /// <summary>
        /// 64-bit Integer
        /// </summary>
        NUMBER_LONG = 18,
        /// <summary>
        /// Special type that compares higher than all other possible BSON element values
        /// </summary>
        MAXKEY = 127,
        /// <summary>
        /// Special type that compares lower than all other possible BSON element values
        /// </summary>
        MINKEY = 255,
    }

    /// <summary>
    /// Helper methods for communication via the MongoDB Wire Protocol
    /// </summary>
    public static class WireProtocol
    {
        /// <summary>
        /// Gets the type byte.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        /// Gets the type byte for a given object.
        /// @param o the object
        /// @return the byte value associated with the type, or 0 if 
        /// <code>o</code>
        ///  was 
        /// <code>null</code>
        public static TypeByte GetTypeByte(object o)
        {
            if (o == null)
                return TypeByte.NULL;

            if (o is double || o is float || o is Int32 || o is Int64)
                return TypeByte.NUMBER;

            if (o is string)
                return TypeByte.STRING;

            if (o is IList)
                return TypeByte.ARRAY;

            if (o is byte[])
                return TypeByte.BINARY;

            if (o is Oid)
                return TypeByte.OID;

            if (o is bool)
                return TypeByte.BOOLEAN;

            if (o is DateTime)
                return TypeByte.DATE;

            if (o is Regex)
                return TypeByte.REGEX;

            if (o is IDBObject)
                return TypeByte.OBJECT;

            return 0;
        }






        //TODO: Port Regex options...
        /*
         * expression flags.
         * @param flags flags from database
         * @return the Java flags
         
        public static int patternFlags(string flags){
        flags = flags.ToLowerCase();
        int fint = 0;

        for( int i=0; i<flags.Length; i++ ) {
            Flag flag = (Flag) flags[i] );
            if( flag != null ) {
                fint |= flag.javaFlag;
                if( flag.unsupported != null )
                    _warnUnsupported( flag.unsupported );
            }
            else {
                throw new ArgumentException( "unrecognized flag: "+flags.charAt( i ) );
            }
        }
        return fint;
    }

        public static int getFlag(char c)
        {
            Flag flag = Flag.getByCharacter(c);
            if (flag == null)
                throw new ArgumentException("unrecognized flag: " + c);

            if (flag.unsupported != null)
            {
                _warnUnsupported(flag.unsupported);
                return 0;
            }

            return flag.javaFlag;
        }

        /** Converts Java regular expression flags into a string of flags for the database
         * @param flags Java flags
         * @return the flags for the database
         
        public static string patternFlags(int flags)
        {
            StringBuilder buf = new StringBuilder();

            foreach (Flag flag in Enum.GetValues(typeof(Flag)))
            {
                if ((flags & flag.javaFlag) > 0)
                {
                    buf.Append(flag.flagChar);
                    flags -= flag.javaFlag;
                }
            }

            if (flags > 0)
                throw new ArgumentException("some flags could not be recognized.");
            return buf.ToString();

        }
        */
        //TODO: Port Regex options...
        //CANON_EQ( Pattern.CANON_EQ, 'c', "Pattern.CANON_EQ" ),
        //    UNIX_LINES(Pattern.UNIX_LINES, 'd', "Pattern.UNIX_LINES" ),
        //    GLOBAL( GLOBAL_FLAG, 'g', null ),
        //    CASE_INSENSITIVE( Pattern.CASE_INSENSITIVE, 'i', null ),
        //    MULTILINE(Pattern.MULTILINE, 'm', null ),
        //    DOTALL( Pattern.DOTALL, 's', "Pattern.DOTALL" ),
        //    LITERAL( Pattern.LITERAL, 't', "Pattern.LITERAL" ),
        //    UNICODE_CASE( Pattern.UNICODE_CASE, 'u', "Pattern.UNICODE_CASE" ),
        //    COMMENTS( Pattern.COMMENTS, 'x', null );


        //private static Dictionary<char, RegexOptions> RegexOptionLookup = new Dictionary<char, RegexOptions>()
        //{
        //    {'c', RegexOptions.ExplicitCapture},
        //    {'d', RegexOptions.Singleline},
        //    {'g', RegexOptions.ExplicitCapture},
        //    {'i', RegexOptions.IgnoreCase},
        //    {'m', RegexOptions.Multiline},
        //    {'s', RegexOptions.Singleline},
        //    {'t', RegexOptions.IgnoreCase},
        //    {'u', RegexOptions.CultureInvariant},
        //    {'x', RegexOptions.None }
        //};


        //public static RegexOptions getByCharacter(char ch)
        //{
        //    return RegexOptionLookup[ch];
        //}


        //private static void _warnUnsupported(string flag)
        //{
        //    Console.WriteLine("flag " + flag + " not supported by db.");
        //}
    }
}