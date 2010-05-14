using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IDBMessageTest and is intended
    ///to contain all IDBMessageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBMessageTest
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


        internal virtual IDBMessage CreateIDBMessage()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBMessage target = null;
            return target;
        }

        /// <summary>
        ///A test for MessageLength
        ///</summary>
        [TestMethod()]
        public void MessageLengthTest()
        {
            IDBMessage target = CreateIDBMessage(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MessageLength;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpCode
        ///</summary>
        [TestMethod()]
        public void OpCodeTest()
        {
            IDBMessage target = CreateIDBMessage(); // TODO: Initialize to an appropriate value
            Operation actual;
            actual = target.OpCode;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RequestID
        ///</summary>
        [TestMethod()]
        public void RequestIDTest()
        {
            IDBMessage target = CreateIDBMessage(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.RequestID = expected;
            actual = target.RequestID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResponseTo
        ///</summary>
        [TestMethod()]
        public void ResponseToTest()
        {
            IDBMessage target = CreateIDBMessage(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ResponseTo;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
