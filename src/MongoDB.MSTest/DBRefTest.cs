using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBRefTest and is intended
    ///to contain all DBRefTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBRefTest
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
        ///A test for DBRef Constructor
        ///</summary>
        [TestMethod()]
        public void DBRefConstructorTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            object id = null; // TODO: Initialize to an appropriate value
            DBRef target = new DBRef(collection, id);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Fetch
        ///</summary>
        [TestMethod()]
        public void FetchTest()
        {
            IDBCollection collection = null; // TODO: Initialize to an appropriate value
            object id = null; // TODO: Initialize to an appropriate value
            DBRef target = new DBRef(collection, id); // TODO: Initialize to an appropriate value
            IDocument expected = null; // TODO: Initialize to an appropriate value
            IDocument actual;
            actual = target.Fetch();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CollectionTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBRef_Accessor target = new DBRef_Accessor(param0); // TODO: Initialize to an appropriate value
            //IDBCollection expected = null; // TODO: Initialize to an appropriate value
            //IDBCollection actual;
            //target.Collection = expected;
            //actual = target.Collection;
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void IDTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBRef_Accessor target = new DBRef_Accessor(param0); // TODO: Initialize to an appropriate value
            //object expected = null; // TODO: Initialize to an appropriate value
            //object actual;
            //target.ID = expected;
            //actual = target.ID;
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
