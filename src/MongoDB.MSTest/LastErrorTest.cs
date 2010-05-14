using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for LastErrorTest and is intended
    ///to contain all LastErrorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LastErrorTest
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
        ///A test for LastError Constructor
        ///</summary>
        [TestMethod()]
        public void LastErrorConstructorTest()
        {
            IDBObject res = null; // TODO: Initialize to an appropriate value
            LastError target = new LastError(res);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Code
        ///</summary>
        [TestMethod()]
        public void CodeTest()
        {
            IDBObject res = null; // TODO: Initialize to an appropriate value
            LastError target = new LastError(res); // TODO: Initialize to an appropriate value
            DBError.Code actual;
            actual = target.Code;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ErrorMessage
        ///</summary>
        [TestMethod()]
        public void ErrorMessageTest()
        {
            IDBObject res = null; // TODO: Initialize to an appropriate value
            LastError target = new LastError(res); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ErrorMessage;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumberOfErrors
        ///</summary>
        [TestMethod()]
        public void NumberOfErrorsTest()
        {
            IDBObject res = null; // TODO: Initialize to an appropriate value
            LastError target = new LastError(res); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NumberOfErrors;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
