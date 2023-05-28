using RestSharp;

namespace APITesting.APIHelper
{


    // [Serializable] is used toindicate that a class can be serialized and deserialized into a binary or other data formats (such as XML or JSON).
    // This allows objects of the class to be converted into a format that can be stored, transmitted over a network, or used in different scenarios.
    [Serializable]
    public record class WebApiParam : Parameter
    {
        public WebApiParam(string name, object value) : base(name, value, ParameterType.QueryString, true)
        {

        }
        public WebApiParam(string name, object value, ParameterType type) : base(name, value, type, true)
        {

        }
    }
}
