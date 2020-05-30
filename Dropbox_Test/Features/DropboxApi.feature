Feature: GetFileList
	
@Get
Scenario: Get all files
	When I try to get list of all existing files
	Then I should get valid list of files

@FileMetadata
Scenario: Get file metadata
	When I try to get '/MyImage_.jpg' file metadata
	Then I should get valid metadata
	| Name         |
	| MyImage_.jpg |

@Delete
Scenario: Delete a file
	When I try to delete '/MyImage_.jpg' file
	Then I should get a valid file info
	| Name         |
	| MyImage_.jpg |

