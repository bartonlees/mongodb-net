using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents an object whose uniqueness can be determined by a Uri parameter
    /// </summary>
    public interface IUriComparable
    {
        /// <summary>
        /// Gets the URI for this instance.
        /// </summary>
        /// <value>The URI.</value>
        Uri Uri { get; }
    }

    /// <summary>
    /// An equality comparer that investigates the Uri associated with an object
    /// </summary>
    public class UriEqualityComparer<T> : IEqualityComparer<T> where T:IUriComparable
    {
        /// <summary>
        /// Tests for equality between two instances of IUriComparable interfaces
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public bool Equals(T x, T y)
        {
            return x.Uri == y.Uri;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(T obj)
        {
            return obj.Uri.GetHashCode();
        }
    }
}
