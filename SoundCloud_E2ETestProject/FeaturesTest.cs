using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

namespace SoundCloud_E2ETestProject
{
    class ScrollListOfPlaylistsFeatureTest
    {

        private IWebDriver _driver;
        private string _url = "https://soundcloud.com/discover";
        private int sleepTime = 6000;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_url);
            CookiesNotification cookiesNotification = new CookiesNotification(_driver);
            cookiesNotification.AllowCookies();
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ScrollListOfPlaylists_FarwardAndBackwardScroll(int indexOfListOfPlaylists)
        {
            HomePage playlistPage = new HomePage(_driver);
            Thread.Sleep(sleepTime);
            playlistPage.ScrollListOfPlaylistFarward(indexOfListOfPlaylists);
            playlistPage.ScrollListOfPlaylistBackward(indexOfListOfPlaylists);
            Assert.Pass();
        }


        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }

    class SelectUserWhoLikedTheTrackFeatureTest
    {

        private IWebDriver _driver;
        private string _url = "https://soundcloud.com/discover";
        private int sleepTime = 6000;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_url);
            CookiesNotification cookiesNotification = new CookiesNotification(_driver);
            cookiesNotification.AllowCookies();
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 2)]
        public void ShowUsersWhoHaveLikedTrack_AND_SelectUserWhoHaveLikedTrack(int indexOfPlaylist, int indexOfTrack, int indexOfUser)
        {
            HomePage homePage = new HomePage(_driver);
            Thread.Sleep(sleepTime);
            _driver.Navigate().GoToUrl(homePage.GetPlaylistPageURL(indexOfPlaylist));

            PlaylistPage playlistPage = new PlaylistPage(_driver);
            _driver.Navigate().GoToUrl(playlistPage.GetTrackPageURL(indexOfTrack));

            TrackPage trackPage = new TrackPage(_driver);
            _driver.Navigate().GoToUrl(trackPage.GetLikePageURL());

            LikePage likePage = new LikePage(_driver);
            _driver.Navigate().GoToUrl(likePage.GetUserPageURL(indexOfUser));

            Assert.Pass();
        }


        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
