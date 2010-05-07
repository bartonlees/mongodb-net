using MongoDB.Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Collections;
using Newtonsoft.Json.Serialization;
using SharpTestsEx;
using System.IO;

namespace MongoDB.MSTest
{
    public class TestContractObject
    {
        public TestContractObject()
        {
            Data = 321;
            Caption = "Amble";
        }
        public int Data { get; set; }
        public string Caption { get; set; }
        private float _secret { get; set; }
    }
    
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
        }

        [TestMethod()]
        public void ContractDBObjectConstructorTest()
        {
            ContractDBObjectConstructorTestHelper<TestContractObject>();
            Executing.This(() => ContractDBObjectConstructorTestHelper<List<int>>()).Should().Throw();
        }

        /// <summary>
        ///A test for ContractDBObject`1 Constructor
        ///</summary>
        public void ContractDBObjectConstructorTest1Helper<T>() where T : new()
        {
            T instance = new T();
            ContractDBObject<T> target = new ContractDBObject<T>(instance);
        }

        [TestMethod()]
        public void ContractDBObjectConstructorTest1()
        {
            ContractDBObjectConstructorTest1Helper<TestContractObject>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            Executing.This(() => target.Add("test", 1)).Should().Throw<KeyNotFoundException>();
            target.Add("Data", 123);
            target["Data"].Should().Be(123);
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTest1Helper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            Executing.This(()=> target.Add(new KeyValuePair<string, object>("test",1))).Should().Throw<KeyNotFoundException>();
            target.Add(new KeyValuePair<string, object>("Data", 123));
            target["Data"].Should().Be(123);
        }

        [TestMethod()]
        public void AddTest1()
        {
            AddTest1Helper<TestContractObject>();
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        public void ClearTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            Executing.This(()=> target.Clear()).Should().Throw();
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        public void ContainsTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            target.Contains(new KeyValuePair<string, object>("Data",0)).Should().Be(true);
            target.Contains(new KeyValuePair<string, object>("monkey",0)).Should().Be(false);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            ContainsTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for ContainsKey
        ///</summary>
        public void ContainsKeyTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            target.ContainsKey("Data").Should().Be(true);
            target.ContainsKey("monkey").Should().Be(false);
        }

        [TestMethod()]
        public void ContainsKeyTest()
        {
            ContainsKeyTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for CopyTo
        ///</summary>
        public void CopyToTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            KeyValuePair<string, object>[] array = new KeyValuePair<string,object>[4];
            int arrayIndex = 0;
            target.CopyTo(array, arrayIndex);
            array[0].Key.Should().Be("Data");
            array[1].Key.Should().Be("Caption");
            array[2].Should().Be.Null();
        }

        [TestMethod()]
        public void CopyToTest()
        {
            CopyToTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        public void GetEnumeratorTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            IEnumerator<KeyValuePair<string, object>> actual = (target as IEnumerable<KeyValuePair<string, object>>).GetEnumerator();
            actual.MoveNext().Should().Be(true);
            actual.Current.Key.Should().Be("Data");
            actual.MoveNext().Should().Be(true);
            actual.Current.Key.Should().Be("Caption");
            actual.MoveNext().Should().Be(false);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            GetEnumeratorTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for PutAll
        ///</summary>
        public void PutAllTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            IDictionary<string, object> m = new Dictionary<string,object>();
            Executing.This(() => target.PutAll(m)).Should().Throw<NotSupportedException>();
        }

        [TestMethod()]
        public void PutAllTest()
        {
            PutAllTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Read
        ///</summary>
        public void ReadTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            WireProtocolReader reader = null; // TODO: Initialize to an appropriate value
            target.Read(reader);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void ReadTest()
        {
            ReadTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        public void RemoveTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            Executing.This(() => target.Remove(new KeyValuePair<string, object>())).Should().Throw<NotSupportedException>();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            RemoveTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        public void RemoveTest1Helper<T>() where T:new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            Executing.This(() => target.Remove("Data")).Should().Throw<NotSupportedException>();
        }

        [TestMethod()]
        public void RemoveTest1()
        {
            RemoveTest1Helper<TestContractObject>();
        }

        /// <summary>
        ///A test for System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        public void GetEnumeratorTest1Helper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            IEnumerator actual = (target as IEnumerable).GetEnumerator();
            actual.MoveNext().Should().Be(true);
            ((KeyValuePair<string, object>)actual.Current).Key.Should().Be("Data");
            actual.MoveNext().Should().Be(true);
            ((KeyValuePair<string, object>)actual.Current).Key.Should().Be("Caption");
            actual.MoveNext().Should().Be(false);
        }

        [TestMethod()]
        [DeploymentItem("MongoDB.Newtonsoft.Json.dll")]
        public void GetEnumeratorTest1()
        {
            GetEnumeratorTest1Helper<TestContractObject>();
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        public void ToStringTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            string result = target.ToString();
            Console.WriteLine(result);
            result.Should().Be("");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            ToStringTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for TryGetValue
        ///</summary>
        public void TryGetValueTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            object value = null; 
            target.TryGetValue("Data", out value).Should().Be(true);
            value.Should().Be(321);
            target.TryGetValue("goat", out value).Should().Be(false);
        }

        [TestMethod()]
        public void TryGetValueTest()
        {
            TryGetValueTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        public void WriteTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            using (MemoryStream stream = new MemoryStream())
            using (WireProtocolWriter writer = new WireProtocolWriter(stream))
            {
                target["Data"] = 111;
                target["Caption"] = "gaggle";
                target.Write(writer);
                string bytes = BitConverter.ToString(stream.GetBuffer(), 0, (int)stream.Length);
                Console.WriteLine(bytes);
                bytes.Should().Be("");
            }
        }

        [TestMethod()]
        public void WriteTest()
        {
            WriteTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        public void CountTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            target.Count.Should().Be(2);
        }

        [TestMethod()]
        public void CountTest()
        {
            CountTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        public void ItemTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            target["Data"].Should().Be(123);
            Executing.This(() => { object obj = target["turnkey"]; }).Should().Throw<KeyNotFoundException>();
        }

        [TestMethod()]
        public void ItemTest()
        {
            ItemTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Keys
        ///</summary>
        public void KeysTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            target.Keys.Should().Have.SameValuesAs("Data", "Caption");
        }

        [TestMethod()]
        public void KeysTest()
        {
            KeysTestHelper<TestContractObject>();
        }

        /// <summary>
        ///A test for Values
        ///</summary>
        public void ValuesTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            target.Values.Should().Have.SameValuesAs(321, "Amble");
        }

        [TestMethod()]
        public void ValuesTest()
        {
            ValuesTestHelper<TestContractObject>();
        }
    }
}
