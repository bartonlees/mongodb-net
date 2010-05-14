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
            IList list = null; // TODO: Initialize to an appropriate value
            DBObjectArray target = new DBObjectArray(list);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest1()
        {
            IList<object> list = null; // TODO: Initialize to an appropriate value
            DBObjectArray target = new DBObjectArray(list);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest2()
        {
            IDictionary<string, object> map = null; // TODO: Initialize to an appropriate value
            DBObjectArray target = new DBObjectArray(map);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest3()
        {
            DBObjectArray target = new DBObjectArray();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DBObjectArray Constructor
        ///</summary>
        [TestMethod()]
        public void DBObjectArrayConstructorTest4()
        {
            int capacity = 0; // TODO: Initialize to an appropriate value
            DBObjectArray target = new DBObjectArray(capacity);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            KeyValuePair<string, object> item = new KeyValuePair<string, object>(); // TODO: Initialize to an appropriate value
            target.Add(item);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest1()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            target.Add(key, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest2()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object item = null; // TODO: Initialize to an appropriate value
            target.Add(item);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            KeyValuePair<string, object> item = new KeyValuePair<string, object>(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest1()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object item = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContainsKey
        ///</summary>
        [TestMethod()]
        public void ContainsKeyTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ContainsKey(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CopyTo
        ///</summary>
        [TestMethod()]
        public void CopyToTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            KeyValuePair<string, object>[] array = null; // TODO: Initialize to an appropriate value
            int arrayIndex = 0; // TODO: Initialize to an appropriate value
            target.CopyTo(array, arrayIndex);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyTo
        ///</summary>
        [TestMethod()]
        public void CopyToTest1()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object[] array = null; // TODO: Initialize to an appropriate value
            int arrayIndex = 0; // TODO: Initialize to an appropriate value
            target.CopyTo(array, arrayIndex);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            IEnumerator<KeyValuePair<string, object>> expected = null; // TODO: Initialize to an appropriate value
            IEnumerator<KeyValuePair<string, object>> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IndexOf
        ///</summary>
        [TestMethod()]
        public void IndexOfTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object item = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.IndexOf(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            object item = null; // TODO: Initialize to an appropriate value
            target.Insert(index, item);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PutAll
        ///</summary>
        [TestMethod()]
        public void PutAllTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            IDictionary<string, object> map = null; // TODO: Initialize to an appropriate value
            target.PutAll(map);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest1()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object item = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest2()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            KeyValuePair<string, object> item = new KeyValuePair<string, object>(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveAt
        ///</summary>
        [TestMethod()]
        public void RemoveAtTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.RemoveAt(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator
        ///</summary>
        [TestMethod()]

        public void GetEnumeratorTest1()
        {
            //IEnumerable<T> target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            //IEnumerator<object> expected = null; // TODO: Initialize to an appropriate value
            //IEnumerator<object> actual;
            //actual = target.GetEnumerator();
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.ICollection.CopyTo
        ///</summary>
        [TestMethod()]

        public void CopyToTest2()
        {
            ICollection target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            Array array = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyTo(array, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        [TestMethod()]

        public void GetEnumeratorTest2()
        {
            IEnumerable target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.IList.Add
        ///</summary>
        [TestMethod()]

        public void AddTest3()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Add(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.IList.Clear
        ///</summary>
        [TestMethod()]

        public void ClearTest1()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for System.Collections.IList.Contains
        ///</summary>
        [TestMethod()]

        public void ContainsTest2()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.IList.IndexOf
        ///</summary>
        [TestMethod()]

        public void IndexOfTest1()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.IndexOf(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.IList.Insert
        ///</summary>
        [TestMethod()]

        public void InsertTest1()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            target.Insert(index, value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for System.Collections.IList.Remove
        ///</summary>
        [TestMethod()]

        public void RemoveTest3()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            target.Remove(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for System.Collections.IList.RemoveAt
        ///</summary>
        [TestMethod()]

        public void RemoveAtTest1()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.RemoveAt(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TryGetValue
        ///</summary>
        [TestMethod()]
        public void TryGetValueTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
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

        /// <summary>
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Count;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        [TestMethod()]
        public void IDTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.ID = expected;
            actual = target.ID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsReadOnly
        ///</summary>
        [TestMethod()]
        public void IsReadOnlyTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
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
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            ICollection<string> actual;
            actual = target.Keys;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PartialObject
        ///</summary>
        [TestMethod()]
        public void PartialObjectTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.PartialObject = expected;
            actual = target.PartialObject;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for State
        ///</summary>
        [TestMethod()]

        public void StateTest()
        {
            //DBObjectArray_Accessor target = new DBObjectArray_Accessor(); // TODO: Initialize to an appropriate value
            //DocumentState expected = new DocumentState(); // TODO: Initialize to an appropriate value
            //DocumentState actual;
            //target.State = expected;
            //actual = target.State;
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.ICollection.Count
        ///</summary>
        [TestMethod()]

        public void CountTest1()
        {
            ICollection target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Count;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.ICollection.IsSynchronized
        ///</summary>
        [TestMethod()]

        public void IsSynchronizedTest()
        {
            ICollection target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsSynchronized;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.ICollection.SyncRoot
        ///</summary>
        [TestMethod()]

        public void SyncRootTest()
        {
            ICollection target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            object actual;
            actual = target.SyncRoot;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.IList.IsFixedSize
        ///</summary>
        [TestMethod()]

        public void IsFixedSizeTest()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsFixedSize;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.IList.IsReadOnly
        ///</summary>
        [TestMethod()]

        public void IsReadOnlyTest1()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.IList.Item
        ///</summary>
        [TestMethod()]

        public void ItemTest2()
        {
            IList target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target[index] = expected;
            actual = target[index];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Values
        ///</summary>
        [TestMethod()]
        public void ValuesTest()
        {
            DBObjectArray target = new DBObjectArray(); // TODO: Initialize to an appropriate value
            ICollection<object> actual;
            actual = target.Values;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
