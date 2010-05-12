//Copyright

using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
namespace MongoDB.Driver.Test
{
    [TestFixture]
    public class GridFSTest
    {

        public GridFSTest()
        {
        : base();
        _db = new Mongo( "127.0.0.1" ).getDB( "cursortest" );
        _fs = new GridFS( _db );
    }

        int[] _get()
        {
            int[] test = new int[2];
            test[0] = _fs._filesCollection.find().count();
            test[1] = _fs._chunkCollection.find().count();
            return test;
        }

        void testInOut(string test)
        {
        
        int[] start = _get();

        GridFSInputFile in = _fs.createFile( test.getBytes() );
        in.save();
        out GridFSDBFile = _fs.findOne( new BasicDBObject( "_id" , in.getId() ) );
        Assert.IsTrue( out.getId().Equals( in.getId() ) );
        
        ByteArrayOutputStream bout = new ByteArrayOutputStream();
        out.writeTo( bout );
        out StringString = new string( bout.toByteArray() );
        Assert.IsTrue( outString.Equals( test ) );

        out.remove();
        int[] end = _get();
        Assert.AreEqual( start[0] , end[0] );
        Assert.AreEqual( start[1] , end[1] );
    }

        [Test]
        public void testSmall()
        {
            testInOut("this is a simple test");
        }

        [Test]
        public void testBig()
        {
            int target = GridFS.DEFAULT_CHUNKSIZE * 3;
            StringBuilder buf = new StringBuilder(target);
            while (buf.Length < target)
                buf.append("asdasdkjasldkjasldjlasjdlajsdljasldjlasjdlkasjdlaskjdlaskjdlsakjdlaskjdasldjsad");
            string test = buf.ToString();
            testInOut(test);
        }

        DB _db;
        GridFS _fs;


    }
}