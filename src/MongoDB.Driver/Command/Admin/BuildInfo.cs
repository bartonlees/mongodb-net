using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver.Command.Admin
{
    internal static partial class AdminCommandExtensions
    {
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
    public class BuildInfo : DBObjectWrapper
    {
        //{version : dbVersion, gitVersion : gitCommitId, sysInfo : osInfo, ok : 1}

        public BuildInfo(IDBObject response)
            : base(response)
        {
        }
        public string Version { get { return Object.GetAsString("version", string.Empty); } }
        public string GitVersion { get { return Object.GetAsString("gitVersion", string.Empty); } }
        public string SysInfo { get { return Object.GetAsString("sysInfo", string.Empty); } }
        public int Bits { get { return Object.GetAsInt("bits", 0); } }

        public override string ToString()
        {
            return string.Format("{{version : {0}, gitVersion : {1}, sysInfo : {2}, bits : {3}}}", Version, GitVersion, SysInfo, Bits);
        }
    }
}
