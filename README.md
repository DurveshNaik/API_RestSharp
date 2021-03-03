API Automation:

Get API used
	GoIbibo's Airport suggestion GET api based on the location passed.

Post API used
	ReqRes's Create user POST api.
	
	
Tools used:

Framework: Dot net core 3.1

Testing Framework used: MsTest

Nuget packages used:

	RestSharp : HTTP client library for .NET. used for making api calls like get, post etc.
	
	Specflow : Framework used to implement behavioural driven development.
	
	Log4Net : library used to implement logging mechanism throughout the project.
	
	ExtentReports : used for creating dynamic html test execution report.
	
	Newtonsoft Json : library to deal with JSON objects.

Framework :

	It's a hybrid test framework with Behavioural Driven apporach used to write testcases.
	
	Feature files : Scenario's are written feature files in plain english domain language (Gherkin) so that it is easy to understand. Each scenario is tagged with a unique Scenario Id.
	
	Step Definition files: feature file has corresponding step definition file which has respective methods invoked on scenario execution.
	
	Test data files : Each feature file has its corresponding test data file in JSON format. It has required testdata which can be read using ScenarioId and TestcaseId sent from feature file.
	
	Page files : Page object model is implement. Although it is more relevant to UI test framework, every API feature file has its corresponding page file. This file contains all methods to make the API call with required test data.
	
	models : this directory holds all the classes to make the framework type rich.
	
	Utilities : This directory contains all generic/common utilities which are used accross project. RestSharp utility is created to make Get and Post API calls in standard way.
	
	Configurations : All the URL's are kept in appsettings.json at root level and are read in BeforeTest hook to be used anytime.
	
	TextContext : This class is used along with ScenarioContext to share data between scenario steps. TextContext has properties which holds API request/response, Scenario specific information which are shared while executing any scenario.
	
	testReports : Dynamic html test report is generated in this directory at the end of execution. Extent reports library used for that purpose.
	
	RunTests.bat : has commands to start the test execution from command prompt.