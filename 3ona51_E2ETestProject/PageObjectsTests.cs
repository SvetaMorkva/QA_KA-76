using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace _3ona51_E2ETestProject
{
    public class GamingDevicePageTest
    {
        private IWebDriver _driver;
        private string _url = "https://www.3ona51.com/ru/gaming-devices/";
        private int sleepTime = 3000;

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
        [TestCase(3)]
        public void BuyProduct(int indexOfProduct)
        {
            GamingDevicePage gamingDevicePage = new GamingDevicePage(_driver);
            Thread.Sleep(sleepTime);
            gamingDevicePage.BuyProduct(indexOfProduct);
            Assert.Pass();
        }

        [Test]
        public void OpenAndCloseProductBasket()
        {
            GamingDevicePage gamingDevicePage = new GamingDevicePage(_driver);
            Thread.Sleep(sleepTime);
            gamingDevicePage.OpenProductBusket().CloseProductBusket();

            Assert.Pass();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void SumUpOrderPrice(int indexOfProduct)
        {
            GamingDevicePage gamingDevicePage = new GamingDevicePage(_driver);
            Thread.Sleep(sleepTime);
            gamingDevicePage.BuyProduct(indexOfProduct);
            int SumUpOrderPrice = gamingDevicePage.GetSumUpOrderPrice();
            Assert.Pass();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }

    }
}