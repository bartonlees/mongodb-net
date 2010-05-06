using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

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
        [DeploymentItem("MongoDB.Driver.dll")]
        public void RewindAndWriteSizeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            long sizePos = 0; // TODO: Initialize to an appropriate value
            target.RewindAndWriteSize(sizePos);
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

        /// <summary>
        ///A test for _dontRefContains
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void _dontRefContainsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            object o = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target._dontRefContains(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _handleSpecialObjects
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void _handleSpecialObjectsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IDBObject o = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target._handleSpecialObjects(name, o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for element
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void elementTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            object val = null; // TODO: Initialize to an appropriate value
            target.element(name, val);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_array
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_arrayTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IList list = null; // TODO: Initialize to an appropriate value
            target.element_array(name, list);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_binary
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_binaryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            byte[] data = null; // TODO: Initialize to an appropriate value
            target.element_binary(name, data);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_binary
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_binaryTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DBBinary val = null; // TODO: Initialize to an appropriate value
            target.element_binary(name, val);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_boolean
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_booleanTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            bool b = false; // TODO: Initialize to an appropriate value
            target.element_boolean(name, b);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_code
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_codeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            string code = string.Empty; // TODO: Initialize to an appropriate value
            target.element_code(name, code);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_date
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_dateTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DateTime d = new DateTime(); // TODO: Initialize to an appropriate value
            target.element_date(name, d);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_int
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_intTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            int value = 0; // TODO: Initialize to an appropriate value
            target.element_int(name, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_long
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_longTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            target.element_long(name, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_name
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_nameTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            target.element_name(name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_nullTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            target.element_null(name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_number
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_numberTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            double value = 0F; // TODO: Initialize to an appropriate value
            target.element_number(name, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_number
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_numberTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            float value = 0F; // TODO: Initialize to an appropriate value
            target.element_number(name, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_object
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_objectTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DBRef reference = null; // TODO: Initialize to an appropriate value
            target.element_object(name, reference);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_object
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_objectTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IDictionary dictionary = null; // TODO: Initialize to an appropriate value
            target.element_object(name, dictionary);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_object
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_objectTest2()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IDBObject obj = null; // TODO: Initialize to an appropriate value
            target.element_object(name, obj);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_oid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_oidTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Oid oid = null; // TODO: Initialize to an appropriate value
            target.element_oid(name, oid);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_ref
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_refTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            string ns = string.Empty; // TODO: Initialize to an appropriate value
            Oid oid = null; // TODO: Initialize to an appropriate value
            target.element_ref(name, ns, oid);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_regex
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_regexTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DBRegex regex = null; // TODO: Initialize to an appropriate value
            target.element_regex(name, regex);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_regex
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_regexTest1()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Regex p = null; // TODO: Initialize to an appropriate value
            target.element_regex(name, p);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_string
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_stringTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            target.element_string(name, s);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_symbol
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_symbolTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DBSymbol s = null; // TODO: Initialize to an appropriate value
            target.element_symbol(name, s);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_timestamp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_timestampTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            DBTimestamp ts = null; // TODO: Initialize to an appropriate value
            target.element_timestamp(name, ts);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_type
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_typeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            byte type = 0; // TODO: Initialize to an appropriate value
            target.element_type(type);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for element_undefined
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void element_undefinedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolWriter_Accessor target = new WireProtocolWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            target.element_undefined(name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
