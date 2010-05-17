using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DocumentTest and is intended
    ///to contain all DocumentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DocumentTest
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
        ///A test for Document Constructor
        ///</summary>
        [TestMethod()]
        public void DocumentConstructorTest()
        {
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            Document target = new Document(key, value);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Document Constructor
        ///</summary>
        [TestMethod()]
        public void DocumentConstructorTest1()
        {
            string key1 = string.Empty; // TODO: Initialize to an appropriate value
            object value1 = null; // TODO: Initialize to an appropriate value
            string key2 = string.Empty; // TODO: Initialize to an appropriate value
            object value2 = null; // TODO: Initialize to an appropriate value
            Document target = new Document(key1, value1, key2, value2);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Document Constructor
        ///</summary>
        [TestMethod()]
        public void DocumentConstructorTest2()
        {
            string key1 = string.Empty; // TODO: Initialize to an appropriate value
            object value1 = null; // TODO: Initialize to an appropriate value
            string key2 = string.Empty; // TODO: Initialize to an appropriate value
            object value2 = null; // TODO: Initialize to an appropriate value
            string key3 = string.Empty; // TODO: Initialize to an appropriate value
            object value3 = null; // TODO: Initialize to an appropriate value
            Document target = new Document(key1, value1, key2, value2, key3, value3);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Document Constructor
        ///</summary>
        [TestMethod()]
        public void DocumentConstructorTest3()
        {
            IDictionary<string, object> obj = null; // TODO: Initialize to an appropriate value
            Document target = new Document(obj);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Document Constructor
        ///</summary>
        [TestMethod()]
        public void DocumentConstructorTest4()
        {
            Oid id = null; // TODO: Initialize to an appropriate value
            bool partial = false; // TODO: Initialize to an appropriate value
            Document target = new Document(id, partial);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Document Constructor
        ///</summary>
        [TestMethod()]
        public void DocumentConstructorTest5()
        {
            Oid id = null; // TODO: Initialize to an appropriate value
            Document target = new Document(id);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Document Constructor
        ///</summary>
        [TestMethod()]
        public void DocumentConstructorTest6()
        {
            Document target = new Document();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        [TestMethod()]
        public void CollectionTest()
        {
            //Document target = new Document(); // TODO: Initialize to an appropriate value
            //IDBCollection expected = null; // TODO: Initialize to an appropriate value
            //IDBCollection actual;
            //target.Collection = expected;
            //actual = target.Collection;
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        [TestMethod()]
        public void IDTest()
        {
            Document target = new Document(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.ID = expected;
            actual = target.ID;
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Partial
        ///</summary>
        [TestMethod()]

        public void PartialTest()
        {
            //Document_Accessor target = new Document_Accessor(); // TODO: Initialize to an appropriate value
            //bool expected = false; // TODO: Initialize to an appropriate value
            //bool actual;
            //target.Partial = expected;
            //actual = target.Partial;
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for State
        ///</summary>
        [TestMethod()]

        public void StateTest()
        {
            //Document_Accessor target = new Document_Accessor(); // TODO: Initialize to an appropriate value
            //DocumentState expected = new DocumentState(); // TODO: Initialize to an appropriate value
            //DocumentState actual;
            //target.State = expected;
            //actual = target.State;
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
