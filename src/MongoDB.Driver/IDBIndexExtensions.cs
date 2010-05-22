//COPYRIGHT

namespace MongoDB.Driver
{
    /// <summary>
    /// Extension methods for <see cref="IDBIndex"/>
    /// </summary>
    public static class IDBIndexExtensions
    {
        /// <summary>
        /// Drops the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        public static void Drop(this IDBIndex index)
        {
            index.Collection.DropIndex(index);
        }
    }
}