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
                //List<Categorie> liste = ((CoucheModele)Session["CoucheModele"]).ListCategories();

                //DropDownList1.DataSource = liste;
                //DropDownList1.DataBind();
            }
            }
            protected void BtnUpCars_Click(object sender, EventArgs e)
        {
            //string nom = txtNom.Text;
            //string prenom = txtChassis.Text;
            //string adresse = txtCouleur.Text;
            //string tel = txtCtEntretien.Text;
            //string email = txtCylindres.Text;
            //string email = txtdtarv.Text;
            //string email = txtKm.Text;
            //string email = txtNbPortes.Text;
            //string email = txtNbVitesse.Text;
            //string mdp = DDLCarbu.Text;
            //string cfmdp = DDListCarro.Text;
            //string cfmdp = DDListMarque.Text;
            //string cfmdp = txtPuissance.Text;
            //string cfmdp = RBCtEnt.Text;
            //string cfmdp = RBPortes.Text;
            //string cfmdp = RBTransm.Text;
            //string cfmdp = dateCtrlTech.Text;
            //if (((Modele)Session["CoucheModele"]).UpCarsVM(new Client(nom, prenom, adresse, tel, email, mdp)))


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
    }
}