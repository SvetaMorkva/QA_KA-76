Feature: SelectUserWhoLikedTheTrack
	In order to find users who like a track
	As a user
	I want to see users who liked the track

@mytag
Scenario: Show users who have liked a track
	Given I have opened the track
	When I have pressed the LikeScoreLink
	Then I see all users who liked track

@mytag
Scenario: Select a user who liked a track
	Given I have opened the UserWhoLikedTheTrackPage
	And I have scrolled page to browse more users
	When I press on a user icon
	Then I open the user's page
