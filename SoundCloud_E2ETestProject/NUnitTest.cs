using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SoundCloud_E2ETestProject
{
    public class PlaylistPageTest
    {
        private IWebDriver _driver;
        private string _url = "https://soundcloud.com/user-876658341/sets/sunday-music-and-hot-coffee";

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
            playlistPage.PlayTrack(indexInTrackList);
            Assert.Pass();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void GoToTrackPage(int indexInTrackList)
        {
            PlaylistPage playlistPage = new PlaylistPage(_driver);
            Thread.Sleep(6000);
            _driver.Navigate().GoToUrl(playlistPage.GetTrackURL(indexInTrackList));
            Assert.Pass();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }

    public class HomePageTest
    {
        private IWebDriver _driver;
        private string _url = "https://soundcloud.com/discover";

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
            HomePage playlistPage = new HomePage(_driver);
            Thread.Sleep(6000);
            _driver.Navigate().GoToUrl(playlistPage.GetPlaylistURL(indexInPlaulistList));
            Assert.Pass();
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ScrollListOfPlaylists_FarwardScroll(int indexOfListOfPlaylists)
        {
            HomePage playlistPage = new HomePage(_driver);
            Thread.Sleep(6000);
            playlistPage.ScrollListOfPlaylistFarward(indexOfListOfPlaylists);
            Assert.Pass();
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ScrollListOfPlaylists_FarwardAndBackwardScroll(int indexOfListOfPlaylists)
        {
            HomePage playlistPage = new HomePage(_driver);
            Thread.Sleep(6000);
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
}