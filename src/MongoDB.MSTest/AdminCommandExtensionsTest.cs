using MongoDB.Driver.Command.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for AdminCommandExtensionsTest and is intended
    ///to contain all AdminCommandExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AdminCommandExtensionsTest
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
        ///A test for buildinfo
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void buildinfoTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            BuildInfo expected = null; // TODO: Initialize to an appropriate value
            BuildInfo actual;
            actual = AdminCommandExtensions_Accessor.buildinfo(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for closeAllDatabases
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void closeAllDatabasesTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            AdminCommandExtensions_Accessor.closeAllDatabases(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for copydb
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void copydbTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            IDatabase fromDatabase = null; // TODO: Initialize to an appropriate value
            IDatabase toDatabase = null; // TODO: Initialize to an appropriate value
            AdminCommandExtensions_Accessor.copydb(db, fromDatabase, toDatabase);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for copydbgetnonce
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void copydbgetnonceTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            IDatabase fromDatabase = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AdminCommandExtensions_Accessor.copydbgetnonce(db, fromDatabase);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for diagLogging
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void diagLoggingTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            DiagnosticLoggingLevel logLevel = new DiagnosticLoggingLevel(); // TODO: Initialize to an appropriate value
            DiagnosticLoggingLevel logLevelExpected = new DiagnosticLoggingLevel(); // TODO: Initialize to an appropriate value
            AdminCommandExtensions_Accessor.diagLogging(db, ref logLevel);
            Assert.AreEqual(logLevelExpected, logLevel);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for fsync
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void fsyncTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            bool asynchronous = false; // TODO: Initialize to an appropriate value
            bool shouldLock = false; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AdminCommandExtensions_Accessor.fsync(db, asynchronous, shouldLock);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for listDatabases
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void listDatabasesTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            DatabaseList expected = null; // TODO: Initialize to an appropriate value
            DatabaseList actual;
            actual = AdminCommandExtensions_Accessor.listDatabases(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for logRotate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void logRotateTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            AdminCommandExtensions_Accessor.logRotate(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for opLogging
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void opLoggingTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            bool useOpLogging = false; // TODO: Initialize to an appropriate value
            AdminCommandExtensions_Accessor.opLogging(db, useOpLogging);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for queryTraceLevel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void queryTraceLevelTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            int traceLevel = 0; // TODO: Initialize to an appropriate value
            AdminCommandExtensions_Accessor.queryTraceLevel(db, traceLevel);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for replacepeer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void replacepeerTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AdminCommandExtensions_Accessor.replacepeer(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for shutdown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void shutdownTest()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            AdminCommandExtensions_Accessor.shutdown(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
