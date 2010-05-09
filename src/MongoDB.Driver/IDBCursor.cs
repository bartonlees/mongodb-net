using System;
using System.Collections.Generic;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents an unfinished query result from the server
    /// </summary>
    public interface IDBCursor : IEnumerable<IDocument>, IDisposable
    {
        /// <summary>
        /// Gets or sets the cursor ID.
        /// </summary>
        /// <value>The cursor ID.</value>
        long? CursorID { get; set; }
        /// <summary>
        /// Gets a value indicating whether this instance has more.
        /// </summary>
        /// <value><c>true</c> if this instance has more; otherwise, <c>false</c>.</value>
        bool HasMore { get; }
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        DBCursorOptions Options { get; }
        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <returns></returns>
        IDBCursor Copy();
    }

    /// <summary>
    /// Represents a strongly typed, unfinished query result from the server
    /// </summary>
    /// <typeparam name="TDoc">The type of the doc.</typeparam>
    public interface IDBCursor<TDoc> : IDBCursor where TDoc : class, IDocument
    {
        /// <summary>
        /// Gets the documents T.
        /// </summary>
        /// <value>The documents T.</value>
        IEnumerable<TDoc> DocumentsT { get; }
    }


}
