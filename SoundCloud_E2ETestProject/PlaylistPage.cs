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
    class PlaylistPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div[1]/div/div/div/button")]
        private IWebElement cookiesButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.trackItem.g-flex-row.sc-type-small.sc-type-light")]
        private IList<IWebElement> Tracks { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.trackItem.g-flex-row.sc-type-small.sc-type-light a.trackItem__trackTitle.sc-link-dark.sc-font-light")]
        private IList<IWebElement> TrackPageLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.trackItem.g-flex-row.sc-type-small.sc-type-light span[class$='image__full g-opacity-transition']")]
                                         
        private IList<IWebElement> TrackPlayButton { get; set; }

        public PlaylistPage(IWebDriver driver)
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

        private PlaylistPage GoToElement(IWebElement element)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
            //scrall down in order to the MusicPlayerElement doesn't overlap the element
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,100)"); 

            return this;

        }

        public PlaylistPage PlayTrack(int index_Track)
        {
            GoToElement(Tracks[index_Track]);
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(TrackPlayButton[index_Track]));
            TrackPlayButton[index_Track].Click();
            return this;
        }

        public string GetTrackPageURL(int index_Track)
        {
            GoToElement(TrackPageLink[index_Track]);
            return TrackPageLink[index_Track].GetAttribute("href");
        }
    }
}
