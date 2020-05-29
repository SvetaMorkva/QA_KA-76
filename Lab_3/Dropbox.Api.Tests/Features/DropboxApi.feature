Feature: TestDropbox
	
@Get
Scenario: Get all files
	When I try to get list of all existing files
	Then I should get valid list of files

@Upload
Scenario: Upload a file
	Given I have 'IDA_Lab_5.pdf' file to upload
	When I upload the file
	| Path		     | Mode | AutoRename | Mute  |
	| /IDA_Lab_5.pdf | add  | true       | false |
	Then I should be able to get file info
	| Name          |
	| IDA_Lab_5.pdf |

@Get
Scenario: Get file metadata
	When I want to get file 'IDA_Lab_5.pdf' metadata
	Then I should be given valid file 'IDA_Lab_5.pdf' metadata