using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace NUnitSoundCloudFeaturesTestProject1
{   
    public class TurnOnMusicFromPlaylistTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TurnSongOnFromPlaylistTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://soundcloud.com/discover");
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            try
            {
                string cookyButtonXpath = "//*[@id='app']/div[1]/div/div/div/button";
                var cookyButton = wait.Until(d => d.FindElement(By.XPath(cookyButtonXpath)));
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(cookyButtonXpath)));
                cookyButton.Click();

            }
            catch { }

            //select a playlist
            int selectedListOfPlaylists = 1;
            int selectedPlaylist = 1;
            string playlistXpath = "//body/div[@id='app']/div[contains(@class,'l-container l-content')]/div[@id='content']/div/div[contains(@class,'l-fluid-fixed')]/div[contains(@class,'sc-border-light-right l-main')]/div[contains(@class,'l-content')]/div[contains(@class,'modular-home-mixed-selection lazyLoadingList')]/ul[contains(@class,'lazyLoadingList__list sc-list-nostyle sc-clearfix')]/li[" + selectedListOfPlaylists + "]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + selectedPlaylist + "]/div[1]/div[1]/a[1]";
            var playlistLink = wait.Until(d => d.FindElement(By.XPath(playlistXpath)));
            playlistLink.Click();

            //select a track
            int selectedTrack = 1;
            string trackXpath = "//div[contains(@class,'l-about-main')]//li[" + selectedTrack + "]//div[1]//div[1]//div[1]//span[1]";
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(trackXpath)));
            driver.FindElementByXPath(trackXpath).Click();
            driver.Close();

            Assert.Pass();
        }
    }
    public class SelectUserWhoLikedTheTrack
    {
        [SetUp]
        public void Setup()
        {
        }

        private IWebElement getLikeScoreLink(IWebDriver driver )
        {
            driver.Navigate().GoToUrl("https://soundcloud.com/discover");
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            try
            {
                string cookyButtonXpath = "//*[@id='app']/div[1]/div/div/div/button";
                var cookyButton = wait.Until(d => d.FindElement(By.XPath(cookyButtonXpath)));
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(cookyButtonXpath)));
                cookyButton.Click();

            }
            catch { }

            //select a playlist
            int selectedListOfPlaylists = 1;
            int selectedPlaylist = 1;
            string playlistXpath = "//body/div[@id='app']/div[contains(@class,'l-container l-content')]/div[@id='content']/div/div[contains(@class,'l-fluid-fixed')]/div[contains(@class,'sc-border-light-right l-main')]/div[contains(@class,'l-content')]/div[contains(@class,'modular-home-mixed-selection lazyLoadingList')]/ul[contains(@class,'lazyLoadingList__list sc-list-nostyle sc-clearfix')]/li[" + selectedListOfPlaylists + "]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + selectedPlaylist + "]/div[1]/div[1]/a[1]";
            var playlistLink = wait.Until(d => d.FindElement(By.XPath(playlistXpath)));
            playlistLink.Click();

            //I have opened the track
            int selectedTrack = 2;
            string trackXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/ul[1]/li[" + selectedTrack + "]/div[1]/div[3]/a[2]";
            var trackLink = wait.Until(d => d.FindElement(By.XPath(trackXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(trackXpath)));
            trackLink.Click();

            //I have pressed the LikeScoreLink
            string likeScoreXpath = "//*[@id='content']/div/div[3]/div[1]/div/div[1]/div/div/div[2]/ul/li[2]/a";
            var likeScoreLink = wait.Until(d => d.FindElement(By.XPath(likeScoreXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(likeScoreXpath)));
            return likeScoreLink;
        }

        [Test]
        public void ShowUsersWhoHaveLikedTrackTest()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            IWebElement likeScoreLink = getLikeScoreLink(driver);
            string likeScore = likeScoreLink.Text;
            likeScoreLink.Click();

            if (likeScore[0] != '0')
            {
                var lu = wait.Until(d => d.FindElement(By.XPath("//*[@id='content']/div/div/div[2]/div/div/ul")));
                IList<IWebElement> amountOfUsersWhoLikedTheTrack = lu.FindElements(By.TagName("li"));
                if (amountOfUsersWhoLikedTheTrack.Count == 0) Assert.Fail("Error: LikeScore = " + likeScore + " but amountOfUsersWhoLikedTheTrack = " + amountOfUsersWhoLikedTheTrack.Count );
            }

            driver.Close();
            Assert.Pass();
        }

        [Test]
        public void SelectUserWhoLikedTrackTest()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            IWebElement likeScoreLink = getLikeScoreLink(driver);
            string likeScore = likeScoreLink.Text;
            likeScoreLink.Click();

            if (likeScore[0] != '0')
            {
                string userWhoLikedTrackXpath = "//*[@id='content']/div/div/div[2]/div/div/ul/li[1]/div/div[1]/a";
                var userWhoLikedTrackLink = wait.Until(d => d.FindElement(By.XPath(userWhoLikedTrackXpath)));
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(userWhoLikedTrackXpath)));
                userWhoLikedTrackLink.Click();
            }

            driver.Close();
            Assert.Pass();
        }
    }

}