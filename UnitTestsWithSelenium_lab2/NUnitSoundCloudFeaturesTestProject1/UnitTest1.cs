using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace NUnitSoundCloudFeaturesTestProject1
{
    public class TurnOnMusicFromPlaylistTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://soundcloud.com/discover");

            //select a playlist
            int selectedListOfPlaylists = 1;
            int selectedPlaylist = 1;
            string playlistXpath = "//body/div[@id='app']/div[contains(@class,'l-container l-content')]/div[@id='content']/div/div[contains(@class,'l-fluid-fixed')]/div[contains(@class,'sc-border-light-right l-main')]/div[contains(@class,'l-content')]/div[contains(@class,'modular-home-mixed-selection lazyLoadingList')]/ul[contains(@class,'lazyLoadingList__list sc-list-nostyle sc-clearfix')]/li[" + selectedListOfPlaylists + "]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + selectedPlaylist + "]/div[1]/div[1]/a[1]";
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var playlistLink = wait.Until(d => d.FindElement(By.XPath(playlistXpath)));
            playlistLink.Click();

            //select a track
            int selectedTrack = 2;
            string trackXpath = "//div[contains(@class,'l-about-main')]//li[" + selectedTrack + "]//div[1]//div[1]//div[1]//span[1]";
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(trackXpath)));
            driver.FindElementByXPath(trackXpath).Click();

            Assert.Pass();
        }
    },
    public class SelectUserWhoLikedTheTrack
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://soundcloud.com/discover");

            //select a playlist
            int selectedListOfPlaylists = 1;
            int selectedPlaylist = 1;
            string playlistXpath = "//body/div[@id='app']/div[contains(@class,'l-container l-content')]/div[@id='content']/div/div[contains(@class,'l-fluid-fixed')]/div[contains(@class,'sc-border-light-right l-main')]/div[contains(@class,'l-content')]/div[contains(@class,'modular-home-mixed-selection lazyLoadingList')]/ul[contains(@class,'lazyLoadingList__list sc-list-nostyle sc-clearfix')]/li[" + selectedListOfPlaylists + "]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + selectedPlaylist + "]/div[1]/div[1]/a[1]";
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var playlistLink = wait.Until(d => d.FindElement(By.XPath(playlistXpath)));
            playlistLink.Click();

            //select a track
            int selectedTrack = 2;
            string trackXpath = "//div[contains(@class,'l-about-main')]//li[" + selectedTrack + "]//div[1]//div[1]//div[1]//span[1]";
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(trackXpath)));
            driver.FindElementByXPath(trackXpath).Click();

            Assert.Pass();
        }
    }

}