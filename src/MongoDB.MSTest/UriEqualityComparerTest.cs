using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for UriEqualityComparerTest and is intended
    ///to contain all UriEqualityComparerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UriEqualityComparerTest
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
        ///A test for UriEqualityComparer`1 Constructor
        ///</summary>
        public void UriEqualityComparerConstructorTestHelper<T>()
            where T : IUriComparable
        {
            UriEqualityComparer<T> target = new UriEqualityComparer<T>();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void UriEqualityComparerConstructorTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call UriEqualityComparerConstructorTestHelper<T>() with appropriate type " +
                    "parameters.");
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        public void EqualsTestHelper<T>()
            where T : IUriComparable
        {
            UriEqualityComparer<T> target = new UriEqualityComparer<T>(); // TODO: Initialize to an appropriate value
            T x = default(T); // TODO: Initialize to an appropriate value
            T y = default(T); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(x, y);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call EqualsTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        public void GetHashCodeTestHelper<T>()
            where T : IUriComparable
        {
            UriEqualityComparer<T> target = new UriEqualityComparer<T>(); // TODO: Initialize to an appropriate value
            T obj = default(T); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetHashCode(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetHashCodeTestHelper<T>() with appropriate type parameters.");
        }
    }
}
