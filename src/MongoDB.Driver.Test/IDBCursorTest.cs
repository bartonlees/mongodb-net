//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Text;
using System.Linq;
namespace MongoDB.Driver.Test
{

    [TestFixture]
    public class DBCursorTest
    {
        [Test]
        public void TestEmptyCursor()
        {
            try
            {
                IDBCollection c = Mongo.DefaultDatabase.GetCollection("test");
                c.Drop();

                using (IDBCursor cur = c.GetCursor())
                {
                    List<IDocument> results = new List<IDocument>(cur);
                }


                Assert.AreEqual(c.ToList().Count, 0);

                Document obj = new Document();
                obj["test"] = "foo";
                c.Insert(obj);

                Assert.AreEqual(c.ToList().Count, 1);
            }
            catch (MongoException)
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void Snapshot()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("snapshot1");
            c.Drop();
            for (int test = 0; test < 100; test++)
                c.Save(new Document("test", test));
            Assert.AreEqual(100, c.ToList().Count);
            Assert.AreEqual(100, c.ToArray().Length);
            Assert.AreEqual(100, c.Find(snapshot:true).Count());
            Assert.AreEqual(50, c.Find(snapshot:true,limit:50).Count());
        }

        [Test]
        public void LimitAndNumberToReturn()
        {
            //Note that Find operation uses cursor internally
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("big1");
            c.Drop();

            string bigString;
            {
                StringBuilder buf = new StringBuilder(16000);
                for (int tt = 0; tt < 16000; tt++)
                    buf.Append("test");
                bigString = buf.ToString();
            }

            int collSize = (15 * 1024 * 1024) / bigString.Length;
            int upperThreshold = 800; //A number greater than the collSize
            int lowerThreshold = 10;  //A number less than the collSize

            for (int t = 0; t < collSize; t++)
                c.Save(new Document() { { "best", t }, { "test", bigString } });

            Assert.That(collSize, Is.LessThan(upperThreshold), "verifying collSize < upperThreshold");
            Assert.That(collSize, Is.GreaterThan(lowerThreshold), "verifying collSize > lowerThreshold");

            Assert.That(collSize, Is.EqualTo(c.ToList().Count), "expected count() == collSize from collection enumeration");
            Assert.That(c.Find().Count(), Is.EqualTo(collSize), "expected count() == collSize from default cursor operation");

            Assert.That(c.Find(numberToReturn: upperThreshold).Count(), Is.EqualTo(collSize), "expected count() == collSize regardless of numberToReturn > collSize");
            Assert.That(c.Find(numberToReturn: lowerThreshold).Count(), Is.EqualTo(collSize), "expected count() == collSize regardless of numberToReturn < collSize");
            Assert.That(c.Find(numberToReturn: collSize).Count(), Is.EqualTo(collSize), "expected count() == collSize regardless of numberToReturn == collSize");
            Assert.That(c.Find(numberToReturn: 2).Count(), Is.EqualTo(collSize), "expected count() == collSize when numberToReturn == 2");
            Assert.That(c.Find(numberToReturn: 1).Count(), Is.EqualTo(1), "expected count() == 1 when numberToReturn == 1");

            Assert.That(c.Find(limit: upperThreshold).Count(), Is.EqualTo(66), "expected count() == 66 regardless of limit > collSize");
            Assert.That(c.Find(limit: lowerThreshold).Count(), Is.EqualTo(lowerThreshold), "expected count() == lowerThreshold becase of limit < 66");
            Assert.That(c.Find(limit: collSize).Count(), Is.EqualTo(66), "expected count() == 66 because of limit == collSize");
        }

        [Test]
        public void Explain()
        {
            IDBCollection c = Mongo.DefaultDatabase.GetCollection("explain1");
            c.Drop();

            for (int test = 0; test < 100; test++)
                c.Save(new Document("test", test));

            DBQuery q = new DBQuery("test", new DBQuery("$gt", 50));

            Assert.AreEqual(49, c.Find(q).Count());
            Assert.AreEqual(20, c.Find(q, limit:20).Count());

            c.EnsureIndex(new DBFieldSet("test"));

            Assert.AreEqual(49, c.Find(q).Count());
            Assert.AreEqual(20, c.Find(q, limit:20).Count());

            //Assert.AreEqual(49, c.Find(q, explain:true)["n"]);

            //// these 2 are 'reversed' b/c we want the user case to make sense
            //Assert.AreEqual(20, c.Find(q).limit(20).explain()["n"]);
            //Assert.AreEqual(49, c.Find(q).limit(-20).explain()["n"]);

        }
    }
}