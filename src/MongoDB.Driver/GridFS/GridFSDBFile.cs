//COPYRIGHT

using System.IO;
using System;
namespace MongoDB.Driver.GridFS
{
    public class GridFSDBFile : GridFSFile
    {
        public FileStream getInputStream()
        {
            return new MyInputStream();
        }

        public long writeTo(string filename)
        {
            return writeTo(new FileInfo(filename));
        }
        public long writeTo(FileInfo f)
        {
            return writeTo(f.Open(FileMode.Create));
        }

        public long writeTo(FileStream outputStream)
        {
            int nc = numChunks();
            for (int i = 0; i < nc; i++)
            {
                byte[] chunk = getChunk(i);
                outputStream.Write(chunk, 0, chunk.Length);
            }
            return _length;
        }

        byte[] getChunk(int i)
        {
            if (_fs == null)
                throw new Exception("no gridfs!");

            DBObject chunk = _fs._chunkCollection.findOne(BasicDBObjectBuilder.start("files_id", _id)
                                                           .Add("n", i).get());
            if (chunk == null)
                throw new MongoException("can't find a chunk!  file id: " + _id + " chunk: " + i);

            return (byte[])chunk.get("data");
        }

        class MyInputStream : FileStream
        {
            MyInputStream()
            {
                _numChunks = numChunks();
            }

            public int available()
            {
                if (_data == null)
                    return 0;
                return _data.length - _offset;
            }

            public void close()
            {
            }

            public void mark(int readlimit)
            {
                throw new Exception("mark not supported");
            }
            public void reset()
            {
                throw new Exception("mark not supported");
            }
            public bool markSupported()
            {
                return false;
            }

            public int read()
        {
            byte b[] = new byte[1];
            int res = read( b );
            if ( res < 0 )
                return -1;
            return b[0] & 0xFF;
        }

            public int read(byte[] b)
            {
                return read(b, 0, b.Length);
            }
            public int read(byte[] b, int off, int len)
            {

                if (_data == null || _offset >= _data.length)
                {

                    if (_nextChunk >= _numChunks)
                        return -1;

                    _data = getChunk(_nextChunk);
                    _offset = 0;
                    _nextChunk++;
                }

                int r = Math.min(len, _data.length - _offset);
                System.arraycopy(_data, _offset, b, off, r);
                _offset += r;
                return r;
            }

            internal int _numChunks;

            int _nextChunk = 0;
            int _offset;
            byte[] _data = null;
        }

        void remove()
        {
            _fs._filesCollection.remove(new BasicDBObject("_id", _id));
            _fs._chunkCollection.remove(new BasicDBObject("files_id", _id));
        }
    }
}