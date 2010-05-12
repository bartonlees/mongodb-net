using Newtonsoft.Json;

namespace MongoDB.Newtonsoft.Json
{
    /// <summary>
    /// Light wrapper that injects our OidConverter
    /// </summary>
    public class MongoDBSerializer : JsonSerializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDBSerializer"/> class.
        /// </summary>
        public MongoDBSerializer()
        {
            Converters.Add(new OidConverter());
        }
    }
}
