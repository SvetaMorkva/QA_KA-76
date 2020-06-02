using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace UITestingHomework_pageobject
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
            var LibraryMainPage = new LibraryPage(driver);
            LibraryMainPage.ClickLinkToClick();
            LibraryMainPage.FillTheFields("Ilya", "Tsuprun", "tsuprun_i@ukr.net", "student");
            LibraryMainPage.clickCheckbox();
            LibraryMainPage.ClickSubmitButton();
            Assert.IsTrue(LibraryMainPage.actualErrorAttribute);
        }
    }
}