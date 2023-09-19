//using Epam.TestAutomation.BDD.DataDrivenTestingTests;
//using Epam.TestAutomation.Core.Browser;
//using Epam.TestAutomation.Helper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using TechTalk.SpecFlow;
//using Epam.TestAutomation.Utilities.Logger;
//using NUnit.Framework;
//using Epam.TestAutomation.BDD.Steps.SharedComponents;
//using Epam.TestAutomation.Web.PageObjects.Pages;

//namespace Epam.TestAutomation.BDD.Steps

//{
//    [Binding]
//    public class LocationSearchSteps
//    {
//[Given(@"I navigate to Landing Page of Epam site1")]
//public void GivenIAmOnEpamCareersPage()
//{
//    Logger.Info("Step: Go to https://www.epam.com");
//    BrowserFactory.Browser.GotToUrl(TestSettings.ApplicationUrl);
//}

//private MainPage LandingPage => new();

//[When(@"I accept all cookies on Epam Site2")]
//public void GivenIAcceptAllCookiesOnEpamSite()
//{
//    Thread.Sleep(3000);
//    LandingPage.AcceptAllCookies();
//}

//[When(@"Go to the “Careers” -> “Join our Team” section")]
//public void GivenIAcceptAllCookiesOnEpamSite2()
//{
//    Logger.Info("Step: Go to the “Careers” -> “Join our Team” section");
//    BrowserFactory.Browser.Action.MoveToElement(BrowserFactory.Browser.FindElement(Locators.CareersButton)).Build().Perform();
//    BrowserFactory.Browser.FindElement(Locators.JobListingsLink).Click();
//}



//[When(@"I select location ""(.*)"" and ""(.*)"" in the drop down list")]
//public void WhenISelectLocationInDropdown(string locationCountry, string locationCity)
//{
//    TestMethods.SelectLocation(locationCountry, locationCity);
//}

//[When(@"I press the ""Search"" button")]
//public void WhenIClickSearchButton()
//{
//    TestMethods.ClickFindButton();
//    Thread.Sleep(1000);
//}

//        //[Then(@"I check that the search results contain ""(.*)"" and ""(.*)""")]
//        //public void ThenICheckSearchResultsContainLocation(string locationCountry, string locationCity)
//        //{
//        //    TestMethods.CheckSearchResultsLocation(locationCountry, locationCity);
//        //}

//        //[Then(@"I check that the search results contain ""(.*)"" and ""(.*)""")]
//        //public void ThenICheckSearchResultsContainLocation(string locationCountry, string locationCity)
//        //{
//        //    var searchResults = TestMethods.GetSearchResults();
//        //    bool resultsContainLocation = searchResults.All(result => result.Contains(locationCountry) && result.Contains(locationCity));

//        //    Assert.IsTrue(resultsContainLocation, $"Search results do not contain {locationCountry} and {locationCity}");
//        //}

//        //[Then(@"I check that the search results contain ""(.*)"" and ""(.*)""")]
//        //public void ThenICheckSearchResultsContainLocation(string locationCountry, string locationCity)
//        //{
//        //    string searchResults = TestMethods.GetSearchResultsText();

//        //    Assert.IsTrue(searchResults.Contains(locationCountry), $"{locationCountry} not found in search results.");
//        //    Assert.IsTrue(searchResults.Contains(locationCity), $"{locationCity} not found in search results.");
//        //}



//    }
//}
