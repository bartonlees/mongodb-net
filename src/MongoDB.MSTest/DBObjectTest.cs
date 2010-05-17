using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBObjectTest and is intended
    ///to contain all DBObjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBObjectTest
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
        public void RemoveTest()
        {
            DBObject obj = new DBObject();
            obj["test"] = "y";
            obj["y"] = "z";

            Assert.IsTrue(obj.ContainsKey("test"));
            Assert.IsTrue(obj.ContainsKey("y"));

            obj.Remove("test");

            Assert.IsFalse(obj.ContainsKey("test"));
            Assert.IsTrue(obj.ContainsKey("y"));

            obj["test"] = "y";

            Assert.IsTrue(obj.ContainsKey("test"));
            Assert.IsTrue(obj.ContainsKey("y"));
        }




        [TestMethod]
        public void EntryOrder()
        {
            DBObject o = new DBObject();
            o["u"] = 0;
            o["m"] = 1;
            o["p"] = 2;
            o["i"] = 3;
            o["r"] = 4;
            o["e"] = 5;
            o["s"] = 6;
            string[] keys = new string[7];
            o.Keys.CopyTo(keys, 0);
            string.Join("", keys).Should().Be("umpires", "keys should be in order added");

            List<KeyValuePair<string, object>> pairs = new List<KeyValuePair<string, object>>(o);
            for (int i = 0; i < 7; i++)
            {
                pairs[i].Value.Should().Be(i, "pairs should be in order added");
            }
        }


        /// <summary>
        ///A test for DBObject Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectConstructorTest()
        {
            DBObject target = new DBObject("a", 1);
            target["a"].Should().Be(1);
        }

        /// <summary>
        ///A test for DBObject Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectConstructorTest2()
        {
            DBObject target = new DBObject();            
        }

        /// <summary>
        ///A test for DBObject Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectConstructorTest4()
        {
            Dictionary<string, object> m = new Dictionary<string, object>();
            m["key"] = "value";
            m["foo"] = 1;
            m["bar"] = null;

            IDBObject obj = new DBObject(m);
            obj["key"].Should().Be("value");
            obj["foo"].Should().Be(1);
            obj["bar"].Should().BeNull();
        }

        /// <summary>
        ///A test for Append
        ///</summary>
        [TestMethod()]
        public void AppendTest()
        {
            DBObject target = new DBObject();
            target.Count.Should().Be(0);
            target.Append("a", 1);
            target.Count.Should().Be(1);
            target.Append("b", 2);
            target.Count.Should().Be(2);
            target["b"].Should().Be(2);
        }

        /// <summary>
        ///A test for PutAll
        ///</summary>
        [TestMethod()]
        public void PutAllTest()
        {
            IDBObject start = new DBObject() { { "a", 7 }, { "d", 4 } };
            start.PutAll(new DBObject() { { "a", 1 }, { "b", 2 }, { "c", 3 } });

            start["a"].Should().Be(1, "put should have overwritten a");
            start["b"].Should().Be(2, "put should have added b");
            start["c"].Should().Be(3, "put should have added c");
            start["d"].Should().Be(4, "d was not in the put");
        }
    }
}
