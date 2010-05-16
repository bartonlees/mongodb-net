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
        ///A test for DBModifier Constructor
        ///</summary>
        [TestMethod()]
        public void DBModifierConstructorTest()
        {
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            DBModifier target = new DBModifier(key, value);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBModifier Constructor
        ///</summary>
        [TestMethod()]
        public void DBModifierConstructorTest1()
        {
            IDictionary<string, object> obj = null; // TODO: Initialize to an appropriate value
            DBModifier target = new DBModifier(obj);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBModifier Constructor
        ///</summary>
        [TestMethod()]
        public void DBModifierConstructorTest2()
        {
            DBModifier target = new DBModifier();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddEachToSet
        ///</summary>
        [TestMethod()]
        public void AddEachToSetTest()
        {
            DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            IList value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            DBModifier actual;
            actual = target.AddEachToSet(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddToSet
        ///</summary>
        [TestMethod()]
        public void AddToSetTest()
        {
            DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            DBModifier actual;
            actual = target.AddToSet(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Inc
        ///</summary>
        [TestMethod()]
        public void IncTest()
        {
            DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            DBModifier actual;
            actual = target.Inc(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pop
        ///</summary>
        [TestMethod()]
        public void PopTest()
        {
            //DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //bool fromTop = false; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = target.Pop(fieldName, fromTop);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pull
        ///</summary>
        [TestMethod()]
        public void PullTest()
        {
            //DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = target.Pull(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PullAll
        ///</summary>
        [TestMethod()]
        public void PullAllTest()
        {
            //DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //IList value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = target.PullAll(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Push
        ///</summary>
        [TestMethod()]
        public void PushTest()
        {
            //DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = target.Push(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PushAll
        ///</summary>
        [TestMethod()]
        public void PushAllTest()
        {
            //DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //IList value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = target.PushAll(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Set
        ///</summary>
        [TestMethod()]
        public void SetTest()
        {
            //DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = target.Set(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Unset
        ///</summary>
        [TestMethod()]
        public void UnsetTest()
        {
            //DBModifier target = new DBModifier(); // TODO: Initialize to an appropriate value
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = target.Unset(fieldName, value);
            //expected.Should().Be(actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
