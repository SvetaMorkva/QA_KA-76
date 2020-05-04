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
            Thread.Sleep(1000);
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

            var logIn = new LogIn_Out(driver);
            var formularPage = new Formular(driver);

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.Url.Contains(_url));

            formularPage.GoToFomularPage();
            Thread.Sleep(3000);
            logIn.EnterCredentials("11753089", "watermelob").
                SubmitCredentials();
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }

        [Test]
        public void TestLogin()
        {
            var formularPage = new Formular(driver);

            string actual_title = formularPage.GetFormularTitle();

            actual_title.Should().Contain("Завальнюк Юлія");
        }

        [Test]
        public void TestLogout()
        {
            var logOut = new LogIn_Out(driver);
            var formularPage = new Formular(driver);

            logOut.LogOut_EndSession();
            formularPage.GoToFomularPage();

            string actual_title = formularPage.GetFormularTitle();

            actual_title.Should().NotContain("Завальнюк Юлія");
        }

        [Test]
        public void TestViewHoldRequestHsitory()
        {
            var formularPage = new Formular(driver);

            string mainLoansNumber = formularPage.GetHoldReqestsMainPage();
            formularPage.GoToHoldRequests();

            int loansNumber = formularPage.GetHistoryItemsCount();

            using (new AssertionScope())
            {
                mainLoansNumber.Should().Be("6");
                loansNumber.Should().Be(6);
            }
        }

        [TestCase("Война и мир", "Толстой")]
        [TestCase("Преступление и наказание", "Достоевский")]
        [TestCase("Идиот", "Достоевский")]

        public void TestViewDetails(string Name, string expectedAuthor)
        {
            var catalogPage = new Catalog(driver);

            catalogPage.GoToCatalog().
                EnterBookName(Name).
                SubmitSearch().
                SelectBookWithName(Name);

            string actualAuthor = catalogPage.GetBookAuthor();

            actualAuthor.Should().Contain(expectedAuthor);
        }

        [TestCase("Гаррі Поттер")]
        [TestCase("Захар Беркут")]
        [TestCase("Маруся")]
        public void TestOrderBook(string Name)
        {
            var catalogPage = new Catalog(driver);
            var eShelfPage = new EShelf(driver);

            catalogPage.GoToCatalog().
                EnterBookName(Name).
                SubmitSearch().
                SelectBookWithName(Name).
                PutBookOnEShelf();

            string actual_message = catalogPage.GetCatalogMessage();

            eShelfPage.GoToEShelf();

            string actual_name = eShelfPage.GetBookName();

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
            var catalogPage = new Catalog(driver);
            var eShelfPage = new EShelf(driver);

            catalogPage.GoToCatalog().
                EnterBookName(Name).
                SelectPeriodic().
                SubmitSearch().
                SelectBookWithName(Name).
                PutBookOnEShelf();

            string actual_message = catalogPage.GetCatalogMessage();

            eShelfPage.GoToEShelf();
            string actual_name = eShelfPage.GetBookName();

            using (new AssertionScope())
            {
                actual_message.Should().Contain("Відібраний запис покладено на");
                actual_name.Should().Contain(Name);
            }
        }

        [Test]
        public void TestViewOrdersHistory()
        {
            var formularPage = new Formular(driver);

            string mainLoansNumber = formularPage.GetOrdersHistoryMainPage();
            formularPage.GoToOrdersHistory();

            int loansNumber = formularPage.GetHistoryItemsCount();

            using (new AssertionScope())
            {
                mainLoansNumber.Should().Be("4");
                loansNumber.Should().Be(4);
            }
        }

        [Test]
        public void TestCancelOrderBook()
        {
            var eShelfPage = new EShelf(driver);

            eShelfPage.GoToEShelf();
            int prev_count = eShelfPage.CountEShelfItems();

            eShelfPage.DeleteFirstItem();

            int actual_count = eShelfPage.CountEShelfItems();

            string actual_message = eShelfPage.GetEShelfMessage();

            using (new AssertionScope())
            {
                actual_count.Should().Be(prev_count - 1);
                actual_message.Should().Contain("Документи були видалені");
            }
        }
    }
}
