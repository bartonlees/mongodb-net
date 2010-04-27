using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command
{
    /// <summary>
    /// {was : previousLevel, ok : 1}
    /// </summary>
    internal static partial class CommandExtensions
    {
        //IDatabase
        
        //{profile : mode}

        //{was : previousLevel, ok : 1}
    }

    public enum ProfileMode
    {
        GetProfilingLevel = -1,
        SetLevel0 = 0,
        SetLevel1 = 1,
        SetLevel2 = 2
    }
}


