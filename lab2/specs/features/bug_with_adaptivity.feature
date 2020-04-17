Feature: Adaptivity
   There are elements that overlap and distort when user
   scales the screen.

   Scenario: Footer overlap
      Given I have opened relax.kpi.ua/ website in the browser
      And the browser is Google Chrome
      When I scale the page using Ctrl + = shorcut
      Then I should see all elements on a big enough distance from each other
      # But some elements start to cover other elements

   Scenario: YouTube video distortion
      Given I have opened kpi.ua/en website in the browser
      And the browser is Google Chrome
      When I scale the page using Ctrl + = shorcut
      Then I should see YouTube video window scaled proportionally
      # But I see that the window is stretched horizontally along the page

   Scenario: Navigation bar distortion
      Given I have opened kpi.ua/en website in the browser
      And the browser is Google Chrome
      When I scale the page using Ctrl + = shorcut
      Then I see the Main navigation clickable words that should not be there at all
      And I click on Main navigation
      Then I see drop-down list of website sections covering each other
      # But I should see a smaller navigation bar with elements on a big enough distance from each other
      