using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DBErrorTest and is intended
    ///to contain all DBErrorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBErrorTest
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

        private DBError GetInstance()
        {
            return new DBError(new DBObject() { { "errmsg", "ns not found" }, { "assertion", "my assertion" } });
        }

        /// <summary>
        ///A test for DBError Constructor
        ///</summary>
        [TestMethod()]
        public void DBErrorConstructorTest()
        {
            DBError target = GetInstance();
        }

        /// <summary>
        ///A test for Throw
        ///</summary>
        [TestMethod()]
        public void ThrowTest()
        {
            DBError target = GetInstance();
            string context = "MyContext"; 
            new Action(() => target.Throw(context)).ShouldThrow<MongoException>();
        }

        /// <summary>
        ///A test for ToCode
        ///</summary>
        [TestMethod()]
        public void ToCodeTest()
        {
            DBError.ToCode("E10003").Should().Be(DBError.Code.FailingUpdateOfCappedNS);
            DBError.ToCode("E11000        ").Should().Be(DBError.Code.DuplicateKeyError);
            DBError.ToCode("E11001 dsdfsd    fdf").Should().Be(DBError.Code.DuplicateKeyOnUpdate);
            DBError.ToCode("E12000-fdfdfdfdfd").Should().Be(DBError.Code.IdxNoFails);
            DBError.ToCode("E12001----------").Should().Be(DBError.Code.CannotSortMSSnapshot);
            DBError.ToCode("E12010-3-3-3").Should().Be(DBError.Code.CannotIncAnIndexedField);
            DBError.ToCode("E12011").Should().Be(DBError.Code.CannotSetAnIndexedField);
        }

        /// <summary>
        ///A test for Assertion
        ///</summary>
        [TestMethod()]
        public void AssertionTest()
        {
            DBError target = GetInstance();
            target.Assertion.Should().NotBeNull().And.NotBeEmpty();
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            DBError target = GetInstance();
            target.Message.Should().NotBeNull().And.NotBeEmpty();
        }

        /// <summary>
        ///A test for NamespaceWasNotFound
        ///</summary>
        [TestMethod()]
        public void NamespaceWasNotFoundTest()
        {
            DBError target = GetInstance();
            target.NamespaceWasNotFound.Should().BeTrue();
        }
    }
}
