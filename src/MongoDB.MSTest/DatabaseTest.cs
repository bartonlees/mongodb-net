using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DatabaseTest and is intended
    ///to contain all DatabaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatabaseTest
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
        ///A test for Database Constructor
        ///</summary>
        [TestMethod()]
        public void DatabaseConstructorTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddUser
        ///</summary>
        [TestMethod()]
        public void AddUserTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            SecureString passwd = null; // TODO: Initialize to an appropriate value
            target.AddUser(username, passwd);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ClearCollectionCache
        ///</summary>
        [TestMethod()]
        public void ClearCollectionCacheTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            target.ClearCollectionCache();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropCollection
        ///</summary>
        [TestMethod()]
        public void DropCollectionTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            target.DropCollection(collection);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExecuteCommand
        ///</summary>
        [TestMethod()]
        public void ExecuteCommandTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            DBQuery cmd = null; // TODO: Initialize to an appropriate value
            IDBObject expected = null; // TODO: Initialize to an appropriate value
            IDBObject actual;
            actual = target.ExecuteCommand(cmd);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCollection
        ///</summary>
        [TestMethod()]
        public void GetCollectionTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            IDBCollection expected = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = target.GetCollection(collectionUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSisterDatabase
        ///</summary>
        [TestMethod()]
        public void GetSisterDatabaseTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetSisterDatabase(databaseUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsStandardCollection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void IsStandardCollectionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Database_Accessor target = new Database_Accessor(param0); // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsStandardCollection(collectionUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _GetCollection
        ///</summary>
        [TestMethod()]
        public void _GetCollectionTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            IDBCollection expected = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = target._GetCollection(collectionUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Admin
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void AdminTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Database_Accessor target = new Database_Accessor(param0); // TODO: Initialize to an appropriate value
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
            Database_Accessor target = new Database_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBBinding expected = null; // TODO: Initialize to an appropriate value
            IDBBinding actual;
            target.Binding = expected;
            actual = target.Binding;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuildInfo
        ///</summary>
        [TestMethod()]
        public void BuildInfoTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            BuildInfo actual;
            actual = target.BuildInfo;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CmdCollection
        ///</summary>
        [TestMethod()]
        public void CmdCollectionTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = target.CmdCollection;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Collections
        ///</summary>
        [TestMethod()]
        public void CollectionsTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            IEnumerable<IDBCollection> actual;
            actual = target.Collections;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DiagnosticLoggingLevel
        ///</summary>
        [TestMethod()]
        public void DiagnosticLoggingLevelTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            DiagnosticLoggingLevel expected = new DiagnosticLoggingLevel(); // TODO: Initialize to an appropriate value
            DiagnosticLoggingLevel actual;
            target.DiagnosticLoggingLevel = expected;
            actual = target.DiagnosticLoggingLevel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            string collectionUri = string.Empty; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = target[collectionUri];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest1()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = target[collectionUri];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MongoDB.Driver.IAdminOperations.OpLogging
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void OpLoggingTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            IAdminOperations target = new Database(server, binding); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.OpLogging = expected;
            actual = target.OpLogging;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MongoDB.Driver.IAdminOperations.QueryTraceLevel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void QueryTraceLevelTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            IAdminOperations target = new Database(server, binding); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.QueryTraceLevel = expected;
            actual = target.QueryTraceLevel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadOnly
        ///</summary>
        [TestMethod()]
        public void ReadOnlyTest()
        {
            IServer server = null; // TODO: Initialize to an appropriate value
            IDBBinding binding = null; // TODO: Initialize to an appropriate value
            Database target = new Database(server, binding); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Server
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ServerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Database_Accessor target = new Database_Accessor(param0); // TODO: Initialize to an appropriate value
            IServer expected = null; // TODO: Initialize to an appropriate value
            IServer actual;
            target.Server = expected;
            actual = target.Server;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void UriTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Database_Accessor target = new Database_Accessor(param0); // TODO: Initialize to an appropriate value
            Uri expected = null; // TODO: Initialize to an appropriate value
            Uri actual;
            target.Uri = expected;
            actual = target.Uri;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
