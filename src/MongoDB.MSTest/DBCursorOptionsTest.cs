using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

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
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBCursorOptions target = new DBCursorOptions(collection, DBQuery.SelectAll, DBFieldSet.IDKeyFieldSet, DBFieldSet.IDKeyFieldSet, 2, 40, explain:true, flags:CursorFlags.SlaveOK, explicitIndexHint:collection.EnsureIDIndex());
        }


        /// <summary>
        ///A test for Collection
        ///</summary>
        [TestMethod()]
        public void CollectionTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBCursorOptions target = new DBCursorOptions(collection);
            target.Collection.Should().NotBeNull();
        }

        /// <summary>
        ///A test for Explain
        ///</summary>
        [TestMethod()]

        public void ExplainTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBCursorOptions target = new DBCursorOptions(collection, explain:true);
            target.Explain.Should().BeTrue();
        }

        /// <summary>
        ///A test for Flags
        ///</summary>
        [TestMethod()]
        public void FlagsTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBCursorOptions target = new DBCursorOptions(collection, flags:CursorFlags.TailableCursor);
            target.Flags.Should().Be(CursorFlags.TailableCursor);
        }

        /// <summary>
        ///A test for Hint
        ///</summary>
        [TestMethod()]
        public void HintTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            IDBIndex idIndex = collection.EnsureIDIndex();
            DBCursorOptions target = new DBCursorOptions(collection, explicitIndexHint:idIndex);
            target.Hint.Should().Be(idIndex);
        }

        /// <summary>
        ///A test for NumberToReturn
        ///</summary>
        [TestMethod()]
        public void NumberToReturnTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBCursorOptions target = new DBCursorOptions(collection, numberToReturn:3);
            target.NumberToReturn.Should().Be(3);
        }

        /// <summary>
        ///A test for NumberToSkip
        ///</summary>
        [TestMethod()]
        public void NumberToSkipTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBCursorOptions target = new DBCursorOptions(collection, numberToSkip: 3);
            target.NumberToSkip.Should().Be(3);
        }

        /// <summary>
        ///A test for OrderBy
        ///</summary>
        [TestMethod()]
        public void OrderByTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBFieldSet fieldSet = "tim";
            DBCursorOptions target = new DBCursorOptions(collection, orderBy:fieldSet);
            target.OrderBy.Keys.Should().Contain("tim");
        }

        /// <summary>
        ///A test for ReturnFields
        ///</summary>
        [TestMethod()]
        public void ReturnFieldsTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBFieldSet fieldSet = "tim";
            DBCursorOptions target = new DBCursorOptions(collection, returnFields: fieldSet);
            target.ReturnFields.Keys.Should().Contain("tim");
        }

        /// <summary>
        ///A test for Selector
        ///</summary>
        [TestMethod()]
        public void SelectorTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBCursorOptions target = new DBCursorOptions(collection, selector: DBQuery.SelectAll);
            target.Selector.Count.Should().Be(0);
        }

        /// <summary>
        ///A test for Snapshot
        ///</summary>
        [TestMethod()]
        public void SnapshotTest()
        {
            IDBCollection collection = Mongo.DefaultDatabase["test"];
            DBCursorOptions target = new DBCursorOptions(collection, snapshot: true);
            target.Snapshot.Should().BeTrue();
        }
    }
}
