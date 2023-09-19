@SearchBySkills
Feature: Search by Skills
  As a user
  I want to be able to search for jobs by skills
  In order to find job listings that match my skills

  Scenario: Perform a keyword search
    Given I navigate to Landing Page of Epam site2
    When I accept all cookies on Epam Site2
    When Go to the “Careers” -> “Join our Team” section2
    When I select skills "Marketing and Communications" and "Business and Data Analysis"
    When I press the "Find" button2
    Then I verify that the selected skills are displayed
