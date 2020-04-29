using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Linq;

namespace lab2
{
    public class ContactsTests
    {
        private IWebDriver driver;
        private readonly string email = "olha.pashnieva@gmail.com";
        private readonly string password = "QALab123456";

        private readonly By createContactButton = By.CssSelector("button[data-selenium-test='new-object-button']");
        private readonly By contactEmailInput = By.CssSelector("input[data-selenium-test='property-input-email']");
        private readonly By createButton = By.CssSelector("button[data-selenium-test='base-dialog-confirm-btn']");

        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");


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

            // go to Contacts page
            driver.FindElement(By.Id("nav-primary-contacts-branch")).Click();
            driver.FindElement(By.Id("nav-secondary-contacts")).Click();
        }

        [Test]
        public void CreateContactTroughEmailOnly()
        {
            string contactEmail = randomStr + "@me.com";

            driver.FindElement(createContactButton).Click();
            driver.FindElement(contactEmailInput).SendKeys(contactEmail);

            // var createButtonClickable = waiterVar.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(createButton));
            // createButtonClickable.Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(createButton).Click();

            // verify contact is created
            By createdContactEmailSpan = By.CssSelector("span[data-selenium-test='highlightTitle']>span");
            string createdContactEmail = driver.FindElement(createdContactEmailSpan).GetAttribute("textContent");

            Assert.AreEqual(contactEmail, createdContactEmail);
        }

        [Test]
        public void AttemptCreatingContactWithInvalidEmail()
        {
            driver.FindElement(createContactButton).Click();
            driver.FindElement(contactEmailInput).SendKeys(randomStr);
            driver.FindElement(createButton).Click();

            By errorElem = By.CssSelector("i18n-string[data-key='customerDataProperties.PropertyInput.errorMessageInvalidEmail']");
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> invalidEmailError = driver.FindElements(errorElem);
            Assert.AreEqual(1, invalidEmailError.Count());
        }


    }
}