using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for WhereTest and is intended
    ///to contain all WhereTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WhereTest
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
        ///A test for Field
        ///</summary>
        [TestMethod()]
        public void FieldTest()
        {
            Expression<Func<DBQueryParameter, bool>> selector = null; // TODO: Initialize to an appropriate value
            DBQuery expected = null; // TODO: Initialize to an appropriate value
            DBQuery actual;
            actual = Where.Field(selector);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Fields
        ///</summary>
        [TestMethod()]
        public void FieldsTest()
        {
            Expression<Func<DBQueryParameter, DBQueryParameter, DBQueryParameter, bool>> selector = null; // TODO: Initialize to an appropriate value
            DBQuery expected = null; // TODO: Initialize to an appropriate value
            DBQuery actual;
            actual = Where.Fields(selector);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Fields
        ///</summary>
        [TestMethod()]
        public void FieldsTest1()
        {
            Expression<Func<DBQueryParameter, DBQueryParameter, bool>> selector = null; // TODO: Initialize to an appropriate value
            DBQuery expected = null; // TODO: Initialize to an appropriate value
            DBQuery actual;
            actual = Where.Fields(selector);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
