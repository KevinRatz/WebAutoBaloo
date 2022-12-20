using AutoBalooWeb.ClasseMetiers;
using AutoBalooWeb.CoucheModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoBalooWeb.WebForms
{
    public partial class LocationForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtdtfin.Enabled = false;
            txtdtdeb.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            Vehicule v = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(Session["IdVehicule"].ToString());
            txtVe.Text = v.ToString();
        }
        protected void BtnLouerCars_Click(object sender, EventArgs e)
        {
            // partie paypal
            Literal lit = new Literal();
            Client cliSess = ((Modele)Session["CoucheModele"]).GetClientVM(Page.User.Identity.Name);
            Vehicule v = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(Session["IdVehicule"].ToString());
            AutoBalooWeb.ClasseMetiers.Location loc = null;
            loc = new AutoBalooWeb.ClasseMetiers.Location(Convert.ToDateTime(txtdtdeb.Text), v.IdVoiture, cliSess.Id, Convert.ToDateTime(txtdtfin.Text));
            if (!((Modele)Session["CoucheModele"]).AddLocationVM(loc))
            {
                lit.Text = "Le numéro du chassis de la voiture existe déjà ou des erreurs dans le formulaire";
                ct.Controls.Add(lit);
            }
            else
            {
                lit.Text = "Location réussie";
                ct.Controls.Add(lit);
                btnLouerCars.Visible = false;
                btnCancel.CssClass = "btn btn-primary";
                btnCancel.Text = "Ok";
            }
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void txtdtdeb_TextChanged(object sender, EventArgs e)
        {
            txtdtfin.Enabled = true;
            txtdtfin.Attributes["min"] = Convert.ToDateTime(txtdtdeb.Text).ToString("yyyy-MM-dd");
        }
    }
}