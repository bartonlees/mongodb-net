using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for MapReduceInfoTest and is intended
    ///to contain all MapReduceInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MapReduceInfoTest
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


        /// <summary>
        ///A test for MapReduceInfo Constructor
        ///</summary>
        [TestMethod()]
        public void MapReduceInfoConstructorTest()
        {
            IDBCollection from = null; // TODO: Initialize to an appropriate value
            DBObject raw = null; // TODO: Initialize to an appropriate value
            MapReduceInfo target = new MapReduceInfo(from, raw);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Counts
        ///</summary>
        [TestMethod()]

        public void CountsTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //MapReduceInfo_Accessor target = new MapReduceInfo_Accessor(param0); // TODO: Initialize to an appropriate value
            //IDocument expected = null; // TODO: Initialize to an appropriate value
            //IDocument actual;
            //target.Counts = expected;
            //actual = target.Counts;
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResultingCollection
        ///</summary>
        [TestMethod()]

        public void ResultingCollectionTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //MapReduceInfo_Accessor target = new MapReduceInfo_Accessor(param0); // TODO: Initialize to an appropriate value
            //IDBCollection expected = null; // TODO: Initialize to an appropriate value
            //IDBCollection actual;
            //target.ResultingCollection = expected;
            //actual = target.ResultingCollection;
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
