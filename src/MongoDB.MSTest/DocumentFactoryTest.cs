using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for DocumentFactoryTest and is intended
    ///to contain all DocumentFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DocumentFactoryTest
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
        ///A test for CreateDocument
        ///</summary>
        public void CreateDocumentTestHelper<TDoc>()
            where TDoc : class , IDocument
        {
            //Oid id = null; // TODO: Initialize to an appropriate value
            //bool partial = false; // TODO: Initialize to an appropriate value
            //TDoc expected = null; // TODO: Initialize to an appropriate value
            //TDoc actual;
            //actual = DocumentFactory<TDoc>.CreateDocument(id, partial);
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CreateDocumentTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TDo" +
                    "c. Please call CreateDocumentTestHelper<TDoc>() with appropriate type parameters" +
                    ".");
        }
    }
}
