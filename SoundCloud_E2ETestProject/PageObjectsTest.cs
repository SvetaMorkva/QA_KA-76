using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SoundCloud_E2ETestProject
{
    public class HomePageTest
    {
        private IWebDriver _driver;
        private string _url = "https://soundcloud.com/discover";
        private int sleepTime = 6000;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_url);
        }


        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void GoToPlaylistPage(int indexInPlaulistList)
        {
            HomePage homePage = new HomePage(_driver);
            Thread.Sleep(sleepTime);
            _driver.Navigate().GoToUrl(homePage.GetPlaylistPageURL(indexInPlaulistList));
            Assert.Pass();
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ScrollListOfPlaylists_FarwardScroll(int indexOfListOfPlaylists)
        {
            HomePage playlistPage = new HomePage(_driver);
            Thread.Sleep(sleepTime);
            playlistPage.ScrollListOfPlaylistFarward(indexOfListOfPlaylists);
            Assert.Pass();
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ScrollListOfPlaylists_FarwardAndBackwardScroll(int indexOfListOfPlaylists)
        {
            HomePage homePage = new HomePage(_driver);
            Thread.Sleep(sleepTime);
            homePage.ScrollListOfPlaylistFarward(indexOfListOfPlaylists);
            homePage.ScrollListOfPlaylistBackward(indexOfListOfPlaylists);
            Assert.Pass();
        }


        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }

    public class PlaylistPageTest
    {
        private IWebDriver _driver;
        private string _url = "https://soundcloud.com/user-876658341/sets/sunday-music-and-hot-coffee";
        private int sleepTime = 6000;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void TurnOnTrack(int indexInTrackList)
        {
            PlaylistPage playlistPage = new PlaylistPage(_driver);
            Thread.Sleep(sleepTime);
            playlistPage.PlayTrack(indexInTrackList);
            Assert.Pass();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void GoToTrackPage(int indexInTrackList)
        {
            PlaylistPage playlistPage = new PlaylistPage(_driver);
            Thread.Sleep(sleepTime);
            _driver.Navigate().GoToUrl(playlistPage.GetTrackPageURL(indexInTrackList));
            Assert.Pass();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }

    public class TrackPageTest
    {
        private IWebDriver _driver;
        private string _url = "https://soundcloud.com/ruucampbell/crossroads-heartsong-ruu?in=user-876658341/sets/sunday-music-and-hot-coffee";
        private int sleepTime = 6000;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        [Test]
        public void GoToLikePage()
        {
            TrackPage trackPage = new TrackPage(_driver);
            Thread.Sleep(sleepTime);
            _driver.Navigate().GoToUrl(trackPage.GetLikePageURL());
            Assert.Pass();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }

    public class LikePageTest
    {
        private IWebDriver _driver;
        private string _url = "https://soundcloud.com/ruucampbell/crossroads-heartsong-ruu/likes";
        private int sleepTime = 6000;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_url);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GoToUserWhoLikedPage(int indexOfUserWhoLiked)
        {
            LikePage likePage = new LikePage(_driver);
            Thread.Sleep(sleepTime);
            _driver.Navigate().GoToUrl(likePage.GetUserPage(indexOfUserWhoLiked));
            Assert.Pass();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }


}