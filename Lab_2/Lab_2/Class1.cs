using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lab_2
{
    [TestFixture]
    public class GagTests
    {
        private IWebDriver driver;
        private string _url = "https://9gag.com/";

        [SetUp]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url = _url);
        }
        [TearDown]
        public void TestFinalize()
        {
            driver.Close();
        }

        [Test]
        public void DarkTheme()
        {
            driver.FindElement(By.ClassName("darkmode-toggle")).Click();
            using ( new AssertionScope())
            {
                driver.FindElement(By.TagName("body")).GetAttribute("class").Should().Be("theme-dark");
            }

        }
        [TestCase("/funny")]
        [TestCase("/coronavirus")]
        [TestCase("/animals")]
        [TestCase("/awesome")]
        [TestCase("/gaming")]
        public void StarCategory(string category)
        {
            driver.FindElement(By.XPath($"//li[a[@href='{category}']]/a[@class='button']")).Click();
            using (new AssertionScope())
            {
                driver.FindElements(By.XPath("//section[@class = 'shortcut']")).Should().NotBeEmpty();
            }

        }

        [TestCase("up")]
        [TestCase("down")]
        public void UnauthorisedScore(string prefference)
        {
            driver.FindElement(By.XPath($"//article/div[ contains(@class, 'post-afterbar')]/ul/li/a[@class = '{prefference}']")).Click();
            using (new AssertionScope())
            {
                driver.FindElements(By.CssSelector("section[class = 'modal']")).Count().Should().NotBe(0);
                driver.FindElement(By.XPath("//section[@class = 'modal']/section/div/h2")).Text.Should().Contain("Hey there!");
            }
        }
        [Test]
        public void RandomPostNextPost()
        {
            driver.FindElement(By.XPath("//nav[@class='nav-menu']/ul/li[contains(a, 'Random')]")).Click();
            var tabs = driver.WindowHandles;
            driver.SwitchTo().Window(tabs[1]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            using (new AssertionScope())
            {
                driver.FindElements(By.ClassName("post-page")).Count().Should().NotBe(0);
            }
        }
    }
}
