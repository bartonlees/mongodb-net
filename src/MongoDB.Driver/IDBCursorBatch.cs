using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MongoDB.Driver
{
    public interface IDBCursorBatch : IEnumerable<IDocument>
    {
        int Index { get; }
    }

    public interface IDBCursorBatch<TDoc> : IDBCursorBatch where TDoc : class, IDocument
    {
    }
}
