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
            Vehicule v = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(Session["IdVehicule"].ToString());

            /*
             * Tableau qui liste les dates déjà loué par ce vehicule
             */
            List<AutoBalooWeb.ClasseMetiers.Location> list = new List<AutoBalooWeb.ClasseMetiers.Location>();            
            //Choix de la zone d'ajout pour l'injection du code 
            ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu");

            list = ((Modele)Session["CoucheModele"]).ListLocationsByVehiculeVM(v.IdVoiture);
            AutoBalooWeb.ClasseMetiers.Location c = new AutoBalooWeb.ClasseMetiers.Location();

            //On met les balise qui vont permettre de structurer l'affichage.
            if(list!=null)
                cph.Controls.Add(new LiteralControl("<div class=\"container\" style=\"padding-left: 270px;padding-right: 270px;\">\r\n " +
                "<div class=\"row justify-content-md-center text-center\" style=\"border: 1px solid black;\">\r\n\r\n  <h2>Date déjà loué</h2> " +
                "\r\n\r\n <div style=\"margin-left: -80px;\">Date début</div> \r\n\r\n <div style=\"margin-left:80px;margin-top:-24px;\">Date fin</div> " +
                "<div  class=\"col-md-4\"><br>\r\n"));

            //On remplis la page avec la liste de voitures qui a été récupérée.

            int i = 0;
            while (i < list.Count())
            {
                c = list[i];
                cph.Controls.Add(new LiteralControl("" +
                    //Récupération de la photo de la voiture
                    "<div style =\"border:1px solid black;width:auto;background-color:lightgray\">\r\n" +
                    //Récupération des informations de la voiture

                    "<div style=\"text-align:center;\">\r\n" +
                    "<div>" + c.Date.ToShortDateString() + " - " + c.DateFin.ToShortDateString() +
                    "</div>\r\n\r\n"
                ));
                i++;
            }

            /*
             * ------------------------------------------
             */

            txtdtfin.Enabled = false;
            txtdtdeb.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            txtVe.Text = v.ToString();
        }
        protected void BtnLouerCars_Click(object sender, EventArgs e)
        {

            Literal lit = new Literal();
            Client cliSess = ((Modele)Session["CoucheModele"]).GetClientVM(Page.User.Identity.Name);
            Vehicule v = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(Session["IdVehicule"].ToString());
            AutoBalooWeb.ClasseMetiers.Location loc = null;
            loc = new AutoBalooWeb.ClasseMetiers.Location(Convert.ToDateTime(txtdtdeb.Text), v.IdVoiture, cliSess.Id, Convert.ToDateTime(txtdtfin.Text));
            if (!((Modele)Session["CoucheModele"]).AddLocationVM(loc))
            {
                lit.Text = "Déjà loué à cette période";
                ct.Controls.Add(lit);
            }
            else
            {
                lit.Text = "Location réussie";
                ct.Controls.Add(lit);
                btnLouerCars.Visible = false;
                btnCancel.CssClass = "btn btn-primary";
                btnCancel.Text = "OK";
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
            txtdtfin.Text = txtdtdeb.Text;
            btnLouerCars.Visible = true;
            btnCancel.CssClass = "btn btn-secondary";
            btnCancel.Text = "Annuler";
        }
    }
}