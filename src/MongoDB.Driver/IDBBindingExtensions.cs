using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    /// <summary>
    /// Extension methods for the IDBBinding interface
    /// </summary>
    public static class IDBBindingExtensions
    {
        /// <summary>
        /// Gets the sister binding using a database name.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="dbName">Name of the db.</param>
        /// <returns></returns>
        public static IDBBinding GetSisterBinding(this IDBBinding binding, string dbName)
        {
            return binding.GetSisterBinding(new Uri(dbName, UriKind.Relative));
        }
    }
}
