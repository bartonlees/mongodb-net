using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for MongoTest and is intended
    ///to contain all MongoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MongoTest
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
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest()
        {
            IDatabase target1 = Mongo.GetDatabase(new Uri("mongo://localhost/database"));
            new Action(() => Mongo.GetDatabase(new Uri("database"))).ShouldThrow<Exception>("URI must be absolute");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest1()
        {
            IDatabase target1 = Mongo.GetDatabase("mongo://localhost/database");
            new Action(() => Mongo.GetDatabase("database")).ShouldThrow<Exception>("URI must be absolute");
        }

        /// <summary>
        ///A test for GetDatabase
        ///</summary>
        [TestMethod()]
        public void GetDatabaseTest2()
        {
            IDatabase target1 = Mongo.GetDatabase("localhost", "database");
            IDatabase target2 = Mongo.GetDatabase("localhost", "database", 78787);
            new Action(() => Mongo.GetDatabase((string)null, "database")).ShouldThrow<Exception>("although the db name was valid, the host name was null");
            new Action(() => Mongo.GetDatabase("localhost", (string)null)).ShouldThrow<Exception>("although the db name was valid, the host name was null");
        }

        /// <summary>
        ///A test for GetServer
        ///</summary>
        [TestMethod()]
        public void GetServerTest()
        {
            IServer server = Mongo.GetServer("localhost", 1910);
            server.Uri.Should().Be("mongo://localhost:1910");

            Action<Tuple<string, int>> ctor = t => Mongo.GetServer(t.Item1, t.Item2);

            new Tuple<string, int>((string)null, 123).Invoking(ctor).ShouldThrow<Exception>("although the port was OK, the hostname was null");
            new Tuple<string, int>("localhost", -1).Invoking(ctor).ShouldThrow<Exception>("although the hostname was OK, the port was negative");
            new Tuple<string, int>("localhost", 65536).Invoking(ctor).ShouldThrow<Exception>("although the hostname was OK, the port was out of range");
        }

        /// <summary>
        ///A test for GetServer
        ///</summary>
        [TestMethod()]
        public void GetServerTest1()
        {
            IServer server = Mongo.GetServer(new Uri("mongo://localhost"));
            server.Uri.Should().Be("mongo://localhost");

            new Action(() => Mongo.GetServer((Uri)null)).ShouldThrow<Exception>("a null URI is invalid");
        }

        [TestMethod()]
        public void GetServerTest2()
        {
            IServer loopback = Mongo.GetServer("mongo://localhost");
            IServer ipv4loopback = Mongo.GetServer("mongo://127.0.0.1");
            IServer ipv6loopback = Mongo.GetServer("mongo://[::1]");
            IServer loopbackport = Mongo.GetServer("mongo://localhost:1910");
            IServer ipv4loopbackport = Mongo.GetServer("mongo://127.0.0.1:1910");
            IServer ipv6loopbackport = Mongo.GetServer("mongo://[::1]:1910");

            loopbackport.Should().Be(loopback, "port number differs");
            ipv4loopbackport.Should().Be(ipv4loopback, "port number differs");
            ipv6loopbackport.Should().Be(ipv6loopback, "port number differs");

            IServer host_port_dbname = Mongo.GetServer("localhost", 1910);

            loopbackport.Should().Be(host_port_dbname, "explicit loopback host + port + db should still be equivalent to shorthand loopback");

            Action<string> ctor = s => Mongo.GetServer(s);

            //Strings
            ((string)null).Invoking(ctor).ShouldThrow<ArgumentNullException>("URI string was null");
            string.Empty.Invoking(ctor).ShouldThrow<UriFormatException>("URI string was empty");
            " ".Invoking(ctor).ShouldThrow<UriFormatException>("URI string was whitespace");
            "db".Invoking(ctor).ShouldThrow<UriFormatException>("URI string was unqualified, ambiguous identifier");
            "http://localhost".Invoking(ctor).ShouldThrow<ArgumentException>("bad scheme uristring : should have failed");
            "localhost:1910".Invoking(ctor).ShouldThrow<ArgumentException>("existence of ':port' forced interpretation of hostname, but no database name can be inferred");
        }


        /// <summary>
        ///A test for DefaultDatabase
        ///</summary>
        [TestMethod()]
        public void DefaultDatabaseTest()
        {
            IDatabase actual;
            actual = Mongo.DefaultDatabase;
            actual.Should().NotBeNull();
            List<Uri> names = new List<Uri>(actual.GetCollectionNames());
            names.Should().Contain(Constants.CollectionNames.Cmd); //Todo:get the actual name for the command collection
        }

        /// <summary>
        ///A test for DefaultServer
        ///</summary>
        [TestMethod()]
        public void DefaultServerTest()
        {
            IServer actual;
            actual = Mongo.DefaultServer;
            actual.Should().NotBeNull("the proxy should always be creatable");
        }

        /// <summary>
        ///A test for ReadOnlyDefaultDatabase
        ///</summary>
        [TestMethod()]
        public void ReadOnlyDefaultDatabaseTest()
        {
            IDatabase actual;
            actual = Mongo.DefaultReadOnlyDatabase;
            actual.Should().NotBeNull();
            actual.ReadOnly.Should().BeTrue("that is how we set it");
        }

        /// <summary>
        ///A test for ReadOnlyDefaultServer
        ///</summary>
        [TestMethod()]
        public void ReadOnlyDefaultServerTest()
        {
            IServer readOnlyServer = Mongo.DefaultReadOnlyServer;
            readOnlyServer.ReadOnly.Should().BeTrue("it is a read only server");
        }

        /// <summary>
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            Version actual;
            actual = Mongo.Version;
            actual.Should().NotBeNull();
        }
    }
}
