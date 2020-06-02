using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITestingHomework
{
    [TestFixture]
    public class KPITests
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
            IWebElement changeToEnglistButton = findBySelector(driver, "a[lang='en']");
            changeToEnglistButton.Click();
            IWebElement newEnglishName = findBySelector(driver, "div[class='site-branding__slogan']");
            var actualText = newEnglishName.GetAttribute("innerHTML");
            var textToContain = "national";
            Assert.IsTrue(actualText.ToLower().Contains(textToContain), $"expected actual text '{actualText}' to contain '{textToContain}'");
        }

        [Test]
        public void searchFormTest()
        {
            IWebElement searchForm = findBySelector(driver, "input[name='keys']");
            var textToType = "fnjsjnfdnj";
            searchForm.SendKeys(textToType);
            searchForm.Submit();
            IWebElement searchResult = findBySelector(driver, "h1[class='title page-title']");
            var actualResult = searchResult.GetAttribute("innerHTML");
            Assert.IsTrue(actualResult.ToLower().Contains(textToType));
        }

        [Test]
        public void clickLogoTest()
        {
            IWebElement logolink = findBySelector(driver, "a[title='Головна']");
            logolink.Click();
            var urlAfterClick = driver.Url;
            Assert.AreEqual(_url, urlAfterClick);
        }
    }
}