using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for ServerPairBindingTest and is intended
    ///to contain all ServerPairBindingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServerPairBindingTest
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
        ///A test for ServerPairBinding Constructor
        ///</summary>
        [TestMethod()]
        public void ServerPairBindingConstructorTest()
        {
            ServerBinding leftBinding = null; // TODO: Initialize to an appropriate value
            ServerBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerPairBinding target = new ServerPairBinding(leftBinding, rightBinding, readOnly);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetDBBinding
        ///</summary>
        [TestMethod()]
        public void GetDBBindingTest()
        {
            ServerBinding leftBinding = null; // TODO: Initialize to an appropriate value
            ServerBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerPairBinding target = new ServerPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDBBinding expected = null; // TODO: Initialize to an appropriate value
            IDBBinding actual;
            actual = target.GetDBBinding(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToUri
        ///</summary>
        [TestMethod()]
        public void ToUriTest()
        {
            ServerBinding leftBinding = null; // TODO: Initialize to an appropriate value
            ServerBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerPairBinding target = new ServerPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            Uri expected = null; // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.ToUri();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Address
        ///</summary>
        [TestMethod()]
        public void AddressTest()
        {
            ServerBinding leftBinding = null; // TODO: Initialize to an appropriate value
            ServerBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerPairBinding target = new ServerPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            ServerBinding leftBinding = null; // TODO: Initialize to an appropriate value
            ServerBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerPairBinding target = new ServerPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.HostName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LeftBinding
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void LeftBindingTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ServerPairBinding_Accessor target = new ServerPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            ServerBinding expected = null; // TODO: Initialize to an appropriate value
            ServerBinding actual;
            target.LeftBinding = expected;
            actual = target.LeftBinding;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Port
        ///</summary>
        [TestMethod()]
        public void PortTest()
        {
            ServerBinding leftBinding = null; // TODO: Initialize to an appropriate value
            ServerBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerPairBinding target = new ServerPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Port;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReadOnly
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ReadOnlyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ServerPairBinding_Accessor target = new ServerPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ReadOnly = expected;
            actual = target.ReadOnly;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RightBinding
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void RightBindingTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ServerPairBinding_Accessor target = new ServerPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            ServerBinding expected = null; // TODO: Initialize to an appropriate value
            ServerBinding actual;
            target.RightBinding = expected;
            actual = target.RightBinding;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
