using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MongoDB.Driver
{
    internal class DBCursorEnumerator<TDoc> : IEnumerator<IDocument> where TDoc : class, IDocument
    {
        bool disposed = false;
        /// <summary>
        /// Gets or sets the cursor.
        /// </summary>
        /// <value>The cursor.</value>
        public DBCursor<TDoc> Cursor { get; private set; }
        IEnumerator<TDoc> _DocumentEnumerator = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="DBCursorEnumerator&lt;TDoc&gt;"/> class.
        /// </summary>
        /// <param name="cursor">The cursor.</param>
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

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
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

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
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

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
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
