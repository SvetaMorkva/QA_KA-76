using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab2
{
    public class ContactsTests
    {
        private IWebDriver driver;
        private readonly string email = "olha.pashnieva@gmail.com";
        private readonly string password = "QALab123456";

        private readonly By createContactButton = By.CssSelector("button[data-button-use='primary']");
        private readonly By contactEmailInput = By.CssSelector("input[data-selenium-test='property-input-email']");
        private readonly By createButton = By.CssSelector("button[data-selenium-test='base-dialog-confirm-btn']");

        private readonly string randomStr = Path.GetRandomFileName().Replace(".", "");
        Random rand = new Random();
        WebDriverWait wait;


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
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://app.hubspot.com/contacts/");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void quitDriver()
        {
            driver.Quit();
        }

        private List<string> getAllContactsEmails()
        {
            By emailsElemsSelector = By.CssSelector("a[class='private-link uiLinkWithoutUnderline uiLinkDark text-left truncate-text']");
            IWebElement[] emailsElems = driver.FindElements(emailsElemsSelector).ToArray();

            var emailsList = new List<string>();

            foreach (IWebElement emailElem in emailsElems)
            {
                emailsList.Add(emailElem.GetAttribute("textContent"));
            }
            return emailsList;
        }

        [Test]
        [Obsolete]
        public void CreateContactTroughEmailOnly()
        {
            string contactEmail = randomStr + "@me.com";

            // wait.Until(ExpectedConditions.ElementIsVisible(createContactButton));
            System.Threading.Thread.Sleep(4000);
            driver.FindElement(createContactButton).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(contactEmailInput));
            driver.FindElement(contactEmailInput).SendKeys(contactEmail);

            // wait.Until(ExpectedConditions.ElementIsVisible(createButton));
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(createButton).Click();


            // verify contact is created
            System.Threading.Thread.Sleep(3000);
            driver.Navigate().GoToUrl("https://app.hubspot.com/contacts/");
            System.Threading.Thread.Sleep(3000);
            List<string> emailsList = getAllContactsEmails();

            Assert.IsTrue(emailsList.Contains(contactEmail));
        }

        [Test]
        [Obsolete]
        public void AttemptCreatingContactWithInvalidEmail()
        {
            System.Threading.Thread.Sleep(4000);
            driver.FindElement(createContactButton).Click();
            driver.FindElement(contactEmailInput).SendKeys(randomStr);
            wait.Until(ExpectedConditions.ElementIsVisible(createButton));
            driver.FindElement(createButton).Click();

            By errorElem = By.CssSelector("i18n-string[data-key='customerDataProperties.PropertyInput.errorMessageInvalidEmail']");
            var invalidEmailError = driver.FindElements(errorElem);

            Assert.AreEqual(1, invalidEmailError.Count());
        }

        [Test]
        [Obsolete]
        public void DeleteRandomContact()
        {
            List<string> emailsList = getAllContactsEmails();

            // choose random email to delete
            int index;
            try
            {
                index = rand.Next(0, emailsList.Count - 1);
            }
            catch
            {
                Assert.Pass();
            }

            index = rand.Next(0, emailsList.Count - 1);
            string emailToDelete = emailsList[index];

            // delete contact with the index
            By checkSelector = By.CssSelector("span[class='private-checkbox__indicator']");
            IWebElement[] checksElems =  driver.FindElements(checkSelector).ToArray();
            checksElems[index+1].Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span[data-icon-name='delete']")));
            driver.FindElement(By.CssSelector("span[data-icon-name='delete']")).Click();

            driver.FindElement(By.CssSelector("textarea[data-selenium-test='delete-dialog-match']")).SendKeys("1");

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[data-selenium-test='delete-dialog-confirm-button']")));
            driver.FindElement(By.CssSelector("button[data-selenium-test='delete-dialog-confirm-button']")).Click();

            System.Threading.Thread.Sleep(1000);
            List<string> emailsListAfterDel = getAllContactsEmails();

            Assert.IsFalse(emailsListAfterDel.Contains(emailToDelete));
            // Assert.AreEqual(emailToDelete, emailsListAfterDel);
        }


    }
}