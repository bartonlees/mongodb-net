﻿using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IDBCollectionTest and is intended
    ///to contain all IDBCollectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBCollectionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        [TestMethod]
        public void SaveAndFindSingle_AlternatePort()
        {
            IDBCollection c = Mongo.GetDatabase("mongo://localhost:27018/Default").GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.Save(newDocument);
            newDocument.ID.Should().NotBeNull();
            newDocument.ID.Should().NotBe(Oid.Empty);

            IDocument foundDocument = c.FindByID(newDocument.ID);
            foundDocument.Should().NotBeNull();
            foundDocument["name"].Should().Be("ee");
            foundDocument["state"].Should().Be("wa");
        }

        [TestMethod]
        public void TrySaveCheckErrorAndFindSingle_AlternatePort()
        {
            IDBCollection c = Mongo.GetDatabase("mongo://localhost:27018/Default").GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.TrySave(newDocument);
            newDocument.ID.Should().NotBeNull();
            newDocument.ID.Should().NotBe(Oid.Empty);

            IDocument foundDocument = c.FindByID(newDocument.ID);
            foundDocument.Should().NotBeNull();
            foundDocument["name"].Should().Be("ee");
            foundDocument["state"].Should().Be("wa");
        }

        [TestMethod]
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
            newDocument.ID.Should().NotBeNull();
            newDocument.ID.Should().NotBe(Oid.Empty);

            IDocument foundDocument = c.FindByID(newDocument.ID);
            foundDocument.Should().NotBeNull();
            foundDocument["name"].Should().Be("ee");
            foundDocument["state"].Should().Be("wa");
        }


        [TestMethod]
        public void Save_InternalChecks()
        {
           
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("dotted");
            c.Drop();

            Action<IDocument> save = d => c.Save(d);

            new Document() { { "a.b", "test" } }.Invoking(save).ShouldThrow<Exception>();
            new Document() { { "a", new Document() { { "file.ext", 0 } } } }.Invoking(save).ShouldThrow<Exception>();
        }

        [TestMethod]
        public void SaveAndFindByID()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.Save(newDocument);
            newDocument.ID.Should().NotBeNull();
            newDocument.ID.Should().NotBe(Oid.Empty);

            IDocument foundDocument = c.FindByID(newDocument.ID);
            foundDocument.Should().NotBeNull();
            foundDocument["name"].Should().Be("ee");
            foundDocument["state"].Should().Be("wa");
        }


        [TestMethod]
        public void TrySaveAndFindByID()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.TrySave(newDocument);
            newDocument.ID.Should().NotBeNull();
            newDocument.ID.Should().NotBe(Oid.Empty);

            IDocument foundDocument = c.FindByID(newDocument.ID);
            foundDocument.Should().NotBeNull();
            foundDocument["name"].Should().Be("ee");
            foundDocument["state"].Should().Be("wa");
        }

        [TestMethod]
        public void TrySaveCheckErrorAndFindByID()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test1");
            c.Drop();

            IDocument newDocument = new Document
            {
                {"name", "ee"},
                {"state", "wa"}
            };

            c.TrySave(newDocument, true);
            newDocument.ID.Should().NotBeNull();
            newDocument.ID.Should().NotBe(Oid.Empty);

            IDocument foundDocument = c.FindByID(newDocument.ID);
            foundDocument.Should().NotBeNull();
            foundDocument["name"].Should().Be("ee");
            foundDocument["state"].Should().Be("wa");
        }

        [TestMethod]
        public void SaveAndFindByID_Nested()
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

            newDocument.ID.Should().NotBeNull();
            newDocument.ID.Should().NotBe(Oid.Empty);

            IDocument foundDocument = (IDocument)(c.FindByID(newDocument.ID));
            foundDocument.Should().NotBeNull();
            foundDocument["name"].Should().Be("ee");
            foundDocument["state"].Should().Be("wa");

            IDocument nestedDocument = (IDocument)foundDocument["foo"];
            nestedDocument.Should().NotBeNull();
            nestedDocument["bar"].Should().Be("1z");
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


        internal virtual IDBCollection CreateIDBCollection()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBCollection target = null;
            return target;
        }

        /// <summary>
        ///A test for ClearIndexCache
        ///</summary>
        [TestMethod()]
        public void ClearIndexCacheTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            target.ClearIndexCache();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropIndex
        ///</summary>
        [TestMethod()]
        public void DropIndexTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDBIndex index = null; // TODO: Initialize to an appropriate value
            target.DropIndex(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnsureIDIndex
        ///</summary>
        [TestMethod()]
        public void EnsureIDIndexTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = target.EnsureIDIndex();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnsureIndex
        ///</summary>
        [TestMethod()]
        public void EnsureIndexTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            DBFieldSet indexKeyFieldSet = null; // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            bool unique = false; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = target.EnsureIndex(indexKeyFieldSet, name, unique);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIndex
        ///</summary>
        [TestMethod()]
        public void GetIndexTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            Uri indexUri = null; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = target.GetIndex(indexUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetMore
        ///</summary>
        public void GetMoreTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDBCursor<TDoc> cursor = null; // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.GetMore<TDoc>(cursor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetMoreTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call GetMoreTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> documents = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Insert(documents, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Query
        ///</summary>
        public void QueryTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDBCursor<TDoc> cursor = null; // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.Query<TDoc>(cursor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void QueryTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call QueryTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Remove(document, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TryInsert
        ///</summary>
        [TestMethod()]
        public void TryInsertTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> documents = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryInsert(documents, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryRemove
        ///</summary>
        [TestMethod()]
        public void TryRemoveTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryRemove(document, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryUpdate
        ///</summary>
        [TestMethod()]
        public void TryUpdateTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            DBModifier modifier = null; // TODO: Initialize to an appropriate value
            bool upsert = false; // TODO: Initialize to an appropriate value
            bool multi = false; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryUpdate(selector, document, modifier, upsert, multi, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            DBModifier modifier = null; // TODO: Initialize to an appropriate value
            bool upsert = false; // TODO: Initialize to an appropriate value
            bool multi = false; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Update(selector, document, modifier, upsert, multi, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Database
        ///</summary>
        [TestMethod()]
        public void DatabaseTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.Database;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FullName
        ///</summary>
        [TestMethod()]
        public void FullNameTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FullName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IndexHintFieldSets
        ///</summary>
        [TestMethod()]
        public void IndexHintFieldSetsTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IEnumerable<DBFieldSet> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<DBFieldSet> actual;
            target.IndexHintFieldSets = expected;
            actual = target.IndexHintFieldSets;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Indexes
        ///</summary>
        [TestMethod()]
        public void IndexesTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IEnumerable<IDBIndex> actual;
            actual = target.Indexes;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadOnly
        ///</summary>
        [TestMethod()]
        public void ReadOnlyTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.Uri;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
