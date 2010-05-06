using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBCursorOptionsTest and is intended
    ///to contain all DBCursorOptionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBCursorOptionsTest
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
        ///A test for DBCursorOptions Constructor
        ///</summary>
        [TestMethod()]
        public void DBCursorOptionsConstructorTest()
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
            DBCursorOptions target = new DBCursorOptions(collection, selector, returnFields, orderBy, numberToSkip, numberToReturn, limit, explain, snapshot, options, explicitIndexHint);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CollectionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBCollection expected = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            target.Collection = expected;
            actual = target.Collection;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Explain
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ExplainTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Explain = expected;
            actual = target.Explain;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Flags
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void FlagsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            CursorFlags expected = new CursorFlags(); // TODO: Initialize to an appropriate value
            CursorFlags actual;
            target.Flags = expected;
            actual = target.Flags;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Hint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void HintTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBIndex expected = null; // TODO: Initialize to an appropriate value
            IDBIndex actual;
            target.Hint = expected;
            actual = target.Hint;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Limit
        ///</summary>
        [TestMethod()]
        public void LimitTest()
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
            DBCursorOptions target = new DBCursorOptions(collection, selector, returnFields, orderBy, numberToSkip, numberToReturn, limit, explain, snapshot, options, explicitIndexHint); // TODO: Initialize to an appropriate value
            Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> actual;
            target.Limit = expected;
            actual = target.Limit;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumberToReturn
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void NumberToReturnTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.NumberToReturn = expected;
            actual = target.NumberToReturn;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumberToSkip
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void NumberToSkipTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> actual;
            target.NumberToSkip = expected;
            actual = target.NumberToSkip;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OrderBy
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void OrderByTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            DBFieldSet expected = null; // TODO: Initialize to an appropriate value
            DBFieldSet actual;
            target.OrderBy = expected;
            actual = target.OrderBy;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReturnFields
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ReturnFieldsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            DBFieldSet expected = null; // TODO: Initialize to an appropriate value
            DBFieldSet actual;
            target.ReturnFields = expected;
            actual = target.ReturnFields;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Selector
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void SelectorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            DBQuery expected = null; // TODO: Initialize to an appropriate value
            DBQuery actual;
            target.Selector = expected;
            actual = target.Selector;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Snapshot
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void SnapshotTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorOptions_Accessor target = new DBCursorOptions_Accessor(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Snapshot = expected;
            actual = target.Snapshot;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
