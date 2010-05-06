using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Security;
using System.Net.Sockets;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBConnectionTest and is intended
    ///to contain all DBConnectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBConnectionTest
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
        ///A test for DBConnection Constructor
        ///</summary>
        [TestMethod()]
        public void DBConnectionConstructorTest()
        {
            IPEndPoint addr = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            DBConnection target = new DBConnection(addr, options);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Call
        ///</summary>
        public void CallTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IPEndPoint addr = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            DBConnection target = new DBConnection(addr, options); // TODO: Initialize to an appropriate value
            IDBRequest msg = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> actual;
            actual = target.Call<TDoc>(msg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CallTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CallTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for ConnectClient
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ConnectClientTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBConnection_Accessor target = new DBConnection_Accessor(param0); // TODO: Initialize to an appropriate value
            target.ConnectClient();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            IPEndPoint addr = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            DBConnection target = new DBConnection(addr, options); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            IPEndPoint addr = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            DBConnection target = new DBConnection(addr, options); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Say
        ///</summary>
        [TestMethod()]
        public void SayTest()
        {
            IPEndPoint addr = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            DBConnection target = new DBConnection(addr, options); // TODO: Initialize to an appropriate value
            IDBRequest msg = null; // TODO: Initialize to an appropriate value
            target.Say(msg);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            IPEndPoint addr = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            DBConnection target = new DBConnection(addr, options); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryAuthenticate
        ///</summary>
        [TestMethod()]
        public void TryAuthenticateTest()
        {
            IPEndPoint addr = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            DBConnection target = new DBConnection(addr, options); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            SecureString usrPassHash = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryAuthenticate(cmdCollection, username, usrPassHash);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _SendRequest
        ///</summary>
        public void _SendRequestTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBConnection_Accessor target = new DBConnection_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBRequest msg = null; // TODO: Initialize to an appropriate value
            bool expectResponse = false; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> actual;
            actual = target._SendRequest<TDoc>(msg, expectResponse);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void _SendRequestTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call _SendRequestTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for CanRequest
        ///</summary>
        [TestMethod()]
        public void CanRequestTest()
        {
            IPEndPoint addr = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions options = null; // TODO: Initialize to an appropriate value
            DBConnection target = new DBConnection(addr, options); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanRequest;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EndPoint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void EndPointTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBConnection_Accessor target = new DBConnection_Accessor(param0); // TODO: Initialize to an appropriate value
            IPEndPoint expected = null; // TODO: Initialize to an appropriate value
            IPEndPoint actual;
            target.EndPoint = expected;
            actual = target.EndPoint;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NetworkStream
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void NetworkStreamTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBConnection_Accessor target = new DBConnection_Accessor(param0); // TODO: Initialize to an appropriate value
            NetworkStream actual;
            actual = target.NetworkStream;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Options
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void OptionsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBConnection_Accessor target = new DBConnection_Accessor(param0); // TODO: Initialize to an appropriate value
            DBConnectionOptions expected = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions actual;
            target.Options = expected;
            actual = target.Options;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
