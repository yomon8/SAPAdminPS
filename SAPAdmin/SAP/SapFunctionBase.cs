using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPAdminPS.SAP
{
    public abstract class SapFunctionBase : ISAPFunction
    {
        #region PROTECTED MEMBERS
        // SAP RFC接続基盤
        protected RfcDestination rfcDestination;
        // SAPレポジトリ
        protected RfcRepository rfcRepository;
        // SAPログオン情報
        protected SapConnectionInfo sapLogonConfiguration;

        protected SapFunctionBase(SapConnectionInfo logonConf)
        {
            this.sapLogonConfiguration = logonConf;
            this.rfcDestination = GetRfcDestination(this.sapLogonConfiguration);
            this.rfcRepository = rfcDestination.Repository;
        }

        public abstract SapReturn Execute();

        /// <summary>
        /// SAP汎用モジュールオブジェクト生成
        /// </summary>
        protected IRfcFunction CreateSapFunctionModule(string sapFunctionModuleName)
        {
            return rfcRepository.CreateFunction(sapFunctionModuleName);
        }

        #endregion

        #region PRIVATE MEMBERS
        /// <summary>
        /// RFC接続の生成
        /// </summary>
        private static RfcDestination GetRfcDestination(SapConnectionInfo sapLogonConf)
        {
            RfcConfigParameters RfcParameter = new RfcConfigParameters();
            RfcParameter.Add(RfcConfigParameters.Name, sapLogonConf.SAPSID);
            RfcParameter.Add(RfcConfigParameters.AppServerHost, sapLogonConf.HOSTNAME);
            RfcParameter.Add(RfcConfigParameters.SystemNumber, sapLogonConf.SYSNUM);
            RfcParameter.Add(RfcConfigParameters.Client, sapLogonConf.CLIENT);
            RfcParameter.Add(RfcConfigParameters.User, sapLogonConf.USER_ID);
            RfcParameter.Add(RfcConfigParameters.Password, sapLogonConf.PASSWORD);
            RfcParameter.Add(RfcConfigParameters.Language, sapLogonConf.LANGUAGE);
            RfcParameter.Add(RfcConfigParameters.SAPRouter, sapLogonConf.ROUTE_STRING);


            return RfcDestinationManager.GetDestination(RfcParameter);
        }
        #endregion
    }
}
