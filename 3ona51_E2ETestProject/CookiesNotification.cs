using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace _3ona51_E2ETestProject
{
    class CookiesNotification
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "cookiesAcceptButton")]
        private IWebElement cookiesButton { get; set; }

        public CookiesNotification(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public CookiesNotification AllowCookies()
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(cookiesButton));
                cookiesButton.Click();
            }
            catch { }
            return this;
        }
    }
}