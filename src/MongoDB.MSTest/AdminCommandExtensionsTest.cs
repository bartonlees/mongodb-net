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
        public void buildinfoTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            BuildInfo expected = new BuildInfo(new DBObject());
            BuildInfo actual;
            actual = AdminCommandExtensions.buildinfo(db);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for closeAllDatabases
        ///</summary>
        [TestMethod()]
        public void closeAllDatabasesTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            AdminCommandExtensions.closeAllDatabases(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for copydb
        ///</summary>
        [TestMethod()]
        public void copydbTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            IDatabase fromDatabase = null; // TODO: Initialize to an appropriate value
            IDatabase toDatabase = null; // TODO: Initialize to an appropriate value
            AdminCommandExtensions.copydb(db, fromDatabase, toDatabase);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for copydbgetnonce
        ///</summary>
        [TestMethod()]
        public void copydbgetnonceTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            IDatabase fromDatabase = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AdminCommandExtensions.copydbgetnonce(db, fromDatabase);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for diagLogging
        ///</summary>
        [TestMethod()]
        public void diagLoggingTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            DiagnosticLoggingLevel logLevel = new DiagnosticLoggingLevel(); // TODO: Initialize to an appropriate value
            DiagnosticLoggingLevel logLevelExpected = new DiagnosticLoggingLevel(); // TODO: Initialize to an appropriate value
            AdminCommandExtensions.diagLogging(db, ref logLevel);
            Assert.AreEqual(logLevelExpected, logLevel);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for fsync
        ///</summary>
        [TestMethod()]
        public void fsyncTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            bool asynchronous = false; // TODO: Initialize to an appropriate value
            bool shouldLock = false; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = AdminCommandExtensions.fsync(db, asynchronous, shouldLock);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for listDatabases
        ///</summary>
        [TestMethod()]
        public void listDatabasesTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            DatabaseList expected = null; // TODO: Initialize to an appropriate value
            DatabaseList actual;
            actual = AdminCommandExtensions.listDatabases(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for logRotate
        ///</summary>
        [TestMethod()]
        public void logRotateTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            AdminCommandExtensions.logRotate(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for opLogging
        ///</summary>
        [TestMethod()]
        public void opLoggingTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            bool useOpLogging = false; // TODO: Initialize to an appropriate value
            AdminCommandExtensions.opLogging(db, useOpLogging);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for queryTraceLevel
        ///</summary>
        [TestMethod()]
        public void queryTraceLevelTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            int traceLevel = 0; // TODO: Initialize to an appropriate value
            AdminCommandExtensions.queryTraceLevel(db, traceLevel);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for replacepeer
        ///</summary>
        [TestMethod()]
        public void replacepeerTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AdminCommandExtensions.replacepeer(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for shutdown
        ///</summary>
        [TestMethod()]
        public void shutdownTest()
        {
            IAdminOperations db = Mongo.DefaultServer.Admin; 
            AdminCommandExtensions.shutdown(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
