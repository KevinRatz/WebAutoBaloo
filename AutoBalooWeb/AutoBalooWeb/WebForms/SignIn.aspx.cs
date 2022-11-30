using AutoBalooWeb.CoucheModele;
using System;
using System.Collections.Generic;
using System.Linq;
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

        }
        protected void ValidateUser(object sender, AuthenticateEventArgs e)
        {
            string id = ((Modele)Session["CoucheModele"]).ValidateUserVM(Login1.UserName, Login1.Password);

            if (id == "invalid")
                Login1.FailureText = "Username and/or password is incorrect.";
            else
            {
                Session["UserId"] = id;
                Session["Connected"] = 1;
                Response.Write("<script>alert('login successful');</script>");
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                FormsAuthentication.SetAuthCookie(Login1.UserName, true);
            }
        }
    }
}