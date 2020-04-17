Feature: Text translation to English
    Some pages of the English version of the KPI website https://kpi.ua/en
    are not translated from Ukrainian properly.
   
    Scenario: View translated into English webpage
        Given I have opened https://kpi.ua/en website in the browser
        And the browser is Google Chrome
        When I turn on contextual search using Ctrl + F keys and type some Ukrainian letters or words
        Then there are no cyrillic symbols and words, only English
        # But some Ukrainian characters are found in the page