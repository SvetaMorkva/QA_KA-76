Feature: Documents management
	As a user I want to share and track 
	my documents 


Scenario: Upload a document stored on local device
	Given I am logged in
	And I am on Documents page
	When I press Upload new document
	Then I press Local File
	And I choose a file on my device
	When I press Open
	Then my document is uploaded to Documents

Scenario: Create sharable link to a document
	Given I am logged in
	And I am on Documents page
	When I hover over the document I need a sharable link of
	Then Create shareable link button appear
	And I press Create shareable link
	And I enter recepient email address
	When I press Create shareable link
	Then I can copy the shareable link
