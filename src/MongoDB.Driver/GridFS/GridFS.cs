//COPYRIGHT

using System.Collections.Generic;
namespace MongoDB.Driver.GridFS
{

    /**
     *  Implementation of GridFS v1.0
     *
     *  <a href="http://www.mongodb.org/display/DOCS/GridFS+Specification">GridFS 1.0 spec</a>
     */
    public class GridFS
    {

        public static int DEFAULT_CHUNKSIZE = 256 * 1024;
        public static string DEFAULT_BUCKET = "fs";

        // --------------------------
        // ------ constructors -------
        // --------------------------

        /**
         * Creates a GridFS instance for the default bucket "fs"
         * in the given database.
         *
         * @param db database to work with
         */
        public GridFS(DB db)
            : this(db, DEFAULT_BUCKET)
        {
        }

        /**
         * Creates a GridFS instance for the specified bucket
         * in the given database.
         *
         * @param db database to work with
         * @param bucket bucket to use in the given database
         */
        public GridFS(DB db, string bucket)
        {
            _db = db;
            _bucketName = bucket;

            _filesCollection = _db.getCollection(_bucketName + ".files");
            _chunkCollection = _db.getCollection(_bucketName + ".chunks");

            _chunkCollection.ensureIndex(BasicDBObjectBuilder.start().Add("files_id", 1).Add("n", 1).get());

            _filesCollection.setObjectClass(typeof(GridFSDBFile));
        }


        // --------------------------
        // ------ utils       -------
        // --------------------------


        /**
         *   Returns a cursor for this filestore
         *
         * @return cursor of file objects
         */
        public DBCursor getFileList()
        {
            return _filesCollection.find().sort(new BasicDBObject("filename", 1));
        }

        /**
         *   Returns a cursor for this filestore
         *
         * @param query filter to apply
         * @return cursor of file objects
         */
        public DBCursor getFileList(DBObject query)
        {
            return _filesCollection.find(query).sort(new BasicDBObject("filename", 1));
        }


        // --------------------------
        // ------ reading     -------
        // --------------------------

        public GridFSDBFile find(Oid id)
        {
            return findOne(id);
        }
        public GridFSDBFile findOne(Oid id)
        {
            return findOne(new BasicDBObject("_id", id));
        }
        public GridFSDBFile findOne(string filename)
        {
            return findOne(new BasicDBObject("filename", filename));
        }
        public GridFSDBFile findOne(DBObject query)
        {
            return _fix(_filesCollection.findOne(query));
        }

        public List<GridFSDBFile> find(string filename)
        {
            return find(new BasicDBObject("filename", filename));
        }
        public List<GridFSDBFile> find(DBObject query)
        {
            List<GridFSDBFile> files = new List<GridFSDBFile>();

            DBCursor c = _filesCollection.find(query);
            while (c.hasNext())
            {
                files.Add(_fix(c.next()));
            }
            return files;
        }

        private GridFSDBFile _fix(object o)
        {
            if (o == null)
                return null;

            if (!(o is GridFSDBFile))
                throw new Exception("somehow didn't get a GridFSDBFile");

            GridFSDBFile f = (GridFSDBFile)o;
            f._fs = this;
            return f;
        }


        // --------------------------
        // ------ remove      -------
        // --------------------------

        public void remove(Oid id)
        {
            _filesCollection.remove(new BasicDBObject("_id", id));
            _chunkCollection.remove(new BasicDBObject("files_id", id));
        }

        public void remove(string filename)
        {
            remove(new BasicDBObject("filename", filename));
        }

        public void remove(DBObject query)
        {
            foreach (GridFSDBFile f in find(query))
            {
                f.remove();
            }
        }


        // --------------------------
        // ------ writing     -------
        // --------------------------

        /**
         * after calling this method, you have to call save() on the GridFSInputFile file
         */
        public GridFSInputFile createFile(byte[] data)
        {
            return createFile(new ByteArrayInputStream(data));
        }


        /**
         * after calling this method, you have to call save() on the GridFSInputFile file
         */
        public GridFSInputFile createFile(File f)
        {
            return createFile(new FileInputStream(f), f.getName());
        }

        /**
         * after calling this method, you have to call save() on the GridFSInputFile file
         */
        public GridFSInputFile createFile(InputStream inStream)
        {
            return createFile(inStream, null);
        }

        /**
         * after calling this method, you have to call save() on the GridFSInputFile file
         * on that, you can call setFilename, setContentType and control meta data by modifying the 
         *   result of getMetaData
         */
        public GridFSInputFile createFile(InputStream inStream, string filename)
        {
            return new GridFSInputFile(this, inStream, filename);
        }




        // --------------------------
        // ------ members     -------
        // --------------------------

        public string getBucketName()
        {
            return _bucketName;
        }

        public DB getDB()
        {
            return _db;
        }

        protected internal DB _db;
        protected internal string _bucketName;
        protected internal DBCollection _filesCollection;
        protected internal DBCollection _chunkCollection;

    }
}