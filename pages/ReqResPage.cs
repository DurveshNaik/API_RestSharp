using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TestAssignmentProject.models;
using TestAssignmentProject.utilities;

namespace TestAssignmentProject.pages
{
    public class ReqResPage
    {
        public ResponseInfo callPostCreateUserApi(string url, JObject testSpecificData)
        {
            JObject queryStringParams = (JObject)testSpecificData["requestInfo"]["queryString"];
            JObject requestBody = (JObject)testSpecificData["requestInfo"]["requestBody"];
            //JObject requestInfo
            return RestSharpUtility.callPostAPI(url, queryStringParams, requestBody);
        }

        public bool ValidateUserCreatedResponse(JObject expectedResponse, JObject actualResponse)
        {
            if (((string)expectedResponse["name"] == (string)actualResponse["name"]) &&
                ((string)expectedResponse["job"] == (string)actualResponse["job"]) &&
                (!String.IsNullOrEmpty((string)actualResponse["id"])) &&
                (!String.IsNullOrEmpty((string)actualResponse["job"])))
                return true;
            return false;
        }
    }
}
