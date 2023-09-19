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
        private MainPage LandingPage => new();

        [Given(@"I navigate to Landing Page of Epam site1")]
        public void GivenINavigateToLandingPageOfEpamSite()
        {
            Logger.Info("Step: Navigate to Landing Page of Epam site");
            BrowserFactory.Browser.GotToUrl(TestSettings.ApplicationUrl);
        }


        [When(@"I accept all cookies on Epam Site1")]
        public void WhenIAcceptAllCookiesOnEpamSite()
        {
            Logger.Info("Step: Accept all cookies on Epam Site");
            Thread.Sleep(3000);
            LandingPage.AcceptAllCookies();
        }

        [When(@"Go to the “Careers” -> “Join our Team” section1")]
        public void GivenIAcceptAllCookiesOnEpamSite2()
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
            // Implement keyword entry logic
            IWebElement searchInput = BrowserFactory.Browser.FindElement(Locators.SearchInput);
            searchInput.Clear();
            searchInput.SendKeys(keyword);
        }

        [When(@"I press the ""Find"" button")]
        public void WhenIPressTheButton()
        {
            Logger.Info("Step: Press the 'Find' button");
            // Implement button click logic
            BrowserFactory.Browser.FindElement(Locators.FindButton).Click();
            Thread.Sleep(1000); // Simulate a delay
        }

        [Then(@"I check that the search results contain ""(.*)""")]
        public void ThenICheckThatTheSearchResultsContain(string expectedKeyword)
        {
            Logger.Info($"Step: Check that the search results contain '{expectedKeyword}'");
            // Implement result verification logic
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
    }
}