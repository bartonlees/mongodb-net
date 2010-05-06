using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IDBCursorTest and is intended
    ///to contain all IDBCursorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBCursorTest
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
        ///A test for DocumentsT
        ///</summary>
        public void DocumentsTTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBCursor<TDoc> target = CreateIDBCursor<TDoc>(); // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.DocumentsT;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual IDBCursor<TDoc> CreateIDBCursor<TDoc>()
            where TDoc : class , IDocument
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBCursor<TDoc> target = null;
            return target;
        }

        [TestMethod()]
        public void DocumentsTTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DocumentsTTestHelper<TDoc>() with appropriate type parameters.");
        }

        internal virtual IDBCursor CreateIDBCursor()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBCursor target = null;
            return target;
        }

        /// <summary>
        ///A test for Copy
        ///</summary>
        [TestMethod()]
        public void CopyTest()
        {
            IDBCursor target = CreateIDBCursor(); // TODO: Initialize to an appropriate value
            IDBCursor expected = null; // TODO: Initialize to an appropriate value
            IDBCursor actual;
            actual = target.Copy();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CursorID
        ///</summary>
        [TestMethod()]
        public void CursorIDTest()
        {
            IDBCursor target = CreateIDBCursor(); // TODO: Initialize to an appropriate value
            Nullable<long> expected = new Nullable<long>(); // TODO: Initialize to an appropriate value
            Nullable<long> actual;
            target.CursorID = expected;
            actual = target.CursorID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasMore
        ///</summary>
        [TestMethod()]
        public void HasMoreTest()
        {
            IDBCursor target = CreateIDBCursor(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasMore;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Options
        ///</summary>
        [TestMethod()]
        public void OptionsTest()
        {
            IDBCursor target = CreateIDBCursor(); // TODO: Initialize to an appropriate value
            DBCursorOptions actual;
            actual = target.Options;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
