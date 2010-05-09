using System;

namespace MongoDB.Driver
{
    /// <summary>
    /// Helper class to parse specialized mongo URIs
    /// </summary>
    public class MongoUriParser : GenericUriParser
    {

        static MongoUriParser()
        {
            UriParser.Register(new MongoUriParser(), "mongo", Properties.Settings.Default.DefaultPort);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoUriParser"/> class.
        /// </summary>
        public MongoUriParser()
            : base(GenericUriParserOptions.NoUserInfo | GenericUriParserOptions.NoQuery | GenericUriParserOptions.NoFragment)
        {
        }

        /// <summary>
        /// Gets the default port.
        /// </summary>
        /// <value>The default port.</value>
        public static int DefaultPort
        {
            get
            {
                return Properties.Settings.Default.DefaultPort;
            }
        }
    }


}
