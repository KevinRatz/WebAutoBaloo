using AutoBalooWeb.ClasseMetiers;
using AutoBalooWeb.CoucheModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoBalooWeb.WebForms
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("MainPage.aspx");
            }
        }
        protected void ValidateUser(object sender, AuthenticateEventArgs e)
        {
            string id = ((Modele)Session["CoucheModele"]).ValidateUserVM(Login1.UserName, Login1.Password);

            if (id == "invalid")
                Login1.FailureText = "Email et/ou mot de passe incorrect.";
            else
            {
                Client cliSess = ((Modele)Session["CoucheModele"]).GetClientVM(Login1.UserName);
                if (cliSess != null)
                    Session["Client"] = cliSess;
                //Session["UserId"] = id;
                //Session["Connected"] = 1;
                //Response.Write("<script>alert('login successful');</script>");
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                FormsAuthentication.SetAuthCookie(Login1.UserName, true);
            }
        }
        protected bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid email format.
            return Regex.IsMatch(strIn, @"^([\w\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        protected void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
            if (!IsValidEmail(Login1.UserName))
            {
                Login1.InstructionText = "Entrer un email valide.";
                Login1.InstructionTextStyle.ForeColor = System.Drawing.Color.RosyBrown;
                e.Cancel = true;
            }
            else
            {
                Login1.InstructionText = String.Empty;
            }
        }

        protected void OnLoginError(object sender, EventArgs e)
        {
            //Login1.HelpPageText = "Help with logging in...";
            //Login1.PasswordRecoveryText = "Forgot your password?";
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
            UrlBuilder.Append("&state=" + "signin");
            Response.Redirect(UrlBuilder.ToString());
        }
    }
}