using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace TestAssignmentProject.models
{
    public class RestInfo
    {
        public RequestInfo requestInfo { get; set; }
        public ResponseInfo responseInfo { get; set; }
    }

    public class RequestInfo
    {
        public string baseUrl { get; set; }

        public string requestMethod { get; set; }
        public Dictionary<string, string> queryStrings { get; set; }
        public Dictionary<string, string> headers { get; set; }

        public JObject requestBody { get; set; }

    }

    public class ResponseInfo
    {
        public int statusCode { get; set; }
        public JObject responseBody { get; set; }
    }

    //public class JsontoClass
    //{
    //    public static T Deserialize<T>(string json)
    //    {
    //        JsonSerializer s = new JsonSerializer();
    //        return s.Deserialize<T>(new JsonTextReader(new StringReader(json)));
    //    }
    //}
}
