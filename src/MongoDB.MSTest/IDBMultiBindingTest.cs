using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IDBMultiBindingTest and is intended
    ///to contain all IDBMultiBindingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBMultiBindingTest
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


        internal virtual IDBMultiBinding CreateIDBMultiBinding()
        {
            return null;// Mongo.DefaultMultiDatabase;
        }

        /// <summary>
        ///A test for ActiveBinding
        ///</summary>
        [TestMethod()]
        public void ActiveBindingTest()
        {
            IDBMultiBinding target = CreateIDBMultiBinding(); // TODO: Initialize to an appropriate value
            IDBBinding actual;
            actual = target.ActiveSubBinding;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ServerMultiBinding
        ///</summary>
        [TestMethod()]
        public void ServerMultiBindingTest()
        {
            IDBMultiBinding target = CreateIDBMultiBinding(); // TODO: Initialize to an appropriate value
            IServerMultiBinding actual;
            actual = target.ServerMultiBinding;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SubBindings
        ///</summary>
        [TestMethod()]
        public void SubBindingsTest()
        {
            IDBMultiBinding target = CreateIDBMultiBinding(); // TODO: Initialize to an appropriate value
            IEnumerable<IDBBinding> actual;
            actual = target.SubBindings;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
