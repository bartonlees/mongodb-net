using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for BuildInfoTest and is intended
    ///to contain all BuildInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BuildInfoTest
    {
        BuildInfo _BuildInfo;

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
        ///A test for BuildInfo Constructor
        ///</summary>
        [TestMethod()]
        public void BuildInfoConstructorTest()
        {
            _BuildInfo = Mongo.DefaultServer.Admin.BuildInfo;
            Console.WriteLine(_BuildInfo);
        }

        /// <summary>
        ///A test for Bits
        ///</summary>
        [TestMethod()]
        public void BitsTest()
        {
            Assert.AreNotEqual(_BuildInfo.Bits, 0, "Shouldn't be default");
        }

        /// <summary>
        ///A test for GitVersion
        ///</summary>
        [TestMethod()]
        public void GitVersionTest()
        {
            Assert.AreNotEqual(_BuildInfo.GitVersion, 0, "Shouldn't be default");
        }

        /// <summary>
        ///A test for SysInfo
        ///</summary>
        [TestMethod()]
        public void SysInfoTest()
        {
            Assert.AreNotEqual(_BuildInfo.SysInfo, 0, "Shouldn't be default");
        }

        /// <summary>
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            Assert.AreNotEqual(_BuildInfo.Version, 0, "Shouldn't be default");
        }
    }
}
