using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;
using System.Collections.Generic;
using FluentAssertions;
using System.Transactions;
using System.Data;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IDatabaseTest and is intended
    ///to contain all IDatabaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDatabaseTest
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

        internal virtual IDatabase CreateIDatabase()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDatabase target = null;
            return target;
        }

        /// <summary>
        ///A test for AddUser
        ///</summary>
        [TestMethod()]
        public void AddUserTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
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
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            target.ClearCollectionCache();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropCollection
        ///</summary>
        [TestMethod()]
        public void DropCollectionTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
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
            Mongo.DefaultDatabase.Evaluate("return 17").Should().Be(17);
            Mongo.DefaultDatabase.Evaluate("function(test){ return 17 + test; }", 1).Should().Be(18);
            Mongo.DefaultDatabase.Evaluate("function(a,b){ return a + b; }", 2, 3).Should().Be(5);
        }

        /// <summary>
        ///A test for GetCollection
        ///</summary>
        [TestMethod()]
        public void GetCollectionTest()
        {
            //IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            //Uri collectionUri = null; // TODO: Initialize to an appropriate value
            //IDBCollection expected = null; // TODO: Initialize to an appropriate value
            //IDBCollection actual;
            //actual = target.GetCollection(collectionUri);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSisterDatabase
        ///</summary>
        [TestMethod()]
        public void GetSisterDatabaseTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetSisterDatabase(name);
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Binding
        ///</summary>
        [TestMethod()]
        public void BindingTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            IDBBinding actual;
            actual = target.Binding;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CmdCollection
        ///</summary>
        [TestMethod()]
        public void CmdCollectionTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
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
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            IEnumerable<IDBCollection> actual;
            actual = target.Collections;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
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
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = target[collectionUri];
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
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
            //Make sure this collection doesn't exist
            IDBCollection testWritable = Mongo.DefaultDatabase["test"];
            testWritable.Drop();

            IDatabase readonlyDatabase = Mongo.DefaultDatabase_ReadOnly;
            readonlyDatabase.ReadOnly.Should().BeTrue("we just constructed it to be so");

            new Action(() => readonlyDatabase.AddUser("test", new char[] { 'g', 'o' })).ShouldThrow<ReadOnlyException>();

            new Action(() => readonlyDatabase.Drop()).ShouldThrow<ReadOnlyException>();

            new Action(() => readonlyDatabase.CreateCollection("test")).ShouldThrow<ReadOnlyException>();

            new Action(() => readonlyDatabase.GetCollection("test")).ShouldThrow<ReadOnlyException>();

            new Action(() => { IDBCollection test = readonlyDatabase["test"]; }).ShouldThrow<ReadOnlyException>();

            new Action(() => Mongo.DefaultServer.Admin.CopyDatabase(Mongo.DefaultDatabase, readonlyDatabase)).ShouldThrow<ReadOnlyException>();

            new Action(() => readonlyDatabase.AddUser("test", new char[] { 'g', 'o' })).ShouldThrow<ReadOnlyException>();
        }

        /// <summary>
        ///A test for Server
        ///</summary>
        [TestMethod()]
        public void ServerTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            IServer actual;
            actual = target.Server;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.Uri;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
