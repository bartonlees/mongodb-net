using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IDBCollectionTest and is intended
    ///to contain all IDBCollectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBCollectionTest
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


        internal virtual IDBCollection CreateIDBCollection()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBCollection target = null;
            return target;
        }

        /// <summary>
        ///A test for ClearIndexCache
        ///</summary>
        [TestMethod()]
        public void ClearIndexCacheTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            target.ClearIndexCache();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropIndex
        ///</summary>
        [TestMethod()]
        public void DropIndexTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            DBFieldSet indexKeyFieldSet = null; // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            bool unique = false; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = target.EnsureIndex(indexKeyFieldSet, name, unique);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIndex
        ///</summary>
        [TestMethod()]
        public void GetIndexTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Remove(document, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TryInsert
        ///</summary>
        [TestMethod()]
        public void TryInsertTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryRemove(document, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryUpdate
        ///</summary>
        [TestMethod()]
        public void TryUpdateTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
        ///A test for Database
        ///</summary>
        [TestMethod()]
        public void DatabaseTest()
        {
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
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
            IDBCollection target = CreateIDBCollection(); // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.Uri;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
