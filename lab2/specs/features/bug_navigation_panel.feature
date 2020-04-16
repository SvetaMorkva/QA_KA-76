Feature: Bug in navigation panel
    Some elements of the navigation bar On the English version
    of the kpi.ua website does not work

    Scenario: Open schedule
        Given I have opened https://kpi.ua/en website in the browser
        And the browser is Google Chrome
        When I navigate to the top of the page and click on the Schedule icon
        Then I can choose one of three options for the Department of Education: Class Schedule, Schedule or Teacher Schedule
        When I click on any option of the three mentioned above
        Then I should see a page with a field for entering either the name of the group or full name of the teacher
        But I see a blank screen with no useful information

    Scenario: Open Campus
        Given I have opened https://kpi.ua/en website in the browser
        And the browser is Google Chrome
        When I navigate to the top of the page and click on the Campus icon
        Then I see four options to choose from: E-Campus, Information Resources, KPI Teachers and GitHub Repository
        And I click on E-Campus option from the above
        Then I should be redirected to the campus.kpi.ua/ page
        But I see a blank screen with no useful information

    Scenario: Open Media
        Given I have opened https://kpi.ua/en website in the browser
        And the browser is Google Chrome
        When I navigate to the top of the page and click on the Media icon
        Then I see three options to choose from: Webcams, Radio, and Video
        When I click on the Webcams option from the above
        Then I should be redirected to a page with a list of webcams on the teritory of the KPI
        But I see a page with just Web-cams heading
        When I click on the Radio option from the above
        Then I should see a page with some useful information
        But I see a blank page with It works! heading