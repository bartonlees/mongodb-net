using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents an index on an collection
    /// </summary>
    public interface IDBIndex
    {
        IDBCollection Collection { get; }
        DBFieldSet KeyFieldSet { get; }
        Uri Uri { get; }
        string Name { get; }
        bool Unique { get; }
    }
}
