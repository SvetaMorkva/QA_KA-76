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
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(d => d.Url == _url);
            
            _driver.FindElement(By.CssSelector(".right-part a")).Click();
            _driver.FindElement(By.Id("btnGoogle")).Click();
            Thread.Sleep(1000);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.FindElement(By.CssSelector("input[type=email]")).SendKeys("test.qa.epam@gmail.com");
            _driver.FindElement(By.CssSelector("div[role=button]")).Click();
            Thread.Sleep(3000);
            _driver.FindElement(By.CssSelector("input[type='password']")).SendKeys("ytrewq654321");
            _driver.FindElement(By.Id("passwordNext")).Click();
            Thread.Sleep(3000);
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            Thread.Sleep(3000);
            IWebElement lang_switcher = _driver.FindElement(By.CssSelector(".footer-lang-switch a:nth-of-type(2)"));
            if (lang_switcher.Text == "English")
                lang_switcher.Click();
        }

        [TearDown]
        public void TestFinalize()
        {
            _driver.Quit();
        }


        [Test]
        public void TestAuthwithGoogle()
        {
            _driver.FindElement(By.ClassName("min-profile")).Click();
            string actual_name = _driver.FindElement(By.TagName("h1")).Text;
            using (new AssertionScope())
                actual_name.Should().Be("Test Testing");
        }

        [TestCase("Dnipro", "KPI")]
        [TestCase("Kyiv", "EPAM")]
        [TestCase("Poltava", "Ubisoft")]
        public void TestEditProfileInformation(string expected_city, string expected_company)
        {
            _driver.FindElement(By.ClassName("min-profile")).Click();
            _driver.FindElement(By.CssSelector(".b-content-menu li:nth-of-type(2) a")).Click();
            _driver.FindElement(By.Id("txtcity")).Clear();
            Thread.Sleep(100);
            _driver.FindElement(By.Id("txtcity")).SendKeys(expected_city);
            _driver.FindElement(By.Id("txtworkplace")).Clear();
            Thread.Sleep(100);
            _driver.FindElement(By.Id("txtworkplace")).SendKeys(expected_company);
            _driver.FindElement(By.Id("btnSubmit")).Click();

            Thread.Sleep(1000);
            string[] city_information = _driver.FindElement(By.ClassName("city")).Text.Trim().Split(',');
            city_information = city_information[0].Split('\n');
            string actual_city = city_information[1];

            string actual_company = _driver.FindElement(By.CssSelector(".descr span")).Text;

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
            _driver.FindElement(By.ClassName("min-profile")).Click();
            _driver.FindElement(By.CssSelector(".b-content-menu li:nth-of-type(2) a")).Click();
            _driver.FindElement(By.CssSelector(".b-content-menu li:nth-of-type(2) a")).Click();

            IWebElement newsletter = _driver.FindElement(By.Id("id_newsletter"));
            if (newsletter.Selected)
                newsletter.Click();

            IWebElement receive_digests = _driver.FindElement(By.Id("id_receive_comment_digest"));
            if (receive_digests.Selected)
                receive_digests.Click();

            IWebElement allow_pm = _driver.FindElement(By.Id("id_allow_pm"));
            if (!allow_pm.Selected)
                allow_pm.Click();

            _driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);

            newsletter = _driver.FindElement(By.Id("id_newsletter"));
            receive_digests = _driver.FindElement(By.Id("id_receive_comment_digest"));
            allow_pm = _driver.FindElement(By.Id("id_allow_pm"));

            using (new AssertionScope())
            {
                newsletter.Selected.Should().BeFalse();
                receive_digests.Selected.Should().BeFalse();
                allow_pm.Selected.Should().BeTrue();
            }
        }
    }
}
