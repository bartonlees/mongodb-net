using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Text.RegularExpressions;
namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBQueryTest and is intended
    ///to contain all DBQueryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBQueryTest
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
        ///A test for DBQuery Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryConstructorTest()
        {
            IDictionary<string, object> obj = null; // TODO: Initialize to an appropriate value
            DBQuery target = new DBQuery(obj);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBQuery Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryConstructorTest1()
        {
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            DBQuery target = new DBQuery(key, value);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBQuery Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryConstructorTest2()
        {
            DBQuery target = new DBQuery();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBQuery Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryConstructorTest3()
        {
            string whereClause = string.Empty; // TODO: Initialize to an appropriate value
            DBQuery target = new DBQuery(whereClause);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testWhere1");
            c.Drop();
            c.FindOne().Should().BeNull("the collection is empty after the drop");

            c.Save(new Document("a", 1));
            c.FindOne().Should().NotBeNull("we just added a document");

            c.FindOne("this.a == 1").Should().NotBeNull("the document matches the string query");
            c.FindOne("this.a == 2").Should().BeNull("the document does not match the string query");
        }

        /// <summary>
        ///A test for IsMaster
        ///</summary>
        [TestMethod()]
        public void IsMasterTest()
        {
            DBQuery actual;
            actual = DBQuery.IsMaster;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectAll
        ///</summary>
        [TestMethod()]
        public void SelectAllTest()
        {
            DBQuery actual;
            actual = DBQuery.SelectAll;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
