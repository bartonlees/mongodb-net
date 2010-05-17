using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBModifierTest and is intended
    ///to contain all DBModifierTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBModifierTest
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
        /// A test for DBModifier Constructor
        /// </summary>
        [TestMethod()]
        public void DBModifierConstructorTest()
        {
            DBModifier target = new DBModifier("a", 1);
            target["a"].Should().Be(1);
        }

        /// <summary>
        ///A test for DBModifier Constructor
        ///</summary>
        [TestMethod()]
        public void DBModifierConstructorTest1()
        {            
            DBModifier target = new DBModifier(new Dictionary<string, object>() {{"a",1},{"b",2},{"c",3}});
            target.Keys.Count.Should().Be(3);
        }

        /// <summary>
        ///A test for DBModifier Constructor
        ///</summary>
        [TestMethod()]
        public void DBModifierConstructorTest2()
        {
            DBModifier target = new DBModifier();
        }

        /// <summary>
        /// A test for AddEachToSet
        /// </summary>
        [TestMethod()]
        public void AddEachToSetTest()
        {
            DBModifier target = new DBModifier();
            ArrayList list = new ArrayList() {"a", "b", "c" };
            target.AddEachToSet("fieldName", list);
            target.GetAsIDBObject(DBModifier.ModifierOperation.AddToSet).GetAsIDBObject("fieldName")[DBModifier.ModifierOperation.Each].Should().Be(list);
        }

        /// <summary>
        ///A test for AddToSet
        ///</summary>
        [TestMethod()]
        public void AddToSetTest()
        {
            DBModifier target = new DBModifier();
            target.AddToSet("fieldName", "a");
            target.GetAsIDBObject(DBModifier.ModifierOperation.AddToSet)["fieldName"].Should().Be("a");
        }

        /// <summary>
        ///A test for Inc
        ///</summary>
        [TestMethod()]
        public void IncTest()
        {
            DBModifier target = new DBModifier();
            target.Inc("fieldName", 2);
            target.GetAsIDBObject(DBModifier.ModifierOperation.Inc)["fieldName"].Should().Be(2);
        }

        /// <summary>
        ///A test for Pop
        ///</summary>
        [TestMethod()]
        public void PopTest()
        {
            DBModifier target = new DBModifier();
            target.Pop("fieldName", false);
            target.GetAsIDBObject(DBModifier.ModifierOperation.Pop)["fieldName"].Should().Be(-1);

            target = new DBModifier();
            target.Pop("fieldName", true);
            target.GetAsIDBObject(DBModifier.ModifierOperation.Pop)["fieldName"].Should().Be(1);
        }

        /// <summary>
        ///A test for Pull
        ///</summary>
        [TestMethod()]
        public void PullTest()
        {
            DBModifier target = new DBModifier();
            target.Pull("fieldName", "a");
            target.GetAsIDBObject(DBModifier.ModifierOperation.Pull)["fieldName"].Should().Be("a");
        }

        /// <summary>
        ///A test for PullAll
        ///</summary>
        [TestMethod()]
        public void PullAllTest()
        {
            DBModifier target = new DBModifier();
            ArrayList list = new ArrayList() { "a", "b", "c" };
            target.PullAll("fieldName", list);
            target.GetAsIDBObject(DBModifier.ModifierOperation.PullAll)["fieldName"].Should().Be(list);
        }

        /// <summary>
        ///A test for Push
        ///</summary>
        [TestMethod()]
        public void PushTest()
        {
            DBModifier target = new DBModifier();
            target.Push("fieldName", "a");
            target.GetAsIDBObject(DBModifier.ModifierOperation.Push)["fieldName"].Should().Be("a");
        }

        /// <summary>
        ///A test for PushAll
        ///</summary>
        [TestMethod()]
        public void PushAllTest()
        {
            DBModifier target = new DBModifier();
            ArrayList list = new ArrayList() { "a", "b", "c" };
            target.PushAll("fieldName", list);
            target.GetAsIDBObject(DBModifier.ModifierOperation.PushAll)["fieldName"].Should().Be(list);
        }

        /// <summary>
        ///A test for Set
        ///</summary>
        [TestMethod()]
        public void SetTest()
        {
            DBModifier target = new DBModifier();
            target.Set("fieldName", "a");
            target.GetAsIDBObject(DBModifier.ModifierOperation.Set)["fieldName"].Should().Be("a");
        }

        /// <summary>
        ///A test for Unset
        ///</summary>
        [TestMethod()]
        public void UnsetTest()
        {
            DBModifier target = new DBModifier();
            target.Unset("fieldName", "a");
            target.GetAsIDBObject(DBModifier.ModifierOperation.Unset)["fieldName"].Should().Be("a");
        }
    }
}
