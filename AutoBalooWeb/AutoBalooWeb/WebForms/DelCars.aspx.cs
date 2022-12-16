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
    public partial class DelCars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.User.Identity.IsAuthenticated || ((Client)Session["Client"]).Admin == 0)
            //    Response.Redirect("MainPage.aspx");
            if (!Page.IsPostBack)
            {
                btnDelCars.Enabled = false;
                DDListId.DataSource = ((Modele)Session["CoucheModele"]).ListVehiculeVMAvecOptions(5);
                DDListId.DataBind();
            }
        }

        protected void DDListId_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelCars.Enabled = true;
            if (DDListId.SelectedIndex == 0)
                btnDelCars.Enabled = false;
        }
        protected void BtnDelCars_Click(object sender, EventArgs e)
        {
            Literal lit = new Literal();
            if (((Modele)Session["CoucheModele"]).DelVehiculeVM(DDListId.SelectedIndex))
            {
                lit.Text = "Véhicule supprimé";
                ct.Controls.Add(lit);
                btnDelCars.Enabled = false;
                DDListId.SelectedIndex = 0;
            }
        }
    }
}