using MongoDB.Driver.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for ReplyTest and is intended
    ///to contain all ReplyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReplyTest
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
        ///A test for Reply`1 Constructor
        ///</summary>
        public void ReplyConstructorTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            bool partial = false; // TODO: Initialize to an appropriate value
            Reply<TDoc> target = new Reply<TDoc>(partial);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void ReplyConstructorTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call ReplyConstructorTestHelper<TDoc>() with appropriate type paramete" +
                    "rs.");
        }

        /// <summary>
        ///A test for Read
        ///</summary>
        public void ReadTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            bool partial = false; // TODO: Initialize to an appropriate value
            Reply<TDoc> target = new Reply<TDoc>(partial); // TODO: Initialize to an appropriate value
            WireProtocolReader reader = null; // TODO: Initialize to an appropriate value
            target.Read(reader);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void ReadTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call ReadTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for ReadDocument
        ///</summary>
        public void ReadDocumentTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Reply_Accessor<TDoc> target = new Reply_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
            WireProtocolReader reader = null; // TODO: Initialize to an appropriate value
            TDoc expected = null; // TODO: Initialize to an appropriate value
            TDoc actual;
            actual = target.ReadDocument(reader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ReadDocumentTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call ReadDocumentTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for CursorID
        ///</summary>
        public void CursorIDTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            bool partial = false; // TODO: Initialize to an appropriate value
            Reply<TDoc> target = new Reply<TDoc>(partial); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            target.CursorID = expected;
            actual = target.CursorID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CursorIDTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CursorIDTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Documents
        ///</summary>
        public void DocumentsTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            bool partial = false; // TODO: Initialize to an appropriate value
            Reply<TDoc> target = new Reply<TDoc>(partial); // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> actual;
            actual = target.Documents;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void DocumentsTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DocumentsTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for DocumentsT
        ///</summary>
        public void DocumentsTTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            bool partial = false; // TODO: Initialize to an appropriate value
            Reply<TDoc> target = new Reply<TDoc>(partial); // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.DocumentsT;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void DocumentsTTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DocumentsTTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for NumberReturned
        ///</summary>
        public void NumberReturnedTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            bool partial = false; // TODO: Initialize to an appropriate value
            Reply<TDoc> target = new Reply<TDoc>(partial); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.NumberReturned = expected;
            actual = target.NumberReturned;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void NumberReturnedTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call NumberReturnedTestHelper<TDoc>() with appropriate type parameters" +
                    ".");
        }

        /// <summary>
        ///A test for Partial
        ///</summary>
        public void PartialTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Reply_Accessor<TDoc> target = new Reply_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Partial = expected;
            actual = target.Partial;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void PartialTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call PartialTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for ResponseFlag
        ///</summary>
        public void ResponseFlagTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            bool partial = false; // TODO: Initialize to an appropriate value
            Reply<TDoc> target = new Reply<TDoc>(partial); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ResponseFlag = expected;
            actual = target.ResponseFlag;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ResponseFlagTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call ResponseFlagTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for StartingFrom
        ///</summary>
        public void StartingFromTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            bool partial = false; // TODO: Initialize to an appropriate value
            Reply<TDoc> target = new Reply<TDoc>(partial); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.StartingFrom = expected;
            actual = target.StartingFrom;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void StartingFromTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call StartingFromTestHelper<TDoc>() with appropriate type parameters.");
        }
    }
}
