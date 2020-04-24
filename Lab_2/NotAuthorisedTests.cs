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
        private string _jobs_selector = "header li:nth-of-type(6) a";

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_url);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(d => d.Url == _url);
            _driver.FindElement(By.CssSelector(".footer-lang-switch a:nth-of-type(2)")).Click();
        }

        [TestCleanup]
        public void TestFinalize()
        {
            _driver.Close();
        }

        [DataTestMethod]
        [DataRow("QA")]
        [DataRow("Python")]
        [DataRow(".NET")]
        public void TestViewArticlesbyTag(string expected_tag)
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.CssSelector(".top_wide li:nth-of-type(3) a")).Click();
            _driver.FindElement(By.XPath($"//a[contains(text(), '{expected_tag}') and @class='b-tag tag-7']")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".page-head h1")).Text;
            Assert.IsTrue(actual_header.Contains(expected_tag), $"{actual_header} is expected to contain '{expected_tag}'");
            Assert.AreEqual($"https://dou.ua/lenta/tags/{expected_tag}/", _driver.Url);
        }

        [TestMethod]
        public void TestViewBestAtricles()
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.CssSelector(".top_wide li:nth-of-type(2) a")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".page-head h1")).Text;
            Assert.IsTrue(actual_header.ToLower().Contains("best articles"), $"{actual_header} is expected to contain 'best articles'");
            Assert.AreEqual("https://dou.ua/lenta/best/", _driver.Url);
        }

        [TestMethod]
        public void TestViewRecentDigests()
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.XPath("//select/option[text()='Digests']")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".title a")).Text;
            Assert.IsTrue(actual_header.ToLower().Contains("дайджест"), $"{actual_header} is expected to contain 'дайджест'");
            Assert.AreEqual("https://dou.ua/lenta/digests/", _driver.Url);
        }

        [DataTestMethod]
        [DataRow("epam")]
        [DataRow("pharos production")]
        [DataRow("genesis")]
        public void TestSearchforCompany(string expected_company)
        {
            _driver.FindElement(By.CssSelector(_jobs_selector)).Click();
            _driver.FindElement(By.CssSelector(".sub li:nth-of-type(3) a")).Click();
            _driver.FindElement(By.CssSelector("input[class='company']")).SendKeys(expected_company);
            _driver.FindElement(By.CssSelector(".btn-search")).Click();
            _driver.FindElement(By.CssSelector(".h2 a")).Click();
            string actual_company = _driver.FindElement(By.CssSelector("h1[class='g-h2']")).Text;
            Assert.IsTrue(actual_company.ToLower().Contains(expected_company), $"{actual_company} is expected to contain '{expected_company}'");
        }

        [DataTestMethod]
        [DataRow("QA", "Genesis")]
        [DataRow("Python", "Luxoft")]
        [DataRow(".NET", "EPAM")]
        public void TestSearchforVacancy(string expected_category, string expected_company)
        {
            _driver.FindElement(By.CssSelector(_jobs_selector)).Click();
            _driver.FindElement(By.XPath($"//select/option[text()='{expected_category}']")).Click();
            _driver.FindElement(By.CssSelector(".job")).SendKeys(expected_company);
            _driver.FindElement(By.CssSelector(".btn-search")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".vt")).Text;
            string actual_company = _driver.FindElement(By.CssSelector(".company")).Text;
            Assert.IsTrue(actual_header.ToLower().Contains(expected_category.ToLower()), $"{actual_header} is expected to contain '{expected_category}'");
            Assert.IsTrue(actual_company.ToLower().Contains(expected_company.ToLower()), $"{actual_company} is expected to contain '{expected_company}'");
        }
    }
}
