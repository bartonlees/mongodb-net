using System;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// Bitwise Cursor option flags
    /// </summary>
    [Flags]
    public enum CursorFlags
    {
        /// <summary>
        /// No flags are specified
        /// </summary>
        None = 0,
        /// <summary>
        /// Tailable Cursor
        /// </summary>
        TailableCursor = 2,
        /// <summary>
        /// Whether or not connecting to a Slave is OK
        /// </summary>
        SlaveOK = 4,
        /// <summary>
        /// Oplog replay: 8 (internal replication use only - drivers should not implement)
        /// </summary>
        NoCursorTimeout = 16
    }

    /// <summary>
    /// 
    /// </summary>
    public class DBCursorOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBCursorOptions"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="returnFields">The return fields.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="numberToSkip">The number to skip.</param>
        /// <param name="numberToReturn">The number to return.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="explain">if set to <c>true</c> [explain].</param>
        /// <param name="snapshot">if set to <c>true</c> [snapshot].</param>
        /// <param name="options">The options.</param>
        /// <param name="explicitIndexHint">The explicit index hint.</param>
        public DBCursorOptions(IDBCollection collection,
            DBQuery selector = null,
            DBFieldSet returnFields = null,
            DBFieldSet orderBy = null,
            int? numberToSkip = null,
            int? numberToReturn = null,
            int? limit = null,
            bool explain = false,
            bool snapshot = false,
            CursorFlags options = CursorFlags.None,
            IDBIndex explicitIndexHint = null)
        {
            Condition.Requires(snapshot, "snapshot")
                .Evaluate(!(snapshot && explicitIndexHint != null), "Snapshot is not allowed when there is an explicit hint")
                .Evaluate(!(snapshot && orderBy != null), "Snapshot is not allowed when there field set to order by");
            Condition.Requires(numberToReturn, "numberToReturn")
                .Evaluate(!(numberToReturn.HasValue && limit.HasValue), "You may not specify both numberToReturn AND limit. They are ways to set a common property. Choose one to set.");

            Collection = collection;
            Selector = selector ?? DBQuery.SelectAll;
            ReturnFields = returnFields;
            Explain = explain;
            Flags = options;
            Hint = explicitIndexHint;
            OrderBy = orderBy;
            Snapshot = snapshot;

            if (numberToSkip.HasValue)
                NumberToSkip = numberToSkip;
            if (numberToReturn.HasValue)
                NumberToReturn = numberToReturn.Value;
            if (limit.HasValue)
                Limit = limit;


            //            _addToQueryObject(foo, "query", Selector, true);
            //            _addToQueryObject(foo, "orderby", OrderByFieldSet, false);
            //            _addToQueryObject(foo, "$hint", _hint);
            //            if (_explain)
            //                foo["$explain"] = true;
            //            if (_snapshot)
            //                foo["$snapshot"] = true;


        }

        /// <summary>
        /// Gets or sets the number of documents to return. If set to 0, then the default number is used. If set to a negative number n, exactly |n| documents will be returned. If set to a positive number p, then p or fewer documents will be returned (depending on the number available). If there are more than p available, only p will be sent in the first batch, and a cursor will be left open. Otherwise the cursor will be closed after sending all documents.
        /// </summary>
        /// <value>number of documents to return in the first OP_REPLY.</value>
        public int NumberToReturn { get; private set; }
        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        public int? Limit
        {
            get
            {
                return NumberToReturn >= 0 ? (int?)null : (int?)-NumberToReturn;
            }
            internal set
            {
                if (value.HasValue)
                    NumberToReturn = -Math.Abs(value.Value);
                else
                    NumberToReturn = 0;
            }
        }
        /// <summary>
        /// Gets or sets the number to skip.
        /// </summary>
        /// <value>number of documents to skip when returning results.</value>
        public int? NumberToSkip { get; private set; }
        /// <summary>
        /// Gets or sets the hint.
        /// </summary>
        /// <value>The hint.</value>
        public IDBIndex Hint { get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DBCursorOptions"/> is explain.
        /// </summary>
        /// <value><c>true</c> if explain; otherwise, <c>false</c>.</value>
        public bool Explain { get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DBCursorOptions"/> is snapshot.
        /// </summary>
        /// <value><c>true</c> if snapshot; otherwise, <c>false</c>.</value>
        public bool Snapshot { get; private set; }
        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>The flags.</value>
        public CursorFlags Flags { get; private set; }
        /// <summary>
        /// Gets or sets the return fields.
        /// </summary>
        /// <value>The return fields.</value>
        public DBFieldSet ReturnFields { get; private set; }
        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>The order by.</value>
        public DBFieldSet OrderBy { get; private set; }
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        /// <value>The collection.</value>
        public IDBCollection Collection { get; private set; }
        /// <summary>
        /// Gets or sets the selector.
        /// </summary>
        /// <value>The selector.</value>
        public DBQuery Selector { get; private set; }
    }
}
