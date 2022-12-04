using AutoBalooWeb.CoucheAccesDB;
using AutoBalooWeb.CoucheModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoBalooWeb
{
    public partial class NavBar : System.Web.UI.MasterPage
    {
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
                if (Page.User.Identity.Name.Equals("kev.r@stu.be"))
                    adminbt.Visible = true; // aff btn gerer
            }
            else
            {
                signup.Visible = true; // aff bouton inscire
                user.Visible = false; //cache icon user
            }
        }
    }
}