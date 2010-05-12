using MongoDB.Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Collections;
using Newtonsoft.Json.Serialization;
using FluentAssertions;
using System.IO;

namespace MongoDB.MSTest
{
    public class TestContractObject
    {
        public TestContractObject()
        {
            Data = 321;
            Caption = "Amble";
            ID = Oid.Empty;
        }
        public int Data { get; set; }
        public string Caption { get; set; }
        private float _secret { get; set; }
        [JsonProperty(PropertyName="_id")]
        public Oid ID { get; set; }
    }

    public class TestContractObjectNoID
    {
        public TestContractObjectNoID()
        {
            Data = 321;
            Caption = "Amble";
        }
        public int Data { get; set; }
        public string Caption { get; set; }
        private float _secret { get; set; }
    }

    public struct TestContractStruct
    {
        public int Data;
        public string Caption;
        public Oid _id { get; set; }
    }

    public struct TestContractStructNoID
    {
        public int Data;
        public string Caption;
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
            ContractDBObject<T> target = new ContractDBObject<T>(new T(), new MongoDBSerializer());
            this.Invoking((t) => { ContractDBObject<T> target3 = new ContractDBObject<T>(new T(), null); }).ShouldThrow<Exception>();
        }

        [TestMethod()]
        public void ContractDBObjectConstructorTest()
        {
            ContractDBObjectConstructorTestHelper<TestContractStruct>();
            ContractDBObjectConstructorTestHelper<TestContractObject>();
            this.Invoking((t) => { ContractDBObject<TestContractObject> target2 = new ContractDBObject<TestContractObject>(null, new MongoDBSerializer()); }).ShouldThrow<Exception>();
            this.Invoking((t) => ContractDBObjectConstructorTestHelper<List<int>>()).ShouldThrow<Exception>();
            //Don't force an _id here
            ContractDBObjectConstructorTestHelper<TestContractObjectNoID>();
            ContractDBObjectConstructorTestHelper<TestContractStructNoID>();
        }

        /// <summary>
        ///A test for ContractDBObject`1 Constructor
        ///</summary>
        public void ContractDBObjectConstructorTest1Helper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>(new T());
        }

        [TestMethod()]
        public void ContractDBObjectConstructorTest1()
        {
            ContractDBObjectConstructorTest1Helper<TestContractStruct>();
            ContractDBObjectConstructorTest1Helper<TestContractObject>();
            this.Invoking((t) => { ContractDBObject<TestContractObject> target2 = new ContractDBObject<TestContractObject>(null); }).ShouldThrow<Exception>();
            this.Invoking((t) => ContractDBObjectConstructorTest1Helper<List<int>>()).ShouldThrow<Exception>();
            //Don't force an _id here
            ContractDBObjectConstructorTest1Helper<TestContractObjectNoID>();
            ContractDBObjectConstructorTest1Helper<TestContractStructNoID>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTestHelper<T>() where T : new()
        {
            ContractDBObject<T> target = new ContractDBObject<T>();
            this.Invoking((t) => target.Add("test", 1)).ShouldThrow<KeyNotFoundException>();
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
            this.Invoking((t)=> target.Add(new KeyValuePair<string, object>("test",1))).ShouldThrow<KeyNotFoundException>();
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
            this.Invoking((t)=> target.Clear()).ShouldThrow<Exception>();
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
            array.Select(p => p.Key).Should().Contain("Caption", "Data", "_id", null);
            array[3].Key.Should().BeEmpty();
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
            (target as IEnumerable<KeyValuePair<string, object>>).Select(p => p.Key).Should().Contain("Caption", "Data", "_id");
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
            target.PutAll(new Dictionary<string, object>() {{"Caption","Perambulator"},{"Data",222} });
            target["Caption"].Should().Be("Perambulator");
            target["Data"].Should().Be(222);
            this.Invoking((t) => target.PutAll(new Dictionary<string, object>() { { "Putin", "Powell" }})).ShouldThrow<KeyNotFoundException>();
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
            using (MemoryStream stream = new MemoryStream("34-00-00-00-10-44-61-74-61-00-6F-00-00-00-02-43-61-70-74-69-6F-6E-00-07-00-00-00-67-61-67-67-6C-65-00-07-5F-69-64-00-00-00-00-00-00-00-00-00-00-00-00-00-00".ToBytes()))
            using (WireProtocolReader reader = new WireProtocolReader(stream))
            {
                target.Read(reader);
            }
            target["Data"].Should().Be(111);
            target["Caption"].Should().Be("gaggle");
            target["_id"].Should().Be(Oid.Empty);
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
            this.Invoking((t) => target.Remove(new KeyValuePair<string, object>())).ShouldThrow<NotSupportedException>();
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
            this.Invoking((t) => target.Remove("Data")).ShouldThrow<NotSupportedException>();
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
            actual.MoveNext().Should().Be(true);
            ((KeyValuePair<string, object>)actual.Current).Key.Should().Be("_id");
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
            string result = target.ToString().RemoveWhitespace();
            Console.WriteLine(result);
            string expected = "{\"Data\":321,\"Caption\":\"Amble\",\"_id\":\"AAAAAAAAAAAAAAAA\"}";
            result.Should().Be(expected);
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
                bytes.Should().Be("34-00-00-00-10-44-61-74-61-00-6F-00-00-00-02-43-61-70-74-69-6F-6E-00-07-00-00-00-67-61-67-67-6C-65-00-07-5F-69-64-00-00-00-00-00-00-00-00-00-00-00-00-00-00");
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
            target.Count.Should().Be(3);
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
            target["Data"].Should().Be(321);
            this.Invoking((t) => { object obj = target["turnkey"]; }).ShouldThrow<KeyNotFoundException>();
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
            target.Keys.Should().Contain("Data", "Caption", "_id");
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
            target.Values.Should().Contain(321, "Amble", Oid.Empty);
        }

        [TestMethod()]
        public void ValuesTest()
        {
            ValuesTestHelper<TestContractObject>();
        }
    }
}
