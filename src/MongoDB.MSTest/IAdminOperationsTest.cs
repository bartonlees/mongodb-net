using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SharpTestsEx;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IAdminOperationsTest and is intended
    ///to contain all IAdminOperationsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IAdminOperationsTest
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


        internal virtual IAdminOperations CreateIAdminOperations()
        {
            // TODO: Instantiate an appropriate concrete class.
            IAdminOperations target = null;
            return target;
        }

        /// <summary>
        ///A test for BuildInfo
        ///</summary>
        [TestMethod()]
        public void BuildInfoTest()
        {
            IAdminOperations target = CreateIAdminOperations();
            BuildInfo actual;
            actual = target.BuildInfo;
            Console.WriteLine(actual);
            actual.Bits.Should().Not.Be(0);
            actual.GitVersion.Should().Not.Be(string.Empty);
            actual.SysInfo.Should().Not.Be(string.Empty);
            actual.Version.Should().Not.Be(string.Empty);
        }

        /// <summary>
        ///A test for DiagnosticLoggingLevel
        ///</summary>
        [TestMethod()]
        public void DiagnosticLoggingLevelTest()
        {
            IAdminOperations target = CreateIAdminOperations();
            DiagnosticLoggingLevel expected = new DiagnosticLoggingLevel(); // TODO: Initialize to an appropriate value
            DiagnosticLoggingLevel actual;
            target.DiagnosticLoggingLevel = expected;
            actual = target.DiagnosticLoggingLevel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpLogging
        ///</summary>
        [TestMethod()]
        public void OpLoggingTest()
        {
            IAdminOperations target = CreateIAdminOperations();
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.OpLogging = expected;
            actual = target.OpLogging;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for QueryTraceLevel
        ///</summary>
        [TestMethod()]
        public void QueryTraceLevelTest()
        {
            IAdminOperations target = CreateIAdminOperations();
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.QueryTraceLevel = expected;
            actual = target.QueryTraceLevel;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
