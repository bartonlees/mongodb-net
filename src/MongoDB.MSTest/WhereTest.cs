using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using FluentAssertions;
using System.Text.RegularExpressions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for WhereTest and is intended
    ///to contain all WhereTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WhereTest
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
        ///A test for Field
        ///</summary>
        [TestMethod()]
        public void FieldTest()
        {
            DBQuery query = Where.Field(test => test.Matches(new Regex("^a$")));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            query["test"].ToString().Should().Be(new Regex("^a$").ToString());
        }

        /// <summary>
        ///A test for Fields
        ///</summary>
        [TestMethod()]
        public void FieldsTest()
        {
            DBQuery query = Where.Fields((a, b) => a == 1 && b == 2);
            query.ContainsKey("a").Should().BeTrue("the query should have generated an 'a' key");
            query.ContainsKey("b").Should().BeTrue("the query should have generated a 'b' key");
            query["a"].Should().Be(1);
            query["b"].Should().Be(2);
        }

        /// <summary>
        ///A test for Fields
        ///</summary>
        [TestMethod()]
        public void FieldsTest1()
        {
            DBQuery query = Where.Fields((a, b, c) => a == 1 && b == 2 && c == 3);
            query.ContainsKey("a").Should().BeTrue("the query should have generated an 'a' key");
            query.ContainsKey("b").Should().BeTrue("the query should have generated a 'b' key");
            query.ContainsKey("c").Should().BeTrue("the query should have generated a 'b' key");
            query["a"].Should().Be(1);
            query["b"].Should().Be(2);
            query["c"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaTwoFieldsEqualMirror()
        {
            DBQuery query = Where.Fields((a, b) => b == 1 && a == 2);
            query.ContainsKey("a").Should().BeTrue("the query should have generated an 'a' key");
            query.ContainsKey("b").Should().BeTrue("the query should have generated a 'b' key");
            query["b"].Should().Be(1);
            query["a"].Should().Be(2);
        }

        [TestMethod]
        public void LambdaTwoFieldsExplicitNaming()
        {
            DBQuery query = Where.Fields((a, b) => b["c"] == 1 && a["d"] == 2);
            query.ContainsKey("c").Should().BeTrue("the query should have generated an 'c' key");
            query.ContainsKey("d").Should().BeTrue("the query should have generated a 'd' key");
            query["c"].Should().Be(1);
            query["d"].Should().Be(2);
        }

        [TestMethod]
        public void LambdaGtAndLt()
        {
            DBQuery query = Where.Field(test => test > 1 && test < 7);
            query.ContainsKey("test").Should().BeTrue("the query should have generated an 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested["$lt"].Should().Be(7);
            nested["$gt"].Should().Be(1);
        }

        [TestMethod]
        public void LambdaDuplicateExplicitNames()
        {
            new Action(() => Where.Fields((a, b, c) => a["b"] > 1 && b < 7 && c == 4)).ShouldThrow<Exception>("two identical field names are not allowed");
        }

        //TODO:Enable logical contradiction testing
        //[TestMethod]
        //public void LambdaInvalidExpressions()
        //{
        //    () => Where.Field(a => a == 3 || a != 3), Throws.Exception, "Or is not allowed");
        //}
    }
}
