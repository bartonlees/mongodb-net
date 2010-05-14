#pragma warning disable 0612
using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using FluentAssertions;
using System.Collections.Generic;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for WireProtocolWriterTest and is intended
    ///to contain all WireProtocolWriterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WireProtocolWriterTest
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
        ///A test for WireProtocolWriter Constructor
        ///</summary>
        [TestMethod()]
        public void WireProtocolWriterConstructorTest()
        {
            Stream stream = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter target = new WireProtocolWriter(stream);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for RewindAndWriteSize
        ///</summary>
        [TestMethod()]

        public void RewindAndWriteSizeTest()
        {
            //PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            //WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            //long sizePos = 0; // TODO: Initialize to an appropriate value
            //target.RewindAndWriteSize(sizePos);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            Stream stream = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter target = new WireProtocolWriter(stream); // TODO: Initialize to an appropriate value
            IDBObject o = null; // TODO: Initialize to an appropriate value
            target.Write(o);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        public string WriteToString(object value)
        {
            DBObject obj = new DBObject("a", value);

            string result = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            using (WireProtocolWriter writer = new WireProtocolWriter(stream))
            {
                writer.Write(obj);
                result = BitConverter.ToString(stream.GetBuffer(), 0, (int)stream.Length);
            }
            return result;
        }

        /// <summary>
        ///A test for element_array
        ///</summary>
        [TestMethod()]
        public void element_arrayTest()
        {
            WriteToString(new List<int>() { 1, 2, 3 }).Should().Be("");
        }

        /// <summary>
        ///A test for element_binary
        ///</summary>
        [TestMethod()]
        public void element_binaryTest()
        {
            WriteToString(new DBBinary(BinaryType.Binary, new byte[] { 1,2,3})).Should().Be("");
        }

        /// <summary>
        ///A test for element_boolean
        ///</summary>
        [TestMethod()]
        public void element_booleanTest()
        {
            WriteToString(true).Should().Be("");
        }

        /// <summary>
        ///A test for element_code
        ///</summary>
        [TestMethod()]
        public void element_codeTest()
        {
            WriteToString(new DBCode("i++")).Should().Be("");
        }

        /// <summary>
        ///A test for element_date
        ///</summary>
        [TestMethod()]
        public void element_dateTest()
        {
            WriteToString(new DateTime(2009, 6, 17)).Should().Be("");
        }

        /// <summary>
        ///A test for element_int
        ///</summary>
        [TestMethod()]
        public void element_intTest()
        {
            WriteToString(42).Should().Be("");
        }

        /// <summary>
        ///A test for element_long
        ///</summary>
        [TestMethod()]
        public void element_longTest()
        {
            WriteToString(42L).Should().Be("");
        }

        /// <summary>
        ///A test for element_null
        ///</summary>
        [TestMethod()]
        public void element_nullTest()
        {
            WriteToString(null).Should().Be("");
        }

        /// <summary>
        ///A test for element_object
        ///</summary>
        [TestMethod()]
        public void element_objectTest()
        {
            WriteToString(new DBObject("b",2)).Should().Be("");
        }

        /// <summary>
        ///A test for element_oid
        ///</summary>
        [TestMethod()]
        public void element_oidTest()
        {
            WriteToString(new Oid(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 })).Should().Be("");
        }

        /// <summary>
        ///A test for element_ref
        ///</summary>
        [TestMethod()]
        public void element_refTest()
        {
            WriteToString(new DBRef(Mongo.DefaultDatabase.SystemUsersCollection, "gandalf")).Should().Be("");
        }

        /// <summary>
        ///A test for element_regex
        ///</summary>
        [TestMethod()]
        public void element_regexTest()
        {
            WriteToString(new Regex(".*\\.jpg$")).Should().Be("");
        }

        /// <summary>
        ///A test for element_string
        ///</summary>
        [TestMethod()]
        public void element_stringTest()
        {
            WriteToString("devfuel").Should().Be("");
        }

        /// <summary>
        ///A test for element_symbol
        ///</summary>
        [TestMethod()]
        public void element_symbolTest()
        {
            WriteToString(new DBSymbol("s")).Should().Be("");
        }

        /// <summary>
        ///A test for element_timestamp
        ///</summary>
        [TestMethod()]
        public void element_timestampTest()
        {
            WriteToString(new DBTimestamp(34,2)).Should().Be("");
        }
    }
}
