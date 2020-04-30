using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Lab2
{
    
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            var option = new ChromeOptions();
            driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua");
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }


        [TestMethod]
        public void TestMethod1()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div/div[1]/nav/div/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("/html / body / div[2] / div[1] / div[1] / ul / li[1] / span")).Click();
            var nameclass = driver.FindElement(By.XPath("/html / body / div[2] / div[1] / div[1] / ul / li[1] / span")).GetAttribute("class");
            Assert.AreEqual(nameclass,"acc opened");
        }
        [TestMethod]
        public void TestMethod2()
        {
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua/bukety/");
            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[2]/div[1]/div[2]/div/div[1]/h4/a")).Click();
            var title = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[1]/h1")).Text;
            Assert.AreEqual(title, "9 Гербер");
        }
        [TestMethod]
        public void TestMethod3()
        {
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua/9-gerber");
            driver.FindElement(By.CssSelector("#button-cart")).Click();
            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/h1")).Text;
            Assert.AreEqual(title, "Оформление заказа");
        }
        [TestMethod]
        public void TestMethod4()
        {
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua/order/cart!view.do/");
            driver.FindElement(By.CssSelector("#logo > a:nth-child(1)")).Click();
            var title = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/h2")).Text;
            Assert.AreEqual(title, "Поводы");
        }
        [TestMethod]
        public void TestMethod5()
        {
            driver.FindElement(By.CssSelector(".cart-href")).Click();
            var title = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/h1")).Text;
            Assert.AreEqual(title, "Оформление заказа");
        }
        [TestMethod]
        public void TestMethod6()
        {
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua/order/cart!view.do/");
            driver.FindElement(By.CssSelector("#step_five > div:nth-child(3) > a:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector("div.radio:nth-child(1) > label:nth-child(1) > div:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("button.next-step-button:nth-child(5)")).Click();
            var site = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div/a")).GetAttribute("href");
            Assert.AreEqual(site, "https://www.interkassa.com/");
        }
        [TestMethod]
        public void TestMethod7()
        {
            driver.FindElement(By.CssSelector("div.col-xl-auto:nth-child(1) > a:nth-child(7)")).Click();
            var phone = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div/div/span/a[1]")).GetAttribute("href");
            Assert.AreEqual(phone, "tel:+380443916779");
        }
        [TestMethod]
        public void TestMethod8()
        {
            driver.FindElement(By.CssSelector("div.col-xl-auto:nth-child(1) > a:nth-child(7)")).Click();
            var phone = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[3]/div/div[2]/div/a")).GetAttribute("href");
            Assert.AreEqual(phone, "mailto:info@megacvet24.kiev.ua");
        }

    }
}
