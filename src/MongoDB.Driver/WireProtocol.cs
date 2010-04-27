//COPYRIGHT

using System.Text;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
namespace MongoDB.Driver
{

    /**
     * Handles byte functions for <code>ByteEncoder</code> and <code>ByteDecoder</code>.
     */
    public static class Bytes
    {
        public const int MAX_OBJECT_SIZE = 1024 * 1024 * 4;
        public const int CONNECTIONS_PER_HOST = 10;
        public const string NO_REF_HACK = "_____nodbref_____";

        public const byte EOO = 0;
        public const byte NUMBER = 1;
        public const byte STRING = 2;
        public const byte OBJECT = 3;
        public const byte ARRAY = 4;
        public const byte BINARY = 5;
        public const byte UNDEFINED = 6;
        public const byte OID = 7;
        public const byte BOOLEAN = 8;
        public const byte DATE = 9;
        public const byte NULL = 10;
        public const byte REGEX = 11;
        public const byte REF = 12;
        public const byte CODE = 13;
        public const byte SYMBOL = 14;
        public const byte CODE_W_SCOPE = 15;
        public const byte NUMBER_INT = 16;
        public const byte TIMESTAMP = 17;
        public const byte NUMBER_LONG = 18;

        public const byte MINKEY = 255;
        public const byte MAXKEY = 127;

        public const int GLOBAL_FLAG = 256;

        /** The maximum number of bytes allowed to be sent to the db at a time */
        public const int MAX_STRING = MAX_OBJECT_SIZE - 1024;

        /** Gets the type byte for a given object.
         * @param o the object
         * @return the byte value associated with the type, or 0 if <code>o</code> was <code>null</code>
         */
        public static byte getType(object o)
        {
            if (o == null)
                return NULL;

            if (o is double || o is float || o is Int32 || o is Int64)
                return NUMBER;

            if (o is string)
                return STRING;

            if (o is IList)
                return ARRAY;

            if (o is byte[])
                return BINARY;

            if (o is Oid)
                return OID;

            if (o is bool)
                return BOOLEAN;

            if (o is DateTime)
                return DATE;

            if (o is Regex)
                return REGEX;

            if (o is IDBObject)
                return OBJECT;

            return 0;
        }

        /** Determines whether the given object was once part of a db collection.
         * This method is not foolproof, the the object has had its _id or _ns fields since
         * it was fetched, this will return that <code>o</code> did not come from the db.
         * @param o the object to check
         * @return if <code>o</code> contains fields that are automatically added by the database on insertion
         */
        public static bool CameFromDB(IDBObject o)
        {
            if (o == null)
                return false;

            if (!o.ContainsKey("_id"))
                return false;

            if (!o.ContainsKey("_ns"))
                return false;

            return true;
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


        private static Dictionary<char, RegexOptions> RegexOptionLookup = new Dictionary<char, RegexOptions>()
        {
            {'c', RegexOptions.ExplicitCapture},
            {'d', RegexOptions.Singleline},
            {'g', RegexOptions.ExplicitCapture},
            {'i', RegexOptions.IgnoreCase},
            {'m', RegexOptions.Multiline},
            {'s', RegexOptions.Singleline},
            {'t', RegexOptions.IgnoreCase},
            {'u', RegexOptions.CultureInvariant},
            {'x', RegexOptions.None }
        };


        public static RegexOptions getByCharacter(char ch)
        {
            return RegexOptionLookup[ch];
        }


        private static void _warnUnsupported(string flag)
        {
            Console.WriteLine("flag " + flag + " not supported by db.");
        }
    }
}