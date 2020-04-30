using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab_2
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private string _url = "https://opac.kpi.ua/";

        private IWebElement WaitForFindElement(IWebDriver driver, By selector)
        {
            Thread.Sleep(500);
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(selector));
            return driver.FindElement(selector);
        }

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url.Contains(_url));

            WaitForFindElement(driver, By.XPath("//a[contains(text(), 'Формуляр')]")).Click();
            Thread.Sleep(3000);
            WaitForFindElement(driver, By.CssSelector("input[name='bor_id']")).Click();
            WaitForFindElement(driver, By.CssSelector("input[name='bor_id']")).SendKeys("11753089");
            WaitForFindElement(driver, By.CssSelector("input[name='bor_verification']")).SendKeys("watermelob");
            WaitForFindElement(driver, By.CssSelector("input[alt='Ввійти']")).Click();
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }

        [Test]
        public void TestLogin()
        {
            string actual_title = WaitForFindElement(driver, By.ClassName("title")).Text;
            using (new AssertionScope())
                actual_title.Should().Contain("Завальнюк Юлія");
        }

        [Test]
        public void TestLogout()
        {
            WaitForFindElement(driver, By.XPath("//a[contains(text(), 'Вихід')]")).Click();
            WaitForFindElement(driver, By.CssSelector("a img[alt='Завершити']")).Click();
            WaitForFindElement(driver, By.XPath("//a[contains(text(), 'Формуляр')]")).Click();

            string actual_title = WaitForFindElement(driver, By.ClassName("bar")).Text;
            using (new AssertionScope())
                actual_title.Should().NotContain("Завальнюк Юлія");
        }

        [Test]
        public void TestViewHoldRequestHsitory()
        {
            IWebElement LoanHistory = WaitForFindElement(driver, By.CssSelector(".indent1[cellspacing='2'] .td1:nth-of-type(2) a[href*='history-hold']"));
            string mainLoansNumber = LoanHistory.Text;
            LoanHistory.Click();

            List<IWebElement> HistoryItems = new List<IWebElement>();
            HistoryItems.AddRange(driver.FindElements(By.Id("centered")));

            using (new AssertionScope())
            {
                mainLoansNumber.Should().Be("6");
                HistoryItems.Should().HaveCount(6);
            }
        }

        [TestCase("Война и мир", "Толстой")]
        [TestCase("Преступление и наказание", "Достоевский")]
        [TestCase("Идиот", "Достоевский")]

        public void TestViewDetails(string Name, string expectedAuthor)
        {
            WaitForFindElement(driver, By.CssSelector("a[title='Загальний каталог']")).Click();
            WaitForFindElement(driver, By.ClassName("keyboardInput")).SendKeys(Name);
            WaitForFindElement(driver, By.CssSelector("input[alt*='Пошук']")).Click();
            WaitForFindElement(driver, By.XPath($"//a[contains(text(), '{Name}')]")).Click();

            string actualAuthor = WaitForFindElement(driver, By.CssSelector(".td1 a")).Text;

            using (new AssertionScope())
                actualAuthor.Should().Contain(expectedAuthor);
        }

        [TestCase("Гаррі Поттер")]
        [TestCase("Захар Беркут")]
        [TestCase("Маруся")]
        public void TestOrderBook(string Name)
        {
            WaitForFindElement(driver, By.CssSelector("a[title='Загальний каталог']")).Click();
            WaitForFindElement(driver, By.ClassName("keyboardInput")).SendKeys(Name);
            WaitForFindElement(driver, By.CssSelector("input[alt*='Пошук']")).Click();
            WaitForFindElement(driver, By.XPath($"//a[contains(text(), '{Name}')]")).Click();

            WaitForFindElement(driver, By.XPath("//a[contains(text(), 'Покласти на ')]")).Click();
            WaitForFindElement(driver, By.CssSelector("input[type='image']")).Click();

            string actual_message = WaitForFindElement(driver, By.CssSelector("b[style]")).Text;
            WaitForFindElement(driver, By.XPath($"//a[contains(text(), 'Моя е-Полиця')]")).Click();

            string actual_name = WaitForFindElement(driver, By.CssSelector(".td1[width='21%']")).Text;

            using (new AssertionScope())
            {
                actual_message.Should().Contain("Відібраний запис покладено на");
                actual_name.Should().Contain(Name);
            }
        }

        [TestCase("Науковий вісник")]
        [TestCase("Системи керування")]
        public void TestOrderMagazine(string Name)
        {
            WaitForFindElement(driver, By.CssSelector("a[title='Загальний каталог']")).Click();
            WaitForFindElement(driver, By.ClassName("keyboardInput")).SendKeys(Name);
            WaitForFindElement(driver, By.XPath("//option[text()='Періодика']")).Click();
            WaitForFindElement(driver, By.CssSelector("input[alt*='Пошук']")).Click();

            WaitForFindElement(driver, By.XPath($"//a[contains(text(), '{Name}')]")).Click();

            WaitForFindElement(driver, By.XPath("//a[contains(text(), 'Покласти на ')]")).Click();
            WaitForFindElement(driver, By.CssSelector("input[type='image']")).Click();

            string actual_message = WaitForFindElement(driver, By.CssSelector("b[style]")).Text;
            WaitForFindElement(driver, By.XPath($"//a[contains(text(), 'Моя е-Полиця')]")).Click();

            string actual_name = WaitForFindElement(driver, By.CssSelector(".td1[width='21%']")).Text;

            using (new AssertionScope())
            {
                actual_message.Should().Contain("Відібраний запис покладено на");
                actual_name.Should().Contain(Name);
            }
        }

        [Test]
        public void TestViewOrdersHistory()
        {
            IWebElement LoanHistory = WaitForFindElement(driver, By.CssSelector(".indent1[cellspacing='2'] .td1:nth-of-type(2) a[href*='history-loan']"));
            string mainLoansNumber = LoanHistory.Text;
            LoanHistory.Click();

            List<IWebElement> HistoryItems = new List<IWebElement>();
            HistoryItems.AddRange(driver.FindElements(By.Id("centered")));

            using (new AssertionScope())
            {
                mainLoansNumber.Should().Be("4");
                HistoryItems.Should().HaveCount(4);
            }
        }

        [Test]
        public void TestCancelOrderBook()
        {
            WaitForFindElement(driver, By.XPath($"//a[contains(text(), 'Моя е-Полиця')]")).Click();

            List<IWebElement> All_Items = new List<IWebElement>();
            All_Items.AddRange(driver.FindElements(By.CssSelector("input[type='checkbox']")));
            int prev_count = All_Items.Count;
            All_Items.Clear();

            WaitForFindElement(driver, By.CssSelector("input[type='checkbox']")).Click();
            WaitForFindElement(driver, By.XPath("//a[contains(text(), 'Видалити')]")).Click();

            All_Items.AddRange(driver.FindElements(By.CssSelector("input[type='checkbox']")));
            int actual_count = All_Items.Count;

            string actual_message = WaitForFindElement(driver, By.CssSelector("b[style]")).Text;

            using (new AssertionScope())
            {
                actual_count.Should().Be(prev_count - 1);
                actual_message.Should().Contain("Документи були видалені");
            }
        }
    }
}
