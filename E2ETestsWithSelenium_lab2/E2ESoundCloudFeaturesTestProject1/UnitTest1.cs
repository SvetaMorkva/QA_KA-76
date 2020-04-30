using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace E2ESoundCloudFeaturesTestProject1
{   
    public class TurnOnMusicFromPlaylistTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 1, 1)]
        [TestCase(3, 2, 2)]
        [TestCase(2, 1, 3)]
        public void TurnSongOnFromPlaylistTest(int selectedListOfPlaylists, int selectedPlaylist, int selectedTrack)
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
            string playlistXpath = "//*[@id='content']/div/div/div[1]/div[2]/div/ul/li[" + selectedListOfPlaylists + "]/ div/div[2]/div[1]/div/div/div[" + selectedPlaylist + "]/div/div[2]/div[1]/a";
            var playlistLink = wait.Until(d => d.FindElement(By.XPath(playlistXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(playlistXpath)));
            playlistLink.Click();

            //TurnOn a track from the playlist
            string trackXpath = "//*[@id='content']/div/div[3]/div[1]/div/div[2]/div[2]/div/div[3]/div/ul/li[" + selectedTrack + "]/div";
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(trackXpath)));
            driver.FindElementByXPath(trackXpath).Click();
            driver.Quit();

            Assert.Pass();
        }
    }

    public class ScrollListOfPlaylists
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ScrollListOfPlaylistsTest(int selectedListOfPlaylists)
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

            string sliderFarwardButtonXpath = "//*[@id='content']/div/div/div[1]/div[2]/div/ul/li[" + selectedListOfPlaylists + "]/ div/div[2]/div[2]/button";
            var sliderFarwardButton = wait.Until(d => d.FindElement(By.XPath(sliderFarwardButtonXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(sliderFarwardButtonXpath)));
            sliderFarwardButton.Click();

            string sliderBackwardButtonXpath = "//*[@id='content']/div/div/div[1]/div[2]/div/ul/li[" + selectedListOfPlaylists + "]/div/div[2]/div[3]/button";
            var sliderBackwardButton = wait.Until(d => d.FindElement(By.XPath(sliderBackwardButtonXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(sliderBackwardButtonXpath)));
            sliderBackwardButton.Click();

            driver.Quit();
            Assert.Pass();
        }

    }

    public class SignIn
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SignInTest()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://soundcloud.com/discover");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                string cookyButtonXpath = "//*[@id='app']/div[1]/div/div/div/button";
                var cookyButton = wait.Until(d => d.FindElement(By.XPath(cookyButtonXpath)));
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(cookyButtonXpath)));
                cookyButton.Click();

            }
            catch { }

            string signInButtonXpath = "//*[@id='app']/header/div/div[3]/div[1]/button[1]";
            var signInButton = wait.Until(d => d.FindElement(By.XPath(signInButtonXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(signInButtonXpath)));
            signInButton.Click();


            string signInIframeXpath = "//iframe[@class='webAuthContainer__iframe']";
            var detailFrame = wait.Until(d => d.FindElement(By.XPath(signInIframeXpath)));
            driver.SwitchTo().Frame(detailFrame);

            string signInEmailInputXpath = "//*[@id='sign_in_up_email']";
            wait.Until(d => d.FindElement(By.XPath(signInEmailInputXpath))).SendKeys("voiceofreason@ukr.net");

            string signInContinueButtonXpath = "//*[@id='sign_in_up_submit']";
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(signInContinueButtonXpath))).Click();

            string signInPasswordInputXpath = "//*[@id='enter_password_field']";
            wait.Until(d => d.FindElement(By.XPath(signInPasswordInputXpath))).SendKeys("catcatcatcat");

            string signInFinishButtonXpath = "//*[@id='enter_password_submit']";
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(signInFinishButtonXpath))).Click();

            driver.Quit();

            Assert.Pass();
        }

    }

    public class SelectUserWhoLikedTheTrack
    {
        [SetUp]
        public void Setup()
        {
        }

        private IWebElement getLikeScoreLink(IWebDriver driver, int selectedListOfPlaylists, int selectedPlaylist, int selectedTrack)
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
            string playlistXpath = "//*[@id='content']/div/div/div[1]/div[2]/div/ul/li[" + selectedListOfPlaylists + "]/ div/div[2]/div[1]/div/div/div[" + selectedPlaylist + "]/div/div[2]/div[1]/a";
            var playlistLink = wait.Until(d => d.FindElement(By.XPath(playlistXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(playlistXpath)));
            playlistLink.Click();

            //I have opened the track
            string trackXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/ul[1]/li[" + selectedTrack + "]/div[1]/div[3]/a[2]";
            var trackLink = wait.Until(d => d.FindElement(By.XPath(trackXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(trackXpath)));
            trackLink.Click();

            //I have pressed the LikeScoreLink
            string likeScoreXpath = "//*[@id='content']/div/div[3]/div[1]/div/div[1]/div/div/div[2]/ul/li[2]/a";
            Thread.Sleep(4000);
            var likeScoreLink = wait.Until(d => d.FindElement(By.XPath(likeScoreXpath)));
            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(likeScoreXpath)));
            return likeScoreLink;
        }


        [TestCase(1,1,1)]
        [TestCase(1, 1, 2)]
        [TestCase(1,2,1)]
        public void ShowUsersWhoHaveLikedTrackTest(int selectedListOfPlaylists, int selectedPlaylist, int selectedTrack)
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            IWebElement likeScoreLink = getLikeScoreLink(driver, selectedListOfPlaylists, selectedPlaylist, selectedTrack);
            string likeScore = likeScoreLink.Text;
            likeScoreLink.Click();

            if (likeScore[0] != '0')
            {
                var lu = wait.Until(d => d.FindElement(By.XPath("//*[@id='content']/div/div/div[2]/div/div/ul")));
                IList<IWebElement> amountOfUsersWhoLikedTheTrack = lu.FindElements(By.TagName("li"));
                if (amountOfUsersWhoLikedTheTrack.Count == 0) Assert.Fail("Error: LikeScore = " + likeScore + " but amountOfUsersWhoLikedTheTrack = " + amountOfUsersWhoLikedTheTrack.Count );
            }

            driver.Quit();
            Assert.Pass();
        }

        [Test]
        public void SelectUserWhoLikedTrackTest()
        {
            var driver = new ChromeDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            IWebElement likeScoreLink = getLikeScoreLink(driver, 1, 1, 1);
            string likeScore = likeScoreLink.Text;
            likeScoreLink.Click();

            if (likeScore[0] != '0')
            {
                string userWhoLikedTrackXpath = "//*[@id='content']/div/div/div[2]/div/div/ul/li[1]/div/div[1]/a";
                var userWhoLikedTrackLink = wait.Until(d => d.FindElement(By.XPath(userWhoLikedTrackXpath)));
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(userWhoLikedTrackXpath)));
                userWhoLikedTrackLink.Click();
            }

            driver.Quit();
            Assert.Pass();
        }
    }

}