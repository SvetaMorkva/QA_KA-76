using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITestingHomework
{
    [TestFixture]
    public class Tests
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
            IWebElement link_to_click = findBySelector(driver, "div[id='SIvCob'] a:nth-of-type(2)");
            link_to_click.Click();
            IWebElement changed_input = findBySelector(driver, "div[class='FPdoLc tfB0Bf'] input[class='RNmpXc']");
            var actualText = changed_input.GetAttribute("value");
            Assert.IsTrue(actualText.ToLower().Contains("lucky"), $"expected actual text '{actualText}' to contain 'lucky'");
        }
        
        
   }
}