//COPYRIGHT

using System;
using MongoDB.Driver.Platform.Conditions;
namespace MongoDB.Driver
{
    public class DBRef
    {
        public DBRef(IDBCollection collection, object id)
        {
            Collection = collection;
            ID = id;
        }

        private IDocument _FetchResult = null;
        public IDocument Fetch()
        {
            if (_FetchResult == null)
            {
                _FetchResult = Collection.FindByID(ID);
            }
            return _FetchResult; 
        }

        public object ID { get; private set; }
        public IDBCollection Collection { get; private set; }
    }
}