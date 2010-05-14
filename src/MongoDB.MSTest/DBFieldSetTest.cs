using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBFieldSetTest and is intended
    ///to contain all DBFieldSetTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBFieldSetTest
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
        ///A test for DBFieldSet Constructor
        ///</summary>
        [TestMethod()]
        public void DBFieldSetConstructorTest()
        {
            IEnumerable<string> fieldNames = null; // TODO: Initialize to an appropriate value
            DBFieldSet target = new DBFieldSet(fieldNames);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBFieldSet Constructor
        ///</summary>
        [TestMethod()]
        public void DBFieldSetConstructorTest1()
        {
            string[] fieldNames = null; // TODO: Initialize to an appropriate value
            DBFieldSet target = new DBFieldSet(fieldNames);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GenerateIndexUri
        ///</summary>
        [TestMethod()]
        public void GenerateIndexUriTest()
        {
            string[] fieldNames = null; // TODO: Initialize to an appropriate value
            DBFieldSet target = new DBFieldSet(fieldNames); // TODO: Initialize to an appropriate value
            Uri expected = null; // TODO: Initialize to an appropriate value
            Uri actual;
            actual = target.GenerateIndexUri();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            DBFieldSet fieldSet = null; // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = fieldSet;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest1()
        {
            string[] s = null; // TODO: Initialize to an appropriate value
            DBFieldSet expected = null; // TODO: Initialize to an appropriate value
            DBFieldSet actual;
            actual = s;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest2()
        {
            DBFieldSet fieldSet = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = fieldSet;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest3()
        {
            string s = string.Empty; // TODO: Initialize to an appropriate value
            DBFieldSet expected = null; // TODO: Initialize to an appropriate value
            DBFieldSet actual;
            actual = s;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IDKeyFieldSet
        ///</summary>
        [TestMethod()]
        public void IDKeyFieldSetTest()
        {
            DBFieldSet actual;
            actual = DBFieldSet.IDKeyFieldSet;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
