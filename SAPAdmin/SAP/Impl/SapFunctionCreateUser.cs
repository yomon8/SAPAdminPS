using System;
using SAP.Middleware.Connector;
using SAPAdminPS.SAP;

namespace SAPAdminPS.SAP.Impl
{
    /// <summary>
    /// SAPユーザ登録
    /// </summary>
    public class SapFunctionCreateUser : SapFunctionBase
    {
        private string newUser;
        private string initialPassword;
        private string userType;
        private string lastName;
        private string firstName;

        /// <param name="logonConf">SAPログオン情報</param>
        /// <param name="newUser">SAPユーザID</param>
        /// <param name="initialPassword">初期パスワード</param>
        /// <param name="userType">ユーザタイプ(A:ダイアログ、B:システム、C:通信、S:サービス、L:サービス)</param>
        /// <param name="lastName">姓</param>
        /// <param name="firstName">名</param>
        public SapFunctionCreateUser
            (SapConnectionInfo logonConf, string newUser, string initialPassword, string userType, string lastName, string firstName)
            : base(logonConf)
        {
            this.newUser = newUser;
            this.initialPassword = initialPassword;
            this.userType = userType;
            this.lastName = lastName;
            this.firstName = firstName;
        }

        public override SapReturn Execute()
        {
            string functionModule = "BAPI_USER_CREATE1";
            IRfcFunction sapFunction = CreateSapFunctionModule(functionModule);
            sapFunction.SetValue("USERNAME", this.newUser);
            sapFunction.GetStructure("LOGONDATA").SetValue("USTYP", this.userType);
            sapFunction.GetStructure("PASSWORD").SetValue("BAPIPWD", this.initialPassword);
            sapFunction.GetStructure("ADDRESS").SetValue("LASTNAME", this.lastName);
            sapFunction.GetStructure("ADDRESS").SetValue("FIRSTNAME", this.firstName);
            sapFunction.Invoke(this.rfcDestination);

            return SapReturnFactory.GetSapReturnFromBapiTable(functionModule, sapFunction);

        }
    }
}
