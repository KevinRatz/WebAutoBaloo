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
    public partial class AddCars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.User.Identity.IsAuthenticated || ((Client)Session["Client"]).Admin == 0)
            //    Response.Redirect("MainPage.aspx");
            // si la page est chargée pour la première fois
            if (!Page.IsPostBack)
            {
                DDListMarque.DataSource = ((Modele)Session["CoucheModele"]).ListMarques();
                DDListMarque.DataBind();
                
                DDListCarro.DataSource = ((Modele)Session["CoucheModele"]).ListCarrosseries();
                DDListCarro.DataBind();

                DDListCarbu.DataSource = ((Modele)Session["CoucheModele"]).ListCarburants();
                DDListCarbu.DataBind();
            }
        }
        protected void BtnAddCars_Click(object sender, EventArgs e)
        {
            Vehicule v = new Vehicule(txtChassis.Text, txtNom.Text, DDListMarque.SelectedIndex,
                txtPuissance.Text, Convert.ToInt32(RBPortes.SelectedValue), Convert.ToInt32(txtNbVitesse.Text), Convert.ToInt32(txtCylindres.Text), txtCouleur.Text,
                Convert.ToDecimal(txtKm.Text), Convert.ToDateTime(txtAn.Text), Convert.ToDateTime(dateCtrlTech.Text), RBCtEnt.SelectedValue, RBTrans.SelectedIndex,
                Convert.ToDecimal(txtPrix.Text), Convert.ToInt32(txtReduct.Text),InPhoto.PostedFile.FileName, Convert.ToDateTime(txtdtarv.Text), 1, RBTransm.SelectedIndex,
                DDListCarbu.SelectedIndex, DDListCarro.SelectedIndex);

            Literal lit = new Literal();
            if (!((Modele)Session["CoucheModele"]).AddVehiculeVM(v))
            {
                lit.Text = "Le numéro du chassis de la voiture existe déjà ou des erreurs dans le formulaire";
                ct.Controls.Add(lit);
            }
        }

        protected void RBTransm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBTransm.SelectedItem.ToString() == "man")
                vitesseHide.Style.Add("display", "flex");
            else
                vitesseHide.Style.Add("display", "none");
        }
        protected void RBCtEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBCtEnt.SelectedItem.ToString() == "Oui")
                dtCtrlTechH.Style.Add("display", "flex");
            else
                dtCtrlTechH.Style.Add("display", "none");
        }
    }
}