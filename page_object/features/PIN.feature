@security
Feature: Security PIN

  I logged in and must enter PIN
  Background: Log in
    Given I log in to my account

  Scenario: Correct PIN
    Given I logged in and must enter PIN 5434
    When I click button Continue
    Then I redirect to Account page

  Scenario: Wrong PIN
    Given I logged in and must enter PIN 1111
    When I click button Continue
    Then I redirect to security page