using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    [Flags]
    public enum DocumentState
    {
        None = 0,
        // Summary:
        //     The row has been created but is not part of any System.Data.DataRowCollection.
        //     A System.Data.DataRow is in this state immediately after it has been created
        //     and before it is added to a collection, or if it has been removed from a
        //     collection.
        Detached = 1,
        //
        // Summary:
        //     The row has not changed since System.Data.DataRow.AcceptChanges() was last
        //     called.
        Unchanged = 2,
        //
        // Summary:
        //     The row has been added to a System.Data.DataRowCollection, and System.Data.DataRow.AcceptChanges()
        //     has not been called.
        Added = 4,
        //
        // Summary:
        //     The row was deleted using the System.Data.DataRow.Delete() method of the
        //     System.Data.DataRow.
        Deleted = 8,
        //
        // Summary:
        //     The row has been modified and System.Data.DataRow.AcceptChanges() has not
        //     been called.
        Modified = 16,
    }

    public interface IDocument : IDBObject
    {
        Oid ID { get; set; }
        DocumentState State { get; }
        IDBCollection Collection { get; set; }
        bool Partial { get; }
    }

    public static class IDocumentExtensions
    {
        /// <summary>
        /// Checks key strings for invalid characters.
        /// </summary>
        /// <param name="document">The document.</param>
        public static void Validate(this IDocument document)
        {
            Condition.Requires(document, "this")
                .IsNotNull()
                .Evaluate(!document.Keys.Any(k => k.Contains(".") || k.Contains("$")), "Document fields may not include '.' or '$'")
                .Evaluate(!document.Values.Any(i => ((i as IDBObject) != null) && ((i as IDocument) == null)), "Only nested IDocument instances are allowed within an IDocument");

            foreach (IDocument nestedDocument in document.Values.OfType<IDocument>())
                nestedDocument.Validate();
        }
    }
}
