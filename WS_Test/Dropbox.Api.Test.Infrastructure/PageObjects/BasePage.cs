using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Dropbox.Api.Test.Infrastructure.PageObjects
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetUrl()
        {
            return driver.Url;
        }
    }
}
