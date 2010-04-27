using System;
using System.IO;
using System.Collections.Generic;

namespace MongoDB.Driver.Message
{
    /// <summary>
    /// The OP_KILL_CURSORS message is used to close an active cursor in the database. This is necessary to ensure that database resources are reclaimed at the end of the query.
    /// Note that if a cursor is read until exhausted (read until OP_QUERY or OP_GETMORE returns zero for the cursor id), there is no need to kill the cursor.
    /// </summary>
    internal class KillCursors : Request
    {
        //      struct {
        //          MsgHeader header;                 // standard message header
        //          int32     ZERO;                   // 0 - reserved for future use
        //          int32     numberOfCursorIDs;      // number of cursorIDs in message
        //          int64[]   cursorIDs;                // array of cursorIDs to close
        //      }

        /// <summary>
        /// Gets or sets the cursor IDs.
        /// </summary>
        /// <value>The IDs of the cursors to kill.</value>
        public List<long> CursorIDs { get; private set; }

        public KillCursors()
            : base(Operation.KillCursors)
        {
            CursorIDs = new List<long>();
        }
        public KillCursors(params long[] cursorIDs)
            : base(Operation.KillCursors)
        {
            CursorIDs = new List<long>(cursorIDs);
        }
        public KillCursors(IEnumerable<long> cursorIDs)
            : base(Operation.KillCursors)
        {
            CursorIDs = new List<long>(cursorIDs);
        }

        protected override void WriteBody(WireProtocolWriter writer)
        {
            writer.Write(0);
            writer.Write(this.CursorIDs.Count);
            foreach (long cursorID in CursorIDs)
            {
                writer.Write(cursorID);
            }
        }
    }
}
