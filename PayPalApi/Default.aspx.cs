using System;
using PayPalApi.Utilities;

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