using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoBalooWeb.CoucheAccesDB;
using AutoBalooWeb.CoucheModele;
using AutoBalooWeb.ClasseMetiers;
using System.Web.Security;

namespace AutoBalooWeb.WebForms
{
    public partial class InfoClientForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
        protected void BtnUpClient_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string adresse = txtAdd.Text;
            string tel = txtTel.Text;
            string email = txtEmail.Text;
            string mdp = txtPwd.Text;
            string cfmdp = txtConfirmPassword.Text;
            Literal lit = new Literal();
            //
            if (mdp != cfmdp)
            {
                lit.Text = "Email ou mot de passe incorrect";
                ct.Controls.Add(lit);
            }
            //else if (((Modele)Session["CoucheModele"]).UpClientVM(new Client(nom, prenom, adresse, tel, email, mdp)))
                //        Response.Redirect("MainPage.aspx");
                //Session["UserId"] = id;
                //Response.Write("<script>alert('login successful');</script>");
                //FormsAuthentication.RedirectFromLoginPage(email, true);
            else
            {
                lit.Text = "Email ou mot de passe incorrect";
                ct.Controls.Add(lit);
            }
        }
    }
}