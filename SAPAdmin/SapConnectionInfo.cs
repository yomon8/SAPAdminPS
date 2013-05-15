namespace SAPAdminPS
{
    public class SapConnectionInfo
    {
        private string sapSid;
        private string sapSysNum;
        private string sapHostName;
        private string sapClient;
        private string sapUserId;
        private string sapUserPassword;
        private string sapLogonLangage;
        private string sapRouterString;

        public string SAPSID
        {
            get { return sapSid; }
            set { sapSid = value; }
        }

        public string SYSNUM
        {
            get { return sapSysNum; }
            set { sapSysNum = value; }
        }

        public string HOSTNAME
        {
            get { return sapHostName; }
            set { sapHostName = value; }
        }

        public string CLIENT
        {
            get { return sapClient; }
            set { sapClient = value; }
        }

        public string USER_ID
        {
            get { return sapUserId; }
            set { sapUserId = value; }
        }

        public string PASSWORD
        {
            get { return sapUserPassword; }
            set { sapUserPassword = value; }
        }

        public string LANGUAGE
        {
            get { return sapLogonLangage; }
            set { sapLogonLangage = value; }
        }

        public string ROUTE_STRING
        {
            get { return sapRouterString; }
            set { sapRouterString = value; }
        }
    }

}
