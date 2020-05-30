Feature: GetFileList

@Get
Scenario: 1 Get file metadata
	Given I have file 'MyPdf.pdf' in Dropbox
	| Path        | Mode | AutoRename | Mute  |
	| /MyFile.pdf | add  | true       | false |
	When I get the file metadata
	Then I should be able to get file info
