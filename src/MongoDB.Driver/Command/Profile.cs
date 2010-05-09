
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

    /// <summary>
    /// 
    /// </summary>
    public enum ProfileMode
    {
        /// <summary>
        /// 
        /// </summary>
        GetProfilingLevel = -1,
        /// <summary>
        /// 
        /// </summary>
        SetLevel0 = 0,
        /// <summary>
        /// 
        /// </summary>
        SetLevel1 = 1,
        /// <summary>
        /// 
        /// </summary>
        SetLevel2 = 2
    }
}


