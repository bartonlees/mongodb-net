using System;

namespace MongoDB.Driver
{
    internal class DBIndex : IDBIndex
    {
        /// <summary>
        /// Gets or sets the key field set.
        /// </summary>
        /// <value>The key field set.</value>
        public DBFieldSet KeyFieldSet { get; private set; }
        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri { get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DBIndex"/> is unique.
        /// </summary>
        /// <value><c>true</c> if unique; otherwise, <c>false</c>.</value>
        public bool Unique { get; private set; }
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        /// <value>The collection.</value>
        public IDBCollection Collection { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DBIndex"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="indexUri">The index URI.</param>
        /// <param name="indexKeyFieldSet">The index key field set.</param>
        /// <param name="unique">if set to <c>true</c> [unique].</param>
        public DBIndex(DBCollection collection, Uri indexUri, DBFieldSet indexKeyFieldSet, bool unique)
        {
            Collection = collection;
            Uri relative = indexUri.IsAbsoluteUri ? indexUri.MakeRelativeUri(collection.Uri) : indexUri;
            Uri = new Uri(new Uri(collection.Uri.ToString() + "/"), relative);
            KeyFieldSet = indexKeyFieldSet;
            Unique = unique;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return Uri.GetIndexName(); }
        }
    }
}
