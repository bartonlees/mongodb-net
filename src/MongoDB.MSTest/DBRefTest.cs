using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBRefTest and is intended
    ///to contain all DBRefTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBRefTest
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
            //Assert.That(one.GetAsIDBObject("l")["n"].Should().Be(111));
            //TODO:This appears to be mostly useless and deprecated...should verify though

        }


        /// <summary>
        ///A test for DBRef Constructor
        ///</summary>
        [TestMethod()]
        public void DBRefConstructorTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["ref"];
            object id = Oid.NewOid();
            DBRef target = new DBRef(collection, id);
            target.ID.Should().Be(id);
            target.Collection.Should().BeEquivalentTo(collection);
        }

        /// <summary>
        ///A test for Fetch
        ///</summary>
        [TestMethod()]
        public void FetchTest()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("test");
            c.Drop();

            Document obj = new Document() { { "test", "me" } };
            c.Save(obj);

            DBRef r = new DBRef(c, obj.ID);
            IDocument deref = r.Fetch();

            deref.Should().NotBeNull();
            deref.ID.Should().Be(obj.ID);
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        [TestMethod()]

        public void CollectionTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBRef_Accessor target = new DBRef_Accessor(param0); // TODO: Initialize to an appropriate value
            //IDBCollection expected = null; // TODO: Initialize to an appropriate value
            //IDBCollection actual;
            //target.Collection = expected;
            //actual = target.Collection;
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        [TestMethod()]

        public void IDTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBRef_Accessor target = new DBRef_Accessor(param0); // TODO: Initialize to an appropriate value
            //object expected = null; // TODO: Initialize to an appropriate value
            //object actual;
            //target.ID = expected;
            //actual = target.ID;
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
