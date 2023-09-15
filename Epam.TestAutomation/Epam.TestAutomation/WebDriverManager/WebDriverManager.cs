using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Epam.TestAutomation.Core.WebDriverManager
{
    public static class WebDriverManager
    {
        private static IWebDriver _driver;

        public static void Initialize()
        {
            _driver = new ChromeDriver();
        }

        public static IWebDriver Driver
        {
            get { return _driver; }
        }

        public static void Quit()
        {
            _driver.Quit();
        }
    }
}
