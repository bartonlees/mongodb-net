using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IServerBindingTest and is intended
    ///to contain all IServerBindingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IServerBindingTest
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

        internal virtual IServerBinding CreateIServerBinding()
        {
            // TODO: Instantiate an appropriate concrete class.
            IServerBinding target = null;
            return target;
        }

        /// <summary>
        ///A test for GetDBBinding
        ///</summary>
        [TestMethod()]
        public void GetDBBindingTest()
        {
            IServerBinding target = CreateIServerBinding(); // TODO: Initialize to an appropriate value
            IServer serverLoopback = Mongo.GetServer("mongo://localhost");
            IDBBinding b1 = serverLoopback.Binding.GetDBBinding("db");
            IServer serverLoopback2 = Mongo.GetServer("mongo://localhost/db2/test/goat");
            IDBBinding b2 = serverLoopback.Binding.GetDBBinding("db");
            b1.Should().Be(b2, "the database portion should have been replaced");

            new Action(()=> target.GetDBBinding((string)null)).ShouldThrow<Exception>("a null hostname is not valid");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            IServerBinding target = CreateIServerBinding(); // TODO: Initialize to an appropriate value
            Uri expected = null; // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.Uri;
            expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Address
        ///</summary>
        [TestMethod()]
        public void AddressTest()
        {
            IServerBinding target = CreateIServerBinding(); // TODO: Initialize to an appropriate value
            IPAddress actual;
            actual = target.Address;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HostName
        ///</summary>
        [TestMethod()]
        public void HostNameTest()
        {
            IServerBinding target = CreateIServerBinding(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.HostName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Port
        ///</summary>
        [TestMethod()]
        public void PortTest()
        {
            IServerBinding target = CreateIServerBinding(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Port;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadOnly
        ///</summary>
        [TestMethod()]
        public void ReadOnlyTest()
        {
            IServerBinding target = CreateIServerBinding(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
