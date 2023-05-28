using Newtonsoft.Json;
using RestSharp;

namespace APITesting.APIHelper
{
    public class ApiHelper
    {

        private readonly RestClient _client;
        private static ApiHelper _instance;
        //private static string baseUrl = ConfigurationHelper.GetValue<string>("baseUrl");
        private static string baseUrl = "https://api-sandbox.orangehrm.com/oauth/issueToken";


        //Singleton
        public static ApiHelper Instance = _instance ?? (_instance = new ApiHelper(baseUrl));


        public ApiHelper()
        {
        }

        public ApiHelper(string baseUrl, Dictionary<string, string> headers = null)
        {
            // Init:
            _client = new RestClient(baseUrl);
            // Add header:
            _client.AddDefaultHeader("Content-Type", "application/json");
            AddHeader(headers);
        }

        /// <summary>
        /// Method used to support add header:
        /// </summary>
        /// <param name="headers"></param>

        public void AddHeader(Dictionary<string, string> headers = null)
        {
            try
            {
                if (headers != null && _client != null)
                {
                    foreach (var item in headers.Keys)
                    {
                        string value = headers.TryGetValue(item, out var val) ? val : null;
                        if (!string.IsNullOrEmpty(value))
                        {
                            _client.AddDefaultHeader(item, value);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        public T Get<T>(string resource, params WebApiParam[] parameters)
        {
            return Execute<T>(resource, Method.Get, parameters);
        }

        /// <summary>
        /// Post method with multiple params
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T Post<T>(string resource, params WebApiParam[] parameters)
        {
            return Execute<T>(resource, Method.Post, parameters);
        }

        /// <summary>
        /// Post method with params is a object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public T Post<T>(string resource, object requestData) where T : new()
        {
            return Execute<T>(resource, Method.Post, requestData);
        }


        /// <summary>
        /// Method use to excute Method as Get, Post, Put, Delete, Path with param and multiple params
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private T Execute<T>(string resource, Method method, params WebApiParam[] parameters)
        {
            try
            {
                T? result = default;
                var request = new RestRequest(resource)
                {
                    RequestFormat = DataFormat.Json,
                    Method = method
                };

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        request.AddParameter(param);
                    }
                }

                var response = _client.Execute(request, method);
                var content = response.Content;

                if (response.IsSuccessful)
                {
                    result = string.IsNullOrEmpty(content) || content == "null" ? default(T) : JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    });
                }
                else
                {
                    result = default(T);
                }

                return result;
            }
            catch (Exception ex)
            {
                //todo log
                return default;
            }
        }

        /// <summary>
        /// Method use to excute Method as Get, Post, Put, Delete, Path have not  param
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        private T Execute<T>(string resource, Method method, object requestData)
        {
            try
            {
                T? result = default;
                var request = new RestRequest(resource)
                {
                    RequestFormat = DataFormat.Json,
                    Method = method
                };

                var json = JsonConvert.SerializeObject(requestData);
                request.AddParameter("text/json", json, ParameterType.RequestBody);

                var response = _client.Execute(request, method);
                var content = response.Content;

                if (response.IsSuccessful)
                {
                    result = string.IsNullOrEmpty(content) || content == "null" ? default(T) : JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    });
                }
                else
                {
                    result = default(T);
                }

                return result;
            }
            catch (Exception ex)
            {
                //todo log
                return default;
            }
        }
    }
}
