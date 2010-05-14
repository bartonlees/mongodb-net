using MongoDB.Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for JsonIDBCollectionExtensionsTest and is intended
    ///to contain all JsonIDBCollectionExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JsonIDBCollectionExtensionsTest
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
        ///A test for FindContractDocumentByID
        ///</summary>
        public void FindContractDocumentByIDTestHelper<T>()
            where T : new()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            object id = null; // TODO: Initialize to an appropriate value
            DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            bool explain = false; // TODO: Initialize to an appropriate value
            bool snapshot = false; // TODO: Initialize to an appropriate value
            CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            ContractDocument<T> expected = null; // TODO: Initialize to an appropriate value
            ContractDocument<T> actual;
            actual = JsonIDBCollectionExtensions.FindContractDocumentByID<T>(collection, id, returnFields, explain, snapshot, options);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void FindContractDocumentByIDTest()
        {
            FindContractDocumentByIDTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for FindContractDocuments
        ///</summary>
        public void FindContractDocumentsTestHelper<T>()
            where T : new()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            DBFieldSet orderBy = null; // TODO: Initialize to an appropriate value
            Nullable<int> numberToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> numberToReturn = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> limit = new Nullable<int>(); // TODO: Initialize to an appropriate value
            bool explain = false; // TODO: Initialize to an appropriate value
            bool snapshot = false; // TODO: Initialize to an appropriate value
            CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            IEnumerable<ContractDocument<T>> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<ContractDocument<T>> actual;
            actual = JsonIDBCollectionExtensions.FindContractDocuments<T>(collection, selector, returnFields, orderBy, numberToSkip, numberToReturn, limit, explain, snapshot, options, explicitIndexHint);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void FindContractDocumentsTest()
        {
            FindContractDocumentsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for FindOneContractDocument
        ///</summary>
        public void FindOneContractDocumentTestHelper<T>()
            where T : new()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            Nullable<int> numToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            bool explain = false; // TODO: Initialize to an appropriate value
            CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            ContractDocument<T> expected = null; // TODO: Initialize to an appropriate value
            ContractDocument<T> actual;
            actual = JsonIDBCollectionExtensions.FindOneContractDocument<T>(collection, selector, returnFields, numToSkip, explain, options, explicitIndexHint);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void FindOneContractDocumentTest()
        {
            FindOneContractDocumentTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetContractDocumentCursor
        ///</summary>
        public void GetContractDocumentCursorTestHelper<T>()
            where T : new()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBQuery selector = null; // TODO: Initialize to an appropriate value
            DBFieldSet returnFields = null; // TODO: Initialize to an appropriate value
            DBFieldSet orderBy = null; // TODO: Initialize to an appropriate value
            Nullable<int> numberToSkip = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> numberToReturn = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> limit = new Nullable<int>(); // TODO: Initialize to an appropriate value
            bool explain = false; // TODO: Initialize to an appropriate value
            bool snapshot = false; // TODO: Initialize to an appropriate value
            CursorFlags options = new CursorFlags(); // TODO: Initialize to an appropriate value
            IDBIndex explicitIndexHint = null; // TODO: Initialize to an appropriate value
            IDBCursor<ContractDocument<T>> expected = null; // TODO: Initialize to an appropriate value
            IDBCursor<ContractDocument<T>> actual;
            actual = JsonIDBCollectionExtensions.GetContractDocumentCursor<T>(collection, selector, returnFields, orderBy, numberToSkip, numberToReturn, limit, explain, snapshot, options, explicitIndexHint);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetContractDocumentCursorTest()
        {
            GetContractDocumentCursorTestHelper<GenericParameterHelper>();
        }
    }
}
