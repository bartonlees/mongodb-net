using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MongoDB.Driver.Command;
using FluentAssertions;
using System.Transactions;
using System.Linq;

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
            IDBCollection coll1 = Mongo.DefaultDatabase["test"];
            Uri collUri = coll1.Uri;
            coll1.Drop();
            Assert.IsFalse(Mongo.DefaultDatabase.CollectionExists(collUri));

            IDBCollection coll2 = Mongo.DefaultDatabase.CreateCollection("test");
            Assert.IsTrue(Mongo.DefaultDatabase.CollectionExists(collUri));
        }

        /// <summary>
        ///A test for CreateCollection
        ///</summary>
        [TestMethod()]
        public void CreateCollectionTest()
        {
            IDBCollection foo1 = Mongo.DefaultDatabase.GetCollection("foo1");
            foo1.Drop();
            foo1 = Mongo.DefaultDatabase.CreateCollection("foo1", capped: false);

            IDBCollection foo2 = Mongo.DefaultDatabase.GetCollection("foo2");
            foo2.Drop();

            foo2 = Mongo.DefaultDatabase.CreateCollection("foo2", capped: true, size: 100);

            for (int test = 0; test < 30; test++)
            {
                foo2.Insert(new Document("test", test));
            }

            foo2.Find().Count().Should().BeLessThan(10);

            IDBCollection foo3 = Mongo.DefaultDatabase.GetCollection("foo3");
            foo3.Drop();
            foo3 = Mongo.DefaultDatabase.CreateCollection("foo3", capped: true, max: 2);
            for (int test = 0; test < 30; test++)
            {
                foo3.Insert(new Document("test", test));
            }
            foo3.Find().Count().Should().Be(2);

            IDBCollection foo4 = Mongo.DefaultDatabase.GetCollection("foo4");
            foo4.Drop();

            foo4 = Mongo.DefaultDatabase.CreateCollection("foo4", capped: true, size: 100, max: 35);
            for (int test = 0; test < 30; test++)
            {
                foo4.Insert(new Document("test", test));
            }
            foo4.Find().Count().Should().BeLessThan(10);

            IDBCollection foo5 = Mongo.DefaultDatabase.GetCollection("foo5");
            foo5.Drop();

            new Action(() => foo5 = Mongo.DefaultDatabase.CreateCollection("foo5", capped: true, size: -20)).ShouldThrow<Exception>("negative size should not be allowed");

            IDBCollection foo6 = Mongo.DefaultDatabase.GetCollection("foo6");
            foo6.Drop();

            new Action(() => foo6 = Mongo.DefaultDatabase.CreateCollection("foo6", capped: true, max: -20)).ShouldThrow<Exception>("Negative max should not be allowed");
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
        [TestMethod]
        public void LastErrorTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                IDatabase db = Mongo.DefaultDatabase;
                db.ResetError();
                db.GetLastError().ErrorMessage.Should().BeNull("we just reset errors");

                db.ForceError();
                db.GetLastError().ErrorMessage.Should().NotBeNull("we just forced an error"); ;

                db.ResetError();
                db.GetLastError().ErrorMessage.Should().BeNull("we just reset errors");
            }
        }

        /// <summary>
        ///A test for GetPreviousError
        ///</summary>
        [TestMethod]
        public void PrevErrorTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                IDatabase db = Mongo.DefaultDatabase;
                db.ResetError();

                db.GetLastError().ErrorMessage.Should().BeNull("we just reset errors");
                db.GetPreviousError().ErrorMessage.Should().BeNull("we just reset errors");

                db.ForceError();

                db.GetLastError().ErrorMessage.Should().NotBeNull("we just forced an error");
                db.GetPreviousError().ErrorMessage.Should().BeNull("we are still reset");

                Mongo.DefaultDatabase.GetCollection("misc").Insert(new Document("foo", 1));

                db.GetLastError().ErrorMessage.Should().BeNull("we had a successful operation");
                db.GetPreviousError().ErrorMessage.Should().NotBeNull("the last is now the previous");

                Mongo.DefaultDatabase.ResetError();

                db.GetLastError().ErrorMessage.Should().BeNull("we just reset errors");
                db.GetPreviousError().ErrorMessage.Should().BeNull("we just reset errors");
            }
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
