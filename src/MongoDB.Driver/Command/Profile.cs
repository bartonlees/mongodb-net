
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
    /// The various options available for getting/setting the profiling level
    /// </summary>
    public enum ProfileMode
    {
        /// <summary>
        /// Just retrieve the profiling level
        /// </summary>
        GetProfilingLevel = -1,
        /// <summary>
        /// Set the profiling level to 0
        /// </summary>
        SetLevel0 = 0,
        /// <summary>
        /// Set the profiling level to 1
        /// </summary>
        SetLevel1 = 1,
        /// <summary>
        /// Set the profiling level to 2
        /// </summary>
        SetLevel2 = 2
    }
}


