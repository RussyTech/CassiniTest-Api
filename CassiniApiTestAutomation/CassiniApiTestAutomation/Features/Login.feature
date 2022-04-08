Feature: Login

Test the register endpoint to ensure that user can successfully log in

Scenario: Successful Login
	Given I perform a POST request to the "/login" endpoint with Table
	| Email              | Password		|
	| eve.holt@reqres.in | cityslicka   |
	Then a "200" response is returned
	Then I should see the "token" as "QpwL5tke4Pnpja7X4"
