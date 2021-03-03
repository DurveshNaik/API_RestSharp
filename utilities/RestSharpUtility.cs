using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using TestAssignmentProject.models;

namespace TestAssignmentProject.utilities
{
    public class RestSharpUtility
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static ResponseInfo callGetAPI(string url, JObject queryStrings)
        {
            ResponseInfo responseInfo = null;

            RestClient client = new RestClient(GenerateAPIURL(url, queryStrings));
            RestRequest request = new RestRequest(Method.GET);

            try
            {
                RestResponse response = (RestResponse)client.Execute(request);

                responseInfo = new ResponseInfo
                {
                    statusCode = (int)response.StatusCode,
                    responseBody = JObject.Parse(response.Content)
                };

                log.Info("Response Body : " + responseInfo.responseBody);
            }
            catch (Exception e)
            {
                log.Error("Error while making a get call" + e);
            }

            return responseInfo;
        }

        public static ResponseInfo callPostAPI(string url, JObject queryStrings, JObject requestBody)
        {
            ResponseInfo responseInfo = null;

            RestClient client = new RestClient(GenerateAPIURL(url, queryStrings));
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);

            try
            {
                RestResponse response = (RestResponse)client.Execute(request);

                responseInfo = new ResponseInfo
                {
                    statusCode = (int)response.StatusCode,
                    responseBody = JObject.Parse(response.Content)
                };

                log.Info("Response Body : " + responseInfo.responseBody);
            }
            catch (Exception e)
            {
                log.Error("Error while making a post call" + e);
            }

            return responseInfo;
        }

        public static string GenerateAPIURL(string baseUrl, JObject queryStringParams)
        {
            if (queryStringParams.Count > 0)
            {
                baseUrl += "?";
                foreach (var item in queryStringParams)
                {
                    baseUrl += item.Key + "=" + item.Value + "&";
                }

                baseUrl = baseUrl.Remove(baseUrl.Length - 1, 1).ToString();
            }

            log.Info("URL used : " + baseUrl);

            return baseUrl;
        }
    }
}
