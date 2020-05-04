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
    public class HomePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div[1]/div/div/div/button")]
        private IWebElement cookiesButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.sc-link-dark.sc-type-light.playableTile__mainHeading.audibleTile__mainHeading.playableTile__heading.playableTile__audibleHeading.audibleTile__audibleHeading.sc-truncate.sc-font-light")]
        private IList<IWebElement> PlaylistsLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.tileGallery__sliderButton.tileGallery__slideForwardButton.sc-button.sc-button-small.sc-button-icon")]
        private IList<IWebElement> PlaylistsScrallFarwardButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.tileGallery__sliderButton.tileGallery__slideBackwardButton.sc-button.sc-button-small.sc-button-icon")]
        private IList<IWebElement> PlaylistsScrallBackwardButton { get; set; }

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);

            try
            {
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(cookiesButton));
                cookiesButton.Click();
            }
            catch { }
        }

        public string GetPlaylistPageURL(int index_Playlist)
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(PlaylistsLink[index_Playlist]));
            return PlaylistsLink[index_Playlist].GetAttribute("href");

        }

        public HomePage ScrollListOfPlaylistFarward(int indexOfListOfPlaylists)
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(PlaylistsScrallFarwardButton[indexOfListOfPlaylists]));
            PlaylistsScrallFarwardButton[indexOfListOfPlaylists].Click();
            return this;
        }

        public HomePage ScrollListOfPlaylistBackward(int indexOfListOfPlaylists)
        {
            new WebDriverWait(_driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(PlaylistsScrallBackwardButton[indexOfListOfPlaylists]));
            PlaylistsScrallBackwardButton[indexOfListOfPlaylists].Click();
            return this;
        }
    }
}
