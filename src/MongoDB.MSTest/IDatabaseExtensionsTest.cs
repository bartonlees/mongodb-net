using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MongoDB.Driver.Command;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IDatabaseExtensionsTest and is intended
    ///to contain all IDatabaseExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDatabaseExtensionsTest
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
        ///A test for AddUser
        ///</summary>
        [TestMethod()]
        public void AddUserTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<char> passwd = null; // TODO: Initialize to an appropriate value
            IDatabaseExtensions.AddUser(db, username, passwd);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CollectionExists
        ///</summary>
        [TestMethod()]
        public void CollectionExistsTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IDatabaseExtensions.CollectionExists(db, collectionUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateCollection
        ///</summary>
        [TestMethod()]
        public void CreateCollectionTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Nullable<bool> capped = new Nullable<bool>(); // TODO: Initialize to an appropriate value
            Nullable<int> size = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> max = new Nullable<int>(); // TODO: Initialize to an appropriate value
            IDBCollection expected = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = IDatabaseExtensions.CreateCollection(db, name, capped, size, max);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Drop
        ///</summary>
        [TestMethod()]
        public void DropTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            IDatabaseExtensions.Drop(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Evaluate
        ///</summary>
        [TestMethod()]
        public void EvaluateTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string expression = string.Empty; // TODO: Initialize to an appropriate value
            object[] args = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = IDatabaseExtensions.Evaluate(db, expression, args);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ForceError
        ///</summary>
        [TestMethod()]
        public void ForceErrorTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            DBError expected = null; // TODO: Initialize to an appropriate value
            DBError actual;
            actual = IDatabaseExtensions.ForceError(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCollection
        ///</summary>
        [TestMethod()]
        public void GetCollectionTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            string collectionUri = string.Empty; // TODO: Initialize to an appropriate value
            IDBCollection expected = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = IDatabaseExtensions.GetCollection(db, collectionUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCollectionNames
        ///</summary>
        [TestMethod()]
        public void GetCollectionNamesTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            IEnumerable<Uri> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Uri> actual;
            actual = IDatabaseExtensions.GetCollectionNames(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLastError
        ///</summary>
        [TestMethod()]
        public void GetLastErrorTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            LastError expected = null; // TODO: Initialize to an appropriate value
            LastError actual;
            actual = IDatabaseExtensions.GetLastError(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPreviousError
        ///</summary>
        [TestMethod()]
        public void GetPreviousErrorTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            PrevError expected = null; // TODO: Initialize to an appropriate value
            PrevError actual;
            actual = IDatabaseExtensions.GetPreviousError(db);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResetError
        ///</summary>
        [TestMethod()]
        public void ResetErrorTest()
        {
            IDatabase db = null; // TODO: Initialize to an appropriate value
            IDatabaseExtensions.ResetError(db);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetCredentials
        ///</summary>
        [TestMethod()]
        public void SetCredentialsTest()
        {
            IDBBinding db = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<char> passwd = null; // TODO: Initialize to an appropriate value
            IDatabaseExtensions.SetCredentials(db, username, passwd);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
