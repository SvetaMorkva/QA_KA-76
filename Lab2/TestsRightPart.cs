using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab2
{
    [TestFixture]
    public class TestsRightPart
    {
        private IWebDriver driver;
        private string _url = "https://greenforest.com.ua/";

        private IWebElement WaitForFindElement(IWebDriver driver, By selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(selector));
            return driver.FindElement(selector);
        }

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url == _url);

            var mainPage = new MainPage(driver);
            mainPage.GoToRightPart();
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }

        [TestCase("Grammar")]
        [TestCase("Fun")]
        [TestCase("Listening")]
        public void TestViewNewsOnTopic(string Topic)
        {
            var journalPage = new JournalPage(driver);

            journalPage.SelectTopic(Topic);
            List<string> CategoryElementsName = journalPage.GetArticlesCategories();

            using (new AssertionScope())
            {
                CategoryElementsName.Should().Contain(Topic.ToLower());
                driver.Url.Should().Be($"https://greenforest.com.ua/journal/{Topic.ToLower()}");
            }
        }

        [Test]
        public void TestRedirectToAppStore()
        {
            var journalPage = new JournalPage(driver);

            journalPage.GoToAppStore();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string actual_name = journalPage.GetAppName();

            using (new AssertionScope())
                actual_name.Should().Contain("Green Forest");
        }

        [TestCase("Everyday English")]
        [TestCase("Homophones")]
        public void TestViewProjectsonTopic(string Topic)
        {
            var journalPage = new JournalPage(driver);

            journalPage.SelectCategory(Topic);
            List<string> CategoryElementsName = journalPage.GetFirstArticleCategories();

            using (new AssertionScope())
                CategoryElementsName.Should().Contain(Topic.ToLower());
        }
    }
}
