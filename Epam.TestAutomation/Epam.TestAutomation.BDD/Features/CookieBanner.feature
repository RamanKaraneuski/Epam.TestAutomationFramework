@CookieBanner
Feature: Cookie Banner Test
  As a user
  I want to see and interact with the cookie banner
  So that I can manage my cookie preferences

  Scenario: Open the page and verify the cookie banner
    Given I navigate to the main page of the Epam website
    Then I should see the cookie banner
    And the cookie banner should contain the text "This website uses cookies for analytics, personalization and advertising."
    And the cookie banner should have a "Cookies Settings" button
    And the cookie banner should have an "Accept All" button
    And the cookie banner should have ana "Accept All" button