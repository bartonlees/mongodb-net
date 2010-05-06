using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for ServerTest and is intended
    ///to contain all ServerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServerTest
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
        ///A test for Server Constructor
        ///</summary>
        [TestMethod()]
        public void ServerConstructorTest()
        {
            Uri binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Server Constructor
        ///</summary>
        [TestMethod()]
        public void ServerConstructorTest1()
        {
            string binding = string.Empty; // TODO: Initialize to an appropriate value
            Server target = new Server(binding);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Server Constructor
        ///</summary>
        [TestMethod()]
        public void ServerConstructorTest2()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Server Constructor
        ///</summary>
        [TestMethod()]
        public void ServerConstructorTest3()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding, options);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ClearDatabaseCache
        ///</summary>
        [TestMethod()]
        public void ClearDatabaseCacheTest()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            target.ClearDatabaseCache();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropDatabase
        ///</summary>
        [TestMethod()]
        public void DropDatabaseTest()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            IDatabase database = null; // TODO: Initialize to an appropriate value
            target.DropDatabase(database);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            IDBBinding binding1 = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetDatabase(binding1);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest1()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetDatabase(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Admin
        ///</summary>
        [TestMethod()]
        public void AdminTest()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            IAdminOperations actual;
            actual = target.Admin;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Binding
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void BindingTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Server_Accessor target = new Server_Accessor(param0); // TODO: Initialize to an appropriate value
            IServerBinding expected = null; // TODO: Initialize to an appropriate value
            IServerBinding actual;
            target.Binding = expected;
            actual = target.Binding;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DatabaseNames
        ///</summary>
        [TestMethod()]
        public void DatabaseNamesTest()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            IEnumerable<Uri> actual;
            actual = target.DatabaseNames;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Databases
        ///</summary>
        [TestMethod()]
        public void DatabasesTest()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
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
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
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
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            string databaseUri = string.Empty; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target[databaseUri];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Options
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void OptionsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Server_Accessor target = new Server_Accessor(param0); // TODO: Initialize to an appropriate value
            DBConnectionOptions expected = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions actual;
            target.Options = expected;
            actual = target.Options;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadOnly
        ///</summary>
        [TestMethod()]
        public void ReadOnlyTest()
        {
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
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
            IServerBinding binding = null; // TODO: Initialize to an appropriate value
            Server target = new Server(binding); // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.Uri;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
