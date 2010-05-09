//COPYRIGHT
using System;
namespace MongoDB.Driver
{


    /// <summary>
    /// Use Regex for regular expressions. DEPRECATED
    /// </summary>
    [Obsolete]
    public class DBRegex
    {
        public string Pattern { get; private set;}
        private string _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBRegex"/> class.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="o">The o.</param>
        public DBRegex(string p, string o)
        {
            Pattern = p;
            _options = o;
        }

        /// <summary>
        /// Gets the pattern.
        /// </summary>
        /// <returns></returns>
        public string GetPattern()
        {
            return Pattern;
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <returns></returns>
        public string GetOptions()
        {
            return _options ?? "";
        }
    }
}