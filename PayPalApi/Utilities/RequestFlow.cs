using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;
using System.IO;

namespace PayPalApi.Utilities
{
    public class RequestFlow
    {
        public List<RequestFlowItem> Items { get; private set; }

        public string Description { get; set; }
        
        public RequestFlow()
        {
            this.Items = new List<RequestFlowItem>();
        }

        public void AddNewRequest(string title, IPayPalSerializableObject requestObject = null, string description = "")
        {
            this.Items.Add(new RequestFlowItem()
            {
                Request = requestObject == null ? string.Empty : Common.FormatJsonString(requestObject.ConvertToJson()),
                Title = title,
                Description = description
            });
        }

        public void RecordResponse(IPayPalSerializableObject responseObject)
        {
            if (responseObject != null && this.Items.Any())
            {
                this.Items.Last().Response = Common.FormatJsonString(responseObject.ConvertToJson());
            }
        }

        public void RecordActionSuccess(string message)
        {
            if (this.Items.Any())
            {
                this.Items.Last().RecordSuccess(message);
            }
        }

        public void RecordImage(Image image)
        {
            if (this.Items.Any())
            {
                var filename = "Images/sample.png";
                var serverRoot = HttpContext.Current.Server.MapPath(null);
                image.Save(Path.Combine(serverRoot, filename));
                this.Items.Last().ImagePath = filename;
            }
        }

        public void RecordException(Exception ex)
        {
            if (ex != null)
            {
                if (!this.Items.Any())
                {
                    this.Items.Add(new RequestFlowItem());
                }
                this.Items.Last().RecordException(ex);
            }
        }

        public void RecordRedirectUrl(string text, string redirectUrl)
        {
            if (this.Items.Any())
            {
                this.Items.Last().RedirectUrlText = text;
                this.Items.Last().RedirectUrl = redirectUrl;
            }
        }

        public void RecordApproval(string message)
        {
            if (this.Items.Any())
            {
                this.Items.Last().Title += " (Approved!)";
                this.Items.Last().RedirectUrlText = message;
                this.Items.Last().IsRedirectApproved = true;
            }
        }
    }
}