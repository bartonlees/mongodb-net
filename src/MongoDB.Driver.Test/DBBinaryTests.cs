//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class DBBinaryTests
    {
        [Test]
        public void DBBinaryByteArrayRoundtrip()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testBinary");
            c.Drop();
            c.Save(new Document() { { "a", Encoding.UTF8.GetBytes("devfuel") } });
            Assert.That(Encoding.UTF8.GetString((byte[])c.FindOne()["a"]), Is.EqualTo("devfuel"), "byte array roundtrip failed");
            c.Drop();
        }

        [Test]
        public void DBBinaryRoundtrip()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testBinary");
            c.Drop();

            c.Save(new Document("a", new DBBinary(BinaryType.Binary, Encoding.UTF8.GetBytes("devfuel"))));

            Assert.That(Encoding.UTF8.GetString(c.FindOne().GetAs<byte[]>("a")), Is.EqualTo("devfuel"), "DBBinary roundtrip failed");
        }

        [Test]
        public void DBBinaryUserDefinedRoundtrip()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testBinary");
            c.Drop();

            c.Save(new Document("a", new DBBinary(BinaryType.UserDefined, Encoding.UTF8.GetBytes("devfuel"))));

            Assert.That(Encoding.UTF8.GetString(c.FindOne().GetAs<DBBinary>("a").Buffer), Is.EqualTo("devfuel"), "UserDefined DBBinary roundtrip failed");
        }
    }
}