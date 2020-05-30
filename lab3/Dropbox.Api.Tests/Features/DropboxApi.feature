Feature: GetFileList
	
@GetMetadata
Scenario: Get file metadata
	When I uploaded a file
	| Mode | AutoRename | Mute  |
	| add  | true       | false |
	Then I shoud be able to get file metadata

@DeleteFile
Scenario: Delete a file
	Given I have nonempty dropbox folder
	Then I shoud be able to delete a file