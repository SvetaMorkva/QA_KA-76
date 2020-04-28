Feature: Adding tickets
	I am a user and I want to add create
	and manage tickets


Scenario: Add 2 high priority tickets
	Given I am logged in
	And I am on Tickets page
	When I press Create ticket
	Then I add ticket name
	And I set priority as High
	When I press Create and add another
	Then I am taken to Create ticket again
	And I add ticket name
	And I set priority as High
	When I press Create
	Then 2 tickets are created

