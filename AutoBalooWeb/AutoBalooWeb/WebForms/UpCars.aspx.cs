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
    public partial class UpCars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated || ((Client)Session["Client"]).Admin == 0)
                Response.Redirect("MainPage.aspx");
            if (!Page.IsPostBack)
            {
                DDListId.DataSource = ((Modele)Session["CoucheModele"]).ListVehiculeVM();
                DDListId.DataBind();

                DDListMarque.DataSource = ((Modele)Session["CoucheModele"]).ListMarques();
                DDListMarque.DataBind();

                DDListCarro.DataSource = ((Modele)Session["CoucheModele"]).ListCarrosseries();
                DDListCarro.DataBind();

                DDListCarbu.DataSource = ((Modele)Session["CoucheModele"]).ListCarburants();
                DDListCarbu.DataBind();
            }
        }
        protected void BtnUpCars_Click(object sender, EventArgs e)
        {
            Vehicule v = new Vehicule(txtChassis.Text, txtNom.Text, DDListMarque.SelectedIndex,
                txtPuissance.Text, Convert.ToInt32(RBPortes.SelectedValue), Convert.ToInt32(txtNbVitesse.Text), Convert.ToInt32(txtCylindres.Text), txtCouleur.Text,
                Convert.ToDecimal(txtKm.Text), Convert.ToDateTime(txtAn.Text), Convert.ToDateTime(dateCtrlTech.Text), RBCtEnt.SelectedValue, RBTrans.SelectedIndex,
                Convert.ToDecimal(txtPrix.Text), Convert.ToInt32(txtReduct.Text), (InPhoto.PostedFile.FileName == "") ? null : InPhoto.PostedFile.FileName, Convert.ToDateTime(txtdtarv.Text), 1, RBTransm.SelectedIndex,
                DDListCarbu.SelectedIndex, DDListCarro.SelectedIndex);

            Literal lit = new Literal();
            if (!((Modele)Session["CoucheModele"]).UpVehiculeVM(v))
            {
                lit.Text = "Le numéro du chassis de la voiture existe déjà ou des erreurs dans le formulaire";
                ct.Controls.Add(lit);
            }
        }

        // attention faire via id recherché 
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

        protected void DDListId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Modele)Session["CoucheModele"]).GetVehiculeVM(DDListId.SelectedIndex);
        }

        protected void DDListId_TextChanged(object sender, EventArgs e)
        {
            Vehicule v = null;
            try
            {
                v = ((Modele)Session["CoucheModele"]).GetVehiculeVM(DDListId.SelectedIndex);
                txtChassis.Text = v.NumChassis; 
                txtNom.Text= v.Nom;
                DDListMarque.SelectedIndex = v.Marque.IdMarque-1;
                txtPuissance.Text = v.Puissance;
                if (v.NbPortes == 3)
                    RBPortes.SelectedIndex = 0;
                else
                    RBPortes.SelectedIndex = 1;
                if(v.Transmission.NomTrans=="man")
                    txtNbVitesse.Text = v.NbVitesse.ToString();
                txtCylindres.Text = v.Cylindres.ToString();
                txtCouleur.Text = v.Couleur;
                txtKm.Text = v.Kilometrage.ToString();
                txtAn.Text = v.Année.ToString();
                dateCtrlTech.Text = v.DateCtrlTech.ToString();
                RBCtEnt.SelectedValue = v.CarnetEntretien;
                if(v.CarnetEntretien=="oui")
                    txtdtarv.Text = v.DateArrive.ToString();
                RBTrans.SelectedIndex = v.TypeTransaction;
                txtPrix.Text = v.Prix.ToString();
                txtReduct.Text = v.Reduction.ToString();
                RBTransm.SelectedIndex = v.Transmission.IdTrans;
                DDListCarbu.SelectedIndex = v.Carburant.IdCarbu-1;
                DDListCarro.SelectedIndex = v.Carrosserie.IdCaros-1;                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problème inattendu lors du listage!");
            }
        }
    }
}