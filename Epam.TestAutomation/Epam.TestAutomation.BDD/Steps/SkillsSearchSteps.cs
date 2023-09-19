//using Epam.TestAutomation.BDD.DataDrivenTestingTests;
//using Epam.TestAutomation.BDD.Steps.GeneralSteps;
//using Epam.TestAutomation.BDD.Steps.Pages;
//using Epam.TestAutomation.BDD.Steps.SharedComponents;
//using Epam.TestAutomation.BDD.Steps;
//using Epam.TestAutomation.BDD;
//using Epam.TestAutomation.Core.Browser;
//using Epam.TestAutomation.Helper;
//using Epam.TestAutomation.Utilities;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using TechTalk.SpecFlow;
//using Epam.TestAutomation.Utilities.Logger;
//using Epam.TestAutomation.Web.PageObjects.Pages;

//namespace Epam.TestAutomation.BDD.Steps
//{
//    [Binding]
//    public class SkillsSearchSteps
//    {
//        [Given(@"Дано, что я нахожусь на странице карьеры Epam")]
//        public void GivenIAmOnEpamCareersPage()
//        {
//            Logger.Info("Step: Go to https://www.epam.com");
//            BrowserFactory.Browser.GotToUrl(TestSettings.ApplicationUrl);

//        }

//        private MainPage LandingPage => new();

//        [When(@"И я принимаю все файлы cookie на сайте Epam")]
//        public void GivenIAcceptAllCookiesOnEpamSite()
//        {
//            Thread.Sleep(3000);
//            LandingPage.AcceptAllCookies();
//        }

//        [When(@"Дано, что я нахожусь на странице карьеры Epam2")]
//        public void GivenIAmOnEpamCareersPage1()
//        {
//            Logger.Info("Step: Go to the “Careers” -> “Join our Team” section");
//            BrowserFactory.Browser.Action.MoveToElement(BrowserFactory.Browser.FindElement(Locators.CareersButton)).Build().Perform();
//            BrowserFactory.Browser.FindElement(Locators.JobListingsLink).Click();

//        }



//        [When(@"Когда я выбираю навыки ""(.*)"" и ""(.*)""")]
//        public void WhenISelectSkills(string skillsOne, string skillsTwo)
//        {
//            TestMethods.SelectSkills(skillsOne, skillsTwo);
//        }

//        [When(@"И я нажимаю кнопку ""Поиск""")]
//        public void WhenIClickSearchButton()
//        {
//            TestMethods.ClickFindButton();
//        }

//        //[Then(@"Тогда я проверяю, что результаты поиска содержат ""(.*)"" и ""(.*)""")]
//        //public void ThenICheckSearchResultsContainSkills(string skillsOne, string skillsTwo)
//        //{
//        //    TestMethods.CheckSearchResultsSkills(skillsOne, skillsTwo);
//        //}
//        [Then(@"Тогда я проверяю, что результаты поиска содержат ""(.*)"" и ""(.*)""")]
//        public void ThenICheckSearchResultsContainSkills(string skillsOne, string skillsTwo)
//        {
//            List<string> selectedSkills = new List<string> { skillsOne, skillsTwo };
//            List<string> actualSkills = TestMethods.GetSelectedSkillsFromSearchResults();

//            foreach (string skill in selectedSkills)
//            {
//                Assert.Contains(skill, actualSkills, $"Skill '{skill}' was not found in the search results.");
//            }
//        }


//        //[Then(@"Тогда я проверяю, что результаты поиска содержат ""(.*)"" и ""(.*)""")]
//        //public void ThenICheckSearchResultsContainSkills(string skillsOne, string skillsTwo)
//        //{
//        //    TestMethods.CheckSearchResultsSkills(skillsOne, skillsTwo);
//        //}

//        //[Then(@"Тогда я проверяю, что результаты поиска содержат")]
//        //public void ThenICheckSearchResultsContainSkills(Table expectedResults)
//        //{
//        //    Logger.Info("Step: Check search results");

//        //    foreach (var row in expectedResults.Rows)
//        //    {
//        //        var skillsOne = row["SkillsOne"];
//        //        var skillsTwo = row["SkillsTwo"];
//        //        var expectedResult = row["ExpectedResult"];

//        //        var resultElements = BrowserFactory.Browser.FindElements(Locators.SearchResultElement(expectedResult));
//        //        Assert.IsTrue(resultElements.Count > 0, $"Result for keywords '{skillsOne}' '{skillsTwo}' is not found: {expectedResult}");
//        //    }
//        //}





//    }
//}
