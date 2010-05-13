using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            // TODO: Instantiate an appropriate concrete class.
            IServer target = null;
            return target;
        }

        /// <summary>
        ///A test for ClearDatabaseCache
        ///</summary>
        [TestMethod()]
        public void ClearDatabaseCacheTest()
        {
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
            target.ClearDatabaseCache();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropDatabase
        ///</summary>
        [TestMethod()]
        public void DropDatabaseTest()
        {
            IServer readOnlyServer = Mongo.ReadOnlyDefaultServer;
            IServer defaultServer = Mongo.DefaultServer;
            readOnlyServer.DropDatabase(readOnlyServer.),
                Throws.InstanceOf<ReadOnlyException>());
            target.DropDatabase(database);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest()
        {
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetDatabase(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest1()
        {
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetDatabase(binding);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Admin
        ///</summary>
        [TestMethod()]
        public void AdminTest()
        {
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
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
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
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
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
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
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
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
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
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
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
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
            IServer target = CreateIServer(); // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.Uri;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
