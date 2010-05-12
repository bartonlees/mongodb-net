using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBErrorTest and is intended
    ///to contain all DBErrorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBErrorTest
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
        ///A test for DBError Constructor
        ///</summary>
        [TestMethod()]
        public void DBErrorConstructorTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DBError target = new DBError(response);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Throw
        ///</summary>
        [TestMethod()]
        public void ThrowTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DBError target = new DBError(response); // TODO: Initialize to an appropriate value
            string context = string.Empty; // TODO: Initialize to an appropriate value
            target.Throw(context);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToCode
        ///</summary>
        [TestMethod()]
        public void ToCodeTest()
        {
            string error = string.Empty; // TODO: Initialize to an appropriate value
            DBError.Code expected = new DBError.Code(); // TODO: Initialize to an appropriate value
            DBError.Code actual;
            actual = DBError.ToCode(error);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Assertion
        ///</summary>
        [TestMethod()]
        public void AssertionTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DBError target = new DBError(response); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Assertion;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DBError target = new DBError(response); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Message;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NamespaceWasNotFound
        ///</summary>
        [TestMethod()]
        public void NamespaceWasNotFoundTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DBError target = new DBError(response); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.NamespaceWasNotFound;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Response
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ResponseTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBError_Accessor target = new DBError_Accessor(param0); // TODO: Initialize to an appropriate value
            //IDBObject expected = null; // TODO: Initialize to an appropriate value
            //IDBObject actual;
            //target.Response = expected;
            //actual = target.Response;
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
