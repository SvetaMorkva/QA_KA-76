using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace UnitTest_lab2
{
    public class ItemPage
    {

        private IWebDriver _driver;
        public ItemPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".group-app-developer a")]
        private IWebElement WebSite;

        public ItemPage GoToItemWeb()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(WebSite));
            WebSite.Click();
            Thread.Sleep(5000);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            return this;
        }
    }
}
