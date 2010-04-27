//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class MongoTests
    {
        [Test]
        public void DefaultDatabase()
        {
            IDatabase db = Mongo.DefaultDatabase;
            List<Uri> names = new List<Uri>(db.GetCollectionNames());
        }
    }
}