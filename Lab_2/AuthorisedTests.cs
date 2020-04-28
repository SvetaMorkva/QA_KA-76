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
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.UrlToBe(_url));

            var mainPage = new MainPage(_driver);
            var logInPage = new LogInPage(_driver);

            mainPage.GoToLogInPage();
            logInPage.SelectGoogleAuth();

            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            logInPage.TypeAndSubmitEmail("test.qa.epam@gmail.com");

            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.CssSelector("input[type='password']"))));
            _driver.FindElement(By.CssSelector("input[type='password']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.CssSelector("input[type='password']")).SendKeys("ytrewq654321");
            _driver.FindElement(By.Id("passwordNext")).Click();
            Thread.Sleep(3000);
            _driver.SwitchTo().Window(_driver.WindowHandles.First());

            mainPage.SwitchLanguageToEnglish();
        }

        [TearDown]
        public void TestFinalize()
        {
            _driver.Quit();
        }

        [Test]
        public void TestAuthwithGoogle()
        {
            var mainPage = new MainPage(_driver);
            var profilePage = new ProfilePage(_driver);

            mainPage.GoToProfilePage();
            string actual_name = profilePage.GetUserName();

            using (new AssertionScope())
                actual_name.Should().Be("Test Testing");
        }

        [TestCase("Dnipro", "KPI")]
        [TestCase("Kyiv", "EPAM")]
        [TestCase("Poltava", "Ubisoft")]
        public void TestEditProfileInformation(string expected_city, string expected_company)
        {
            var mainPage = new MainPage(_driver);
            var profilePage = new ProfilePage(_driver);

            mainPage.GoToProfilePage();
            profilePage.GoToProfileSettings().
                FillCityTextBox(expected_city).
                FillWorkplaceTextBox(expected_company).
                SubmitChanges();

            string actual_city = profilePage.GetCityName();
            string actual_company = profilePage.GetWorkplaceName();

            using (new AssertionScope())
            {
                _driver.Url.Should().Be("https://dou.ua/users/test-testing/");
                actual_city.Should().Be(expected_city);
                actual_company.Should().Be(expected_company);
            }
        }

        [Test]
        public void TestManageSubscriptions()
        {
            var mainPage = new MainPage(_driver);
            var profilePage = new ProfilePage(_driver);

            mainPage.GoToProfilePage();
            profilePage.GoToProfileSettings().
                GoToSubscriptions().
                CheckNewsletterIfNecessary().
                CheckDigestIfNecessary().
                CheckAllowPMIfNecessary().
                SubmitChanges();

            using (new AssertionScope())
            {
                profilePage.NewsletterChecked().Should().BeFalse();
                profilePage.DigestChecked().Should().BeFalse();
                profilePage.AllowPMChecked().Should().BeTrue();
            }
        }
    }
}
