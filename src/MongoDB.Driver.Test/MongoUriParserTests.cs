//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using MongoDB.Driver.Platform.Util;
using System.Text;
using System.Linq;
using System.Collections;
namespace MongoDB.Driver.Test
{
    [TestFixture]
    public class MongoUriParserTests
    {
        [Test]
        public void FullUriParseTest()
        {
            string address = "mongo://localhost:7899/db";
            Uri uri = new Uri(address);
            Assert.That(uri.Scheme, Is.EqualTo(UriExtensions.UriSchemeMongo));
            Assert.That(uri.Port, Is.EqualTo(7899));
            Assert.That(uri.AbsolutePath, Is.EqualTo("/db"));
            Assert.That(uri.Host, Is.EqualTo("localhost"));
            Assert.That(uri.Authority, Is.EqualTo("localhost:7899"));
            Assert.That(uri.IsAbsoluteUri);
            Assert.IsFalse(uri.IsDefaultPort);
        }

        [Test]
        public void DefaultPortTest()
        {
            string address = "mongo://localhost/db";
            Uri uri = new Uri(address);
            Assert.That(uri.Scheme, Is.EqualTo(UriExtensions.UriSchemeMongo));
            Assert.That(uri.Port, Is.EqualTo(-1));
            Assert.That(uri.AbsolutePath, Is.EqualTo("/db"));
            Assert.That(uri.Host, Is.EqualTo("localhost"));
            Assert.That(uri.Authority, Is.EqualTo("localhost"));
            Assert.That(uri.IsAbsoluteUri);
            Assert.That(uri.IsDefaultPort);
        }

        [Test]
        public void DotTest()
        {
            string address = "mongo://localhost/db.testing";
            Uri uri = new Uri(address);
        }
    }
}