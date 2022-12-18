using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Api;

namespace WebPaypalTest.WebForms
{
    public partial class ReturnRes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void BtnConf_Click(object sender, EventArgs e)
        {
            var config = new Dictionary<string, string>();
            config.Add("mode", "sandbox");
            config.Add("clientId", WebConfigurationManager.AppSettings["clientID"]);
            config.Add("clientSecret", WebConfigurationManager.AppSettings["clientSecret"]);

            var accessToken = new OAuthTokenCredential(config).GetAccessToken();

            var apiContext = new APIContext(accessToken);
            apiContext.Config = config;

            var paymentId = Session["paymentId"].ToString();
            if (!String.IsNullOrEmpty(paymentId))
            { 
                var payment = new Payment() { id = paymentId };  
                var payerId = Request.QueryString["PayerID"].ToString();
                var paymentExecution = new PaymentExecution() { payer_id = payerId };

                var executedPayment = payment.Execute(apiContext, paymentExecution);

                litInfo.Text = "<p>Le paiement a été completé</p>";
                btnConf.Visible = false;                   
            }
            
        }
    }
}