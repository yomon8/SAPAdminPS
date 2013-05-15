using SAP.Middleware.Connector;

namespace SAPAdminPS.SAP
{
    public static class SapReturnFactory
    {
        public static SapBapiReturn GetSapReturnFromBapiTable(string functionModule, IRfcFunction sapFunction)
        {
            IRfcTable returnTable = sapFunction.GetTable("RETURN");
            SapBapiReturn sapReturn = new SapBapiReturn(functionModule, sapFunction);
            sapReturn.TYPE = returnTable.GetString("TYPE");
            sapReturn.MESSAGE_CLASS = returnTable.GetString("ID");
            sapReturn.MESSAGE_TEXT = returnTable.GetString("MESSAGE");
            sapReturn.MESSAGE_ID = returnTable.GetInt("NUMBER");
            return sapReturn;

        }

        public static SapBapiReturn GetSapReturnFromBapiStructure(string functionModule, IRfcFunction sapFunction)
        {
            IRfcStructure returnStructure = sapFunction.GetStructure("RETURN");
            SapBapiReturn sapReturn = new SapBapiReturn(functionModule, sapFunction);
            sapReturn.TYPE = returnStructure.GetString("TYPE");
            sapReturn.MESSAGE_CLASS = returnStructure.GetString("ID");
            sapReturn.MESSAGE_TEXT = returnStructure.GetString("MESSAGE");
            sapReturn.MESSAGE_ID = returnStructure.GetInt("NUMBER");
            return sapReturn;
        }
    }
}
