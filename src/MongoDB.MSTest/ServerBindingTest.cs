using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for ServerBindingTest and is intended
    ///to contain all ServerBindingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServerBindingTest
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
        [Test]
        public void ConstructionTests()
        {
            //Strings
            ServerBinding loopback = new ServerBinding("mongo://localhost");
            ServerBinding ipv4loopback = new ServerBinding("mongo://127.0.0.1");
            ServerBinding ipv6loopback = new ServerBinding("mongo://[::1]");
            ServerBinding loopbackport = new ServerBinding("mongo://localhost:1910");
            ServerBinding ipv4loopbackport = new ServerBinding("mongo://127.0.0.1:1910");
            ServerBinding ipv6loopbackport = new ServerBinding("mongo://[::1]:1910");

            Assert.That(loopbackport, Is.Not.EqualTo(loopback), "should differ by port number");
            Assert.That(ipv4loopbackport, Is.Not.EqualTo(ipv4loopback), "should differ by port number");
            Assert.That(ipv6loopbackport, Is.Not.EqualTo(ipv6loopback), "should differ by port number");

            ServerBinding host_port_dbname = new ServerBinding("localhost", 1910);

            Assert.That(loopbackport, Is.EqualTo(host_port_dbname), "explicit host + port + db should still be equivalent");
        }

        [Test]
        public void BadConstructionTests()
        {
            //Strings
            Assert.That(() => new ServerBinding((string)null), Throws.InstanceOf<ArgumentNullException>(), "null uristring : should have failed");
            Assert.That(() => new ServerBinding(string.Empty), Throws.InstanceOf<UriFormatException>(), "empty uristring : should have failed");
            Assert.That(() => new ServerBinding(" "), Throws.InstanceOf<UriFormatException>(), "whitespace uristring : should have failed");
            Assert.That(() => new ServerBinding("db"), Throws.InstanceOf<UriFormatException>(), "unqualified, ambiguous identifier uristring : should have failed");
            Assert.That(() => new ServerBinding("http://localhost"), Throws.ArgumentException, "bad scheme uristring : should have failed");
            Assert.That(() => new ServerBinding("localhost:1910"), Throws.ArgumentException, "forced host interpretation (:port), but no db : should have failed");

            //Uris
            Assert.That(() => new ServerBinding((Uri)null), Throws.Exception, "null uri : should have failed");

            //host, port
            Assert.That(() => new ServerBinding((string)null, 123), Throws.Exception, "null hostname (port OK) : should have failed");
            Assert.That(() => new ServerBinding("localhost", -1), Throws.Exception, "negative port (hostname OK) : should have failed");
            Assert.That(() => new ServerBinding("localhost", 65536), Throws.Exception, "port out of range (hostname OK) : should have failed");
        }


        /// <summary>
        ///A test for ServerBinding Constructor
        ///</summary>
        [TestMethod()]
        public void ServerBindingConstructorTest()
        {
            string host = string.Empty; // TODO: Initialize to an appropriate value
            int port = 0; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(host, port, readOnly);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ServerBinding Constructor
        ///</summary>
        [TestMethod()]
        public void ServerBindingConstructorTest1()
        {
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ServerBinding Constructor
        ///</summary>
        [TestMethod()]
        public void ServerBindingConstructorTest2()
        {
            string address = string.Empty; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(address, readOnly);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
            object other = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(other);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDBBinding
        ///</summary>
        [TestMethod()]
        public void GetDBBindingTest()
        {
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDBBinding expected = null; // TODO: Initialize to an appropriate value
            IDBBinding actual;
            actual = target.GetDBBinding(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToUri
        ///</summary>
        [TestMethod()]
        public void ToUriTest()
        {
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
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
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
            IPAddress actual;
            actual = target.Address;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DefaultHost
        ///</summary>
        [TestMethod()]
        public void DefaultHostTest()
        {
            string actual;
            actual = ServerBinding.DefaultHost;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DefaultPort
        ///</summary>
        [TestMethod()]
        public void DefaultPortTest()
        {
            int actual;
            actual = ServerBinding.DefaultPort;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EndPoint
        ///</summary>
        [TestMethod()]
        public void EndPointTest()
        {
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
            IPEndPoint actual;
            actual = target.EndPoint;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HostName
        ///</summary>
        [TestMethod()]
        public void HostNameTest()
        {
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
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
            Uri uri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            ServerBinding target = new ServerBinding(uri, readOnly); // TODO: Initialize to an appropriate value
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
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //ServerBinding_Accessor target = new ServerBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            //bool expected = false; // TODO: Initialize to an appropriate value
            //bool actual;
            //target.ReadOnly = expected;
            //actual = target.ReadOnly;
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
