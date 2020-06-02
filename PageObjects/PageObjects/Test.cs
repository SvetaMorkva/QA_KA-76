using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace PageObjects
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;
        private string url = "https://www.epam.com/";
        private HomePage home;
        private RusPage homeRus;
        private InsightsPage insights;
        private CareersPage careers;

        public static void waitUntilExists(IWebDriver driver, string selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector(selector)));
        }

        public static IWebElement smartFind(IWebDriver driver, string selector)
        {
            waitUntilExists(driver, selector);
            return driver.FindElement(By.CssSelector(selector));
        }

        public static IWebElement smartFindCollection(IWebDriver driver, string selector, int position)
        {
            waitUntilExists(driver, selector);
            return driver.FindElements(By.CssSelector(selector)).ElementAt(position);
        }

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == url);

            home = new HomePage(driver);
            homeRus = new RusPage(driver);
            insights = new InsightsPage(driver);
            careers = new CareersPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }


        [Test]
        public void GoToMainPage()
        {
            home.openWorkPage();
            home.openHomePage();
            string res = home.getDriverUrl();

            Assert.AreEqual(res, url);
        }

        [Test]
        public void ContactUs()
        {
            home.openContactUsPage();
            string number = home.findPhoneNumber();

            Assert.AreEqual(number, "+1-267-759-8989");
        }

        [Test]
        public void ChangeLanguage()
        {
            home.agreeWithCookies();
            home.changeLanguage();
            string res = homeRus.getRussianWord();

            Assert.AreEqual(res, "Услуги");
        }

        [Test]
        public void ToDifferentOffices()
        {
            home.agreeWithCookies();
            string res = home.findAustria();

            Assert.AreEqual(res, "Austria");
        }

        [Test]
        public void FilterContentType()
        {
            home.agreeWithCookies();
            home.toInsights();
            string res = insights.filtrator();

            Assert.AreEqual(res, "Financial Services");
        }

        [Test]
        public void SocialNetworks()
        {
            home.agreeWithCookies();
            string res = home.toInst();
            Assert.AreEqual(res, "https://www.instagram.com/epamsystems/");
        }

        [Test]
        public void SearchInfo()
        {
            home.agreeWithCookies();
            string res = home.searchInfo();

            Assert.AreEqual(res, "blockchain");
        }

        [Test]
        public void ApplyJobVacancy()
        {
            home.agreeWithCookies();
            home.applyCandydacy();
            string res = careers.getJobTitle();

            Assert.AreEqual(res, "E-learning Specialist");
        }
    }
}
