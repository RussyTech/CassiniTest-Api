Feature: Register

Test the register endpoint to ensure that user can successfully register

Scenario: Successful Register
	Given I perform a POST request to the "/register" endpoint with Table
	| Email              | Password |
	| eve.holt@reqres.in | pistol   |
	Then a "200" response is returned
	Then I should see the "id" as "4"
	#Then I should see the "token" as "QpwL5tke4Pnpja7X4"

Scenario: Successful Register using Json
	
	Given I perform a POST request to the "/register" endpoint with Jason data
	Then a "200" response is returned
	Then I should see the "id" as "4"

Scenario: Successful Register using csv file
	
	Given I perform a POST request to the "/register" endpoint with csv file
	Then a "200" response is returned
	#Then I should see the "id" as "4"