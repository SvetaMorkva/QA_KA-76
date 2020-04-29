using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace WebDriverHomework
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private PageObject mainPage;

        private string url = "https://www.instagram.com/";

        private string username = "brandd1re";
        private string password = "ImaBitchImaBoss";

        private string path = System.AppDomain.CurrentDomain.BaseDirectory + "Selenium";



        public static void waitUntilExists(IWebDriver driver, By selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(selector));
        }

        public static IWebElement smartFind(IWebDriver driver, By selector)
        {
            waitUntilExists(driver, selector);
            return driver.FindElement(selector);
        }




        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArguments(@"user-data-dir=" + path);

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == url);


            smartFind(driver, By.CssSelector(".FBi-h+ .-MzZI .zyHYP")).SendKeys(username);
            smartFind(driver, By.CssSelector(".-MzZI+ .-MzZI .zyHYP")).SendKeys(password);
            smartFind(driver, By.CssSelector(".-MzZI+ .DhRcB")).Click();

            Thread.Sleep(3000);

            //There's a dumb notification dialog (-_-)
            if (smartFind(driver, By.CssSelector(".piCib")).Displayed)
            {
                smartFind(driver, By.CssSelector(".HoLwm")).Click();
            }

            waitUntilExists(driver, By.CssSelector(".Fifk5 ._6q-tv"));
            
            mainPage = new PageObject(driver);

            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }


        [Test]
        public void findNataliePortmanWithSearch()
        {
            mainPage.startSearchInput().SendKeys("natalieportman");
            smartFind(driver, By.CssSelector(".yCE8d:nth-child(1)")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver =>
                    driver.Url == "https://www.instagram.com/natalieportman/");

            IWebElement verificationBadge = smartFind(driver, By.CssSelector(".coreSpriteVerifiedBadge"));

            Assert.IsTrue(verificationBadge.Displayed);
        }
    }
}
