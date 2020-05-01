using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace LabWork3.Pages
{
    public class GoogleSearchResultsPage
    {
        private IWebDriver _driver;

        public GoogleSearchResultsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String GetCurrntUrl() => _driver.Url;
    }
}
