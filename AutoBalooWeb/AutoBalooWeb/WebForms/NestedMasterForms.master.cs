using AutoBalooWeb.ClasseMetiers;
using AutoBalooWeb.CoucheModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoBalooWeb.WebForms
{
    public partial class NestedMasterForms : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                hi.InnerText = "Mon profil";
                btnSignup.Text = "Modifier";
                othersReg.Visible = false;
                Client c = ((Modele)Session["CoucheModele"]).GetClientVM(Page.User.Identity.Name);
                if(c.Admin==1)
                    Session["Admin"] = 1;
                txtNom.Text = c.Nom.ToString();
            }
            else
                othersReg.Visible = true;
        }
        protected void BtnSignup_Click(object sender, EventArgs e)
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
            else if (((Modele)Session["CoucheModele"]).AddClientVM(new Client(nom, prenom, adresse, tel, email, mdp)))
                //        Response.Redirect("MainPage.aspx");
                //Session["UserId"] = id;
                //Response.Write("<script>alert('login successful');</script>");
                FormsAuthentication.RedirectFromLoginPage(email, true);
            else
            {
                lit.Text = "Email ou mot de passe incorrect";
                ct.Controls.Add(lit);
            }
        }
        protected void BtnGgl_Click(object sender, EventArgs e)
        {
            string ClientId = "258872183646-54mter43i10k9k5hkk1pnf6bgm934pfp.apps.googleusercontent.com";
            string Scopes = "https://www.googleapis.com/auth/userinfo.email";
            //get this value by opening your web app in browser.    
            string RedirectUrl = "http://localhost:64428/WebForms/MainPage.aspx";
            string Url = "https://accounts.google.com/o/oauth2/auth?";
            StringBuilder UrlBuilder = new StringBuilder(Url);
            UrlBuilder.Append("client_id=" + ClientId);
            UrlBuilder.Append("&redirect_uri=" + RedirectUrl);
            UrlBuilder.Append("&response_type=" + "code");
            UrlBuilder.Append("&scope=" + Scopes);
            UrlBuilder.Append("&access_type=" + "offline");
            Response.Redirect(UrlBuilder.ToString());
        }

    }
}