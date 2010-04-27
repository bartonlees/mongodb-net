//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class ServerBindingTests
    {

        [Test]
        public void ConstructionTests()
        {
            //Strings
            ServerBinding loopback = new ServerBinding("mongo://localhost");
            ServerBinding ipv4loopback = new ServerBinding("mongo://127.0.0.1");
            ServerBinding ipv6loopback = new ServerBinding("mongo://[::1]");
            ServerBinding loopbackport = new ServerBinding("mongo://localhost:1910");
            ServerBinding ipv4loopbackport = new ServerBinding("mongo://127.0.0.1:1910");
            ServerBinding ipv6loopbackport = new ServerBinding("mongo://[::1]:1910");

            Assert.That(loopbackport, Is.Not.EqualTo(loopback), "should differ by port number");
            Assert.That(ipv4loopbackport, Is.Not.EqualTo(ipv4loopback), "should differ by port number");
            Assert.That(ipv6loopbackport, Is.Not.EqualTo(ipv6loopback), "should differ by port number");

            ServerBinding host_port_dbname = new ServerBinding("localhost", 1910);

            Assert.That(loopbackport, Is.EqualTo(host_port_dbname), "explicit host + port + db should still be equivalent");
        }

        [Test]
        public void BadConstructionTests()
        {
            //Strings
            Assert.That(() => new ServerBinding((string)null), Throws.InstanceOf<ArgumentNullException>(), "null uristring : should have failed");
            Assert.That(() => new ServerBinding(string.Empty), Throws.InstanceOf<UriFormatException>(), "empty uristring : should have failed");
            Assert.That(() => new ServerBinding(" "), Throws.InstanceOf<UriFormatException>(), "whitespace uristring : should have failed");
            Assert.That(() => new ServerBinding("db"), Throws.InstanceOf<UriFormatException>(), "unqualified, ambiguous identifier uristring : should have failed");
            Assert.That(() => new ServerBinding("http://localhost"), Throws.ArgumentException, "bad scheme uristring : should have failed");
            Assert.That(() => new ServerBinding("localhost:1910"), Throws.ArgumentException, "forced host interpretation (:port), but no db : should have failed");

            //Uris
            Assert.That(() => new ServerBinding((Uri)null), Throws.Exception, "null uri : should have failed");

            //host, port
            Assert.That(() => new ServerBinding((string)null, 123), Throws.Exception, "null hostname (port OK) : should have failed");
            Assert.That(() => new ServerBinding("localhost", -1), Throws.Exception, "negative port (hostname OK) : should have failed");
            Assert.That(() => new ServerBinding("localhost", 65536), Throws.Exception, "port out of range (hostname OK) : should have failed");
        }
    }

}