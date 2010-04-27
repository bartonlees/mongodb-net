using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MongoDB.Driver
{
    public interface IDBCursor : IEnumerable<IDocument>, IDisposable
    {
        long? CursorID { get; set; }
        bool HasMore { get; }
        DBCursorOptions Options { get; }
        IDBCursor Copy();
    }

    public interface IDBCursor<TDoc> : IDBCursor where TDoc : class, IDocument
    {
        IEnumerable<TDoc> DocumentsT { get; }
    }

    
}
