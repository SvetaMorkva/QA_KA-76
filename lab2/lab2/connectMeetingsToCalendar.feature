Feature: Connecting meetings to calendar
	I am a user and I want myself and my team to
	book meetings througth a calendar calendar we
	use (for ex. Google calendar)

Scenario: Connect meetings to Google calendar
	Given I am logged in user
	And I am on Meetings page
	When I press Connect to your Google calendar
	And I press Accept (Product Privacy Policy)
	And I choose my google account to connect to HubSpot with
	And I press Allow (HubSpot to connect to my Google account)
	And I press ok button on HubSpot
	Then I can setup meetings
