using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace UITestingHomework
{
    [TestFixture]
    public class LibraryTests
    {
        private IWebDriver driver;
        private string _url = "https://www.library.kpi.ua/";

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
        public void subscribeFormErrorTest()
        {
            IWebElement linkToClick = findBySelector(driver, "li[class = rss] a");
            linkToClick.Click();
            IWebElement nameForm = findBySelector(driver, "input[name = 'your-name']");
            IWebElement surnameForm = findBySelector(driver, "input[name = 'prizv']");
            IWebElement emailForm = findBySelector(driver, "input[name = 'your-email']");
            IWebElement positionForm = findBySelector(driver, "input[name = 'text-867']");
            IWebElement checkbox = findBySelector(driver, "input[name = 'checkbox-34[]']");
            IWebElement submitButton = findBySelector(driver, "input[type='submit']");
            checkbox.Click();
            nameForm.SendKeys("Ilya");
            surnameForm.SendKeys("Tsuprun");
            emailForm.SendKeys("tsuprun_i@ukr.net");
            positionForm.SendKeys("student");
            submitButton.Click();
            var actualErrorAttribute = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/centerb/article/div/div/form/div[2]")).GetAttribute("role");
            Assert.IsNull(actualErrorAttribute);
        }
    }
}