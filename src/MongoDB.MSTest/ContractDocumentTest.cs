using MongoDB.Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using Newtonsoft.Json;
using FluentAssertions;
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
            this.Invoking((t) => { ContractDocument<T> target3 = new ContractDocument<T>(new T(), DocumentState.Unchanged, null); }).ShouldThrow<Exception>();
        }

        [TestMethod()]
        public void ContractDocumentConstructorTest()
        {
            ContractDocumentConstructorTestHelper<TestContractStruct>();
            ContractDocumentConstructorTestHelper<TestContractObject>();
            this.Invoking((t) => { ContractDocument<TestContractObject> target2 = new ContractDocument<TestContractObject>(null, DocumentState.Unchanged, new MongoDBSerializer()); }).ShouldThrow<Exception>();
            this.Invoking((t) => ContractDocumentConstructorTestHelper<List<int>>()).ShouldThrow<Exception>();
            this.Invoking((t) => ContractDocumentConstructorTestHelper<TestContractObjectNoID>()).ShouldThrow<KeyNotFoundException>();
            this.Invoking((t) => ContractDocumentConstructorTestHelper<TestContractStructNoID>()).ShouldThrow<KeyNotFoundException>();
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
            this.Invoking((t) => { ContractDocument<TestContractObject> target2 = new ContractDocument<TestContractObject>(null, DocumentState.Unchanged); }).ShouldThrow<Exception>();
            this.Invoking((t) => ContractDocumentConstructorTest1Helper<List<int>>()).ShouldThrow<Exception>();
            this.Invoking((t) => ContractDocumentConstructorTest1Helper<TestContractObjectNoID>()).ShouldThrow<KeyNotFoundException>();
            this.Invoking((t) => ContractDocumentConstructorTest1Helper<TestContractStructNoID>()).ShouldThrow<KeyNotFoundException>();
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
        public void StateTest()
        {
            StateTestHelper<TestContractObject>();
        }

        [TestMethod()]
        public void RoundTripTest()
        {
            TestContractObject newObj = new TestContractObject();
            newObj.ID = new Oid(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            newObj.Caption = "good";
            newObj.Data = 345;
            ContractDocument<TestContractObject> newDoc = new ContractDocument<TestContractObject>(newObj);
            IDBCollection coll = Mongo.DefaultDatabase.GetCollection("TestContractObject");
            coll.Save(newDoc);
            ContractDocument<TestContractObject> existingDoc = coll.FindContractDocumentByID<TestContractObject>(newDoc.ID);
            TestContractObject existingObj = existingDoc.Instance;
            existingObj.ID.Should().Be(newObj.ID);
            existingObj.Data.Should().Be(newObj.Data);
            existingObj.Caption.Should().Be(newObj.Caption);
        }

    }
}
