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

            //if (Page.User.Identity.IsAuthenticated)
            //{
            //    register.Visible = false;
            //}
            //else
            //    register.Visible = true;
        }
    }
}