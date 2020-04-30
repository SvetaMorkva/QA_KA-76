using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebDriverHomework
{
    public class PageObject
    {
        private IWebDriver driver;

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //search .coreSpriteSearchIcon .TqC_a
        [FindsBy(How = How.CssSelector, Using = ".coreSpriteSearchIcon")]
        private IWebElement searchButton;
        [FindsBy(How = How.CssSelector, Using = ".XTCLo")]
        private IWebElement searchInput;

        //navbar
        [FindsBy(How = How.CssSelector, Using = ".Fifk5:nth-child(1) a")]
        private IWebElement homeButton;
        [FindsBy(How = How.CssSelector, Using = ".Fifk5:nth-child(2) a")]
        private IWebElement inboxButton;
        [FindsBy(How = How.CssSelector, Using = ".Fifk5:nth-child(3) a")]
        private IWebElement exploreButton;
        [FindsBy(How = How.CssSelector, Using = ".Fifk5:nth-child(4) a")]
        private IWebElement activityButton;
        [FindsBy(How = How.CssSelector, Using = ".Fifk5:nth-child(5) a")]
        private IWebElement profileButton;


        public PageObject openHomePage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(homeButton));
            homeButton.Click();
            return this;
        }

        public PageObject openInboxPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(inboxButton));
            inboxButton.Click();
            return this;
        }

        public PageObject openExplorePage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(exploreButton));
            exploreButton.Click();
            return this;
        }

        public PageObject openActivityPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(activityButton));
            activityButton.Click();
            return this;
        }

        public PageObject openProfilePage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(profileButton));
            profileButton.Click();
            return this;
        }


        public IWebElement startSearchInput()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(".XTCLo")));
            return searchInput;
        }
    }
}

