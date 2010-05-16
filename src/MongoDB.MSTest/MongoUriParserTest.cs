using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for MongoUriParserTest and is intended
    ///to contain all MongoUriParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MongoUriParserTest
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
        [TestMethod]
        public void FullUriParseTest()
        {
            string address = "mongo://localhost:7899/db";
            Uri uri = new Uri(address);
            uri.Scheme.Should().Be(UriExtensions.UriSchemeMongo);
            uri.Port.Should().Be(7899);
            uri.AbsolutePath.Should().Be("/db");
            uri.Host.Should().Be("localhost");
            uri.Authority.Should().Be("localhost:7899");
            uri.IsAbsoluteUri.Should().BeTrue();
            Assert.IsFalse(uri.IsDefaultPort);
        }

        [TestMethod]
        public void DotTest()
        {
            string address = "mongo://localhost/db.testing";
            Uri uri = new Uri(address);
        }


        /// <summary>
        ///A test for MongoUriParser Constructor
        ///</summary>
        [TestMethod()]
        public void MongoUriParserConstructorTest()
        {
            MongoUriParser target = new MongoUriParser();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DefaultPort
        ///</summary>
        [TestMethod()]
        public void DefaultPortTest()
        {
            string address = "mongo://localhost/db";
            Uri uri = new Uri(address);
            uri.Scheme.Should().Be(UriExtensions.UriSchemeMongo);
            uri.Port.Should().Be(-1);
            uri.AbsolutePath.Should().Be("/db");
            uri.Host.Should().Be("localhost");
            uri.Authority.Should().Be("localhost");
            uri.IsAbsoluteUri.Should().BeTrue();
            uri.IsDefaultPort.Should().BeTrue();
        }
    }
}
