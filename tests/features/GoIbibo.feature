Feature: GoIbibo
	Verifying Get api and validating the response

@GoIbibo_sc001
Scenario: Validate airport search suggestions using a goIbibo get api for a specific location
	Given I call a goIbibo get api for airport suggestion
		| testCase   |
		| <testCase> |
	Then I validate http status code
	And I validate search suggestions in response

	Examples:
		| testCase |
		| tc001    |
