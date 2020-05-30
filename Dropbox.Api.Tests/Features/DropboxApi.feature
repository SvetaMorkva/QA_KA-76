Feature: GetFileList
	
@Get
Scenario: Get all files
	When I try to get list of all existing files
	Then I should get valid list of files

@Upload
Scenario: Upload a file
	Given I have 'MyPdf.pdf' file to upload
	When I upload the file
	| Path        | Mode | AutoRename | Mute  |
	| /MyPdf.pdf | add  | true       | false |
	Then I should be able to get file info
	| Name       |
	| MyPdf.pdf |

@Get
Scenario: Get metadata
	When I try get 'ferret.jpg' file`s metatada
	Then I should get valid file`s metadata
	| Name       |
	| ferret.jpg |



@Delete
Scenario: Delete file
	When I try delete 'MyPdf.pdf' file
	Then I should get no file info about 'MyPdf.pdf'