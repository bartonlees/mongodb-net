using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IDBCollectionExtensionsTest and is intended
    ///to contain all IDBCollectionExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBCollectionExtensionsTest
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
        ///A test for CreateIndex
        ///</summary>
        [TestMethod()]
        public void CreateIndexTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBFieldSet keyFieldSet = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.CreateIndex(collection, keyFieldSet);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Distinct
        ///</summary>
        [TestMethod()]
        public void DistinctTest()
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //string keyField = string.Empty; // TODO: Initialize to an appropriate value
            //DBQuery selector = null; // TODO: Initialize to an appropriate value
            //IList expected = null; // TODO: Initialize to an appropriate value
            //IList actual;
            //actual = IDBCollectionExtensions.Distinct(collection, keyField, selector);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Drop
        ///</summary>
        [TestMethod()]
        public void DropTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Drop(collection);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropAllIndexes
        ///</summary>
        [TestMethod()]
        public void DropAllIndexesTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.DropAllIndexes(collection);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropIndex
        ///</summary>
        [TestMethod()]
        public void DropIndexTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBFieldSet keyFieldSet = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.DropIndex(collection, keyFieldSet);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DropIndex
        ///</summary>
        [TestMethod()]
        public void DropIndexTest1()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.DropIndex(collection, name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnsureIndex
        ///</summary>
        [TestMethod()]
        public void EnsureIndexTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBFieldSet keyFieldSet = null; // TODO: Initialize to an appropriate value
            bool force = false; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = IDBCollectionExtensions.EnsureIndex(collection, keyFieldSet, force);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnsureIndex
        ///</summary>
        [TestMethod()]
        public void EnsureIndexTest1()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBFieldSet keyFieldSet = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.EnsureIndex(collection, keyFieldSet);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnsureIndex
        ///</summary>
        [TestMethod()]
        public void EnsureIndexTest2()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBFieldSet indexKeysFieldSet = null; // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = IDBCollectionExtensions.EnsureIndex(collection, indexKeysFieldSet, name);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnsureIndex
        ///</summary>
        [TestMethod()]
        public void EnsureIndexTest3()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBFieldSet indexKeyFieldSet = null; // TODO: Initialize to an appropriate value
            string indexUri = string.Empty; // TODO: Initialize to an appropriate value
            bool unique = false; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = IDBCollectionExtensions.EnsureIndex(collection, indexKeyFieldSet, indexUri, unique);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Find
        ///</summary>
        public void FindTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //DBQuery selector = null; // TODO: Initialize to an appropriate value
            //DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            //DBFieldSet orderBy = null; // TODO: Initialize to an appropriate value
            //Nullable<int> numberToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //Nullable<int> numberToReturn = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //Nullable<int> limit = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //bool explain = false; // TODO: Initialize to an appropriate value
            //bool snapshot = false; // TODO: Initialize to an appropriate value
            //CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            //IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            //IEnumerable<TDoc> expected = null; // TODO: Initialize to an appropriate value
            //IEnumerable<TDoc> actual;
            //actual = IDBCollectionExtensions.Find<TDoc>(collection, selector, returnFields, orderBy, numberToSkip, numberToReturn, limit, explain, snapshot, options, explicitIndexHint);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void FindTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call FindTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Find
        ///</summary>
        [TestMethod()]
        public void FindTest1()
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //DBQuery selector = null; // TODO: Initialize to an appropriate value
            //DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            //DBFieldSet orderBy = null; // TODO: Initialize to an appropriate value
            //Nullable<int> numberToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //Nullable<int> numberToReturn = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //Nullable<int> limit = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //bool explain = false; // TODO: Initialize to an appropriate value
            //bool snapshot = false; // TODO: Initialize to an appropriate value
            //CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            //IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            //IEnumerable<IDocument> expected = null; // TODO: Initialize to an appropriate value
            //IEnumerable<IDocument> actual;
            //actual = IDBCollectionExtensions.Find(collection, selector, returnFields, orderBy, numberToSkip, numberToReturn, limit, explain, snapshot, options, explicitIndexHint);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindByID
        ///</summary>
        [TestMethod()]
        public void FindByIDTest()
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //object id = null; // TODO: Initialize to an appropriate value
            //DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            //bool explain = false; // TODO: Initialize to an appropriate value
            //bool snapshot = false; // TODO: Initialize to an appropriate value
            //CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            //IDocument expected = null; // TODO: Initialize to an appropriate value
            //IDocument actual;
            //actual = IDBCollectionExtensions.FindByID(collection, id, returnFields, explain, snapshot, options);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindByID
        ///</summary>
        public void FindByIDTest1Helper<TDoc>()
            where TDoc : class , IDocument
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //object id = null; // TODO: Initialize to an appropriate value
            //DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            //bool explain = false; // TODO: Initialize to an appropriate value
            //bool snapshot = false; // TODO: Initialize to an appropriate value
            //CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            //TDoc expected = null; // TODO: Initialize to an appropriate value
            //TDoc actual;
            //actual = IDBCollectionExtensions.FindByID<TDoc>(collection, id, returnFields, explain, snapshot, options);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void FindByIDTest1()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call FindByIDTest1Helper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for FindOne
        ///</summary>
        public void FindOneTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //DBQuery selector = null; // TODO: Initialize to an appropriate value
            //DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            //Nullable<int> numToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //bool explain = false; // TODO: Initialize to an appropriate value
            //bool snapshot = false; // TODO: Initialize to an appropriate value
            //CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            //IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            //TDoc expected = null; // TODO: Initialize to an appropriate value
            //TDoc actual;
            //actual = IDBCollectionExtensions.FindOne<TDoc>(collection, selector, returnFields, numToSkip, explain, snapshot, options, explicitIndexHint);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void FindOneTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call FindOneTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for FindOne
        ///</summary>
        [TestMethod()]
        public void FindOneTest1()
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //DBQuery selector = null; // TODO: Initialize to an appropriate value
            //DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            //Nullable<int> numToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //bool explain = false; // TODO: Initialize to an appropriate value
            //CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            //IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            //IDocument expected = null; // TODO: Initialize to an appropriate value
            //IDocument actual;
            //actual = IDBCollectionExtensions.FindOne(collection, selector, returnFields, numToSkip, explain, options, explicitIndexHint);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCollection
        ///</summary>
        [TestMethod()]
        public void GetCollectionTest()
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //string collectionName = string.Empty; // TODO: Initialize to an appropriate value
            //IDBCollection expected = null; // TODO: Initialize to an appropriate value
            //IDBCollection actual;
            //actual = IDBCollectionExtensions.GetCollection(collection, collectionName);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCount
        ///</summary>
        [TestMethod()]
        public void GetCountTest()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testCount");
            c.Drop();
            Assert.IsNull(c.FindOne());
            c.GetCount().Should().Be(0);
            for (int test = 0; test < 100; test++)
            {
                c.Insert(new Document("test", test));
            }
            c.GetCount().Should().Be(100);
        }

        /// <summary>
        ///A test for GetCursor
        ///</summary>
        [TestMethod()]
        public void GetCursorTest()
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //DBQuery selector = null; // TODO: Initialize to an appropriate value
            //DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            //DBFieldSet orderBy = null; // TODO: Initialize to an appropriate value
            //Nullable<int> numberToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //Nullable<int> numberToReturn = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //Nullable<int> limit = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //bool explain = false; // TODO: Initialize to an appropriate value
            //bool snapshot = false; // TODO: Initialize to an appropriate value
            //CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            //IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            //IDBCursor<Document> expected = null; // TODO: Initialize to an appropriate value
            //IDBCursor<Document> actual;
            //actual = IDBCollectionExtensions.GetCursor(collection, selector, returnFields, orderBy, numberToSkip, numberToReturn, limit, explain, snapshot, options, explicitIndexHint);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCursor
        ///</summary>
        public void GetCursorTest1Helper<TDoc>()
            where TDoc : class , IDocument
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //DBQuery selector = null; // TODO: Initialize to an appropriate value
            //DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            //DBFieldSet orderBy = null; // TODO: Initialize to an appropriate value
            //Nullable<int> numberToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //Nullable<int> numberToReturn = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //Nullable<int> limit = new Nullable<int>(); // TODO: Initialize to an appropriate value
            //bool explain = false; // TODO: Initialize to an appropriate value
            //bool snapshot = false; // TODO: Initialize to an appropriate value
            //CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            //IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            //IDBCursor<TDoc> expected = null; // TODO: Initialize to an appropriate value
            //IDBCursor<TDoc> actual;
            //actual = IDBCollectionExtensions.GetCursor<TDoc>(collection, selector, returnFields, orderBy, numberToSkip, numberToReturn, limit, explain, snapshot, options, explicitIndexHint);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetCursorTest1()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call GetCursorTest1Helper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for GetIndex
        ///</summary>
        [TestMethod()]
        public void GetIndexTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            string indexUri = string.Empty; // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            actual = IDBCollectionExtensions.GetIndex(collection, indexUri);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIndexInfo
        ///</summary>
        [TestMethod()]
        public void GetIndexInfoTest()
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //IEnumerable<IDBObject> expected = null; // TODO: Initialize to an appropriate value
            //IEnumerable<IDBObject> actual;
            //actual = IDBCollectionExtensions.GetIndexInfo(collection);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Group
        ///</summary>
        [TestMethod()]
        public void GroupTest()
        {
            //IDBCollection collection = null; // TODO: Initialize to an appropriate value
            //DBFieldSet key = null; // TODO: Initialize to an appropriate value
            //DBQuery cond = null; // TODO: Initialize to an appropriate value
            //IDocument initial = null; // TODO: Initialize to an appropriate value
            //string reduce = string.Empty; // TODO: Initialize to an appropriate value
            //IDBObject expected = null; // TODO: Initialize to an appropriate value
            //IDBObject actual;
            //actual = IDBCollectionExtensions.Group(collection, key, cond, initial, reduce);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDocument[] documents = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Insert(collection, documents);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest1()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Insert(collection, document);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MapReduce
        ///</summary>
        [TestMethod()]
        public void MapReduceTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            string map = string.Empty; // TODO: Initialize to an appropriate value
            string reduce = string.Empty; // TODO: Initialize to an appropriate value
            string outputCollection = string.Empty; // TODO: Initialize to an appropriate value
            DBQuery query = null; // TODO: Initialize to an appropriate value
            MapReduceInfo expected = null; // TODO: Initialize to an appropriate value
            MapReduceInfo actual;
            actual = IDBCollectionExtensions.MapReduce(collection, map, reduce, outputCollection, query);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MapReduce
        ///</summary>
        [TestMethod()]
        public void MapReduceTest1()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBQuery command = null; // TODO: Initialize to an appropriate value
            MapReduceInfo expected = null; // TODO: Initialize to an appropriate value
            MapReduceInfo actual;
            actual = IDBCollectionExtensions.MapReduce(collection, command);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Rename
        ///</summary>
        [TestMethod()]
        public void RenameTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            Uri newName = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Rename(collection, newName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Rename
        ///</summary>
        [TestMethod()]
        public void RenameTest1()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            string newName = string.Empty; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Rename(collection, newName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Save(collection, document);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TryInsert
        ///</summary>
        [TestMethod()]
        public void TryInsertTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDocument[] documents = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IDBCollectionExtensions.TryInsert(collection, documents);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryInsert
        ///</summary>
        [TestMethod()]
        public void TryInsertTest1()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IDBCollectionExtensions.TryInsert(collection, document, checkError);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TrySave
        ///</summary>
        [TestMethod()]
        public void TrySaveTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IDBCollectionExtensions.TrySave(collection, document, checkError);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBModifier modifier = null; // TODO: Initialize to an appropriate value
            bool multi = false; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Update(collection, modifier, multi);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest1()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            bool upsert = false; // TODO: Initialize to an appropriate value
            bool multi = false; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Update(collection, document, upsert, multi);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest2()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            DBModifier modifier = null; // TODO: Initialize to an appropriate value
            bool multi = false; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Update(collection, selector, modifier, multi);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest3()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            IDocument document = null; // TODO: Initialize to an appropriate value
            bool upsert = false; // TODO: Initialize to an appropriate value
            bool multi = false; // TODO: Initialize to an appropriate value
            IDBCollectionExtensions.Update(collection, selector, document, upsert, multi);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
