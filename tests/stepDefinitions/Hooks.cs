using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestAssignmentProject.utilities;
using TestAssignmentProject.models;
using Newtonsoft.Json.Linq;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace TestAssignmentProject.tests.stepDefinitions
{
    [Binding]
    public class TestContext
    {
        public Configs configs { get; set; }
        public RestInfo execInfo { get; set; }
        public JObject testData { get; set; }
        public ScenarioDetails scenariodetails { get; set; }
    }

    [Binding]
    public class Hooks
    {
        public IWebDriver driver;

        public TestContext testContext;
        public ScenarioContext scenarioContext;

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public Hooks(TestContext testContext, ScenarioContext scenarioContext)
        {
            this.testContext = testContext;
            this.scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {
            //Initialize the Report
            string reportLocation = System.IO.Path.GetFullPath(@"..\..\..\testReports\ExtentReport.html");
            var htmlReporter = new ExtentHtmlReporter(reportLocation);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.ReportName = "Automation Test Report";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //driver = WebDriverFactory.getDriver();
            //scenarioContext["driver"] = driver;

            testContext.configs = ConfigReader.GetGlobalConfigs();
            string scenarioTag = scenarioContext.ScenarioInfo.Tags[0];
            testContext.scenariodetails = new ScenarioDetails
            {
                featureName = scenarioTag.Split("_")[0],
                scenarioId = scenarioTag.Split("_")[1],
                title = scenarioContext.ScenarioInfo.Title
            };

            JObject scenarioData = fileOperations.GetScenarioSpecificTestData(scenarioTag.Split("_")[0]);
            testContext.testData = scenarioData[scenarioTag.Split("_")[1]] as JObject;

            //to capture feature and scenario in extent report
            featureName = extent.CreateTest<Feature>(scenarioTag);
            scenario = featureName.CreateNode<Scenario>(testContext.scenariodetails.title);
        }

        [AfterScenario]
        public void InsertTestRunLogs()
        {
            scenario.Info("Http Status Code : " + testContext.execInfo.responseInfo.statusCode.ToString());
            scenario.Info("Response body : " + testContext.execInfo.responseInfo.responseBody);
            scenario.Log(Status.Pass);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var StepInfo = scenarioContext.StepContext.StepInfo.Text;
            var testError = scenarioContext.TestError;

            if (testError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(StepInfo);
                else if (stepType == "When")
                    scenario.CreateNode<When>(StepInfo);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(StepInfo);
                else if (stepType == "And")
                    scenario.CreateNode<And>(StepInfo);
            }
            else if (testError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(StepInfo).Fail(testError.InnerException);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(StepInfo).Fail(testError.InnerException);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(StepInfo).Fail(testError.Message);
                }
            }
        }
    }
}
