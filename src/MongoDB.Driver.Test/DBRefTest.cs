//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class DBRefTest
    {
        [Test]
        public void Fetch()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test");
            c.Drop();

            Document obj = new Document() {{"test","me"}};
            c.Save(obj);

            DBRef r = new DBRef(c, obj.ID);
            IDocument deref = r.Fetch();

            Assert.That(deref, Is.Not.Null);
            Assert.That(deref.ID, Is.EqualTo(obj.ID));
        }

        [Test]
        public void RoundTrip()
        {
            IDBCollection a = Mongo.DefaultDatabase.GetCollection("refroundtripa");
            IDBCollection b = Mongo.DefaultDatabase.GetCollection("refroundtripb");
            a.Drop();
            b.Drop();

            Document docA = new Document("n", 111);
            Document docB = new Document() { { "n", 12 }, { "l", new DBRef(a, docA.ID) } };

            a.Save(docA);
            b.Save(docB);

            IDocument one = b.FindOne();

            Assert.AreEqual(12, one["n"]);
            //Assert.That(one.GetAsIDBObject("l")["n"], Is.EqualTo(111));
            //TODO:This appears to be mostly useless and deprecated...should verify though

        }
    }

}