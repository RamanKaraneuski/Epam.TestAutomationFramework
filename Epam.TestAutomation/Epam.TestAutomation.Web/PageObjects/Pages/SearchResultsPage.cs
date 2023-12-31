﻿using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages
{
    public class SearchResultsPage : BasePage
    {
        public override string Url => "https://www.epam.com/search";

        public ElementsList<Link> SearchResultLinks => new ElementsList<Link>(By.ClassName("search-results__title-link"));

        public Link GetSearchResultLinkByName(string linkName)
        {
            return SearchResultLinks.GetElements().FirstOrDefault(x => x.GetText().ToLower().Equals(linkName.ToLower()));
        }
    }
}
