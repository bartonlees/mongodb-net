using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Sockets;
using FluentAssertions;

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
        }

        /// <summary>
        ///A test for Reset
        ///</summary>
        [TestMethod()]
        public void ResetTest()
        {
            DBConnectionOptions def = new DBConnectionOptions();
            DBConnectionOptions target = new DBConnectionOptions();
            target.AutoConnectRetry = !def.AutoConnectRetry;
            target.ConnectionFactory = (a, b) => null;
            target.ConnectionPoolSize++;
            target.FireAndForgetUpdate = !def.FireAndForgetUpdate;
            target.LingerState = new LingerOption(true, 2);
            target.NoDelay = !def.NoDelay;
            target.ReceiveBufferSize++;
            target.ReceiveTimeout++;
            target.RetryTime++;
            target.SendBufferSize++;
            target.SendTimeout++;
            
            //Verify our assumptions
            target.AutoConnectRetry.Should().Be(!def.AutoConnectRetry);
            target.ConnectionFactory.Should().NotBe(def.ConnectionFactory);
            target.ConnectionPoolSize.Should().NotBe(def.ConnectionPoolSize);
            target.FireAndForgetUpdate.Should().Be(!def.FireAndForgetUpdate);
            target.LingerState.Should().NotBe(def.LingerState);
            target.NoDelay.Should().Be(!def.NoDelay);
            target.ReceiveBufferSize.Should().NotBe(def.ReceiveBufferSize);
            target.ReceiveTimeout.Should().NotBe(def.ReceiveTimeout);
            target.RetryTime.Should().NotBe(def.RetryTime);
            target.SendBufferSize.Should().NotBe(def.SendBufferSize);
            target.SendTimeout.Should().NotBe(def.SendTimeout);

            //Reset
            target.Reset();
            //Verify the result
            target.AutoConnectRetry.Should().Be(def.AutoConnectRetry, "AutoConnectRetry should have been reset");
            target.ConnectionFactory.Should().Be(def.ConnectionFactory, "ConnectionFactory should have been reset");
            target.ConnectionPoolSize.Should().Be(def.ConnectionPoolSize, "ConnectionPoolSize should have been reset");
            target.FireAndForgetUpdate.Should().Be(def.FireAndForgetUpdate, "FireAndForgetUpdate should have been reset");
            target.LingerState.Should().BeNull("LingerState should have been reset");
            target.NoDelay.Should().Be(def.NoDelay, "NoDelay should have been reset");
            target.ReceiveBufferSize.Should().Be(def.ReceiveBufferSize, "ReceiveBufferSize should have been reset");
            target.ReceiveTimeout.Should().Be(def.ReceiveTimeout, "ReceiveTimeout should have been reset");
            target.RetryTime.Should().Be(def.RetryTime, "RetryTime should have been reset");
            target.SendBufferSize.Should().Be(def.SendBufferSize, "SendBufferSize should have been reset");
            target.SendTimeout.Should().Be(def.SendTimeout, "SendTimeout should have been reset");
        }

        /// <summary>
        ///A test for ConnectionFactory
        ///</summary>
        [TestMethod()]
        public void ConnectionFactoryTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            target.ConnectionFactory = (ep, o) => null;
            target.ConnectionFactory(null, null).Should().BeNull();
        }

        /// <summary>
        ///A test for ConnectionPoolSize
        ///</summary>
        [TestMethod()]
        public void ConnectionPoolSizeTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            int expected = 234;
            int actual;
            target.ConnectionPoolSize = expected;
            actual = target.ConnectionPoolSize;
            expected.Should().Be(actual);
        }

        /// <summary>
        ///A test for LingerState
        ///</summary>
        [TestMethod()]
        public void LingerStateTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            LingerOption expected = new LingerOption(true, 123);
            LingerOption actual;
            target.LingerState = expected;
            actual = target.LingerState;
            expected.Should().Be(actual);
        }

        /// <summary>
        ///A test for NoDelay
        ///</summary>
        [TestMethod()]
        public void NoDelayTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            bool expected = true; 
            bool actual;
            target.NoDelay = expected;
            actual = target.NoDelay;
            expected.Should().Be(actual);
        }

        /// <summary>
        ///A test for ReceiveBufferSize
        ///</summary>
        [TestMethod()]
        public void ReceiveBufferSizeTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            int expected = 71;
            int actual;
            target.ReceiveBufferSize = expected;
            actual = target.ReceiveBufferSize;
            expected.Should().Be(actual);
        }

        /// <summary>
        ///A test for RetryTime
        ///</summary>
        [TestMethod()]
        public void RetryTimeTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            long expected = 80;
            long actual;
            target.RetryTime = expected;
            actual = target.RetryTime;
            expected.Should().Be(actual);
        }

        /// <summary>
        ///A test for SendBufferSize
        ///</summary>
        [TestMethod()]
        public void SendBufferSizeTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            int expected = 2344;
            int actual;
            target.SendBufferSize = expected;
            actual = target.SendBufferSize;
            expected.Should().Be(actual);
        }

        /// <summary>
        ///A test for DoNotGetLastError
        ///</summary>
        [TestMethod()]
        public void FireAndForgetUpdateTest()
        {
            DBConnectionOptions target = new DBConnectionOptions();
            bool expected = false; 
            bool actual;
            target.FireAndForgetUpdate = expected;
            actual = target.FireAndForgetUpdate;
            expected.Should().Be(actual);
        }
    }
}
