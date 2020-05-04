using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SoundCloud_E2ETestProject
{
    class TrackPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div[1]/div/div/div/button")]
        private IWebElement cookiesButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.sc-ministats.sc-ministats-medium.sc-ministats-likes")]
        private IWebElement LikeScoreLink { get; set; }

        public TrackPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            PageFactory.InitElements(driver, this);

            try
            {
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(cookiesButton));
                cookiesButton.Click();
            }
            catch { }
        }

        private TrackPage GoToElement(IWebElement element)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
            //scrall down in order to the MusicPlayerElement doesn't overlap the element
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,100)");

            return this;

        }

        public string GetLikePageURL()
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(LikeScoreLink));
            return LikeScoreLink.GetAttribute("href");

        }

    }
}
