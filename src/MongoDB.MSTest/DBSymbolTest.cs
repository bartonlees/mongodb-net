using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBSymbolTest and is intended
    ///to contain all DBSymbolTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBSymbolTest
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
        ///A test for DBSymbol Constructor
        ///</summary>
        [TestMethod()]
        public void DBSymbolConstructorTest()
        {
            string s = string.Empty; // TODO: Initialize to an appropriate value
            DBSymbol target = new DBSymbol(s);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Symbol
        ///</summary>
        [TestMethod()]
        //
        public void SymbolTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBSymbol_Accessor target = new DBSymbol_Accessor(param0); // TODO: Initialize to an appropriate value
            //string expected = string.Empty; // TODO: Initialize to an appropriate value
            //string actual;
            //target.Symbol = expected;
            //actual = target.Symbol;
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
