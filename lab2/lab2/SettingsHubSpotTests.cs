using lab2.PageObjects;
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
        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");
        private WebDriverWait wait;
        private SettingsPage settings;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            settings = new SettingsPage(driver);
            settings.GoToPage();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        [TearDown]
        public void quitDriver()
        {
            driver.Quit();
        }

        [Test]
        public void ChangeProfileName()
        {
            settings.basicInfoSection.Click();
            settings.editProfileNameButton.Click();

            string randomName = randomStr;
            string randomSurname = randomStr + "Surname";
            string fullRandomName = randomName + " " + randomSurname;

            settings.EnterNewProfileName(randomName, randomSurname);
            settings.saveProfileNameButton.Click();

            System.Threading.Thread.Sleep(1000);
            string newName = settings.GetProfileName();

            Assert.AreEqual(fullRandomName, newName);
        }

        [Test]
        public void ChangeAccountName()
        {
            // settings.accountDefaultsSection.Click();
            settings.EnterNewAccountName(randomStr);

            wait.Until(ExpectedConditions.ElementToBeClickable(settings.saveChangesButton));
            settings.saveChangesButton.Click();

            System.Threading.Thread.Sleep(1000);
            string newAccName = settings.GetAccountName();

            Assert.AreEqual(randomStr, newAccName);
        }
    }
}