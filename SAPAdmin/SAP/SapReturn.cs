using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPAdminPS.SAP
{
    public class SapReturn
    {
        private IRfcFunction function;

        public SapReturn()
        {
        }

        public SapReturn(IRfcFunction function)
        {
            this.function = function;
        }

        public IRfcStructure GetStructure(string name)
        {
            return function.GetStructure(name);
        }

        public IRfcTable GetTable(string name)
        {
            return function.GetTable(name);
        }

        public string GetString(string name)
        {
            return function.GetString(name);
        }
    }
}
