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
    public partial class VenteForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtdtRes.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
        }
        protected void BtnResCars_Click(object sender, EventArgs e)
        {
            // partie paypal
            Literal lit = new Literal();
            Client cliSess = ((Modele)Session["CoucheModele"]).GetClientVM(Page.User.Identity.Name);
            Reservation res = new Reservation(Convert.ToDateTime(txtdtRes.Text),Convert.ToInt32(Session["IdVehicule"]), cliSess.Id , 1);
            if (!((Modele)Session["CoucheModele"]).AddResVM(res))
            {
                lit.Text = "Le numéro du chassis de la voiture existe déjà ou des erreurs dans le formulaire";
                ct.Controls.Add(lit);
            }
            else
            {
                lit.Text = "Modification réussi";
                ct.Controls.Add(lit);
            }
        }
    }
}