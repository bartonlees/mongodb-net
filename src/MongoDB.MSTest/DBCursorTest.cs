using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBCursorTest and is intended
    ///to contain all DBCursorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBCursorTest
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
        ///A test for DBCursor`1 Constructor
        ///</summary>
        public void DBCursorConstructorTest1Helper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            DBCursor<TDoc> target = new DBCursor<TDoc>(options);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void DBCursorConstructorTest1()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DBCursorConstructorTest1Helper<TDoc>() with appropriate type para" +
                    "meters.");
        }

        /// <summary>
        ///A test for Copy
        ///</summary>
        public void CopyTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            DBCursor<TDoc> target = new DBCursor<TDoc>(options); // TODO: Initialize to an appropriate value
            IDBCursor expected = null; // TODO: Initialize to an appropriate value
            IDBCursor actual;
            actual = target.Copy();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CopyTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CopyTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        public void GetEnumeratorTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            DBCursor<TDoc> target = new DBCursor<TDoc>(options); // TODO: Initialize to an appropriate value
            IEnumerator<IDocument> expected = null; // TODO: Initialize to an appropriate value
            IEnumerator<IDocument> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call GetEnumeratorTestHelper<TDoc>() with appropriate type parameters." +
                    "");
        }

        /// <summary>
        ///A test for System.Collections.Generic.IEnumerable<MongoDB.Driver.IDocument>.GetEnumerator
        ///</summary>
        public void GetEnumeratorTest1Helper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            IEnumerable<IDocument> target = new DBCursor<TDoc>(options); // TODO: Initialize to an appropriate value
            IEnumerator<IDocument> expected = null; // TODO: Initialize to an appropriate value
            IEnumerator<IDocument> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void GetEnumeratorTest1()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call GetEnumeratorTest1Helper<TDoc>() with appropriate type parameters" +
                    ".");
        }

        /// <summary>
        ///A test for System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        public void GetEnumeratorTest2Helper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            IEnumerable target = new DBCursor<TDoc>(options); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void GetEnumeratorTest2()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call GetEnumeratorTest2Helper<TDoc>() with appropriate type parameters" +
                    ".");
        }

        /// <summary>
        ///A test for System.IDisposable.Dispose
        ///</summary>
        public void DisposeTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            IDisposable target = new DBCursor<TDoc>(options); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void DisposeTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DisposeTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for CursorID
        ///</summary>
        public void CursorIDTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            DBCursor<TDoc> target = new DBCursor<TDoc>(options); // TODO: Initialize to an appropriate value
            Nullable<long> expected = new Nullable<long>(); // TODO: Initialize to an appropriate value
            Nullable<long> actual;
            target.CursorID = expected;
            actual = target.CursorID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CursorIDTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CursorIDTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for DocumentsT
        ///</summary>
        public void DocumentsTTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            DBCursor<TDoc> target = new DBCursor<TDoc>(options); // TODO: Initialize to an appropriate value
            IEnumerable<TDoc> actual;
            actual = target.DocumentsT;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void DocumentsTTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DocumentsTTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for HasMore
        ///</summary>
        public void HasMoreTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            DBCursor<TDoc> target = new DBCursor<TDoc>(options); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasMore;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void HasMoreTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call HasMoreTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Options
        ///</summary>
        public void OptionsTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursor_Accessor<TDoc> target = new DBCursor_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
            DBCursorOptions expected = null; // TODO: Initialize to an appropriate value
            DBCursorOptions actual;
            target.Options = expected;
            actual = target.Options;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void OptionsTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call OptionsTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for DBCursor Constructor
        ///</summary>
        [TestMethod()]
        public void DBCursorConstructorTest()
        {
            DBCursorOptions options = null; // TODO: Initialize to an appropriate value
            DBCursor target = new DBCursor(options);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CleanupCursors
        ///</summary>
        [TestMethod()]
        public void CleanupCursorsTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            DBCursor.CleanupCursors(collection);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
