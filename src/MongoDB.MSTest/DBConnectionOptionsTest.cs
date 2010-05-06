using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Sockets;

namespace MongoDB.MSTest
{
    
    
    /// <summary>
    ///This is a test class for DBConnectionOptionsTest and is intended
    ///to contain all DBConnectionOptionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBConnectionOptionsTest
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
        ///A test for DBConnectionOptions Constructor
        ///</summary>
        [TestMethod()]
        public void DBConnectionOptionsConstructorTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Reset
        ///</summary>
        [TestMethod()]
        public void ResetTest()
        {
            DBConnectionOptions target = new DBConnectionOptions(); // TODO: Initialize to an appropriate value
            target.Reset();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ConnectionFactory
        ///</summary>
        [TestMethod()]
        public void ConnectionFactoryTest()
        {
            DBConnectionOptions target = new DBConnectionOptions(); // TODO: Initialize to an appropriate value
            Func<IPEndPoint, DBConnectionOptions, IDBConnection> expected = null; // TODO: Initialize to an appropriate value
            Func<IPEndPoint, DBConnectionOptions, IDBConnection> actual;
            target.ConnectionFactory = expected;
            actual = target.ConnectionFactory;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConnectionPoolSize
        ///</summary>
        [TestMethod()]
        public void ConnectionPoolSizeTest()
        {
            DBConnectionOptions target = new DBConnectionOptions(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ConnectionPoolSize = expected;
            actual = target.ConnectionPoolSize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LingerState
        ///</summary>
        [TestMethod()]
        public void LingerStateTest()
        {
            DBConnectionOptions target = new DBConnectionOptions(); // TODO: Initialize to an appropriate value
            LingerOption expected = null; // TODO: Initialize to an appropriate value
            LingerOption actual;
            target.LingerState = expected;
            actual = target.LingerState;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NoDelay
        ///</summary>
        [TestMethod()]
        public void NoDelayTest()
        {
            DBConnectionOptions target = new DBConnectionOptions(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.NoDelay = expected;
            actual = target.NoDelay;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReceiveBufferSize
        ///</summary>
        [TestMethod()]
        public void ReceiveBufferSizeTest()
        {
            DBConnectionOptions target = new DBConnectionOptions(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.ReceiveBufferSize = expected;
            actual = target.ReceiveBufferSize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RetryTime
        ///</summary>
        [TestMethod()]
        public void RetryTimeTest()
        {
            DBConnectionOptions target = new DBConnectionOptions(); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            target.RetryTime = expected;
            actual = target.RetryTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SendBufferSize
        ///</summary>
        [TestMethod()]
        public void SendBufferSizeTest()
        {
            DBConnectionOptions target = new DBConnectionOptions(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.SendBufferSize = expected;
            actual = target.SendBufferSize;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
