
namespace MongoDB.Driver
{
    /// <summary>
    /// Constants used in MongoDB.Driver namespace
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 
        /// </summary>
        public const int MAX_OBJECT_SIZE = 1024 * 1024 * 4;
        /// <summary>
        /// 
        /// </summary>
        public const int CONNECTIONS_PER_HOST = 10;
        /// <summary>
        /// 
        /// </summary>
        public const string NO_REF_HACK = "_____nodbref_____";
        /// <summary>
        /// 
        /// </summary>
        public const int GLOBAL_FLAG = 256;

        /// <summary>
        /// The maximum number of bytes allowed to be sent to the db at a time 
        /// </summary>
        public const int MAX_STRING = MAX_OBJECT_SIZE - 1024;

        /// <summary>
        /// Well-Known Collection Names
        /// </summary>
        public static class CollectionNames
        {
            /// <summary>
            /// Name of the virtual collection used for sending database commands to the server
            /// </summary>
            public const string Cmd = "$cmd";

            /// <summary>
            /// Name of the collection that houses user information
            /// </summary>
            public const string SystemUsers = "system.users";
        }
    }



}
