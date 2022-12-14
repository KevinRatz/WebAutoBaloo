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
    public partial class Location : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Vehicule> list = new List<Vehicule>();

            //Choix de la zone d'ajout pour l'injection du code 
            ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu");


            list = ((Modele)Session["CoucheModele"]).ListVehiculeVMAvecOptions(3);


            Vehicule c = new Vehicule();

            //On met les balise qui vont permettre de structurer l'affichage.
            cph.Controls.Add(new LiteralControl("<div class=\"container\">\r\n      <div class=\"row justify-content-md-center\">\r\n\r\n        <div class=\"col col-lg-2\"></div>\r\n\r\n        <div  class=\"col-md\"><br>\r\n"));

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


                //Si Location
                cph.Controls.Add(new LiteralControl(
                        "<div style=\"display:inline-block ;vertical-align:middle;margin-right:50px;align-content:end\">\r\n" +
                        //Affichage du prix Sans réduction
                        "<div>" + c.Etat.NomEtat + "</div>\r\n" +
                        ((c.Reduction == 0) ? "" : "<div style =\"color:red\">- "+c.Reduction+" %</div>\r\n") +
                        //Affichage du prix avec réduction
                        ((c.Reduction == 0) ?  "<div>" + c.Prix + "€ par jour</div>\r\n" : "<div><strike>" + c.Prix + "</strike> " + (c.Prix - (c.Prix * c.Reduction) / 100) + "€ par jour </div>\r\n")));

                //Ajout des boutons pour faire une demande de location
                if (Session["Client"] != null)
                {
                    cph.Controls.Add(new LiteralControl("<button>Louer</button>\r\n"));
                }
                
                //Balise de fin 
                cph.Controls.Add(new LiteralControl("</div>\r\n\r\n </div> <br>"));

                i++;
            }
            //Fermeture de l'affichage
            cph.Controls.Add(new LiteralControl("\r\n\r\n        </div>\r\n\r\n        <div class=\"col col-lg-2\"></div>\r\n\r\n      </div>\r\n    </div>"));




        }
    }
}