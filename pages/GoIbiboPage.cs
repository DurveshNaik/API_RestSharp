using TestAssignmentProject.utilities;
using TestAssignmentProject.models;
using Newtonsoft.Json.Linq;

namespace TestAssignmentProject.pages
{
    public class GoIbiboPage
    {
        public ResponseInfo callGetAirportSearchApi(string url, JObject testSpecificData)
        {
            JObject queryStringParams = (JObject)testSpecificData["requestInfo"]["queryString"];
            //JObject requestInfo
            return RestSharpUtility.callGetAPI(url, queryStringParams);
        }

        public bool ValidateSearchSuggestionsInResponse(JObject expectedResponse, JObject actualResponse)
        {
            foreach (var expAirport in expectedResponse["SearchSuggestions"])
            {
                bool flag = false;
                foreach (var airportObj in actualResponse["data"]["r"])
                {
                    if (expAirport.ToString() == airportObj["n"].ToString())
                        flag = true;
                }
                if (!flag) return false;
            }
            return true;
        }

    }
}
