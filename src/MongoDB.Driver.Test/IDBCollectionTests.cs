//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MongoDB.Driver.Platform.Util;
using System.Data;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class IDBCollectionTests
    {
        [Test]
        public void SaveAndFindSingleAlternatePort()
        {
            IDBCollection c = Mongo.GetDatabase("mongo://localhost:27018/Default").GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.Save(newDocument);
            Assert.That(newDocument.ID, Is.Not.Null);
            Assert.That(newDocument.ID, Is.Not.EqualTo(Oid.Empty));

            IDocument foundDocument = c.FindByID(newDocument.ID);
            Assert.That(foundDocument, Is.Not.Null);
            Assert.AreEqual("ee", foundDocument["name"]);
            Assert.AreEqual("wa", foundDocument["state"]);
        }

        [Test]
        public void TrySaveCheckErrorAndFindSingleAlternatePort()
        {
            IDBCollection c = Mongo.GetDatabase("mongo://localhost:27018/Default").GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.TrySave(newDocument);
            Assert.That(newDocument.ID, Is.Not.Null);
            Assert.That(newDocument.ID, Is.Not.EqualTo(Oid.Empty));

            IDocument foundDocument = c.FindByID(newDocument.ID);
            Assert.That(foundDocument, Is.Not.Null);
            Assert.AreEqual("ee", foundDocument["name"]);
            Assert.AreEqual("wa", foundDocument["state"]);
        }

        [Test]
        public void TrySaveAndFindSingleAlternatePort()
        {
            IDBCollection c = Mongo.GetDatabase("mongo://localhost:27018/Default").GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.TrySave(newDocument);
            Assert.That(newDocument.ID, Is.Not.Null);
            Assert.That(newDocument.ID, Is.Not.EqualTo(Oid.Empty));

            IDocument foundDocument = c.FindByID(newDocument.ID);
            Assert.That(foundDocument, Is.Not.Null);
            Assert.AreEqual("ee", foundDocument["name"]);
            Assert.AreEqual("wa", foundDocument["state"]);
        }


        [Test]
        public void SaveAndFindSingle()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.Save(newDocument);
            Assert.That(newDocument.ID, Is.Not.Null);
            Assert.That(newDocument.ID, Is.Not.EqualTo(Oid.Empty));

            IDocument foundDocument = c.FindByID(newDocument.ID);
            Assert.That(foundDocument, Is.Not.Null);
            Assert.AreEqual("ee", foundDocument["name"]);
            Assert.AreEqual("wa", foundDocument["state"]);
        }


        [Test]
        public void TrySaveAndFindSingle()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.TrySave(newDocument);
            Assert.That(newDocument.ID, Is.Not.Null);
            Assert.That(newDocument.ID, Is.Not.EqualTo(Oid.Empty));

            IDocument foundDocument = c.FindByID(newDocument.ID);
            Assert.That(foundDocument, Is.Not.Null);
            Assert.AreEqual("ee", foundDocument["name"]);
            Assert.AreEqual("wa", foundDocument["state"]);
        }

        [Test]
        public void TrySaveCheckErrorAndFindSingle()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.TrySave(newDocument, true);
            Assert.That(newDocument.ID, Is.Not.Null);
            Assert.That(newDocument.ID, Is.Not.EqualTo(Oid.Empty));

            IDocument foundDocument = c.FindByID(newDocument.ID);
            Assert.That(foundDocument, Is.Not.Null);
            Assert.AreEqual("ee", foundDocument["name"]);
            Assert.AreEqual("wa", foundDocument["state"]);
        }

        [Test]
        public void SaveAndFindSingleNested()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test2");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state","wa"},
                {"foo", new Document {
                    {"bar", "1z"}}
                }
            };

            c.Save(newDocument);

            Assert.That(newDocument.ID, Is.Not.Null);
            Assert.That(newDocument.ID, Is.Not.EqualTo(Oid.Empty));

            IDocument foundDocument = (IDocument)(c.FindByID(newDocument.ID));
            Assert.AreEqual("ee", foundDocument["name"]);
            Assert.AreEqual("wa", foundDocument["state"]);

            IDocument nestedDocument = (IDocument)foundDocument["foo"];
            Assert.IsNotNull(nestedDocument);
            Assert.AreEqual("1z", nestedDocument["bar"]);
        }


        [Test]
        public void CollectionGetCount()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testCount");
            c.Drop();
            Assert.IsNull(c.FindOne());
            Assert.That(c.GetCount(), Is.EqualTo(0));
            for (int test = 0; test < 100; test++)
            {
                c.Insert(new Document("test", test));
            }
            Assert.That(c.GetCount(), Is.EqualTo(100));
        }

        [Test]
        public void ImplicitAndExplicitIndexCreate()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testIndex");

            c.Drop();
            Assert.IsNull(c.FindOne());

            for (int test = 0; test < 100; test++)
            {
                c.Insert(new Document("test", test));
            }

            Assert.That(c.GetCount(), Is.EqualTo(100), "There should have been 100 documents in the collection");

            c.CreateIndex(new DBFieldSet("test"));

            List<IDBObject> list = new List<IDBObject>(c.GetIndexInfo());

            Assert.That(list.Count, Is.EqualTo(2), "There should have been 2 indexes on the collection");
            Assert.IsTrue(list.Count == 2);
            Assert.That(list[0]["name"], Is.EqualTo("_id_"), "The second index should have been named '_id'");
            Assert.That(list[1]["name"], Is.EqualTo("test_1"), "The second index should have been named 'test'");
        }

        [Test]
        public void GroupCount()
        {

            IDBCollection c = Mongo.DefaultDatabase.GetCollection("group1");
            c.Drop();
            c.Save(new Document() { { "test", "a" } });
            c.Save(new Document() { { "test", "a" } });
            c.Save(new Document() { { "test", "a" } });
            c.Save(new Document() { { "test", "b" } });

            IDBObject g = c.Group("test", DBQuery.SelectAll, new Document("count", 0),
                                  "function( o , test ){ test.count++; }");

            IList l = (IList)g;
            Assert.AreEqual(2, l.Count);
        }

        [Test]
        public void PartialDocumentQuery()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("partial1");
            c.Drop();

            c.Save(new Document { { "a", 1 }, { "b", 2 } });

            IDocument fullView = c.FindOne();
            Assert.AreEqual(1, fullView["a"]);
            Assert.AreEqual(2, fullView["b"]);

            IDocument partial = c.FindOne("*", "a");
            Assert.That(1, Is.EqualTo(partial["a"]));
            Assert.That(!partial.ContainsKey("b"), "the partial view should not contain the key 'b'");
        }

        [Test]
        public void FindOne()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test");
            c.Drop();

            IDBObject obj = c.FindOne();
            Assert.AreEqual(obj, null);

            Document inserted = new Document() { { "test", 1 }, { "y", 2 } };
            c.Insert(inserted);
            Document one = new Document() { { "test", 2 }, { "z", 2 } };
            one["_id"] = 123;
            c.Insert(one);

            obj = c.FindByID(123);
            Assert.AreEqual(obj["_id"], 123);
            Assert.AreEqual(obj["test"], 2);
            Assert.AreEqual(obj["z"], 2);

            obj = c.FindByID(123, "test");
            Assert.AreEqual(obj["_id"], 123);
            Assert.AreEqual(obj["test"], 2);
            Assert.AreEqual(obj.ContainsKey("z"), false);

            obj = c.FindOne(Lambda.Query(test => test == 1));
            Assert.AreEqual(obj["test"], 1);
            Assert.AreEqual(obj["y"], 2);

            obj = c.FindOne(Lambda.Query(test => test == 1), "y");
            Assert.AreEqual(obj.ContainsKey("test"), false);
            Assert.AreEqual(obj["y"], 2);
        }

        [Test]
        public void DropIndex()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("dropindex1");
            c.Drop();

            c.Save(new Document("test", 1));
            Assert.AreEqual(1, c.GetIndexInfo().Count());

            c.EnsureIndex(new DBFieldSet("test"));
            Assert.AreEqual(2, c.GetIndexInfo().Count());

            c.DropAllIndexes();
            Assert.AreEqual(1, c.GetIndexInfo().Count());

            c.EnsureIndex(new DBFieldSet("test"));
            Assert.AreEqual(2, c.GetIndexInfo().Count());

            c.EnsureIndex(new DBFieldSet("y"));
            Assert.AreEqual(3, c.GetIndexInfo().Count());

            c.DropIndex(new DBFieldSet("test"));
            Assert.AreEqual(2, c.GetIndexInfo().Count());

        }

        [Test]
        public void Distinct()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("distinct1");
            c.Drop();

            for (int test = 0; test < 100; test++)
            {
                Document o = new Document 
                {
                    {"test",test % 10}
                };

                o["_id"] = test;

                c.Save(o);
            }

            IList l = c.Distinct("test");
            Assert.AreEqual(10, l.Count);

            l = c.Distinct("test",Lambda.Query(_id => _id > 95));
            Assert.AreEqual(4, l.Count);

        }

        [Test]
        public void UpdateWithSet()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("group1");
            c.Drop();
            c.Save(new Document() { { "id", 1 }, { "test", true } });
            Assert.That(c.FindOne()["test"], Is.TypeOf<bool>(), "expected test was a boolean");

            c.Update(Where.Field(id => id == 1), Do.Set("test", 5.5));
            Assert.AreEqual(typeof(Double), c.FindOne()["test"].GetType());
        }

        [Test]
        public void UpdateWithNestedSet()
        {

            IDBCollection c = Mongo.DefaultDatabase.GetCollection("keys1");
            c.Drop();
            c.Save(new Document() {{"a", new Document("test", 1)}});

            Assert.AreEqual(1, ((IDBObject)c.FindOne()["a"])["test"]);
            c.Update("*", Do.Set("a.test", 2));
            Assert.AreEqual(1, c.Find().Count());
            Assert.AreEqual(2, ((IDBObject)c.FindOne()["a"])["test"]);

        }

        [Test]
        public void RoundTripDBTimestamp()
        {

            IDBCollection c = Mongo.DefaultDatabase.GetCollection("ts1");
            c.Drop();
            c.Save(new Document() { { "y", new DBTimestamp() } });

            DBTimestamp test = (DBTimestamp)c.FindOne()["y"];
            Assert.IsTrue(test.Time > 0);
            Assert.IsTrue(test.Inc > 0);
        }

        [Test]
        public void WriteConcernStrict()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("write1");
            c.Drop();
            


            Document a = new Document();
            a.ID = Oid.Empty;

            Document b = new Document();
            b.ID = Oid.Empty;

            c.Insert(a);
            Assert.That(() => c.Insert(b), Throws.Exception);
            Assert.AreEqual(1, c.Find().Count());
        }

        [Test]
        public void RegexQuery()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("jp1");
            c.Drop();

            c.Insert(new Document("test", "a"));
            c.Insert(new Document("test", "A"));

            Assert.AreEqual(1, c.Find(Where.Field(test => test.Matches(new Regex("a")))).Count());
            Assert.AreEqual(1, c.Find(Where.Field(test => test.Matches(new Regex("A")))).Count());
            Assert.AreEqual(2, c.Find(Where.Field(test => test.Matches(new Regex("a", RegexOptions.IgnoreCase)))).Count());
            Assert.AreEqual(2, c.Find(Where.Field(test => test.Matches(new Regex("A", RegexOptions.IgnoreCase)))).Count());
        }


        [Test]
        public void RoundTripDate()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("dates1");
            c.Drop();

            IDocument ins = new Document("test", new DateTime());
            c.Insert(ins);
            IDBObject outs = c.FindOne();
            Assert.That(ins["test"], Is.InstanceOf<DateTime>());
            Assert.AreEqual(ins["test"].GetType(), outs["test"].GetType());
        }

        [Test]
        public void MapReduce()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("jmr1");
            c.Drop();

            c.Save(new Document("test", new string[] { "a", "b" }));
            c.Save(new Document("test", new string[] { "b", "c" }));
            c.Save(new Document("test", new string[] { "c", "d" }));

            MapReduceInfo info =
                c.MapReduce("function(){ for ( var test=0; test<this.test.length; test++ ){ emit( this.test[test] , 1 ); } }",
                             "function(key,values){ var sum=0; for( var test=0; test<values.length; test++ ) sum += values[test]; return sum;}",
                             null, null);

            Dictionary<string, int> m = new Dictionary<string, int>();
            foreach (IDBObject test in info.ResultingCollection)
            {
                m[test.GetAsString("_id")] = test.GetAsInt("value");
            }

            Assert.AreEqual(4, m.Count);
            Assert.AreEqual(1, m["a"]);
            Assert.AreEqual(2, m["b"]);
            Assert.AreEqual(2, m["c"]);
            Assert.AreEqual(1, m["d"]);

        }

        string _testMulti(IDBCollection c)
        {
            string test = "";
            foreach (IDBObject z in c.Find(orderBy:"_id"))
            {
                if (test.Length > 0)
                    test += ",";
                test += z["test"];
            }
            return test;
        }


        [Test]
        public void UpdateInc()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("inc");
            c.Drop();
            c.Insert(new Document() {{ "test", 1 }});
            Assert.That(c.FindOne().GetAsInt("test"), Is.EqualTo(1));
            c.Update("*", Do.Inc("test", 2));
            Assert.That(c.FindOne().GetAsInt("test"), Is.EqualTo(3));
        }

        [Test]
        public void UpdateMulti()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("multi1");
            c.Drop();

            c.Insert(new Document() {{"i", 1},{"test", 1}});
            c.Insert(new Document() {{"i", 2},{"test", 5}});
            c.EnsureIndex("i");

            Assert.That(c.Find(orderBy:"i").Select(doc => doc.GetAsInt("test")), Is.EquivalentTo(new int[] {1, 5}));

            c.Update(Do.Inc("test", 1));
            Assert.That(c.Find(orderBy:"i").Select(doc => doc.GetAsInt("test")), Is.EquivalentTo(new int[] {2, 5}));

            c.Update(Where.Field(i => i == 2),  Do.Inc("test", 1));
            Assert.That(c.Find(orderBy:"i").Select(doc => doc.GetAsInt("test")), Is.EquivalentTo(new int[] {2, 6}));

            c.Update(Do.Inc("test", 1), multi:true);
            Assert.That(c.Find(orderBy: "i").Select(doc => doc.GetAsInt("test")), Is.EquivalentTo(new int[] { 3, 7 }));
        }

        [Test]
        public void Authenticate()
        {
            Assert.AreEqual("26e3d12bd197368526409177b3e8aab6", Util._hash("test", new char[] { 'j' }));

            IDBCollection test = Mongo.DefaultDatabase.GetCollection("system.users");
            try
            {
                Assert.AreEqual(0, test.Find().Count());

                Mongo.DefaultDatabase.AddUser("xx", new char[] { 't', 'e', 's', 't' });
                Assert.AreEqual(1, test.Find().Count());

                Mongo.DefaultDatabase.Binding.SetCredentials("xx", new char[] { 'f' });
                Assert.That(Mongo.DefaultDatabase.GetCollectionNames(), Throws.InstanceOf<MongoException.Authentication>());

                Mongo.DefaultDatabase.Binding.SetCredentials("xx", new char[] { 't', 'e', 's', 't' });
                Assert.That(Mongo.DefaultDatabase.GetCollectionNames(), Throws.InstanceOf<MongoException.Authentication>());
            }
            finally
            {
                test.Remove(new Document());
                Assert.AreEqual(0, test.Find().Count());
            }
        }

        [Test]
        public void OidCompatibility()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("oidc");
            c.Drop();

            c.Save(new Document("test", 1));
            Mongo.DefaultDatabase.Evaluate("db.oidc.insert( { test : 2 } );");

            List<IDBObject> l = new List<IDBObject>(c.Find());
            Assert.AreEqual(2, l.Count);

            Oid a = (Oid)(l[0]["_id"]);
            Oid b = (Oid)(l[1]["_id"]);

            Assert.Less(Math.Abs(a.Time - b.Time), 10000);
        }

        [Test]
        public void OidCompat2()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("oidc");
            c.Drop();

            c.Save(new Document("test", 1));

            object o = Mongo.DefaultDatabase.Evaluate("return db.oidc.findOne()._id.ToString()");
            string test = c.FindOne()["_id"].ToString();
            Assert.AreEqual(test, o);
        }


        [Test]
        public void testLargeBulkInsert()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("largebulk");
            c.Drop();
            string test = "asdasdasd";
            while (test.Length < 10000)
                test += test;
            List<IDBObject> l = new List<IDBObject>();
            int num = 3 * (Bytes.MAX_OBJECT_SIZE / test.Length);

            for (int t = 0; t < num; t++)
            {
                l.Add(new Document("test", t));
            }
            Assert.AreEqual(0, c.Find().Count());
            c.Insert(new Document("l",l));
            Assert.AreEqual(num, c.Find().Count());

            test = l.ToString();
            Assert.IsTrue(test.Length > Bytes.MAX_OBJECT_SIZE);
            Assert.That(()=> c.Save(new Document("foo", test)), Throws.Exception);
            Assert.AreEqual(num, c.Find().Count());
        }

        [Test]
        public void ReadOnly()
        {
            //Make sure this collection doesn't exist
            IDBCollection readOnlyCollection = Mongo.ReadOnlyDefaultDatabase["test"];
            readOnlyCollection.Drop();

            Assert.That(readOnlyCollection.ReadOnly, Is.True, "Collection.ReadOnly");

            Assert.That(() => readOnlyCollection.Update(Do.Inc("test",1)),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => readOnlyCollection.EnsureIndex("_id",true),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => readOnlyCollection.Insert(new Document("test", "test")),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => readOnlyCollection.Remove(new Document("test", "test")),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => readOnlyCollection.Save(new Document("test", "test")),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => readOnlyCollection.DropIndex("_id"),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => readOnlyCollection.Drop(),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => readOnlyCollection.Rename("timmy"),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => readOnlyCollection.MapReduce("function(){ for ( var test=0; test<this.test.length; test++ ){ emit( this.test[test] , 1 ); } }",
                             "function(key,values){ var sum=0; for( var test=0; test<values.length; test++ ) sum += values[test]; return sum;}",
                             null, null),
                Throws.InstanceOf<ReadOnlyException>());
        }
    }
}