using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lab_2
{
    [TestClass]
    public class NotAuthorisedTests
    {
        private IWebDriver _driver;
        private string _url = "https://dou.ua/";
        private string _articles_selector = "header li:nth-of-type(4) a";

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_url);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(d => d.Url == _url);
        }

        [TestCleanup]
        public void TestFinalize()
        {
            _driver.Close();
        }

        [TestMethod]
        public void TestViewArticlesbyTagQA()
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.CssSelector(".top_wide li:nth-of-type(3) a")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(), 'QA') and @class='b-tag tag-7']")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".page-head h1")).Text;
            Assert.IsTrue(actual_header.Contains("QA"), $"{actual_header} is expected to contain 'QA'");
            Assert.AreEqual("https://dou.ua/lenta/tags/QA/", _driver.Url);
        }
    }
}
