//COPYRIGHT

namespace MongoDB.Driver
{
    /// <summary>
    /// Type to hold a BSON symbol object
    /// </summary>
    public class DBSymbol
    {
        public string Symbol { get; private set;}

        public DBSymbol(string s)
        {
            Symbol = s;
        }
    }
}