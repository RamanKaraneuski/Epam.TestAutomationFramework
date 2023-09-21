using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Utilities.Logger;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Epam.TestAutomation.Helper;
using Epam.TestAutomation.Utils;
using System.IO;
using Newtonsoft.Json.Linq;
using Epam.TestAutomation.BDD.DataDrivenTestingTests;

namespace Epam.TestAutomation.BDD
{
    [TestFixture]
    public class SearchTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger.InitLogger(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.TestDirectory);
        }

        [SetUp]
        public void SetUp()
        {
            Logger.Info("Test begin");
            TestMethods.GoToEpamCareersPage();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Info("Test is failed");
                BrowserFactory.Browser.SaveScreenshoot(TestContext.CurrentContext.Test.MethodName, Path.Combine(TestContext.CurrentContext.TestDirectory, TestSettings.ScreenShotPath));
            }
            Logger.Info("Test finish");
            BrowserFactory.Browser.Quit();
        }

        [Test]
        [TestCaseSource(typeof(TestData), "GetTestData")]
        public void SearchAndVerifyResults(string keyword, List<string> expectedResults)
        {
            TestMethods.EnterKeyword(keyword);
            TestMethods.ClickFindButton();
            TestMethods.CheckSearchResultsKeyword(keyword, expectedResults);
        }

        [Test]
        [TestCaseSource(typeof(TestData), "GetLocationTestData")]
        public void SearchAndVerifyLocationResults(string locationCountry, string locationCity, List<string> expectedResults)
        {
            TestMethods.SelectLocation(locationCountry, locationCity);
            TestMethods.ClickFindButton();
            TestMethods.CheckSearchResultsLocation(locationCountry, locationCity, expectedResults);
        }

        [Test]
        [TestCaseSource(typeof(TestData), "GetSkillsTestData")]
        public void SearchAndVerifySkillsResults(string skillsOne, string skillsTwo, List<string> expectedResults)
        {
            TestMethods.SelectSkills(skillsOne, skillsTwo);
            TestMethods.ClickFindButton();
            TestMethods.CheckSearchResultsSkills(skillsOne, skillsTwo, expectedResults);
        }

        [Test]
        [TestCaseSource(typeof(TestData), "GetCombinedTestData")]
        public void SearchAndVerifyCombinedResults(string keyword, string locationCountry, string locationCity, string skillsOne, string skillsTwo, List<string> expectedResults)
        {
            TestMethods.SelectLocation(locationCountry, locationCity);
            TestMethods.SelectSkills(skillsOne, skillsTwo);
            TestMethods.EnterKeyword(keyword);
            TestMethods.ClickFindButton();
            TestMethods.CheckSearchResults(keyword,locationCountry,locationCity, skillsOne, skillsTwo, expectedResults);
        }

        [Test]
        [TestCaseSource(typeof(TestData), "GetCombinedTestDataAndErrorChecking")]
        public void SearchAndVerifyCombinedResultsErrorChecking(string keyword, string locationCountry, string locationCity, string skillsOne, string skillsTwo, List<string> expectedResults, string errorMessage)
        {
            TestMethods.SelectLocation(locationCountry, locationCity);
            TestMethods.SelectSkills(skillsOne, skillsTwo);
            TestMethods.EnterKeyword(keyword);
            TestMethods.ClickFindButton();
            TestMethods.CheckSearchResultsError(keyword, locationCountry, locationCity, skillsOne, skillsTwo, expectedResults, errorMessage);
        }
    }
}