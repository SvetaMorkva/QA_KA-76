using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Laba2_part2
{
    [TestFixture]
    class Test
    {
        private IWebDriver driver;
        [Obsolete]
        [SetUp]
        public void TestInitialize()
        {
            var option = new ChromeOptions();
            driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua");
                
        }
        [TearDown]
        public void TestCleanup()
        {
            driver.Quit();
        }

        [Obsolete]
        [Test]
        public void TestMethod1()
        {
            var WebPage = new Page(driver);
            WebPage.GoToBouquetPage();
            WebPage.Selection();
            var nameclass = WebPage.GetArrowStatus();
            using (new AssertionScope())
            {
                nameclass.Should().Be("acc opened");
            }
        }
        [Obsolete]
        [Test]
        public void TestMethod2()
        {
        var WebPage = new Page(driver);
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua/bukety/");
            WebPage.GoToFlowersPage();
            var title = WebPage.GetFlowerTitle();
            using (new AssertionScope())
            {
                title.Should().Be("9 Гербер");
            }
        }
        [Obsolete]
        [Test]
        public void TestMethod3()
        {
        var WebPage = new Page(driver);
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua/9-gerber");
            WebPage.Buy();
            var title = WebPage.GetBasketPageTitle();
            using (new AssertionScope())
            {
                title.Should().Be("Оформление заказа");
            }
        }
        [Obsolete]
        [Test]
        public void TestMethod4()
        {
        var WebPage = new Page(driver);
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua/order/cart!view.do/");
            WebPage.GoToHomePage();
            var title = WebPage.GetHomePageTitle();
            using (new AssertionScope())
            {
                title.Should().Be("Поводы");
            }
        }
        [Obsolete]
        [Test]
        public void TestMethod5()
        {
        var WebPage = new Page(driver);
            WebPage.GoToBasketPage();
            var title = WebPage.GetBasketPageTitle();
            using (new AssertionScope())
            {
                title.Should().Be("Оформление заказа");
            }
        }
        [Obsolete]
        [Test]
        public void TestMethod6()
        {
        var WebPage = new Page(driver);
            driver.Navigate().GoToUrl("http://megacvet24.kiev.ua/9-gerber");
            WebPage.Buy();
            WebPage.GoToFiveStep();
            WebPage.ChoosePayWay();
            WebPage.Submit();
            Thread.Sleep(3000);
            var site = WebPage.GetSite();
            using (new AssertionScope())
            {
                site.Should().Be("https://www.interkassa.com/");
            }
        }
        [Obsolete]
        [Test]
        public void TestMethod7()
        {
        var WebPage = new Page(driver);
            WebPage.GoToContactPage();
            var phone = WebPage.GetPhoneNumber();
            using (new AssertionScope())
            {
                phone.Should().Be("tel:+380443916779");
            }
        }
        [Obsolete]
        [Test]
        public void TestMethod8()
        {
        var WebPage = new Page(driver);
            WebPage.GoToContactPage();
            var email = WebPage.GetEmail();
            using (new AssertionScope())
            {
                email.Should().Be("mailto:info@megacvet24.kiev.ua");
            }
        }

        
    }
}
