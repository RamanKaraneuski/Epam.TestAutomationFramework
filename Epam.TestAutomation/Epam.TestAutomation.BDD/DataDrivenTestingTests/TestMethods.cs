using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Epam.TestAutomation.Utilities.Logger;
using OpenQA.Selenium;
using TechTalk.SpecFlow.BindingSkeletons;

namespace Epam.TestAutomation.BDD.DataDrivenTestingTests

{
    public static class TestMethods
    {
        public static void GoToEpamCareersPage()
        {
            Logger.Info("Step: Go to https://www.epam.com");
            BrowserFactory.Browser.GotToUrl(TestSettings.ApplicationUrl);

            Logger.Info("Step: Go to the “Careers” -> “Join our Team” section");
            BrowserFactory.Browser.Action.MoveToElement(BrowserFactory.Browser.FindElement(Locators.CareersButton)).Build().Perform();
            BrowserFactory.Browser.FindElement(Locators.JobListingsLink).Click();
        }

        public static void SelectLocation(string locationCountry, string locationCity)
        {
            Logger.Info("Step: Select a location (for example, Armenia -> Gyumri)");
            BrowserFactory.Browser.FindElement(Locators.LocationDropdown).Click();
            BrowserFactory.Browser.FindElement(Locators.LocationOption(locationCountry)).Click();
            BrowserFactory.Browser.FindElement(Locators.NestedLocationOption(locationCity)).Click();
        }

        public static void SelectSkills(string skillsOne, string skillsTwo)
        {
            Logger.Info("Step: Select skills (for example, Solution Architecture, Technology and Business Consulting)");
            BrowserFactory.Browser.FindElement(Locators.SkillsLocator).Click();
            Thread.Sleep(1000);
            BrowserFactory.Browser.FindElement(Locators.SkillsLocatorOptionOne(skillsOne)).Click();
            BrowserFactory.Browser.FindElement(Locators.SkillsLocatorOptionTwo(skillsTwo)).Click();
        }

        public static void EnterKeyword(string keyword)
        {
            Logger.Info("Step: Enter a keyword phrase in the “Keyword” field");
            var searchInput = BrowserFactory.Browser.FindElement(Locators.SearchInput);
            searchInput.Clear();
            searchInput.SendKeys(keyword);
        }

        public static void ClickFindButton()
        {
            Logger.Info("Step: Click the “Find” button");
            BrowserFactory.Browser.FindElement(Locators.FindButton).Click();
            Thread.Sleep(1000);
        }

        public static void CheckSearchResultsKeyword(string keyword, List<string> expectedResults)
        {
            Logger.Info("Step: Check search results");

            foreach (var expectedResult in expectedResults)
            {
                var resultElements = BrowserFactory.Browser.FindElements(Locators.SearchResultElement(expectedResult));
                Assert.IsTrue(resultElements.Count > 0, $"Result for keyword '{keyword}' is not found: {expectedResult}");
            }
        }

        public static void CheckSearchResultsLocation(string locationCountry, string locationCity, List<string> expectedResults)
        {
            Logger.Info("Step: Check search results");

            foreach (var expectedResult in expectedResults)
            {
                var resultElements = BrowserFactory.Browser.FindElements(Locators.SearchResultElement(expectedResult));
                Assert.IsTrue(resultElements.Count > 0, $"Result for keyword '{locationCountry}' '{locationCity}' is not found: {expectedResult}");
            }
        }

        public static void CheckSearchResultsSkills(string skillsOne, string skillsTwo, List<string> expectedResults)
        {
            Logger.Info("Step: Check search results");

            foreach (var expectedResult in expectedResults)
            {
                var resultElements = BrowserFactory.Browser.FindElements(Locators.SearchResultElement(expectedResult));
                Assert.IsTrue(resultElements.Count > 0, $"Result for keyword '{skillsOne}' '{skillsTwo}' is not found: {expectedResult}");
            }
        }

        public static void CheckSearchResults(string keyword, string locationCountry, string locationCity, string skillsOne, string skillsTwo, List<string> expectedResults)
        {
            Logger.Info("Step: Check search results");

            foreach (var expectedResult in expectedResults)
            {
                var resultElements = BrowserFactory.Browser.FindElements(Locators.SearchResultElement(expectedResult));
                Assert.IsTrue(resultElements.Count > 0, $"Result for keyword '{keyword}' '{locationCountry}' '{locationCity}' '{skillsOne}' '{skillsTwo}' is not found: {expectedResult}");
            }
        }

        public static void CheckSearchResultsError(string keyword, string locationCountry, string locationCity, string skillsOne, string skillsTwo, List<string> expectedResults, string errorMessage)
        {
            Logger.Info("Step: Check search results");
            if (string.IsNullOrEmpty(errorMessage))
            {
                foreach (var expectedResult in expectedResults)
                {
                    var resultElements = BrowserFactory.Browser.FindElements(Locators.SearchResultElement(expectedResult));
                    Assert.IsTrue(resultElements.Count > 0, $"Result for keyword '{keyword}' '{locationCountry}' '{locationCity}' '{skillsOne}' '{skillsTwo}' is not found: {expectedResult}");
                }
            }
            else
            {
                var errorMessageElement = BrowserFactory.Browser.FindElement(Locators.ErrorMessage);
                Assert.AreEqual(errorMessage, errorMessageElement.Text, "Error message does not match the expected value.");
            }
        }
    }
}