using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

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
            using (new AssertionScope())
            {
                actual_header.Should().Contain(expected_tag);
                _driver.Url.Should().Be($"https://dou.ua/lenta/tags/{expected_tag}/");
            }
        }

        [Test]
        public void TestViewBestAtricles()
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.CssSelector(".top_wide li:nth-of-type(2) a")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".page-head h1")).Text;
            using (new AssertionScope())
            {
                actual_header.ToLower().Should().Contain("best articles");
                _driver.Url.Should().Be("https://dou.ua/lenta/best/");
            }
        }

        [Test]
        public void TestViewRecentDigests()
        {
            _driver.FindElement(By.CssSelector(_articles_selector)).Click();
            _driver.FindElement(By.XPath("//select/option[text()='Digests']")).Click();
            string actual_header = _driver.FindElement(By.CssSelector(".title a")).Text;
            using (new AssertionScope())
            {
                actual_header.ToLower().Should().Contain("дайджест");
                _driver.Url.Should().Be("https://dou.ua/lenta/digests/");
            }
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
            using (new AssertionScope())
                actual_company.ToLower().Should().Contain(expected_company);
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
            using (new AssertionScope())
            {
                actual_header.ToLower().Should().Contain(expected_category.ToLower());
                actual_company.ToLower().Should().Contain(expected_company.ToLower());
            }
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
            Thread.Sleep(300);
            for (int i = 0; i < 8; i++)
            {
                action.SendKeys(Keys.ArrowLeft).Build();
            }
            action.Perform();
            slider.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            

            string actual_i_quartile = _driver.FindElement(By.CssSelector(".salarydec-results-min .num")).Text;
            string actual_median = _driver.FindElement(By.CssSelector(".salarydec-results-median .num")).Text;
            string actual_iii_quartile = _driver.FindElement(By.CssSelector(".salarydec-results-max .num")).Text;

            using (new AssertionScope())
            {
                actual_i_quartile.Should().Be(expected_i_quartile);
                actual_median.Should().Be(expected_median);
                actual_iii_quartile.Should().Be(expected_iii_quartile);
            }
        }
    }
}
