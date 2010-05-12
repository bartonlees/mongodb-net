using System;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
        /// <summary>
        /// Buildinfoes the specified db.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public static BuildInfo buildinfo(this IAdminOperations db)
        {
            IDBObject response = db.ExecuteCommand(_buildinfo);
            response.ThrowIfResponseNotOK("buildinfo failed");
            return new BuildInfo(response);
        }
        static DBQuery _buildinfo = new DBQuery("buildinfo", 1);
    }
}

namespace MongoDB.Driver
{
    /// <summary>
    /// 
    /// </summary>
    public class BuildInfo : DBObjectWrapper
    {
        //{version : dbVersion, gitVersion : gitCommitId, sysInfo : osInfo, ok : 1}

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildInfo"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        public BuildInfo(IDBObject response)
            : base(response)
        {
        }
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get { return Object.GetAsString("version", string.Empty); } }
        /// <summary>
        /// Gets the git version.
        /// </summary>
        /// <value>The git version.</value>
        public string GitVersion { get { return Object.GetAsString("gitVersion", string.Empty); } }
        /// <summary>
        /// Gets the sys info.
        /// </summary>
        /// <value>The sys info.</value>
        public string SysInfo { get { return Object.GetAsString("sysInfo", string.Empty); } }
        /// <summary>
        /// Gets the bits.
        /// </summary>
        /// <value>The bits.</value>
        public int Bits { get { return Object.GetAsInt("bits", 0); } }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{{version : {0}, gitVersion : {1}, sysInfo : {2}, bits : {3}}}", Version, GitVersion, SysInfo, Bits);
        }
    }
}
