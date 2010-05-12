//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class DBObjectTests
    {

        [Test]
        public void ConstructFromDictionary()
        {
            Dictionary<string, object> m = new Dictionary<string, object>();
            m["key"] = "value";
            m["foo"] = 1;
            m["bar"] = null;

            IDBObject obj = new DBObject(m);
            Assert.AreEqual(obj["key"], "value");
            Assert.AreEqual(obj["foo"], 1);
            Assert.AreEqual(obj["bar"], null);
        }


        [Test]
        public void PutAll()
        {
            IDBObject start = new DBObject() { { "a", 7 }, { "d", 4 } };
            Assert.AreEqual(7, start["a"]);
            Assert.AreEqual(4, start["d"]);

            start.PutAll(new DBObject() { { "a", 1 }, { "b", 2 }, { "c", 3 } });

            Assert.AreEqual(1, start["a"]); //Overwrite
            Assert.AreEqual(2, start["b"]); //Add
            Assert.AreEqual(3, start["c"]); //Add
            Assert.AreEqual(4, start["d"]); //Left alone
        }

        [Test]
        public void Remove()
        {
            DBObject obj = new DBObject();
            obj["test"] = "y";
            obj["y"] = "z";

            Assert.IsTrue(obj.ContainsKey("test"));
            Assert.IsTrue(obj.ContainsKey("y"));

            obj.Remove("test");

            Assert.IsFalse(obj.ContainsKey("test"));
            Assert.IsTrue(obj.ContainsKey("y"));

            obj["test"] = "y";

            Assert.IsTrue(obj.ContainsKey("test"));
            Assert.IsTrue(obj.ContainsKey("y"));
        }


        [Test]
        public void DottedFieldName()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("dotted");
            c.Drop();

            Assert.That(() => c.Save(new Document() { { "a.b", "test" } }), Throws.Exception);
        }

        [Test]
        public void NestedDottedFieldName()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("nesteddotted");
            c.Drop();

            Assert.That(() => c.Save(new Document() { { "a", new Document() { { "file.ext", 0 } } } }), Throws.Exception);
        }

        [Test]
        public void EntryOrder()
        {
            DBObject o = new DBObject();
            o["u"] = 0;
            o["m"] = 1;
            o["p"] = 2;
            o["i"] = 3;
            o["r"] = 4;
            o["e"] = 5;
            o["s"] = 6;
            string[] keys = new string[7];
            o.Keys.CopyTo(keys, 0);
            Assert.That(string.Join("", keys), Is.EqualTo("umpires"), "keys should be in order added");

            List<KeyValuePair<string, object>> pairs = new List<KeyValuePair<string, object>>(o);
            for (int i = 0; i < 7; i++)
            {
                Assert.That(pairs[i].Value, Is.EqualTo(i), "pairs should be in order added");
            }
        }
    }

}