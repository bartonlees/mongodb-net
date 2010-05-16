
using System;
namespace MongoDB.Driver
{
    /// <summary>
    /// Extension methods for the <see cref="IServerBinding"/> interface
    /// </summary>
    public static class IServerBindingExtensions
    {
        /// <summary>
        /// Gets the <see cref="IDBBinding"/>
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="uri">Either a fully qualified URI, or the db name</param>
        /// <returns>a binding for the URI</returns>
        public static IDBBinding GetDBBinding(this IServerBinding binding, string uriString)
        {
            Uri uri;
            if (Uri.TryCreate(uriString, UriKind.Absolute, out uri))
            {
                return binding.GetDBBinding(uri);
            }
            return binding.GetDBBinding(new Uri(binding.Uri, uriString));
        }
    }
}
