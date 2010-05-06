using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for BytesTest and is intended
    ///to contain all BytesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BytesTest
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
        ///A test for CameFromDB
        ///</summary>
        [TestMethod()]
        public void CameFromDBTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = Bytes.CameFromDB(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _warnUnsupported
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void _warnUnsupportedTest()
        {
            string flag = string.Empty; // TODO: Initialize to an appropriate value
            Bytes_Accessor._warnUnsupported(flag);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for getByCharacter
        ///</summary>
        [TestMethod()]
        public void getByCharacterTest()
        {
            char ch = '\0'; // TODO: Initialize to an appropriate value
            RegexOptions expected = new RegexOptions(); // TODO: Initialize to an appropriate value
            RegexOptions actual;
            actual = Bytes.getByCharacter(ch);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getType
        ///</summary>
        [TestMethod()]
        public void getTypeTest()
        {
            object o = null; // TODO: Initialize to an appropriate value
            byte expected = 0; // TODO: Initialize to an appropriate value
            byte actual;
            actual = Bytes.getType(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
