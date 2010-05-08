using MongoDB.Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using Newtonsoft.Json;
using SharpTestsEx;
using System.Collections.Generic;

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
            ContractDocument<T> target = new ContractDocument<T>(new T(), DocumentState.Unchanged, new MongoDBSerializer());
            Executing.This(() => { ContractDocument<T> target3 = new ContractDocument<T>(new T(), DocumentState.Unchanged, null); }).Should().Throw();
        }

        [TestMethod()]
        public void ContractDocumentConstructorTest()
        {
            ContractDocumentConstructorTestHelper<TestContractStruct>();
            ContractDocumentConstructorTestHelper<TestContractObject>();
            Executing.This(() => { ContractDocument<TestContractObject> target2 = new ContractDocument<TestContractObject>(null, DocumentState.Unchanged, new MongoDBSerializer()); }).Should().Throw();
            Executing.This(() => ContractDocumentConstructorTestHelper<List<int>>()).Should().Throw();
            Executing.This(() => ContractDocumentConstructorTestHelper<TestContractObjectNoID>()).Should().Throw<KeyNotFoundException>();
            Executing.This(() => ContractDocumentConstructorTestHelper<TestContractStructNoID>()).Should().Throw<KeyNotFoundException>();
        }

        /// <summary>
        ///A test for ContractDocument`1 Constructor
        ///</summary>
        public void ContractDocumentConstructorTest1Helper<T>() where T : new()
        {
            ContractDocument<T> target = new ContractDocument<T>(new T(), DocumentState.Unchanged);
        }

        [TestMethod()]
        public void ContractDocumentConstructorTest1()
        {
            ContractDocumentConstructorTest1Helper<TestContractStruct>();
            ContractDocumentConstructorTest1Helper<TestContractObject>();
            Executing.This(() => { ContractDocument<TestContractObject> target2 = new ContractDocument<TestContractObject>(null, DocumentState.Unchanged); }).Should().Throw();
            Executing.This(() => ContractDocumentConstructorTest1Helper<List<int>>()).Should().Throw();
            Executing.This(() => ContractDocumentConstructorTest1Helper<TestContractObjectNoID>()).Should().Throw<KeyNotFoundException>();
            Executing.This(() => ContractDocumentConstructorTest1Helper<TestContractStructNoID>()).Should().Throw<KeyNotFoundException>();
        }

        /// <summary>
        ///A test for Collection
        ///</summary>
        public void CollectionTestHelper<T>() where T : new()
        {
            ContractDocument<T> target = new ContractDocument<T>();
            IDBCollection expected = Mongo.DefaultDatabase.CmdCollection; 
            IDBCollection actual;
            target.Collection = expected;
            actual = target.Collection;
            expected.Name.Should().Be(actual.Name);
        }

        [TestMethod()]
        public void CollectionTest()
        {
            CollectionTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        public void IDTestHelper<T>() where T : new()
        {
            ContractDocument<T> target = new ContractDocument<T>();
            Oid expected = Oid.NewOid();
            Oid actual;
            target.ID = expected;
            actual = target.ID;
            expected.Should().Be(actual);
        }

        [TestMethod()]
        public void IDTest()
        {
            IDTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for State
        ///</summary>
        public void StateTestHelper<T>() where T : new()
        {
            DocumentState actual = DocumentState.Modified;
            ContractDocument<T> target = new ContractDocument<T>(new T(), actual);
            target.State.Should().Be(DocumentState.Modified);
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Newtonsoft.Json.dll")]
        public void StateTest()
        {
            StateTestHelper<TestContractObject>();
        }
    }
}
