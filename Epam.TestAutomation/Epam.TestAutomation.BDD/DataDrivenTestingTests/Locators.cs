using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TestAutomation.BDD
{
    public static class Locators
    {
        public static By CareersButton => By.XPath("//*[@href = '/careers' and contains(@class, 'top-navigation__item-link')]");
        public static By JobListingsLink => By.XPath("//*[@href = '/careers/job-listings' and contains(@class, 'top-navigation__main-link')]");
        public static By LocationDropdown => By.XPath("//span[contains(@class, 'select2-selection__rendered')]");
        public static By LocationOption(string locationCountry) => By.XPath($"//li[@aria-label='{locationCountry}']");
        public static By NestedLocationOption(string locationCity) => By.XPath($"//ul[contains(@class, 'select2-results__options--nested')]//li[@id and contains(@id, '{locationCity}')]");
        public static By SkillsLocator => By.XPath("//div[contains(@class, 'multi-select-filter') and @role='combobox']");
        public static By SkillsLocatorOptionOne(string skillsOne) => By.XPath($"//span[contains(@class, 'checkbox-custom-label') and text()='{skillsOne}']");
        public static By SkillsLocatorOptionTwo(string skillsTwo) => By.XPath($"//span[contains(@class, 'checkbox-custom-label') and text()='{skillsTwo}']");
        public static By SearchInput => By.Id("new_form_job_search-keyword");
        public static By FindButton => By.XPath("//button[contains(@class, 'job-search-button-transparent-23') and normalize-space()='Find']");
        public static By ErrorMessage => By.XPath("//div[@class='search-result__error-message-23 paragraph']");
        public static By SearchResultElement(string expectedResult) => By.XPath($"//*[contains(text(), '{expectedResult}')]");
    }
}

