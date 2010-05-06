using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for IDBObjectExtensionsTest and is intended
    ///to contain all IDBObjectExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBObjectExtensionsTest
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
        ///A test for GetAs
        ///</summary>
        public void GetAsTestHelper<T>()
            where T : class
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            T defaultValue = null; // TODO: Initialize to an appropriate value
            T expected = null; // TODO: Initialize to an appropriate value
            T actual;
            actual = IDBObjectExtensions.GetAs<T>(o, name, defaultValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetAsTest()
        {
            GetAsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetAs
        ///</summary>
        public void GetAsTest1Helper<T>()
            where T : class
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            T expected = null; // TODO: Initialize to an appropriate value
            T actual;
            actual = IDBObjectExtensions.GetAs<T>(o, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetAsTest1()
        {
            GetAsTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetAsIDBObject
        ///</summary>
        [TestMethod()]
        public void GetAsIDBObjectTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            IDBObject expected = null; // TODO: Initialize to an appropriate value
            IDBObject actual;
            actual = IDBObjectExtensions.GetAsIDBObject(o, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAsInt
        ///</summary>
        [TestMethod()]
        public void GetAsIntTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            int def = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = IDBObjectExtensions.GetAsInt(o, name, def);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAsInt
        ///</summary>
        [TestMethod()]
        public void GetAsIntTest1()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = IDBObjectExtensions.GetAsInt(o, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAsLong
        ///</summary>
        [TestMethod()]
        public void GetAsLongTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = IDBObjectExtensions.GetAsLong(o, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAsLong
        ///</summary>
        [TestMethod()]
        public void GetAsLongTest1()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            long defaultValue = 0; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = IDBObjectExtensions.GetAsLong(o, name, defaultValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAsString
        ///</summary>
        [TestMethod()]
        public void GetAsStringTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = IDBObjectExtensions.GetAsString(o, name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAsString
        ///</summary>
        [TestMethod()]
        public void GetAsStringTest1()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            string defaultValue = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = IDBObjectExtensions.GetAsString(o, name, defaultValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetID
        ///</summary>
        [TestMethod()]
        public void GetIDTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = IDBObjectExtensions.GetID(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetOid
        ///</summary>
        [TestMethod()]
        public void GetOidTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            actual = IDBObjectExtensions.GetOid(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasID
        ///</summary>
        [TestMethod()]
        public void HasIDTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IDBObjectExtensions.HasID(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasOid
        ///</summary>
        [TestMethod()]
        public void HasOidTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IDBObjectExtensions.HasOid(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsNumber
        ///</summary>
        [TestMethod()]
        public void IsNumberTest()
        {
            object value = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IDBObjectExtensions.IsNumber(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RequireOid
        ///</summary>
        [TestMethod()]
        public void RequireOidTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            actual = IDBObjectExtensions.RequireOid(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ThrowIfResponseNotOK
        ///</summary>
        [TestMethod()]
        public void ThrowIfResponseNotOKTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            string failureMessage = string.Empty; // TODO: Initialize to an appropriate value
            IDBObjectExtensions.ThrowIfResponseNotOK(o, failureMessage);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WasError
        ///</summary>
        [TestMethod()]
        public void WasErrorTest()
        {
            IDBObject o = null; // TODO: Initialize to an appropriate value
            DBError error = null; // TODO: Initialize to an appropriate value
            DBError errorExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IDBObjectExtensions.WasError(o, out error);
            Assert.AreEqual(errorExpected, error);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
