using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace Lab2
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private string _url = "https://greenforest.com.ua/";

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url == _url);

            driver.FindElement(By.CssSelector(".left a")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".cities-popup li:nth-of-type(1)")).Click();
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }

        [TestCase("Харьков", "kharkov")]
        [TestCase("Днепр", "dnepropetrovsk")]
        [TestCase("Львов", "lvov")]
        [TestCase("Одесса", "odessa")]
        public void TestChangeCity(string CityRus, string CityLatin)
        {
            driver.FindElement(By.ClassName("fa-caret-down")).Click();
            driver.FindElement(By.XPath($"//div[@class='cities-switch']//ul//a[contains(text(), '{CityRus}')]")).Click();
            Thread.Sleep(1000);
            string actual_prelabel = driver.FindElement(By.ClassName("courses-list-prelabel")).Text;

            using (new AssertionScope())
            {
                actual_prelabel.Should().Contain(CityRus);
                driver.Url.Should().Be($"https://greenforest.com.ua/courses/{CityLatin}");
            }
        }

        [Test]
        public void TestSwitchLangToUkr()
        {
            string rus_prelabel = driver.FindElement(By.ClassName("courses-list-prelabel")).Text;
            driver.FindElement(By.CssSelector(".language-switcher a")).Click();
            Thread.Sleep(1000);
            string ukr_prelabel = driver.FindElement(By.ClassName("courses-list-prelabel")).Text;

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
            driver.FindElement(By.XPath("//div[@class='right-part']/a[contains(text(), 'MY GREEN FOREST')]")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.FindElement(By.CssSelector(".logo a")).Click();

            string actual_header = driver.FindElement(By.CssSelector(".bottom-offset span")).Text.ToLower();

            using (new AssertionScope())
            {
                actual_header.Should().Contain("вхід");
                driver.Url.Should().Be("https://my.greenforest.com.ua/");
            }
        }

        [TestCase("Киев", "дистанционный курс", 6)]
        [TestCase("Харьков", "курс подготовки к ielts", 8)]
        [TestCase("Днепр", "grammar express", 7)]
        [TestCase("Одесса", "летний интенсив", 7)]
        public void TestViewCourses(string CityName, string OriginalCourse, int CoursesQuantity)
        {
            if (CityName != "Киев")
            {
                driver.FindElement(By.ClassName("fa-caret-down")).Click();
                driver.FindElement(By.XPath($"//div[@class='cities-switch']//ul//a[contains(text(), '{CityName}')]")).Click();
            }
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName("details")).Click();
            List<IWebElement> Courses = new List<IWebElement>();
            Courses.AddRange(driver.FindElements(By.ClassName("title")));
            List<string> CoursesNames = new List<string>();
            foreach (IWebElement element in Courses)
                CoursesNames.Add(element.Text.Trim().ToLower());

            using (new AssertionScope())
            {
                CoursesNames.Should().Contain(OriginalCourse);
                CoursesNames.Should().HaveCount(CoursesQuantity);
            }
        }
    }
}
