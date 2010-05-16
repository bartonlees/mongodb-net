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


        [TestMethod()]
        public void DBBindingConstructorTest()
        {
        }

        /// <summary>
        ///A test for DBBinding Constructor
        ///</summary>
        [TestMethod()]
        public void DBBindingConstructorTest1()
        {
            
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            IDatabase b1 = Mongo.GetDatabase("mongo://localhost/db");
            IDatabase b2 = Mongo.GetDatabase("mongo://localhost/db");
            b1.Binding.Should().BeSameAs(b2.Binding);
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            IDatabase b1 = Mongo.GetDatabase("mongo://localhost/db1");
            IDatabase b2 = Mongo.GetDatabase("mongo://localhost/db2");
            b1.GetHashCode().Should().NotBe(b2.GetHashCode());
        }

        /// <summary>
        ///A test for GetSisterBinding
        ///</summary>
        [TestMethod()]
        public void GetSisterBindingTest()
        {
            IDatabase b1 = Mongo.GetDatabase("mongo://localhost/db1");
            IDBBinding actual = b1.Binding.GetSisterBinding("sister");
        }

        /// <summary>
        ///A test for SetCredentials
        ///</summary>
        [TestMethod()]
        public void SetCredentialsTest()
        {
            IDatabase b1 = Mongo.GetDatabase("mongo://localhost/db");
            string username = "melon";
            SecureString password = new SecureString();
            password.AppendChar('a');
            password.AppendChar('b');
            password.AppendChar('c');
            b1.Binding.SetCredentials(username, password);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            IDatabase b1 = Mongo.GetDatabase("mongo://localhost/db");
            string expected = "mongo://localhost/db";
            string actual;
            actual = b1.ToString();
            Console.WriteLine(actual);
            actual.Should().Be(expected);
        }

        /// <summary>
        ///A test for DatabaseName
        ///</summary>
        [TestMethod()]
        public void DatabaseNameTest()
        {
            IDatabase b1 = Mongo.GetDatabase("mongo://localhost/db");
            b1.Binding.DatabaseName.Should().Be("db");
        }

        /// <summary>
        ///A test for Call
        ///</summary>
        public void CallTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBBinding target = CreateIDBBinding();
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
            return Mongo.DefaultDatabase.Binding;
        }

        /// <summary>
        ///A test for Address
        ///</summary>
        [TestMethod()]
        public void AddressTest()
        {
            IDBBinding target = CreateIDBBinding();
            IPAddress actual;
            actual = target.Address;
            target.Address.Should().NotBeNull();
        }

        /// <summary>
        ///A test for ConnectionOptions
        ///</summary>
        [TestMethod()]
        public void ConnectionOptionsTest()
        {
            IDBBinding target = CreateIDBBinding();
            DBConnectionOptions actual;
            actual = target.ConnectionOptions;
            actual.Should().NotBeNull();
        }

        /// <summary>
        ///A test for EndPoint
        ///</summary>
        [TestMethod()]
        public void EndPointTest()
        {
            IDBBinding target = CreateIDBBinding();
            IPEndPoint actual;
            actual = target.EndPoint;
            actual.Should().NotBeNull();
        }

        /// <summary>
        ///A test for HostName
        ///</summary>
        [TestMethod()]
        public void HostNameTest()
        {
            IDBBinding target = CreateIDBBinding();
            string actual;
            actual = target.HostName;
            actual.Should().NotBeNull();
        }

        /// <summary>
        ///A test for LastException
        ///</summary>
        [TestMethod()]
        public void LastExceptionTest()
        {
            IDBBinding target = CreateIDBBinding();
            Exception actual;
            actual = target.LastException;
            actual.Should().BeNull();
        }

        /// <summary>
        ///A test for Port
        ///</summary>
        [TestMethod()]
        public void PortTest()
        {
            IDBBinding target = CreateIDBBinding();
            int actual;
            actual = target.Port;
            actual.Should().Be(Mongo.DefaultPort);
        }

        /// <summary>
        ///A test for ReadOnly
        ///</summary>
        [TestMethod()]
        public void ReadOnlyTest()
        {
            IDBBinding target = Mongo.DefaultReadOnlyDatabase.Binding;
            bool actual;
            actual = target.ReadOnly;
            actual.Should().BeTrue();
        }

        /// <summary>
        ///A test for Server
        ///</summary>
        [TestMethod()]
        public void BoundDatabaseTest()
        {
            IDBBinding target = CreateIDBBinding();
            IDatabase actual;
            actual = target.BoundDatabase;
            actual.Should().NotBeNull();
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            IDBBinding target = CreateIDBBinding();
            Uri actual;
            actual = target.Uri;
            actual.Should().NotBeNull();
        }

        /// <summary>
        ///A test for Username
        ///</summary>
        [TestMethod()]
        public void UsernameTest()
        {
            IDBBinding target = CreateIDBBinding();
            string actual;
            actual = target.Username;
            actual.Should().BeNull();
        }
    }
}
