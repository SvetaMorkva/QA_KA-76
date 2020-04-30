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
        [TestCase("//a[@class='box js-add-basket tit_176024']")]
        [TestCase("//a[@class='box js-add-basket tit_558']")]
        [TestCase("//a[@class='box js-add-basket tit_576']")]
        [TestCase("//a[@class='box js-add-basket tit_560']")]
      /*  [TestCase("//a[@class='box js-add-basket tit_327853']")]
        [TestCase("//a[@class='box js-add-basket tit_12935']")]
        [TestCase("//a[@class='box js-add-basket tit_987']")]
        [TestCase("//a[@class='box js-add-basket tit_39009']")]
        [TestCase("//a[@class='box js-add-basket tit_1163516']")]
        [TestCase("//a[@class='box js-add-basket tit_567']")]
        [TestCase("//a[@class='box js-add-basket tit_1252']")]
        [TestCase("//a[@class='box js-add-basket tit_562']")]
        [TestCase("//a[@class='box js-add-basket tit_577']")]
        [TestCase("//a[@class='box js-add-basket tit_565']")]
        [TestCase("//a[@class='box js-add-basket tit_1159951']")]
        [TestCase("//a[@class='box js-add-basket tit_5216']")]
        [TestCase("//a[@class='box js-add-basket tit_559']")]
        [TestCase("//a[@class='box js-add-basket tit_569']")]
        [TestCase("//a[@class='box js-add-basket tit_568']")]
        [TestCase("//a[@class='box js-add-basket tit_566']")]
        [TestCase("//a[@class='box js-add-basket tit_572']")]
        [TestCase("//a[@class='box js-add-basket tit_554']")]*/
        public void TestBuyPizzaInSiteIlMolino(string pizza)
        {
            _driver.FindElement(By.XPath("//div[@class='menu js_drop-menu']//a[@href='/delivery/pizza.html']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(pizza)).Click();
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            Thread.Sleep(2000);
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
            Thread.Sleep(2000);
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
            Thread.Sleep(2000);
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }
        
        [Test]
        public void TestBuyTwoPizzaOneTypeInSiteIlMolino ()
        {
            Thread.Sleep(2000);
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
            Thread.Sleep(2000);
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
            Thread.Sleep(2000);
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
            Thread.Sleep(2000);
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }
        
        [TestCase("//a[@class='box js-add-basket tit_1165205']")]
        [TestCase("//a[@class='box js-add-basket tit_1165308']")]
        [TestCase("//a[@class='box js-add-basket tit_1165165']")]
        [TestCase("//a[@class='box js-add-basket tit_1165163']")]
        [TestCase("//a[@class='box js-add-basket tit_1165164']")]
        [TestCase("//a[@class='box js-add-basket tit_1165166']")]
        [TestCase("//a[@class='box js-add-basket tit_1165307']")]
        [TestCase("//a[@class='box js-add-basket tit_713']")]
        [TestCase("//a[@class='box js-add-basket tit_5173']")]
        [TestCase("//a[@class='box js-add-basket tit_1163606']")]
        public void TestBuyDessertInSiteIlMolino(string dessert)
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2331']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(dessert)).Click();
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            Thread.Sleep(2000);
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }

        [TestCase("//a[@class='box js-add-basket tit_1165004']")]
        [TestCase("//a[@class='box js-add-basket tit_1165005']")]
        [TestCase("//a[@class='box js-add-basket tit_1165006']")]
        [TestCase("//a[@class='box js-add-basket tit_829']")]
        [TestCase("//a[@class='box js-add-basket tit_5443']")]
        [TestCase("//a[@class='box js-add-basket tit_1163511']")]
        [TestCase("//a[@class='box js-add-basket tit_710']")]
        [TestCase("//a[@class='box js-add-basket tit_1162353']")]
        [TestCase("//a[@class='box js-add-basket tit_7372']")]
        [TestCase("//a[@class='box js-add-basket tit_709']")]
        [TestCase("//a[@class='box js-add-basket tit_706']")]
        public void TestBuyMainDishesInSiteIlMolino(string mainDishes)
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2348']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(mainDishes)).Click();
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            Thread.Sleep(2000);
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }
        /*
        [TestCase("//a[@class='box js-add-basket tit_733']")]
        [TestCase("//a[@class='box js-add-basket tit_39093']")]
        [TestCase("//a[@class='box js-add-basket tit_1165168']")]
        [TestCase("//a[@class='box js-add-basket tit_1165167']")]
        [TestCase("//a[@class='box js-add-basket tit_1165254']")]
        [TestCase("//a[@class='box js-add-basket tit_1165253']")]
        [TestCase("//a[@class='box js-add-basket tit_1165252']")]
        [TestCase("//a[@class='box js-add-basket tit_1165265']")]
        [TestCase("//a[@class='box js-add-basket tit_1165266']")]
        [TestCase("//a[@class='box js-add-basket tit_1165269']")]
        [TestCase("//a[@class='box js-add-basket tit_1165268']")]
        [TestCase("//a[@class='box js-add-basket tit_3352']")]
        [TestCase("//a[@class='box js-add-basket tit_733']")]
        [TestCase("//a[@class='box js-add-basket tit_733']")]
        [TestCase("//a[@class='box js-add-basket tit_733']")]
        [TestCase("//a[@class='box js-add-basket tit_1165250']")]
        [TestCase("//a[@class='box js-add-basket tit_1165251']")]
        [TestCase("//a[@class='box js-add-basket tit_1165249']")]
        [TestCase("//a[@class='box js-add-basket tit_1165245']")]
        [TestCase("//a[@class='box js-add-basket tit_1165027']")]
        [TestCase("//a[@class='box js-add-basket tit_1165028']")]
        [TestCase("//a[@class='box js-add-basket tit_1163491']")]
        [TestCase("//a[@class='box js-add-basket tit_1165241']")]
        [TestCase("//a[@class='box js-add-basket tit_1163492']")]
        [TestCase("//a[@class='box js-add-basket tit_1164622']")]
        [TestCase("//a[@class='box js-add-basket tit_1163495']")]
        [TestCase("//a[@class='box js-add-basket tit_1163498']")]
        [TestCase("//a[@class='box js-add-basket tit_1163496']")]
        [TestCase("//a[@class='box js-add-basket tit_1163506']")]
        [TestCase("//a[@class='box js-add-basket tit_1163500']")]
        [TestCase("//a[@class='box js-add-basket tit_1163505']")]
        [TestCase("//a[@class='box js-add-basket tit_1163503']")]
        [TestCase("//a[@class='box js-add-basket tit_1163502']")]
        [TestCase("//a[@class='box js-add-basket tit_1163514']")]
        [TestCase("//a[@class='box js-add-basket tit_1163513']")]
        [TestCase("//a[@class='box js-add-basket tit_725']")]
        [TestCase("//a[@class='box js-add-basket tit_724']")]
        [TestCase("//a[@class='box js-add-basket tit_723']")]
        [TestCase("//a[@class='box js-add-basket tit_722']")]
        [TestCase("//a[@class='box js-add-basket tit_38765']")]
        [TestCase("//a[@class='box js-add-basket tit_38767']")]
        [TestCase("//a[@class='box js-add-basket tit_38764']")]
        [TestCase("//a[@class='box js-add-basket tit_38766']")]
        [TestCase("//a[@class='box js-add-basket tit_739']")]
        [TestCase("//a[@class='box js-add-basket tit_1163488']")]
        [TestCase("//a[@class='box js-add-basket tit_1163490']")]
        [TestCase("//a[@class='box js-add-basket tit_1163499']")]
        public void TestBuyBeveragesInSiteIlMolino(string beverages)
        {
            _driver.FindElement(By.XPath("//a[@class='menu-item-2332']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath(beverages)).Click();
            Thread.Sleep(3000);
            string count = _driver.FindElement(By.XPath("//span[@class='js-lb-basket-qty']")).Text;
            Thread.Sleep(2000);
            string expected = "(1)";
            Assert.AreEqual(expected, count);
        }
        */
        [TestCase ("EN")]
        public void TestLocalizationInSiteIlMolino(string expected)
        {
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div[@class=\"lang_bl\"]")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div[@class=\"lang_bl\"]//div//a[@href=\"/en/delivery.html\"]")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//div/a[@title=\"Краща мережа ресторанів\"]")).Click();
            Thread.Sleep(3000);
            var result = _driver.FindElement(By.XPath("//div[@class=\"lang_bl\"]//span//span")).Text;
            Thread.Sleep(2000);
            Assert.AreEqual(expected, result);
        }

    }
}
