using MongoDB.Driver.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for PrevErrorTest and is intended
    ///to contain all PrevErrorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrevErrorTest
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
        ///A test for PrevError Constructor
        ///</summary>
        [TestMethod()]
        public void PrevErrorConstructorTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            PrevError target = new PrevError(response);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ElapsedOperations
        ///</summary>
        [TestMethod()]
        public void ElapsedOperationsTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            PrevError target = new PrevError(response); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ElapsedOperations;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ErrorMessage
        ///</summary>
        [TestMethod()]
        public void ErrorMessageTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            PrevError target = new PrevError(response); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ErrorMessage;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
