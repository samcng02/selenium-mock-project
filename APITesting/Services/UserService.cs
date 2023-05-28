using APITesting.APIHelper;
using APITesting.Models;


namespace APITesting.Controllers
{
    public class UserService
    {
        /*public static int UserRegister1()
        {
            string userRegisterEndPoint = "/api/register";
            var client = new RestClient($"{Controllers.systemURL}{userRegisterEndPoint}");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new
            {
                email = "eve.holt@reqres.in",
                password = "pistol"
            });
            var response = client.ExecutePost(request);
            if (response.IsSuccessful)
            {
                return (int)response.StatusCode;
            }
            else
            {
                var errorMessage = response.ErrorMessage;
                throw new Exception(errorMessage);
            }
        }


        public static AllUser GetAllUsers1()
        {
            string userRegisterEndPoint = "https://reqres.in/api/users";
            var client = new RestClient(userRegisterEndPoint);
            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);
            string content = response.Content ?? "";
            var uses = JsonConvert.DeserializeObject<AllUser>(content);
            if (response.IsSuccessful)
            {
                return uses ?? new AllUser();
            }
            else
            {
                var errorMessage = response.ErrorMessage;
                throw new Exception(errorMessage);
            }
        }*/


        public static AllUser GetAllUsers()
        {
            var result = ApiHelper.Instance.Get<AllUser>("users");
            return result;
        }

        public static int UserRegister()
        {
            var obj = new
            {
                email = "eve.holt@reqres.in",
                password = "pistol"
            };
            var result = ApiHelper.Instance.Post<object>("register", obj);
            if (result != null)
            {
                return 200;
            }
            return -1;


        }
    }
}
