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

                txtChassis.Text = "125";
                txtNom.Text = "S3";
                DDListMarque.SelectedIndex = 2;
                txtPuissance.Text = "50 kW";
                RBPortes.SelectedIndex = 1;
                txtNbVitesse.Text = "6";
                vitesseHide.Style.Add("display", "flex");
                txtCylindres.Text = "50";
                txtCouleur.Text = "blue";
                txtKm.Text = "50000";
                txtAn.Text = "1995-04-20";
                RBCtEnt.SelectedValue = "Non";
                txtdtarv.Text = "2022-04-20";
                RBTrans.SelectedIndex = 0;
                txtPrix.Text = "10000";
                txtReduct.Text = "0";
                RBTransm.SelectedIndex = 1;
                DDListCarbu.SelectedIndex = 1;
                DDListCarro.SelectedIndex = 1;
            }
        }
        protected void BtnAddCars_Click(object sender, EventArgs e)
        {
            Vehicule v = new Vehicule(txtChassis.Text, txtNom.Text, new Marque(DDListMarque.SelectedIndex),
                txtPuissance.Text, Convert.ToInt32(RBPortes.SelectedValue), Convert.ToInt32(txtNbVitesse.Text), Convert.ToInt32(txtCylindres.Text), txtCouleur.Text,
                Convert.ToDecimal(txtKm.Text), Convert.ToDateTime(txtAn.Text), (dateCtrlTech.Text=="")? new DateTime(1900,01,01) : (Convert.ToDateTime(dateCtrlTech.Text)), RBCtEnt.SelectedValue, RBTrans.SelectedIndex,
                Convert.ToDecimal(txtPrix.Text), Convert.ToInt32(txtReduct.Text),InPhoto.PostedFile.FileName, Convert.ToDateTime(txtdtarv.Text), new Etat(1), new Transmission(RBTransm.SelectedIndex),
                new Carburant(DDListCarbu.SelectedIndex), new Carrosserie(DDListCarro.SelectedIndex));

            Literal lit = new Literal();
            if (!((Modele)Session["CoucheModele"]).AddVehiculeVM(v))
            {
                lit.Text = "Le numéro du chassis de la voiture existe déjà ou des erreurs dans le formulaire";
                ct.Controls.Add(lit);
            }
            else if (v.TypeTransaction == 0)
                Response.Redirect("Vente.aspx");
            else
                Response.Redirect("Location.aspx");
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