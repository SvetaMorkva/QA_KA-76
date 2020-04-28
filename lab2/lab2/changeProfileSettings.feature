Feature: Changing profile settings
	I am a user and I have a mistake or smth blank
	in my phofile so I want to change this


Scenario: Change profile name
	Given I am logged in
	And I am on Settings page
	When I press Conversation
	Then there is a drop box with Filtering rules, Indoxes, My profile
	And I press My plofile
	When I press on my name
	Then I am taken to the new tab with setting across all accounts
	And I press a pencil right to my name
	And I alter my First name
	And I alter my Last name
	When I press Save
	Then my name is changed


Scenario: Change profile photo
	Given I am logged in
	And I am on Settings page
	When I press Conversation
	Then there is a drop box with Filtering rules, Indoxes, My profile
	And I press My plofile
	When I press on my name
	Then I am taken to the new tab with setting across all accounts
	And I press on my photo
	And I press Upload image
	And I press Choose photo
	And I choose some image from my computer
	When I press Save
	Then my profile picture is changed
