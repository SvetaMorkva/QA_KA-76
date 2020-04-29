﻿using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
        [TestCase("Speaking")]
        [TestCase("Reviews")]
        public void TestViewNewsOnTopic(string Topic)
        {
            WaitForFindElement(driver, By.ClassName("fa-caret-down")).Click();
            Thread.Sleep(3000);
            WaitForFindElement(driver, By.XPath($"//ul[@class='categories']//a[text()='{Topic}']")).Click();
            Thread.Sleep(3000);

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
    }
}
