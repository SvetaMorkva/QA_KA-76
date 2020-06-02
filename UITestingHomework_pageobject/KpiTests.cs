using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITestingHomework_pageobject
{
    [TestFixture]
    public class KpiTests
    {
        private IWebDriver driver;
        private string _url = "https://kpi.ua/";

        public static IWebElement findBySelector(IWebDriver driver, string selector)
        {
            return driver.FindElement(By.CssSelector(selector));
        }

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }

        [Test]
        public void changeLanguageTest()
        {
            var KpiMainPage = new KpiPage(driver);
            KpiMainPage.ClickEnglishButton();
            Assert.IsTrue(KpiMainPage.NameSuccesfullyChanged);
        }
        
        [Test]
        public void searchFormTest()
        {
            var KpiMainPage = new KpiPage(driver);
            var TextToType = "dnsjfdnjs";
            KpiMainPage.FillSearchField(TextToType);
            Assert.IsTrue(KpiMainPage.SearchCompleted(TextToType));
        }
        
        [Test]
        public void clickLogoTest()
        {
            var KpiMainPage = new KpiPage(driver);
            KpiMainPage.ClickLogo();
            Assert.AreEqual(_url, KpiMainPage.AfterClickLink);
        }
    }
}