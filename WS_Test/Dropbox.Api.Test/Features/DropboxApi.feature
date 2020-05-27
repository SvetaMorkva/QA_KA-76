Feature: DropboxApi
	
@Get
Scenario: Get list of files
	When I try to get the list of all existing files in a folder
	| Path		  |
	| /testupload |
	Then I should get a valid list of files

@Get
Scenario: Get file metadata
	When I try to get file's metadata that is stored in my dropbox
	| Path					|
	| /testupload/MyPdf.pdf |
	Then I should be able to get the valid info
	| Name      | pathLower             |
	| MyPdf.pdf | /testupload/MyPdf.pdf |

@Upload
Scenario: Upload a file
	Given I have 'MyPdf.pdf' file to upload
	When I upload the file
	| Path						| Mode | AutoRename | Mute  |
	| /testupload/MyPdf.pdf		| add  | true       | false |
	Then I should be able to get file info
	| Name       |
	| MyPdf.pdf  |

@Create
Scenario: Create a folder
	When I try to create a folder
	| Path	| AutoRename |
	| /test | true       |
	Then I should be able to see folder info
	| Name |
	| test |

@Download
Scenario: Download a file
	Given I have the 'MyPdf.pdf' file on my computer
	When I try to download the same file from my dropbox
	| Path					 |
	| /testupload/MyPdf.pdf  |
	Then these two files should be identical

