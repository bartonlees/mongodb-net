using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace MongoDB.Driver
{
    public static class Constants
    {
        public const int MAX_OBJECT_SIZE = 1024 * 1024 * 4;
        public const int CONNECTIONS_PER_HOST = 10;
        public const string NO_REF_HACK = "_____nodbref_____";
        public const int GLOBAL_FLAG = 256;

        /// <summary>
        /// The maximum number of bytes allowed to be sent to the db at a time 
        /// </summary>
        public const int MAX_STRING = MAX_OBJECT_SIZE - 1024;
    }

  

}
