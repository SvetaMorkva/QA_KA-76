using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ilMolinoTest
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver _driver;
        private string _url = "https://ilmolino.ua/delivery.html";

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_url);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(d => d.Url == _url);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }

        [Test]
        public void TestBuyPizzaInSiteIlMolino()
        {
            _driver.FindElement(By.XPath("//div[@class='menu js_drop-menu']//a[@href='/delivery/pizza.html']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='box js-add-basket tit_1165015']")).Click();
            Thread.Sleep(2000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }
        
        [Test]
        public void TestBuyPizzaAndSaladInSiteIlMolino()
        {
            _driver.FindElement(By.XPath("//div[@class='menu js_drop-menu']//a[@href='/delivery/pizza.html']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@data-price='99']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='menu-item-2328']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='box js-add-basket tit_1165002']")).Click();
            Thread.Sleep(2000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(2)";
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void TestBuyHitPizzaInSiteIlMolino()
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2386']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='box js-add-basket tit_577']")).Click();
            Thread.Sleep(2000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void TestBuyTwoPizzaOneTypeSiteIlMolino ()
        {
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='menu-item-2325']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='box js-add-basket tit_1165015']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='pre_r_a']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='pre_r_a']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div//a[@class='plus js-btn-basket-plus']")).Click();
            Thread.Sleep(2000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(2)";
            Assert.AreEqual(expected, count);
        }
        /*
        [Test]
        public void TestBuyPizzaWithIngredientsSiteIlMolino()
        {
            bool result = false;
            string url = "https://ilmolino.ua/delivery/pizza/milano.html";
            _driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='button_a js-add-ingr']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//li[@data-absnum='787']//a[@class='plus_ingr js-btn-ingr-plus']")).Click();
            Thread.Sleep(2000);
            string expectedPrice = "264";
            string price = _driver.FindElement(By.XPath("//span[@class='js-lb-price']")).Text;
            Assert.AreEqual(expectedPrice, price);
        }
        */
        [TestCase ("UA")]
        public void TestLocalizationSiteIlMolino(string expected)
        {
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div[@class=\"lang_bl\"]")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div[@class=\"lang_bl\"]//div//a[@href=\"/en/delivery.html\"]")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div/a[@title=\"Краща мережа ресторанів\"]")).Click();
            Thread.Sleep(2000);
            var result = _driver.FindElement(By.XPath("//div[@class=\"lang_bl\"]//span//span")).Text;
            Assert.AreEqual(expected, result);
        }
        
    }
}
