using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for IDBConnectionTest and is intended
    ///to contain all IDBConnectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IDBConnectionTest
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
        ///A test for Call
        ///</summary>
        public void CallTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            IDBConnection target = CreateIDBConnection(); // TODO: Initialize to an appropriate value
            IDBRequest msg = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> expected = null; // TODO: Initialize to an appropriate value
            IDBResponse<TDoc> actual;
            actual = target.Call<TDoc>(msg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual IDBConnection CreateIDBConnection()
        {
            // TODO: Instantiate an appropriate concrete class.
            IDBConnection target = null;
            return target;
        }

        [TestMethod()]
        public void CallTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CallTestHelper<TDoc>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Say
        ///</summary>
        [TestMethod()]
        public void SayTest()
        {
            IDBConnection target = CreateIDBConnection(); // TODO: Initialize to an appropriate value
            IDBRequest msg = null; // TODO: Initialize to an appropriate value
            target.Say(msg);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TryAuthenticate
        ///</summary>
        [TestMethod()]
        public void TryAuthenticateTest()
        {
            IDBConnection target = CreateIDBConnection(); // TODO: Initialize to an appropriate value
            IDBCollection cmdCollection = null; // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            SecureString usrPassHash = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryAuthenticate(cmdCollection, username, usrPassHash);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanRequest
        ///</summary>
        [TestMethod()]
        public void CanRequestTest()
        {
            IDBConnection target = CreateIDBConnection(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanRequest;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
