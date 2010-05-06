using MongoDB.Driver.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;
using MongoDB.Driver;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for CommandExtensionsTest and is intended
    ///to contain all CommandExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandExtensionsTest
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
        ///A test for BuildQuery_authenticate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void BuildQuery_authenticateTest()
        {
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string nonce = string.Empty; // TODO: Initialize to an appropriate value
            SecureString key = null; // TODO: Initialize to an appropriate value
            DBQuery expected = null; // TODO: Initialize to an appropriate value
            DBQuery actual;
            actual = CommandExtensions_Accessor.BuildQuery_authenticate(username, nonce, key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for assertinfo
        ///</summary>
        [TestMethod()]
        public void assertinfoTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            AssertInfo expected = null; // TODO: Initialize to an appropriate value
            AssertInfo actual;
            actual = CommandExtensions.assertinfo(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for authenticate
        ///</summary>
        [TestMethod()]
        public void authenticateTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string nonce = string.Empty; // TODO: Initialize to an appropriate value
            SecureString key = null; // TODO: Initialize to an appropriate value
            CommandExtensions.authenticate(db, username, nonce, key);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for authenticate
        ///</summary>
        [TestMethod()]
        public void authenticateTest1()
        {
            IDBConnection connection = null; // TODO: Initialize to an appropriate value
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string nonce = string.Empty; // TODO: Initialize to an appropriate value
            SecureString key = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = CommandExtensions.authenticate(connection, collection, username, nonce, key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for create
        ///</summary>
        [TestMethod()]
        public void createTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string collectionName = string.Empty; // TODO: Initialize to an appropriate value
            IDBObject options = null; // TODO: Initialize to an appropriate value
            CommandExtensions.create(db, collectionName, options);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for deleteIndexes
        ///</summary>
        [TestMethod()]
        public void deleteIndexesTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            string indexName = string.Empty; // TODO: Initialize to an appropriate value
            CommandExtensions.deleteIndexes(db, collection, indexName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for driverOIDTest
        ///</summary>
        [TestMethod()]
        public void driverOIDTestTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            Oid id = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = CommandExtensions.driverOIDTest(db, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for drop
        ///</summary>
        [TestMethod()]
        public void dropTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string collectionFullName = string.Empty; // TODO: Initialize to an appropriate value
            CommandExtensions.drop(db, collectionFullName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for dropDatabase
        ///</summary>
        [TestMethod()]
        public void dropDatabaseTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string dbName = string.Empty; // TODO: Initialize to an appropriate value
            CommandExtensions.dropDatabase(db, dbName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for eval
        ///</summary>
        [TestMethod()]
        public void evalTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string code = string.Empty; // TODO: Initialize to an appropriate value
            object[] args = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = CommandExtensions.eval(db, code, args);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for forceerror
        ///</summary>
        [TestMethod()]
        public void forceerrorTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            DBError expected = null; // TODO: Initialize to an appropriate value
            DBError actual;
            actual = CommandExtensions.forceerror(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getlasterror
        ///</summary>
        [TestMethod()]
        public void getlasterrorTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            LastError expected = null; // TODO: Initialize to an appropriate value
            LastError actual;
            actual = CommandExtensions.getlasterror(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getoptime
        ///</summary>
        [TestMethod()]
        public void getoptimeTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            OpTime expected = null; // TODO: Initialize to an appropriate value
            OpTime actual;
            actual = CommandExtensions.getoptime(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getpreverror
        ///</summary>
        [TestMethod()]
        public void getpreverrorTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            PrevError expected = null; // TODO: Initialize to an appropriate value
            PrevError actual;
            actual = CommandExtensions.getpreverror(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for group
        ///</summary>
        [TestMethod()]
        public void groupTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBFieldSet key = null; // TODO: Initialize to an appropriate value
            DBQuery cond = null; // TODO: Initialize to an appropriate value
            IDocument initial = null; // TODO: Initialize to an appropriate value
            string reduce = string.Empty; // TODO: Initialize to an appropriate value
            IDBObject expected = null; // TODO: Initialize to an appropriate value
            IDBObject actual;
            actual = CommandExtensions.group(db, collection, key, cond, initial, reduce);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nonce
        ///</summary>
        [TestMethod()]
        public void nonceTest()
        {
            IDBConnection connection = null; // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = CommandExtensions.nonce(connection, cmdCollection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nonce
        ///</summary>
        [TestMethod()]
        public void nonceTest1()
        {
            IAdminOperations db = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = CommandExtensions.nonce(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for renameCollection
        ///</summary>
        [TestMethod()]
        public void renameCollectionTest()
        {
            IDatabase database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            Uri newCollectionUri = null; // TODO: Initialize to an appropriate value
            CommandExtensions.renameCollection(database, collectionUri, newCollectionUri);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for reseterror
        ///</summary>
        [TestMethod()]
        public void reseterrorTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            CommandExtensions.reseterror(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
