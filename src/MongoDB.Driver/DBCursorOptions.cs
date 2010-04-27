using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    [Flags]
    public enum CursorFlags
    {
        None = 0,
        TailableCursor = 2,
        SlaveOK = 4,
        //Oplog replay: 8 (internal replication use only - drivers should not implement)
        NoCursorTimeout = 16
    }

    public class DBCursorOptions
    {
        internal DBCursorOptions(IDBCollection collection,
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
        public IDBIndex Hint { get; private set; }
        public bool Explain { get; private set; }
        public bool Snapshot { get; private set; }
        public CursorFlags Flags { get; private set; }
        public DBFieldSet ReturnFields { get; private set; }
        public DBFieldSet OrderBy { get; private set; }
        public IDBCollection Collection { get; private set; }
        public DBQuery Selector { get; private set; }
    }
}
