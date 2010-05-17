using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DoTest and is intended
    ///to contain all DoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DoTest
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
        ///A test for AddEachToSet
        ///</summary>
        [TestMethod()]
        public void AddEachToSetTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //IList value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.AddEachToSet(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddToSet
        ///</summary>
        [TestMethod()]
        public void AddToSetTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.AddToSet(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Inc
        ///</summary>
        [TestMethod()]
        public void IncTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.Inc(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pop
        ///</summary>
        [TestMethod()]
        public void PopTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //bool fromTop = false; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.Pop(fieldName, fromTop);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pull
        ///</summary>
        [TestMethod()]
        public void PullTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.Pull(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PullAll
        ///</summary>
        [TestMethod()]
        public void PullAllTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //IList value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.PullAll(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Push
        ///</summary>
        [TestMethod()]
        public void PushTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.Push(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PushAll
        ///</summary>
        [TestMethod()]
        public void PushAllTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //IList value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.PushAll(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Set
        ///</summary>
        [TestMethod()]
        public void SetTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.Set(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Unset
        ///</summary>
        [TestMethod()]
        public void UnsetTest()
        {
            //string fieldName = string.Empty; // TODO: Initialize to an appropriate value
            //object value = null; // TODO: Initialize to an appropriate value
            //DBModifier expected = null; // TODO: Initialize to an appropriate value
            //DBModifier actual;
            //actual = Do.Unset(fieldName, value);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
