using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBCursorEnumeratorTest and is intended
    ///to contain all DBCursorEnumeratorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBCursorEnumeratorTest
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
        ///A test for DBCursorEnumerator`1 Constructor
        ///</summary>
        public void DBCursorEnumeratorConstructorTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            DBCursor_Accessor<TDoc> cursor = null; // TODO: Initialize to an appropriate value
            DBCursorEnumerator_Accessor<TDoc> target = new DBCursorEnumerator_Accessor<TDoc>(cursor);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void DBCursorEnumeratorConstructorTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call DBCursorEnumeratorConstructorTestHelper<TDoc>() with appropriate " +
                    "type parameters.");
        }

        /// <summary>
        ///A test for CheckDisposed
        ///</summary>
        public void CheckDisposedTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorEnumerator_Accessor<TDoc> target = new DBCursorEnumerator_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
            target.CheckDisposed();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CheckDisposedTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CheckDisposedTestHelper<TDoc>() with appropriate type parameters." +
                    "");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        public void DisposeTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorEnumerator_Accessor<TDoc> target = new DBCursorEnumerator_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
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
        ///A test for MoveNext
        ///</summary>
        public void MoveNextTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorEnumerator_Accessor<TDoc> target = new DBCursorEnumerator_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.MoveNext();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void MoveNextTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call MoveNextTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Reset
        ///</summary>
        public void ResetTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorEnumerator_Accessor<TDoc> target = new DBCursorEnumerator_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
            target.Reset();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ResetTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call ResetTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Current
        ///</summary>
        public void CurrentTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorEnumerator_Accessor<TDoc> target = new DBCursorEnumerator_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
            IDocument actual;
            actual = target.Current;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CurrentTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CurrentTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Cursor
        ///</summary>
        public void CursorTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBCursorEnumerator_Accessor<TDoc> target = new DBCursorEnumerator_Accessor<TDoc>(param0); // TODO: Initialize to an appropriate value
            DBCursor_Accessor<TDoc> expected = null; // TODO: Initialize to an appropriate value
            DBCursor_Accessor<TDoc> actual;
            target.Cursor = expected;
            actual = target.Cursor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CursorTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CursorTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for System.Collections.IEnumerator.Current
        ///</summary>
        public void CurrentTest1Helper<TDoc>()
            where TDoc : class , IDocument
        {
            // Class inheritance across assemblies is not preserved by private accessors. However, a static method AttachShadow() is provided in each private accessor class to transfer a private object from one private accessor class to another.
            Assert.Inconclusive("Class inheritance across assemblies is not preserved by private accessors. Howeve" +
                    "r, a static method AttachShadow() is provided in each private accessor class to " +
                    "transfer a private object from one private accessor class to another.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CurrentTest1()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CurrentTest1Helper<TDoc>() with appropriate type parameters.");
        }
    }
}
