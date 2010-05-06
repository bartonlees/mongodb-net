using MongoDB.Driver.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for HeaderTest and is intended
    ///to contain all HeaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HeaderTest
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


        internal virtual Header CreateHeader()
        {
            // TODO: Instantiate an appropriate concrete class.
            Header target = null;
            return target;
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Header target = CreateHeader(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual Header_Accessor CreateHeader_Accessor()
        {
            // TODO: Instantiate an appropriate concrete class.
            Header_Accessor target = null;
            return target;
        }

        /// <summary>
        ///A test for MessageLength
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void MessageLengthTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Header_Accessor target = new Header_Accessor(param0); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.MessageLength = expected;
            actual = target.MessageLength;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpCode
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void OpCodeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Header_Accessor target = new Header_Accessor(param0); // TODO: Initialize to an appropriate value
            Operation expected = new Operation(); // TODO: Initialize to an appropriate value
            Operation actual;
            target.OpCode = expected;
            actual = target.OpCode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RequestID
        ///</summary>
        [TestMethod()]
        public void RequestIDTest()
        {
            Header target = CreateHeader(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.RequestID = expected;
            actual = target.RequestID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResponseTo
        ///</summary>
        [TestMethod()]
        public void ResponseToTest()
        {
            Header target = CreateHeader(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ResponseTo = expected;
            actual = target.ResponseTo;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
