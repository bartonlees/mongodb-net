using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Transactions;
using System.Security;
using System.Net;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBBindingTest and is intended
    ///to contain all DBBindingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBBindingTest
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
        ///A test for DBBinding Constructor
        ///</summary>
        [TestMethod()]
        public void DBBindingConstructorTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            string databaseUri = string.Empty; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBBinding Constructor
        ///</summary>
        [TestMethod()]
        public void DBBindingConstructorTest1()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Call
        ///</summary>
        public void CallTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
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
        ///A test for CreateConnection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CreateConnectionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBConnection expected = null; // TODO: Initialize to an appropriate value
            IDBConnection actual;
            actual = target.CreateConnection();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            object other = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(other);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIdleConnection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void GetIdleConnectionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBConnection expected = null; // TODO: Initialize to an appropriate value
            IDBConnection actual;
            actual = target.GetIdleConnection();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSisterBinding
        ///</summary>
        [TestMethod()]
        public void GetSisterBindingTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            Uri databaseUri1 = null; // TODO: Initialize to an appropriate value
            IDBBinding expected = null; // TODO: Initialize to an appropriate value
            IDBBinding actual;
            actual = target.GetSisterBinding(databaseUri1);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IdleConnection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void IdleConnectionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBConnection connection = null; // TODO: Initialize to an appropriate value
            target.IdleConnection(connection);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MongoDB.Driver.IInternalDBBinding.Initialize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void InitializeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            IInternalDBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IServer server = null; // TODO: Initialize to an appropriate value
            target.Initialize(server);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RequireConnection
        ///</summary>
        [TestMethod()]
        public void RequireConnectionTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            Transaction transaction = null; // TODO: Initialize to an appropriate value
            IDBConnection expected = null; // TODO: Initialize to an appropriate value
            IDBConnection actual;
            actual = target.RequireConnection(transaction);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Say
        ///</summary>
        [TestMethod()]
        public void SayTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
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
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            SecureString password = null; // TODO: Initialize to an appropriate value
            target.SetCredentials(username, password);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TransactionCompleted
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void TransactionCompletedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            TransactionEventArgs e = null; // TODO: Initialize to an appropriate value
            target.TransactionCompleted(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TrySay
        ///</summary>
        [TestMethod()]
        public void TrySayTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            IDBRequest request = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TrySay(cmdCollection, request, checkError);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _Say
        ///</summary>
        [TestMethod()]
        public void _SayTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            IDBRequest request = null; // TODO: Initialize to an appropriate value
            bool checkError = false; // TODO: Initialize to an appropriate value
            bool suppressException = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target._Say(cmdCollection, request, checkError, suppressException);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Address
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void AddressTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            IPAddress expected = null; // TODO: Initialize to an appropriate value
            IPAddress actual;
            target.Address = expected;
            actual = target.Address;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Authenticated
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void AuthenticatedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Authenticated = expected;
            actual = target.Authenticated;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConnectionOptions
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ConnectionOptionsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            DBConnectionOptions expected = null; // TODO: Initialize to an appropriate value
            DBConnectionOptions actual;
            target.ConnectionOptions = expected;
            actual = target.ConnectionOptions;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CredentialsSpecified
        ///</summary>
        [TestMethod()]
        public void CredentialsSpecifiedTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CredentialsSpecified;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DatabaseName
        ///</summary>
        [TestMethod()]
        public void DatabaseNameTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.DatabaseName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DefaultHost
        ///</summary>
        [TestMethod()]
        public void DefaultHostTest()
        {
            string actual;
            actual = DBBinding.DefaultHost;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DefaultPort
        ///</summary>
        [TestMethod()]
        public void DefaultPortTest()
        {
            int actual;
            actual = DBBinding.DefaultPort;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EndPoint
        ///</summary>
        [TestMethod()]
        public void EndPointTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
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
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.HostName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LastException
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void LastExceptionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            Exception expected = null; // TODO: Initialize to an appropriate value
            Exception actual;
            target.LastException = expected;
            actual = target.LastException;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Port
        ///</summary>
        [TestMethod()]
        public void PortTest()
        {
            IServerBinding serverBinding = null; // TODO: Initialize to an appropriate value
            Uri databaseUri = null; // TODO: Initialize to an appropriate value
            bool readOnly = false; // TODO: Initialize to an appropriate value
            DBBinding target = new DBBinding(serverBinding, databaseUri, readOnly); // TODO: Initialize to an appropriate value
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
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ReadOnly = expected;
            actual = target.ReadOnly;
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
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
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
        [DeploymentItem("MongoDB.Driver.dll")]
        public void UriTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            Uri expected = null; // TODO: Initialize to an appropriate value
            Uri actual;
            target.Uri = expected;
            actual = target.Uri;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Username
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void UsernameTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Username = expected;
            actual = target.Username;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
