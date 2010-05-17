#pragma warning disable 0612
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

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
            WriteToString(new List<int>() { 1, 2, 3 }).Should().Be("22-00-00-00-04-61-00-1A-00-00-00-10-30-00-01-00-00-00-10-31-00-02-00-00-00-10-32-00-03-00-00-00-00-00");
        }

        /// <summary>
        ///A test for element_binary
        ///</summary>
        [TestMethod()]
        public void element_binaryTest()
        {
            WriteToString(new DBBinary(BinaryType.Binary, new byte[] { 1, 2, 3 })).Should().Be("10-00-00-00-05-61-00-03-00-00-00-02-01-02-03-00");
        }

        /// <summary>
        ///A test for element_boolean
        ///</summary>
        [TestMethod()]
        public void element_booleanTest()
        {
            WriteToString(true).Should().Be("09-00-00-00-08-61-00-01-00");
        }

        /// <summary>
        ///A test for element_code
        ///</summary>
        [TestMethod()]
        public void element_codeTest()
        {
            WriteToString(new DBCode("i++")).Should().Be("10-00-00-00-0D-61-00-04-00-00-00-69-2B-2B-00-00");
        }

        /// <summary>
        ///A test for element_date
        ///</summary>
        [TestMethod()]
        public void element_dateTest()
        {
            WriteToString(new DateTime(2009, 6, 17)).Should().Be("10-00-00-00-09-61-00-00-80-1A-B1-F5-BC-CB-08-00");
        }

        /// <summary>
        ///A test for element_int
        ///</summary>
        [TestMethod()]
        public void element_intTest()
        {
            WriteToString(42).Should().Be("0C-00-00-00-10-61-00-2A-00-00-00-00");
        }

        /// <summary>
        ///A test for element_long
        ///</summary>
        [TestMethod()]
        public void element_longTest()
        {
            WriteToString(42L).Should().Be("10-00-00-00-12-61-00-2A-00-00-00-00-00-00-00-00");
        }

        /// <summary>
        ///A test for element_null
        ///</summary>
        [TestMethod()]
        public void element_nullTest()
        {
            WriteToString(null).Should().Be("08-00-00-00-0A-61-00-00");
        }

        /// <summary>
        ///A test for element_object
        ///</summary>
        [TestMethod()]
        public void element_objectTest()
        {
            WriteToString(new DBObject("b", 2)).Should().Be("14-00-00-00-03-61-00-0C-00-00-00-10-62-00-02-00-00-00-00-00");
        }

        /// <summary>
        ///A test for element_oid
        ///</summary>
        [TestMethod()]
        public void element_oidTest()
        {
            WriteToString(new Oid(new byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 })).Should().Be("14-00-00-00-07-61-00-01-00-00-00-00-00-00-00-00-00-00-01-00");
        }

        /// <summary>
        ///A test for element_ref
        ///</summary>
        [TestMethod()]
        public void element_refTest()
        {
            WriteToString(new DBRef(Mongo.DefaultDatabase.SystemUsersCollection, "gandalf")).Should().Be("35-00-00-00-03-61-00-2D-00-00-00-02-24-72-65-66-00-0D-00-00-00-73-79-73-74-65-6D-2E-75-73-65-72-73-00-02-24-69-64-00-08-00-00-00-67-61-6E-64-61-6C-66-00-00-00");
        }

        /// <summary>
        ///A test for element_regex
        ///</summary>
        [TestMethod()]
        public void element_regexTest()
        {
            WriteToString(new Regex(".*\\.jpg$")).Should().Be("12-00-00-00-0B-61-00-2E-2A-5C-2E-6A-70-67-24-00-00-00");
        }

        /// <summary>
        ///A test for element_string
        ///</summary>
        [TestMethod()]
        public void element_stringTest()
        {
            WriteToString("devfuel").Should().Be("14-00-00-00-02-61-00-08-00-00-00-64-65-76-66-75-65-6C-00-00");
        }

        /// <summary>
        ///A test for element_symbol
        ///</summary>
        [TestMethod()]
        public void element_symbolTest()
        {
            WriteToString(new DBSymbol("s")).Should().Be("0E-00-00-00-0E-61-00-02-00-00-00-73-00-00");
        }

        /// <summary>
        ///A test for element_timestamp
        ///</summary>
        [TestMethod()]
        public void element_timestampTest()
        {
            WriteToString(new DBTimestamp(34, 2)).Should().Be("10-00-00-00-11-61-00-22-00-00-00-02-00-00-00-00");
        }
    }
}
