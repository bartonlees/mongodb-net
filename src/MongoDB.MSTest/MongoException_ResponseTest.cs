using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for MongoException_ResponseTest and is intended
    ///to contain all MongoException_ResponseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MongoException_ResponseTest
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
        ///A test for Response Constructor
        ///</summary>
        [TestMethod()]
        public void MongoException_ResponseConstructorTest()
        {
            string msg = string.Empty; // TODO: Initialize to an appropriate value
            IDBResponse response = null; // TODO: Initialize to an appropriate value
            MongoException.Response target = new MongoException.Response(msg, response);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ActualResponse
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ActualResponseTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            MongoException_Accessor.Response target = new MongoException_Accessor.Response(param0); // TODO: Initialize to an appropriate value
            IDBResponse expected = null; // TODO: Initialize to an appropriate value
            IDBResponse actual;
            target.ActualResponse = expected;
            actual = target.ActualResponse;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
