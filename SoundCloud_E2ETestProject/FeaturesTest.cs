using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
}
