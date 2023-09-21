using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Epam.TestAutomation.BDD.DataDrivenTestingTests;
using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Utilities.Logger;
using Epam.TestAutomation.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Epam.TestAutomation.BDD.Steps.GeneralSteps;
using Epam.TestAutomation.BDD.Steps.Pages;
using Epam.TestAutomation.BDD.Steps.SharedComponents;
using Epam.TestAutomation.BDD.Steps;
using Epam.TestAutomation.BDD;
using Epam.TestAutomation.Utilities;
using Epam.TestAutomation.Web.PageObjects.Pages;

namespace Epam.TestAutomation.BDD
{
    [Binding]
    public class SearchByKeywordSteps
    {
        private string enteredKeyword;
        private string selectedLocationCountry;
        private string selectedLocationCity;
        private string selectedSkillsOne;
        private string selectedSkillsTwo;
        private MainPage LandingPage => new();
         
        [Given(@"I navigate to the main page of the Epam website")]
        public void GivenINavigateToLandingPageOfEpamSite()
        {
            Logger.Info("Step: Navigate to Landing Page of Epam site");
            BrowserFactory.Browser.GotToUrl(TestSettings.ApplicationUrl);
        }

        [When(@"I accept all cookies on Epam website")]
        public void WhenIAcceptAllCookiesOnEpamSite()
        {
            Logger.Info("Step: Accept all cookies on Epam Site");
            Thread.Sleep(3000);
            LandingPage.AcceptAllCookies();
        }

        [When(@"Go to the “Careers” “Join our Team” section")]
        public void GivenIAcceptAllCookiesOnEpamSite()
        {
            Logger.Info("Step: Go to the “Careers” -> “Join our Team” section");
            BrowserFactory.Browser.Action.MoveToElement(BrowserFactory.Browser.FindElement(Locators.CareersButton)).Build().Perform();
            BrowserFactory.Browser.FindElement(Locators.JobListingsLink).Click();
        }

        [When(@"I enter keyword ""(.*)"" in the search field")]
        public void WhenIEnterKeywordInTheSearchField(string keyword)
        {
            Logger.Info($"Step: Enter keyword '{keyword}' in the search field");
            enteredKeyword = keyword;

            IWebElement searchInput = BrowserFactory.Browser.FindElement(Locators.SearchInput);
            searchInput.Clear();
            searchInput.SendKeys(keyword);
        }

        [When(@"I select location ""(.*)"" and ""(.*)""")]
        public void WhenISelectLocationAndInTheDropDownList(string locationCountry, string locationCity)
        {
            Logger.Info($"Step: Select location '{locationCountry}' and '{locationCity}' in the drop-down list");
            selectedLocationCountry = locationCountry;
            selectedLocationCity = locationCity;

            IWebElement locationDropdown = BrowserFactory.Browser.FindElement(Locators.LocationDropdown);
            locationDropdown.Click();
            Thread.Sleep(1000);
            BrowserFactory.Browser.FindElement(Locators.LocationOption(locationCountry)).Click();
            Thread.Sleep(1000);
            BrowserFactory.Browser.FindElement(Locators.NestedLocationOption(locationCity)).Click();
        }

        [When(@"I select skills ""(.*)"" and ""(.*)""")]
        public void WhenISelectSkillsAnd(string skillsOne, string skillsTwo)
        {
            Logger.Info($"Step: Select skills '{skillsOne}' and '{skillsTwo}'");
            selectedSkillsOne = skillsOne;
            selectedSkillsTwo = skillsTwo;

            IWebElement skillsLocator = BrowserFactory.Browser.FindElement(Locators.SkillsLocator);
            skillsLocator.Click();
            Thread.Sleep(1000);
            BrowserFactory.Browser.FindElement(Locators.SkillsLocatorOptionOne(skillsOne)).Click();
            BrowserFactory.Browser.FindElement(Locators.SkillsLocatorOptionTwo(skillsTwo)).Click();
        }

        [When(@"I press the ""Find"" button")]
        public void WhenIPressTheButton()
        {
            Logger.Info("Step: Press the 'Find' button");

            BrowserFactory.Browser.FindElement(Locators.FindButton).Click();
            Thread.Sleep(1000);
        }

        [Then(@"I check that the search results contain Keyword ""(.*)""")]
        public void ThenICheckThatTheSearchResultsContain(string expectedKeyword)
        {
            Logger.Info($"Step: Check that the search results contain '{expectedKeyword}'");
            IReadOnlyCollection<IWebElement> resultElements = BrowserFactory.Browser.FindElements(Locators.SearchResultElement(expectedKeyword));

            bool keywordFound = false;
            foreach (IWebElement resultElement in resultElements)
            {
                if (resultElement.Text.Contains(expectedKeyword))
                {
                    keywordFound = true;
                    break;
                }
            }

            Assert.IsTrue(keywordFound, $"Result for keyword '{enteredKeyword}' is not found: {expectedKeyword}");
        }

        [Then(@"I check that is selected in the location dropdown City ""(.*)""")]
        public void ThenICheckThatIsSelectedInTheLocationDropdownCity(string locationCity)
        {
            Logger.Info($"Step: Check that '{locationCity}' is selected in the location dropdown");
            IWebElement selectedLocation = BrowserFactory.Browser.FindElement(Locators.LocationDropdown)
                .FindElement(By.XPath($"//span[contains(@class, 'select2-selection__rendered') and text()='{locationCity}']"));

            Assert.IsNotNull(selectedLocation, $"{locationCity} is not selected in the location dropdown");
        }

        [Then(@"I check that is selected in the location dropdown Country ""(.*)""")]
        public void ThenICheckThatIsSelectedInTheLocationDropdownCountry(string locationCountry)
        {
            Logger.Info($"Step: Check that '{locationCountry}' is selected in the location dropdown");
            IWebElement selectedLocation1 = BrowserFactory.Browser.FindElement(Locators.LocationDropdown)
                .FindElement(By.XPath($"//strong[contains(@class, 'search-result__location-23') and text()='{locationCountry}']"));

            Assert.IsNotNull(selectedLocation1, $"{locationCountry} is not selected in the location dropdown");
        }

        [Then(@"I verify that the selected skills are displayed")]
        public void ThenIVerifyThatTheSelectedSkillsAreDisplayed()
        {
            Logger.Info($"Step: Verify that the selected skills '{selectedSkillsOne}' and '{selectedSkillsTwo}' are displayed");

            IWebElement selectedItemsElement = BrowserFactory.Browser.FindElement(By.ClassName("selected-items"));

            Assert.IsTrue(selectedItemsElement.Text.Contains(selectedSkillsOne) && selectedItemsElement.Text.Contains(selectedSkillsTwo),
                $"Selected skills '{selectedSkillsOne}' and '{selectedSkillsTwo}' are not displayed in selected items");
        }
    }
}