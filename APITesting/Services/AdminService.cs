using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APITesting.Services
{
    public class AdminService
    {
        //https://api-sandbox.orangehrm.com/oauth/issueToken
        public static string AdminAuthen()
        {

            string userRegisterEndPoint = "https://api-sandbox.orangehrm.com/oauth/issueToken";
            var client = new RestClient(userRegisterEndPoint);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new
            {
                client_id = "api-client",
                client_secret = "942d36a36d6bf422a36f5871f905b6e5",
                grant_type = "client_credentials",
                username = "Admin",
                password = "admin123",
            });
            var response = client.Execute(request);
            string content = response.Content ?? "";
            var cookies = response.Cookies;
            var contentParseToJson = JsonConvert.DeserializeObject<JObject>(content);
            var token = contentParseToJson.Property("access_token").Value.ToString();

            /* var option = new CookieOptions
             {
                 Expires = DateTime.Now.AddMinutes(response.Cookies)
             };

             if (!string.IsNullOrEmpty(domain))
             {
                 option.Domain = domain;
             }

             Response.Cookies.Append({ cookiename}, response.AccessToken, option);*/
            if (response.IsSuccessful)
            {
                return token;
            }
            else
            {
                var errorMessage = response.ErrorMessage;
                throw new Exception(errorMessage);
            }

        }




    }
}
