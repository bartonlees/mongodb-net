using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Bson;
using MongoDB.Driver;

namespace MongoDB.Newtonsoft.Json
{
    /// <summary>
    /// Extension methods for ObjectIds
    /// </summary>
    public static class OidExtensions
    {
        /// <summary>
        /// Helper to transform an oid into a BsonObjectId
        /// </summary>
        /// <param name="oid">The oid.</param>
        /// <returns></returns>
        public static BsonObjectId ToBsonObjectId(this Oid oid)
        {
            return new BsonObjectId(oid.Buffer);
        }

        /// <summary>
        /// Helper to transform BsonObjectIds into Oids
        /// </summary>
        /// <param name="boid">The BOID.</param>
        /// <returns></returns>
        public static Oid ToOid(this BsonObjectId boid)
        {
            return new Oid(boid.Value);
        }
    }
}
