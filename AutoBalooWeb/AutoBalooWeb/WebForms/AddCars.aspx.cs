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
            if (!Page.User.Identity.IsAuthenticated || ((Client)Session["Client"]).Admin == 0)
                Response.Redirect("MainPage.aspx");
            // si la page est chargée pour la première fois
            if (!Page.IsPostBack)
            {

                /*
                 * Remplissage des dropdown list
                 */
                
                DDListMarque.DataSource = ((Modele)Session["CoucheModele"]).ListMarques();
                DDListMarque.DataBind();
                
                DDListCarro.DataSource = ((Modele)Session["CoucheModele"]).ListCarrosseries();
                DDListCarro.DataBind();

                DDListCarbu.DataSource = ((Modele)Session["CoucheModele"]).ListCarburants();
                DDListCarbu.DataBind();

                RBCtEnt.SelectedValue = "Non";
                RBTrans.SelectedIndex = 0;
                RBPortes.SelectedIndex = 1;
                RBTransm.SelectedIndex = 1;
                vitesseHide.Style.Add("display", "flex");
                txtNbVitesse.Text = "6";

                //txtChassis.Text = "125";
                //txtNom.Text = "S3";
                //DDListMarque.SelectedIndex = 2;
                //txtPuissance.Text = "50 kW";
                //txtCylindres.Text = "50";
                //txtCouleur.Text = "blue";
                //txtKm.Text = "50000";
                //txtAn.Text = "1995-04-20";
                //txtdtarv.Text = "2022-04-20";
                //txtPrix.Text = "10000";
                //txtReduct.Text = "0";
                //DDListCarbu.SelectedIndex = 1;
                //DDListCarro.SelectedIndex = 1;
            }
        }
        protected void BtnAddCars_Click(object sender, EventArgs e)
        {
            Vehicule vCha = ((Modele)Session["CoucheModele"]).GetVehiculeByVM(txtChassis.Text);
            Vehicule v = null;
            Literal lit = new Literal();

            if (vCha != null)
            {
                lit.Text = "Le numéro du chassis de la voiture existe déjà";
                ct.Controls.Add(lit);
            }
            else
            {
                v = new Vehicule(txtChassis.Text, txtNom.Text, new Marque(DDListMarque.SelectedIndex),
                  txtPuissance.Text, Convert.ToInt32(RBPortes.SelectedValue), (txtNbVitesse.Text == "") ? 0 : Convert.ToInt32(txtNbVitesse.Text),
                  (txtCylindres.Text == "") ? 0 : Convert.ToInt32(txtCylindres.Text), txtCouleur.Text, (txtKm.Text == "") ? 0 : Convert.ToDecimal(txtKm.Text),
                  (txtAn.Text == "") ? new DateTime(1900, 01, 01) : Convert.ToDateTime(txtAn.Text),
                  (dateCtrlTech.Text == "") ? new DateTime(1900, 01, 01) : (Convert.ToDateTime(dateCtrlTech.Text)), RBCtEnt.SelectedValue, RBTrans.SelectedIndex,
                  (txtPrix.Text == "") ? 0 : Convert.ToDecimal(txtPrix.Text), (txtReduct.Text == "") ? 0 : Convert.ToInt32(txtReduct.Text), (InPhoto.PostedFile.FileName == "") ? "NoImage.png" : InPhoto.PostedFile.FileName,
                  (txtdtarv.Text == "") ? new DateTime(1900, 01, 01) : (Convert.ToDateTime(txtdtarv.Text)), new Etat(1),
                  new Transmission(RBTransm.SelectedIndex), new Carburant(DDListCarbu.SelectedIndex), new Carrosserie(DDListCarro.SelectedIndex));

                if (!((Modele)Session["CoucheModele"]).AddVehiculeVM(v))
                {
                    lit.Text = "Des erreurs dans le formulaire";
                    ct.Controls.Add(lit);
                }
                else
                {
                    lit.Text = "Ajout réussi";
                    ct.Controls.Add(lit);
                    resetForms();
                }
            }
        }

        private void resetForms()
        {
            RBCtEnt.SelectedValue = "Non";
            RBTrans.SelectedIndex = 0;
            RBPortes.SelectedIndex = 1;
            RBTransm.SelectedIndex = 1;
            vitesseHide.Style.Add("display", "flex");
            txtNbVitesse.Text = "6";
            txtChassis.Text = "";
            txtNom.Text = "";
            DDListMarque.SelectedIndex = 0;
            txtPuissance.Text = "";
            txtCylindres.Text = "";
            txtCouleur.Text = "";
            txtKm.Text = "";
            txtAn.Text = "";
            txtdtarv.Text = "";
            txtPrix.Text = "";
            txtReduct.Text = "0";
            DDListCarbu.SelectedIndex = 0;
            DDListCarro.SelectedIndex = 0;
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