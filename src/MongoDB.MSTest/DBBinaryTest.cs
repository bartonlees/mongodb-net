using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBBinaryTest and is intended
    ///to contain all DBBinaryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBBinaryTest
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
        ///A test for DBBinary Constructor
        ///</summary>
        [TestMethod()]
        public void DBBinaryConstructorTest()
        {
            BinaryType type = new BinaryType(); // TODO: Initialize to an appropriate value
            byte[] data = null; // TODO: Initialize to an appropriate value
            DBBinary target = new DBBinary(type, data);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Buffer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void BufferTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinary_Accessor target = new DBBinary_Accessor(param0); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            target.Buffer = expected;
            actual = target.Buffer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void TypeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            DBBinary_Accessor target = new DBBinary_Accessor(param0); // TODO: Initialize to an appropriate value
            BinaryType expected = new BinaryType(); // TODO: Initialize to an appropriate value
            BinaryType actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
