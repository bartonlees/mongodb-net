using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents an unfinished query result from the server
    /// </summary>
    public interface IDBCursor : IEnumerable<IDocument>, IDisposable
    {
        long? CursorID { get; set; }
        bool HasMore { get; }
        DBCursorOptions Options { get; }
        IDBCursor Copy();
    }

    /// <summary>
    /// Represents a strongly typed, unfinished query result from the server
    /// </summary>
    /// <typeparam name="TDoc">The type of the doc.</typeparam>
    public interface IDBCursor<TDoc> : IDBCursor where TDoc : class, IDocument
    {
        IEnumerable<TDoc> DocumentsT { get; }
    }

    
}
