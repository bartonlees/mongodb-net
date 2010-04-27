using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    internal class DBIndex : IDBIndex
    {
        public DBFieldSet KeyFieldSet { get; private set;}
        public Uri Uri{ get; private set;}
        public bool Unique { get; private set; }
        public IDBCollection Collection { get; private set; }
        public DBIndex(DBCollection collection, Uri indexUri, DBFieldSet indexKeyFieldSet, bool unique)
        {
            Collection = collection;
            Uri relative = indexUri.IsAbsoluteUri ? indexUri.MakeRelativeUri(collection.Uri) : indexUri;
            Uri = new Uri(new Uri(collection.Uri.ToString() + "/"), relative);
            KeyFieldSet = indexKeyFieldSet;
            Unique = unique;
        }

        public string Name
        {
            get { return Uri.GetIndexName(); }
        }
    }
}
