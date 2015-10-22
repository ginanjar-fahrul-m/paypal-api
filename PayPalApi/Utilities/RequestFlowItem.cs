using System;
using System.Collections.Generic;
using PayPal;
using System.Linq;
using System.Web;

namespace PayPalApi.Utilities
{
    public enum RequestFlowItemMessageType
    {
        General,
        Success,
        Error
    }

    public class RequestFlowItemMessage
    {
        public string Message { get; set; }
        public RequestFlowItemMessageType Type { get; set; }
    }

    public class RequestFlowItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<RequestFlowItemMessage> Messages { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public bool IsErrorResponse { get; set; }
        public string RedirectUrl { get; set; }
        public string RedirectUrlText { get; set; }
        public bool IsRedirectApproved { get; set; }
        public string ImagePath { get; set; }

        public RequestFlowItem()
        {
            this.Messages = new List<RequestFlowItemMessage>();
        }

        public void RecordException(Exception ex)
        {
            this.IsErrorResponse = true;

            if (ex is ConnectionException)
            {
                this.Response = Common.FormatJsonString(((ConnectionException)ex).Response);
                if (string.IsNullOrEmpty(ex.Message))
                {
                    this.RecordError(string.Format("Error thrown from SDK as type {0}.", ex.GetType().ToString));
                }
                else
                {
                    this.RecordError(ex.Message);
                }
            }
            else if (ex is PayPalException && ex.InnerException != null)
            {
                this.RecordError(ex.InnerException);
            }
            else
            {
                this.RecordError(ex.Message);
            }
        }

        public void RecordError(string message)
        {
            this.RecordMessage(message, RequestFlowItemMessageType.Success);
        }

        public void RecordMessage(string message, RequestFlowItemMessageType type = RequestFlowItemMessageType.General)
        {
            this.Messages.Add(new RequestFlowItemMessage() { Message = message, Type = type});
        }
    }
}