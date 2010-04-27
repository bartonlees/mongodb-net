//COPYRIGHT

using System.Collections.Generic;
using System;
using System.Collections;
using MongoDB.Driver.Platform.Conditions;
using MongoDB.Driver.Command;
using System.Data;
using System.Linq.Expressions;
namespace MongoDB.Driver
{
    /// <summary>
    /// Extension method implementations for convenience overrides and common collection operations
    /// </summary>
    public static class IDBIndexExtensions
    {
        public static void Drop(this IDBIndex index)
        {
            index.Collection.DropIndex(index);
        }
    }
}