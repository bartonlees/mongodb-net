using MongoDB.Driver.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for GetMoreTest and is intended
    ///to contain all GetMoreTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GetMoreTest
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
        ///A test for GetMore Constructor
        ///</summary>
        [TestMethod()]
        public void GetMoreConstructorTest()
        {
            IDBCursor cursor = null; // TODO: Initialize to an appropriate value
            GetMore target = new GetMore(cursor);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for WriteBody
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void WriteBodyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GetMore_Accessor target = new GetMore_Accessor(param0); // TODO: Initialize to an appropriate value
            WireProtocolWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteBody(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Cursor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CursorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            GetMore_Accessor target = new GetMore_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBCursor expected = null; // TODO: Initialize to an appropriate value
            IDBCursor actual;
            target.Cursor = expected;
            actual = target.Cursor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
