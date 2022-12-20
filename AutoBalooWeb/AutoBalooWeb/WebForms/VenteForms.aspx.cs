using AutoBalooWeb.ClasseMetiers;
using AutoBalooWeb.CoucheModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Api;
using System.Web.Configuration;

namespace AutoBalooWeb.WebForms
{
    public partial class VenteForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtdtRes.Text = DateTime.Now.ToString();
            Vehicule v = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(Session["IdVehicule"].ToString());
            txtVe.Text = v.ToString();
        }
        protected void BtnResCars_Click(object sender, EventArgs e)
        {
            Literal lit = new Literal();
            Client cliSess = ((Modele)Session["CoucheModele"]).GetClientVM(Page.User.Identity.Name);
            Vehicule v = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(Session["IdVehicule"].ToString());
            Reservation res = new Reservation(Convert.ToDateTime(txtdtRes.Text), v.IdVoiture, cliSess.Id, 1);

            // partie paypal
            Session["Reserve"] = res;
            //tax livraison
            decimal postageCost = 0;
            // prix voiture db
            decimal price = v.Prix-(v.Prix*((decimal)v.Reduction/100));
            //pour test
            int qt = 1;
            decimal subtot = (qt * price);
            decimal tot = subtot + postageCost;
            // Authentifier avec paypal
            var config = new Dictionary<string, string>();
            config.Add("mode", "sandbox");
            config.Add("clientId", WebConfigurationManager.AppSettings["clientID"]);
            config.Add("clientSecret", WebConfigurationManager.AppSettings["clientSecret"]);
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();

            var apiContext = new APIContext(accessToken);
            apiContext.Config = config;
            //info voiture db
            var carsItem = new Item();
            carsItem.name = v.Marque.NomMarque+" "+v.Nom;
            carsItem.currency = "EUR";
            carsItem.price = price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            carsItem.sku = v.ToString().Trim();
            carsItem.quantity = qt.ToString();

            var transactionDetails = new Details();
            transactionDetails.tax = "0";
            transactionDetails.shipping = postageCost.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            transactionDetails.subtotal = subtot.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            var transactionAmount = new Amount();
            transactionAmount.currency = "EUR";
            transactionAmount.total = tot.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            transactionAmount.details = transactionDetails;

            var trans = new Transaction();
            trans.description = "order o cars";
            //key of res db
            trans.invoice_number = Guid.NewGuid().ToString();
            trans.amount = transactionAmount;
            trans.item_list = new ItemList
            {
                items = new List<Item> { carsItem }
            };

            var payer = new Payer();
            payer.payment_method = "paypal";

            var redUrls = new RedirectUrls();
            redUrls.cancel_url = WebConfigurationManager.AppSettings["cancelUrl"];
            redUrls.return_url = WebConfigurationManager.AppSettings["returnUrl"];

            var payment = Payment.Create(apiContext, new Payment
            {
                intent = "sale",
                payer = payer,
                transactions = new List<Transaction> { trans },
                redirect_urls = redUrls
            });

            Session["paymentId"] = payment.id;

            foreach (var link in payment.links)
            {
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                    Response.Redirect(link.href);
            }
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}