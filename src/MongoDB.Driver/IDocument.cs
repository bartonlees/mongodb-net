using System;
using System.Linq;
using MongoDB.Driver.Platform.Conditions;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents the life cycle state of an <see cref="IDocument"/>
    /// </summary>
    [Flags]
    public enum DocumentState
    {
        /// <summary>
        /// The document state is undefined
        /// </summary>
        None = 0,
        
        /// <summary>
        /// The row has been created but is not part of a collection.
        /// </summary>
        /// <remarks>
        /// An <see cref="IDocument"/> is in this state immediately after it has been created
        ///     and before it is added to a collection, or if it has been removed from a
        ///     collection.
        /// </remarks>
        Detached = 1,

        /// <summary>
        /// This <see cref="IDocument"/> has not changed since it was last retrieved from or saved to its collection
        /// </summary>
        Unchanged = 2,
        
        /// <summary>
        /// This <see cref="IDocument"/> has been added but not yet pushed to a remote collection
        /// </summary>
        Added = 4,
        
        /// <summary>
        /// This <see cref="IDocument"/> has been deleted from its collection and marked deleted locally
        /// </summary>
        Deleted = 8,
        
        /// <summary>
        /// This attached <see cref="IDocument"/> has been modified and not yet updated back to the database
        /// </summary>
        Modified = 16,
    }

    /// <summary>
    /// Represents a full document that can be sent to or retrieved from a collection on the server
    /// </summary>
    public interface IDocument : IDBObject
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        Oid ID { get; set; }
        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        DocumentState State { get; }
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        /// <value>The collection.</value>
        IDBCollection Collection { get; set; }
        /// <summary>
        /// Gets a value indicating whether this <see cref="IDocument"/> is partial.
        /// </summary>
        /// <value><c>true</c> if partial; otherwise, <c>false</c>.</value>
        bool Partial { get; }
    }

    /// <summary>
    /// Extension methods for <see cref="IDocument"/>
    /// </summary>
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
