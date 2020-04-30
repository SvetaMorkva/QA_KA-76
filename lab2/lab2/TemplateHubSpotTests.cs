using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace lab2
{
    public class TemplateTests
    {
        private IWebDriver driver;
        private readonly string email = "olha.pashnieva@gmail.com";
        private readonly string password = "QALab123456";

        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://app.hubspot.com/login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            // login to HubSpot
            driver.FindElement(By.Id("username")).SendKeys(email);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("loginBtn")).Submit();

            // go to Templates page
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-primary-conversations-branch")).Click();
            driver.FindElement(By.Id("nav-secondary-templates")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        [TearDown]
        public void quitDriver()
        {
            driver.Quit();
        }

        [Test]
        [Obsolete]
        public void AddFolderToTemplates()
        {
            By createFolderButton = By.CssSelector("button[class='uiButton private-button private-button--secondary private-button--default template-index-new-folder-button private-button--non-responsive private-button--non-link']");
            By addFolderButton = By.CssSelector("button[class='uiButton private-button private-button--primary private-button--default private-button--non-link']");
            driver.FindElement(createFolderButton).Click();
            driver.FindElement(By.CssSelector("input[class='form-control private-form__control']")).SendKeys(randomStr);

            wait.Until(ExpectedConditions.ElementIsVisible(addFolderButton));
            driver.FindElement(addFolderButton).Click();

            System.Threading.Thread.Sleep(1500);
            By newestFolderElem = By.CssSelector("a[data-selenium-test='sales-content-index-table-folder-link']");
            string newestFolderName = driver.FindElement(newestFolderElem).GetAttribute("textContent");

            Assert.AreEqual(randomStr, newestFolderName);
        }

    }
}