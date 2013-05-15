using System;
using System.ComponentModel;
using System.Management.Automation;
using System.Configuration.Install;

namespace SAPAdminPS
{
    [RunInstaller(true)]
    public class SapPSSnapIn : PSSnapIn
    {
        public override string Name
        {
            get
            {
                return "SAP.Admin.PS";
            }
        }

        public override string Vendor
        {
            get
            {
                return "Yusuke.Otomo";
            }
        }

        public override string Description
        {
            get
            {
                return "PowerShell Cmdlet for SAP User Administration";
            }
        }

        public SapPSSnapIn()
            : base()
        {
        }
    }
}
