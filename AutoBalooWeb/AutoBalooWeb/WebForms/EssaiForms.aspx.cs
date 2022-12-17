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
    public partial class EssaiForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtdt.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            Vehicule v = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(Session["IdVehicule"].ToString());
            txtVe.Text = v.ToString();
        }

        protected void BtnEssaiCars_Click(object sender, EventArgs e)
        {
            Literal lit = new Literal();
            Client cliSess = ((Modele)Session["CoucheModele"]).GetClientVM("kevboy9515@gmail.com"/*Page.User.Identity.Name*/);
            Vehicule v = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(Session["IdVehicule"].ToString());
            AutoBalooWeb.ClasseMetiers.Essai essai = null;

            if (txtdt.Text == "")
            {
                lit.Text = "Date manquante";
                ct.Controls.Add(lit);
            }
            else
            {
                essai = new AutoBalooWeb.ClasseMetiers.Essai(Convert.ToDateTime(txtdt.Text), v.IdVoiture, cliSess.Id);
                if (!((Modele)Session["CoucheModele"]).AddEssaiVM(essai))
                {
                    lit.Text = "L'essai de cette voiture existe déjà à cette date";
                    ct.Controls.Add(lit);
                }
                else
                {
                    lit.Text = "Essai réussi";
                    ct.Controls.Add(lit);
                }
            }
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}