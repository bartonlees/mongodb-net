using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using System.Text;

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
        [TestMethod]
        public void DBBinaryByteArrayRoundtrip()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testBinary");
            c.Drop();
            c.Save(new Document() { { "a", Encoding.UTF8.GetBytes("devfuel") } });
            Encoding.UTF8.GetString((byte[])c.FindOne()["a"]).Should().Be("devfuel", "byte array came from roundtrip");
            c.Drop();
        }

        [TestMethod]
        public void DBBinaryRoundtrip()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testBinary");
            c.Drop();

            c.Save(new Document("a", new DBBinary(BinaryType.Binary, Encoding.UTF8.GetBytes("devfuel"))));

            Encoding.UTF8.GetString((byte[])c.FindOne().GetAs<byte[]>("a")).Should().Be("devfuel", "DBBinary came from roundtrip");
        }

        [TestMethod]
        public void DBBinaryUserDefinedRoundtrip()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testBinary");
            c.Drop();

            c.Save(new Document("a", new DBBinary(BinaryType.UserDefined, Encoding.UTF8.GetBytes("devfuel"))));

            Encoding.UTF8.GetString(c.FindOne().GetAs<DBBinary>("a").Buffer).Should().Be("devfuel", "UserDefined DBBinary roundtrip failed");
        }


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
            byte[] buffer = new byte[] { 1, 2, 1, 2, 12, 2, 2 };
            target = new DBBinary(BinaryType.Binary, buffer);
            target.Buffer.ToDashedHexString().Should().Be(buffer.ToDashedHexString());
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
