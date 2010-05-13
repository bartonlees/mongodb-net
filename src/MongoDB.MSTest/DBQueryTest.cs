using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
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
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            Assert.That(query["test"], Is.EqualTo(1));
        }

        [Test]
        public void LambdaSimpleEqMirror()
        {
            DBQuery query = Where.Field(test => 1 == test);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            Assert.That(query["test"], Is.EqualTo(1));
        }

        [Test]
        public void LambdaSimpleNe()
        {
            DBQuery query = Where.Field(test => test != 3);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$ne"), "the query should have generated a nested '$ne' key");
            Assert.That(nested["$ne"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleNeMirror()
        {
            DBQuery query = Where.Field(test => 3 != test);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$ne"), "the query should have generated a nested '$ne' key");
            Assert.That(nested["$ne"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleGt()
        {
            DBQuery query = Where.Field(test => test > 3);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$gt"), "the query should have generated a nested '$gt' key");
            Assert.That(nested["$gt"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleGtMirror()
        {
            DBQuery query = Where.Field(test => 3 > test);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$lte"), "the query should have generated a nested '$lte' key");
            Assert.That(nested["$lte"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleLt()
        {
            DBQuery query = Where.Field(test => test < 3);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$lt"), "the query should have generated a nested '$lt' key");
            Assert.That(nested["$lt"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleLtMirror()
        {
            DBQuery query = Where.Field(test => 3 < test);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$gte"), "the query should have generated a nested '$gte' key");
            Assert.That(nested["$gte"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleGte()
        {
            DBQuery query = Where.Field(test => test >= 3);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$gte"), "the query should have generated a nested '$gte' key");
            Assert.That(nested["$gte"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleGteMirror()
        {
            DBQuery query = Where.Field(test => 3 >= test);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$lt"), "the query should have generated a nested '$lt' key");
            Assert.That(nested["$lt"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleLte()
        {
            DBQuery query = Where.Field(test => test <= 3);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$lte"), "the query should have generated a nested '$lte' key");
            Assert.That(nested["$lte"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleLteMirror()
        {
            DBQuery query = Where.Field(test => 3 <= test);
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$gt"), "the query should have generated a nested '$gt' key");
            Assert.That(nested["$gt"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleIn()
        {
            DBQuery query = Where.Field(test => test.In(new int[] { 1, 2, 3 }));
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$in"), "the query should have generated a nested '$in' key");
            Assert.That(nested["$in"], Is.TypeOf<int[]>());
            Assert.That(nested["$in"], Is.EquivalentTo(new int[] { 1, 2, 3 }));
        }

        [Test]
        public void LambdaSimpleNin()
        {
            DBQuery query = Where.Field(test => test.Nin(new int[] { 1, 2, 3 }));
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$nin"), "the query should have generated a nested '$nin' key");
            Assert.That(nested["$nin"], Is.TypeOf<int[]>());
            Assert.That(nested["$nin"], Is.EquivalentTo(new int[] { 1, 2, 3 }));
        }

        [Test]
        public void LambdaSimpleAll()
        {
            DBQuery query = Where.Field(test => test.All(new int[] { 1, 2, 3 }));
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$all"), "the query should have generated a nested '$all' key");
            Assert.That(nested["$all"], Is.TypeOf<int[]>());
            Assert.That(nested["$all"], Is.EquivalentTo(new int[] { 1, 2, 3 }));
        }

        [Test]
        public void LambdaSimpleSizeInt()
        {
            DBQuery query = Where.Field(test => test.Size(3));
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$size"), "the query should have generated a nested '$size' key");
            Assert.That(nested["$size"], Is.TypeOf<int>());
            Assert.That(nested["$size"], Is.EqualTo(3));
        }

        [Test]
        public void LambdaSimpleSizeLong()
        {
            DBQuery query = Where.Field(test => test.Size(3L));
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$size"), "the query should have generated a nested '$size' key");
            Assert.That(nested["$size"], Is.TypeOf<long>());
            Assert.That(nested["$size"], Is.EqualTo(3L));
        }

        [Test]
        public void LambdaSimpleModInt()
        {
            DBQuery query = Where.Field(test => test.Mod(2,3));
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$mod"), "the query should have generated a nested '$mod' key");
            Assert.That(nested["$mod"], Is.TypeOf<int[]>());
            Assert.That(nested["$mod"], Is.EqualTo(new int[] { 2, 3 }));
        }

        [Test]
        public void LambdaSimpleModLong()
        {
            DBQuery query = Where.Field(test => test.Mod(2L, 3L));
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$mod"), "the query should have generated a nested '$mod' key");
            Assert.That(nested["$mod"], Is.TypeOf<long[]>());
            Assert.That(nested["$mod"], Is.EqualTo(new long[] { 2, 3 }));
        }

        [Test]
        public void LambdaSimpleExists()
        {
            DBQuery query = Where.Field(test => test.Exists());
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$exists"), "the query should have generated a nested '$exists' key");
            Assert.That(nested["$exists"], Is.TypeOf<bool>());
            Assert.That(nested["$exists"], Is.EqualTo(true));
        }

        [Test]
        public void LambdaSimpleNexists()
        {
            DBQuery query = Where.Field(test => test.Nexists());
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested, Is.Not.Null);
            Assert.That(nested.ContainsKey("$exists"), "the query should have generated a nested '$exists' key");
            Assert.That(nested["$exists"], Is.TypeOf<bool>());
            Assert.That(nested["$exists"], Is.EqualTo(false));
        }

        [Test]
        public void LambdaSimpleMatches()
        {
            DBQuery query = Where.Field(test => test.Matches(new Regex("^a$")));
            Assert.That(query.ContainsKey("test"), "the query should have generated a 'test' key");
            Assert.That(query["test"].ToString(), Is.EqualTo(new Regex("^a$").ToString()));
        }

        [Test]
        public void LambdaTwoFieldsEqual()
        {
            DBQuery query = Where.Fields((a, b) => a == 1 && b == 2);
            Assert.That(query.ContainsKey("a"), "the query should have generated an 'a' key");
            Assert.That(query.ContainsKey("b"), "the query should have generated a 'b' key");
            Assert.That(query["a"], Is.EqualTo(1));
            Assert.That(query["b"], Is.EqualTo(2));
        }

        [Test]
        public void LambdaTwoFieldsEqualMirror()
        {
            DBQuery query = Where.Fields((a, b) => b == 1 && a == 2);
            Assert.That(query.ContainsKey("a"), "the query should have generated an 'a' key");
            Assert.That(query.ContainsKey("b"), "the query should have generated a 'b' key");
            Assert.That(query["b"], Is.EqualTo(1));
            Assert.That(query["a"], Is.EqualTo(2));
        }

        [Test]
        public void LambdaTwoFieldsExplicitNaming()
        {
            DBQuery query = Where.Fields((a, b) => b["c"] == 1 && a["d"] == 2);
            Assert.That(query.ContainsKey("c"), "the query should have generated an 'a' key");
            Assert.That(query.ContainsKey("d"), "the query should have generated a 'b' key");
            Assert.That(query["c"], Is.EqualTo(1));
            Assert.That(query["d"], Is.EqualTo(2));
        }

        [Test]
        public void LambdaGtAndLt()
        {
            DBQuery query = Where.Field(test => test > 1 && test < 7);
            Assert.That(query.ContainsKey("test"), "the query should have generated an 'a' key");
            IDBObject nested = query.GetAsIDBObject("test");
            Assert.That(nested["$lt"], Is.EqualTo(7));
            Assert.That(nested["$gt"], Is.EqualTo(1));
        }

        [Test]
        public void LambdaDuplicateExplicitNames()
        {
            Assert.That(() => Where.Fields((a, b, c) => a["b"] > 1 && b < 7 && c == 4), Throws.Exception, "shouldn't allow two identical field names");
        }

        //TODO:Enable logical contradiction testing
        //[Test]
        //public void LambdaInvalidExpressions()
        //{
        //    Assert.That(() => Where.Field(a => a == 3 || a != 3), Throws.Exception, "Or is not allowed");
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
