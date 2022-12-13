using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using System.Web.Security;
using AutoBalooWeb.ClasseMetiers;
using AutoBalooWeb.CoucheModele;

namespace AutoBalooWeb.WebForms
{
    public partial class GoogleCallBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Error = Request.QueryString["error"];
            //authorization code after successful authorization    
            string Code = Request.QueryString["code"];
            if (Error != null) { }
            else if (Code != null)
            {
                string AccessToken = string.Empty;
                string RefreshToken = ExchangeAuthorizationCode(Code, out AccessToken);
                //saving refresh token in database    
                //SaveRefreshToken(Id, RefreshToken);
                //Get Email Id of the user    
                string emailId = FetchEmailId(AccessToken);
                string etat = Request.QueryString["state"];
                Client cliSess = ((Modele)Session["CoucheModele"]).GetClientVM(emailId);
                
                if (cliSess != null && cliSess.Password=="")
                {
                    //Redirect the user to MainPage.aspx avec email connecté
                    FormsAuthentication.SetAuthCookie(emailId, false);
                    if (cliSess != null)
                        Session["Client"] = cliSess;
                    Response.Redirect("MainPage.aspx", true); 
                }
                else
                {
                    if (etat == "signup")
                    {
                        //Saving Email Id
                        ((Modele)Session["CoucheModele"]).AddClientVM(new Client(emailId), true);
                        //Redirect the user to MainPage.aspx avec email connecté
                        FormsAuthentication.SetAuthCookie(emailId, false);
                        Session["Client"] = new Client(emailId);
                        Response.Redirect("MainPage.aspx", true);
                    }
                    else
                        Response.Redirect("SignIn.aspx", true);
                }
            }
        }
        /***
         * Récupération du token du client inscrit avec Gmail
         */
        private string ExchangeAuthorizationCode(string code, out string accessToken)
        {
            accessToken = string.Empty;
            string ClientSecret = "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";
            string ClientId = "258872183646-54mter43i10k9k5hkk1pnf6bgm934pfp.apps.googleusercontent.com";
            //get this value by opening your web app in browser.    
            string RedirectUrl = "http://localhost:64428/WebForms/GoogleCallBack.aspx";
            var Content = "code=" + code + "&client_id=" + ClientId + "&client_secret=" + ClientSecret + "&redirect_uri=" + RedirectUrl + "&grant_type=authorization_code";
            var request = WebRequest.Create("https://accounts.google.com/o/oauth2/token");
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(Content);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            var Response = (HttpWebResponse)request.GetResponse();
            Stream responseDataStream = Response.GetResponseStream();
            StreamReader reader = new StreamReader(responseDataStream);
            string ResponseData = reader.ReadToEnd();
            reader.Close();
            responseDataStream.Close();
            Response.Close();
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                var ReturnedToken = JsonSerializer.Deserialize<Token>(ResponseData);
                if (ReturnedToken.refresh_token != null)
                {
                    accessToken = ReturnedToken.access_token;
                    return ReturnedToken.refresh_token;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return string.Empty;
            }
        }
        //private void SaveRefreshToken(int userId, string refreshToken)
        //{
        //    SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        //    string Query = "insert into Member (UserId,RefreshToken) values(" + userId + ",'" + refreshToken + "')";
        //    SqlCommand Cmd = new SqlCommand(Query, Con);
        //    Con.Open();
        //    int Result = Cmd.ExecuteNonQuery();
        //    Con.Close();
        //}

        /***
         * Récupération de l'email du client inscrit avec Gmail grace à son token
         */
        private string FetchEmailId(string accessToken)
        {
            var EmailRequest = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + accessToken;
            // Create a request for the URL.    
            var Request = WebRequest.Create(EmailRequest);
            // Get the response.    
            var Response = (HttpWebResponse)Request.GetResponse();
            // Get the stream containing content returned by the server.    
            var DataStream = Response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.    
            var Reader = new StreamReader(DataStream);
            // Read the content.    
            var JsonString = Reader.ReadToEnd();
            // Cleanup the streams and the response.    
            Reader.Close();
            DataStream.Close();
            Response.Close();
            MyData deptObj = JsonSerializer.Deserialize<MyData>(JsonString);
            return deptObj.email;// email;
        }
    }
    public class MyData
    {
        public string email { get; set; }
        public string name { get; set; }
    }
    public class Token
    {
        public string access_token
        {
            get;
            set;
        }
        public string token_type
        {
            get;
            set;
        }
        public int expires_in
        {
            get;
            set;
        }
        public string refresh_token
        {
            get;
            set;
        }
    }
}