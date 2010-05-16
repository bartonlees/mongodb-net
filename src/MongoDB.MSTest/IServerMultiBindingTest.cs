using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IServerMultiBindingTest and is intended
    ///to contain all IServerMultiBindingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IServerMultiBindingTest
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


        internal virtual IServerMultiBinding CreateIServerMultiBinding()
        {
            // TODO: Instantiate an appropriate concrete class.
            IServerMultiBinding target = null;
            return target;
        }

        /// <summary>
        ///A test for GetDBMultiBinding
        ///</summary>
        [TestMethod()]
        public void GetDBMultiBindingTest()
        {
            IServerMultiBinding target = CreateIServerMultiBinding(); // TODO: Initialize to an appropriate value
            Uri uri = null; // TODO: Initialize to an appropriate value
            IDBMultiBinding expected = null; // TODO: Initialize to an appropriate value
            IDBMultiBinding actual;
            actual = target.GetDBMultiBinding(uri);
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SubBindings
        ///</summary>
        [TestMethod()]
        public void SubBindingsTest()
        {
            IServerMultiBinding target = CreateIServerMultiBinding(); // TODO: Initialize to an appropriate value
            IEnumerable<IServerBinding> actual;
            actual = target.SubBindings;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
