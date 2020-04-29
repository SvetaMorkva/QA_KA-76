Feature: Log in
    I have account
    I want to log in my account

  Background: Log in
    Given I am not logged and want to log in
    When I click to button sign in open signIn page


  Scenario: Successful log in
    Given I entered real data 'artur.borbela1122@gmail.com' in field name, 'borbelaopencart1122' in field password
    When I press on sign in
    Then I redirect to security page

  Scenario: Unsuccessful log in
    Given I entered wrong data 'a.borbela1122@gmail.com' in field name, 'kartonopencart1122' in field password
    When I press on sign in
    Then I get a notification wrong password or name


