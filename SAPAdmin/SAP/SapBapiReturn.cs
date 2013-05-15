using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;

namespace SAPAdminPS.SAP
{
    public class SapBapiReturn : SapReturn
    {
        private string functionMoldule;
        private string type;
        private string messageClass;
        private string messageText;
        private string resultMessage;
        private int messageID;
    
        public const string MessageTypeSuccess = "S";
        public const string MessageTypeError = "E";
        public const string MessageTypeWarning = "W";
        public const string MessageTypeInformation = "I";
        public const string MessageTypeTermination = "A";

        public SapBapiReturn() { }

        
        public SapBapiReturn(string functionMoldule, IRfcFunction function) : base(function)
        {
            this.functionMoldule = functionMoldule;
        }


        public string FUNCTION_MODULE
        {
            get { return functionMoldule; }
            set { functionMoldule = value; }
        }
        public string TYPE
        {
            get { return type; }
            set { type = value; }
        }
        public string MESSAGE_CLASS
        {
            get { return messageClass; }
            set { messageClass = value; }
        }
        public string MESSAGE_TEXT
        {
            get { return messageText; }
            set { messageText = value; }
        }
        public int MESSAGE_ID
        {
            get { return messageID; }
            set { messageID = value; }
        }
        public string RESULT_MESSAGE
        {
            get { return resultMessage; }
            set { resultMessage = value; }
        }

        public bool HasSuccess
        {
            get { return MessageTypeSuccess.Equals(type) || "".Equals(type); }
        }

        public bool HasError
        {
            get { return MessageTypeError.Equals(type) || MessageTypeTermination.Equals(type); }
        }
    }
}
