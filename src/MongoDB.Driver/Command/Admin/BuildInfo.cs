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
        public string Version { get { return Object.GetAsString("version"); } }
        public string GitVersion { get { return Object.GetAsString("gitVersion"); } }
        public string SysInfo { get { return Object.GetAsString("sysInfo"); } }
        public int Bits { get { return Object.GetAsInt("bits"); } }
    }
}
