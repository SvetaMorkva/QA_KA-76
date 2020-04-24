using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace Lab_2
{
    [TestFixture]
    public class AuthorisedTests
    {
        private IWebDriver _driver;
        private string _url = "https://dou.ua/";

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_url);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(d => d.Url == _url);
            _driver.FindElement(By.CssSelector(".footer-lang-switch a:nth-of-type(2)")).Click();
            _driver.FindElement(By.CssSelector(".right-part a")).Click();
            _driver.FindElement(By.Id("btnGoogle")).Click();
            Thread.Sleep(1000);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.FindElement(By.CssSelector("input[type=email]")).SendKeys("test.qa.epam@gmail.com");
            _driver.FindElement(By.CssSelector("div[role=button]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.CssSelector("input[type='password']")).SendKeys("ytrewq654321");
            _driver.FindElement(By.Id("passwordNext")).Click();
            Thread.Sleep(3000);
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
        }

        [TearDown]
        public void TestFinalize()
        {
            _driver.Quit();
        }


        [Test]
        public void TestAuthwithGoogle()
        {
            _driver.FindElement(By.ClassName("min-profile")).Click();
            string actual_name = _driver.FindElement(By.TagName("h1")).Text;
            using (new AssertionScope())
                actual_name.Should().Be("Test Testing");
        }
    }
}
