using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Helper;
using Epam.TestAutomation.Utilities.ElementUtils;
using Epam.TestAutomation.Core.WebDriverManager;
using Epam.TestAutomation.Web.PageObjects.Pages;

namespace Epam.TestAutomation.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class Selenium_AdvancedTest
    {
        [SetUp]
        public void Setup()
        {
            WebDriverManager.Initialize();
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverManager.Quit();
        }

        [Test]
        public void SearchAndVerifyResults()
        {
            var loginPage = new LoginPage(WebDriverManager.Driver);
            loginPage.PerformSearchAndVerifyResults();
        }

        [Test]
        public void CheckLanguageDropdown()
        {
            var loginPage = new LoginPage(WebDriverManager.Driver);
            loginPage.PerformLanguageDropdownCheck();
        }

        [Test]
        public void CheckCareersLocationPage()
        {
            var loginPage = new LoginPage(WebDriverManager.Driver);
            loginPage.PerformCareersLocationPageCheck();
        }

        [Test]
        public void OpenEpamHomePage()
        {
            var loginPage = new LoginPage(WebDriverManager.Driver);
            loginPage.OpenBaseUrl();

            Assert.AreEqual(ConfigurationHelper.BaseUrl, WebDriverManager.Driver.Url);
        }

        [Test]
        public void NavigationAndPageReload()
        {
            var loginPage = new LoginPage(WebDriverManager.Driver);
            loginPage.OpenBaseUrl();

            var howWeDoItUrl = ConfigurationHelper.BaseUrl + "services";
            var ourWorkUrl = ConfigurationHelper.BaseUrl + "/services/client-work";

            WebDriverManager.Driver.Navigate().GoToUrl(howWeDoItUrl);
            WebDriverManager.Driver.Navigate().GoToUrl(ourWorkUrl);
            WebDriverManager.Driver.Navigate().Refresh();
            WebDriverManager.Driver.Navigate().Back();

            Assert.AreEqual(howWeDoItUrl, WebDriverManager.Driver.Url);
        }

        [Test]
        public void NavigationAndPageReloadClick()
        {
            var loginPage = new LoginPage(WebDriverManager.Driver);
            loginPage.OpenBaseUrl();


            var howWeDoItUrl = ConfigurationHelper.BaseUrl + "services";

            var exploreOurClientWorkLocator = By.XPath("//a[contains(@class, 'bold-underlined-hover') and @href='/services/client-work']");

            WebDriverManager.Driver.Navigate().GoToUrl(howWeDoItUrl);
            WebDriverManager.Driver.FindElement(exploreOurClientWorkLocator).Click();
            WebDriverManager.Driver.Navigate().Refresh();
            WebDriverManager.Driver.Navigate().Back();

            Assert.AreEqual(howWeDoItUrl, WebDriverManager.Driver.Url);
        }

        [Test]
        public void TestFindDreamJobCountries()
        {
            var loginPage = new LoginPage(WebDriverManager.Driver);
            loginPage.OpenBaseUrl();

            var careersPage = loginPage.GoToCareersPage();
            careersPage.ClickCareersLink();
            careersPage.ClickDreamJobIcon();

            Assert.IsTrue(careersPage.IsAmericasDisplayed(), "Americas not displayed");
            Assert.IsTrue(careersPage.IsEMEADisplayed(), "EMEA not displayed");
            Assert.IsTrue(careersPage.IsAPACDisplayed(), "APAC not displayed");
        }
    }
}
