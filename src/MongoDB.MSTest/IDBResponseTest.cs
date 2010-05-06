using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IDBResponseTest and is intended
    ///to contain all IDBResponseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBResponseTest
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
        ///A test for DocumentsT
        ///</summary>
        public void DocumentsTTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBResponse<TDoc> target = CreateIDBResponse<TDoc>(); // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.DocumentsT;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual IDBResponse<TDoc> CreateIDBResponse<TDoc>()
            where TDoc : class , IDocument
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBResponse<TDoc> target = null;
            return target;
        }

        [TestMethod()]
        public void DocumentsTTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DocumentsTTestHelper<TDoc>() with appropriate type parameters.");
        }

        internal virtual IDBResponse CreateIDBResponse()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBResponse target = null;
            return target;
        }

        /// <summary>
        ///A test for Read
        ///</summary>
        [TestMethod()]
        public void ReadTest()
        {
            IDBResponse target = CreateIDBResponse(); // TODO: Initialize to an appropriate value
            WireProtocolReader reader = null; // TODO: Initialize to an appropriate value
            target.Read(reader);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Documents
        ///</summary>
        [TestMethod()]
        public void DocumentsTest()
        {
            IDBResponse target = CreateIDBResponse(); // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> actual;
            actual = target.Documents;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
