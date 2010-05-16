using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Data;
namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IServerTest and is intended
    ///to contain all IServerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IServerTest
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

        internal virtual IServer CreateIServer()
        {
            IServer target = Mongo.DefaultServer;
            return target;
        }

        /// <summary>
        ///A test for ClearDatabaseCache
        ///</summary>
        [TestMethod()]
        public void ClearDatabaseCacheTest()
        {
            IServer target = CreateIServer();
            target.ClearDatabaseCache();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropDatabase
        ///</summary>
        [TestMethod()]
        public void DropDatabaseTest()
        {
            IServer defaultServer = Mongo.DefaultServer;
            IDatabase defaultDatabase = defaultServer.GetDatabase("drop1");
            defaultDatabase.GetCollection("test").Insert(new Document() { { "a", 1 } });
            defaultServer.DropDatabase(defaultDatabase);

            IServer readonlyServer = Mongo.DefaultServer_ReadOnly;
            IDatabase readonlyDatabase = readonlyServer.GetDatabase("drop1");
            Action drop = () => readonlyServer.DropDatabase(readonlyDatabase);
            drop.ShouldThrow<ReadOnlyException>("one shouldn't be able to drop a readonly database");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest()
        {
            IServer target = CreateIServer();
            Uri name = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetDatabase(name);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest1()
        {
            IServer target = CreateIServer();
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetDatabase(binding);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Admin
        ///</summary>
        [TestMethod()]
        public void AdminTest()
        {
            IServer target = CreateIServer();
            IAdminOperations actual;
            actual = target.Admin;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Binding
        ///</summary>
        [TestMethod()]
        public void BindingTest()
        {
            IServer target = CreateIServer();
            IServerBinding actual;
            actual = target.Binding;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DatabaseNames
        ///</summary>
        [TestMethod()]
        public void DatabaseNamesTest()
        {
            foreach (Uri name in Mongo.DefaultServer.DatabaseNames)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        ///A test for Databases
        ///</summary>
        [TestMethod()]
        public void DatabasesTest()
        {
            IServer target = CreateIServer();
            IEnumerable<IDatabase> actual;
            actual = target.Databases;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            IServer target = CreateIServer();
            string databaseUri = string.Empty; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target[databaseUri];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest1()
        {
            IServer target = CreateIServer();
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target[databaseUri];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadOnly
        ///</summary>
        [TestMethod()]
        public void ReadOnlyTest()
        {
            IServer target = CreateIServer();
            bool actual;
            actual = target.ReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            IServer target = CreateIServer();
            Uri actual;
            actual = target.Uri;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
