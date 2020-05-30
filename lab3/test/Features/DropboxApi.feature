Feature: GetFileList
	
@Get
Scenario: Get all files
	When I try to get list of all existing files
	Then I should get valid list of files

@Upload
Scenario: Upload a file
	Given I have 'data.txt' file to upload
	When I upload the file
	| Path        | Mode | AutoRename | Mute  |
	| /data.txt   | add  | true       | false |
	Then I should be able to get file info
	| Name       |
	| data.txt   |