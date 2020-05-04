using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Lab2_1
{
    [Obsolete]
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private string _url = "https://nszu.gov.ua/";

        private IWebElement WaitForFindElement(IWebDriver driver, By selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(selector));
            return driver.FindElement(selector);
        }

        [Obsolete]
        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url == _url);

        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }
        
        [Obsolete]
        [TestCase("Контакти", "kontakti")]
        [TestCase("Закупівлі", "zakupivli")]
        public void TestChangeItemOfNav(string infoUkr, string infoLatin)
        {
            var coursesPage = new WebPage(driver);
            string infoUkr1 = infoUkr.ToLower();

            coursesPage.SelectItemOfNavigatoin(infoUkr);
            string actual_label = coursesPage.GetTitleLabel();

            using (new AssertionScope())
            {
                actual_label.Should().Contain(infoUkr1);
                driver.Url.Should().Be($"https://nszu.gov.ua/pro-nszu/{infoLatin}");
            }
        }

        [Obsolete]
        [Test]
        public void TestSwitchLangToEng()
        {
            var coursesPage = new WebPage(driver);

            string ukr_label = coursesPage.GetLabel();
            coursesPage.SwitchLang();
            string eng_label = coursesPage.GetLabel();

            using (new AssertionScope())
            {
                ukr_label.Should().Contain("далі");
                eng_label.Should().Contain("Read");
                driver.Url.Should().Be("https://nszu.gov.ua/en");
            }
        }


        [Obsolete]
        [Test]
        public void TestOpenFacebookSource()
        {
            var coursesPage = new WebPage(driver);

            coursesPage.OpenFacebookSource();

            using (new AssertionScope())
            {
                driver.Url.Should().Be("https://www.facebook.com/nszu.ukr/");
            }
        }

        [Obsolete]
        [Test]
        public void TestGoToAcademy()
        {
            var coursesPage = new WebPage(driver);

            coursesPage.GoToAcademy();
            string actualPoint = coursesPage.GetAcademyTtileText().ToLower();

            using (new AssertionScope())
            {
                actualPoint.Should().Contain("вхід");
                driver.Url.Should().Be("https://academy.nszu.gov.ua/");
            }
        }

        [Obsolete]
        [Test]
        public void TestGetSearchBoxResult()
        {
            var coursesPage = new WebPage(driver);
            string TextValue = "коронавірус";
            coursesPage.GetSearchBoxResult(TextValue);
            string actualArticle = coursesPage.GetSearchTitle().ToLower();

            using (new AssertionScope())
            {
                actualArticle.Should().Contain("результати");
            }
        }


        [Obsolete]
        [Test]
        public void TestGetReports()
        {
            var coursesPage = new WebPage(driver);

            coursesPage.GetReports();
            string actualPoint = coursesPage.GetTitleLabel();

            using (new AssertionScope())
            {
                actualPoint.Should().Be("звіти");
            }
        }

       
        [Obsolete]
        [Test]
        public void TestGetTelephoneForFeetback()
        {
            var coursesPage = new WebPage(driver);
            string actual_number = coursesPage.GetFeetbackNumber();

            using (new AssertionScope())
                actual_number.Should().Be("16-77");
        }

        [Obsolete]
        [Test]
        public void TestGetEmailForFeetback()
        {
            var coursesPage = new WebPage(driver);
            string actual_number = coursesPage.GetFeetbackEmail();

            using (new AssertionScope())
                actual_number.Should().Be("info@nszu.gov.ua");
        }
    }
}