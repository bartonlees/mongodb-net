using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SharpTestsEx;

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
            DBBinary target;
            target = new DBBinary(BinaryType.Binary, new byte[] { 1, 2, 1, 2, 12, 2, 2 });
            target = new DBBinary(BinaryType.Function, new byte[] { 1, 2, 1, 2, 12, 2, 2 });
            target = new DBBinary(BinaryType.MD5, new byte[] { 1, 2, 1, 2, 12, 2, 2 });
            target = new DBBinary(BinaryType.UserDefined, new byte[] { 1, 2, 1, 2, 12, 2, 2 });
            target = new DBBinary(BinaryType.UUID, new byte[] { 1, 2, 1, 2, 12, 2, 2 });
        }

        /// <summary>
        ///A test for Buffer
        ///</summary>
        [TestMethod()]
        public void BufferTest()
        {
            DBBinary target;
            target = new DBBinary(BinaryType.Binary, new byte[] { 1, 2, 1, 2, 12, 2, 2 });
            target.Buffer.Should().Have.SameSequenceAs( new byte[] {1, 2, 1, 2, 12, 2, 2});
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            DBBinary target;
            target = new DBBinary(BinaryType.Binary, new byte[] { 1, 2, 1, 2, 12, 2, 2 });
            target.Type.Should().Be(BinaryType.Binary);
        }
    }
}
