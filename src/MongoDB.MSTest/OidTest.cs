using MongoDB.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Serialization;
using FluentAssertions;

namespace MongoDB.MSTest
{


    /// <summary>
    ///This is a test class for OidTest and is intended
    ///to contain all OidTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OidTest
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
        public void TestBase64Roundtrip()
        {
            Oid a = Oid.NewOid();
            string val = a.ToBase64String();
            string val2 = a.ToString("b", null);
            val.Should().Be(val2);
            Oid b = new Oid(val, "b");
            b.Should().Be(a);
        }

        [TestMethod]
        public void TestHexadecimalRoundtrip()
        {
            Oid a = Oid.NewOid();
            string val = a.ToHexadecimalString();
            string val2 = a.ToString("h", null);
            val.Should().Be(val2);
            Oid b = new Oid(val, "h");
            Oid c = new Oid(val);
            b.Should().Be(a);
            b.Should().Be(c);
        }

        [TestMethod]
        public void TestMongoDBRoundtrip()
        {
            Oid a = Oid.NewOid();
            string val = a.ToMongoDBString();
            string val2 = a.ToString("m", null);
            val.Should().Be(val2);
            Oid b = new Oid(val, "m");
            b.Should().Be(a);
        }

        /// <summary>
        ///A test for Oid Constructor
        ///</summary>
        [TestMethod()]
        public void OidConstructorTest()
        {
            Action<string> ctor = (s) => new Oid(s);
            "BAD0".Invoking(ctor).ShouldThrow<ArgumentException>();
            "BAD0BAD0BAD0BAD0BAD0BAD0BAD0BAD0".Invoking(ctor).ShouldThrow<ArgumentException>();
            "BADBOYc30a57000000008ecb".Invoking(ctor).ShouldThrow<ArgumentOutOfRangeException>();

            new Oid("4a7067c30a57000000008ecb").Should().NotBe(Oid.Empty);
            new Oid(string.Empty).Should().Be(Oid.Empty);
        }

        /// <summary>
        ///A test for Oid Constructor
        ///</summary>
        [TestMethod()]
        public void OidConstructorTest1()
        {
            string value = string.Empty; // TODO: Initialize to an appropriate value
            string format = string.Empty; // TODO: Initialize to an appropriate value
            Oid target = new Oid(value, format);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Oid Constructor
        ///</summary>
        [TestMethod()]
        public void OidConstructorTest2()
        {
            Action<byte[]> ctor = (p) => new Oid(p);

            new byte[] { 0, 1, 3, 5 }.Invoking(ctor).ShouldThrow<ArgumentException>("input does not have enough bytes for ObjectId");
            new byte[] { 0, 1, 3, 5, 0, 1, 3, 5, 0, 1, 3, 5, 0, 1, 3, 5, 0, 1, 3, 5, }.Invoking(ctor).ShouldThrow<ArgumentException>("input has too many bytes for ObjectId");
            new Oid(new byte[] { 0, 1, 3, 5, 0, 1, 3, 5, 0, 1, 3, 5 }).Should().NotBe(Oid.Empty);
        }

        /// <summary>
        ///A test for Oid Constructor
        ///</summary>
        [TestMethod()]
        public void OidConstructorTest3()
        {
            Oid a = Oid.NewOid();
            Oid b = new Oid(a);
            a.Should().Be(b);
        }

        /// <summary>
        ///A test for Oid Constructor
        ///</summary>
        [TestMethod()]
        public void OidConstructorTest4()
        {
            new Oid().Should().Be(Oid.Empty, "a default Oid constructor should initialize to empty");
        }

        /// <summary>
        ///A test for Oid Constructor
        ///</summary>
        [TestMethod()]
        public void OidConstructorTest5()
        {
            SerializationInfo serializationInfo = null; // TODO: Initialize to an appropriate value
            StreamingContext streamingContext = new StreamingContext(); // TODO: Initialize to an appropriate value
            Oid target = new Oid(serializationInfo, streamingContext);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CompareTo
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            Oid target = new Oid(); // TODO: Initialize to an appropriate value
            object obj = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CompareTo(obj);
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CompareTo
        ///</summary>
        [TestMethod()]
        public void CompareToTest1()
        {
            Oid target = new Oid(); // TODO: Initialize to an appropriate value
            Oid rhs = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CompareTo(rhs);
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            Oid target = new Oid(); // TODO: Initialize to an appropriate value
            Oid other = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(other);
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest1()
        {
            Oid target = new Oid(); // TODO: Initialize to an appropriate value
            object obj = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Equals(obj);
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FromByteArray
        ///</summary>
        [TestMethod()]

        public void FromByteArrayTest()
        {
            //Oid_Accessor target = new Oid_Accessor(); // TODO: Initialize to an appropriate value
            //byte[] buffer = null; // TODO: Initialize to an appropriate value
            //target.FromByteArray(buffer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FromHexadecimalString
        ///</summary>
        [TestMethod()]

        public void FromHexadecimalStringTest()
        {
            //Oid_Accessor target = new Oid_Accessor(); // TODO: Initialize to an appropriate value
            //string val = string.Empty; // TODO: Initialize to an appropriate value
            //target.FromHexadecimalString(val);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            Oid target = new Oid(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetHashCode();
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetObjectData
        ///</summary>
        [TestMethod()]
        public void GetObjectDataTest()
        {
            Oid target = new Oid(); // TODO: Initialize to an appropriate value
            SerializationInfo info = null; // TODO: Initialize to an appropriate value
            StreamingContext context = new StreamingContext(); // TODO: Initialize to an appropriate value
            target.GetObjectData(info, context);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for NewOid
        ///</summary>
        [TestMethod()]
        public void NewOidTest()
        {
            Oid.NewOid().Should().NotBe(Oid.NewOid());
        }

        /// <summary>
        ///A test for ToBase64String
        ///</summary>
        [TestMethod()]
        public void ToBase64StringTest()
        {
            Oid a = Oid.NewOid();
            Console.WriteLine(a.ToBase64String());
        }

        /// <summary>
        ///A test for ToHexadecimalString
        ///</summary>
        [TestMethod()]
        public void ToHexadecimalStringTest()
        {
            Oid a = Oid.NewOid();
            Console.WriteLine(a.ToHexadecimalString());
        }

        /// <summary>
        ///A test for ToMongoDBString
        ///</summary>
        [TestMethod()]
        public void ToMongoDBStringTest()
        {
            Oid a = Oid.NewOid();
            Console.WriteLine(a.ToMongoDBString());
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Oid a = Oid.NewOid();
            Console.WriteLine(a.ToString("m", null));
            Console.WriteLine(a.ToString("h", null));
            Console.WriteLine(a.ToString("b", null));
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest1()
        {
            Oid a = Oid.NewOid();
            Console.WriteLine(a.ToBase64String());
            Console.WriteLine(a.ToHexadecimalString());
            Console.WriteLine(a.ToString("m", null));
            Console.WriteLine(a.ToString("h", null));
            Console.WriteLine(a.ToString("b", null));
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            Oid oid = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = oid;
            actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest1()
        {
            string hex = "4a7067c30a57000000008ecb";
            new Oid(hex).Should().Be(new Oid(hex));

            string hex2 = "4a7067c30a57000000008ecb";
            string hex3 = "4a7067c30a57000000008ecc";
            new Oid(hex2).Should().NotBe(new Oid(hex3));
        }

        /// <summary>
        ///A test for Buffer
        ///</summary>
        [TestMethod()]
        public void BufferTest()
        {
            //Oid_Accessor target = new Oid_Accessor(); // TODO: Initialize to an appropriate value
            //byte[] expected = null; // TODO: Initialize to an appropriate value
            //byte[] actual;
            //target.Buffer = expected;
            //actual = target.Buffer;
            //actual.Should().Be(expected);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Inc
        ///</summary>
        [TestMethod()]
        public void IncTest()
        {
            Oid target = new Oid(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Inc;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Machine
        ///</summary>
        [TestMethod()]
        public void MachineTest()
        {
            Oid target = new Oid(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Machine;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod()]
        public void TimeTest()
        {
            long a = DateTime.Now.Ticks;
            long b = Oid.NewOid().Time;
            Math.Abs(b - a).Should().BeLessThan(3000);
        }
    }
}
