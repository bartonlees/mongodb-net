using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;
using System.Collections.Generic;

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
        [Test]
        public void CreateExplicitlyNonCappedCollection()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo1");
            c.Drop();
            c = Mongo.DefaultDatabase.CreateCollection("foo1", capped:false);
        }
        
        [Test]
        public void CreateCappedCollectionSize100()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo2");
            c.Drop();

            c = Mongo.DefaultDatabase.CreateCollection("foo2", capped: true, size: 100);

            for (int test = 0; test < 30; test++)
            {
                c.Insert(new Document("test", test));
            }
            
            Assert.That(c.Find().Count(), Is.LessThan(10));
        }

        [Test]
        public void CreateCappedCollectionMax2()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo3");
            c.Drop();
            c = Mongo.DefaultDatabase.CreateCollection("foo3", capped: true, max: 2);
            for (int test = 0; test < 30; test++)
            {
                c.Insert(new Document("test", test));
            }
            Assert.That(c.Find().Count(), Is.EqualTo(2));
        }

        [Test]
        public void CreateCappedCollectionMax35Size100()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo3");
            c.Drop();

            c = Mongo.DefaultDatabase.CreateCollection("foo3", capped: true, size: 100, max: 35);
            for (int test = 0; test < 30; test++)
            {
                c.Insert(new Document("test", test));
            }
            Assert.That(c.Find().Count(), Is.LessThan(10));
        }

        [Test]
        public void CreateCappedExceptionNegativeSize()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo4");
            c.Drop();

            Assert.That(() => c = Mongo.DefaultDatabase.CreateCollection("foo4", capped: true, size: -20), Throws.Exception, "Negative size should not be allowed");

        }

        [Test]
        public void CreateCappedExceptionNegativeMax()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo4");
            c.Drop();

            Assert.That(() => c = Mongo.DefaultDatabase.CreateCollection("foo4", capped:true, max:-20), Throws.Exception, "Negative size should not be allowed");
        }

        [Test]
        public void RemoteExpressionEvaluation()
        {
            Assert.That(17, Is.EqualTo(Mongo.DefaultDatabase.Evaluate("return 17")));
            Assert.That(18, Is.EqualTo(Mongo.DefaultDatabase.Evaluate("function(test){ return 17 + test; }", 1)));
            Assert.That(5, Is.EqualTo(Mongo.DefaultDatabase.Evaluate("function(a,b){ return a + b; }", 2, 3)));
        }

        //TODO:LastError/PrevError require transaction support
        [Test]
        public void LastError()
        {

            Mongo.DefaultDatabase.ResetError();
            Assert.That(Mongo.DefaultDatabase.GetLastError().ErrorMessage, Is.Null);

            Mongo.DefaultDatabase.ForceError();

            Assert.That(Mongo.DefaultDatabase.GetLastError().ErrorMessage, Is.Not.Null);

            Mongo.DefaultDatabase.ResetError();
            Assert.That(Mongo.DefaultDatabase.GetLastError().ErrorMessage, Is.Null);
        }

        [Test]
        public void PrevError()
        {

            Mongo.DefaultDatabase.ResetError();

            Assert.IsTrue(Mongo.DefaultDatabase.GetLastError().ErrorMessage == null);
            Assert.IsTrue(Mongo.DefaultDatabase.GetPreviousError().ErrorMessage == null);

            Mongo.DefaultDatabase.ForceError();

            Assert.IsTrue(Mongo.DefaultDatabase.GetLastError().ErrorMessage != null);
            Assert.IsTrue(Mongo.DefaultDatabase.GetPreviousError().ErrorMessage != null);

            Mongo.DefaultDatabase.GetCollection("misc").Insert(new Document("foo", 1));

            Assert.IsTrue(Mongo.DefaultDatabase.GetLastError().ErrorMessage == null);
            Assert.IsTrue(Mongo.DefaultDatabase.GetPreviousError().ErrorMessage != null);

            Mongo.DefaultDatabase.ResetError();

            Assert.IsTrue(Mongo.DefaultDatabase.GetLastError().ErrorMessage == null);
            Assert.IsTrue(Mongo.DefaultDatabase.GetPreviousError().ErrorMessage == null);
        }

        [Test]
        public void CollectionExists()
        {
            IDBCollection coll = Mongo.DefaultDatabase["test"];
            coll.Drop();
            Assert.IsFalse(Mongo.DefaultDatabase.CollectionExists(coll.Uri));
            coll = Mongo.DefaultDatabase.CreateCollection("test");
            Assert.IsTrue(Mongo.DefaultDatabase.CollectionExists(coll.Uri));
        }

        [Test]
        public void ReadOnly()
        {
            //Make sure this collection doesn't exist
            IDBCollection testWritable = Mongo.DefaultDatabase["test"];
            testWritable.Drop();

            Assert.That(Mongo.ReadOnlyDefaultDatabase.ReadOnly, Is.True, "Database.Read");

            Assert.That(()=>Mongo.ReadOnlyDefaultDatabase.AddUser("test", new char[] {'g','o'}), 
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase.Drop(),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase.CreateCollection("test"),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase.GetCollection("test"),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase["test"],
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.DefaultServer.Admin.CopyDatabase(Mongo.DefaultDatabase, Mongo.ReadOnlyDefaultDatabase),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase.AddUser("test", new char[] { 'g', 'o' }),
                Throws.InstanceOf<ReadOnlyException>());

        }


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
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
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
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
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
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDatabase expected = null; // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.GetSisterDatabase(name);
            Assert.AreEqual(expected, actual);
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
            IDatabase target = CreateIDatabase(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
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
