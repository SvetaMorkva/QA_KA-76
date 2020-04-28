Feature: Creating a HubSpot account
	I want to start using HubSpot,
	to do that I need to sign up

Scenario: Sign up
	Given I am on login page
	When I press on Sign up button
	Then I am taken to Sign up page
	And I enter my first name
	And I enter my last name
	And I enter my email address
	When I press Next
	Then I confirm my email 
