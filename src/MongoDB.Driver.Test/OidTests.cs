using System;
using NUnit.Framework;

namespace MongoDB.Driver.Test
{
    [TestFixture]
    public class OidTests
    {
        [Test]
        public void TestCtorStringTooShort()
        {
            Assert.That(() => new Oid("BAD0"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestCtorStringTooLong()
        {
            Assert.That(() => new Oid("BAD0BAD0BAD0BAD0BAD0BAD0BAD0BAD0"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestCtorStringNotHexadecimal()
        {
            Assert.That(() => new Oid("BADBOYc30a57000000008ecb"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestCtorStringValid()
        {
            Assert.That(() => new Oid("4a7067c30a57000000008ecb"), Is.Not.EqualTo(Oid.Empty));
        }

        [Test]
        public void TestCtorStringEmpty()
        {
            Assert.That(new Oid(string.Empty), Is.EqualTo(Oid.Empty));
        }

        [Test]
        public void TestCtorBytesTooShort()
        {
            Assert.That(() => new Oid(new byte[] { 0, 1, 3, 5 }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestCtorBytesTooLong()
        {
            Assert.That(() => new Oid(new byte[] { 0, 1, 3, 5, 0, 1, 3, 5, 0, 1, 3, 5, 0, 1, 3, 5, 0, 1, 3, 5, }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestCtorBytesValid()
        {
            Assert.That(() => new Oid(new byte[] { 0, 1, 3, 5, 0, 1, 3, 5, 0, 1, 3, 5 }), Is.Not.EqualTo(Oid.Empty));
        }

        [Test]
        public void TestCtorDefault()
        {
            Assert.That(new Oid(), Is.EqualTo(Oid.Empty));
        }

        [Test]
        public void TestEquals()
        {
            string hex = "4a7067c30a57000000008ecb";
            Assert.That(new Oid(hex), Is.EqualTo(new Oid(hex)));
        }

        [Test]
        public void TestNotEquals()
        {
            string hex = "4a7067c30a57000000008ecb";
            string hex2 = "4a7067c30a57000000008ecc";
            Assert.That(new Oid(hex), Is.Not.EqualTo(new Oid(hex2)));
        }

        [Test]
        public void TestNewOids()
        {
            Assert.That(Oid.NewOid(), Is.Not.EqualTo(Oid.NewOid()));
        }

        [Test]
        public void TestCtorOid()
        {
            Oid a = Oid.NewOid();
            Oid b = new Oid(a);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void TestToStrings()
        {
            Oid a = Oid.NewOid();
            Console.WriteLine(a.ToBase64String());
            Console.WriteLine(a.ToHexadecimalString());
            Console.WriteLine(a.ToString("m", null));
            Console.WriteLine(a.ToString("h", null));
            Console.WriteLine(a.ToString("b", null));
        }

        [Test]
        public void TestBase64Roundtrip()
        {
            Oid a = Oid.NewOid();
            string val = a.ToBase64String();
            string val2 = a.ToString("b", null);
            Assert.That(val, Is.EqualTo(val2));
            Oid b = new Oid(val, "b");
            Assert.That(b, Is.EqualTo(a));
        }

        [Test]
        public void TestHexadecimalRoundtrip()
        {
            Oid a = Oid.NewOid();
            string val = a.ToHexadecimalString();
            string val2 = a.ToString("h", null);
            Assert.That(val, Is.EqualTo(val2));
            Oid b = new Oid(val, "h");
            Oid c = new Oid(val);
            Assert.That(b, Is.EqualTo(a));
            Assert.That(b, Is.EqualTo(c));
        }

        [Test]
        public void TestMongoDBRoundtrip()
        {
            Oid a = Oid.NewOid();
            string val = a.ToMongoDBString();
            string val2 = a.ToString("m", null);
            Assert.That(val, Is.EqualTo(val2));
            Oid b = new Oid(val, "m");
            Assert.That(b, Is.EqualTo(a));
        }

        [Test]
        public void TestTime()
        {
            long a = DateTime.Now.Ticks;
            long b = Oid.NewOid().Time;
            Assert.That(Math.Abs(b - a), Is.LessThan(3000));
        }
    }
}

