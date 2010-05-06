using MongoDB.Driver.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for InsertTest and is intended
    ///to contain all InsertTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InsertTest
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
        ///A test for Insert Constructor
        ///</summary>
        [TestMethod()]
        public void InsertConstructorTest()
        {
            string fullCollectionName = string.Empty; // TODO: Initialize to an appropriate value
            IDocument[] documentsToInsert = null; // TODO: Initialize to an appropriate value
            Insert target = new Insert(fullCollectionName, documentsToInsert);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Insert Constructor
        ///</summary>
        [TestMethod()]
        public void InsertConstructorTest1()
        {
            string fullCollectionName = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> documentsToInsert = null; // TODO: Initialize to an appropriate value
            Insert target = new Insert(fullCollectionName, documentsToInsert);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for WriteBody
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void WriteBodyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Insert_Accessor target = new Insert_Accessor(param0); // TODO: Initialize to an appropriate value
            WireProtocolWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteBody(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Documents
        ///</summary>
        [TestMethod()]
        public void DocumentsTest()
        {
            string fullCollectionName = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> documentsToInsert = null; // TODO: Initialize to an appropriate value
            Insert target = new Insert(fullCollectionName, documentsToInsert); // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> actual;
            actual = target.Documents;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FullCollectionName
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void FullCollectionNameTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Insert_Accessor target = new Insert_Accessor(param0); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.FullCollectionName = expected;
            actual = target.FullCollectionName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
