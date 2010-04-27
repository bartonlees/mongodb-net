//COPYRIGHT

using System.Collections.Generic;
using System;
namespace MongoDB.Driver.GridFS {


public abstract class GridFSFile : DBObject {

    
    // ------------------------------
    // --------- db           -------
    // ------------------------------

    public void save(){
        if ( _fs == null )
            throw new MongoException( "need _fs" );
        _fs._filesCollection.save( this );
    }

    public void validate(){
        if ( _fs == null )
            throw new MongoException( "no _fs" );
        if ( _md5 == null )
            throw new MongoException( "no _md5 stored" );
        
        DBObject res = _fs._db.command( new BasicDBObject( "filemd5" , _id ) );
        string m = res.get( "md5" ).ToString();
        if ( m.Equals( _md5 ) )
            return;

        throw new MongoException( "md5 differ.  mine [" + _md5 + "] theirs [" + m + "]" );
    }

    public int numChunks(){
        double d = _length;
        d = d / _chunkSize;
        return (int)Math.ceil( d );
    }

    // ------------------------------
    // --------- getters      -------
    // ------------------------------


    public object getId(){
        return _id;
    }

    public string getFilename(){
        return _filename;
    }

    public string getContentType(){
        return _contentType;
    }

    public long getLength(){
        return _length;
    }
    
    public long getChunkSize(){
        return _chunkSize;
    }
    
    public DateTime getUploadDate(){
        return _uploadDate;
    }

    public List<string> getAliases(){
        return _aliases;
    }

    public DBObject getMetaData(){
        return _metadata;
    }
    
    public string getMD5(){
        return _md5;
    }

    // ------------------------------
    // --------- DBOBject methods ---
    // ------------------------------
    
    public object put( string key , object v ){
        if ( key == null )
            throw new Exception( "key should never be null" );
        else if ( key.Equals( "_id" ) )
            _id = v;
        else if ( key.Equals( "_ns"  ) );
        else if ( key.Equals( "filename" ) )
            _filename = v == null ? null : v.ToString();
        else if ( key.Equals( "contentType" ) )
            _contentType = (string)v;
        else if ( key.Equals( "length" ) )
            _length = ((Number)v).longValue();
        else if ( key.Equals( "chunkSize" ) )
            _chunkSize = ((Number)v).longValue();
        else if ( key.Equals( "uploadDate" ) )
            _uploadDate = (DateTime)v;
        else if ( key.Equals( "metadata" ) )
            _metadata = (DBObject)v;
        else if ( key.Equals( "md5" ) )
            _md5 = (string)v;
        else if ( key.Equals( "aliases" ) ){
            if ( v != null ){
                throw new MongoException( "can't handle aliases yet" );
            }
        }
        else 
            throw new MongoException( "GridFSFile don't know about key [" + key + "] converting to metadata " );
        return v;
    }

    public object get( string key ){
        if ( key == null )
            throw new Exception( "key should never be null" );
        else if ( key.Equals( "_id" ) )
            return _id;
        else if ( key.Equals( "filename" ) )
            return _filename;
        else if ( key.Equals( "contentType" ) )
            return _contentType;
        else if ( key.Equals( "length" ) )
            return _length;
        else if ( key.Equals( "chunkSize" ) )
            return _chunkSize;
        else if ( key.Equals( "uploadDate" ) )
            return _uploadDate;
        else if ( key.Equals( "metadata" ) )
            return _metadata;
        else if ( key.Equals( "md5" ) )
            return _md5;
        

        return null;
    }


    public void putAll( DBObject o ){
        throw new NotSupportedException();
    }
    public void putAll( Map m ){
        throw new NotSupportedException();
    }
    public Map toMap(){
        throw new NotSupportedException();
    }
    public object removeField( string key ){
        throw new NotSupportedException();
    }

    public bool containsKey( string s ){
        return ContainsKey( s );
    }
    public bool ContainsKey(string s){
        return VALID_FIELDS.Contains( s );
    }

    public Set<string> keySet(){
        return VALID_FIELDS;
    }

    public bool isPartialObject(){
        return false;
    }
    public void markAsPartialObject(){
        throw new Exception( "can't load partial GridFSFile file" );
    }
    
    // ----------------------
    // ------- fields -------
    // ----------------------

    public override string ToString(){
        return JSON.serialize( this );
    }

    protected void setGridFS( GridFS fs ){
        _fs = fs;
    }

    protected GridFS _fs = null;

    internal object _id { get; set;};
    protected string _filename;
    protected string _contentType;
    protected long _length;
    protected long _chunkSize;
    protected DateTime _uploadDate;
    protected List<string> _aliases;
    protected DBObject _metadata;
    protected string _md5;

    internal static Set<string> VALID_FIELDS = Collections.unmodifiableSet( new HashSet( Arrays.asList( new string[]{ 
                    "_id" , "filename" , "contentType" , "length" , "chunkSize" , 
                    "uploadDate" , "aliases" , "metadata" , "md5" 
                } ) ) );
}
}