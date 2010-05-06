using MongoDB.Driver.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for UpdateTest and is intended
    ///to contain all UpdateTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UpdateTest
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
        ///A test for Update Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void UpdateConstructorTest()
        {
            string fullNameSpace = string.Empty; // TODO: Initialize to an appropriate value
            IDBObject selector = null; // TODO: Initialize to an appropriate value
            IDBObject document = null; // TODO: Initialize to an appropriate value
            UpdateOption flags = new UpdateOption(); // TODO: Initialize to an appropriate value
            Update_Accessor target = new Update_Accessor(fullNameSpace, selector, document, flags);
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
            Update_Accessor target = new Update_Accessor(param0); // TODO: Initialize to an appropriate value
            WireProtocolWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteBody(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Document
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void DocumentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Update_Accessor target = new Update_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBObject expected = null; // TODO: Initialize to an appropriate value
            IDBObject actual;
            target.Document = expected;
            actual = target.Document;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Flags
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void FlagsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Update_Accessor target = new Update_Accessor(param0); // TODO: Initialize to an appropriate value
            UpdateOption expected = new UpdateOption(); // TODO: Initialize to an appropriate value
            UpdateOption actual;
            target.Flags = expected;
            actual = target.Flags;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FullNameSpace
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void FullNameSpaceTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Update_Accessor target = new Update_Accessor(param0); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.FullNameSpace = expected;
            actual = target.FullNameSpace;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Selector
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void SelectorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Update_Accessor target = new Update_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBObject expected = null; // TODO: Initialize to an appropriate value
            IDBObject actual;
            target.Selector = expected;
            actual = target.Selector;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
