using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBCollectionTest and is intended
    ///to contain all DBCollectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBCollectionTest
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
        ///A test for DBCollection Constructor
        ///</summary>
        [TestMethod()]
        public void DBCollectionConstructorTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ClearIndexCache
        ///</summary>
        [TestMethod()]
        public void ClearIndexCacheTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            target.ClearIndexCache();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ConditionallyEnsureIDIndex
        ///</summary>
        [TestMethod()]
        public void ConditionallyEnsureIDIndexTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IDBObject obj = null; // TODO: Initialize to an appropriate value
            target.ConditionallyEnsureIDIndex(obj);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropIndex
        ///</summary>
        [TestMethod()]
        public void DropIndexTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IDBIndex index = null; // TODO: Initialize to an appropriate value
            target.DropIndex(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnsureIDIndex
        ///</summary>
        [TestMethod()]
        public void EnsureIDIndexTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = target.EnsureIDIndex();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnsureIndex
        ///</summary>
        [TestMethod()]
        public void EnsureIndexTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            DBFieldSet indexKeyFieldSet = null; // TODO: Initialize to an appropriate value
            Uri indexUri = null; // TODO: Initialize to an appropriate value
            bool unique = false; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = target.EnsureIndex(indexKeyFieldSet, indexUri, unique);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            object obj = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IEnumerator<IDocument> expected = null; // TODO: Initialize to an appropriate value
            IEnumerator<IDocument> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIndex
        ///</summary>
        [TestMethod()]
        public void GetIndexTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            Uri indexUri = null; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = target.GetIndex(indexUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetMore
        ///</summary>
        public void GetMoreTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IDBCursor<TDoc> cursor = null; // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.GetMore<TDoc>(cursor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetMoreTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call GetMoreTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> documents = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Insert(documents, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Query
        ///</summary>
        public void QueryTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IDBCursor<TDoc> cursor = null; // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.Query<TDoc>(cursor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void QueryTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call QueryTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IDocument o = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Remove(o, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void GetEnumeratorTest1()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            IEnumerable target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryInsert
        ///</summary>
        [TestMethod()]
        public void TryInsertTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> documents = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryInsert(documents, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryRemove
        ///</summary>
        [TestMethod()]
        public void TryRemoveTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IDocument o = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryRemove(o, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryUpdate
        ///</summary>
        [TestMethod()]
        public void TryUpdateTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            DBModifier modifier = null; // TODO: Initialize to an appropriate value
            bool upsert = false; // TODO: Initialize to an appropriate value
            bool multi = false; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryUpdate(selector, document, modifier, upsert, multi, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            DBModifier modifier = null; // TODO: Initialize to an appropriate value
            bool upsert = false; // TODO: Initialize to an appropriate value
            bool multi = false; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Update(selector, document, modifier, upsert, multi, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for _EnsureIndex
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void _EnsureIndexTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCollection_Accessor target = new DBCollection_Accessor(param0); // TODO: Initialize to an appropriate value
            DBIndex_Accessor index = null; // TODO: Initialize to an appropriate value
            target._EnsureIndex(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Database
        ///</summary>
        [TestMethod()]
        public void DatabaseTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IDatabase actual;
            actual = target.Database;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FullName
        ///</summary>
        [TestMethod()]
        public void FullNameTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.FullName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IndexHintFieldSets
        ///</summary>
        [TestMethod()]
        public void IndexHintFieldSetsTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IEnumerable<DBFieldSet> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<DBFieldSet> actual;
            target.IndexHintFieldSets = expected;
            actual = target.IndexHintFieldSets;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Indexes
        ///</summary>
        [TestMethod()]
        public void IndexesTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            IEnumerable<IDBIndex> actual;
            actual = target.Indexes;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
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
            Database database = null; // TODO: Initialize to an appropriate value
            Uri collectionUri = null; // TODO: Initialize to an appropriate value
            DBCollection target = new DBCollection(database, collectionUri); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ReadOnly;
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
            DBCollection_Accessor target = new DBCollection_Accessor(param0); // TODO: Initialize to an appropriate value
            Uri expected = null; // TODO: Initialize to an appropriate value
            Uri actual;
            target.Uri = expected;
            actual = target.Uri;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _Database
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void _DatabaseTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCollection_Accessor target = new DBCollection_Accessor(param0); // TODO: Initialize to an appropriate value
            Database_Accessor expected = null; // TODO: Initialize to an appropriate value
            Database_Accessor actual;
            target._Database = expected;
            actual = target._Database;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
