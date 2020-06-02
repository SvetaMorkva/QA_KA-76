using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using UITestingHomework_pageobject;

namespace UITestingHomework
{
    [TestFixture]
    public class GoogleTests
    {
        private IWebDriver driver;
        private string _url = "https://google.com";

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
        public void switchToEnglish()
        {
            var chromeMainPage = new TestChromePage(driver);
            chromeMainPage.ClickLinkToClick();
            Assert.IsTrue(chromeMainPage.LanguageSuccesfullyChanged, $"expected actual text to contain 'lucky'");
        }
    }
}