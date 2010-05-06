using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for MongoException_NetworkTest and is intended
    ///to contain all MongoException_NetworkTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MongoException_NetworkTest
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
        ///A test for Network Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void MongoException_NetworkConstructorTest()
        {
            IOException ioe = null; // TODO: Initialize to an appropriate value
            MongoException_Accessor.Network target = new MongoException_Accessor.Network(ioe);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Network Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void MongoException_NetworkConstructorTest1()
        {
            string msg = string.Empty; // TODO: Initialize to an appropriate value
            IOException ioe = null; // TODO: Initialize to an appropriate value
            MongoException_Accessor.Network target = new MongoException_Accessor.Network(msg, ioe);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
