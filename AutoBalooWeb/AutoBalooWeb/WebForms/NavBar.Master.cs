using AutoBalooWeb.ClasseMetiers;
using AutoBalooWeb.CoucheAccesDB;
using AutoBalooWeb.CoucheModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoBalooWeb
{
    public partial class NavBar : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //initialisation de la couche modèle
            try
            {
                if (Session["Client"] == null)
                    FormsAuthentication.SignOut();
                if (Session["CoucheModele"] == null)
                {
                    Session["CoucheModele"] = new Modele();
                    Session.Timeout = 5;
                }
            }
            catch (ExceptionAccesDB ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["CoucheModele"] == null)
                {
                    Session["CoucheModele"] = new Modele();
                    Session.Timeout = 5;
                }
            }
            catch (ExceptionAccesDB ex)
            {
                Console.WriteLine(ex.Message);
            }
            // si un client est connecté
            if (Page.User.Identity.IsAuthenticated)
            {
                signup.Visible = false; // cache bouton inscire
                user.Visible = true; //aff icon user
                // si l'email du client connecté correspond à l'admin
                if (Session["Client"] != null && ((Client)Session["Client"]).Admin==1)
                    adminbt.Visible = true; // aff btn gerer
            }
            else
            {
                signup.Visible = true; // aff bouton inscire
                user.Visible = false; //cache icon user
            }
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Clear();
            Page = null;
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectFromLoginPage("", true);
        }

    }
}