Feature: ReqRes
	Calling Post api and validating the response

@ReqRes_sc001
Scenario: Calling create user Post api of ReqRes and validating the response
	Given I call a ReqRes post api to create a new user
		| testCase   |
		| <testCase> |
	Then I validate http status code in the response
	And I validate the response content

	Examples:
		| testCase |
		| tc001    |
		| tc002    |