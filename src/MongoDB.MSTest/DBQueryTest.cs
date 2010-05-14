using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Text.RegularExpressions;
namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBQueryTest and is intended
    ///to contain all DBQueryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBQueryTest
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
        public void LambdaSimpleEq()
        {
            DBQuery query = Where.Field(test => test == 1);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            query["test"].Should().Be(1);
        }

        [TestMethod]
        public void LambdaSimpleEqMirror()
        {
            DBQuery query = Where.Field(test => 1 == test);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            query["test"].Should().Be(1);
        }

        [TestMethod]
        public void LambdaSimpleNe()
        {
            DBQuery query = Where.Field(test => test != 3);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$ne").Should().BeTrue("the query should have generated a nested '$ne' key");
            nested["$ne"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleNeMirror()
        {
            DBQuery query = Where.Field(test => 3 != test);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$ne").Should().BeTrue("the query should have generated a nested '$ne' key");
            nested["$ne"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleGt()
        {
            DBQuery query = Where.Field(test => test > 3);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$gt").Should().BeTrue("the query should have generated a nested '$gt' key");
            nested["$gt"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleGtMirror()
        {
            DBQuery query = Where.Field(test => 3 > test);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$lte").Should().BeTrue("the query should have generated a nested '$lte' key");
            nested["$lte"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleLt()
        {
            DBQuery query = Where.Field(test => test < 3);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$lt").Should().BeTrue("the query should have generated a nested '$lt' key");
            nested["$lt"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleLtMirror()
        {
            DBQuery query = Where.Field(test => 3 < test);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$gte").Should().BeTrue("the query should have generated a nested '$gte' key");
            nested["$gte"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleGte()
        {
            DBQuery query = Where.Field(test => test >= 3);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$gte").Should().BeTrue("the query should have generated a nested '$gte' key");
            nested["$gte"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleGteMirror()
        {
            DBQuery query = Where.Field(test => 3 >= test);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$lt").Should().BeTrue("the query should have generated a nested '$lt' key");
            nested["$lt"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleLte()
        {
            DBQuery query = Where.Field(test => test <= 3);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$lte").Should().BeTrue("the query should have generated a nested '$lte' key");
            nested["$lte"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleLteMirror()
        {
            DBQuery query = Where.Field(test => 3 <= test);
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$gt").Should().BeTrue("the query should have generated a nested '$gt' key");
            nested["$gt"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleIn()
        {
            DBQuery query = Where.Field(test => test.In(new int[] { 1, 2, 3 }));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$in").Should().BeTrue("the query should have generated a nested '$in' key");
            nested["$in"].Should().BeOfType<int[]>();
            ((int[])nested["$in"]).Should().Contain(new int[] { 1, 2, 3 });
        }

        [TestMethod]
        public void LambdaSimpleNin()
        {
            DBQuery query = Where.Field(test => test.Nin(new int[] { 1, 2, 3 }));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$nin").Should().BeTrue("the query should have generated a nested '$nin' key");
            nested["$nin"].Should().BeOfType<int[]>();
            ((int[])nested["$nin"]).Should().Contain(new int[] { 1, 2, 3 });
        }

        [TestMethod]
        public void LambdaSimpleAll()
        {
            DBQuery query = Where.Field(test => test.All(new int[] { 1, 2, 3 }));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$all").Should().BeTrue("the query should have generated a nested '$all' key");
            nested["$all"].Should().BeOfType<int[]>();
            ((int[])nested["$all"]).Should().Contain(new int[] { 1, 2, 3 });
        }

        [TestMethod]
        public void LambdaSimpleSizeInt()
        {
            DBQuery query = Where.Field(test => test.Size(3));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$size").Should().BeTrue("the query should have generated a nested '$size' key");
            nested["$size"].Should().BeOfType<int>();
            nested["$size"].Should().Be(3);
        }

        [TestMethod]
        public void LambdaSimpleSizeLong()
        {
            DBQuery query = Where.Field(test => test.Size(3L));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$size").Should().BeTrue("the query should have generated a nested '$size' key");
            nested["$size"].Should().BeOfType<long>();
            nested["$size"].Should().Be(3L);
        }

        [TestMethod]
        public void LambdaSimpleModInt()
        {
            DBQuery query = Where.Field(test => test.Mod(2, 3));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$mod").Should().BeTrue("the query should have generated a nested '$mod' key");
            nested["$mod"].Should().BeOfType<int[]>();
            nested["$mod"].Should().Be(new int[] { 2, 3 });
        }

        [TestMethod]
        public void LambdaSimpleModLong()
        {
            DBQuery query = Where.Field(test => test.Mod(2L, 3L));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$mod").Should().BeTrue("the query should have generated a nested '$mod' key");
            nested["$mod"].Should().BeOfType<long[]>();
            nested["$mod"].Should().Be(new long[] { 2, 3 });
        }

        [TestMethod]
        public void LambdaSimpleExists()
        {
            DBQuery query = Where.Field(test => test.Exists());
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$exists").Should().BeTrue("the query should have generated a nested '$exists' key");
            nested["$exists"].Should().BeOfType<bool>();
            nested["$exists"].Should().Be(true);
        }

        [TestMethod]
        public void LambdaSimpleNexists()
        {
            DBQuery query = Where.Field(test => test.Nexists());
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            nested.Should().NotBeNull();
            nested.ContainsKey("$exists").Should().BeTrue("the query should have generated a nested '$exists' key");
            nested["$exists"].Should().BeOfType<bool>();
            nested["$exists"].Should().Be(false);
        }

        [TestMethod]
        public void LambdaSimpleMatches()
        {
            DBQuery query = Where.Field(test => test.Matches(new Regex("^a$")));
            query.ContainsKey("test").Should().BeTrue("the query should have generated a 'test' key");
            query["test"].ToString().Should().Be(new Regex("^a$").ToString());
        }

        [TestMethod]
        public void LambdaTwoFieldsEqual()
        {
            DBQuery query = Where.Fields((a, b) => a == 1 && b == 2);
            query.ContainsKey("a").Should().BeTrue("the query should have generated an 'a' key");
            query.ContainsKey("b").Should().BeTrue("the query should have generated a 'b' key");
            query["a"].Should().Be(1);
            query["b"].Should().Be(2);
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
            query.ContainsKey("c").Should().BeTrue("the query should have generated an 'a' key");
            query.ContainsKey("d").Should().BeTrue("the query should have generated a 'b' key");
            query["c"].Should().Be(1);
            query["d"].Should().Be(2);
        }

        [TestMethod]
        public void LambdaGtAndLt()
        {
            DBQuery query = Where.Field(test => test > 1 && test < 7);
            query.ContainsKey("test").Should().BeTrue("the query should have generated an 'a' key");
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


        /// <summary>
        ///A test for DBQuery Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryConstructorTest()
        {
            IDictionary<string, object> obj = null; // TODO: Initialize to an appropriate value
            DBQuery target = new DBQuery(obj);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBQuery Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryConstructorTest1()
        {
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            DBQuery target = new DBQuery(key, value);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBQuery Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryConstructorTest2()
        {
            DBQuery target = new DBQuery();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBQuery Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryConstructorTest3()
        {
            string whereClause = string.Empty; // TODO: Initialize to an appropriate value
            DBQuery target = new DBQuery(whereClause);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("testWhere1");
            c.Drop();
            c.FindOne().Should().BeNull("the collection is empty after the drop");

            c.Save(new Document("a", 1));
            c.FindOne().Should().NotBeNull("we just added a document");

            c.FindOne("this.a == 1").Should().NotBeNull("the document matches the string query");
            c.FindOne("this.a == 2").Should().BeNull("the document does not match the string query");
        }

        /// <summary>
        ///A test for IsMaster
        ///</summary>
        [TestMethod()]
        public void IsMasterTest()
        {
            DBQuery actual;
            actual = DBQuery.IsMaster;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectAll
        ///</summary>
        [TestMethod()]
        public void SelectAllTest()
        {
            DBQuery actual;
            actual = DBQuery.SelectAll;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
