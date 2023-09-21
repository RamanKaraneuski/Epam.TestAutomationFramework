@SearchSteps
Feature: Search by Keyword, Location, Skills
  As a user
  I want to be able to search for jobs by keyword
  In order to find relevant job listings
    As a user
  I want to be able to search for jobs by location
  In order to find job listings in specific locations
    As a user
  I want to be able to search for jobs by skills
  In order to find job listings that match my skills

@SearchByKeyword
@Smoke
  Scenario: Perform a keyword search
    Given I navigate to the main page of the Epam website
    When I accept all cookies on Epam website
    When Go to the “Careers” “Join our Team” section
    When I enter keyword "QA Testing Team Lead" in the search field
    When I press the "Find" button
    Then I check that the search results contain Keyword "QA Testing Team Lead"

@SearchByLocation
@Smoke
Scenario: Perform a location-based search
    Given I navigate to the main page of the Epam website
    When I accept all cookies on Epam website
    When Go to the “Careers” “Join our Team” section
    When I select location "Ukraine" and "Lviv"
    When I press the "Find" button
    Then I check that is selected in the location dropdown City "Lviv"
    Then I check that is selected in the location dropdown Country "Ukraine"

@SearchBySkills
@Smoke
 Scenario: Perform a skills search
    Given I navigate to the main page of the Epam website
    When I accept all cookies on Epam website
    When Go to the “Careers” “Join our Team” section
    When I select skills "Marketing and Communications" and "Business and Data Analysis"
    When I press the "Find" button
    Then I verify that the selected skills are displayed
