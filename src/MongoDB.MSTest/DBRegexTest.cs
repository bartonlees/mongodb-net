#pragma warning disable 0618
#pragma warning disable 0612
using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBRegexTest and is intended
    ///to contain all DBRegexTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBRegexTest
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
        ///A test for DBRegex Constructor
        ///</summary>
        [TestMethod()]
        public void DBRegexConstructorTest()
        {
            string p = string.Empty; // TODO: Initialize to an appropriate value
            string o = string.Empty; // TODO: Initialize to an appropriate value
            DBRegex target = new DBRegex(p, o);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for getOptions
        ///</summary>
        [TestMethod()]
        public void getOptionsTest()
        {
            string p = string.Empty; // TODO: Initialize to an appropriate value
            string o = string.Empty; // TODO: Initialize to an appropriate value
            DBRegex target = new DBRegex(p, o); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetOptions();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getPattern
        ///</summary>
        [TestMethod()]
        public void getPatternTest()
        {
            string p = string.Empty; // TODO: Initialize to an appropriate value
            string o = string.Empty; // TODO: Initialize to an appropriate value
            DBRegex target = new DBRegex(p, o); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Pattern;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
