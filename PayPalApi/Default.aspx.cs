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
            //Server.Transfer("~/Default.aspx");
        }

        protected void Run()
        {
            var apiContext = Configuration.GetAPIContext();

            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {
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
                
                var details = new Details()
                {
                    tax = "15",
                    shipping = "10",
                    subtotal = "75"
                };

                var amount = new Amount()
                {
                    currency = "USD",
                    total = "100.00",
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

                #region Track Workflow
                this.Flow.AddNewRequest("Create PayPal payment", payment);
                #endregion

                var createdPayment = payment.Create(apiContext);

                #region Track Workflow
                this.Flow.RecordResponse(createdPayment);
                #endregion

                var links = createdPayment.links.GetEnumerator();
                while (links.MoveNext())
                {
                    var link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        this.Flow.RecordRedirectUrl("Redirect to PayPal to approve the payment...", link.href);
                    }
                }
                Session.Add(guid, createdPayment.id);
                Session.Add("flow-" + guid, this.Flow);
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

        private Payment CreateFuturePayment(string correlationId, string authorizationCode, string redirectUrl)
        {
            Payer payer = new Payer()
            {
                payment_method = "paypal"
            };
            
            var amount = new Amount()
            {
                currency = "USD",
                total = "100",
                details = new Details()
                {
                    tax = "15",
                    shipping = "10",
                    subtotal = "75"
                }
            };
            
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };
            
            var itemList = new ItemList() { items = new List<Item>() };
            itemList.items.Add(new Item()
            {
                name = "Item Name",
                currency = "USD",
                price = "15",
                quantity = "5",
                sku = "sku"
            });
            
            var transactionList = new List<Transaction>();
            
            transactionList.Add(new Transaction()
            {
                description = "Transaction description.",
                amount = amount,
                item_list = itemList
            });

            var authorizationCodeParameters = new CreateFromAuthorizationCodeParameters();
            authorizationCodeParameters.setClientId(Configuration.ClientId);
            authorizationCodeParameters.setClientSecret(Configuration.ClientSecret);
            authorizationCodeParameters.SetCode(authorizationCode);

            var apiContext = Configuration.GetAPIContext();


            var tokenInfo = Tokeninfo.CreateFromAuthorizationCodeForFuturePayments(apiContext, authorizationCodeParameters);
            var accessToken = string.Format("{0} {1}", tokenInfo.token_type, tokenInfo.access_token);

            var futurePaymentApiContext = Configuration.GetAPIContext(accessToken);

            var futurePayment = new FuturePayment()
            {
                intent = "authorize",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return futurePayment.Create(futurePaymentApiContext, correlationId);
        }
    }
}