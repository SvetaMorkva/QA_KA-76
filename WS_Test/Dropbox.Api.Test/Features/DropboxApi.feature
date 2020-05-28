Feature: DropboxApi
	

@Create
Scenario: 1 Create a folder
	When I try to create a folder
	| Path	| AutoRename |
	| /test | true       |
	Then I should be able to see folder info
	| Name |
	| test |


@Upload
Scenario: 2 Upload a file
	Given I have 'MyPdf.pdf' file to upload
	Given I also have folder in Dropbox
	| Path        |
	| /testupload |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testupload/MyPdf.pdf		| add  | true       | false |
	Then I should be able to get file info
	| Name       |
	| MyPdf.pdf  |


@Get
Scenario: 3 Get file metadata
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path	| AutoRename |
	| /test | true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testupload/MyPdf.pdf		| add  | true       | false |
	When I try to get metadata
	| Path					|
	| /testupload/MyPdf.pdf |
	Then I should be able to get the valid info
	| Name      | pathLower             |
	| MyPdf.pdf | /testupload/MyPdf.pdf |


@Get
Scenario: 4 Get list of files
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path			| AutoRename |
	| /testupload	| true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testupload/MyPdf.pdf		| add  | true       | false |
	When I upload the file
	| Path							| Mode | AutoRename | Mute  |
	| /testupload/MyPdf2.pdf		| add  | true       | false |
	When I try to get the list of all existing files in a folder
	| Path		  |
	| /testupload |
	Then I should get a valid list of files


@Download
Scenario: 5 Download a file
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path			| AutoRename |
	| /testupload	| true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testupload/MyPdf.pdf		| add  | true       | false |
	When I try to download the same file from my dropbox
	| Path					 |
	| /testupload/MyPdf.pdf  |
	Then these two files should be identical


@Delete
Scenario: 6 Delete a file
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path		  | AutoRename |
	| /testdelete | true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testdelete/MyPdf.pdf		| add  | true       | false |
	When I delete this file
	Then I should be able to see the valid delete result
	| Path					|
	| /testdelete/MyPdf.pdf |
	

@Delete
Scenario: 7 Delete a folder
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path		  | AutoRename |
	| /testdelete | true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testdelete/MyPdf.pdf		| add  | true       | false |
	When I delete this folder
	Then I should be able to see the valid delete result
	| Path			|
	| /testdelete	|


@GetAfterDelete
Scenario: 8 Get folder after delete
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path		  | AutoRename |
	| /testdelete | true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testdelete/MyPdf.pdf		| add  | true       | false |
	When I delete this folder
	When I try to get metadata
	| Path			|
	| /testdelete	|
	Then I should receive an error


@GetAfterDelete
Scenario: 9 Get file after delete
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path		  | AutoRename |
	| /testdelete | true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testdelete/MyPdf.pdf		| add  | true       | false |
	When I delete this folder
	When I try to get metadata
	| Path					 |
	| /testdelete/MyPdf.pdf  |
	Then I should receive an error