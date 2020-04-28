Feature: Connect inbox
	I am a user. In order to view and respond to my emails/messages 
	straight from inbox I need to connect email/chat to inbox


Scenario: Connect personal gmail to inbox
	Given I am logged in
	And I am on Inbox page
	And I haven't connected anything to inbox yet
	When I press Email
	Then I press No, this is a personal email
	When I press Connect a personal email
	Then I am on Email integrations panel in Settings
	And I press Connect an inbox
	And I choose Google as my email provider
	And I press Continue
	When I press Allow
	Then my personal email is connected to HubSpot
