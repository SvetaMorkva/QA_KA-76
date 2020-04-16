Feature: Bug in the search element
    The search icon on the does not respond to clicking

    Scenario: Search for some item
        Given I have opened relax.kpi.ua/ website in the browser
        And the browser is Google Chrome
        When I click on the search icon at the right of the navigation bar at the top of the page
        Then I should see some field
        But no field for entering words occurs