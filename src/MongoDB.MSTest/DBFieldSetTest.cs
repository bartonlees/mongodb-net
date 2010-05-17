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
            DBFieldSet target = new DBFieldSet("a", "b", "c");
            target.Keys.Should().Contain(new string[] { "a", "b", "c" });
        }

        /// <summary>
        ///A test for DBFieldSet Constructor
        ///</summary>
        [TestMethod()]
        public void DBFieldSetConstructorTest1()
        {
            IEnumerable<string> fieldNames = new string[] { "a", "b", "c" };
            DBFieldSet target = new DBFieldSet(fieldNames);
            target.Keys.Should().Contain(new string[] { "a", "b", "c" });
        }

        /// <summary>
        ///A test for GenerateIndexUri
        ///</summary>
        [TestMethod()]
        public void GenerateIndexUriTest()
        {
            DBFieldSet target = new DBFieldSet("a","b","c");
            Uri expected = new Uri("a_1_b_1_c_1", UriKind.Relative);
            Uri actual = target.GenerateIndexUri();
            actual.Should().Be(expected);
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            DBFieldSet fieldSet = new DBFieldSet("a", "b", "c");
            string[] expected = new string[] {"a", "b", "c"};
            string[] actual;
            actual = fieldSet;
            actual.Should().Contain(expected);
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest1()
        {
            string[] s = new string[] { "a", "b", "c" };
            DBFieldSet expected = new DBFieldSet("a", "b", "c");
            DBFieldSet actual;
            actual = s;
            actual.Should().Contain(expected);
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest2()
        {
            DBFieldSet fieldSet = new DBFieldSet("a", "b", "c");
            string expected = "a";
            string actual;
            actual = fieldSet;
            actual.Should().Be(expected);
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest3()
        {
            string s = "a,b,c";
            DBFieldSet expected = new DBFieldSet("a", "b", "c");
            DBFieldSet actual;
            actual = s;
            actual.Should().Contain(expected);
        }

        /// <summary>
        ///A test for IDKeyFieldSet
        ///</summary>
        [TestMethod()]
        public void IDKeyFieldSetTest()
        {
            DBFieldSet.IDKeyFieldSet.Keys.Should().Contain("_id");
        }
    }
}
