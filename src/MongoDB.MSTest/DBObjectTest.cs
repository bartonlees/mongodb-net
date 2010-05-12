using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBObjectTest and is intended
    ///to contain all DBObjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBObjectTest
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
        ///A test for DBObject Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectConstructorTest()
        {
            string key1 = string.Empty; // TODO: Initialize to an appropriate value
            object value1 = null; // TODO: Initialize to an appropriate value
            string key2 = string.Empty; // TODO: Initialize to an appropriate value
            object value2 = null; // TODO: Initialize to an appropriate value
            DBObject target = new DBObject(key1, value1, key2, value2);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBObject Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectConstructorTest1()
        {
            string key1 = string.Empty; // TODO: Initialize to an appropriate value
            object value1 = null; // TODO: Initialize to an appropriate value
            string key2 = string.Empty; // TODO: Initialize to an appropriate value
            object value2 = null; // TODO: Initialize to an appropriate value
            string key3 = string.Empty; // TODO: Initialize to an appropriate value
            object value3 = null; // TODO: Initialize to an appropriate value
            DBObject target = new DBObject(key1, value1, key2, value2, key3, value3);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBObject Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectConstructorTest2()
        {
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            DBObject target = new DBObject(key, value);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBObject Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectConstructorTest3()
        {
            DBObject target = new DBObject();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBObject Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectConstructorTest4()
        {
            IDictionary<string, object> obj = null; // TODO: Initialize to an appropriate value
            DBObject target = new DBObject(obj);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Append
        ///</summary>
        [TestMethod()]
        public void AppendTest()
        {
            DBObject target = new DBObject(); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object val = null; // TODO: Initialize to an appropriate value
            DBObject expected = null; // TODO: Initialize to an appropriate value
            DBObject actual;
            actual = target.Append(key, val);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PutAll
        ///</summary>
        [TestMethod()]
        public void PutAllTest()
        {
            DBObject target = new DBObject(); // TODO: Initialize to an appropriate value
            IDictionary<string, object> dbObject = null; // TODO: Initialize to an appropriate value
            target.PutAll(dbObject);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
