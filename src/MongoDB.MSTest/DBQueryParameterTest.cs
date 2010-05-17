using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using FluentAssertions;
using System.Text.RegularExpressions;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBQueryParameterTest and is intended
    ///to contain all DBQueryParameterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBQueryParameterTest
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
        ///A test for DBQueryParameter Constructor
        ///</summary>
        [TestMethod()]
        public void DBQueryParameterConstructorTest()
        {
            DBQueryParameter target = new DBQueryParameter();
        }

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
            nested.GetAs<int[]>("$mod").Should().Contain(new int[] { 2, 3 });
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
            nested.GetAs<long[]>("$mod").Should().Contain(new long[] { 2, 3 });
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
    }
}
