@SearchByKeyword
Feature: Search by Keyword
  As a user
  I want to be able to search for jobs by keyword
  In order to find relevant job listings

  Scenario: Perform a keyword search
    Given I navigate to Landing Page of Epam site1
    When I accept all cookies on Epam Site1
    When Go to the “Careers” -> “Join our Team” section1
    When I enter keyword "QA Testing Team Lead" in the search field
    When I press the "Find" button
    Then I check that the search results contain "QA Testing Team Lead"
