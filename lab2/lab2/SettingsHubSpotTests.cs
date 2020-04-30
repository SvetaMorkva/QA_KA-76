using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace lab2
{
    public class SettingsTests
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

            // go to Settings page
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://app.hubspot.com/crm-settings-task-reminders/7600578/tasks");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        [TearDown]
        public void quitDriver()
        {
            // driver.Quit();
        }

        [Test]
        public void ChangeProfileName()
        {
            driver.FindElement(By.CssSelector("a[data-selenium-id='Basic info']")).Click();
            driver.FindElement(By.XPath("//span[@data-test-id='edit-name']/span")).Click();

            string randomName = randomStr;
            string randomSurname = randomStr + "Surname";
            string fullRandomName = randomName + " " + randomSurname;

            driver.FindElement(By.CssSelector("input[data-test-id='first-name']")).Clear();
            driver.FindElement(By.CssSelector("input[data-test-id='last-name']")).Clear();

            driver.FindElement(By.CssSelector("input[data-test-id='first-name']")).SendKeys(randomName);
            driver.FindElement(By.CssSelector("input[data-test-id='last-name']")).SendKeys(randomSurname);

            driver.FindElement(By.CssSelector("button[data-test-id='save-name']")).Click();

            System.Threading.Thread.Sleep(1000);
            string newName = driver.FindElement(By.CssSelector("span[data-test-id='name']")).GetAttribute("innerHTML");

            Assert.AreEqual(fullRandomName, newName);
        }

        [Test]
        [Obsolete]
        public void ChangeAccountName()
        {
            By accNameField = By.CssSelector("input[class='form-control private-form__control']");
            driver.FindElement(By.CssSelector("a[data-selenium-id='Account defaults']")).Click();
            driver.FindElement(accNameField).Clear();
            driver.FindElement(accNameField).SendKeys(randomStr);

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[data-test-id='save-footer-confirm-btn']")));
            driver.FindElement(By.CssSelector("button[data-test-id='save-footer-confirm-btn']")).Click();

            System.Threading.Thread.Sleep(1000);
            string newAccName = driver.FindElement(accNameField).GetAttribute("value");

            Assert.AreEqual(randomStr, newAccName);
        }
    }
}