Feature: DropboxApi
	

@Create
Scenario: 1 Create a folder
	When I try to create a folder
	| Path	| AutoRename |
	| /test | true       |
	Then I should be able to see the valid create folder info


@Upload
Scenario: 2 Upload a file
	Given I have 'MyPdf.pdf' file to upload
	Given I also have folder in Dropbox
	| Path        |
	| /testupload |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testupload/MyPdf.pdf		| add  | true       | false |
	Then I should be able to get the valid upload file info


@Get
Scenario: 3 Get file metadata
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path			| AutoRename |
	| /testupload	| true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testupload/MyPdf.pdf		| add  | true       | false |
	When I try to get metadata
	| Path                  | IncludeMediaInfo	| IncludeDeleted | IncludeHasExplicitSharedMembers |
	| /testupload/MyPdf.pdf | true				| true           | true                            |
	Then I should be able to get the valid get metadata info



@Get
Scenario: 4 Get list of files
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path			| AutoRename |
	| /testupload	| true       |
	When I upload the file
	| Path                  | Mode | AutoRename | Mute  | StrictConfclict |
	| /testupload/MyPdf.pdf | add  | true       | false | false           |
	When I upload the file
	| Path                   | Mode | AutoRename | Mute  | StrictConflict |
	| /testupload/MyPdf2.pdf | add  | true       | false | false          |
	When I try to get the list of all existing files in a folder
	| Path        | Recursive | IncludeMediaInfo | IncludeDeleted | IncludeHasExplicitSharedMembers | IncludeMountedFolders | IncludeNonDownloadableFiles |
	| /testupload | false     | false            | false          | false                           | false                 | false                       |
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
	When I perform a delete
	| Path					|
	| /testdelete/MyPdf.pdf |
	Then I should be able to see the valid delete result
	

@Delete
Scenario: 7 Delete a folder
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path		  | AutoRename |
	| /testdelete | true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testdelete/MyPdf.pdf		| add  | true       | false |
	When I perform a delete
	| Path		  |		
	| /testdelete |
	Then I should be able to see the valid delete result



@GetAfterDelete
Scenario: 8 Get folder after delete
	Given I have 'MyPdf.pdf' file to upload
	When I try to create a folder
	| Path		  | AutoRename |
	| /testdelete | true       |
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testdelete/MyPdf.pdf		| add  | true       | false |
	When I perform a delete
	| Path		  |		
	| /testdelete |
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
	When I perform a delete
	| Path		  |		
	| /testdelete |
	When I try to get metadata
	| Path					 |
	| /testdelete/MyPdf.pdf  |
	Then I should receive an error