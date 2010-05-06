using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;
using System.Net;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBPairBindingTest and is intended
    ///to contain all DBPairBindingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBPairBindingTest
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
        ///A test for DBPairBinding Constructor
        ///</summary>
        [TestMethod()]
        public void DBPairBindingConstructorTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Call
        ///</summary>
        public void CallTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            IDBRequest request = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> actual;
            actual = target.Call<TDoc>(cmdCollection, request);
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
        ///A test for CycleSubBinding
        ///</summary>
        [TestMethod()]
        public void CycleSubBindingTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            target.CycleSubBinding();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetSisterBinding
        ///</summary>
        [TestMethod()]
        public void GetSisterBindingTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            Uri name = null; // TODO: Initialize to an appropriate value
            IDBBinding expected = null; // TODO: Initialize to an appropriate value
            IDBBinding actual;
            actual = target.GetSisterBinding(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MongoDB.Driver.IInternalDBBinding.Initialize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void InitializeTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            IInternalDBBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            IServer server = null; // TODO: Initialize to an appropriate value
            target.Initialize(server);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PickInitialSubBinding
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void PickInitialSubBindingTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBPairBinding_Accessor target = new DBPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            target.PickInitialSubBinding();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Say
        ///</summary>
        [TestMethod()]
        public void SayTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            IDBRequest request = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            target.Say(cmdCollection, request, checkError);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetCredentials
        ///</summary>
        [TestMethod()]
        public void SetCredentialsTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
        ///A test for _Call
        ///</summary>
        public void _CallTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBPairBinding_Accessor target = new DBPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            IDBRequest request = null; // TODO: Initialize to an appropriate value
            int retries = 0; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> actual;
            actual = target._Call<TDoc>(cmdCollection, request, retries);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void _CallTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call _CallTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for ActiveBinding
        ///</summary>
        [TestMethod()]
        public void ActiveBindingTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            IDBBinding actual;
            actual = target.ActiveBinding;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Address
        ///</summary>
        [TestMethod()]
        public void AddressTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            Exception actual;
            actual = target.LastException;
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
            DBPairBinding_Accessor target = new DBPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBBinding expected = null; // TODO: Initialize to an appropriate value
            IDBBinding actual;
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
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            DBPairBinding_Accessor target = new DBPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
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
            DBPairBinding_Accessor target = new DBPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBBinding expected = null; // TODO: Initialize to an appropriate value
            IDBBinding actual;
            target.RightBinding = expected;
            actual = target.RightBinding;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Server
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ServerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBPairBinding_Accessor target = new DBPairBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IServer expected = null; // TODO: Initialize to an appropriate value
            IServer actual;
            target.Server = expected;
            actual = target.Server;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
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
            IDBBinding leftBinding = null; // TODO: Initialize to an appropriate value
            IDBBinding rightBinding = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBPairBinding target = new DBPairBinding(leftBinding, rightBinding, readOnly); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Username;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
