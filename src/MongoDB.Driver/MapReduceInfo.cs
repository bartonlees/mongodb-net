//COPYRIGHT

namespace MongoDB.Driver
{

    /// <summary>
    /// Details of a MapReduce operation
    /// </summary>
    public class MapReduceInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapReduceInfo"/> class.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="raw">The raw.</param>
        public MapReduceInfo(IDBCollection from, DBObject raw)
        {
            ResultingCollection = from.Database.GetCollection(raw.GetAsString("result"));
            Counts = (IDocument)raw["counts"];
        }

        /// <summary>
        /// Gets or sets the resulting collection.
        /// </summary>
        /// <value>The resulting collection.</value>
        public IDBCollection ResultingCollection { get; private set; }

        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>The counts.</value>
        public IDocument Counts { get; private set; }
    }
}