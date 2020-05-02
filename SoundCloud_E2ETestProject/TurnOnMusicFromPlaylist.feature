Feature: TurnOnMusicFromPlaylist
	In order to listen music
	As a user
	I want to turn on a song from a playlist 

@mytag
Scenario: Turn a song on from a playlist
	Given I have open the playlist
	And I have scroll down to find the song
	When I press the playButtton
	Then the song is turn on
