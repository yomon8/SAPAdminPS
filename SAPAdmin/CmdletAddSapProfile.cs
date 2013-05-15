using System;
using System.Text;
using System.Management.Automation;
using SAPAdminPS.SAP;
using SAPAdminPS.SAP.Impl;

namespace SAPAdminPS
{
    [Cmdlet("Add", "SapProfile")]
    public class CmdletAddSapProfile : Cmdlet
    {
        //SAP Connection Infomation
        private SapConnectionInfo logonConf = new SapConnectionInfo();

        //Bapi Return
        private SapBapiReturn sapReturn;

        //Parameters for Creating User
        private string targetUser;
        private string profileName;


        #region Logon Parameters (Common)

        [Parameter(Mandatory = true, Position = 0, HelpMessage = MessageTexts.HelpMessageSID)]
        public string SAPSID
        {
            set { this.logonConf.SAPSID = value; }
        }

        [Parameter(Mandatory = true, Position = 1, HelpMessage = MessageTexts.HelpMessageHOSTNAME)]
        public string HOSTNAME
        {
            set { this.logonConf.HOSTNAME = value; }
        }

        [Parameter(Mandatory = true, Position = 2, HelpMessage = MessageTexts.HelpMessageSTSNUM)]
        public string SYSNUM
        {
            set { this.logonConf.SYSNUM = value; }
        }

        [Parameter(Mandatory = true, Position = 3, HelpMessage = MessageTexts.HelpMessageCLIENT)]
        public string CLIENT
        {
            set { this.logonConf.CLIENT = value; }
        }

        [Parameter(Mandatory = true, Position = 4, HelpMessage = MessageTexts.HelpMessageUSER_ID)]
        public string USER_ID
        {
            set { this.logonConf.USER_ID = value; }
        }

        [Parameter(Mandatory = true, Position = 5, HelpMessage = MessageTexts.HelpMessagePASSWORD)]
        public string PASSWORD
        {
            set { this.logonConf.PASSWORD = value; }
        }

        [Parameter(Mandatory = false, Position = 6, HelpMessage = MessageTexts.HelpMessageLOGON_LANGUAGE)]
        public string LOGON_LANGUAGE
        {
            set { this.logonConf.LANGUAGE = value; }
        }

        [Parameter(Mandatory = false, Position = 7, HelpMessage = MessageTexts.HelpMessageROUTE_STRING)]
        public string ROUTE_STRING
        {
            set { this.logonConf.ROUTE_STRING = value; }
        }

        #endregion
        #region Parameter for SAP Funciton Module

        [Parameter(Mandatory = true, Position = 8, HelpMessage = MessageTexts.HelpMessageTARGET_USER)]
        public string TARGET_USER
        {
            set { this.targetUser = value; }
        }

        [Parameter(Mandatory = true, Position = 9, HelpMessage = MessageTexts.HelpMessagePROFILE_NAME)]
        public string PROFILE_NAME
        {
            set { this.profileName = value; }
        }

        #endregion


        public CmdletAddSapProfile()
            : base() { }

        protected override void ProcessRecord()
        {
            ISAPFunction sapFunction = new SapFunctionAddProfile(logonConf, targetUser,profileName);
            sapReturn = (SapBapiReturn)sapFunction.Execute();
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.Append(sapReturn.MESSAGE_TEXT);
            this.WriteObject(outputBuilder.ToString());
        }
    }
}