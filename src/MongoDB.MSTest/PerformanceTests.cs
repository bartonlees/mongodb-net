//Copyright

using System;
using System.Collections.Generic;
using FluentAssertions;
using System.IO;

namespace MongoDB.Driver.Test
{

    public class PerformanceTests
    {

        public const int batchSize = 100;
        public const double perTrial = 5000;

        public static IDBObject small;
        public static IDBObject medium;
        public static IDBObject large;

        private static void setup()
        {
            small = new DBObject();

            DBObjectArray a = new DBObjectArray();
            a["0"] = "test";
            a["1"] = "benchmark";
            medium = new DBObject() {
                {"integer", 5},
                {"number", 5.05},
                {"bool", false},
                {"array", a},
                };

            DBObjectArray harvest = new DBObjectArray();
            for (int test = 0; test < 20; test++)
            {
                harvest[test * 14 + 0] = "10gen";
                harvest[test * 14 + 1] = "web";
                harvest[test * 14 + 2] = "open";
                harvest[test * 14 + 3] = "source";
                harvest[test * 14 + 4] = "application";
                harvest[test * 14 + 5] = "paas";
                harvest[test * 14 + 6] = "platform-as-a-service";
                harvest[test * 14 + 7] = "technology";
                harvest[test * 14 + 8] = "helps";
                harvest[test * 14 + 9] = "developers";
                harvest[test * 14 + 10] = "focus";
                harvest[test * 14 + 11] = "building";
                harvest[test * 14 + 12] = "mongodb";
                harvest[test * 14 + 13] = "mongo";
            }
            large = new DBObject() 
            {
                {"base_url", "http://www.example.com/test-me"},
                {"total_word_count", 6743},
                {"access_time", new DateTime()},
                {"meta_tags", new DBObject() {
                     {"description", "test am a long description string"},
                     {"author", "Holly Man"},
                     {"dynamically_created_meta_tag", "who know\n what"}}},
                {"page_structure", new DBObject() {
                     {"counted_tags", 3450},
                     {"no_of_js_attached", 10},
                     {"no_of_images", 6}}},
                {"harvested_words", harvest}
            };
        }

        private static IDBCollection getCollection(string name, bool index)
        {
            IDBCollection c;
            if (index)
            {
                c = Mongo.DefaultDatabase.GetCollection(name + "_index");
                c.Drop();
                c.EnsureIndex("test");
            }
            else
            {
                c = Mongo.DefaultDatabase.GetCollection(name);
                c.Drop();
            }
            c.FindOne();
            return c;
        }

        private static void doInserts(IDocument obj, string name, bool index)
        {
            IDBCollection c = getCollection(name, index);

            double start = (double)DateTime.Now.Ticks;
            for (int test = 0; test < perTrial; test++)
            {
                obj["test"] = test;
                c.Insert(obj);
            }
            double total = ((double)DateTime.Now.Ticks) - start;
            int opsPerSec = (int)(perTrial / (total / 1000.0));
            Console.WriteLine(opsPerSec + " ops/sec");
        }

        private static void doInsertFindOnes(IDocument obj, string name, bool index)
        {
            IDBCollection c = getCollection(name, index);

            double start = (double)DateTime.Now.Ticks;
            for (int test = 0; test < perTrial; test++)
            {
                obj["test"] = test;
                c.Insert(obj);
            }
            c.FindOne();
            double total = ((double)DateTime.Now.Ticks) - start;
            int opsPerSec = (int)(perTrial / (total / 1000.0));
            Console.WriteLine(opsPerSec + " ops/sec");
        }

        private static void doFindOnes(string name, bool index)
        {
            IDBCollection c = getCollection(name, index);
            int val = (int)perTrial / 2;

            double start = (double)DateTime.Now.Ticks;
            for (int t = 0; t < perTrial; t++)
            {
                IDBObject result = c.FindOne(Lambda.Query(test => test == val));
            }
            double total = ((double)DateTime.Now.Ticks) - start;
            int opsPerSec = (int)(perTrial / (total / 1000.0));
            Console.WriteLine(opsPerSec + " ops/sec");
        }

        private static void doFinds(string name, bool index)
        {
            IDBCollection c = getCollection(name, index);
            int i = (int)perTrial / 2;

            double start = (double)DateTime.Now.Ticks;
            for (int t = 0; t < perTrial; t++)
            {
                using (IDBCursor cursor = c.GetCursor(Lambda.Query(test => test == i)))
                {
                    foreach (IDBObject obj in cursor)
                    {
                        object o = obj;
                    }
                }
            }
            double total = ((double)DateTime.Now.Ticks) - start;
            int opsPerSec = (int)(perTrial / (total / 1000.0));
            Console.WriteLine(opsPerSec + " ops/sec");
        }

        public static void batchInsert(IDocument obj, string name)
        {
            Console.WriteLine("insert " + name);
            IDBCollection c = getCollection(name, false);

            List<List<IDocument>> batches = new List<List<IDocument>>();
            for (int test = 0; test < perTrial; test++)
            {
                List<IDocument> batch = new List<IDocument>();
                for (int j = 0; j < batchSize; j++)
                {
                    obj["test"] = test;
                    batch.Add(obj);
                    test++;
                }
                batches.Add(batch);
            }
            int batchNum = batches.Count;

            double start = (double)DateTime.Now.Ticks;
            for (int test = 0; test < batchNum; test++)
            {
                c.Insert(batches[test]);
            }
            double total = ((double)DateTime.Now.Ticks) - start;
            int opsPerSec = (int)(perTrial / (total / 1000.0));
            Console.WriteLine(opsPerSec + " ops/sec");
        }

        public static void insertSingle(IDocument obj, string name)
        {
            Console.WriteLine("insert " + name);
            doInserts(obj, name, false);
        }

        public static void insertSingleIndex(IDocument obj, string name)
        {
            Console.WriteLine("insert (index) " + name);
            doInserts(obj, name, true);
        }

        public static void insertSingleFindOne(IDocument obj, string name)
        {
            Console.WriteLine("insert (findOne)" + name);
            doInsertFindOnes(obj, name, false);
        }

        public static void insertSingleIndexFindOne(IDocument obj, string name)
        {
            Console.WriteLine("insert (index/findOne) " + name);
            doInsertFindOnes(obj, name, true);
        }

        public static void findOne(string name)
        {
            Console.WriteLine("findOne " + name);
            doFindOnes(name, false);
        }

        public static void findOneIndex(string name)
        {
            Console.WriteLine("findOne (index) " + name);
            doFindOnes(name, true);
        }

        public static void find(string name)
        {
            Console.WriteLine("find " + name);
            doFinds(name, false);
        }

        public static void findIndex(string name)
        {
            Console.WriteLine("find (index) " + name);
            doFinds(name, true);
        }

        public static void findRange(string name)
        {
            Console.WriteLine("findRange " + name);

            IDBCollection c = getCollection(name, true);
            int min = (int)perTrial / 2;
            int max = (int)perTrial / 2 + batchSize;

            double start = (double)DateTime.Now.Ticks;
            for (int i = 0; i < perTrial; i++)
            {
                using (IDBCursor cursor = c.GetCursor(Lambda.Query(test => test > min && test < max)))
                {
                    foreach (IDBObject dbo in cursor)
                    {
                        IDBObject obj = dbo;
                    }
                }
            }
            double total = ((double)DateTime.Now.Ticks) - start;
            int opsPerSec = (int)(perTrial / (total / 1000.0));
            Console.WriteLine(opsPerSec + " ops/sec");
        }
    }
}