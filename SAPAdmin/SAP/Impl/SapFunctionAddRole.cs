using System;
using SAP.Middleware.Connector;

namespace SAPAdminPS.SAP.Impl
{
    /// <summary>
    /// SAPロール追加
    /// </summary>
    public class SapFunctionAddRole : SapFunctionBase
    {
        private string targetUser;
        private string roleName;
        private string fromDate;
        private string toDate;

        /// <param name="logonConf">SAPログオン情報</param>
        /// <param name="targetUser">SAPユーザID</param>
        /// <param name="roleName">ロール名</param>
        /// <param name="fromDate">有効開始日（YYYYMMDD）</param>
        /// <param name="toDate">有効終了日（YYYYMMDD）</param>
        public SapFunctionAddRole
            (SapConnectionInfo logonConf, String targetUser, String roleName, String fromDate, String toDate)
            : base(logonConf)
        {
            this.targetUser = targetUser;
            this.roleName = roleName;
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

        public override SapReturn Execute()
        {
            string functionModule = "BAPI_USER_ACTGROUPS_ASSIGN";
            IRfcFunction sapFunction = CreateSapFunctionModule(functionModule);
            sapFunction.SetValue("USERNAME", this.targetUser);
            IRfcTable activityTable = sapFunction.GetTable("ACTIVITYGROUPS");
            IRfcStructure roleStructure = activityTable.Metadata.LineType.CreateStructure();
            roleStructure.SetValue("AGR_NAME", roleName);
            roleStructure.SetValue("FROM_DAT", fromDate);
            roleStructure.SetValue("TO_DAT", toDate);
            activityTable.Append(roleStructure);
            sapFunction.Invoke(this.rfcDestination);

            return SapReturnFactory.GetSapReturnFromBapiTable(functionModule, sapFunction);
        }
    }
}
