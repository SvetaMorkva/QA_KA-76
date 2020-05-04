@login
Feature: Log out

  I am logged in to my account and I want to log out with account

  Scenario: Log out
    Given I log in to my account
    When I click button Log out
    Then I see button Login
