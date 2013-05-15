using System;
using SAP.Middleware.Connector;

namespace SAPAdminPS.SAP.Impl
{
    /// <summary>
    /// SAPロール追加
    /// </summary>
    public class SapFunctionAddProfile : SapFunctionBase
    {
        private string targetUser;
        private string profileName;

        /// <param name="logonConf">SAPログオン情報</param>
        /// <param name="targetUser">SAPユーザID</param>
        /// <param name="roleName">プロファイル名</param>
        public SapFunctionAddProfile
            (SapConnectionInfo logonConf, String targetUser, String profileName)
            : base(logonConf)
        {
            this.targetUser = targetUser;
            this.profileName = profileName;
        }

        public override SapReturn Execute()
        {
            string functionModule = "BAPI_USER_PROFILES_ASSIGN";
            IRfcFunction sapFunction = CreateSapFunctionModule(functionModule);
            sapFunction.SetValue("USERNAME", this.targetUser);
            IRfcTable profTable = sapFunction.GetTable("PROFILES");
            IRfcStructure profStructure = profTable.Metadata.LineType.CreateStructure();
            profStructure.SetValue("BAPIPROF", profileName);
            profTable.Append(profStructure);
            sapFunction.Invoke(this.rfcDestination);

            return SapReturnFactory.GetSapReturnFromBapiTable(functionModule, sapFunction);
        }
    }
}
