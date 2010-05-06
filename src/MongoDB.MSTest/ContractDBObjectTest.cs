using MongoDB.Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Collections;
using Newtonsoft.Json.Serialization;
using SharpTestsEx;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for ContractDBObjectTest and is intended
    ///to contain all ContractDBObjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContractDBObjectTest
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
        ///A test for ContractDBObject`1 Constructor
        ///</summary>
        public void ContractDBObjectConstructorTestHelper<T>() where T : new()
        {
            T instance = new T();
            JsonSerializer serializer = new JsonSerializer();
            ContractDBObject<T> target = new ContractDBObject<T>(instance, serializer);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void ContractDBObjectConstructorTest()
        {
            ContractDBObjectConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for ContractDBObject`1 Constructor
        ///</summary>
        public void ContractDBObjectConstructorTest1Helper<T>() where T : new()
        {
            T instance = new T();
            ContractDBObject<T> target = new ContractDBObject<T>(instance);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void ContractDBObjectConstructorTest1()
        {
            ContractDBObjectConstructorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            Executing.This(() => target.Add("test", 1)).Should().Throw();
            target.Add("Data", 123);
            target["Data"].Should().Be.EqualTo(123);
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTest1Helper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            KeyValuePair<string, object> item = new KeyValuePair<string, object>(); // TODO: Initialize to an appropriate value
            target.Add(item);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void AddTest1()
        {
            AddTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        public void ClearTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        public void ContainsTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            KeyValuePair<string, object> item = new KeyValuePair<string, object>(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ContainsTest()
        {
            ContainsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for ContainsKey
        ///</summary>
        public void ContainsKeyTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ContainsKey(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ContainsKeyTest()
        {
            ContainsKeyTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for CopyTo
        ///</summary>
        public void CopyToTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            KeyValuePair<string, object>[] array = null; // TODO: Initialize to an appropriate value
            int arrayIndex = 0; // TODO: Initialize to an appropriate value
            target.CopyTo(array, arrayIndex);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void CopyToTest()
        {
            CopyToTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        public void GetEnumeratorTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            IEnumerator<KeyValuePair<string, object>> expected = null; // TODO: Initialize to an appropriate value
            IEnumerator<KeyValuePair<string, object>> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            GetEnumeratorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for PutAll
        ///</summary>
        public void PutAllTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            IDictionary<string, object> m = null; // TODO: Initialize to an appropriate value
            target.PutAll(m);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void PutAllTest()
        {
            PutAllTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Read
        ///</summary>
        public void ReadTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            WireProtocolReader reader = null; // TODO: Initialize to an appropriate value
            target.Read(reader);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void ReadTest()
        {
            ReadTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        public void RemoveTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            KeyValuePair<string, object> item = new KeyValuePair<string, object>(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void RemoveTest()
        {
            RemoveTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        public void RemoveTest1Helper<T>() where T:new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void RemoveTest1()
        {
            RemoveTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        public void GetEnumeratorTest1Helper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            IEnumerable target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Newtonsoft.Json.dll")]
        public void GetEnumeratorTest1()
        {
            GetEnumeratorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        public void ToStringTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            ToStringTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for TryGetValue
        ///</summary>
        public void TryGetValueTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            object valueExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryGetValue(key, out value);
            Assert.AreEqual(valueExpected, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void TryGetValueTest()
        {
            TryGetValueTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        public void WriteTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            WireProtocolWriter writer = null; // TODO: Initialize to an appropriate value
            target.Write(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void WriteTest()
        {
            WriteTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Contract
        ///</summary>
        public void ContractTestHelper<T>() where T:new()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ContractDBObject_Accessor<T> target = new ContractDBObject_Accessor<T>(param0); // TODO: Initialize to an appropriate value
            JsonObjectContract actual;
            actual = target.Contract;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Newtonsoft.Json.dll")]
        public void ContractTest()
        {
            ContractTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        public void CountTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Count;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CountTest()
        {
            CountTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for IsReadOnly
        ///</summary>
        public void IsReadOnlyTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void IsReadOnlyTest()
        {
            IsReadOnlyTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        public void ItemTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target[key] = expected;
            actual = target[key];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ItemTest()
        {
            ItemTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Keys
        ///</summary>
        public void KeysTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            ICollection<string> actual;
            actual = target.Keys;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void KeysTest()
        {
            KeysTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Properties
        ///</summary>
        public void PropertiesTestHelper<T>() where T : new()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ContractDBObject_Accessor<T> target = new ContractDBObject_Accessor<T>(param0); // TODO: Initialize to an appropriate value
            JsonPropertyCollection actual;
            actual = target.Properties;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Newtonsoft.Json.dll")]
        public void PropertiesTest()
        {
            PropertiesTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Values
        ///</summary>
        public void ValuesTestHelper<T>() where T : new()
        {
            T instance = default(T); // TODO: Initialize to an appropriate value
            ContractDBObject<T> target = new ContractDBObject<T>(instance); // TODO: Initialize to an appropriate value
            ICollection<object> actual;
            actual = target.Values;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ValuesTest()
        {
            ValuesTestHelper<GenericParameterHelper>();
        }
    }
}
