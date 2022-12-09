using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                //Remember, we have set userid in State    
                string UserId = Request.QueryString["state"];
                //Get AccessToken    
                int Id = Convert.ToInt32(UserId);
                string AccessToken = string.Empty;
                string RefreshToken = ExchangeAuthorizationCode(Id, Code, out AccessToken);
                //saving refresh token in database    
                SaveRefreshToken(Id, RefreshToken);
                //Get Email Id of the authorized user    
                string EmailId = FetchEmailId(AccessToken);
                //Saving Email Id    
                SaveEmailId(UserId, EmailId);
                //Redirect the user to Authorize.aspx with user id    
                string Url = "MainPage.aspx";
                Response.Redirect(Url, true);
            }
        }
        private void SaveRefreshToken(int userId, string refreshToken)
        {
            SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
            string Query = "insert into Member (UserId,RefreshToken) values(" + userId + ",'" + refreshToken + "')";
            SqlCommand Cmd = new SqlCommand(Query, Con);
            Con.Open();
            int Result = Cmd.ExecuteNonQuery();
            Con.Close();
        }
        private string FetchEmailId(string accessToken)
        {
            var EmailRequest = "https://www.googleapis.com/userinfo/email?alt=json&access_token=" + accessToken;
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
            dynamic json = JValue.Parse(JsonString);
            return json.data.email;
        }
        private bool SaveEmailId(string userId, string emailId)
        {
            SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
            string Query = "update Member set GmailId='" + emailId + "'where UserId='" + userId + "'";
            SqlCommand Cmd = new SqlCommand(Query, Con);
            Con.Open();
            int Result = Cmd.ExecuteNonQuery();
            Con.Close();
            return Result > 0 ? true : false;
        }
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
        public string expires_in
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