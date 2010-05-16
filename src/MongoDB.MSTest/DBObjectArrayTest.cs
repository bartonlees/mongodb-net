using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBObjectArrayTest and is intended
    ///to contain all DBObjectArrayTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBObjectArrayTest
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


        [TestMethod]
        public void RoundTrip()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("dblist");
            c.Drop();

            DBObjectArray l = new DBObjectArray();
            l[0] = "a";
            l[1] = "b";
            l[2] = "c";

            c.Insert(new Document() { { "array", l } });
            IDBObject obj = c.FindOne();
            obj.Should().NotBeNull("we added a document");
            obj.GetAsIDBObject("array").Should().NotBeNull("we sent a nested array");
            obj.GetAsIDBObject("array")["0"].Should().Be("a");
            obj.GetAsIDBObject("array")["1"].Should().Be("b");
            obj.GetAsIDBObject("array")["2"].Should().Be("c");
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(new ArrayList(){ a, b, c});
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray((IList<object>)new List<object>() { a, b, c });
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest2()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(new Dictionary<string,object>() {{"0", a},{"1", b},{"2", c}});
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest3()
        {
            DBObjectArray target = new DBObjectArray();
            target.Count.Should().Be(0,"the default constructor defines no elements");
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest4()
        {
            int capacity = 3;
            DBObjectArray target = new DBObjectArray(capacity);
            target.Capacity.Should().Be(3);
            target.Count.Should().Be(0);
        }

        [TestMethod()]
        public void DBObjectArrayConstructorTest5()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            DBObjectArray target = new DBObjectArray();
            DBObject a = new DBObject("add","me");
            target.Add(new KeyValuePair<string, object>("0", a));
            target.Count.Should().Be(1);
            new Action(() => target.Add(new KeyValuePair<string, object>("a", a))).ShouldThrow<ArgumentException>("index/key must be numeric");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest1()
        {
            DBObjectArray target = new DBObjectArray();
            DBObject a = new DBObject("add", "me");
            target.Add("0", a);
            target.Count.Should().Be(1);
            new Action(() => target.Add("a", a)).ShouldThrow<ArgumentException>("index/key must be numeric");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest2()
        {
            DBObjectArray target = new DBObjectArray();
            DBObject a = new DBObject("add", "me");
            target.Add(new KeyValuePair<string, object>("0", a));
            new Action(() => target.Add(new KeyValuePair<string, object>("a", a))).ShouldThrow<Exception>();
            target.Count.Should().Be(1);
        }

        /// <summary>
        ///A test for System.Collections.IList.Add
        ///</summary>
        [TestMethod()]
        public void AddTest3()
        {
            IList target = new DBObjectArray() as IList;
            DBObject a = new DBObject("add", "me");
            target.Add(a);
            target.Count.Should().Be(1);
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.Count.Should().Be(3);
            target.Clear();
            target.Count.Should().Be(0);
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.Contains(new KeyValuePair<string, object>("0",a)).Should().Be(true);
            target.Contains(new KeyValuePair<string, object>("1", a)).Should().Be(false);
            new Action(() => target.Contains(new KeyValuePair<string, object>("a", a))).ShouldThrow<Exception>();
            target.Contains(new KeyValuePair<string, object>("30", a)).Should().Be(false);
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, c);
            target.Contains(a).Should().Be(true);
            target.Contains(b).Should().Be(false);
        }

        /// <summary>
        ///A test for ContainsKey
        ///</summary>
        [TestMethod()]
        public void ContainsKeyTest()
        {
            DBObject a = new DBObject();
            DBObjectArray target = new DBObjectArray(a);
            target.ContainsKey("0").Should().BeTrue();
            target.ContainsKey("1").Should().BeFalse();
            new Action(() => target.ContainsKey("a")).ShouldThrow<Exception>();
        }

        /// <summary>
        ///A test for CopyTo
        ///</summary>
        [TestMethod()]
        public void CopyToTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a,b,c);
            KeyValuePair<string, object>[] array = new KeyValuePair<string,object>[4];
            target.CopyTo(array, 1);
            array[0].Value.Should().BeNull();
            array[1].Value.Should().Be(a);
            array[3].Value.Should().Be(c);
        }

        /// <summary>
        ///A test for CopyTo
        ///</summary>
        [TestMethod()]
        public void CopyToTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            object[] array = new object[4];
            target.CopyTo(array, 1);
            array[0].Should().BeNull();
            array[1].Should().Be(a);
            array[3].Should().Be(c);
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            //Use enumerator to fill list
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(target);
            list[0].Value.Should().Be(a);
            list[1].Value.Should().Be(b);
            list[2].Value.Should().Be(c);
        }

        /// <summary>
        ///A test for IndexOf
        ///</summary>
        [TestMethod()]
        public void IndexOfTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, c);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(c).Should().Be(1);
            target.Insert(1, b);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
        }

        /// <summary>
        ///A test for PutAll
        ///</summary>
        [TestMethod()]
        public void PutAllTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray();
            IDictionary<string, object> map = new Dictionary<string, object>() { { "0", a }, { "1", b }, { "2", c } };
            target.PutAll(map);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);

            new Action(() => target.PutAll(new Dictionary<string, object>() { { "a", a } })).ShouldThrow<Exception>("index/key must be an integer");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
            target.Remove(b);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(c).Should().Be(1);
            target.Count.Should().Be(2);
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
            target.Remove("1");
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(c).Should().Be(1);
            target.Count.Should().Be(2);
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest2()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
            target.Remove(new KeyValuePair<string, object>("1",b));
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(c).Should().Be(1);
            target.Count.Should().Be(2);
        }

        /// <summary>
        ///A test for RemoveAt
        ///</summary>
        [TestMethod()]
        public void RemoveAtTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(1);
            target.IndexOf(c).Should().Be(2);
            target.Count.Should().Be(3);
            target.RemoveAt(1);
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(c).Should().Be(1);
            target.Count.Should().Be(2);
        }

        /// <summary>
        ///A test for System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            //Use enumerator to fill list
            List<object> list = new List<object>(target);
            list[0].Should().Be(a);
            list[1].Should().Be(b);
            list[2].Should().Be(c);
        }
                
        

        /// <summary>
        ///A test for System.Collections.IList.Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            IList target = new DBObjectArray(a, b, c) as IList;
            target.Count.Should().Be(3);
            target.Clear();
            target.Count.Should().Be(0);
        }

        /// <summary>
        ///A test for System.Collections.IList.Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest2()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            IList target = new DBObjectArray(a, c) as IList;
            target.Contains(a).Should().BeTrue();
            target.Contains(b).Should().BeFalse();
        }

        /// <summary>
        ///A test for System.Collections.IList.IndexOf
        ///</summary>
        [TestMethod()]
        public void IndexOfTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            IList target = new DBObjectArray(a, c) as IList;
            target.IndexOf(a).Should().Be(0);
            target.IndexOf(b).Should().Be(-1);
        }

        /// <summary>
        ///A test for System.Collections.IList.Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            IList target = new DBObjectArray(a, c) as IList;
            target.Insert(1, b);
            target.IndexOf(b).Should().Be(1);
        }

        /// <summary>
        ///A test for System.Collections.IList.Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest3()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            IList target = new DBObjectArray(a, b, c) as IList;
            target.Remove(b);
            target.IndexOf(c).Should().Be(1);
            target.Count.Should().Be(2);
        }

        /// <summary>
        ///A test for System.Collections.IList.RemoveAt
        ///</summary>
        [TestMethod()]
        public void RemoveAtTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            IList target = new DBObjectArray(a, b, c) as IList;
            target.RemoveAt(1);
            target.IndexOf(c).Should().Be(1);
            target.Count.Should().Be(2);
        }

        /// <summary>
        ///A test for TryGetValue
        ///</summary>
        [TestMethod()]
        public void TryGetValueTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);

            object result = null;
            target.TryGetValue("0", out result).Should().BeTrue();
            result.Should().Be(a);
            target.TryGetValue("30", out result).Should().BeFalse();
            target.TryGetValue("a", out result).Should().BeFalse();
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.Count.Should().Be(3);
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            DBObjectArray l = new DBObjectArray();
            l["0"] = "zero";
            l["0"].Should().Be("zero", "we just set it");
            l["10"] = "test";
            l["10"].Should().Be("test", "we just set it");
            l["3"].Should().BeNull("we expanded to a size of 10, and size was 0. All inbetween should be null.");

            Action<string> accessor = s => new DBObjectArray()[s] = "test";

            "-10".Invoking(accessor).ShouldThrow<Exception>("string index is negative");
            ".003".Invoking(accessor).ShouldThrow<Exception>("string index is not an integer");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest1()
        {
            DBObjectArray l = new DBObjectArray();
            l[0] = "zero";
            l[0].Should().Be("zero", "we just set it");
            l[10] = "test";
            l[10].Should().Be("test", "we just set it");
            l[1].Should().BeNull("we expanded to a size of 10, and size was 0. All inbetween should be null.");

            Action<int> accessor = i => new DBObjectArray()[i] = "test";

            ((Int32)(-10)).Invoking(accessor).ShouldThrow<Exception>("string index is negative");
        }

        /// <summary>
        ///A test for Keys
        ///</summary>
        [TestMethod()]
        public void KeysTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a, b, c);
            target.Keys.Should().Contain("0", "1", "2");
        }


        /// <summary>
        ///A test for System.Collections.ICollection.Count
        ///</summary>
        [TestMethod()]
        public void CountTest1()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            ICollection target = new DBObjectArray(a,b,c) as ICollection;
            target.Count.Should().Be(3);
        }

        /// <summary>
        ///A test for System.Collections.ICollection.IsSynchronized
        ///</summary>
        [TestMethod()]
        public void IsSynchronizedTest()
        {
            ICollection target = new DBObjectArray() as ICollection;
            target.IsSynchronized.Should().BeFalse();
        }

        /// <summary>
        ///A test for System.Collections.ICollection.SyncRoot
        ///</summary>
        [TestMethod()]

        public void SyncRootTest()
        {
            ICollection target = new DBObjectArray() as ICollection;
            target.SyncRoot.Should().NotBeNull();
        }

        /// <summary>
        ///A test for System.Collections.IList.IsFixedSize
        ///</summary>
        [TestMethod()]
        public void IsFixedSizeTest()
        {
            IList target = new DBObjectArray() as IList;
            target.IsFixedSize.Should().BeFalse();
        }

        /// <summary>
        ///A test for System.Collections.IList.IsReadOnly
        ///</summary>
        [TestMethod()]
        public void IsReadOnlyTest1()
        {
            IList target = new DBObjectArray() as IList;
            target.IsReadOnly.Should().BeFalse();
        }

        /// <summary>
        ///A test for System.Collections.IList.Item
        ///</summary>
        [TestMethod()]
        public void ItemTest2()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            IList target = new DBObjectArray(a) as IList;
            target[2] = c;
            target[1] = b;
            target[0].Should().Be(a);
            target[1].Should().Be(b);
            target[2].Should().Be(c);
        }

        /// <summary>
        ///A test for Values
        ///</summary>
        [TestMethod()]
        public void ValuesTest()
        {
            DBObject a = new DBObject();
            DBObject b = new DBObject("a", 7);
            DBObject c = new DBObject("78", "car");
            DBObjectArray target = new DBObjectArray(a,b,c);
            target.Values.Should().ContainInOrder(new object[] {a, b, c});
        }
    }
}
