Feature: Creating a task
	As a user a want to create a task


Scenario: Create a task
	Given I am a registered user and I am logged in
	And I am on Tasks page 
	When I press Create task button
	And I add Task Title
	And I add Type
	And I add Priority
	When I press Create
	Then the task in my Tasks list and it's due 3 business days
