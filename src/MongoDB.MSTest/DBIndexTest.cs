using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBIndexTest and is intended
    ///to contain all DBIndexTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBIndexTest
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
        ///A test for DBIndex Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void DBIndexConstructorTest()
        {
            DBCollection_Accessor collection = null; // TODO: Initialize to an appropriate value
            Uri indexUri = null; // TODO: Initialize to an appropriate value
            DBFieldSet indexKeyFieldSet = null; // TODO: Initialize to an appropriate value
            bool unique = false; // TODO: Initialize to an appropriate value
            DBIndex_Accessor target = new DBIndex_Accessor(collection, indexUri, indexKeyFieldSet, unique);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CollectionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBIndex_Accessor target = new DBIndex_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBCollection expected = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            target.Collection = expected;
            actual = target.Collection;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for KeyFieldSet
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void KeyFieldSetTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBIndex_Accessor target = new DBIndex_Accessor(param0); // TODO: Initialize to an appropriate value
            DBFieldSet expected = null; // TODO: Initialize to an appropriate value
            DBFieldSet actual;
            target.KeyFieldSet = expected;
            actual = target.KeyFieldSet;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void NameTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBIndex_Accessor target = new DBIndex_Accessor(param0); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Unique
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void UniqueTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBIndex_Accessor target = new DBIndex_Accessor(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Unique = expected;
            actual = target.Unique;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void UriTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBIndex_Accessor target = new DBIndex_Accessor(param0); // TODO: Initialize to an appropriate value
            Uri expected = null; // TODO: Initialize to an appropriate value
            Uri actual;
            target.Uri = expected;
            actual = target.Uri;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
