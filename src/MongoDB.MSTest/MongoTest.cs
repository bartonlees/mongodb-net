using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for MongoTest and is intended
    ///to contain all MongoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MongoTest
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
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest()
        {
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = Mongo.GetDatabase(databaseUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest1()
        {
            string databaseBinding = string.Empty; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = Mongo.GetDatabase(databaseBinding);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetServer
        ///</summary>
        [TestMethod()]
        public void GetServerTest()
        {
            string location = string.Empty; // TODO: Initialize to an appropriate value
            IServer expected = null; // TODO: Initialize to an appropriate value
            IServer actual;
            actual = Mongo.GetServer(location);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetServer
        ///</summary>
        [TestMethod()]
        public void GetServerTest1()
        {
            Uri location = null; // TODO: Initialize to an appropriate value
            IServer expected = null; // TODO: Initialize to an appropriate value
            IServer actual;
            actual = Mongo.GetServer(location);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DefaultDatabase
        ///</summary>
        [TestMethod()]
        public void DefaultDatabaseTest()
        {
            IDatabase actual;
            actual = Mongo.DefaultDatabase;
            List<Uri> names = new List<Uri>(actual.GetCollectionNames());
            names.Should().Contain("cmd"); //Todo:get the actual name for the command collection
        }

        /// <summary>
        ///A test for DefaultServer
        ///</summary>
        [TestMethod()]
        public void DefaultServerTest()
        {
            IServer actual;
            actual = Mongo.DefaultServer;
        }

        /// <summary>
        ///A test for ReadOnlyDefaultDatabase
        ///</summary>
        [TestMethod()]
        public void ReadOnlyDefaultDatabaseTest()
        {
            IDatabase actual;
            actual = Mongo.DefaultReadOnlyDatabase;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadOnlyDefaultServer
        ///</summary>
        [TestMethod()]
        public void ReadOnlyDefaultServerTest()
        {
            IServer readOnlyServer = Mongo.DefaultReadOnlyServer;
            readOnlyServer.ReadOnly.Should().BeTrue("it is a read only server");
        }

        /// <summary>
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            Version actual;
            actual = Mongo.Version;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
