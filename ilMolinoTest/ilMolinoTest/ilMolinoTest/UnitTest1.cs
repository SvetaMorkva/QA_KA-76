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

        [TestCase("//a[@class='box js-add-basket tit_1165015']")]
        [TestCase("//a[@class='box js-add-basket tit_1165008']")]
        [TestCase("//a[@class='box js-add-basket tit_557']")]
        public void TestBuyPizzaInSiteIlMolino(string pizza)
        {
            _driver.FindElement(By.XPath("//div[@class='menu js_drop-menu']//a[@href='/delivery/pizza.html']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(pizza)).Click();
            Thread.Sleep(3000);
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
            Thread.Sleep(3000);
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
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void TestBuyTwoPizzaOneTypeInSiteIlMolino()
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2325']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='box js-add-basket tit_1165015']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='pre_r_a']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='pre_r_a']")).Click();
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("//div//a[@class='plus js-btn-basket-plus']")).Click();
            Thread.Sleep(2000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(2)";
            Assert.AreEqual(expected, count);
        }

        [Test]
        public void TestBuyPizzaWithIngredientsInSiteIlMolino()
        {
            bool result = false;
            string url = "https://ilmolino.ua/delivery/pizza/milano.html";
            _driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//a[@class='button_a js-add-ingr']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//li[@data-absnum='780']//a[@class='plus_ingr js-btn-ingr-plus']")).Click();
            Thread.Sleep(3000);
            string expectedPrice = "264";
            string price = _driver.FindElement(By.XPath("//span[@class='js-lb-price']")).Text;
            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("//a[@class='box js-add-basket tit_704']")]
        [TestCase("//a[@class='box js-add-basket tit_1164320']")]
        public void TestBuySoupInSiteIlMolino(string soup)
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2329']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(soup)).Click();
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }

        [TestCase("//a[@class='box js-add-basket tit_1165205']")]
        [TestCase("//a[@class='box js-add-basket tit_1165308']")]
        [TestCase("//a[@class='box js-add-basket tit_1165165']")]
        public void TestBuyDessertInSiteIlMolino(string dessert)
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2331']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(dessert)).Click();
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }

        [TestCase("//a[@class='box js-add-basket tit_1165004']")]
        [TestCase("//a[@class='box js-add-basket tit_1165005']")]
        [TestCase("//a[@class='box js-add-basket tit_1165006']")]
        public void TestBuyMainDishesInSiteIlMolino(string mainDishes)
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2348']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(mainDishes)).Click();
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }

        [TestCase("//a[@class='box js-add-basket tit_733']")]
        [TestCase("//a[@class='box js-add-basket tit_1163499']")]
        [TestCase("//a[@class='box js-add-basket tit_1165168']")]
        public void TestBuyBeveragesInSiteIlMolino(string beverages)
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2332']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(beverages)).Click();
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }

        [TestCase("EN", "//div[@class='lang_bl']//div//a[@href='/en/delivery.html']")]
        [TestCase("RU", "//div[@class='lang_bl']//div//a[@href='/ru/delivery.html']")]
        [TestCase("UA", "//div//a[@class='lang_opt']")]
        public void TestLocalizationInSiteIlMolino(string expected, string langage)
        {
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div[@class='lang_bl']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(langage)).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div/a[@title='Краща мережа ресторанів']")).Click();
            Thread.Sleep(3000);
            var result = _driver.FindElement(By.XPath("//div[@class='lang_bl']//span//span")).Text;
            Assert.AreEqual(expected, result);
        }

    }
}