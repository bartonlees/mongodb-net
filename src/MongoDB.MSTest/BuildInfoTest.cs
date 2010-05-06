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
            IDBObject response = null; // TODO: Initialize to an appropriate value
            BuildInfo target = new BuildInfo(response);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Bits
        ///</summary>
        [TestMethod()]
        public void BitsTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            BuildInfo target = new BuildInfo(response); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Bits;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GitVersion
        ///</summary>
        [TestMethod()]
        public void GitVersionTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            BuildInfo target = new BuildInfo(response); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GitVersion;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SysInfo
        ///</summary>
        [TestMethod()]
        public void SysInfoTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            BuildInfo target = new BuildInfo(response); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SysInfo;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            IDBObject response = null; // TODO: Initialize to an appropriate value
            BuildInfo target = new BuildInfo(response); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Version;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
