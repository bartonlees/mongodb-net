//COPYRIGHT

namespace MongoDB.Driver
{
    /// <summary>
    /// A Wrapper for a reference to another object
    /// </summary>
    public class DBRef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBRef"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The id.</param>
        public DBRef(IDBCollection collection, object id)
        {
            Collection = collection;
            ID = id;
        }

        private IDocument _FetchResult = null;
        /// <summary>
        /// Fetches the referenced Document
        /// </summary>
        /// <returns></returns>
        public IDocument Fetch()
        {
            if (_FetchResult == null)
            {
                _FetchResult = Collection.FindByID(ID);
            }
            return _FetchResult;
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public object ID { get; private set; }

        /// <summary>
        /// Gets the foreign collection.
        /// </summary>
        /// <value>The collection.</value>
        public IDBCollection Collection { get; private set; }
    }
}