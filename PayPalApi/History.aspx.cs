using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Api;

namespace PayPalApi
{
    public partial class History : System.Web.UI.Page
    {
        private static Dictionary<String, String> config = ConfigManager.Instance.GetProperties();
        private static String accessToken = new OAuthTokenCredential(config).GetAccessToken();
        private static APIContext apiContext = new APIContext(accessToken);
        protected List<Payment> history;
        protected string paymentid;
        protected string message;

        protected void Page_Load(object sender, EventArgs e)
        {
            paymentid = Request.Params["paymentid"];
            if (string.IsNullOrEmpty(paymentid)) {
                history = Payment.List(apiContext).payments;
            } else
            {
                var payment = Payment.Get(apiContext, paymentid);
                var transactions = payment.transactions.GetEnumerator();
                Sale sale = null;
                int total = 100; //fixed amount
                var invoiceNum = "";
                while (transactions.MoveNext())
                {
                    //total += Int32.Parse(transactions.Current.amount.total);
                    sale = transactions.Current.related_resources[0].sale; //It's dangerous
                    invoiceNum = transactions.Current.invoice_number;
                }

                var refund = new Refund()
                {
                    amount = new Amount()
                    {
                        currency = "USD",
                        total = total.ToString()
                    }
                };
                if (sale != null) {
                    var response = sale.Refund(apiContext, refund);
                    message = GetGlobalResourceObject("Resources", "msg3") + " " + invoiceNum + " " + GetGlobalResourceObject("Resources", "msg2");
                }
            }
        }
    }
}