using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Collections;

namespace MongoDB.Driver.Test
{
    [TestFixture]
    public class WireProtocolTests
    {

        /// <summary>
        /// Tests the write string.
        /// </summary>
        [Test]
        public void TestWriteString()
        {
            MemoryStream ms = new MemoryStream();
            WireProtocolWriter writer = new WireProtocolWriter(ms);
            string expected = "54-65-73-74-73-2E-69-6E-73-65-72-74-73-00";
            writer.WriteNullTerminated("Tests.inserts");

            string hexdump = BitConverter.ToString(ms.ToArray());

            Assert.AreEqual(expected, hexdump);
        }

        [Test]
        public void TestWritePrefixedString()
        {
            MemoryStream ms = new MemoryStream();
            WireProtocolWriter writer = new WireProtocolWriter(ms);
            string expected = "0E-00-00-00-54-65-73-74-73-2E-69-6E-73-65-72-74-73-00";
            writer.WriteLengthPrefixedNullTerminated("Tests.inserts");

            string hexdump = BitConverter.ToString(ms.ToArray());

            Assert.AreEqual(expected, hexdump);
        }

        [Test]
        public void TestWritePrefixedString2()
        {
            MemoryStream ms = new MemoryStream();
            WireProtocolWriter writer = new WireProtocolWriter(ms);
            string expected = "05-00-00-00-54-65-73-74-00";
            writer.WriteLengthPrefixedNullTerminated("Test");

            string hexdump = BitConverter.ToString(ms.ToArray());

            Assert.AreEqual(expected, hexdump);
        }

        [Test]
        public void TestWriteInt()
        {
            MemoryStream ms = new MemoryStream();
            WireProtocolWriter writer = new WireProtocolWriter(ms);
            string expected = "01-00-00-00";
            writer.Write(1);

            string hexdump = BitConverter.ToString(ms.ToArray());

            Assert.AreEqual(expected, hexdump);
        }

        [Test]
        public void TestWriteDocument()
        {
            MemoryStream ms = new MemoryStream();
            WireProtocolWriter writer = new WireProtocolWriter(ms);
            string expected = "1400000002746573740005000000746573740000";
            DBObject doc = new DBObject("test", "test");

            writer.Write(doc);

            string hexdump = BitConverter.ToString(ms.ToArray());
            hexdump = hexdump.Replace("-", "");

            Assert.AreEqual(expected, hexdump);
        }

        [Test]
        public void TestWriteArrayDoc()
        {
            String expected = "2000000002300002000000610002310002000000620002320002000000630000";
            MemoryStream ms = new MemoryStream();
            WireProtocolWriter writer = new WireProtocolWriter(ms);

            String[] str = new String[] { "a", "b", "c" };
            writer.Write(new DBObjectArray((IList)str));

            string hexdump = BitConverter.ToString(ms.ToArray());
            hexdump = hexdump.Replace("-", "");
            Assert.AreEqual(expected, hexdump);
        }
    }
}
