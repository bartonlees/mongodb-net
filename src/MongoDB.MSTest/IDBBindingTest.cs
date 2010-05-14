using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;
using System.Net;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IDBBindingTest and is intended
    ///to contain all IDBBindingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBBindingTest
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
        ///A test for Call
        ///</summary>
        public void CallTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            IDBRequest msg = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> actual;
            actual = target.Call<TDoc>(cmdCollection, msg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual IDBBinding CreateIDBBinding()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBBinding target = null;
            return target;
        }

        [TestMethod()]
        public void CallTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CallTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for GetSisterBinding
        ///</summary>
        [TestMethod()]
        public void GetSisterBindingTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDBBinding expected = null; // TODO: Initialize to an appropriate value
            IDBBinding actual;
            actual = target.GetSisterBinding(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Say
        ///</summary>
        [TestMethod()]
        public void SayTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            IDBRequest msg = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Say(cmdCollection, msg, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetCredentials
        ///</summary>
        [TestMethod()]
        public void SetCredentialsTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            SecureString passwd = null; // TODO: Initialize to an appropriate value
            target.SetCredentials(username, passwd);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TrySay
        ///</summary>
        [TestMethod()]
        public void TrySayTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            IDBRequest msg = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TrySay(cmdCollection, msg, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Address
        ///</summary>
        [TestMethod()]
        public void AddressTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            IPAddress actual;
            actual = target.Address;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConnectionOptions
        ///</summary>
        [TestMethod()]
        public void ConnectionOptionsTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            DBConnectionOptions actual;
            actual = target.ConnectionOptions;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DatabaseName
        ///</summary>
        [TestMethod()]
        public void DatabaseNameTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.DatabaseName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EndPoint
        ///</summary>
        [TestMethod()]
        public void EndPointTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
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
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.HostName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LastException
        ///</summary>
        [TestMethod()]
        public void LastExceptionTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            Exception actual;
            actual = target.LastException;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Port
        ///</summary>
        [TestMethod()]
        public void PortTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
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
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Server
        ///</summary>
        [TestMethod()]
        public void ServerTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            IServer actual;
            actual = target.Server;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.Uri;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Username
        ///</summary>
        [TestMethod()]
        public void UsernameTest()
        {
            IDBBinding target = CreateIDBBinding(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Username;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
