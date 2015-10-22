using System;
using PayPalApi.Utilities;
using PayPal.Api;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayPalApi
{
    public partial class Default : System.Web.UI.Page
    {
        protected RequestFlow Flow;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegisterRequestFlow();
            try
            {
                this.Run();
            }
            catch(Exception ex)
            {
                this.Flow.RecordException(ex);
            }
            Server.Transfer("~/Default.aspx");
        }

        protected void Run()
        {
            // API Context
            var apiContext = Configuration.GetAPIContext();

            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
                // Items
                var itemList = new ItemList()
                {
                    items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "15",
                            quantity = "5",
                            sku = "sku"
                        }
                    }
                };

                // Payer
                var payer = new Payer() { payment_method = "paypal" };

                // Redirect URLS
                var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Default.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var redirectUrl = baseURI + "guid=" + guid;
                var redirUrls = new RedirectUrls()
                {
                    cancel_url = redirectUrl + "&cancel=true",
                    return_url = redirectUrl
                };

                // Details
                var details = new Details()
                {
                    tax = "15",
                    shipping = "10",
                    subtotal = "75"
                };

                // Amount
                var amount = new Amount()
                {
                    currency = "USD",
                    total = "100.00",
                    details = details
                };

                // Transaction
                //var transactionList = new List<Transaction>();
                //transactionList.Add(new Transaction()
                //{
                //    description = "Transaction description.",
                //    invoice_number = Common.GetRandomInvoiceNumber(),
                //    amount = amount,
                //    item_list = itemList
                //});
            };
        }

        protected void RegisterRequestFlow()
        {
            if (this.Flow == null)
            {
                this.Flow = new RequestFlow();
            }
            HttpContext.Current.Items["Flow"] = this.Flow;
        }
    }
}