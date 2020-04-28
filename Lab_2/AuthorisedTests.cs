using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Lab_2
{
    [TestFixture]
    public class AuthorisedTests
    {
        private IWebDriver _driver;
        private string _url = "https://dou.ua/";

        public static IWebElement WaitandFindElement(IWebDriver driver, By selector)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(selector));
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

            var mainPage = new MainPage(_driver);
            var logInPage = new LogInPage(_driver);

            mainPage.GoToLogInPage();
            logInPage.SelectGoogleAuth();

            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            logInPage.TypeAndSubmitEmail("test.qa.epam@gmail.com");

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
            mainPage.GoToProfilePage();
            string actual_name = WaitandFindElement(_driver, By.TagName("h1")).Text;
            using (new AssertionScope())
                actual_name.Should().Be("Test Testing");
        }

        [TestCase("Dnipro", "KPI")]
        [TestCase("Kyiv", "EPAM")]
        [TestCase("Poltava", "Ubisoft")]
        public void TestEditProfileInformation(string expected_city, string expected_company)
        {
            var mainPage = new MainPage(_driver);
            mainPage.GoToProfilePage();

            WaitandFindElement(_driver, By.CssSelector(".b-content-menu li:nth-of-type(2) a")).Click();
            WaitandFindElement(_driver, By.Id("txtcity")).Clear();
            Thread.Sleep(100);
            WaitandFindElement(_driver, By.Id("txtcity")).SendKeys(expected_city);
            WaitandFindElement(_driver, By.Id("txtworkplace")).Clear();
            Thread.Sleep(100);
            WaitandFindElement(_driver, By.Id("txtworkplace")).SendKeys(expected_company);
            WaitandFindElement(_driver, By.Id("btnSubmit")).Click();

            string[] city_information = WaitandFindElement(_driver, By.ClassName("city")).Text.Trim().Split(',');
            city_information = city_information[0].Split('\n');
            string actual_city = city_information[1];

            string actual_company = WaitandFindElement(_driver, By.CssSelector(".descr span")).Text;

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
            mainPage.GoToProfilePage();

            WaitandFindElement(_driver, By.CssSelector(".b-content-menu li:nth-of-type(2) a")).Click();
            WaitandFindElement(_driver, By.CssSelector(".b-content-menu li:nth-of-type(2) a")).Click();

            IWebElement newsletter = WaitandFindElement(_driver, By.Id("id_newsletter"));
            if (newsletter.Selected)
                newsletter.Click();

            IWebElement receive_digests = WaitandFindElement(_driver, By.Id("id_receive_comment_digest"));
            if (receive_digests.Selected)
                receive_digests.Click();

            IWebElement allow_pm = WaitandFindElement(_driver, By.Id("id_allow_pm"));
            if (!allow_pm.Selected)
                allow_pm.Click();

            WaitandFindElement(_driver, By.Id("btnSubmit"));

            newsletter = WaitandFindElement(_driver, By.Id("id_newsletter"));
            receive_digests = WaitandFindElement(_driver, By.Id("id_receive_comment_digest"));
            allow_pm = WaitandFindElement(_driver, By.Id("id_allow_pm"));

            using (new AssertionScope())
            {
                newsletter.Selected.Should().BeFalse();
                receive_digests.Selected.Should().BeFalse();
                allow_pm.Selected.Should().BeTrue();
            }
        }

    }
}
