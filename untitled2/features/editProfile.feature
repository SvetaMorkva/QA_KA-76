Feature: Edit profile data

  Background: I logged in my account with security PIN
    Given I log in to my account
    Given I enter security PIN
    Given I pass to editProfile page

  Scenario: I check my Username
    Then I show my username 'Art-kart-1122'

  Scenario: I change to the correct one
    Given I writting 'Art-kart-1122'
    When I press button submit
    Then I show message successful



  Scenario: I change to the wrong one
    Given I writting 'Art-kart-1122Art-kart-1122'
    When I press button submit
    Then I show warning message