using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MongoDB.Newtonsoft.Json
{
    /// <summary>
    /// Light wrapper that injects our OidConverter
    /// </summary>
    public class MongoDBSerializer : JsonSerializer
    {
        public MongoDBSerializer()
        {
            Converters.Add(new OidConverter());
        }
    }
}
