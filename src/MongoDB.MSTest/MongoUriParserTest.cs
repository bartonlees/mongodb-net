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
            Assert.That(uri.Scheme, Is.EqualTo(UriExtensions.UriSchemeMongo));
            Assert.That(uri.Port, Is.EqualTo(7899));
            Assert.That(uri.AbsolutePath, Is.EqualTo("/db"));
            Assert.That(uri.Host, Is.EqualTo("localhost"));
            Assert.That(uri.Authority, Is.EqualTo("localhost:7899"));
            Assert.That(uri.IsAbsoluteUri);
            Assert.IsFalse(uri.IsDefaultPort);
        }

        [Test]
        public void DefaultPortTest()
        {
            string address = "mongo://localhost/db";
            Uri uri = new Uri(address);
            Assert.That(uri.Scheme, Is.EqualTo(UriExtensions.UriSchemeMongo));
            Assert.That(uri.Port, Is.EqualTo(-1));
            Assert.That(uri.AbsolutePath, Is.EqualTo("/db"));
            Assert.That(uri.Host, Is.EqualTo("localhost"));
            Assert.That(uri.Authority, Is.EqualTo("localhost"));
            Assert.That(uri.IsAbsoluteUri);
            Assert.That(uri.IsDefaultPort);
        }

        [Test]
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
            int actual;
            actual = MongoUriParser.DefaultPort;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
