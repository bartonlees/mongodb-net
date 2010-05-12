//COPYRIGHT

namespace MongoDB.Driver
{
    /// <summary>
    /// Type to hold a BSON symbol object
    /// </summary>
    public class DBSymbol
    {
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBSymbol"/> class.
        /// </summary>
        /// <param name="s">The s.</param>
        public DBSymbol(string s)
        {
            Symbol = s;
        }
    }
}