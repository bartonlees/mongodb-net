using MongoDB.Driver.Command.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DatabaseListTest and is intended
    ///to contain all DatabaseListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatabaseListTest
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
        ///A test for DatabaseList Constructor
        ///</summary>
        [TestMethod()]
        public void DatabaseListConstructorTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DatabaseList target = new DatabaseList(response);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DatabaseNames
        ///</summary>
        [TestMethod()]
        public void DatabaseNamesTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DatabaseList target = new DatabaseList(response); // TODO: Initialize to an appropriate value
            IEnumerable<Uri> actual;
            actual = target.DatabaseNames;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Databases
        ///</summary>
        [TestMethod()]
        public void DatabasesTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DatabaseList target = new DatabaseList(response); // TODO: Initialize to an appropriate value
            DBObjectArray actual;
            actual = target.Databases;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SysInfo
        ///</summary>
        [TestMethod()]
        public void SysInfoTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            DatabaseList target = new DatabaseList(response); // TODO: Initialize to an appropriate value
            object actual;
            actual = target.SysInfo;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
