//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using MongoDB.Driver.Platform.Util;
using System.Text;
using System.Linq;
using System.Collections;
using System.Threading;
using System.Data;
namespace MongoDB.Driver.Test
{
    [TestFixture]
    public class IDatabaseTests
    {
        [Test]
        public void CreateExplicitlyNonCappedCollection()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo1");
            c.Drop();
            c = Mongo.DefaultDatabase.CreateCollection("foo1", capped:false);
        }
        
        [Test]
        public void CreateCappedCollectionSize100()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo2");
            c.Drop();

            c = Mongo.DefaultDatabase.CreateCollection("foo2", capped: true, size: 100);

            for (int test = 0; test < 30; test++)
            {
                c.Insert(new Document("test", test));
            }
            
            Assert.That(c.Find().Count(), Is.LessThan(10));
        }

        [Test]
        public void CreateCappedCollectionMax2()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo3");
            c.Drop();
            c = Mongo.DefaultDatabase.CreateCollection("foo3", capped: true, max: 2);
            for (int test = 0; test < 30; test++)
            {
                c.Insert(new Document("test", test));
            }
            Assert.That(c.Find().Count(), Is.EqualTo(2));
        }

        [Test]
        public void CreateCappedCollectionMax35Size100()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo3");
            c.Drop();

            c = Mongo.DefaultDatabase.CreateCollection("foo3", capped: true, size: 100, max: 35);
            for (int test = 0; test < 30; test++)
            {
                c.Insert(new Document("test", test));
            }
            Assert.That(c.Find().Count(), Is.LessThan(10));
        }

        [Test]
        public void CreateCappedExceptionNegativeSize()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo4");
            c.Drop();

            Assert.That(() => c = Mongo.DefaultDatabase.CreateCollection("foo4", capped: true, size: -20), Throws.Exception, "Negative size should not be allowed");

        }

        [Test]
        public void CreateCappedExceptionNegativeMax()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("foo4");
            c.Drop();

            Assert.That(() => c = Mongo.DefaultDatabase.CreateCollection("foo4", capped:true, max:-20), Throws.Exception, "Negative size should not be allowed");
        }

        [Test]
        public void RemoteExpressionEvaluation()
        {
            Assert.That(17, Is.EqualTo(Mongo.DefaultDatabase.Evaluate("return 17")));
            Assert.That(18, Is.EqualTo(Mongo.DefaultDatabase.Evaluate("function(test){ return 17 + test; }", 1)));
            Assert.That(5, Is.EqualTo(Mongo.DefaultDatabase.Evaluate("function(a,b){ return a + b; }", 2, 3)));
        }

        //TODO:LastError/PrevError require transaction support
        [Test]
        public void LastError()
        {

            Mongo.DefaultDatabase.ResetError();
            Assert.That(Mongo.DefaultDatabase.GetLastError().ErrorMessage, Is.Null);

            Mongo.DefaultDatabase.ForceError();

            Assert.That(Mongo.DefaultDatabase.GetLastError().ErrorMessage, Is.Not.Null);

            Mongo.DefaultDatabase.ResetError();
            Assert.That(Mongo.DefaultDatabase.GetLastError().ErrorMessage, Is.Null);
        }

        [Test]
        public void PrevError()
        {

            Mongo.DefaultDatabase.ResetError();

            Assert.IsTrue(Mongo.DefaultDatabase.GetLastError().ErrorMessage == null);
            Assert.IsTrue(Mongo.DefaultDatabase.GetPreviousError().ErrorMessage == null);

            Mongo.DefaultDatabase.ForceError();

            Assert.IsTrue(Mongo.DefaultDatabase.GetLastError().ErrorMessage != null);
            Assert.IsTrue(Mongo.DefaultDatabase.GetPreviousError().ErrorMessage != null);

            Mongo.DefaultDatabase.GetCollection("misc").Insert(new Document("foo", 1));

            Assert.IsTrue(Mongo.DefaultDatabase.GetLastError().ErrorMessage == null);
            Assert.IsTrue(Mongo.DefaultDatabase.GetPreviousError().ErrorMessage != null);

            Mongo.DefaultDatabase.ResetError();

            Assert.IsTrue(Mongo.DefaultDatabase.GetLastError().ErrorMessage == null);
            Assert.IsTrue(Mongo.DefaultDatabase.GetPreviousError().ErrorMessage == null);
        }

        [Test]
        public void CollectionExists()
        {
            IDBCollection coll = Mongo.DefaultDatabase["test"];
            coll.Drop();
            Assert.IsFalse(Mongo.DefaultDatabase.CollectionExists(coll.Uri));
            coll = Mongo.DefaultDatabase.CreateCollection("test");
            Assert.IsTrue(Mongo.DefaultDatabase.CollectionExists(coll.Uri));
        }

        [Test]
        public void ReadOnly()
        {
            //Make sure this collection doesn't exist
            IDBCollection testWritable = Mongo.DefaultDatabase["test"];
            testWritable.Drop();

            Assert.That(Mongo.ReadOnlyDefaultDatabase.ReadOnly, Is.True, "Database.Read");

            Assert.That(()=>Mongo.ReadOnlyDefaultDatabase.AddUser("test", new char[] {'g','o'}), 
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase.Drop(),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase.CreateCollection("test"),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase.GetCollection("test"),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase["test"],
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.DefaultServer.Admin.CopyDatabase(Mongo.DefaultDatabase, Mongo.ReadOnlyDefaultDatabase),
                Throws.InstanceOf<ReadOnlyException>());

            Assert.That(() => Mongo.ReadOnlyDefaultDatabase.AddUser("test", new char[] { 'g', 'o' }),
                Throws.InstanceOf<ReadOnlyException>());

        }
    }
}