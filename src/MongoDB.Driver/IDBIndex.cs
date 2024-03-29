﻿using System;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents an index on an <see cref="IDBCollection"/>
    /// </summary>
    public interface IDBIndex : IUriComparable
    {
        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>The collection.</value>
        IDBCollection Collection { get; }
        /// <summary>
        /// Gets the key field set.
        /// </summary>
        /// <value>The key field set.</value>
        DBFieldSet KeyFieldSet { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }
        /// <summary>
        /// Gets a value indicating whether this <see cref="IDBIndex"/> is unique.
        /// </summary>
        /// <value><c>true</c> if unique; otherwise, <c>false</c>.</value>
        bool Unique { get; }
    }
}
