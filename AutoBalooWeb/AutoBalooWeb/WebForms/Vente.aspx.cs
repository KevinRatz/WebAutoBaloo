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
    public partial class Vente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Vehicule> list = new List<Vehicule>();

            //Choix de la zone d'ajout pour l'injection du code 
            ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu");


            list = ((Modele)Session["CoucheModele"]).ListVehiculeVMAvecOptions(2);


            Vehicule c = new Vehicule();

            //On met les balise qui vont permettre de structurer l'affichage.
            cph.Controls.Add(new LiteralControl("<div class=\"container\">\r\n      <div class=\"row justify-content-md-center\">\r\n\r\n        <div class=\"col col-lg-2\"></div>\r\n\r\n        <div class=\"col-md\"><br>\r\n"));

            //On remplis la page avec la liste de voitures qui a été récupérée.

            int i = 0;
            while (i < list.Count())
            {
                c = list[i];
                cph.Controls.Add(new LiteralControl("" +
                    //Récupération de la photo de la voiture
                    "<div style =\"border:1px solid black;width:100%;background-color:lightgray\">\r\n <img src =\"./Image/" + c.Photo + "\" style=\"border:1px solid black;width:100%;width:150px;height:150px;display:inline-block ; margin-right :20px\">" +
                    //Récupération des informations de la voiture

                    "<div style=\"display:inline-block;width:300px;vertical-align:middle;margin-right:100px;\">\r\n" +
                    "<div>" + c.Marque.NomMarque + " " + c.Nom + " " + c.NumChassis + "</div>\r\n" +
                    "<div>" + c.Année.Year + "</div>\r\n" +
                    "<div>" + c.Carburant.NomCarbu + "</div>\r\n" +
                    "<div>" + c.Kilometrage + " Km </div>\r\n" +
                    "<div>" + c.Transmission.NomTrans + "</div>\r\n" +
                    "</div>\r\n\r\n"
                ));


                cph.Controls.Add(new LiteralControl(
                    "<div style=\"display:inline-block ;vertical-align:middle;margin-right:50px;align-content:end\">\r\n" +
                    //Affichage du prix Sans réduction
                    "<div>" + c.Etat.NomEtat + "</div>\r\n" +
                    ((c.Reduction == 0) ? "" : "<div style =\"color:red\">- " + c.Reduction + " %</div>\r\n") +
                    //Affichage du prix avec réduction
                    ((c.Reduction == 0) ? "<div>" + c.Prix + "€</div>\r\n" : "<div><strike>" + c.Prix + "</strike> " + (c.Prix - (c.Prix * c.Reduction) / 100) + "€ </div>\r\n")));

                //Ajout des boutons pour Essai et Vente
                //if (Session["Client"] != null)
                //{
                Button bt = new Button();
                bt.ID = "Res-" + c.NumChassis;
                bt.Text = "Réserver";
                bt.Click += new EventHandler(BtnRes_Click);
                bt.CssClass = "btn btn-primary";
                bt.Style.Add("margin-right", "20px");
                if (c.Etat.IdEtat == 2)
                    bt.Visible = false;
                cph.Controls.Add(bt);
                bt = new Button();
                bt.ID = "Essai-" + c.NumChassis;
                bt.Text = "Essai";
                bt.Click += new EventHandler(BtnEssai_Click);
                bt.CssClass = "btn btn-primary";
                if (c.Etat.IdEtat == 2)
                    bt.Visible = false;
                cph.Controls.Add(bt);
                //}
                if (c.Etat.IdEtat != 2)
                    cph.Controls.Add(new LiteralControl("<div> Disponible depuis : " + c.DateArrive.ToString("dd/MM/yyyy") + "</div>\r\n"));
                
                //Balise de fin 
                cph.Controls.Add(new LiteralControl("</div>\r\n\r\n </div> <br>"));

                i++;
            }
            //Fermeture de l'affichage
            cph.Controls.Add(new LiteralControl("\r\n\r\n        </div>\r\n\r\n        <div class=\"col col-lg-2\"></div>\r\n\r\n      </div>\r\n    </div>"));
        }

        protected void BtnRes_Click(object sender, EventArgs e)
        {

            String[] s = (sender as Button).ID.Split('-');
            Session["IdVehicule"] = s[1];
            Response.Redirect("VenteForms.aspx");
        }
        protected void BtnEssai_Click(object sender, EventArgs e)
        {
            String[] s = (sender as Button).ID.Split('-');
            Session["IdVehicule"] = s[1];
            Response.Redirect("EssaiForms.aspx");
        }
    }
}