﻿using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for WireProtocolReaderTest and is intended
    ///to contain all WireProtocolReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WireProtocolReaderTest
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
        ///A test for WireProtocolReader Constructor
        ///</summary>
        [TestMethod()]
        public void WireProtocolReaderConstructorTest()
        {
            Stream stream = null; // TODO: Initialize to an appropriate value
            WireProtocolReader target = new WireProtocolReader(stream);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreateDocument
        ///</summary>
        public void CreateDocumentTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolReader_Accessor target = new WireProtocolReader_Accessor(param0); // TODO: Initialize to an appropriate value
            bool partial = false; // TODO: Initialize to an appropriate value
            TDoc expected = default(TDoc); // TODO: Initialize to an appropriate value
            TDoc actual;
            actual = target.CreateDocument<TDoc>(partial);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void CreateDocumentTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CreateDocumentTestHelper<TDoc>() with appropriate type parameters" +
                    ".");
        }

        /// <summary>
        ///A test for ReadDocument
        ///</summary>
        public void ReadDocumentTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            Stream stream = null; // TODO: Initialize to an appropriate value
            WireProtocolReader target = new WireProtocolReader(stream); // TODO: Initialize to an appropriate value
            bool partial = false; // TODO: Initialize to an appropriate value
            TDoc expected = null; // TODO: Initialize to an appropriate value
            TDoc actual;
            actual = target.ReadDocument<TDoc>(partial);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ReadDocumentTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call ReadDocumentTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for ReadNextElement
        ///</summary>
        public void ReadNextElementTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolReader_Accessor target = new WireProtocolReader_Accessor(param0); // TODO: Initialize to an appropriate value
            IDBObject o = null; // TODO: Initialize to an appropriate value
            bool partial = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ReadNextElement<TDoc>(o, partial);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void ReadNextElementTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call ReadNextElementTestHelper<TDoc>() with appropriate type parameter" +
                    "s.");
        }

        /// <summary>
        ///A test for cstring
        ///</summary>
        [TestMethod()]
        public void cstringTest()
        {
            Stream stream = null; // TODO: Initialize to an appropriate value
            WireProtocolReader target = new WireProtocolReader(stream); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.cstring();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for data_binary
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MongoDB.Driver.dll")]
        public void data_binaryTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            WireProtocolReader_Accessor target = new WireProtocolReader_Accessor(param0); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.data_binary();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for data_string
        ///</summary>
        [TestMethod()]
        public void data_stringTest()
        {
            Stream stream = null; // TODO: Initialize to an appropriate value
            WireProtocolReader target = new WireProtocolReader(stream); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.data_string();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}