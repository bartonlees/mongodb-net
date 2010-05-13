using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Transactions;
using System.Security;
using System.Net;
using FluentAssertions;

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
        [Test]
        public void ConstructionTests()
        {   
            ServerBinding serverLoopback = new ServerBinding("mongo://localhost");
            DBBinding b1 = new DBBinding(serverLoopback, "db");
            ServerBinding serverLoopback2 = new ServerBinding("mongo://localhost/db2/test/goat");
            DBBinding b2 = new DBBinding(serverLoopback, "db");
            Assert.That(b1, Is.EqualTo(b2), "should have replaced the database portion if specified");
        }

        [Test]
        public void BadConstructionTests()
        {
            //Template, name
            Assert.That(() => new DBBinding((ServerBinding)null, "test"), Throws.Exception, "null binding template (hostname OK) : should have failed");
            Assert.That(() => new DBBinding(new ServerBinding("mongo://localhost"), (string)null), Throws.Exception, "null host (binding template OK) : should have failed");
        }


        /// <summary>
        ///A test for DBBinding Constructor
        ///</summary>
        [TestMethod()]
        public void DBBindingConstructorTest()
        {
            DBBinding target = new DBBinding(Mongo.DefaultServerBinding, "database");
        }

        /// <summary>
        ///A test for DBBinding Constructor
        ///</summary>
        [TestMethod()]
        public void DBBindingConstructorTest1()
        {
            DBBinding target = new DBBinding(Mongo.DefaultServerBinding, "database", true);
            target = new DBBinding(Mongo.DefaultServerBinding, "database", false);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            DBBinding target1 = new DBBinding(Mongo.DefaultServerBinding, "coll");
            DBBinding target2 = new DBBinding(Mongo.DefaultServerBinding, "coll");
            target1.Should().BeSameAs(target2);   
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            DBBinding target1 = new DBBinding(Mongo.DefaultServerBinding, "coll");
            DBBinding target2 = new DBBinding(Mongo.DefaultServerBinding, "coll2");
            target1.GetHashCode().Should().NotBe(target2.GetHashCode());
        }

        /// <summary>
        ///A test for GetSisterBinding
        ///</summary>
        [TestMethod()]
        public void GetSisterBindingTest()
        {
            DBBinding target = new DBBinding(Mongo.DefaultServerBinding, "coll");
            IDBBinding actual = target.GetSisterBinding("sister");
        }

        /// <summary>
        ///A test for SetCredentials
        ///</summary>
        [TestMethod()]
        public void SetCredentialsTest()
        {
            DBBinding target = new DBBinding(Mongo.DefaultServerBinding, "db");
            string username = "melon";
            SecureString password = new SecureString();
            password.AppendChar('a');
            password.AppendChar('b');
            password.AppendChar('c');
            target.SetCredentials(username, password);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            DBBinding target = new DBBinding(Mongo.DefaultServerBinding, "db");
            string expected = "mongo://127.0.0.1/db";
            string actual;
            actual = target.ToString();
            Console.WriteLine(actual);
            actual.Should().Be(expected);
        }

        /// <summary>
        ///A test for CredentialsSpecified
        ///</summary>
        [TestMethod()]
        public void CredentialsSpecifiedTest()
        {
            DBBinding target = new DBBinding(Mongo.DefaultServerBinding, "db");
            string username = "melon";
            SecureString password = new SecureString();
            password.AppendChar('a');
            password.AppendChar('b');
            password.AppendChar('c');
            target.SetCredentials(username, password);
            target.CredentialsSpecified.Should().Be(true);
        }

        /// <summary>
        ///A test for DatabaseName
        ///</summary>
        [TestMethod()]
        public void DatabaseNameTest()
        {
            DBBinding target = new DBBinding(Mongo.DefaultServerBinding, "db");
            target.DatabaseName.Should().Be("db");
        }

        /// <summary>
        ///A test for ReadOnly
        ///</summary>
        [TestMethod()]
        public void ReadOnlyTest()
        {
            DBBinding target = new DBBinding(Mongo.DefaultServerBinding, "db",true);
            target.ReadOnly.Should().Be(true);

            DBBinding target2 = new DBBinding(Mongo.DefaultServerBinding, "db");
            target2.ReadOnly.Should().Be(false);
        }

        /// <summary>
        ///A test for Server
        ///</summary>
        [TestMethod()]
        public void ServerTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            //IServer expected = null; // TODO: Initialize to an appropriate value
            //IServer actual;
            //target.Server = expected;
            //actual = target.Server;
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uri
        ///</summary>
        [TestMethod()]
        public void UriTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            //Uri expected = null; // TODO: Initialize to an appropriate value
            //Uri actual;
            //target.Uri = expected;
            //actual = target.Uri;
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Username
        ///</summary>
        [TestMethod()]
        public void UsernameTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //DBBinding_Accessor target = new DBBinding_Accessor(param0); // TODO: Initialize to an appropriate value
            //string expected = string.Empty; // TODO: Initialize to an appropriate value
            //string actual;
            //target.Username = expected;
            //actual = target.Username;
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
