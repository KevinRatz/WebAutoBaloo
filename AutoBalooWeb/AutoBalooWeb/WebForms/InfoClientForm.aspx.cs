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

        }
        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu2");
            //string tel = txtUser.Text;
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string adresse = txtAdd.Text;
            string tel = txtTel.Text;
            string email = txtEmail.Text;
            string mdp = txtPwd.Text;
            string cfmdp = txtConfirmPassword.Text;
            Literal lit = new Literal();
            if (mdp != cfmdp)
            {
                lit.Text = "Mot de passe différent";
                ct.Controls.Add(lit);
            }
            else if (((Modele)Session["CoucheModele"]).AddClientVM(new Client(nom, prenom, adresse, tel, email, mdp)))
                //        Response.Redirect("MainPage.aspx");
                //Session["UserId"] = id;
                //Response.Write("<script>alert('login successful');</script>");
                FormsAuthentication.RedirectFromLoginPage(email, true);
            else
            {
                //cph.Controls.Add(new LiteralControl("Email existant"));
                lit.Text = "Email existant";
                ct.Controls.Add(lit);
            }
        }
    }
}