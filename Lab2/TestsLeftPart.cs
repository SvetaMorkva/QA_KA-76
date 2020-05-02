using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Lab2
{
    [TestFixture]
    public class Tests
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
            options.AddArgument("proxy-server='direct://'");
            options.AddArgument("proxy-bypass-list=*");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url == _url);

            var mainPage = new MainPage(driver);
            mainPage.GoToLeftPart();
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }

        [TestCase("Харьков", "kharkov")]
        [TestCase("Днепр", "dnepropetrovsk")]
        public void TestChangeCity(string CityRus, string CityLatin)
        {
            var coursesPage = new CoursesPage(driver);

            coursesPage.SelectCity(CityRus);
            string actual_prelabel = coursesPage.GetCoursesPrelabel();

            using (new AssertionScope())
            {
                actual_prelabel.Should().Contain(CityRus);
                driver.Url.Should().Be($"https://greenforest.com.ua/courses/{CityLatin}");
            }
        }

        [Test]
        public void TestSwitchLangToUkr()
        {
            var coursesPage = new CoursesPage(driver);

            string rus_prelabel = coursesPage.GetCoursesPrelabel();
            coursesPage.SwitchLang();
            string ukr_prelabel = coursesPage.GetCoursesPrelabel();

            using (new AssertionScope())
            {
                rus_prelabel.Should().Contain("Киев");
                ukr_prelabel.Should().Contain("Київ");
                driver.Url.Should().Be("https://greenforest.com.ua/ua/courses/kiev");
            }
        }

        [Test]
        public void TestOpenMyGF()
        {
            var coursesPage = new CoursesPage(driver);

            coursesPage.GoToMyGF();
            string actual_header = coursesPage.GetMyGFTtileText().ToLower();

            using (new AssertionScope())
            {
                actual_header.Should().Contain("вхід");
                driver.Url.Should().Be("https://my.greenforest.com.ua/");
            }
        }

        [TestCase("Киев", "дистанционный курс", 6)]
        [TestCase("Харьков", "курс подготовки к ielts", 8)]
        [TestCase("Днепр", "grammar express", 7)]
        public void TestViewCourses(string CityName, string OriginalCourse, int CoursesQuantity)
        {
            var coursesPage = new CoursesPage(driver);

            if (CityName != "Киев")
                coursesPage.SelectCity(CityName);

            coursesPage.ViewAllCourses();
            List<string> CoursesNames = coursesPage.GetAllCoursesNames();

            using (new AssertionScope())
            {
                CoursesNames.Should().Contain(OriginalCourse);
                CoursesNames.Should().HaveCount(CoursesQuantity);
            }
        }

        [Test]
        public void TestGetCallCenterNumber()
        {
            var coursesPage = new CoursesPage(driver);
            string actual_number = coursesPage.GetCallCenterNumber();

            using (new AssertionScope())
                actual_number.Should().Be("0 800 750 167");
        }
    }
}
