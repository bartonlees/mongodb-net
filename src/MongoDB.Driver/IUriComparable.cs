using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents and object whose uniqueness can be determined by a Uri parameter
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
        public bool Equals(T x, T y)
        {
            return x.Uri == y.Uri;
        }

        public int GetHashCode(T obj)
        {
            return obj.Uri.GetHashCode();
        }
    }
}
