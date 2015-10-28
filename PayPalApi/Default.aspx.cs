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
        //TODO save static variable to Session
        private static Dictionary<String, String> config = ConfigManager.Instance.GetProperties();
        private static String accessToken = new OAuthTokenCredential(config).GetAccessToken();
        private static APIContext apiContext = new APIContext(accessToken);

        protected void Page_Load(object sender, EventArgs e)
        {
            string payerId = Request.Params["PayerId"];
            if (!string.IsNullOrEmpty(payerId))
            {
                ExecutePayment(payerId);
            }
        }

        protected void ExecutePayment(string payerId)
        {
            var paymentId = Request.Params["paymentId"];
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            var payment = new Payment()
            {
                id = paymentId
            };

            var executedPayment = payment.Execute(apiContext, paymentExecution);
        }

        protected void Pay_Click(object sender, EventArgs e)
        {
            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
                if (RadioButtonList1.SelectedValue == "10")
                {
                    var itemList = new ItemList()
                    {
                        items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "10",
                            quantity = "1",
                            sku = "sku"
                        }
                    }
                    };


                    var payer = new Payer()
                    {
                        payment_method = "paypal"
                    };

                    var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Default.aspx?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var redirectUrl = baseURI + "guid=" + guid;
                    var redirUrls = new RedirectUrls()
                    {
                        cancel_url = redirectUrl + "&cancel=true",
                        return_url = redirectUrl
                    };

                    var details = new Details()
                    {
                        tax = "15",
                        shipping = "10",
                        subtotal = "10"
                    };

                    var amount = new Amount()
                    {
                        currency = "USD",
                        total = "35.00",
                        details = details
                    };

                    var transactionList = new List<Transaction>();
                    transactionList.Add(new Transaction()
                    {
                        description = "Transaction description.",
                        invoice_number = Common.GetRandomInvoiceNumber(),
                        amount = amount,
                        item_list = itemList
                    });

                    var payment = new Payment()
                    {
                        intent = "sale",
                        payer = payer,
                        transactions = transactionList,
                        redirect_urls = redirUrls
                    };

                    var createdPayment = payment.Create(apiContext);

                    var links = createdPayment.links.GetEnumerator();
                    while (links.MoveNext())
                    {
                        var link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            Response.Redirect(link.href);
                        }
                    }
                }
                else if (RadioButtonList1.SelectedValue == "30")
                {
                    var itemList = new ItemList()
                    {
                        items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "30",
                            quantity = "1",
                            sku = "sku"
                        }
                    }
                    };


                    var payer = new Payer()
                    {
                        payment_method = "paypal"
                    };

                    var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Default.aspx?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var redirectUrl = baseURI + "guid=" + guid;
                    var redirUrls = new RedirectUrls()
                    {
                        cancel_url = redirectUrl + "&cancel=true",
                        return_url = redirectUrl
                    };

                    var details = new Details()
                    {
                        tax = "15",
                        shipping = "10",
                        subtotal = "30"
                    };

                    var amount = new Amount()
                    {
                        currency = "USD",
                        total = "55.00",
                        details = details
                    };

                    var transactionList = new List<Transaction>();
                    transactionList.Add(new Transaction()
                    {
                        description = "Transaction description.",
                        invoice_number = Common.GetRandomInvoiceNumber(),
                        amount = amount,
                        item_list = itemList
                    });

                    var payment = new Payment()
                    {
                        intent = "sale",
                        payer = payer,
                        transactions = transactionList,
                        redirect_urls = redirUrls
                    };

                    var createdPayment = payment.Create(apiContext);

                    var links = createdPayment.links.GetEnumerator();
                    while (links.MoveNext())
                    {
                        var link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            Response.Redirect(link.href);
                        }
                    }
                }
                else if (RadioButtonList1.SelectedValue == "50")
                {
                    var itemList = new ItemList()
                    {
                        items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "50",
                            quantity = "1",
                            sku = "sku"
                        }
                    }
                    };


                    var payer = new Payer()
                    {
                        payment_method = "paypal"
                    };

                    var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Default.aspx?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var redirectUrl = baseURI + "guid=" + guid;
                    var redirUrls = new RedirectUrls()
                    {
                        cancel_url = redirectUrl + "&cancel=true",
                        return_url = redirectUrl
                    };

                    var details = new Details()
                    {
                        tax = "15",
                        shipping = "10",
                        subtotal = "50"
                    };

                    var amount = new Amount()
                    {
                        currency = "USD",
                        total = "75.00",
                        details = details
                    };

                    var transactionList = new List<Transaction>();
                    transactionList.Add(new Transaction()
                    {
                        description = "Transaction description.",
                        invoice_number = Common.GetRandomInvoiceNumber(),
                        amount = amount,
                        item_list = itemList
                    });

                    var payment = new Payment()
                    {
                        intent = "sale",
                        payer = payer,
                        transactions = transactionList,
                        redirect_urls = redirUrls
                    };

                    var createdPayment = payment.Create(apiContext);

                    var links = createdPayment.links.GetEnumerator();
                    while (links.MoveNext())
                    {
                        var link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            Response.Redirect(link.href);
                        }
                    }
                }
                else
                {
                    //do nothing
                }
            }
        }
    }
}