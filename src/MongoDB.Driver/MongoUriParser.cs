using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver.Platform.Conditions;

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
        public MongoUriParser()
            : base(GenericUriParserOptions.NoUserInfo | GenericUriParserOptions.NoQuery | GenericUriParserOptions.NoFragment)
        {
        }

        public static int DefaultPort
        {
            get
            {
                return Properties.Settings.Default.DefaultPort;
            }
        }
    }

    
}
