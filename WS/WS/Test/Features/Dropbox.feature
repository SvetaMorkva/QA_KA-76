Feature: Dropbox
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Get
Scenario: 1 Get file metadata
	Given I have file 'MyPdf.pdf' in Dropbox
	| Path        | Mode | AutoRename | Mute  |
	| /MyFile.pdf | add  | true       | false |
	When I get the file metadata
	Then I should be able to get file info

@Delete
Scenario: 2 Delete file
	Given I have file 'MyPdf.pdf' in Dropbox
	| Path        | Mode | AutoRename | Mute  |
	| /MyFile.pdf | add  | true       | false |
	When I delete the file
	Then I should be able to get file info
