using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IDBCursorTest and is intended
    ///to contain all IDBCursorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBCursorTest
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
        public void TestEmptyCursor()
        {
            try
            {
                IDBCollection c = Mongo.DefaultDatabase.GetCollection("test");
                c.Drop();

                using (IDBCursor cur = c.GetCursor())
                {
                    List<IDocument> results = new List<IDocument>(cur);
                }


                Assert.AreEqual(c.ToList().Count, 0);

                Document obj = new Document();
                obj["test"] = "foo";
                c.Insert(obj);

                Assert.AreEqual(c.ToList().Count, 1);
            }
            catch (MongoException)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void Snapshot()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("snapshot1");
            c.Drop();
            for (int test = 0; test < 100; test++)
                c.Save(new Document("test", test));
            Assert.AreEqual(100, c.ToList().Count);
            Assert.AreEqual(100, c.ToArray().Length);
            Assert.AreEqual(100, c.Find(snapshot: true).Count());
            Assert.AreEqual(50, c.Find(snapshot: true, limit: 50).Count());
        }

        [TestMethod]
        public void LimitAndNumberToReturn()
        {
            //Note that Find operation uses cursor internally
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("big1");
            c.Drop();

            string bigString;
            {
                StringBuilder buf = new StringBuilder(16000);
                for (int tt = 0; tt < 16000; tt++)
                    buf.Append("test");
                bigString = buf.ToString();
            }

            int collSize = (15 * 1024 * 1024) / bigString.Length;
            int upperThreshold = 800; //A number greater than the collSize
            int lowerThreshold = 10;  //A number less than the collSize

            for (int t = 0; t < collSize; t++)
                c.Save(new Document() { { "best", t }, { "test", bigString } });

            collSize.Should().BeLessThan(upperThreshold, "verifying collSize < upperThreshold");
            collSize.Should().BeGreaterThan(lowerThreshold, "verifying collSize > lowerThreshold");

            collSize.Should().Be(c.ToList().Count, "expected count() == collSize from collection enumeration");
            c.Find().Count().Should().Be(collSize, "expected count() == collSize from default cursor operation");

            c.Find(numberToReturn: upperThreshold).Count().Should().Be(collSize, "expected count() == collSize regardless of numberToReturn > collSize");
            c.Find(numberToReturn: lowerThreshold).Count().Should().Be(collSize, "expected count() == collSize regardless of numberToReturn < collSize");
            c.Find(numberToReturn: collSize).Count().Should().Be(collSize, "expected count() == collSize regardless of numberToReturn == collSize");
            c.Find(numberToReturn: 2).Count().Should().Be(collSize, "expected count() == collSize when numberToReturn == 2");
            c.Find(numberToReturn: 1).Count().Should().Be(1, "expected count() == 1 when numberToReturn == 1");

            c.Find(limit: upperThreshold).Count().Should().Be(66, "expected count() == 66 regardless of limit > collSize");
            c.Find(limit: lowerThreshold).Count().Should().Be(lowerThreshold, "expected count() == lowerThreshold becase of limit < 66");
            c.Find(limit: collSize).Count().Should().Be(66, "expected count() == 66 because of limit == collSize");
        }

        [TestMethod]
        public void Explain()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("explain1");
            c.Drop();

            for (int test = 0; test < 100; test++)
                c.Save(new Document("test", test));

            DBQuery q = new DBQuery("test", new DBQuery("$gt", 50));

            Assert.AreEqual(49, c.Find(q).Count());
            Assert.AreEqual(20, c.Find(q, limit: 20).Count());

            c.EnsureIndex(new DBFieldSet("test"));

            Assert.AreEqual(49, c.Find(q).Count());
            Assert.AreEqual(20, c.Find(q, limit: 20).Count());

            //Assert.AreEqual(49, c.Find(q, explain:true)["n"]);

            //// these 2 are 'reversed' b/c we want the user case to make sense
            //Assert.AreEqual(20, c.Find(q).limit(20).explain()["n"]);
            //Assert.AreEqual(49, c.Find(q).limit(-20).explain()["n"]);

        }


        /// <summary>
        ///A test for DocumentsT
        ///</summary>
        public void DocumentsTTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBCursor<TDoc> target = CreateIDBCursor<TDoc>(); // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.DocumentsT;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual IDBCursor<TDoc> CreateIDBCursor<TDoc>()
            where TDoc : class , IDocument
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBCursor<TDoc> target = null;
            return target;
        }

        [TestMethod()]
        public void DocumentsTTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DocumentsTTestHelper<TDoc>() with appropriate type parameters.");
        }

        internal virtual IDBCursor CreateIDBCursor()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBCursor target = null;
            return target;
        }

        /// <summary>
        ///A test for Copy
        ///</summary>
        [TestMethod()]
        public void CopyTest()
        {
            IDBCursor target = CreateIDBCursor(); // TODO: Initialize to an appropriate value
            IDBCursor expected = null; // TODO: Initialize to an appropriate value
            IDBCursor actual;
            actual = target.Copy();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CursorID
        ///</summary>
        [TestMethod()]
        public void CursorIDTest()
        {
            IDBCursor target = CreateIDBCursor(); // TODO: Initialize to an appropriate value
            Nullable<long> expected = new Nullable<long>(); // TODO: Initialize to an appropriate value
            Nullable<long> actual;
            target.CursorID = expected;
            actual = target.CursorID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasMore
        ///</summary>
        [TestMethod()]
        public void HasMoreTest()
        {
            IDBCursor target = CreateIDBCursor(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasMore;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Options
        ///</summary>
        [TestMethod()]
        public void OptionsTest()
        {
            IDBCursor target = CreateIDBCursor(); // TODO: Initialize to an appropriate value
            DBCursorOptions actual;
            actual = target.Options;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
