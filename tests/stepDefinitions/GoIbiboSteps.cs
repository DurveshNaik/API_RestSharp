using TechTalk.SpecFlow;
using TestAssignmentProject.pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using TestAssignmentProject.models;

namespace TestAssignmentProject.tests.stepDefinitions
{
    [Binding]
    class GoIbiboSteps
    {
        public TestContext testContext;
        public GoIbiboPage goIbiboPage;
        public GoIbiboSteps(TestContext testContext)
        {
            this.testContext = testContext;
        }

        [Given(@"I call a goIbibo get api for airport suggestion")]
        public void GivenICallAGoIbiboGetApiFor(Table table)
        {
            string testCase = table.Rows[0]["testCase"];
            this.testContext.scenariodetails.testCaseId = testCase;

            goIbiboPage = new GoIbiboPage();
            JObject testSpecificData = (JObject)this.testContext.testData[testCase];
            this.testContext.execInfo = new RestInfo
            {
                responseInfo = goIbiboPage.callGetAirportSearchApi(testContext.configs.GoIbiboAirportSearchGetApiUrl, testSpecificData)
            };
        }

        [Then(@"I validate http status code")]
        public void ThenIValidateStatusCode()
        {
            Assert.AreEqual(this.testContext.execInfo.responseInfo.statusCode, 200, "Status code mismatch");
        }

        [Then(@"I validate search suggestions in response")]
        public void ThenIValidateSearchSuggestionsInResponse()
        {
            JObject actualResponse = this.testContext.execInfo.responseInfo.responseBody;
            Assert.IsNotNull(actualResponse, "API response is null");
            string testCaseId = this.testContext.scenariodetails.testCaseId;
            JObject expectedResponse = (JObject)this.testContext.testData[testCaseId]["responseInfo"]["expectedResponse"];
            Assert.IsTrue(goIbiboPage.ValidateSearchSuggestionsInResponse(expectedResponse, actualResponse));
        }
    }
}
