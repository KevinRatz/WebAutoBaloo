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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // si connecté, retour main page
            if (Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("MainPage.aspx");
            }
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
            //si mot de passe et confirmation différent
            if (mdp != cfmdp)
            {
                lit.Text = "Les mot de passe ne correspondent pas";
                ct.Controls.Add(lit);
            }
            else
            {
                Client cliSess = new Client(nom, prenom, adresse, tel, email, mdp);
                //si ajout réussi, retour main page sinon existant
                if (((Modele)Session["CoucheModele"]).AddClientVM(cliSess,false))
                {
                    if (cliSess != null)
                        Session["Client"] = cliSess;
                    FormsAuthentication.RedirectFromLoginPage(email, true);
                }
                else
                {
                    lit.Text = "Email ou mot de passe incorrect";
                    ct.Controls.Add(lit);
                }
            }
        }
        protected void BtnGgl_Click(object sender, EventArgs e)
        {
            string ClientId = "258872183646-54mter43i10k9k5hkk1pnf6bgm934pfp.apps.googleusercontent.com";
            string Scopes = "https://www.googleapis.com/auth/userinfo.email";
            //get this value by opening your web app in browser.    
            string RedirectUrl = "http://localhost:64428/WebForms/GoogleCallBack.aspx";
            string Url = "https://accounts.google.com/o/oauth2/auth?";
            StringBuilder UrlBuilder = new StringBuilder(Url);
            UrlBuilder.Append("client_id=" + ClientId);
            UrlBuilder.Append("&redirect_uri=" + RedirectUrl);
            UrlBuilder.Append("&response_type=" + "code");
            UrlBuilder.Append("&scope=" + Scopes);
            UrlBuilder.Append("&access_type=" + "offline");
            UrlBuilder.Append("&state=" + "signup");
            Response.Redirect(UrlBuilder.ToString());
        }
    }
}