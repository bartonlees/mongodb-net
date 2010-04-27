//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class DBBindingTests
    {

        [Test]
        public void ConstructionTests()
        {   
            ServerBinding serverLoopback = new ServerBinding("mongo://localhost");
            DBBinding b1 = new DBBinding(serverLoopback, "db");
            ServerBinding serverLoopback2 = new ServerBinding("mongo://localhost/db2/test/goat");
            DBBinding b2 = new DBBinding(serverLoopback, "db");
            Assert.That(b1, Is.EqualTo(b2), "should have replaced the database portion if specified");
        }

        [Test]
        public void BadConstructionTests()
        {
            //Template, name
            Assert.That(() => new DBBinding((ServerBinding)null, "test"), Throws.Exception, "null binding template (hostname OK) : should have failed");
            Assert.That(() => new DBBinding(new ServerBinding("mongo://localhost"), (string)null), Throws.Exception, "null host (binding template OK) : should have failed");
        }
    }

}