using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
namespace UnitTest_lab2
{
    public class MainPage
    {
        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".eu-cookie-compliance-buttons button")]
        private IWebElement PopUp1;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Close']")]
        private IWebElement PopUp2;

        [FindsBy(How = How.CssSelector, Using = "#block-mainmenu li:nth-of-type(5) a")]
        private IWebElement PartnerPage;

        [FindsBy(How = How.CssSelector, Using = "#block-mainmenu li:nth-of-type(5) div.main-menu-submenu-row div:nth-child(2)  li:nth-child(1)  a")]
        private IWebElement Catalog;


        public MainPage CloseNotification()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(PopUp1));
            PopUp1.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(PopUp2));
            PopUp2.Click();
            return this;
        }

        public MainPage GoToPartnersPage()
        {
            Actions actions = new Actions(_driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(PartnerPage));
            actions.DoubleClick(PartnerPage).Perform();
            js.ExecuteScript("window.scrollBy(0,250)", "");
            return this;
        }

        public MainPage GoToCatalogPage()
        {
            
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(PartnerPage));
            new WebDriverWait(_driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(Catalog));
            Actions action = new Actions(_driver);
            action.MoveToElement(PartnerPage).Perform();
            Catalog.Click();
            return this;
        }
    }
}
