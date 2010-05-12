//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class DBObjectArrayTests
    {
        [Test]
        public void AutoExpandToIndex()
        {
            DBObjectArray l = new DBObjectArray();
            l[10] = "test";
            Assert.AreEqual(l[10], "test");
            Assert.AreEqual(l[3], null);
        }

        [Test]
        public void AutoExpandToStringIndex()
        {
            DBObjectArray l = new DBObjectArray();
            l["10"] = "test";
            Assert.AreEqual(l["10"], "test");
            Assert.AreEqual(l["3"], null);
        }

        [Test]
        public void NegativeIndex()
        {
            DBObjectArray l = new DBObjectArray();
            Assert.That(()=> l[-10] = "test", Throws.Exception);
        }

        [Test]
        public void NegativeStringIndex()
        {
            DBObjectArray l = new DBObjectArray();
            Assert.That(()=> l["-10"] = "test", Throws.Exception);
        }

        [Test]
        public void NonIntegerStringIndex()
        {
            DBObjectArray l = new DBObjectArray();
            Assert.That(()=> l[".003"] = "test", Throws.Exception);
        }

        [Test]
        public void RoundTrip()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("dblist");
            c.Drop();

            DBObjectArray l = new DBObjectArray();
            l[0] = "a";
            l[1] = "b";
            l[2] = "c";

            c.Insert(new Document() { { "array", l } });
            IDBObject obj = c.FindOne();
            Assert.That(obj.GetAsIDBObject("array")["0"], Is.EqualTo("a"));
            Assert.That(obj.GetAsIDBObject("array")["1"], Is.EqualTo("b"));
            Assert.That(obj.GetAsIDBObject("array")["2"], Is.EqualTo("c"));
        }
    }
}