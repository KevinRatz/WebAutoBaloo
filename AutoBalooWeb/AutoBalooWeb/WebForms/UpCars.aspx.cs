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
            //if (!Page.User.Identity.IsAuthenticated || ((Client)Session["Client"]).Admin == 0)
            //    Response.Redirect("MainPage.aspx");
            if (!Page.IsPostBack)
            {
                EnableForms(false);
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
            Vehicule v = new Vehicule(DDListId.SelectedIndex,txtChassis.Text, txtNom.Text, new Marque(DDListMarque.SelectedIndex),
                txtPuissance.Text, Convert.ToInt32(RBPortes.SelectedValue), Convert.ToInt32(txtNbVitesse.Text), Convert.ToInt32(txtCylindres.Text), txtCouleur.Text,
                Convert.ToDecimal(txtKm.Text), Convert.ToDateTime(txtAn.Text), (dateCtrlTech.Text == "") ? new DateTime(1900, 01, 01) : (Convert.ToDateTime(dateCtrlTech.Text)), RBCtEnt.SelectedValue, RBTrans.SelectedIndex,
                Convert.ToDecimal(txtPrix.Text), Convert.ToInt32(txtReduct.Text), (InPhoto.PostedFile.FileName == "") ? "NoImage.png" : InPhoto.PostedFile.FileName, Convert.ToDateTime(txtdtarv.Text), new Etat(1), new Transmission(RBTransm.SelectedIndex),
                new Carburant(DDListCarbu.SelectedIndex), new Carrosserie(DDListCarro.SelectedIndex));

            Literal lit = new Literal();
            if (!((Modele)Session["CoucheModele"]).UpVehiculeVM(v))
            {
                lit.Text = "Le numéro du chassis de la voiture existe déjà ou des erreurs dans le formulaire";
                ct.Controls.Add(lit);
            }
            else
            {
                lit.Text = "Modification réussi";
                ct.Controls.Add(lit);
            }
        }

        // Méthode qui affiche le champs vitesse ou non si la transmission est manuelle
        protected void RBTransm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBTransm.SelectedItem.ToString() == "Manuelle")
                vitesseHide.Style.Add("display", "flex");
            else
                vitesseHide.Style.Add("display", "none");
        }

        // Méthode qui affiche le champs de la date d'entretion ou non si le controle entretien est oui
        protected void RBCtEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBCtEnt.SelectedItem.ToString() == "Oui")
                dtCtrlTechH.Style.Add("display", "flex");
            else
                dtCtrlTechH.Style.Add("display", "none");
        }

        /*
         * Méthode qui change les champs du formulaire de modification suivant l'id de la voiture select
         */
        protected void DDListId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicule v = null;
            try
            {
                
                if (DDListId.SelectedIndex == 0)
                    EnableForms(false);
                else
                {
                    v = ((Modele)Session["CoucheModele"]).GetVehiculeVM(DDListId.SelectedIndex);
                    EnableForms(true);
                    txtChassis.Text = v.NumChassis; 
                    txtNom.Text= v.Nom;
                    DDListMarque.SelectedIndex = v.Marque.IdMarque;
                    txtPuissance.Text = v.Puissance;
                    if (v.NbPortes == 3)
                        RBPortes.SelectedIndex = 0;
                    else
                        RBPortes.SelectedIndex = 1;
                    if (v.Transmission.NomTrans == "Manuelle")
                    { 
                        txtNbVitesse.Text = v.NbVitesse.ToString(); 
                        vitesseHide.Style.Add("display", "flex");
                    }
                    else
                        dtCtrlTechH.Style.Add("display", "none");
                    txtCylindres.Text = v.Cylindres.ToString();
                    txtCouleur.Text = v.Couleur;
                    txtKm.Text = v.Kilometrage.ToString();
                    txtAn.Text = v.Année.ToString("yyyy-MM-dd");
                    RBCtEnt.SelectedValue = v.CarnetEntretien;
                    if (v.CarnetEntretien == "Oui")
                    {
                        dtCtrlTechH.Style.Add("display", "flex");
                        dateCtrlTech.Text = v.DateCtrlTech.ToString("yyyy-MM-dd");
                    }
                    else
                        dtCtrlTechH.Style.Add("display", "none");
                    txtdtarv.Text = v.DateArrive.ToString("yyyy-MM-dd");
                    RBTrans.SelectedIndex = v.TypeTransaction;
                    txtPrix.Text = v.Prix.ToString();
                    txtReduct.Text = v.Reduction.ToString();
                    RBTransm.SelectedIndex = v.Transmission.IdTrans-1;
                    DDListCarbu.SelectedIndex = v.Carburant.IdCarbu;
                    DDListCarro.SelectedIndex = v.Carrosserie.IdCaros;                

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problème inattendu lors du listage!");
            }
        }

        // Méthode qui active ou non tous le champs du forms
        private void EnableForms(bool t)
        {
            txtChassis.Enabled = t;
            txtNom.Enabled = t;
            DDListMarque.Enabled = t;
            txtPuissance.Enabled = t;
                RBPortes.Enabled = t;
                txtNbVitesse.Enabled = t;
            txtCylindres.Enabled = t;
            txtCouleur.Enabled = t;
            txtKm.Enabled = t;
            txtAn.Enabled = t;
            dateCtrlTech.Enabled = t;
            RBCtEnt.Enabled = t;
                txtdtarv.Enabled = t;
            RBTrans.Enabled = t;
            txtPrix.Enabled = t;
            txtReduct.Enabled = t;
            RBTransm.Enabled = t;
            DDListCarbu.Enabled = t;
            DDListCarro.Enabled = t;
            btnUpCars.Enabled = t;
        }
    }
}