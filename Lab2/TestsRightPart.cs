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

            WaitForFindElement(driver, By.CssSelector(".right a")).Click();
            Thread.Sleep(1000);
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
            WaitForFindElement(driver, By.ClassName("fa-caret-down")).Click();
            Thread.Sleep(2000);
            WaitForFindElement(driver, By.XPath($"//ul[@class='categories']//a[text()='{Topic}']")).Click();
            Thread.Sleep(5000);

            List<IWebElement> CategoryElements = new List<IWebElement>();
            CategoryElements.AddRange(driver.FindElements(By.CssSelector(".article-block-category a")));
            List<string> CategoryElementsName = new List<string>();
            foreach (IWebElement element in CategoryElements)
                CategoryElementsName.Add(element.Text.Trim().ToLower());

            using (new AssertionScope())
            {
                CategoryElementsName.Should().Contain(Topic.ToLower());
                driver.Url.Should().Be($"https://greenforest.com.ua/journal/{Topic.ToLower()}");
            }
        }

        [Test]
        public void TestRedirectToAppStore()
        {
            WaitForFindElement(driver, By.CssSelector(".mobile_app:nth-of-type(2) a")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string actual_name = WaitForFindElement(driver, By.TagName("h1")).Text;

            using (new AssertionScope())
                actual_name.Should().Contain("Green Forest");
        }

        [TestCase("Everyday English")]
        [TestCase("Homophones")]
        public void TestViewProjectsonTopic(string Topic)
        {
            WaitForFindElement(driver, By.ClassName("projects")).Click();
            WaitForFindElement(driver, By.XPath($"//div[@class='journal-page projects']//a[contains(text(), '{Topic}')]")).Click();

            Thread.Sleep(3000);

            WaitForFindElement(driver, By.CssSelector(".article-block-title a")).Click();
            List<IWebElement> CategoryElements = new List<IWebElement>();
            CategoryElements.AddRange(driver.FindElements(By.CssSelector(".article-page .article-block-category a")));
            List<string> CategoryElementsName = new List<string>();
            foreach (IWebElement element in CategoryElements)
                CategoryElementsName.Add(element.Text.Trim().ToLower());

            using (new AssertionScope())
                CategoryElementsName.Should().Contain(Topic.ToLower());
        }
    }
}
