using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab_2
{
    [TestFixture]
    public class NotAuthorisedTests
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
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.UrlToBe(_url));

            var mainPage = new MainPage(_driver);
            mainPage.SwitchLanguageToEnglish();
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
            var mainPage = new MainPage(_driver);
            var articlesPage = new ArticlesPage(_driver);

            mainPage.GoToArticlesPage();
            string actual_header = articlesPage.GoToTags().
                SelectTag(expected_tag).
                GetPageHeader();

            using (new AssertionScope())
            {
                actual_header.Should().Contain(expected_tag);
                _driver.Url.Should().Be($"https://dou.ua/lenta/tags/{expected_tag}/");
            }
        }

        [Test]
        public void TestViewBestAtricles()
        {
            var mainPage = new MainPage(_driver);
            var articlesPage = new ArticlesPage(_driver);

            mainPage.SwitchLanguageToEnglish().GoToArticlesPage();
            string actual_header = articlesPage.SelectBestArticles().GetPageHeader();

            using (new AssertionScope())
            {
                actual_header.ToLower().Should().Contain("best articles");
                _driver.Url.Should().Be("https://dou.ua/lenta/best/");
            }
        }

        [Test]
        public void TestViewRecentDigests()
        {
            var mainPage = new MainPage(_driver);
            var articlesPage = new ArticlesPage(_driver);

            mainPage.GoToArticlesPage();
            string actual_header = articlesPage.SelectDigestsOption().GetFirstArticleHeader();

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
            var mainPage = new MainPage(_driver);
            var jobsPage = new JobsPage(_driver);

            mainPage.GoToJobsPage();
            string actual_company = jobsPage.SelectCompaniesPage().
                TypeFindCompanyName(expected_company).
                PerformSearch().
                ViewFirstCompany().
                GetCompanyHeader();

            using (new AssertionScope())
                actual_company.ToLower().Should().Contain(expected_company);
        }

        [TestCase("QA", "Genesis")]
        [TestCase("Python", "Luxoft")]
        [TestCase(".NET", "EPAM")]
        public void TestSearchforVacancy(string expected_category, string expected_company)
        {
            var mainPage = new MainPage(_driver);
            var jobsPage = new JobsPage(_driver);

            mainPage.GoToJobsPage();
            jobsPage.SelectJobCategory(expected_category).
                TypeFindCompanyName(expected_company).
                PerformSearch();

            string actual_header = jobsPage.GetJobName();
            string actual_company = jobsPage.GetCompanyName();

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
            var mainPage = new MainPage(_driver);
            var salariesPage = new SalariesPage(_driver);

            mainPage.GoToSalariesPage();
            salariesPage.SelectPeriod().
                SelectCity().
                SelectJob(job).
                SelectPositionIfExist(position).
                MoveSlider();

            string actual_i_quartile = salariesPage.GetMinField();
            string actual_median = salariesPage.GetMedianField();
            string actual_iii_quartile = salariesPage.GetMaxField();

            using (new AssertionScope())
            {
                actual_i_quartile.Should().Be(expected_i_quartile);
                actual_median.Should().Be(expected_median);
                actual_iii_quartile.Should().Be(expected_iii_quartile);
            }
        }
    }
}
