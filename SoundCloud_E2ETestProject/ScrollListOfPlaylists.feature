Feature: ScrollListOfPlaylists
	In order to find new music playlists
	As a user
	I want to use a popular list of music playlists

@mytag
Scenario: Searching for a popular list of music playlists
	Given I have gone to the Home page
	And I have scrolled down the page
	And I have found an interesting ganer of playlist
	When I press the scrallPlaylistToTheRightButton
	Then I see another few playlists of this genre
