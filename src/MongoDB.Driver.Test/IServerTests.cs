//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using MongoDB.Driver.Platform.Util;
using System.Text;
using System.Linq;
using System.Collections;
using System.Data;
namespace MongoDB.Driver.Test
{
    [TestFixture]
    public class IServerTests
    {
        [Test]
        public void InstantiateTest()
        {
            IServer server = Mongo.DefaultServer;
        }

        [Test]
        public void DatabaseNamesTest()
        {
            foreach (Uri name in Mongo.DefaultServer.DatabaseNames)
            {
                Console.WriteLine(name);
            }
        }

        [Test]
        public void ReadOnly()
        {
            //Make sure this collection doesn't exist
            IServer readOnlyServer = Mongo.ReadOnlyDefaultServer;

            Assert.That(readOnlyServer.ReadOnly, Is.True, "Server.ReadOnly");

            Assert.That(() => readOnlyServer.DropDatabase(Mongo.DefaultDatabase),
                Throws.InstanceOf<ReadOnlyException>());
        }
    }
}