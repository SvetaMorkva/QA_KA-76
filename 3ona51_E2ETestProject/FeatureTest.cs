using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace _3ona51_E2ETestProject
{
    class ProductBasketTest
    {
        private IWebDriver _driver;
        private string _url = "https://www.3ona51.com/ru/gaming-devices/";
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
        [TestCase(3)]
        public void AddProductToTheProductBasket(int indexOfProduct)
        {
            GamingDevicePage gamingDevicePage = new GamingDevicePage(_driver);
            Thread.Sleep(sleepTime);
            gamingDevicePage.BuyProduct(indexOfProduct);
            int actualResult = gamingDevicePage.AmountOfProductsInBusket();
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void DeleteProductToTheProductBasket(int indexOfProduct)
        {
            GamingDevicePage gamingDevicePage = new GamingDevicePage(_driver);
            Thread.Sleep(sleepTime);
            gamingDevicePage.BuyProduct(indexOfProduct);
            gamingDevicePage.DeleteProductFromProductBusket(0);

            Thread.Sleep(sleepTime);
            int actualResult = gamingDevicePage.AmountOfProductsInBusket();
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
