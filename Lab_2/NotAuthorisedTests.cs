using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.Generic;

namespace Lab_2
{
    [TestFixture]
    public class NotAuthorisedTests
    {
        private IWebDriver _driver;
        private string _url = "https://dou.ua/";
        private string _articles_selector = "header li:nth-of-type(4) a";
        private string _jobs_selector = "header li:nth-of-type(6) a";
        private string _salaries_selector = "header li:nth-of-type(5) a";

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_url);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(d => d.Url == _url);
            _driver.FindElement(By.CssSelector(".footer-lang-switch a:nth-of-type(2)")).Click();
        }

        [TearDown]
        public void TestFinalize()
        {
            _driver.Quit();
        }


        [TestCase("QA")]
        [TestCase("Python")]
        [TestCase(".NET")]
        public void TestViewArticlesbyTag(string expected_tag)
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.CssSelector(".top_wide li:nth-of-type(3) a")).Click();
            _driver.FindElement(By.XPath($"//a[contains(text(), '{expected_tag}') and @class='b-tag tag-7']")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".page-head h1")).Text;
            Assert.IsTrue(actual_header.Contains(expected_tag), $"{actual_header} is expected to contain '{expected_tag}'");
            Assert.AreEqual($"https://dou.ua/lenta/tags/{expected_tag}/", _driver.Url);
        }

        [Test]
        public void TestViewBestAtricles()
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.CssSelector(".top_wide li:nth-of-type(2) a")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".page-head h1")).Text;
            Assert.IsTrue(actual_header.ToLower().Contains("best articles"), $"{actual_header} is expected to contain 'best articles'");
            Assert.AreEqual("https://dou.ua/lenta/best/", _driver.Url);
        }

        [Test]
        public void TestViewRecentDigests()
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.XPath("//select/option[text()='Digests']")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".title a")).Text;
            Assert.IsTrue(actual_header.ToLower().Contains("дайджест"), $"{actual_header} is expected to contain 'дайджест'");
            Assert.AreEqual("https://dou.ua/lenta/digests/", _driver.Url);
        }

        [TestCase("epam")]
        [TestCase("pharos production")]
        [TestCase("genesis")]
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

        [TestCase("QA", "Genesis")]
        [TestCase("Python", "Luxoft")]
        [TestCase(".NET", "EPAM")]
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

        [TestCase("Junior QA engineer", "Manual QA", "500", "600", "778")]
        [TestCase("Junior QA engineer", "Automation QA", "500", "790", "1000")]
        [TestCase("Junior QA engineer", "General QA", "525", "650", "1000")]
        [TestCase("Junior Software Engineer", "C#/.NET", "600", "855", "1200")]
        [TestCase("Junior Software Engineer", "Python", "600", "770", "1000")]
        [TestCase("Junior Software Engineer", "Swift", "600", "800", "1100")]
        [TestCase("Data Scientist", null, "700", "1300", "1750")]
        public void TestViewSalaryDependsonPositionandTechnology(
            string job, 
            string position, 
            string expected_i_quartile,
            string expected_median,
            string expected_iii_quartile)
        {
            _driver.FindElement(By.CssSelector(_salaries_selector)).Click();
            _driver.FindElement(By.XPath("//select/option[text()='December 2019']")).Click();
            _driver.FindElement(By.XPath("//select/option[text()='Kyiv']")).Click();
            _driver.FindElement(By.XPath($"//select//option[text()='{job}']")).Click();

            var elementList = new List<IWebElement>();
            elementList.AddRange(_driver.FindElements(By.XPath($"//select//option[text()='{position}']")));
            if (elementList.Count > 0)
                elementList[0].Click();

            IWebElement slider = _driver.FindElement(By.CssSelector(".salarydec-slider a:nth-of-type(2)"));
            Actions action = new Actions(_driver);
            action.Click(slider).Build().Perform();
            Thread.Sleep(100);
            for (int i = 0; i < 8; i++)
            {
                action.SendKeys(Keys.ArrowLeft).Build();
            }
            action.Perform();
            slider.SendKeys(Keys.Enter);
            Thread.Sleep(500);

            

            string actual_i_quartile = _driver.FindElement(By.CssSelector(".salarydec-results-min .num")).Text;
            string actual_median = _driver.FindElement(By.CssSelector(".salarydec-results-median .num")).Text;
            string actual_iii_quartile = _driver.FindElement(By.CssSelector(".salarydec-results-max .num")).Text;

            Assert.AreEqual(expected_i_quartile, actual_i_quartile);
            Assert.AreEqual(expected_median, actual_median);
            Assert.AreEqual(expected_iii_quartile, actual_iii_quartile);
        }
    }
}
