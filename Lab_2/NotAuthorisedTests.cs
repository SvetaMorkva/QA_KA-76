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

        private static IWebElement WaitandFindElement(IWebDriver driver, By selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(selector)));
            return driver.FindElement(selector);
        }

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_url);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(d => d.Url == _url);
            IWebElement lang_switcher = WaitandFindElement(_driver, By.CssSelector(".footer-lang-switch a:nth-of-type(2)"));
            if (lang_switcher.Text == "English")
                lang_switcher.Click();
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
            WaitandFindElement(_driver, By.CssSelector(_articles_selector)).Click();
            WaitandFindElement(_driver, By.CssSelector(".top_wide li:nth-of-type(3) a")).Click();
            WaitandFindElement(_driver, By.XPath($"//a[contains(text(), '{expected_tag}') and @class='b-tag tag-7']")).Click();
            string actual_header = WaitandFindElement(_driver, By.CssSelector(".page-head h1")).Text;
            using (new AssertionScope())
            {
                actual_header.Should().Contain(expected_tag);
                _driver.Url.Should().Be($"https://dou.ua/lenta/tags/{expected_tag}/");
            }
        }

        [Test]
        public void TestViewBestAtricles()
        {
            WaitandFindElement(_driver, By.CssSelector(_articles_selector)).Click();
            WaitandFindElement(_driver, By.CssSelector(".top_wide li:nth-of-type(2) a")).Click();

            string actual_header = WaitandFindElement(_driver, By.CssSelector(".page-head h1")).Text;
            using (new AssertionScope())
            {
                actual_header.ToLower().Should().Contain("best articles");
                _driver.Url.Should().Be("https://dou.ua/lenta/best/");
            }
        }

        [Test]
        public void TestViewRecentDigests()
        {
            WaitandFindElement(_driver, By.CssSelector(_articles_selector)).Click();

            WaitandFindElement(_driver, By.XPath("//select/option[text()='Digests']")).Click();

            string actual_header = WaitandFindElement(_driver, By.CssSelector(".title a")).Text;
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
            WaitandFindElement(_driver, By.CssSelector(_jobs_selector)).Click();
            WaitandFindElement(_driver, By.CssSelector(".sub li:nth-of-type(3) a")).Click();
            WaitandFindElement(_driver, By.CssSelector("input[class='company']")).SendKeys(expected_company);
            WaitandFindElement(_driver, By.ClassName("btn-search")).Click();
            WaitandFindElement(_driver, By.CssSelector(".h2 a")).Click();

            string actual_company = WaitandFindElement(_driver, By.CssSelector("h1[class='g-h2']")).Text;
            using (new AssertionScope())
                actual_company.ToLower().Should().Contain(expected_company);
        }

        [TestCase("QA", "Genesis")]
        [TestCase("Python", "Luxoft")]
        [TestCase(".NET", "EPAM")]
        public void TestSearchforVacancy(string expected_category, string expected_company)
        {
            WaitandFindElement(_driver, By.CssSelector(_jobs_selector)).Click();
            WaitandFindElement(_driver, By.XPath($"//select/option[text()='{expected_category}']")).Click();

            WaitandFindElement(_driver, By.ClassName("job")).SendKeys(expected_company);
            WaitandFindElement(_driver, By.ClassName("btn-search")).Click();

            string actual_header = WaitandFindElement(_driver, By.ClassName("vt")).Text;
            string actual_company = WaitandFindElement(_driver, By.ClassName("company")).Text;

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
            WaitandFindElement(_driver, By.CssSelector(_salaries_selector)).Click();

            WaitandFindElement(_driver, By.XPath("//select/option[text()='December 2019']")).Click();
            WaitandFindElement(_driver, By.XPath("//select/option[text()='Kyiv']")).Click();
            WaitandFindElement(_driver, By.XPath($"//select//option[text()='{job}']")).Click();

            var elementList = new List<IWebElement>();
            elementList.AddRange(_driver.FindElements(By.XPath($"//select//option[text()='{position}']")));
            if (elementList.Count > 0)
                elementList[0].Click();

            IWebElement slider = WaitandFindElement(_driver, By.CssSelector(".salarydec-slider a:nth-of-type(2)"));
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

            

            string actual_i_quartile = WaitandFindElement(_driver, By.CssSelector(".salarydec-results-min .num")).Text;
            string actual_median = WaitandFindElement(_driver, By.CssSelector(".salarydec-results-median .num")).Text;
            string actual_iii_quartile = WaitandFindElement(_driver, By.CssSelector(".salarydec-results-max .num")).Text;

            using (new AssertionScope())
            {
                actual_i_quartile.Should().Be(expected_i_quartile);
                actual_median.Should().Be(expected_median);
                actual_iii_quartile.Should().Be(expected_iii_quartile);
            }
        }
    }
}
