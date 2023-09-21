using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Threading;
using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;

namespace Epam.TestAutomation.BDD.Steps
{
    [Binding]
    public class CookieBannerSteps
    {
        [Then(@"I should see the cookie banner")]
        public void ThenIShouldSeeTheCookieBanner()
        {
            IWebElement cookieBanner = BrowserFactory.Browser.FindElement(By.Id("onetrust-group-container"));
            Assert.IsNotNull(cookieBanner, "Cookie banner not found on the page.");
        }

        [Then(@"the cookie banner should contain the text ""(.*)""")]
        public void ThenTheCookieBannerShouldContainTheText(string expectedText)
        {
            IWebElement cookieBannerText = BrowserFactory.Browser.FindElement(By.Id("onetrust-policy-text"));
            string actualText = cookieBannerText.Text;
            StringAssert.Contains(expectedText, actualText, $"Expected text: {expectedText}, Actual text: {actualText}");
        }

        [Then(@"the cookie banner should have a ""(.*)"" button")]
        public void ThenTheCookieBannerShouldHaveAButton(string buttonLabel)
        {
            IWebElement button = BrowserFactory.Browser.FindElement(By.XPath($"//button[contains(text(), '{buttonLabel}')]"));
            Assert.IsNotNull(button, $"Button '{buttonLabel}' not found on the cookie banner.");
        }

        [Then(@"the cookie banner should have an ""(.*)"" button")]
        public void ThenTheCookieBannerShouldHaveAButtonAll(string buttonLabel)
        {
            IWebElement button = BrowserFactory.Browser.FindElement(By.XPath($"//button[contains(text(), '{buttonLabel}')]"));
            Assert.IsNotNull(button, $"Button '{buttonLabel}' not found on the cookie banner.");
        }

        [Then(@"the cookie banner should have ana ""Accept All"" button")]
        public void ThenTheCookieBannerShouldHaveAnAcceptAllButton()
        {
            IWebElement acceptAllButton = BrowserFactory.Browser.FindElement(By.Id("onetrust-accept-btn-handler"));
            Assert.IsNotNull(acceptAllButton, "Accept All button not found on the cookie banner.");
        }
    }
}