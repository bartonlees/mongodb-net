using MongoDB.Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for ContractDocumentTest and is intended
    ///to contain all ContractDocumentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContractDocumentTest
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
        ///A test for ContractDocument`1 Constructor
        ///</summary>
        public void ContractDocumentConstructorTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            DocumentState state = new DocumentState(); // TODO: Initialize to an appropriate value
            JsonSerializer serializer = null; // TODO: Initialize to an appropriate value
            ContractDocument<T> target = new ContractDocument<T>(instance, state, serializer);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void ContractDocumentConstructorTest()
        {
            ContractDocumentConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for ContractDocument`1 Constructor
        ///</summary>
        public void ContractDocumentConstructorTest1Helper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            DocumentState state = new DocumentState(); // TODO: Initialize to an appropriate value
            ContractDocument<T> target = new ContractDocument<T>(instance, state);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void ContractDocumentConstructorTest1()
        {
            ContractDocumentConstructorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        public void CollectionTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            DocumentState state = new DocumentState(); // TODO: Initialize to an appropriate value
            ContractDocument<T> target = new ContractDocument<T>(instance, state); // TODO: Initialize to an appropriate value
            IDBCollection expected = null; // TODO: Initialize to an appropriate value
            IDBCollection actual;
            target.Collection = expected;
            actual = target.Collection;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CollectionTest()
        {
            CollectionTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        public void IDTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            DocumentState state = new DocumentState(); // TODO: Initialize to an appropriate value
            ContractDocument<T> target = new ContractDocument<T>(instance, state); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.ID = expected;
            actual = target.ID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void IDTest()
        {
            IDTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Partial
        ///</summary>
        public void PartialTestHelper<T>() where T : new()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ContractDocument_Accessor<T> target = new ContractDocument_Accessor<T>(param0); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Partial = expected;
            actual = target.Partial;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Newtonsoft.Json.dll")]
        public void PartialTest()
        {
            PartialTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for State
        ///</summary>
        public void StateTestHelper<T>() where T : new()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ContractDocument_Accessor<T> target = new ContractDocument_Accessor<T>(param0); // TODO: Initialize to an appropriate value
            DocumentState expected = new DocumentState(); // TODO: Initialize to an appropriate value
            DocumentState actual;
            target.State = expected;
            actual = target.State;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Newtonsoft.Json.dll")]
        public void StateTest()
        {
            StateTestHelper<GenericParameterHelper>();
        }
    }
}
