using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Helper;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Epam.TestAutomation.BDD.DataDrivenTestingTests;
using Epam.TestAutomation.Utilities.Logger;
using Epam.TestAutomation.BDD.Steps.GeneralSteps;
using Epam.TestAutomation.BDD.Steps.Pages;
using Epam.TestAutomation.BDD.Steps.SharedComponents;
using Epam.TestAutomation.BDD.Steps;
using Epam.TestAutomation.BDD;
using Epam.TestAutomation.Utilities;


//namespace Epam.TestAutomation.BDD.Steps


namespace Epam.TestAutomation.BDD
{
    [Binding]
    public class SearchBySkillsSteps
    {
        private string enteredKeyword;
        private string selectedSkillsOne;
        private string selectedSkillsTwo;
        private MainPage LandingPage => new();

        [Given(@"I navigate to Landing Page of Epam site2")]
        public void GivenINavigateToLandingPageOfEpamSite()
        {
            Logger.Info("Step: Navigate to Landing Page of Epam site");
            BrowserFactory.Browser.GotToUrl(TestSettings.ApplicationUrl);
        }


        [When(@"I accept all cookies on Epam Site2")]
        public void WhenIAcceptAllCookiesOnEpamSite()
        {
            Logger.Info("Step: Accept all cookies on Epam Site");
            Thread.Sleep(3000);
            LandingPage.AcceptAllCookies();
        }

        [When(@"Go to the “Careers” -> “Join our Team” section2")]
        public void GivenIAcceptAllCookiesOnEpamSite2()
        {
            Logger.Info("Step: Go to the “Careers” -> “Join our Team” section");
            BrowserFactory.Browser.Action.MoveToElement(BrowserFactory.Browser.FindElement(Locators.CareersButton)).Build().Perform();
            BrowserFactory.Browser.FindElement(Locators.JobListingsLink).Click();
        }



        [When(@"I select skills ""(.*)"" and ""(.*)""")]
        public void WhenISelectSkillsAnd(string skillsOne, string skillsTwo)
        {
            Logger.Info($"Step: Select skills '{skillsOne}' and '{skillsTwo}'");
            selectedSkillsOne = skillsOne;
            selectedSkillsTwo = skillsTwo;

            // Implement skills selection logic
            IWebElement skillsLocator = BrowserFactory.Browser.FindElement(Locators.SkillsLocator);
            skillsLocator.Click();
            Thread.Sleep(1000); // Simulate a delay
            BrowserFactory.Browser.FindElement(Locators.SkillsLocatorOptionOne(skillsOne)).Click();
            BrowserFactory.Browser.FindElement(Locators.SkillsLocatorOptionTwo(skillsTwo)).Click();
        }

        [When(@"I press the ""Find"" button2")]
        public void WhenIPressTheButton()
        {
            Logger.Info("Step: Press the 'Find' button");
            // Implement button click logic
            BrowserFactory.Browser.FindElement(Locators.FindButton).Click();
            Thread.Sleep(1000); // Simulate a delay
        }


        [Then(@"I verify that the selected skills are displayed")]
        public void ThenIVerifyThatTheSelectedSkillsAreDisplayed()
        {
            Logger.Info($"Step: Verify that the selected skills '{selectedSkillsOne}' and '{selectedSkillsTwo}' are displayed");

            // Implement verification logic to check if the selected skills are displayed on the page
            IWebElement skillsElement = BrowserFactory.Browser.FindElement(Locators.SkillsLocator);
            string selectedSkillsText = skillsElement.Text;

            // Verify that both selected skills are displayed on the page
            Assert.IsTrue(selectedSkillsText.Contains(selectedSkillsOne) && selectedSkillsText.Contains(selectedSkillsTwo),
                $"Selected skills '{selectedSkillsOne}' and '{selectedSkillsTwo}' are not displayed");
        }


    }
}