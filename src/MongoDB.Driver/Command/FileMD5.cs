using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    /// <summary>
    /// Finds the MD5 hash of a GridFS file. file_root is the prefix of the files and chunks collections. For example, with the default fs.files and fs.chunks collections, it would be "fs".
    /// </summary>
    internal static partial class CommandExtensions
    {
        //IDatabase
        //{filemd5 : object_id, root : file_root}
    }
}
