using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MongoDB.Driver
{
    internal class DBCursorEnumerator<TDoc> : IEnumerator<IDocument> where TDoc : class, IDocument
    {
        bool disposed = false;
        public DBCursor<TDoc> Cursor { get; private set; }
        IEnumerator<TDoc> _DocumentEnumerator = null;
        public DBCursorEnumerator(DBCursor<TDoc> cursor)
        {
            Cursor = cursor;
        }

        void CheckDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("DBCursorEnumerator");
            }
        }

        public IDocument Current
        {
            get
            {
                CheckDisposed();
                if (_DocumentEnumerator == null)
                    throw new InvalidOperationException();
                return _DocumentEnumerator.Current;
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                if (_DocumentEnumerator != null)
                {
                    _DocumentEnumerator.Dispose();
                    _DocumentEnumerator = null;
                }
            }
        }

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            CheckDisposed();
            if (_DocumentEnumerator == null) //Get a new batch to enumerate if needed
            {
                _DocumentEnumerator = Cursor.Options.Collection.Query<TDoc>(Cursor).GetEnumerator();
            }
            if (!_DocumentEnumerator.MoveNext()) //Can't continue on this batch
            {
                if (Cursor.HasMore) //There are more batches waiting
                {
                    _DocumentEnumerator.Dispose(); //Release the last batch's enumerator
                    _DocumentEnumerator = Cursor.Options.Collection.GetMore<TDoc>(Cursor).GetEnumerator();
                    if (!_DocumentEnumerator.MoveNext()) //Advance to first on new enumerator
                        throw new InvalidOperationException("There shouldn't be an empty MORE response");
                    return true;
                }
                else
                    return false; //No more documents, no more batches
            }
            else //Successfully on to first/next in the batch
            {
                return true;
            }
        }

        public void Reset()
        {
            Debug.Assert(Cursor.CursorID.HasValue && Cursor.CursorID.Value == 0, "Probably leaking the cursor if this happens, investigate");
            Cursor.CursorID = null;
            if (_DocumentEnumerator != null)
                _DocumentEnumerator.Dispose();
            _DocumentEnumerator = null;
        }
    }
}
