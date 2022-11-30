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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            string tel = txtUser.Text;
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string adresse = txtAdd.Text;
            string email = txtEmail.Text;
            string mdp = txtPassword.Text;
            string cfmdp = txtConfirmPassword.Text;
            if (mdp == cfmdp)
                if (((Modele)Session["CoucheModele"]).AddClientVM(new Client(nom, prenom, adresse,tel, email, mdp)))
                    Response.Redirect("MainPage.aspx");
                else
                    Console.WriteLine("Confirm mdp incorrect");
        }
    }
}