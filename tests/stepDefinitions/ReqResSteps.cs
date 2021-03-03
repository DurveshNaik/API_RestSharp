using TechTalk.SpecFlow;
using TestAssignmentProject.pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using TestAssignmentProject.models;

namespace TestAssignmentProject.tests.stepDefinitions
{
    [Binding]
    public class ReqResSteps
    {
        public TestContext testContext;
        public ReqResPage reqResPage;
        public ReqResSteps(TestContext testContext)
        {
            this.testContext = testContext;
        }

        [Given(@"I call a ReqRes post api to create a new user")]
        public void GivenICallAReqResPostApiToCreateANewUser(Table table)
        {
            string testCase = table.Rows[0]["testCase"];
            this.testContext.scenariodetails.testCaseId = testCase;

            reqResPage = new ReqResPage();
            JObject testSpecificData = (JObject)this.testContext.testData[testCase];
            this.testContext.execInfo = new RestInfo
            {
                responseInfo = reqResPage.callPostCreateUserApi(testContext.configs.ReqResCreateUserPostApiUrl, testSpecificData)
            };
        }

        [Then(@"I validate http status code in the response")]
        public void ThenIValidateHttpStatusCodeInTheResponse()
        {
            Assert.AreEqual(this.testContext.execInfo.responseInfo.statusCode, 201, "Status code mismatch");
        }

        [Then(@"I validate the response content")]
        public void ThenIValidateTheResponseContent()
        {
            JObject actualResponse = this.testContext.execInfo.responseInfo.responseBody;
            Assert.IsNotNull(actualResponse, "API response is null");
            string testCaseId = this.testContext.scenariodetails.testCaseId;
            JObject expectedResponse = (JObject)this.testContext.testData[testCaseId]["requestInfo"]["requestBody"];
            Assert.IsTrue(reqResPage.ValidateUserCreatedResponse(expectedResponse, actualResponse));
        }

    }
}
