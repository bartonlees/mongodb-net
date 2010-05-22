
namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a unit of JavaScript code
    /// </summary>
    public class DBCode
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DBCode"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public DBCode(string code)
        {
            Code = code;
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Code;
        }
    }
}
