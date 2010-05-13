using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IDBIndexTest and is intended
    ///to contain all IDBIndexTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBIndexTest
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


        internal virtual IDBIndex CreateIDBIndex()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBIndex target = null;
            return target;
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        [TestMethod()]
        public void CollectionTest()
        {
            IDBIndex target = CreateIDBIndex(); // TODO: Initialize to an appropriate value
            IDBCollection actual;
            actual = target.Collection;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for KeyFieldSet
        ///</summary>
        [TestMethod()]
        public void KeyFieldSetTest()
        {
            IDBIndex target = CreateIDBIndex(); // TODO: Initialize to an appropriate value
            DBFieldSet actual;
            actual = target.KeyFieldSet;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            IDBIndex target = CreateIDBIndex(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Unique
        ///</summary>
        [TestMethod()]
        public void UniqueTest()
        {
            IDBIndex target = CreateIDBIndex(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Unique;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            IDBIndex target = CreateIDBIndex(); // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.Uri;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
