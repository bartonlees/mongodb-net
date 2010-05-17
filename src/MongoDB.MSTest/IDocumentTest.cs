using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IDocumentTest and is intended
    ///to contain all IDocumentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDocumentTest
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


        internal virtual IDocument CreateIDocument()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDocument target = null;
            return target;
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        [TestMethod()]
        public void CollectionTest()
        {
            IDocument target = CreateIDocument(); // TODO: Initialize to an appropriate value
            IDBCollection expected = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            target.Collection = expected;
            actual = target.Collection;
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        [TestMethod()]
        public void IDTest()
        {
            IDocument target = CreateIDocument(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.ID = expected;
            actual = target.ID;
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Partial
        ///</summary>
        [TestMethod()]
        public void PartialTest()
        {
            IDocument target = CreateIDocument(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Partial;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for State
        ///</summary>
        [TestMethod()]
        public void StateTest()
        {
            IDocument target = CreateIDocument(); // TODO: Initialize to an appropriate value
            DocumentState actual;
            actual = target.State;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
