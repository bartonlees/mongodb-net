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
        Uri Uri { get; }
    }

    /// <summary>
    /// An equality comparer that investigates the Uri associated with an object
    /// </summary>
    public class UriEqualityComparer : IEqualityComparer<IUriComparable>
    {

        public bool Equals(IUriComparable x, IUriComparable y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(IUriComparable obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
