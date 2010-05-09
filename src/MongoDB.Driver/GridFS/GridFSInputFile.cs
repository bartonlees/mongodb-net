//COPYRIGHT

using System.IO;
using System;
namespace MongoDB.Driver.GridFS
{


    public class GridFSInputFile : GridFSFile
    {

        GridFSInputFile(GridFS fs, Stream inStream, string filename)
        {
            _fs = fs;
            _in = inStream;

            _filename = filename;

            _id = new Oid();
            _chunkSize = GridFS.DEFAULT_CHUNKSIZE;
            _uploadDate = new DateTime();
        }

        public DBObject getMetaData()
        {
            if (_metadata == null)
                _metadata = new BasicDBObject();
            return _metadata;
        }

        public void setFilename(string fn)
        {
            _filename = fn;
        }

        public void setContentType(string ct)
        {
            _contentType = ct;
        }

        public void save()
        {
            if (!_saved)
            {
                try
                {
                    saveChunks();
                }
                catch (IOException ioe)
                {
                    throw new MongoException("couldn't save chunks", ioe);
                }
            }
            base.save();
        }

        public int saveChunks()
        {
        if ( _saved )
            throw new Exception( "already saved!" );
        
        byte[] b = new byte[GridFS.DEFAULT_CHUNKSIZE];

        long total = 0;
        int cn = 0;
        
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        
        BinaryReader reader = new BinaryReader( _in);
        
        while ( true )
        {
            int start =0;
            
            while ( start < b.Length )
            {
                int r = reader.Read( b , start , b.Length - start );
                if ( r == 0 )
                    throw new Exception( "i'm doing something wrong" );
                if ( r < 0 )
                    break;
                start += r;
            }
            
            total += start;
            
            byte[] mine = b;
            
            if ( start != b.Length )
            {
                mine = new byte[start];
                Array.ConstrainedCopy( b , 0 , mine , 0 , start );
            }

            DBObject chunk = BasicDBObjectBuilder.start()
                .Add( "files_id" , _id )
                .Add( "n" , cn++ )
                .Add( "data" , mine )
                .Value;
            
            _fs._chunkCollection.save( chunk );
            
            if ( start < b.Length )
            {
                x.TransformFinalBlock(b, 0, b.Length);
                break;
            }
            else
            {
                x.TransformBlock(b, 0, b.Length, b, 0)
            }
        }
        _md5 = Util.toHex(x.Hash);
        _length = total;
        _saved = true;
        return cn;
    }

        internal Stream _in;
        bool _saved = false;
    }
}
