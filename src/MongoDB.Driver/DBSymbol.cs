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
        public string Symbol { get; private set;}

        public DBSymbol(string s)
        {
            Symbol = s;
        }
    }
}